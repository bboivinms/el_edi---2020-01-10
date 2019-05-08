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
    public class Program_856 : EDI_RSS.Program_Base
    {
        public Program_856()
        {
            TransactionCode = "856";

            LogEventSource = "EDI 856 Processor";

            Xml856Writer xml = null;

            List<IDataRecord> RawDataDetails;
            string cobil_ident;
            string edi_ident;

            Status += "Program_856" + NL + "UseSystem: " + UseSystem + NL + "TheFilename: " + Filename + NL;

            try
            {
                //CreateNew();

                List<IDataRecord> RawData = GetData();

                foreach (IDataRecord Data in RawData)
                {
                    cobil_ident = Data["cobil_ident"].ToString();
                    edi_ident = Data["edi_856_ident"].ToString();

                    SetupClient(Convert.ToInt32(Data["cobil_clientid"]));

                    Status += "GetDataDetails: " + cobil_ident + NL;

                    RawDataDetails = GetDataDetails(cobil_ident);

                    xml = new Xml856Writer(Data, RawDataDetails);

                    xml.Write(this);

                    UpdateFilename("edi_856", xml.OutputFileName, edi_ident);
                }

            }
            catch (System.Exception e)
            {
                Error += "Error caught: " + e.Message;
                LogWriter.WriteMessage(LogEventSource, $"Error caught: {e.Message}");
            }
            finally
            {
            }
        }

        //public void CreateNew()
        //{
        //    DB_VIVA.HExecuteSQLNonQuery(@" 
        //        INSERT INTO edi_856 (cobil_ident) 
        //        SELECT cobil.ident 
        //        FROM cobil
        //            WHERE   cobil.clientid = 30037 AND 
        //                    cobil.ident = 10 AND 
        //                    NOT EXISTS(SELECT 1 FROM edi_856 AS edi_856e WHERE edi_856e.cobil_ident = cobil.ident); 
        //        ALTER TABLE edi_856 AUTO_INCREMENT = 1;");

        //    //update pour mettre le ship date
        //    DateTime dte_now = DateTime.Now;

        //    Params.Clear();
        //    Params.Add("?dte_now", dte_now.ToString());

        //    DB_VIVA.HExecuteSQLQuery(@"UPDATE edi_856 SET Ship_date = ?dte_now WHERE cobil_ident = 10;", Params);
        //}

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT  				
                        cobil.ident AS cobil_ident, cobil.clientid AS cobil_clientid, cobil.clientpo AS cobil_clientpo, cobil.BIL_DTE AS cobil_bil_dte,
                        edi_856.ident AS edi_856_ident, edi_856.filename AS edi_856_filename, edi_856.Ship_date AS edi_856_ship_date,
                        SUM(cobili.qty) AS cobili_qty
                FROM cobil 
                INNER JOIN edi_856 ON edi_856.cobil_ident = cobil.ident
                INNER JOIN cobili ON cobil.ident = cobili.IDCOBIL
                WHERE edi_856.Sent = false 
                      AND
                      cobil.ident = 10 
                      AND
                      cobil.STATUT = 'C'
                ");
        }

        public List<IDataRecord> GetDataDetails(string cobil_ident)
        {
            Params.Clear();
            Params.Add("?cobil_ident", cobil_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  
                        COUNT(cocom.ident) AS nb_items,
                        cobil.ident AS cobil_ident,      
                        edi_856.ident AS edi_856_ident, 
                        cobili.PO_NO AS cobili_po_no, cobili.QTY AS cobili_qty,
                        cocom.CLIENTPO AS cocom_clientpo, cocom.ident AS cocom_ident, cocom.CO_DTE AS cocom_co_dte
                FROM cobil 
                INNER JOIN cobili ON cobil.ident = cobili.idcobil
                INNER JOIN edi_856 ON edi_856.cobil_ident = cobil.ident
                INNER JOIN cocom ON cocom.ident = cobili.IDCOM
                WHERE   edi_856.Sent = false 
                        AND cocom.CLIENTID = 30037 
                        AND cobil.ident = ?cobil_ident
                GROUP BY cocom.ident
                ORDER BY cobili.ident, cobili.line
                ", Params);
        }

        public List<IDataRecord> GetItems(string cobil_ident, string cocom_ident)
        {
            Params.Clear();
            Params.Add("?cobil_ident", cobil_ident);
            Params.Add("?cocom_ident", cocom_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT cobili.LINE AS cobili_line, cobili.QTY AS cobili_qty,
                         cocom.ident AS cocom_ident,
                         ivprod.ident AS ivprod_ident, ivprod.code AS ivprod_code, ivprod.DESC AS ivprod_desc,
                         ivprixdcli.codecli AS ivprixdcli_codecli
                  FROM cobil 
                  INNER JOIN cobili ON cobil.ident = cobili.idcobil
                  INNER JOIN cocom ON cocom.ident = cobili.IDCOM
                  INNER JOIN ivprod ON ivprod.ident = cobili.idprod
                  LEFT JOIN ivprixdcli ON (ivprixdcli.idclient = cobil.CLIENTID AND ivprixdcli.idprod = cobili.IDPROD AND IFNULL(ivprixdcli.codecli, '') <> '')
                  WHERE cobil.ident = ?cobil_ident 
                       AND cocom.ident = ?cocom_ident
                  ORDER BY cobili.ident, cobili.line
                ", Params);
        }

        public List<IDataRecord> GetShippedDate(string cobili_idcom, string cobili_idprod)
        {
            Params.Clear();
            Params.Add("?cobili_idcom", cobili_idcom);
            Params.Add("?cobili_idprod", cobili_idprod);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT SUM(cobili.qty) AS sum_cobili_qty FROM vivadata4.cobili wHERE cobili.IDCOM = ?cobili_idcom and COBILI.IDPROD = ?cobili_idprod
                ", Params);
        }
    }

    class Xml856Writer : DB_XmlWriter
    {
        private IDataRecord Data;
        private CIDataRecord CData;
        private List<IDataRecord> RawDataDetails;
        
        public Xml856Writer(IDataRecord TheData, List<IDataRecord> TheDataDetails)
        {
            Data = TheData;
            CData = new CIDataRecord(TheData);

            RawDataDetails = TheDataDetails;

            ClientID = Data["cobil_clientid"].ToString();

            OutputFileName = $"{ClientID.PadLeft(5, '0')}-856OUT-{Data["cobil_ident"].ToString()}-{Base.ToAlphaNumeric(Data["cobil_clientpo"].ToString())}-{(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds}";

            XmlFilePath = Path.Combine(RSS_send_path, OutputFileName + ".xml");

            Status += "Xml856Writer " + NL;
            Status += "OutputFileName: " + OutputFileName + NL;
            Status += "XmlFilePath: " + XmlFilePath + NL;
        }

        public void Write(Program_856 mysql)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            string TransactionControlNumber = rand.Next(0, 101).ToString("0000");
            
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;

            int ClientId = Convert.ToInt32(Data["cobil_clientid"]);
            Decimal TotalNumberOfLineItem = 0;
            Decimal TotalNumberOfLineItemQty = 0;

            using (writer = XmlWriter.Create(XmlFilePath, settings))
            {

                writer.WriteStartElement("TransactionSet");
                writer.WriteStartElement("TX-00403-856");
                writer.WriteAttributeString("type", "TransactionSet");

                writer.WriteStartElement("Meta");
                {
                    writer.WriteElementString("STO1", "", "856"); //STO1 : Transaction Set Identifier Code: Ship Notice/Manifest
                    writer.WriteElementString("STO2", "", TransactionControlNumber);  //STO2 : Transaction Set Control Number
                }
                writer.WriteEndElement(); //Meta

                //BSN segment
                WriteSegment("BSN", "Segment", "BSN01 : Transaction Set Purpose Code: Fixed : Original", "00",
                                               "BSN02 : Shipment Identification : cobil_ident", Data["cobil_ident"].ToString(),
                                               "BSN03 : Date : edi_856_ship_date", string.Format("{0:yyyyMMdd}", Data["edi_856_ship_date"]),
                                               "BSN04 : Time : edi_856_ship_date", string.Format("{0:HHmmss}", Data["edi_856_ship_date"]));

                //DTM segment Shipped
                WriteSegment("DTM", "Segment", "DTM01 : Date/Time Qualifier: Fixed : Shipped", "011",
                                               "DTM02 : Date : cobil_bil_dte", string.Format("{0:yyyyMMdd}", Data["cobil_bil_dte"]));

                DateTime cobil_bil_dte = DateTime.Parse(Data["cobil_bil_dte"].ToString());
                //DTM segment Estimated Delivery
                WriteSegment("DTM", "Segment", "DTM01 : Date/Time Qualifier: Fixed : Estimated Delivery", "017",
                                               "DTM02 : Date : cobil_bil_dte", string.Format("{0:yyyyMMdd}", cobil_bil_dte.AddDays(1)));


                WriteHLLoop1_Shipment(Data);

                WriteN1Loop1_arclient(EntityCode1.ST, EntityCode2.BuyerCode);
                WriteN1Loop1_wscie(EntityCode1.SF, EntityCode2.SellerCode);

                List<IDataRecord> items;
                List<IDataRecord> sum_cobili_qty;
                int Id = 2;  //Hierarchical ID Number
                int Pid = 1; //Hierarchical Parent ID Number

                foreach (var DataDetail in RawDataDetails)
                {
                    WriteHLLoop1_Order(DataDetail, Id, Pid);
                   
                    items = mysql.GetItems(DataDetail["cobil_ident"].ToString(), DataDetail["cocom_ident"].ToString());
                    Pid = Id;
                    foreach (var item in items)
                    {
                        Id++;
                        sum_cobili_qty = mysql.GetShippedDate(item["cocom_ident"].ToString(), item["ivprod_ident"].ToString());
                        int ShippedToDate = Convert.ToInt32(sum_cobili_qty[0]["sum_cobili_qty"]) - Convert.ToInt32(item["cobili_qty"]);
                        WriteHLLoop1_Item(item, ShippedToDate, Id, Pid);

                        int QtyShipped = Convert.ToInt32(item["cobili_qty"]);

                        TotalNumberOfLineItem++;
                        TotalNumberOfLineItemQty += QtyShipped;
                    }
                    Id++;
                    Pid = 1;
                }

                //CTT Loop
                WriteSegmentLoop("CTTLoop1", "Loop", "CTT", "Segment",
                    "Calc: TotalNumberOfLineItem", TotalNumberOfLineItem.ToString(),
                    "Calc: TotalNumberOfLineItemQty", TotalNumberOfLineItemQty.ToString());

                writer.WriteEndElement(); //TX-00403-856

                writer.WriteEndElement(); //TransactionSet


            } // Using XMLWriter

        } // Write()

        public void WriteHLLoop1_Shipment(IDataRecord data)
        {
            writer.WriteStartElement("HLLoop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("HL", "Segment",
                    "HL01 : Hierarchical ID Number", "1",
                    "HL02 : Hierarchical Parent ID Number", "",
                    "HL03 : Hierarchical Level Code: Fixed : Shipment", "S",
                    "HL04 : Hierarchical Child Code: Fixed : Additional Subordinate HL Data Segment in This Hierarchical Structure", "1");

                WriteSegment("TD1", "Segment",
                    "TD101 : Packaging Code: Fixed : Unit: Standard", "UNT90",
                    "TD102 : Lading Quantity: cobili_qty", data["cobili_qty"].ToString());

                WriteSegment("TD5", "Segment",
                    "TD501 : Routing Sequence Code: Fixed : Origin Carrier (Air, Motor, or Ocean)", "O",
                    "TD502 : Identification Code Qualifier: Fixed : Mutually Defined", "ZZ",
                    "TD503 : Identification Code", "", 
                    "TD504 : Transportation Method/Type Code: Fixed : Supplier Truck", "SR");

                //BM
                WriteSegment("REF", "Segment",
                  "REF01 : Reference Identification Qualifier : Bill of Lading Number", "BM",
                  "REF02 : Reference Identification : cobil_ident", data["cobil_ident"].ToString());

                //CR
                WriteSegment("REF", "Segment",
                  "REF01 : Reference Identification Qualifier: Customer Reference Number", "CR",
                  "REF02 : Reference Identification : cobil_clientid", data["cobil_clientid"].ToString()); 
            }
            writer.WriteEndElement(); //HLLoop1
        } // method WriteHLLoop1_Shipment()

        public void WriteHLLoop1_Order(IDataRecord data, int i, int j)
        {
            writer.WriteStartElement("HLLoop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("HL", "Segment",
                    "HL01 : Hierarchical ID Number", i.ToString(), 
                    "HL02 : Hierarchical Parent ID Number", j.ToString(), 
                    "HL03 : Hierarchical Level Code: Fixed : Order", "O",
                    "HL04 : Hierarchical Child Code: Fixed : Additional Subordinate HL Data Segment in This Hierarchical Structure", "1");

                WriteSegment("PRF", "Segment",
                    "PRF01 : Purchase Order Number: cocom_clientpo", data["cocom_clientpo"].ToString(),
                    "PRF02 : Release Number", "",
                    "PRF03 : Change Order Sequence Number", "",
                    "PRF04 : Date: cocom_co_dte", string.Format("{0:yyyyMMdd}", data["cocom_co_dte"])); 

                WriteSegment("REF", "Segment",
                  "REF01 : Reference Identification Qualifier: Vendor Order Number", "VN",
                  "REF02 : Reference Identification : cocom_ident", data["cocom_ident"].ToString());
            }
            writer.WriteEndElement(); //HLLoop1
        } //method WriteHLLoop1_Order()

        public void WriteHLLoop1_Item(IDataRecord data, int qtyShippedDate, int i, int j)
        {
            writer.WriteStartElement("HLLoop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("HL", "Segment",
                    "HL01 : Hierarchical ID Number", i.ToString(), 
                    "HL02 : Hierarchical Parent ID Number", j.ToString(),
                    "HL03 : Hierarchical Level Code: Fixed : Item", "I",
                    "HL04 : Hierarchical Child Code: Fixed :  No Subordinate HL Segment in This Hierarchical Structure.", "0");

                WriteSegment("LIN", "Segment",
                    "LIN01 : Assigned Identification calc: cobili_line * 10", (Convert.ToInt32(data["cobili_line"].ToString()) * 10).ToString(),
                    "LIN02 : Product/Service ID Qualifier: Buyer's Part Number", "BP",
                    "LIN03 : Product/Service ID : ivprixdcli_codecli", data["ivprixdcli_codecli"].ToString(),
                    "LIN04 : Product/Service ID Qualifier: Vendor's (Seller's) Part Number", "VP",
                    "LIN05 : Product/Service ID : ivprod_code", data["ivprod_code"].ToString());

                WriteSegment("SN1", "Segment",
                    "SN101 : Assigned Identification calc: cobili_line * 10", (Convert.ToInt32(data["cobili_line"].ToString()) * 10).ToString(),
                    "SN102 : Number of Units Shipped: cobili_qty", data["cobili_qty"].ToString(),
                    "SN103 : Unit or Basis for Measurement Code: Enveloppe", "EV",
                    "SN104 : Quantity Shipped to Date : calc: qtyShippedDate", qtyShippedDate.ToString(),
                    "SN105 : Quantity Ordered: cobili_qty", data["cobili_qty"].ToString(),
                    "SN106 : Unit or Basis for Measurement Code: Enveloppe", "EV");
            }
            writer.WriteEndElement(); //HLLoop1
        } //method WriteHLLoop1_Item()

    } //class Xml856Writer

} //namespaces EDI_RSS.Helpers