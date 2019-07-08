using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.IO;
using EDICommons.Tools;
using EDI_DB.Data;
using static EDI_DB.Data.Base;

namespace EDI_RSS.Helpers
{
    public partial class Program_855 : EDI_RSS.Program_Base
    {
        public Program_855()
        {
            TransactionCode = "855";
            LogEventSource = "EDI 855 Processor";

            Xml855Writer xml;

            List<IDataRecord> RawDataDetails;
            string cocom_ident;
            string edi_ident;

            Status += "Program_855" + NL + "UseSystem: " + UseSystem + NL + "TheFilename: " + Filename + NL;
            Status += "RSS_send_path: " + RSS_send_path + NL;
            Status += "DB_VIVA: " + DB_VIVA.conn.ConnectionString + NL;
            Status += "PortID: " + PortId + NL;

            try
            {
                //Create/Update edi_855 table to "catch" differences since last time we ran this interface
                //Status += "CreateNew" + NL;
                //CreateNew();
                Status += "UpdateExisting" + NL;
                UpdateExisting();

                //After create/update of 855 data, edi_855 rows marked as "New" and "Not Sent" are used to generate the actual X12 855 document(s)
                Status += "GetData" + NL;
                List<IDataRecord> RawData = GetData();

                if (RawData == null)
                {
                    Status += "No XML Records to process" + NL;
                }
                else
                {
                    //There might be multiple 855, each group represents a single one
                    foreach (IDataRecord Data in RawData)
                    {
                        cocom_ident = Data["cocom_ident"].ToString();
                        edi_ident = Data["edi_855_ident"].ToString();

                        SetupClient(Convert.ToInt32(Data["cocom_clientid"]));

                        Status += "GetDataLines: " + cocom_ident + NL;

                        RawDataDetails = GetDataDetails(cocom_ident);

                        xml = new Xml855Writer(Data, RawDataDetails);

                        string strXml = xml.Write(this);

                        if (gIDataEdi_path["Has_accent"].ToString() == "0")
                        {
                            strXml = RemoveDiacritics(strXml);
                        }

                        strXml = ReplaceTildeAndPipe(strXml);

                        File.WriteAllText(xml.XmlFilePath, strXml);

                        UpdateFilename("edi_855", xml.OutputFileName, edi_ident);
                    }
                }

            }
            catch (System.Exception e)
            {
                Error += "Error caught: " + e.ToString();
                // Something unexpected went wrong.
                LogWriter.WriteMessage(LogEventSource, $"Error caught: {e.ToString()}");
            }
        }

        //public void CreateNew()
        //{
        //    DB_VIVA.HExecuteSQLNonQuery(@"start transaction;
        //                        insert into edi_855(IdCocom, Status, Validator)
        //                        select Id, Stat, NewValidator from
        //                        (select cocom.ident as Id, 'N' as Stat,
        //                                GROUP_CONCAT(cocomi.line, '|', cocomi.idprod, '|', cocomi.QTY_ORD, '|', ifnull(cobili.QTY, ''), '|', ifnull(cocom.req_dte, ''), '|', ifnull(cobil.REQ_DTE, '')
        //                                ORDER BY cocomi.line SEPARATOR '\r') AS NewValidator, edi_855.Validator
        //                        from cocom
        //                        inner join cocomi on cocom.ident = cocomi.idco
        //                        left
        //                        join cobili on cocom.ident = cobili.idcom and cocomi.idprod = cobili.idprod
        //                        left join cobil on cobil.ident = cobili.idcobil
        //                        left join edi_855 on cocom.ident = edi_855.IdCocom
        //                        WHERE LEFT(cocom.CR_BY, 4) = 'XEDI'
        //                        GROUP BY cocom.ident
        //                        having isnull(edi_855.Validator)) as TempQuery;
        //                        commit; ", Params);
        //}

