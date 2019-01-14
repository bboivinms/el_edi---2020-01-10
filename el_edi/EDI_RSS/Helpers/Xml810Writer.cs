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

            Status += "Xml855Writer " + NL;
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

                writer.WriteElementString("STO1", "", "810"); // Transaction Set Identifier Code: 855 - Purchase Order Acknowledgment
                writer.WriteElementString("STO2", "", TransactionControlNumber); // Transaction Set Control Number

                writer.WriteEndElement(); //Meta

                //BAK segement
                // BIG07 BB Billback : CO Corrected / CR Credit Memo / DR Debit Memo / DU Duplicate / RE Rebill
                // PR Product(or Service) Is the usual default but should be explicit to avoid wrong assumptions by the receiving party.
                WriteSegment("BIG", "Segment", "Invoice Date: arinv_invdte", string.Format("{0:yyyyMMdd}", Data["arinv_invdte"]),
                                               "Invoice Number: arinv_ident", Data["arinv_ident"].ToString(),
                                               "Fixed: Client Purchase Order Date", "",
                                               "Client Purchase Order Number: arinv_po", Data["arinv_po"].ToString(),
                                               "Fixed: Release Number", "",
                                               "Fixed: Change Order Sequence Number", "",
                                               "Fixed: Transaction Type Code: PR Product(or Service)", "PR"
                                               );

                WriteSegment("CUR", "Segment", "Fixed: Entity Identifier Code: Vendor", "VN",
                                               "Fixed: Currency Code", "CAD"
                                               );

                //REF segment
                // WriteSegment("REF", "Segment", "VR", "TBD"); //TODO: get the EL supplier ID for the current customer

                WriteN1Loop1(EntityCode1.VN, EntityCode2.SellerCode, CData,
                    "iddel_addr", "",
                    "cocom_del_name",
                    "cocom_daddr1",
                    "cocom_daddr2",
                    "cocom_dcity",
                    "cocom_dstate",
                    "cocom_dzip"
                );

                /*
                //DTM segment
                //TODO: decide if we will send the DTM once for the order, once per item, or both
                // WriteSegment("DTM", "Segment", "002", string.Format("{0:yyyyMMdd}", RawDataPO.ElementAt(0)["cocomi_req_date"])); //Requested shipping date

                //N1 segment
                // N103 : "91": "Assigned by Seller or Seller's Agent"
                writer.WriteStartElement("N1Loop1");
                writer.WriteAttributeString("type", "Loop");
                {
                    List<IDataRecord> RawDataAddress = Program_855.DB_VIVA.GetAddress(ClientId, Data["cocom_dzip"].ToString());
                    IDataRecord DataAddress;

                    string iddel_addr = "";

                    if (RawDataAddress.Count > 0) { DataAddress = RawDataAddress[0]; iddel_addr = DataAddress["iddel_addr"].ToString(); }

                    WriteSegment("N1", "Segment", "Fixed: Ship To", "ST", "cocom_del_name", Data["cocom_del_name"].ToString(), "Fixed: Assigned by Seller or Seller's Agent", "91", "iddel_addr", iddel_addr);
                    if (Data["cocom_daddr1"].ToString() != "")
                    {
                        WriteSegment("N3", "Segment", "cocom_daddr1", Data["cocom_daddr1"].ToString(), "cocom_daddr2", Data["cocom_daddr2"].ToString());
                        WriteSegment("N4", "Segment", "cocom_dcity", Data["cocom_dcity"].ToString(), "cocom_dstate", Data["cocom_dstate"].ToString(), "cocom_dzip", Data["cocom_dzip"].ToString(), "Fixed: Canada", "CA");
                    }

                }
                writer.WriteEndElement(); //N1Loop1

                foreach (var DataDetail in RawDataDetails)
                {
                    Decimal QtyOrdered = Convert.ToDecimal("0" + DataDetail["cocomi_qty_ord"]);

                    TotalNumberOfLineItem++;
                    TotalNumberOfLineItemQty += QtyOrdered;

                    writer.WriteStartElement("PO1Loop1");
                    writer.WriteAttributeString("type", "Loop");
                    {
                        WriteSegment("PO1", "Segment",
                            "Calc: cocomi_line * 10", (Convert.ToInt16(DataDetail["cocomi_line"]) * 10).ToString(), //Assigned Identification (line number)
                            "cocomi_qty_ord", DataDetail["cocomi_qty_ord"].ToString(), //Quantity Ordered
                            "Fixed: Unit: Envelope", "EV", //Unit or Basis for Measurement Code
                            "cocomi_price", DataDetail["cocomi_price"].ToString(), //Unit Price
                            "UnitMappings(unite): " + DataDetail["cocomi_unite"].ToString()
                                                        , UnitMappings(DataDetail["cocomi_unite"].ToString()), //Basis of Unit Price Code
                            "Fixed: Customer Item No", "CB",
                            "ivprixdcli_codecli", DataDetail["ivprixdcli_codecli"].ToString(),
                            "Fixed: Vendor's (Seller's) Part Number", "VP",
                            $"ivprod_code (ivprod_ident={DataDetail["ivprod_ident"].ToString()})", DataDetail["ivprod_code"].ToString()
                            );

                        WriteSegment("REF", "Segment", "Fixed: Purchase Order Number", "PO", "cocom_clientpo", Data["cocom_clientpo"].ToString());
                        WriteSegment("REF", "Segment", "Fixed: Vendor Order Number", "VN", "cocom_ident", Data["cocom_ident"].ToString());

                        //CTP segment
                        // WriteSegment("CTP", "Segment", "DI", "UCP", item["cocomi_price"].ToString()); // Pricing Information // Already in PO01

                        //DTM segment
                        // WriteSegment("DTM", "Segment", "068", "20200101"); // Date time reference // 017 Estimated Delivery / 067 Current Schedule Delivery // Already in ACK

                    }
                    writer.WriteEndElement(); //POLoop1
                    
                }
                */
                //CTT Loop
                WriteSegmentLoop("CTTLoop1", "Loop", "CTT", "Segment",
                    "Calc: TotalNumberOfLineItem", TotalNumberOfLineItem.ToString(),
                    "Calc: TotalNumberOfLineItemQty", TotalNumberOfLineItemQty.ToString());

                writer.WriteEndElement(); //TX-00403-810

                writer.WriteEndElement(); //TransactionSet


            } // Using XMLWriter

        } // Write()
    }
}