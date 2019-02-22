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
            arclient_ident = GetInt(ClientID);

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

        public void Write(Program_855 mysql)
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

            using (writer = XmlWriter.Create(XmlFilePath, settings))
            {
                writer.WriteStartElement("TransactionSet");
                writer.WriteStartElement("TX-00403-855");
                writer.WriteAttributeString("type", "TransactionSet");

                writer.WriteStartElement("Meta");

                writer.WriteElementString("STO1", "", "855"); // Transaction Set Identifier Code: 855 - Purchase Order Acknowledgment
                writer.WriteElementString("STO2", "", TransactionControlNumber); // Transaction Set Control Number

                writer.WriteEndElement(); //Meta

                //BAK segement
                WriteSegment("BAK", "Segment", "Fixed: Original"                , "00", //Transaction Set Purpose Code: "00" = Original / "06" = Confirmation
                                               "Fixed: Acknowledgment Type: Acknowledge product replenishment", "AP",
                                               "cocom_clientpo"                 , CDataCocom["cocom_clientpo"],
                                               "cocom_co_dte"                   , string.Format("{0:yyyyMMdd}", DataCocom["cocom_co_dte"]),
                                               "Fixed: Release Number"          , "",
                                               "Fixed: Request Reference Number", "",
                                               "Fixed: Contract Number"         , "",
                                               "cocom_ident"                    , CDataCocom["cocom_ident"],
                                               "cocom_co_dte"                   , string.Format("{0:yyyyMMdd}", DataCocom["cocom_co_dte"])
                                               );

                //REF segment
                // WriteSegment("REF", "Segment", "VR", "TBD"); //TODO: get the EL supplier ID for the current customer

                //DTM segment
                //TODO: decide if we will send the DTM once for the order, once per item, or both
                // WriteSegment("DTM", "Segment", "002", string.Format("{0:yyyyMMdd}", RawDataPO.ElementAt(0)["cocomi_req_date"])); //Requested shipping date

                WriteN1Loop1(EntityCode1.ST, EntityCode2.SellerCode, CDataCocom,
                    "iddel_addr", iddel_addr,
                    "cocom_del_name",
                    "cocom_daddr1",
                    "cocom_daddr2",
                    "cocom_dcity",
                    "cocom_dstate",
                    "cocom_dzip"
                );
                
                foreach (var DataCocomiItem in RawDataCocomi)
                {
                    Decimal QtyOrdered = Convert.ToDecimal("0" + DataCocomiItem["cocomi_qty_ord"]);
                    Decimal TotalNumberOfShippingQty = 0;

                    TotalNumberOfLineItem++;
                    TotalNumberOfLineItemQty += QtyOrdered;

                    writer.WriteStartElement("PO1Loop1");
                    writer.WriteAttributeString("type", "Loop");
                    {
                        WriteSegment("PO1", "Segment",
                            "Calc: cocomi_line * 10"    , (Convert.ToInt16(DataCocomiItem["cocomi_line"]) * 10).ToString(), //Assigned Identification (line number)
                            "cocomi_qty_ord"            , DataCocomiItem["cocomi_qty_ord"].ToString(), //Quantity Ordered
                            "Fixed: Unit: Envelope"     , "EV", //Unit or Basis for Measurement Code
                            "cocomi_price"              , DataCocomiItem["cocomi_price"].ToString(), //Unit Price
                            "UnitMappings(unite): " + DataCocomiItem["cocomi_unite"].ToString()
                                                        , UnitMappings(DataCocomiItem["cocomi_unite"].ToString()), //Basis of Unit Price Code
                            "Fixed: Buyer's Catalog Number", "CB", 
                            "ivprixdcli_codecli"        , DataCocomiItem["ivprixdcli_codecli"].ToString(), 
                            "Fixed: Vendor's (Seller's) Part Number", "VP",
                            $"ivprod_code (ivprod_ident={DataCocomiItem["ivprod_ident"].ToString()})", DataCocomiItem["ivprod_code"].ToString() 
                            );

                        WriteSegment("REF", "Segment", "Fixed: Purchase Order Number", "PO", "cocom_clientpo", DataCocom["cocom_clientpo"].ToString());
                        WriteSegment("REF", "Segment", "Fixed: Vendor Order Number"  , "VN", "cocom_ident"   , DataCocomiItem["cocom_ident"].ToString());

                        //CTP segment
                        // WriteSegment("CTP", "Segment", "DI", "UCP", item["cocomi_price"].ToString()); // Pricing Information // Already in PO01

                        //DTM segment
                        // WriteSegment("DTM", "Segment", "068", "20200101"); // Date time reference // 017 Estimated Delivery / 067 Current Schedule Delivery // Already in ACK

                        List<IDataRecord> RawDataCocomiLine = mysql.GetDataLines(DataCocomiItem["cocom_ident"].ToString(), DataCocomiItem["cocomi_line"].ToString());

                        //There might be multiple 855, each group represents a single one
                        foreach (IDataRecord DataCocomiLineItem in RawDataCocomiLine)
                        {
                            TotalNumberOfShippingQty += Convert.ToDecimal("0" + DataCocomiLineItem["cobili_qty"]);

                            // ACK01        : "IA": "Item Accepted", "IB": "Item Backordered", "IC": "Item Accepted - Changes Made", "ID": "Item Deleted", "IE": "Item Accepted, Price Pending",
                            //              : "AC": "Item Accepted and Shipped", "AR": "Item Accepted and Released for Shipment", "BP": "Item Accepted - Partial Shipment, Balance Backordered",
                            //              : "DR": "Item Accepted - Date Rescheduled" ... etc
                            // ACK03 / PO103 / SCH02: "EA": "Each", "EV": "Envelope"
                            // ACK04 / SCH05              : "067": "Current Schedule Delivery"
                            
                            if(Convert.ToDecimal("0" + DataCocomiLineItem["cobili_qty"]) != 0)
                            { 
                                WriteSegmentLoop("ACKLoop1", "Loop", "ACK", "Segment",
                                       "Fixed: Item Accepted"               , "IA",
                                       "cobili_qty"                         , DataCocomiLineItem["cobili_qty"].ToString(),
                                       "Fixed: Unit: Envelope"              , "EV",
                                       "Fixed: Current Schedule Delivery"   , "067",
                                       "cobil_req_date"                     , string.Format("{0:yyyyMMdd}", DataCocomiLineItem["cobil_req_date"]));
                            }
                        }

                        if(TotalNumberOfShippingQty < QtyOrdered)
                        {
                            // ACK04        : "100":  "No Shipping Schedule Established as of…"
                            WriteSegmentLoop("ACKLoop1", "Loop", "ACK", "Segment",
                                "Fixed: Item Backordered"                       , "IB",
                                "Calc: (QtyOrdered - TotalNumberOfShippingQty)" , (QtyOrdered - TotalNumberOfShippingQty).ToString(),
                                "Fixed: Unit: Envelope"                         , "EV",
                                "Fixed: No Shipping Schedule Established as of…", "100",
                                "Calc: Today()"                                 , string.Format("{0:yyyyMMdd}", DateTime.Today)
                                );
                        }

                        //There might be multiple 855, each group represents a single one
                        foreach (IDataRecord DataCocomiLineItem in RawDataCocomiLine)
                        {
                            // ACK03 / PO103 / SCH02: "EA": "Each", "EV": "Envelope"
                            // ACK04 / SCH05              : "067": "Current Schedule Delivery"
                            if (Convert.ToDecimal("0" + DataCocomiLineItem["cobili_qty"]) != 0)
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

                    } writer.WriteEndElement(); //POLoop1

                }

                //CTT Loop
                WriteSegmentLoop("CTTLoop1", "Loop", "CTT", "Segment",
                    "Calc: TotalNumberOfLineItem", TotalNumberOfLineItem.ToString(),
                    "Calc: TotalNumberOfLineItemQty", TotalNumberOfLineItemQty.ToString());

                writer.WriteEndElement(); //TX-00403-855

                writer.WriteEndElement(); //TransactionSet

            } // Using XMLWriter

        } // Write()
    }
}