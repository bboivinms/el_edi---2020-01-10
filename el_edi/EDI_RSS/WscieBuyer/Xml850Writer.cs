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
    public class Program_850_OUT : EDI_RSS.Program_Base
    {
        public Program_850_OUT()
        {
            TransactionCode = "850";

            LogEventSource = "EDI 850 Processor";

            Xml850Writer xml = null;

            List<IDataRecord> RawDataDetails;
            string popo_ident;
            string edi_ident;

            Status += "Program_850" + NL + "UseSystem: " + UseSystem + NL + "TheFilename: " + Filename + NL;

            try
            {
                List<IDataRecord> RawData = GetData();

                foreach (IDataRecord Data in RawData)
                {
                    popo_ident = Data["popo_ident"].ToString();
                    edi_ident = Data["edi_850_ident"].ToString();

                    SetupClient(Convert.ToInt32(Data["popo_ident"]));

                    Status += "GetDataDetails: " + popo_ident + NL;

                    RawDataDetails = GetDataDetails(popo_ident);

                    xml = new Xml850Writer(Data, RawDataDetails);

                    string strXml = xml.Write(this);

                    if (gIDataEdi_path["Has_accent"].ToString() == "0")
                    {
                        strXml = RemoveDiacritics(strXml);
                    }

                    strXml = ReplaceTildeAndPipe(strXml);
                    strXml = ReplaceTelephoneNumber(strXml);

                    File.WriteAllText(xml.XmlFilePath, strXml.Replace("&amp;", "&").Replace("& ", "&  "));

                    UpdateFilename("edi_850", xml.OutputFileName, edi_ident);
                }

            }
            catch (System.Exception e)
            {
                Error += "Error caught: " + e.ToString();
                LogWriter.WriteMessage(LogEventSource, $"Error caught: {e.ToString()}");
            }
            finally
            {
            }
        }

        //public void CreateNew()
        //{
        //    DB_VIVA.HExecuteSQLNonQuery(@"
        //        INSERT INTO edi_850 (popo_ident) 
        //        SELECT ident 
        //        FROM popo
        //            WHERE status = 'R' AND IDVENDOR = 2004 AND 
        //                  ident = 101 AND 
        //                  NOT EXISTS(SELECT 1 FROM edi_850 AS edi_850e WHERE edi_850e.popo_ident = popo.ident); 
        //        ALTER TABLE edi_850 AUTO_INCREMENT = 1;");
        //}

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT  
                        popo.ident AS popo_ident, popo.idvendor AS popo_idvendor, popo.pono AS popo_pono, 
                        popo.desc AS popo_desc, popo.po_dte AS popo_po_dte, popo.requ_dte AS popo_requ_dte,
                        popo.contact as popo_contact, popo.contactfax AS popo_contactfax, popo.contactemail AS popo_contactemail,
                        popo.del_name AS popo_del_name, popo.prt_note AS popo_prt_note, popo.ref_fourn AS popo_ref_fourn,
                        apsupp.TERMS_DAYS AS apsupp_terms_days, apsupp.DISCOUNT_DAYS AS apsupp_discount_days, apsupp.DISCOUNT_RATE AS apsupp_discount_rate,
                        edi_850.ident AS edi_850_ident, edi_850.filename AS edi_850_filename, edi_850.Xml_technique AS edi_850_Xml_technique,
                        wsuser.name AS wsuser_name, 
                        IF(IFNULL(wsuser.email, '') = '', wscie.email, wsuser.email) AS wsuser_email, 
                        IF(IFNULL(wsuser.tel, '') = '', wscie.cie_tel, wsuser.tel) AS wsuser_tel,
                        wscie.cie_name AS wscie_cie_name, wscie.cie_fax AS wscie_cie_fax, wscie.cie_tel AS wscie_cie_tel, wscie.email AS wscie_email
                FROM popo 
                INNER JOIN apsupp ON popo.IDVENDOR = apsupp.ident
                INNER JOIN edi_850 ON edi_850.popo_ident = popo.ident
                LEFT JOIN wsuser ON popo.cr_by = wsuser.code
                INNER JOIN wscie ON wscie.cie_id = 1
                WHERE edi_850.Sent = false
                ");
        }

        public List<IDataRecord> GetDataDetails(string popo_ident)
        {
            

            string id_ivxcoprod = "";

            if(wscie == "E")
            {
                id_ivxcoprod = "ident";
            }
            else if(wscie == "M")
            {
                id_ivxcoprod = "ident_ai";
            }

            Params.Clear();
            Params.Add("?popo_ident", popo_ident);

            return DB_VIVA.HExecuteSQLQuery($@"
                 SELECT  
                        popoi.line AS popoi_line, popoi.qty_ord AS popoi_qty_ord, popoi.COST AS popoi_cost, 
                        popoi.date_rcv AS popoi_date_rcv, popoi.unite AS popoi_unite, IF(IFNULL(popoi.desc, '') = '', ivprod.desc, popoi.desc) AS popoi_desc,
                        ivprod.ident AS ivprod_ident, ivprod.code AS ivprod_code, ivprod.desc AS ivprod_desc,
                        edi_850.ident AS edi_850_ident,
                        IFNULL((SELECT 
                            SUBSTRING_INDEX( GROUP_CONCAT(CAST(ref_fourn AS CHAR) ORDER BY ident DESC), ',', 1 ) AS ref_fourn
                            FROM ivprix WHERE idvendor = popo.idvendor AND ref_fourn <> '' 
                            AND LENGTH(ref_fourn) < 12
                            AND LENGTH(ref_fourn) >= 6
                            AND ivprix.idproduit = popoi.idprod
                            GROUP BY idproduit LIMIT 1), '') AS ivprix_ref_fourn,
                        ivxcoprod.item_id_print AS ivxcoprod_item_id_print
                FROM popo 
                INNER JOIN popoi ON popo.ident = popoi.idpo
                INNER JOIN ivprod ON ivprod.ident = popoi.idprod
                INNER JOIN edi_850 ON edi_850.popo_ident = popo.ident
                LEFT JOIN ivxcoprod ON ivxcoprod.idprod = (
									SELECT idprod FROM ivxcoprod
									WHERE ivxcoprod.idprod = popoi.idprod
									ORDER BY {id_ivxcoprod}
									LIMIT 1
								)
                WHERE   edi_850.Sent = false 
                        AND
                        popo.ident = ?popo_ident
                ORDER BY popoi.idpo, popoi.line
                ", Params);
        }
    }

    class Xml850Writer : DB_XmlWriter
    {
        private IDataRecord Data;
        private CIDataRecord CData;
        private List<IDataRecord> RawDataDetails;

        public Xml850Writer(IDataRecord TheData, List<IDataRecord> TheDataDetails)
        {
            Data = TheData;
            CData = new CIDataRecord(TheData);

            RawDataDetails = TheDataDetails;

            ClientID = Data["popo_idvendor"].ToString();

            OutputFileName = $"{ClientID.PadLeft(5, '0')}-850-OUT-{Data["popo_ident"].ToString()}-{Base.ToAlphaNumeric(Data["popo_pono"].ToString())}-{(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds}";

            edi_doc_number = 850;
            IDpartner = GetInt(ClientID);

            gIDataEdi_path = GetEdi_partner("edi_apsupp");

            if (gIDataEdi_path != null)
            {
                SetRouting_out_path("xml_x12");

                XmlFilePath = Path.Combine(RSS_send_path, OutputFileName + ".xml");

                Status += "Xml850Writer " + NL;
                Status += "OutputFileName: " + OutputFileName + NL;
                Status += "XmlFilePath: " + XmlFilePath + NL;
            }
        }

        public string Write(Program_850_OUT mysql)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            string TransactionControlNumber = rand.Next(0, 101).ToString("0000");

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;

            int ClientId = Convert.ToInt32(Data["popo_idvendor"]);
            Decimal TotalNumberOfLineItem = 0;
            Decimal TotalNumberOfLineItemQty = 0;

            using (var sw = new StringWriter())
            {
                using (writer = XmlWriter.Create(sw, settings)) //Create a xml in a string
                {

                    writer.WriteStartElement("TransactionSet");
                    writer.WriteStartElement("TX-"+ gIDataEdi_path["Edi_version"].ToString() +"-850"); //00401 || 00403
                    writer.WriteAttributeString("type", "TransactionSet");

                    writer.WriteStartElement("Meta");
                    {
                        writer.WriteElementString("ST01", "", "850"); // Transaction Set Identifier Code: 850 - Purchase Order
                        writer.WriteElementString("ST02", "", TransactionControlNumber); // Transaction Set Control Number
                    }
                    writer.WriteEndElement(); //Meta

                    //BEG segment
                    WriteSegment("BEG", "Segment", "BEG01 : Transaction Set Purpose Code: Fixed: Original", "00",
                                                   "BEG02 : Purchase Order Type Code: Fixed: Stand-alone Order", "SA",
                                                  $"BEG03 : Purchase Order Number : popo_pono (popo_ident={Data["popo_ident"].ToString()})", Data["popo_pono"].ToString(),
                                                   "BEG04 : Release Number", "",
                                                   "BEG05 : Date : popo_po_dte", string.Format("{0:yyyyMMdd}", Data["popo_po_dte"]));

                    //CUR segment
                    WriteSegment("CUR", "Segment", "CUR01 : Entity Identifier Code: Fixed: Buying Party", "BY",
                                                   "CUR02 : Currency Code: Fixed: Canadian Dollar", "CAD");

                    //REF segment
                    WriteSegment("REF", "Segment", "REF01 : Reference Identification Qualifier : Fixed : Purchase Order Number", "PO",
                                                   "REF02 : Reference Identification : popo_pono", Data["popo_pono"].ToString());

                    string[] methodPayment ;
                    if(Data["popo_del_name"].ToString() == "PICK UP")
                    {
                        methodPayment = new string[]{"BP", "Paid by Buyer" };
                    }
                    else
                    {
                        methodPayment = new string[]{ "PP", "Prepaid (by Seller)" };
                    }

                    //FOB segment
                    WriteSegment("FOB", "Segment", "FOB01 : Shipment Method of Payment: methodPayment: " + methodPayment[1], methodPayment[0],
                                                   "FOB02 : Location Qualifier: Fixed: Mutually Defined", "ZZ",
                                                   "FOB03 : Description : popo_desc", Data["popo_desc"].ToString(),
                                                   "FOB04 : Transportation Terms Qualifier Code: Fixed: Incoterms", "01",
                                                   "FOB05 : Transportation Terms Code: Fixed: Free on Board", "FOB");
                    if(ClientID != "2004")
                    {
                        //ITD segment
                        WriteSegment("ITD", "Segment", "ITD01 : Terms Type Code", "",
                                                       "ITD02 : Terms Basis Date Code: Fixed: Invoice Date", "3",
                                                       "ITD03 : Terms Discount Percent: apsupp_discount_rate", Convert.ToInt32(Data["apsupp_discount_rate"]).ToString(),
                                                       "ITD04 : Terms Discount Due Date", "",
                                                       "ITD05 : Terms Discount Days Due: apsupp_discount_days", Data["apsupp_discount_days"].ToString(),
                                                       "ITD06 : Terms Net Due Date", "",
                                                       "ITD07 : Terms Net Days: apsupp_terms_days", Data["apsupp_terms_days"].ToString());
                    }
                    
                    //DTM segment
                    WriteSegment("DTM", "Segment", "DTM01 : Date/Time Qualifier : Fixed : Purchase Order", "004",
                                                   "DTM02 : Date : popo_po_dte", string.Format("{0:yyyyMMdd}", Data["popo_po_dte"]),
                                                   "DTM03 : Time", "");

                    //DTM segment
                    WriteSegment("DTM", "Segment", "DTM01 : Date/Time Qualifier : Fixed : Delivery Requested", "002",
                                                   "DTM02 : Date : popo_requ_dte", string.Format("{0:yyyyMMdd}", Data["popo_requ_dte"]),
                                                   "DTM03 : Time", "");

                    if(Data["popo_ref_fourn"].ToString() != "")
                    {
                        WriteN9Loop1("popo_ref_fourn", "Votre référence / Your reference: " + Data["popo_ref_fourn"].ToString());
                    }
                    else
                    {
                        WriteN9Loop1("popo_prt_note", Data["popo_prt_note"].ToString());
                    }

                    string cie_name = "Unknown corporations";
                    if (wscie == "E")
                    {
                        cie_name = "Enveloppe Laurentide Inc.";
                    }
                    else if(wscie == "M")
                    {
                        cie_name = "Multi Services GSTJ Inc.";
                    }

                    WriteN9Loop1("Termes", "Le fournisseur accepte les termes et conditions de " + cie_name
                        + NL + "Le fournisseur est responsable d'aviser de toute différence de données technique entre les dossiers de " + cie_name + " et ceux du fournisseurs."
                        + NL + "The supplier accepts the terms and conditions of " + cie_name
                        + NL + "The supplier is responsible for notifying any technical data discrepancies between the "+ cie_name +" and the supplier's records.", "TERMES");

                    DB_PER pDB_PER = null;
                    pDB_PER = new DB_PER(this, PerCode.BD, Data["wsuser_name"].ToString(), Data["wsuser_tel"].ToString(), Data["wsuser_email"].ToString(), Data["wscie_cie_fax"].ToString());
                    WriteN1Loop1_wscie(EntityCode1.BY, EntityCode2.MutuallyDefined, pDB_PER, "101440");

                    pDB_PER = new DB_PER(this, PerCode.CN, Data["popo_contact"].ToString(), "", Data["popo_contactemail"].ToString(), Data["popo_contactfax"].ToString());
                    WriteN1Loop1_apsupp(ClientId, EntityCode1.VN, pDB_PER);

                    pDB_PER = new DB_PER(this, PerCode.CN, Data["wscie_cie_name"].ToString(), Data["wscie_cie_tel"].ToString(), Data["wscie_email"].ToString(), Data["wscie_cie_fax"].ToString());
                    WriteN1Loop1_arclient_name(Data["popo_del_name"].ToString(), EntityCode1.ST, EntityCode2.BuyerCode, pDB_PER);

                    //PO1Loop1 avec PIDLoop1
                    foreach (var DataDetail in RawDataDetails)
                    {
                        int QtyOrdered = Convert.ToInt32(DataDetail["popoi_qty_ord"]);

                        TotalNumberOfLineItem++;
                        TotalNumberOfLineItemQty += Math.Abs(QtyOrdered);

                        WritePO1Loop1(DataDetail);

                    }

                    //CTT Loop
                    WriteSegmentLoop("CTTLoop1", "Loop", "CTT", "Segment",
                        "Calc: TotalNumberOfLineItem", TotalNumberOfLineItem.ToString(),
                        "Calc: TotalNumberOfLineItemQty", TotalNumberOfLineItemQty.ToString());

                    writer.WriteEndElement(); //TX-00401-850

                    writer.WriteEndElement(); //TransactionSet


                } // Using XMLWriter
                return sw.ToString();
            }// Using StringWriter
        } // Write()

        /**
         * Write a po1 loop for the 850 purchase order who contains the product ordered.
         * params1 : IDataRecord TheDataDetails the data of popoi table
         * return : void
         */
        public void WritePO1Loop1(IDataRecord TheDataDetails)
        {
            writer.WriteStartElement("PO1Loop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("PO1", "Segment",
                       "PO101 : Assigned Identification : popoi_line * 10", (Convert.ToInt32(TheDataDetails["popoi_line"].ToString()) * 10).ToString(),
                       "PO102 : Quantity Ordered : popoi_qty_ord", TheDataDetails["popoi_qty_ord"].ToString(),
                       "PO103 : Unit or Basis for Measurement Code : Fixed : Each", "EA",
                       "PO104 : Unit Price: popoi_cost", Convert.ToDecimal(TheDataDetails["popoi_cost"]).ToString("#.##"),
                       "PO105 : Basis of Unit Price Code: UnitMappings(popoi_unite): " + TheDataDetails["popoi_unite"].ToString()
                                                        , UnitMappings(TheDataDetails["popoi_unite"].ToString()),
                       "PO106 : Product/Service ID Qualifier: Fixed : Buyer's Part Number", "BP",
                      $"PO107 : Product/Service ID : ivprod_code (ivprod_ident={TheDataDetails["ivprod_ident"].ToString()})", TheDataDetails["ivprod_code"].ToString(),
                       "PO108 : Product/Service ID Qualifier: Fixed : Vendor's (Seller's) Part Number", "VP",
                       "PO109 : Product/Service ID: ivprix_ref_fourn", TheDataDetails["ivprix_ref_fourn"].ToString()); 

                writer.WriteStartElement("PIDLoop1");
                writer.WriteAttributeString("type", "Loop");
                {
                    WriteSegment("PID", "Segment",
                        "PID01 : Item Description Type : Fixed : Free-form", "F",
                        "PID02 : Product/Process Characteristic Code:", "",
                        "PID03 : Agency Qualifier Code:", "",
                        "PID04 : Product Description Code:", "",
                        "PID05 : Description : popoi_desc [IF NULL: ivprod_desc]", TheDataDetails["popoi_desc"].ToString());
                }
                writer.WriteEndElement(); //PIDLoop1

                writer.WriteStartElement("SACLoop1");
                writer.WriteAttributeString("type", "Loop");
                {
                    //DTM segment
                    WriteSegment("DTM", "Segment", "DTM01 : Date/Time Qualifier : Fixed : Delivery Requested", "002",
                                                   "DTM02 : Date : popo_requ_dte", string.Format("{0:yyyyMMdd}", Data["popo_requ_dte"]),
                                                   "DTM03 : Time", "");

                    if (TheDataDetails["ivxcoprod_item_id_print"].ToString() != "")
                    {
                        WriteSegment("MAN", "Segment",
                            "MAN01 : Marks and Numbers Qualifier : Fixed : Line Item Only", "L",
                            "MAN02 : Marks and Numbers : ivxcoprod_item_id_print", TheDataDetails["ivxcoprod_item_id_print"].ToString());
                    }
                }
                writer.WriteEndElement(); //SACLoop1

                WriteN9Loop_Technique(Data, TheDataDetails);
            }
            writer.WriteEndElement(); //PO1Loop1
        }

    }
}