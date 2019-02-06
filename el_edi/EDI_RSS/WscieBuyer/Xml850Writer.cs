﻿using MySql.Data.MySqlClient;
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
    public class Program_850 : EDI_RSS.Program_Base
    {
        public Program_850()
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
                CreateNew();

                List<IDataRecord> RawData = GetData();

                foreach (IDataRecord Data in RawData)
                {
                    popo_ident = Data["popo_ident"].ToString();
                    edi_ident = Data["edi_850_ident"].ToString();

                    SetupClient(Convert.ToInt32(Data["popo_ident"]));

                    Status += "GetDataDetails: " + popo_ident + NL;

                    RawDataDetails = GetDataDetails(popo_ident);

                    xml = new Xml850Writer(Data, RawDataDetails);

                    xml.Write(this);

                    UpdateFilename("edi_850", xml.OutputFileName, edi_ident);
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
                INSERT INTO edi_850 (popo_ident) 
                SELECT ident 
                FROM popo
                    WHERE status = 'R' AND IDVENDOR = 2004 AND 
                          ident = 101 AND 
                          NOT EXISTS(SELECT 1 FROM edi_850 AS edi_850e WHERE edi_850e.popo_ident = popo.ident); 
                ALTER TABLE edi_850 AUTO_INCREMENT = 1;");
        }

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT  
                        popo.ident AS popo_ident, popo.idvendor AS popo_idvendor, popo.pono AS popo_pono, 
                        popo.desc AS popo_desc, popo.po_dte AS popo_po_dte, popo.requ_dte AS popo_requ_dte,
                        apsupp.TERMS_DAYS AS apsupp_terms_days, apsupp.DISCOUNT_DAYS AS apsupp_discount_days, apsupp.DISCOUNT_RATE AS apsupp_discount_rate,
                        edi_850.ident AS edi_850_ident, edi_850.filename AS edi_850_filename
                FROM popo 
                INNER JOIN apsupp ON popo.IDVENDOR = apsupp.ident
                INNER JOIN edi_850 ON edi_850.popo_ident = popo.ident
                WHERE edi_850.Sent = false 
                      AND
                      popo.ident = 101
                ");
        }

        public List<IDataRecord> GetDataDetails(string popo_ident)
        {
            Params.Clear();
            Params.Add("?popo_ident", popo_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  
                        popoi.line AS popoi_line, popoi.qty_ord AS popoi_qty_ord, popoi.COST AS popoi_cost, 
                        popoi.date_rcv AS popoi_date_rcv, popoi.unite AS popoi_unite, popoi.desc AS popoi_desc,
                        ivprod.code AS ivprod_code,
                        edi_850.ident AS edi_850_ident
                FROM popo 
                INNER JOIN popoi ON popo.ident = popoi.idpo
                INNER JOIN ivprod ON ivprod.ident = popoi.idprod
                INNER JOIN edi_850 ON edi_850.popo_ident = popo.ident
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

            OutputFileName = $"{ClientID}-850OUT-{Data["popo_ident"].ToString()}-{Base.ToAlphaNumeric(Data["popo_pono"].ToString())}-{(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds}";

            XmlFilePath = Path.Combine(RSS_send_path, OutputFileName + ".xml");

            Status += "Xml850Writer " + NL;
            Status += "OutputFileName: " + OutputFileName + NL;
            Status += "XmlFilePath: " + XmlFilePath + NL;
        }

        public void Write(Program_850 mysql)
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

            using (writer = XmlWriter.Create(XmlFilePath, settings))
            {

                writer.WriteStartElement("TransactionSet");
                writer.WriteStartElement("TX-00401-850");
                writer.WriteAttributeString("type", "TransactionSet");

                writer.WriteStartElement("Meta");
                {
                    writer.WriteElementString("STO1", "", "850"); // Transaction Set Identifier Code: 850 - Purchase Order
                    writer.WriteElementString("STO2", "", TransactionControlNumber); // Transaction Set Control Number
                }
                writer.WriteEndElement(); //Meta

                //BEG segment
                WriteSegment("BEG", "Segment", "BEG01 : Transaction Set Purpose Code: Fixed: Original", "00",
                                               "BEG02 : Purchase Order Type Code: Fixed: Stand-alone Order", "SA",
                                               "BEG03 : Purchase Order Number : popo_pono", Data["popo_pono"].ToString(),
                                               "BEG04 : Release Number", "",
                                               "BEG05 : Date : popo_po_dte", string.Format("{0:yyyyMMdd}", Data["popo_po_dte"]));

                //CUR segment
                WriteSegment("CUR", "Segment", "CUR01 : Entity Identifier Code: Fixed: Buying Party", "BY",
                                               "CUR02 : Currency Code: Fixed: Canadian Dollar", "CAD");

                //REF segment
                WriteSegment("REF", "Segment", "REF01 : Reference Identification Qualifier : Fixed : Purchase Order Number", "PO",
                                               "REF02 : Reference Identification : popo_pono", Data["popo_pono"].ToString());

                //FOB segment
                WriteSegment("FOB", "Segment", "FOB01 : Shipment Method of Payment: Fixed: Paid by Seller", "PS",
                                               "FOB02 : Location Qualifier: Fixed: Mutually Defined", "ZZ",
                                               "FOB03 : Description : popo_desc", Data["popo_desc"].ToString(),
                                               "FOB04 : Transportation Terms Qualifier Code: Fixed: Incoterms", "01",
                                               "FOB05 : Transportation Terms Code: Fixed: Free on Board", "FOB");
                //ITD segment
                WriteSegment("ITD", "Segment", "ITD01 : Terms Type Code", "",
                                               "ITD02 : Terms Basis Date Code: Fixed: Invoice Date", "3",
                                               "ITD03 : Terms Discount Percent: apsupp_discount_rate", Convert.ToInt32(Data["apsupp_discount_rate"]).ToString(),
                                               "ITD04 : Terms Discount Due Date", "",
                                               "ITD05 : Terms Discount Days Due: apsupp_discount_days", Data["apsupp_discount_days"].ToString(),
                                               "ITD06 : Terms Net Due Date", "",
                                               "ITD07 : Terms Net Days: apsupp_terms_days", Data["apsupp_terms_days"].ToString());

                //DTM segment
                WriteSegment("DTM", "Segment", "DTM01 : Date/Time Qualifier : Fixed : Purchase Order", "004",
                                               "DTM02 : Date : popo_po_dte", string.Format("{0:yyyyMMdd}", Data["popo_po_dte"]),
                                               "DTM03 : Time", "");

                //DTM segment
                WriteSegment("DTM", "Segment", "DTM01 : Date/Time Qualifier : Fixed : Delivery Requested", "002",
                                               "DTM02 : Date : popo_requ_dte", string.Format("{0:yyyyMMdd}", Data["popo_requ_dte"]),
                                               "DTM03 : Time", "");

                WriteN1Loop1_wscie(EntityCode1.BY, EntityCode2.BuyerCode);
                WriteN1Loop1_apsupp(ClientId, EntityCode1.VN, EntityCode2.SellerCode);
                //WriteN1Loop1_wscie(EntityCode1.ST, EntityCode2.BuyerCode);

                //PO1Loop1 avec PIDLoop1
                foreach (var DataDetail in RawDataDetails)
                {
                    int QtyOrdered = Convert.ToInt32(DataDetail["popoi_qty_ord"]);

                    TotalNumberOfLineItem++;
                    TotalNumberOfLineItemQty += QtyOrdered;

                    WritePO1Loop1(DataDetail);

                }


                //CTT Loop
                WriteSegmentLoop("CTTLoop1", "Loop", "CTT", "Segment",
                    "Calc: TotalNumberOfLineItem", TotalNumberOfLineItem.ToString(),
                    "Calc: TotalNumberOfLineItemQty", TotalNumberOfLineItemQty.ToString());

                writer.WriteEndElement(); //TX-00401-850

                writer.WriteEndElement(); //TransactionSet


            } // Using XMLWriter

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
                       "PO103 : Unit or Basis for Measurement Code : Fixed : Envelope", "EV",
                       "PO104 : Unit Price: popoi_cost", Convert.ToDecimal(TheDataDetails["popoi_cost"]).ToString("#.##"),
                       "PO105 : Basis of Unit Price Code: Fixed : Price per Unit of Measure", "UM",
                       "PO106 : Product/Service ID Qualifier: Fixed : Buyer's Part Number", "BP",
                       "PO107 : Product/Service ID : ivprod_code", TheDataDetails["ivprod_code"].ToString(),
                       "PO108 : Product/Service ID Qualifier: Fixed : Vendor's (Seller's) Part Number", "VP",
                       "PO109 : Product/Service ID", ""); 

                writer.WriteStartElement("PIDLoop1");
                writer.WriteAttributeString("type", "Loop");
                {
                    WriteSegment("PID", "Segment",
                        "PID01 : Item Description Type : Fixed : Free-form", "F",
                        "PID02 : Product/Process Characteristic Code:", "",
                        "PID03 : Agency Qualifier Code:", "",
                        "PID04 : Product Description Code:", "",
                        "PID05 : Description : popoi_desc", TheDataDetails["popoi_desc"].ToString());
                }
                writer.WriteEndElement(); //PIDLoop1

                //DTM segment
                WriteSegment("DTM", "Segment", "DTM01 : Date/Time Qualifier : Fixed : Delivery Requested", "002",
                                               "DTM02 : Date : popoi_date_rcv", string.Format("{0:yyyyMMdd}", TheDataDetails["popoi_date_rcv"]),
                                               "DTM03 : Time", "");
            }
            writer.WriteEndElement(); //PO1Loop1
        }

    }
}