        public void UpdateExisting()
        {
            //update status to x for good commands
            DB_VIVA.HExecuteSQLNonQuery(@"
                    UPDATE EDI_855
                        INNER JOIN cocom ON cocom.ident = edi_855.IdCocom
                    SET EDI_855.Status = 'X'  
                        WHERE LEFT(cocom.CR_BY, 4) = 'XEDI' AND edi_855.Status = 'N'
                        AND (SELECT IFNULL(SUM(cocomi.qty_ord), 0) FROM cocomi WHERE cocomi.idco = cocom.ident) =
					        (SELECT IFNULL(SUM(arinvd.qty), 0) FROM arinvd INNER JOIN arinv ON arinvd.ident = arinv.ident WHERE arinvd.idcom = cocom.ident AND arinv.status = 'P') 
					");

            DB_VIVA.HExecuteSQLNonQuery(
                @"START TRANSACTION;

                    SET @Ids := 
                    (SELECT GROUP_CONCAT(Id) FROM
                    (SELECT edi_855.Ident as Id,
		                    GROUP_CONCAT(cocomi.line,'|',cocomi.idprod, '|', cocomi.QTY_ORD, '|', ifnull(cobili.QTY, ''), '|',ifnull(cocom.req_dte, ''), '|', ifnull(cobil.REQ_DTE, '') 
                            ORDER BY cocomi.line SEPARATOR '\r') AS NewValidator, edi_855.Validator, edi_855.Status
                    FROM cocom
                    INNER JOIN cocomi ON cocom.ident = cocomi.idco
                    LEFT JOIN cobili ON cocom.ident = cobili.idcom AND cocomi.idprod = cobili.idprod
                    LEFT JOIN cobil ON cobil.ident = cobili.idcobil
                    LEFT JOIN edi_855 ON cocom.ident = edi_855.IdCocom
                    WHERE LEFT(cocom.CR_BY, 4) = 'XEDI' AND edi_855.Status = 'N'
                    AND (cobil.statut = 'W' OR cobil.statut = 'C' OR cobil.statut IS NULL)
                    AND (SELECT IFNULL(SUM(cocomi.qty_ord), 0) FROM cocomi WHERE cocomi.idco = cocom.ident) <>
					    (SELECT IFNULL(SUM(arinvd.qty), 0) FROM arinvd INNER JOIN arinv ON arinvd.ident = arinv.ident WHERE arinvd.idcom = cocom.ident AND arinv.status = 'P') 
                    GROUP BY cocom.ident
                    HAVING (NewValidator <> edi_855.Validator)) AS TmpQuery);

                    INSERT INTO edi_855 (IdCocom, Status, Validator)
                    SELECT Id, Stat, NewValidator FROM
                    (SELECT cocom.ident AS Id, 'N' AS Stat,
		                    GROUP_CONCAT(cocomi.line,'|',cocomi.idprod, '|', cocomi.QTY_ORD, '|', ifnull(cobili.QTY, ''), '|',ifnull(cocom.req_dte, ''), '|', ifnull(cobil.REQ_DTE, '') 
                            ORDER BY cocomi.line SEPARATOR '\r') AS NewValidator, edi_855.Validator, edi_855.Status
                    FROM cocom
                    INNER JOIN cocomi ON cocom.ident = cocomi.idco
                    LEFT JOIN cobili ON cocom.ident = cobili.idcom AND cocomi.idprod = cobili.idprod
                    LEFT JOIN cobil ON cobil.ident = cobili.idcobil
                    LEFT JOIN edi_855 on cocom.ident = edi_855.IdCocom
                    WHERE LEFT(cocom.CR_BY, 4) = 'XEDI' AND edi_855.Status = 'N'
                    AND (cobil.statut = 'W' OR cobil.statut = 'C' OR cobil.statut IS NULL)
                    AND (SELECT IFNULL(SUM(cocomi.qty_ord), 0) FROM cocomi WHERE cocomi.idco = cocom.ident) <>
					    (SELECT IFNULL(SUM(arinvd.qty), 0) FROM arinvd INNER JOIN arinv ON arinvd.ident = arinv.ident WHERE arinvd.idcom = cocom.ident AND arinv.status = 'P') 
                    GROUP BY cocom.ident
                    HAVING (NewValidator <> edi_855.Validator)) AS TempQuery;

                    UPDATE edi_855
                    SET Status = 'O'
                    WHERE FIND_IN_SET(Ident, @Ids) AND ident <> 0;

                    COMMIT;");

        }

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  cocom.ident AS cocom_ident, cocom.clientpo AS cocom_clientpo, cocom.clientid AS cocom_clientid, cocom.co_dte AS cocom_co_dte, 
                        cocom.del_name as cocom_del_name, cocom.daddr1 AS cocom_daddr1, cocom.daddr2 AS cocom_daddr2, 
                        cocom.dcity as cocom_dcity, cocom.dstate as cocom_dstate, cocom.dzip as cocom_dzip,
                        edi_855.ident AS edi_855_ident, edi_855.filename AS edi_855_filename
                FROM cocom 
                INNER JOIN edi_855 ON edi_855.idcocom = cocom.ident
                LEFT JOIN cocomi ON cocomi.idco = cocom.ident
                WHERE 
                        LEFT(cocom.CR_BY, 4) = 'XEDI' 
                        AND edi_855.Status = 'N' 
                        AND edi_855.Sent = false
                        AND (SELECT IFNULL(SUM(cocomi.qty_ord), 0) FROM cocomi WHERE cocomi.idco = cocom.ident) <>
					        (SELECT IFNULL(SUM(arinvd.qty), 0) FROM arinvd INNER JOIN arinv ON arinvd.ident = arinv.ident WHERE arinvd.idcom = cocom.ident AND arinv.status = 'P') 
                GROUP BY cocom.ident
                ");

            // AND cocom.clientpo = '4500000387'
            // AND(cocom.clientpo = '4501000399' or cocom.clientpo = '4501000375' or cocom.clientpo = '4501000291' or cocom.clientpo = '4501000073')
            //or cocom.clientpo = '4501000375' or cocom.clientpo = '4501000291' or cocom.clientpo = '4501000073')

        }

        public List<IDataRecord> GetDataDetails(string cocom_ident)
        {
            Params.Clear();
            Params.Add("?cocom_ident", cocom_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  cocom.ident AS cocom_ident, cocom.clientpo AS cocom_clientpo, cocom.clientid AS cocom_clientid, cocom.co_dte AS cocom_co_dte, 
                                        cocom.del_name as cocom_del_name, cocom.daddr1 AS cocom_daddr1, cocom.daddr2 AS cocom_daddr1, 
                        cocom.dcity as cocom_dcity, cocom.dstate as cocom_dstate, cocom.dzip as cocom_dzip, 
                        cocomi.line AS cocomi_line, cocomi.idprod, cocomi.desc, cocomi.qty_ord AS cocomi_qty_ord, 
                        cocomi.req_date AS cocomi_req_date, cocomi.unite AS cocomi_unite, cocomi.price AS cocomi_price, 
                        ivprod.code AS ivprod_code, ivprod.ident AS ivprod_ident,
                        ivprixdcli.codecli AS ivprixdcli_codecli,
                        edi_855.ident AS edi_855_ident
                FROM cocom 
                INNER JOIN cocomi ON cocom.ident = cocomi.idco
                INNER JOIN ivprod ON ivprod.ident = cocomi.idprod
                INNER JOIN edi_855 ON edi_855.idcocom = cocom.ident
                LEFT JOIN ivprixdcli ON (ivprixdcli.idclient = cocom.clientid AND ivprixdcli.idprod = cocomi.idprod AND IFNULL(ivprixdcli.codecli, '') <> '')
                WHERE LEFT(cocom.cr_by, 4) = 'XEDI' AND edi_855.Status = 'N' AND edi_855.Sent = false
                AND cocom.ident = ?cocom_ident
                ORDER BY cocom.ident, cocomi.line
                ", Params);

        }

        public List<IDataRecord> GetDataLines(string cocom_ident, string cocomi_line)
        {
            Params.Clear();
            Params.Add("?cocom_ident", cocom_ident);
            Params.Add("?cocomi_line", cocomi_line);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  cocom.ident AS cocom_ident, cocom.clientpo AS cocom_clientpo, cocom.clientid, cocom.co_dte AS cocom_co_dte, 
                        cocomi.line, cocomi.idprod, cocomi.desc, cocomi.qty_ord AS cocomi_qty_ord, cocomi.req_date AS cocomi_req_date, cocomi.unite AS cocomi_unite, cocomi.price AS cocomi_price, 
                        ivprod.code AS ivprod_code,
                        cobil.req_dte AS cobil_req_date, cobil.ident AS cobil_ident, 
                        cobili.qty AS cobili_qty, 
                        ivprixdcli.codecli AS ivprixdcli_codecli
                FROM cocom 
                INNER JOIN cocomi ON cocom.ident = cocomi.idco
                INNER JOIN ivprod ON ivprod.ident = cocomi.idprod
                INNER JOIN edi_855 ON edi_855.IdCocom = cocom.ident       
                LEFT JOIN cobili ON cobili.idcom = cocom.ident AND cobili.idprod = cocomi.IDPROD
                LEFT JOIN cobil ON cobil.ident = cobili.IDCOBIL
                LEFT JOIN ivprixdcli ON (ivprixdcli.idclient = cocom.clientid AND ivprixdcli.idprod = cocomi.idprod AND IFNULL(ivprixdcli.codecli, '') <> '')
                WHERE 
                        LEFT(cocom.CR_BY, 4) = 'XEDI' 
                    AND edi_855.Status = 'N' 
                    AND edi_855.Sent = false
                    AND (cobil.statut = 'W' OR cobil.statut = 'C')
                    AND cocom.ident = ?cocom_ident 
                    AND cocomi.line = ?cocomi_line
                ", Params);
        }
    }

    class Xml855Writer : DB_XmlWriter
    {
        private IDataRecord DataCocom;
        private CIDataRecord CDataCocom;
        private List<IDataRecord> RawDataCocomi;
        
        public Xml855Writer(IDataRecord TheDataCocom, List<IDataRecord> TheDataCocomi)
        {

            DataCocom = TheDataCocom;
            CDataCocom = new CIDataRecord(DataCocom);
            RawDataCocomi = TheDataCocomi;

            ClientID = DataCocom["cocom_clientid"].ToString();

            OutputFileName = $"{ClientID.PadLeft(5, '0')}-855-OUT-{DataCocom["cocom_ident"].ToString()}-{Base.ToAlphaNumeric(DataCocom["cocom_clientpo"].ToString())}-{(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds}";

            edi_doc_number = 855;
            IDpartner = GetInt(ClientID);

            gIDataEdi_path = GetEdi_partner("edi_arclient");

            if (gIDataEdi_path != null)
            {
                SetRouting_out_path("xml_x12");

                XmlFilePath = Path.Combine(RSS_send_path, OutputFileName + ".xml");

                Status += "Xml855Writer " + NL;
                Status += "OutputFileName: " + OutputFileName + NL;
                Status += "XmlFilePath: " + XmlFilePath + NL;
            }
        }

        public string Write(Program_855 mysql)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            string TransactionControlNumber = rand.Next(0, 101).ToString("0000");
            
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;

            int ClientId = Convert.ToInt32(DataCocom["cocom_clientid"]);
            Decimal TotalNumberOfLineItem = 0;
            Decimal TotalNumberOfLineItemQty = 0;

            IDataRecord DataAddress = DB_VIVA.GetAddressST(ClientId, DataCocom["cocom_dzip"].ToString());

            string iddel_addr = "";

            if (DataAddress != null) { iddel_addr = DataAddress["iddel_addr"].ToString(); }

            using (var sw = new StringWriter())
            {
                using (writer = XmlWriter.Create(sw, settings))
                {
                    writer.WriteStartElement("TransactionSet");
                    writer.WriteStartElement("TX-00403-855");
                    writer.WriteAttributeString("type", "TransactionSet");

                    writer.WriteStartElement("Meta");

                    writer.WriteElementString("ST01", "", "855"); // Transaction Set Identifier Code: 855 - Purchase Order Acknowledgment
                    writer.WriteElementString("ST02", "", TransactionControlNumber); // Transaction Set Control Number

                    writer.WriteEndElement(); //Meta

                    //BAK segement
                    WriteSegment("BAK", "Segment", "Fixed: Original", "00", //Transaction Set Purpose Code: "00" = Original / "06" = Confirmation
                                                   "Fixed: Acknowledgment Type: Acknowledge product replenishment", "AP",
                                                   "cocom_clientpo", CDataCocom["cocom_clientpo"],
                                                   "cocom_co_dte", string.Format("{0:yyyyMMdd}", DataCocom["cocom_co_dte"]),
                                                   "Fixed: Release Number", "",
                                                   "Fixed: Request Reference Number", "",
                                                   "Fixed: Contract Number", "",
                                                   "cocom_ident", CDataCocom["cocom_ident"],
                                                   "cocom_co_dte", string.Format("{0:yyyyMMdd}", DataCocom["cocom_co_dte"])
                                                   );

                    //REF segment
                    // WriteSegment("REF", "Segment", "VR", "TBD"); //TODO: get the EL supplier ID for the current customer

                    //DTM segment
                    //TODO: decide if we will send the DTM once for the order, once per item, or both
                    // WriteSegment("DTM", "Segment", "002", string.Format("{0:yyyyMMdd}", RawDataPO.ElementAt(0)["cocomi_req_date"])); //Requested shipping date

                    WriteN1Loop1(EntityCode1.ST, EntityCode2.BuyerCode, CDataCocom,
                        "iddel_addr", "2000", //iddel_addr
                        "cocom_del_name",
                        "cocom_daddr1",
                        "cocom_daddr2",
                        "cocom_dcity",
                        "cocom_dstate",
                        "cocom_dzip"
                    );

                    foreach (var DataCocomiItem in RawDataCocomi)
                    {
                        decimal QtyOrdered = Convert.ToDecimal(mysql.IsNull(DataCocomiItem["cocomi_qty_ord"]));
                        decimal TotalNumberOfShippingQty = 0;

                        TotalNumberOfLineItem++;
                        TotalNumberOfLineItemQty += Math.Abs(QtyOrdered);

                        writer.WriteStartElement("PO1Loop1");
                        writer.WriteAttributeString("type", "Loop");
                        {
                            WriteSegment("PO1", "Segment",
                                "Calc: cocomi_line * 10", (Convert.ToInt16(DataCocomiItem["cocomi_line"]) * 10).ToString(), //Assigned Identification (line number)
                                "cocomi_qty_ord", DataCocomiItem["cocomi_qty_ord"].ToString(), //Quantity Ordered
                                "Fixed: Unit: Envelope", "EV", //Unit or Basis for Measurement Code
                                "cocomi_price", DataCocomiItem["cocomi_price"].ToString(), //Unit Price
                                "UnitMappings(unite): " + DataCocomiItem["cocomi_unite"].ToString()
                                                            , UnitMappings(DataCocomiItem["cocomi_unite"].ToString()), //Basis of Unit Price Code
                                "Fixed: Buyer's Catalog Number", "CB",
                                "ivprixdcli_codecli", DataCocomiItem["ivprixdcli_codecli"].ToString(),
                                "Fixed: Vendor's (Seller's) Part Number", "VP",
                                $"ivprod_code (ivprod_ident={DataCocomiItem["ivprod_ident"].ToString()})", DataCocomiItem["ivprod_code"].ToString()
                                );

                            WriteSegment("REF", "Segment", "Fixed: Purchase Order Number", "PO", "cocom_clientpo", DataCocom["cocom_clientpo"].ToString());
                            WriteSegment("REF", "Segment", "Fixed: Vendor Order Number", "VN", "cocom_ident", DataCocomiItem["cocom_ident"].ToString());

                            //CTP segment
                            // WriteSegment("CTP", "Segment", "DI", "UCP", item["cocomi_price"].ToString()); // Pricing Information // Already in PO01

                            //DTM segment
                            // WriteSegment("DTM", "Segment", "068", "20200101"); // Date time reference // 017 Estimated Delivery / 067 Current Schedule Delivery // Already in ACK

                            List<IDataRecord> RawDataCocomiLine = mysql.GetDataLines(DataCocomiItem["cocom_ident"].ToString(), DataCocomiItem["cocomi_line"].ToString());

                            //There might be multiple 855, each group represents a single one
                            foreach (IDataRecord DataCocomiLineItem in RawDataCocomiLine)
                            {
                                TotalNumberOfShippingQty += Convert.ToDecimal(mysql.IsNull(DataCocomiLineItem["cobili_qty"]));

                                // ACK01        : "IA": "Item Accepted", "IB": "Item Backordered", "IC": "Item Accepted - Changes Made", "ID": "Item Deleted", "IE": "Item Accepted, Price Pending",
                                //              : "AC": "Item Accepted and Shipped", "AR": "Item Accepted and Released for Shipment", "BP": "Item Accepted - Partial Shipment, Balance Backordered",
                                //              : "DR": "Item Accepted - Date Rescheduled" ... etc
                                // ACK03 / PO103 / SCH02: "EA": "Each", "EV": "Envelope"
                                // ACK04 / SCH05              : "067": "Current Schedule Delivery"

                                if (Convert.ToDecimal(mysql.IsNull(DataCocomiLineItem["cobili_qty"])) != 0)
                                {
                                    WriteSegmentLoop("ACKLoop1", "Loop", "ACK", "Segment",
                                           "Fixed: Item Accepted", "IA",
                                           "cobili_qty", DataCocomiLineItem["cobili_qty"].ToString(),
                                           "Fixed: Unit: Envelope", "EV",
                                           "Fixed: Current Schedule Delivery", "067",
                                           "cobil_req_date", string.Format("{0:yyyyMMdd}", DataCocomiLineItem["cobil_req_date"]));
                                }
                            }

                            if (TotalNumberOfShippingQty < QtyOrdered)
                            {
                                // ACK04        : "100":  "No Shipping Schedule Established as of…"
                                WriteSegmentLoop("ACKLoop1", "Loop", "ACK", "Segment",
                                    "Fixed: Item Backordered", "IB",
                                    "Calc: (QtyOrdered - TotalNumberOfShippingQty)", (QtyOrdered - TotalNumberOfShippingQty).ToString(),
                                    "Fixed: Unit: Envelope", "EV",
                                    "Fixed: No Shipping Schedule Established as of…", "100",
                                    "Calc: Today()", string.Format("{0:yyyyMMdd}", DateTime.Today)
                                    );
                            }

                            //There might be multiple 855, each group represents a single one
                            foreach (IDataRecord DataCocomiLineItem in RawDataCocomiLine)
                            {
                                // ACK03 / PO103 / SCH02: "EA": "Each", "EV": "Envelope"
                                // ACK04 / SCH05              : "067": "Current Schedule Delivery"
                                if (Convert.ToDecimal(mysql.IsNull(DataCocomiLineItem["cobili_qty"])) != 0)
                                {
                                    WriteSegmentLoop("SCHLoop1", "Loop", "SCH", "Segment",
                                       "cobili_qty", DataCocomiLineItem["cobili_qty"].ToString(),
                                       "Fixed: Unit: Envelope", "EV",
                                       "Fixed: Entity Identifier Code", "",
                                       "Fixed: Name", "",
                                       "Fixed: Current Schedule Delivery", "067",
                                       "cobil_req_date", string.Format("{0:yyyyMMdd}", DataCocomiLineItem["cobil_req_date"])
                                       );
                                }
                            }

                            if (TotalNumberOfShippingQty < QtyOrdered)
                            {
                                // ACK04 / SCH05              : "100":  "No Shipping Schedule Established as of…"
                                WriteSegmentLoop("SCHLoop1", "Loop", "SCH", "Segment",
                                       "Calc: (QtyOrdered - TotalNumberOfShippingQty)", (QtyOrdered - TotalNumberOfShippingQty).ToString(),
                                       "Fixed: Unit: Envelope", "EV",
                                       "Fixed: Entity Identifier Code", "",
                                       "Fixed: Name", "",
                                       "Fixed: No Shipping Schedule Established as of…", "100",
                                       "Calc: Today()", string.Format("{0:yyyyMMdd}", DateTime.Today)
                                       );
                            }

                        }
                        writer.WriteEndElement(); //POLoop1

                    }

                    //CTT Loop
                    WriteSegmentLoop("CTTLoop1", "Loop", "CTT", "Segment",
                        "Calc: TotalNumberOfLineItem", TotalNumberOfLineItem.ToString(),
                        "Calc: TotalNumberOfLineItemQty", TotalNumberOfLineItemQty.ToString());

                    writer.WriteEndElement(); //TX-00403-855

                    writer.WriteEndElement(); //TransactionSet

                } // Using XMLWriter
                return sw.ToString();
            }

        } // Write()
    }
}