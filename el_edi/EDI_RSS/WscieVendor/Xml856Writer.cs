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
                CreateNew();

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

        public void CreateNew()
        {
            DB_VIVA.HExecuteSQLNonQuery(@" 
                INSERT INTO edi_856 (cobil_ident) 
                SELECT cobil.ident 
                FROM cobil
                    WHERE   cobil.clientid = 30037 AND 
                            cobil.ident > 14300 AND 
                            NOT EXISTS(SELECT 1 FROM edi_856 AS edi_856e WHERE edi_856e.cobil_ident = cobil.ident); 
                ALTER TABLE edi_856 AUTO_INCREMENT = 1;");

            //update pour mettre le ship date
            DateTime dte_now = DateTime.Now;

            Params.Clear();
            Params.Add("?dte_now", dte_now.ToString());

            DB_VIVA.HExecuteSQLQuery(@"UPDATE edi_856 SET Ship_date = ?dte_now WHERE cobil_ident = 14333;", Params);
        }

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT  
                        cobil.ident AS cobil_ident, cobil.clientid AS cobil_clientid, cobil.clientpo AS cobil_clientpo, cobil.BIL_DTE AS cobil_bil_dte,
                        edi_856.ident AS edi_856_ident, edi_856.filename AS edi_856_filename, edi_856.Ship_date AS edi_856_ship_date
                FROM cobil 
                INNER JOIN edi_856 ON edi_856.cobil_ident = cobil.ident
                WHERE edi_856.Sent = false 
                      AND
                      cobil.ident = 14333
                ");
        }

        public List<IDataRecord> GetDataDetails(string cobil_ident)
        {
            Params.Clear();
            Params.Add("?cobil_ident", cobil_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  
                        ivprod.code AS ivprod_code, ivprod.DESC AS ivprod_desc,
                        edi_856.ident AS edi_856_ident, 
                        cobili.PO_NO AS cobili_po_no, cobili.QTY AS cobili_qty,
                        cocom.CLIENTPO AS cocom_clientpo, cocom.ident AS cocom_ident  
                FROM cobil 
                INNER JOIN cobili ON cobil.ident = cobili.idcobil
                INNER JOIN ivprod ON ivprod.ident = cobili.idprod
                INNER JOIN edi_856 ON edi_856.cobil_ident = cobil.ident
                INNER JOIN cocom ON cocom.ident = cobili.IDCOM
                WHERE   edi_856.Sent = false 
                        AND
                        cobil.ident = ?cobil_ident
                ORDER BY cobili.ident, cobili.line
                ", Params);
        }

        public List<IDataRecord> GetItems(string cobil_ident, string cocom_ident)
        {
            Params.Clear();
            Params.Add("?cobil_ident", cobil_ident);
            Params.Add("?cocom_ident", cocom_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT cobil.DEL_NAME,
                         cobili.PO_NO AS cobili_po_no, cobili.QTY AS cobili_qty,
                         cocom.ident AS cocom_ident
                  FROM cobil 
                  INNER JOIN cobili ON cobil.ident = cobili.idcobil
                  INNER JOIN cocom ON cocom.ident = cobili.IDCOM
                  WHERE cobil.ident = cobil_ident 
                        AND 
                        cocom.ident = ?cocom_ident
                  ORDER BY cobili.ident, cobili.line
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

            OutputFileName = $"{ClientID}-856OUT-{Data["cobil_ident"].ToString()}-{Base.ToAlphaNumeric(Data["cobil_clientpo"].ToString())}-{(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds}";

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

                //details
                foreach (var DataDetail in RawDataDetails)
                {
                    int QtyShipped = Convert.ToInt32(DataDetail["cobili_qty"]);

                    TotalNumberOfLineItem++;
                    TotalNumberOfLineItemQty += QtyShipped;

                    WriteHLLoop1_Order(DataDetail);

                }

                WriteN1Loop1_arclient(EntityCode1.ST, EntityCode2.BuyerCode);
                //WriteN1Loop1_ffaddr(Data, EntityCode1.ST);
                //WriteN1Loop1_wscie(EntityCode1.VN);


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
                    "TD101 : Packaging Code: Fixed : Pallet: Standard", "PLT90",
                    "TD102 : Lading Quantity", "1"); //<--

                WriteSegment("TD5", "Segment",
                    "TD501 : Routing Sequence Code: Fixed : Origin Carrier (Air, Motor, or Ocean)", "O",
                    "TD502 : Identification Code Qualifier: Fixed : Standard Carrier Alpha Code (SCAC)", "2",
                    "TD503 : Identification Code", "",  //<--
                    "TD504 : Transportation Method/Type Code: Fixed : Supplier Truck", "SR");

                //BM
                WriteSegment("REF", "Segment",
                  "REF01 : Reference Identification Qualifier : Bill of Lading Number", "BM",
                  "REF02 : Reference Identification : ", ""); //<--

                //CR
                WriteSegment("REF", "Segment",
                  "REF01 : Reference Identification Qualifier: Customer Reference Number", "CR",
                  "REF02 : Reference Identification : ", ""); //<--
            }
            writer.WriteEndElement(); //HLLoop1
        } // method WriteHLLoop1_Shipment()

        public void WriteHLLoop1_Order(IDataRecord data)
        {
            writer.WriteStartElement("HLLoop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("HL", "Segment",
                    "HL01 : Hierarchical ID Number", "2", 
                    "HL02 : Hierarchical Parent ID Number", "1", 
                    "HL03 : Hierarchical Level Code: Fixed : Order", "O",
                    "HL04 : Hierarchical Child Code: Fixed : Additional Subordinate HL Data Segment in This Hierarchical Structure", "1");

                WriteSegment("PRF", "Segment",
                    "PRF01 : Purchase Order Number", "PO_1234_NUMBER",
                    "PRF02 : Release Number", "",
                    "PRF03 : Change Order Sequence Number", "",
                    "PRF04 : Date", "20180910");

                WriteSegment("REF", "Segment",
                  "REF01 : Reference Identification Qualifier: Vendor Order Number", "VN",
                  "REF02 : Reference Identification : ", "VN_1234_NUMBER"); //<--
            }
            writer.WriteEndElement(); //HLLoop1
        } //method WriteHLLoop1_Order()

        public void WriteHLLoop1_Item(IDataRecord data)
        {
            writer.WriteStartElement("HLLoop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("HL", "Segment",
                    "HL01 : Hierarchical ID Number", "3", 
                    "HL02 : Hierarchical Parent ID Number", "2",
                    "HL03 : Hierarchical Level Code: Fixed : Item", "I",
                    "HL04 : Hierarchical Child Code: Fixed :  No Subordinate HL Segment in This Hierarchical Structure.", "0");

                WriteSegment("LIN", "Segment",
                    "LIN01 : Assigned Identification", "10",
                    "LIN02 : Product/Service ID Qualifier: Buyer's Part Number", "BP",
                    "LIN03 : Product/Service ID", "BP_1234_NUMBER",
                    "LIN04 : Product/Service ID Qualifier: Vendor's (Seller's) Part Number", "VP",
                    "LIN05 : Product/Service ID", "VP_1234_NUMBER");

                WriteSegment("SN1", "Segment",
                    "SN101 : Assigned Identification", "10",
                    "SN102 : Number of Units Shipped", "1100",
                    "SN103 : Unit or Basis for Measurement Code: Each", "EA",
                    "SN104 : Quantity Shipped to Date", "0",
                    "SN105 : Quantity Ordered", "1100",
                    "SN106 : Unit or Basis for Measurement Code: Each", "EA");
            }
            writer.WriteEndElement(); //HLLoop1
        } //method WriteHLLoop1_Item()

    } //class Xml856Writer

} //namespaces EDI_RSS.Helpers