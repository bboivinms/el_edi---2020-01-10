using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.IO;
using EDI_DB.Data;

namespace EDI_DB.Data
{
    public class DB_XmlWriter
    {
        public string XmlFilePath { get; set; }
        public string OutputFileName { get; set; }
        public string ClientID { get; set; }

        protected XmlWriter writer;

        protected void WriteSegmentLoop(string Loop, string LoopType, string Segment, string SegmentType = "",
                string Comment1 = "", string Seg1 = "x0x",
                string Comment2 = "", string Seg2 = "x0x",
                string Comment3 = "", string Seg3 = "x0x",
                string Comment4 = "", string Seg4 = "x0x",
                string Comment5 = "", string Seg5 = "x0x",
                string Comment6 = "", string Seg6 = "x0x",
                string Comment7 = "", string Seg7 = "x0x",
                string Comment8 = "", string Seg8 = "x0x",
                string Comment9 = "", string Seg9 = "x0x")
        {
            writer.WriteStartElement(Loop);
            if (LoopType != "") writer.WriteAttributeString("type", LoopType);
            WriteSegment(Segment, SegmentType, Comment1, Seg1, Comment2, Seg2, Comment3, Seg3, Comment4, Seg4, Comment5, Seg5, Comment6, Seg6, Comment7, Seg7, Comment8, Seg8, Comment9, Seg9);
            writer.WriteEndElement();
        }

        protected void WriteSegment(string Segment, string SegmentType = "",
                string Comment1 = "", string Seg1 = "x0x",
                string Comment2 = "", string Seg2 = "x0x",
                string Comment3 = "", string Seg3 = "x0x",
                string Comment4 = "", string Seg4 = "x0x",
                string Comment5 = "", string Seg5 = "x0x",
                string Comment6 = "", string Seg6 = "x0x",
                string Comment7 = "", string Seg7 = "x0x",
                string Comment8 = "", string Seg8 = "x0x",
                string Comment9 = "", string Seg9 = "x0x")
        {
            writer.WriteStartElement(Segment);
            if(SegmentType != "") writer.WriteAttributeString("type", SegmentType);
            {
                if (Seg1 != "x0x") { if (Comment1 != "") Comment(Comment1); writer.WriteElementString($"{Segment}01", Seg1); }
                if (Seg2 != "x0x") { if (Comment2 != "") Comment(Comment2); writer.WriteElementString($"{Segment}02", Seg2); }
                if (Seg3 != "x0x") { if (Comment3 != "") Comment(Comment3); writer.WriteElementString($"{Segment}03", Seg3); }
                if (Seg4 != "x0x") { if (Comment4 != "") Comment(Comment4); writer.WriteElementString($"{Segment}04", Seg4); }
                if (Seg5 != "x0x") { if (Comment5 != "") Comment(Comment5); writer.WriteElementString($"{Segment}05", Seg5); }
                if (Seg6 != "x0x") { if (Comment6 != "") Comment(Comment6); writer.WriteElementString($"{Segment}06", Seg6); }
                if (Seg7 != "x0x") { if (Comment7 != "") Comment(Comment7); writer.WriteElementString($"{Segment}07", Seg7); }
                if (Seg8 != "x0x") { if (Comment8 != "") Comment(Comment8); writer.WriteElementString($"{Segment}08", Seg8); }
                if (Seg9 != "x0x") { if (Comment9 != "") Comment(Comment9); writer.WriteElementString($"{Segment}09", Seg9); }
            }
            writer.WriteEndElement();
        }

        public static class EntityCode1
        {
            public static string[] ST = { "ST", "Ship To" };
            public static string[] BY = { "BY", "Buying Party (Purchaser)" };
            public static string[] VN = { "VN", "Vendor" };
        }

        public static class EntityCode2
        {
            public static string[] SellerCode = { "91", "Assigned by Seller or Seller's Agent" };
        }

        public void WriteN1Loop1(
            string[] pEntityCode1,
            string[] pEntityCode2,
            CIDataRecord data_record,
            string Comment_pId_addr,
            string pId_addr,
            string Data_name,
            string Data_addr1,
            string Data_addr2,
            string Data_city, 
            string Data_state,
            string Data_zip
        )
        {
            writer.WriteStartElement("N1Loop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("N1", "Segment", "pEntityIdentifierCode: " + pEntityCode1[1], pEntityCode1[0], Data_name, data_record[Data_name], pEntityCode2[1], pEntityCode2[0], Comment_pId_addr, pId_addr);
                if (Data_addr1 != "")
                {
                    WriteSegment("N3", "Segment", Data_addr1, data_record[Data_addr1], Data_addr2, data_record[Data_addr2]);
                    WriteSegment("N4", "Segment", Data_city, data_record[Data_city], Data_state, data_record[Data_state], Data_zip, data_record[Data_zip], "Fixed: Canada", "CA");
                }

            }
            writer.WriteEndElement(); //N1Loop1
        }

        private string Comment(string pComment)
        {
            writer.WriteComment(pComment);
            return "";
        }

        public string UnitMappings(string Units)
        {
            if (Units == "/Mille") return "TP";
            return "UN";
        }
    }
}
