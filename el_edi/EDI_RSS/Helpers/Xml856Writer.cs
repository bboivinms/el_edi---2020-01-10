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

            OutputFileName = $"{ClientID}-{Data["cobil_ident"].ToString()}-{Base.ToAlphaNumeric(Data["cobil_clientpo"].ToString())}-{(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds}";

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

                WriteHLLoop1();

                //BAK segement
                // BIG07 BB Billback : CO Corrected / CR Credit Memo / DR Debit Memo / DU Duplicate / RE Rebill
                // PR Product(or Service) Is the usual default but should be explicit to avoid wrong assumptions by the receiving party.
                //WriteSegment("BIG", "Segment", "BIG01 : Invoice Date: arinv_invdte", string.Format("{0:yyyyMMdd}", Data["arinv_invdte"]),
                //                               "BIG02 : Invoice Number: arinv_invno", Data["arinv_invno"].ToString(),
                //                               "BIG03 : Fixed: Client Purchase Order Date", "",
                //                               "BIG04 : Client Purchase Order Number: arinv_po", Data["arinv_po"].ToString(),
                //                               "BIG05 : Fixed: Release Number", "",
                //                               "BIG06 : Fixed: Change Order Sequence Number", "",
                //                               "BIG07 : Fixed: Transaction Type Code: PR Product(or Service)", "PR");

                //WriteSegment("CUR", "Segment", "CUR01 : Fixed: Entity Identifier Code: Vendor", "VN",
                //                               "CUR02 : Fixed: Currency Code", "CAD");

                ////REF segment
                //WriteSegment("REF", "Segment", "REF01 : Reference Identification Qualifier : Fixed : Bill of Lading Number", "IK",
                //                               "REF02 : Reference Identification : arinv_idbil", Data["arinv_idbil"].ToString());

                //REF segment
                //WriteSegment("REF", "Segment", "VR", "TBD"); //TODO: get the EL supplier ID for the current customer


                //WriteN1Loop1_arclient(Data, EntityCode1.BY);
                //WriteN1Loop1_ffaddr(Data, EntityCode1.ST);
                //WriteN1Loop1_wscie(EntityCode1.VN);

                //foreach (var DataDetail in RawDataDetails)
                //{
                //    int QtyInvoiced = Convert.ToInt32(DataDetail["arinvd_qty"]);

                //    TotalNumberOfLineItem++;
                //    TotalNumberOfLineItemQty += QtyInvoiced;

                //    WriteIT1Loop1(DataDetail);
                //    WritePIDLoop1(DataDetail);

                //}

                ////TDS segment
                //WriteSegment("TDS", "Segment", "TDS01 : Total Invoice Amount : arinv_inv_mnt", Data["arinv_inv_mnt"].ToString());
                ////"TDS02 : Total Amount Subject to Discount", "",
                ////"TDS03 : Discounted Amount Due", "",
                ////"TDS04 : Terms Discount Amount", ""

                ////tps
                //if (Convert.ToInt32(Data["arinv_inv_tx_gst"]) != 0 && Convert.ToInt32(Data["arinv_tpstaux"]) != 0)
                //{
                //    //TXI segment
                //    WriteSegment("TXI", "Segment", "TXI01 : Tax Type Code : Fixed : State/Provincial Tax", "SP",
                //                                   "TXI02 : Monetary Amount", Data["arinv_inv_tx_gst"].ToString(),
                //                                   "TXI03 : Percent: Percentage expressed as a decimal", (Convert.ToDecimal(Data["arinv_tpstaux"]) / 100).ToString());
                //}

                ////tvq
                //if (Convert.ToInt32(Data["arinv_inv_tx_pst"]) != 0 && Convert.ToInt32(Data["arinv_tvqtaux"]) != 0)
                //{
                //    //TXI segment
                //    WriteSegment("TXI", "Segment", "TXI01 : Tax Type Code : Fixed : Federal Tax", "FD",
                //                                   "TXI02 : Monetary Amount", Data["arinv_inv_tx_pst"].ToString(),
                //                                   "TXI03 : Percent: Percentage expressed as a decimal", (Convert.ToDecimal(Data["arinv_tvqtaux"])/100).ToString());
                //}

                ////tvh
                //if (Convert.ToInt32(Data["arinv_inv_tx_tvh"]) != 0 && Convert.ToInt32(Data["arinv_tvhtaux"]) != 0)
                //{
                //    //TXI segment
                //    WriteSegment("TXI", "Segment", "TXI01 : Tax Type Code : Fixed : State Sales Tax", "ST",
                //                                   "TXI02 : Monetary Amount", Data["arinv_inv_tx_tvh"].ToString(),
                //                                   "TXI03 : Percent: Percentage expressed as a decimal", (Convert.ToDecimal(Data["arinv_tvhtaux"]) / 100).ToString());
                //}

                //CTT Loop
                WriteSegmentLoop("CTTLoop1", "Loop", "CTT", "Segment",
                    "Calc: TotalNumberOfLineItem", TotalNumberOfLineItem.ToString(),
                    "Calc: TotalNumberOfLineItemQty", TotalNumberOfLineItemQty.ToString());

                writer.WriteEndElement(); //TX-00403-856

                writer.WriteEndElement(); //TransactionSet


            } // Using XMLWriter

        } // Write()

        public void WriteHLLoop1()
        {
            writer.WriteStartElement("HLLoop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("HL", "Segment",
                    "HL01 : Hierarchical ID Number", "1", //<--
                    "HL02 : Hierarchical Parent ID Number", "", //<--
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
        }
    } //class Xml856Writer
} //namespaces EDI_RSS.Helpers