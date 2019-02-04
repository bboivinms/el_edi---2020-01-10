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
    class Xml810Writer : DB_XmlWriter
    {
        private IDataRecord Data;
        private CIDataRecord CData;
        private List<IDataRecord> RawDataDetails;
        
        public Xml810Writer(IDataRecord TheData, List<IDataRecord> TheDataDetails)
        {
            Data = TheData;
            CData = new CIDataRecord(TheData);

            RawDataDetails = TheDataDetails;

            ClientID = Data["arinv_custid"].ToString();

            OutputFileName = $"{ClientID}-{Data["arinv_ident"].ToString()}-{Base.ToAlphaNumeric(Data["arinv_po"].ToString())}-{(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds}";

            XmlFilePath = Path.Combine(RSS_send_path, OutputFileName + ".xml");

            Status += "Xml810Writer " + NL;
            Status += "OutputFileName: " + OutputFileName + NL;
            Status += "XmlFilePath: " + XmlFilePath + NL;
        }

        public void Write(Program_810 mysql)
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            string TransactionControlNumber = rand.Next(0, 101).ToString("0000");
            
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.OmitXmlDeclaration = true;

            int ClientId = Convert.ToInt32(Data["arinv_custid"]);
            Decimal TotalNumberOfLineItem = 0;
            Decimal TotalNumberOfLineItemQty = 0;

            using (writer = XmlWriter.Create(XmlFilePath, settings))
            {

                writer.WriteStartElement("TransactionSet");
                writer.WriteStartElement("TX-00403-810");
                writer.WriteAttributeString("type", "TransactionSet");

                writer.WriteStartElement("Meta");
                {
                    writer.WriteElementString("STO1", "", "810"); // Transaction Set Identifier Code: 855 - Purchase Order Acknowledgment
                    writer.WriteElementString("STO2", "", TransactionControlNumber); // Transaction Set Control Number
                }
                writer.WriteEndElement(); //Meta

                //BAK segement
                // BIG07 BB Billback : CO Corrected / CR Credit Memo / DR Debit Memo / DU Duplicate / RE Rebill
                // PR Product(or Service) Is the usual default but should be explicit to avoid wrong assumptions by the receiving party.
                WriteSegment("BIG", "Segment", "BIG01 : Invoice Date: arinv_invdte", string.Format("{0:yyyyMMdd}", Data["arinv_invdte"]),
                                               "BIG02 : Invoice Number: arinv_invno", Data["arinv_invno"].ToString(),
                                               "BIG03 : Fixed: Client Purchase Order Date", "",
                                               "BIG04 : Client Purchase Order Number: arinv_po", Data["arinv_po"].ToString(),
                                               "BIG05 : Fixed: Release Number", "",
                                               "BIG06 : Fixed: Change Order Sequence Number", "",
                                               "BIG07 : Fixed: Transaction Type Code: PR Product(or Service)", "PR");

                WriteSegment("CUR", "Segment", "CUR01 : Fixed: Entity Identifier Code: Vendor", "VN",
                                               "CUR02 : Fixed: Currency Code", "CAD");

                //REF segment
                WriteSegment("REF", "Segment", "REF01 : Reference Identification Qualifier : Fixed : Bill of Lading Number", "BM",
                                               "REF02 : Reference Identification : arinv_idbil", Data["arinv_idbil"].ToString());

                //REF segment
                //WriteSegment("REF", "Segment", "VR", "TBD"); //TODO: get the EL supplier ID for the current customer


                WriteN1Loop1_arclient(Data, EntityCode1.BY, EntityCode2.SellerCode);
                WriteN1Loop1_ffaddr(Data, EntityCode1.ST, EntityCode2.SellerCode);
                WriteN1Loop1_wscie(EntityCode1.VN, EntityCode2.SellerCode);

                foreach (var DataDetail in RawDataDetails)
                {
                    int QtyInvoiced = Convert.ToInt32(DataDetail["arinvd_qty"]);

                    TotalNumberOfLineItem++;
                    TotalNumberOfLineItemQty += QtyInvoiced;

                    WriteIT1Loop1(DataDetail);
                    WritePIDLoop1(DataDetail);

                }

                //TDS segment
                WriteSegment("TDS", "Segment", "TDS01 : Total Invoice Amount : arinv_inv_mnt", Data["arinv_inv_mnt"].ToString());
                //"TDS02 : Total Amount Subject to Discount", "",
                //"TDS03 : Discounted Amount Due", "",
                //"TDS04 : Terms Discount Amount", ""

                //tps
                if (Convert.ToInt32(Data["arinv_inv_tx_gst"]) != 0 && Convert.ToInt32(Data["arinv_tpstaux"]) != 0)
                {
                    //TXI segment
                    WriteSegment("TXI", "Segment", "TXI01 : Tax Type Code : Fixed : State/Provincial Tax", "SP",
                                                   "TXI02 : Monetary Amount", Data["arinv_inv_tx_gst"].ToString(),
                                                   "TXI03 : Percent: Percentage expressed as a decimal", (Convert.ToDecimal(Data["arinv_tpstaux"]) / 100).ToString());
                }

                //tvq
                if (Convert.ToInt32(Data["arinv_inv_tx_pst"]) != 0 && Convert.ToInt32(Data["arinv_tvqtaux"]) != 0)
                {
                    //TXI segment
                    WriteSegment("TXI", "Segment", "TXI01 : Tax Type Code : Fixed : Federal Tax", "FD",
                                                   "TXI02 : Monetary Amount", Data["arinv_inv_tx_pst"].ToString(),
                                                   "TXI03 : Percent: Percentage expressed as a decimal", (Convert.ToDecimal(Data["arinv_tvqtaux"])/100).ToString());
                }

                //tvh
                if (Convert.ToInt32(Data["arinv_inv_tx_tvh"]) != 0 && Convert.ToInt32(Data["arinv_tvhtaux"]) != 0)
                {
                    //TXI segment
                    WriteSegment("TXI", "Segment", "TXI01 : Tax Type Code : Fixed : State Sales Tax", "ST",
                                                   "TXI02 : Monetary Amount", Data["arinv_inv_tx_tvh"].ToString(),
                                                   "TXI03 : Percent: Percentage expressed as a decimal", (Convert.ToDecimal(Data["arinv_tvhtaux"]) / 100).ToString());
                }

                //CTT Loop
                WriteSegmentLoop("CTTLoop1", "Loop", "CTT", "Segment",
                    "Calc: TotalNumberOfLineItem", TotalNumberOfLineItem.ToString(),
                    "Calc: TotalNumberOfLineItemQty", TotalNumberOfLineItemQty.ToString());

                writer.WriteEndElement(); //TX-00403-810

                writer.WriteEndElement(); //TransactionSet


            } // Using XMLWriter

        } // Write()

        public void WriteIT1Loop1(IDataRecord TheDataDetails)
        {
            writer.WriteStartElement("IT1Loop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("IT1", "Segment",
                    "IT101 : Assigned Identification : Calc: arinvd_invline * 10", (Convert.ToInt32(TheDataDetails["arinvd_invline"]) * 10).ToString(),
                    "IT102 : Quantity Invoiced : arinvd_qty", Convert.ToInt32(TheDataDetails["arinvd_qty"]).ToString(), //convert 
                    "IT103 : Unit or Basis for Measurement Code : Fixed : Each", "EA",
                    "IT104 : Unit Price : arinvd_inv_mnt_unit", TheDataDetails["arinvd_inv_mnt_unit"].ToString(),
                    "IT105 : Basis of Unit Price Code : UnitMappings(unite): " + TheDataDetails["arinvd_unite"].ToString(), UnitMappings(TheDataDetails["arinvd_unite"].ToString()),
                    "IT106 : Product/Service ID Qualifier : Fixed: Buyer's Catalog Number", "CB",
                    "IT107 : Product/Service ID : ivprixdcli_codecli", TheDataDetails["ivprixdcli_codecli"].ToString(),
                    "IT108 : Product/Service ID Qualifier : Fixed: Vendor's (Seller's) Part Number", "VP",
                    "IT109 : Product/Service ID : ivprod_code", TheDataDetails["ivprod_code"].ToString());

            }
            writer.WriteEndElement(); //IT1Loop1
        }

        public void WritePIDLoop1(IDataRecord TheDataDetails)
        {

            writer.WriteStartElement("PIDLoop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("PID", "Segment",
                    "PID01 : Item Description Type : Fixed : Free-form", "F",
                    "PID02 : Product/Process Characteristic Code : Fixed", "",
                    "PID03 : Agency Qualifier Code: Fixed", "",
                    "PID04 : Product Description Code: Fixed", "",
                    "PID05 : Description : ivprod_desc", TheDataDetails["ivprod_desc"].ToString());

                WriteSegment("REF", "Segment",
                   "REF01 : Reference Identification Qualifier : Delivery Reference", "KK",
                   "REF02 : Reference Identification : arinvd_idbil", TheDataDetails["arinvd_idbil"].ToString());

                WriteSegment("REF", "Segment",
                  "REF01 : Reference Identification Qualifier: Purchase Order Number", "PO",
                  "REF02 : Reference Identification : cocom_clientpo", TheDataDetails["cocom_clientpo"].ToString());

                WriteSegment("REF", "Segment",
                  "REF01 : Reference Identification Qualifier: Vendor Order Number", "VN",
                  "REF02 : Reference Identification : cocom_ident", TheDataDetails["cocom_ident"].ToString());
            }
            writer.WriteEndElement(); //PIDLoop1
        }

    }
}