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
    public class Program_810 : EDI_RSS.Program_Base
    {
        public Program_810()
        {
            TransactionCode = "810";

            LogEventSource = "EDI 810 Processor";

            Xml810Writer xml = null;

            List<IDataRecord> RawDataDetails;
            string arinv_ident;
            string edi_ident;

            Status += "Program_810" + NL + "UseSystem: " + UseSystem + NL + "TheFilename: " + Filename + NL + "RSS_send_path: " + RSS_send_path + NL;

            try
            {
                List<IDataRecord> RawData = GetData();

                foreach (IDataRecord Data in RawData)
                {
                    arinv_ident = Data["arinv_ident"].ToString();
                    edi_ident = Data["edi_810_ident"].ToString();

                    SetupClient(Convert.ToInt32(Data["arinv_custid"]));

                    Status += "GetDataDetails: " + arinv_ident + NL;

                    RawDataDetails = GetDataDetails(arinv_ident);

                    xml = new Xml810Writer(Data, RawDataDetails);

                    xml.Write(this);

                    UpdateFilename("edi_810", xml.OutputFileName, edi_ident);
                }

            }
            catch (System.Exception e)
            {
                Error += "Error caught: " + e.ToString();
                LogWriter.WriteMessage(LogEventSource, $"Error caught: {e.Message}");
            }
            finally
            {
            }
        }

        //public void CreateNew()
        //{
        //    DB_VIVA.HExecuteSQLNonQuery(@" 
        //        INSERT INTO edi_810 (arinv_ident) 
        //        SELECT ident 
        //        FROM arinv
        //            WHERE   status = 'P' AND custid = 30037 AND 
        //                    ident > 14350 AND 
        //                    NOT EXISTS(SELECT 1 FROM edi_810 AS edi_810e WHERE edi_810e.arinv_ident = arinv.ident); 
        //        ALTER TABLE edi_810 AUTO_INCREMENT = 1;");
        //}

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT  
                    arinv.ident AS arinv_ident, arinv.invno AS arinv_invno, arinv.invdte AS arinv_invdte, arinv.custid AS arinv_custid,
                    arinv.po AS arinv_po, arinv.idbil AS arinv_idbil, arinv.inv_mnt AS arinv_inv_mnt, arinv.INV_TX_GST AS arinv_inv_tx_gst,
                    arinv.INV_TX_PST AS arinv_inv_tx_pst, arinv.TPSTAUX AS arinv_tpstaux, arinv.TVQTAUX AS arinv_tvqtaux,
                    arinv.TVHTAUX AS arinv_tvhtaux, arinv.INV_TX_TVH AS arinv_inv_tx_tvh,
					arclient.DISCOUNT_RATE AS arclient_discount_rate, arclient.DISCOUNT_DAYS AS arclient_discount_days, arclient.TERMS_DAYS AS arclient_terms_days,
                    edi_810.ident AS edi_810_ident, edi_810.filename AS edi_810_filename
                FROM arinv 
                INNER JOIN arclient ON arclient.ident = arinv.CUSTID
                INNER JOIN edi_810 ON edi_810.arinv_ident = arinv.ident
                WHERE edi_810.Sent = false;
                ");
        }

        public List<IDataRecord> GetDataDetails(string arinv_ident)
        {
            Params.Clear();
            Params.Add("?arinv_ident", arinv_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  
                        arinvd.invline AS arinvd_invline, arinvd.qty AS arinvd_qty, arinvd.inv_mnt_unit AS arinvd_inv_mnt_unit,
                        arinvd.unite AS arinvd_unite, arinvd.descr AS arinvd_descr, arinvd.idbil AS arinvd_idbil, arinvd.NOFSC AS arinvd_nofsc,
                        ivprod.code AS ivprod_code, ivprod.DESC AS ivprod_desc,
                        edi_810.ident AS edi_810_ident,
                        ivprixdcli.codecli AS ivprixdcli_codecli,
                        cobili.PO_NO AS cobili_po_no,
                        cocom.CLIENTPO AS cocom_clientpo, cocom.ident AS cocom_ident  
                FROM arinv 
                INNER JOIN arinvd ON arinv.ident = arinvd.ident
                INNER JOIN ivprod ON ivprod.ident = arinvd.idprod
                INNER JOIN edi_810 ON edi_810.arinv_ident = arinv.ident
                LEFT JOIN ivprixdcli ON (ivprixdcli.idclient = arinv.custid AND ivprixdcli.idprod = arinvd.idprod AND IFNULL(ivprixdcli.codecli, '') <> '')
                INNER JOIN cobili ON cobili.IDCOBIL= arinv.IDBIL AND cobili.LINE = arinvd.BIL_LINE
                INNER JOIN cocom ON cocom.ident = cobili.IDCOM
                WHERE   edi_810.Sent = false 
                        AND
                        arinv.ident = ?arinv_ident
                ORDER BY arinvd.ident, arinvd.invline
                ", Params);
        }
    }

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

            OutputFileName = $"{ClientID.PadLeft(5, '0')}-810-OUT-{Data["arinv_ident"].ToString()}-{Base.ToAlphaNumeric(Data["arinv_po"].ToString())}-{(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds}";

            edi_doc_number = 850;
            arclient_ident = GetInt(ClientID);

            gIDataEdi_path = GetEdi_partner("edi_arclient");

            if (gIDataEdi_path != null)
            {
                SetRouting_out_path("xml_x12");

                XmlFilePath = Path.Combine(RSS_send_path, OutputFileName + ".xml");

                Status += "Xml850Writer " + NL;
                Status += "OutputFileName: " + OutputFileName + NL;
                Status += "XmlFilePath: " + XmlFilePath + NL;
            }
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
                    writer.WriteElementString("ST01", "", "810"); // Transaction Set Identifier Code: 855 - Purchase Order Acknowledgment
                    writer.WriteElementString("ST02", "", TransactionControlNumber); // Transaction Set Control Number
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


                WriteN1Loop1_arclient(EntityCode1.BY, EntityCode2.SellerCode);
                WriteN1Loop1_ffaddr(int.Parse(Data["arinv_ident"].ToString()), EntityCode1.ST, EntityCode2.SellerCode);
                WriteN1Loop1_wscie(EntityCode1.VN, EntityCode2.SellerCode);

                //ITD segment
                WriteSegment("ITD", "Segment", "ITD01 : Terms Type Code", "",
                                               "ITD02 : Terms Basis Date Code: Fixed: Invoice Date", "3",
                                               "ITD03 : Terms Discount Percent: arclient_discount_rate", Convert.ToInt32(Data["arclient_discount_rate"]).ToString(), 
                                               "ITD04 : Terms Discount Due Date", "",
                                               "ITD05 : Terms Discount Days Due: arclient_discount_days", Data["arclient_discount_days"].ToString(),
                                               "ITD06 : Terms Net Due Date", "",
                                               "ITD07 : Terms Net Days: arclient_terms_days", Data["arclient_terms_days"].ToString());

                foreach (var DataDetail in RawDataDetails)
                {
                    int QtyInvoiced = Convert.ToInt32(DataDetail["arinvd_qty"]);

                    TotalNumberOfLineItem++;
                    TotalNumberOfLineItemQty += QtyInvoiced;

                    WriteIT1Loop1(DataDetail);
                    

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

                decimal totalTaxAmount = Convert.ToDecimal(Data["arinv_inv_tx_pst"]) + Convert.ToDecimal(Data["arinv_inv_tx_tvh"]);
                //AMT segment
                WriteSegment("AMT", "Segment", "AMT01 : Amount Qualifier Code : Fixed : Tax", "T",
                                               "AMT02 : Monetary Amount", totalTaxAmount.ToString());

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
                    "IT103 : Unit or Basis for Measurement Code : Fixed : Envelope", "EV",
                    "IT104 : Unit Price : arinvd_inv_mnt_unit", TheDataDetails["arinvd_inv_mnt_unit"].ToString(),
                    "IT105 : Basis of Unit Price Code : UnitMappings(unite): " + TheDataDetails["arinvd_unite"].ToString(), UnitMappings(TheDataDetails["arinvd_unite"].ToString()),
                    "IT106 : Product/Service ID Qualifier : Fixed: Buyer's Catalog Number", "CB",
                    "IT107 : Product/Service ID : ivprixdcli_codecli", TheDataDetails["ivprixdcli_codecli"].ToString(),
                    "IT108 : Product/Service ID Qualifier : Fixed: Vendor's (Seller's) Part Number", "VP",
                    "IT109 : Product/Service ID : ivprod_code", TheDataDetails["ivprod_code"].ToString());

                decimal MonetaryAmount = (Convert.ToDecimal(TheDataDetails["arinvd_qty"]) / 1000) * Convert.ToDecimal(TheDataDetails["arinvd_inv_mnt_unit"]);
                //PAM Loop
                WriteSegment("PAM", "Segment", "PAM01 : Quantity Qualifier : Fixed : Discrete Quantity", "01",
                                               "PAM02 : Quantity : Calc: arinvd_qty / 1000", Math.Round((Convert.ToDecimal(TheDataDetails["arinvd_qty"]) / 1000), 3).ToString(),
                                               "PAM03-01 : Unit or Basis for Measurement Code : Fixed : per thousand", "TP",
                                               "PAM03-02 : Multiplier : arinvd_inv_mnt_unit", Math.Round(Convert.ToDecimal(TheDataDetails["arinvd_inv_mnt_unit"]), 3).ToString(),
                                               "PAM04 : Amount Qualifier Code : Fixed : Line Item Total", "1",
                                               "PAM05 : Monetary Amount : MonetaryAmount", Math.Round(MonetaryAmount, 2).ToString());

                WritePIDLoop1(TheDataDetails);
            }
            writer.WriteEndElement(); //IT1Loop1
        }

        public void WritePIDLoop1(IDataRecord TheDataDetails)
        {
            string nofsc = TheDataDetails["arinvd_nofsc"].ToString();
            if(nofsc != "")
            {
                nofsc = NL + nofsc;
            }

            writer.WriteStartElement("PIDLoop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("PID", "Segment",
                    "PID01 : Item Description Type : Fixed : Free-form", "F",
                    "PID02 : Product/Process Characteristic Code : Fixed", "",
                    "PID03 : Agency Qualifier Code: Fixed", "",
                    "PID04 : Product Description Code: Fixed", "",
                    "PID05 : Description : ivprod_desc", TheDataDetails["ivprod_desc"].ToString() + nofsc);

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