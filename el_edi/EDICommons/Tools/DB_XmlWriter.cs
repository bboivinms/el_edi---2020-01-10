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
using static EDI_DB.Data.Base;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Globalization;

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
                string Comment9 = "", string Seg9 = "x0x",
                string Comment10 = "", string Seg10 = "x0x",
                string Comment11 = "", string Seg11 = "x0x")
        {
            writer.WriteStartElement(Segment);
            if (SegmentType != "") writer.WriteAttributeString("type", SegmentType);
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
                if (Seg10 != "x0x") { if (Comment10 != "") Comment(Comment10); writer.WriteElementString($"{Segment}10", Seg10); }
                if (Seg11 != "x0x") { if (Comment11 != "") Comment(Comment11); writer.WriteElementString($"{Segment}11", Seg11); }
            }
            writer.WriteEndElement();
        }

        public static class PerCode
        {
            public static string[] BD = { "BD", "Buyer Name or Department" };
            public static string[] CN = { "CN", "General Contact" };
        }

        public static class EntityCode1
        {
            public static string[] ST = { "ST", "Ship To" };
            public static string[] SF = { "SF", "Ship From" };
            public static string[] BY = { "BY", "Buying Party (Purchaser)" };
            public static string[] BT = { "BT", "Bill-to-Party (Purchaser)" };
            public static string[] VN = { "VN", "Vendor" };
        }

        public static class EntityCode2
        {
            public static string[] SellerCode = { "91", "Assigned by Seller or Seller's Agent" };
            public static string[] BuyerCode = { "92", "Assigned by Buyer or Buyer's Agent" };
            public static string[] MutuallyDefined = { "ZZ", "Mutually Defined" };
        }

        /// It write the N1Loop1 xml tag for the arclient
        public void WriteN1Loop1_arclient(string[] entityCode1, DB_PER pDB_PER = null)
        {
            CIDataRecord data_record = new CIDataRecord(DB_VIVA.GetAddressArclient(IDpartner));
            string[] entityCode2;
            string iddel_addr;
            
            if (IDpartner == 30037)
            {
                entityCode2 = EntityCode2.BuyerCode;
                iddel_addr = "2000";
            }
            else
            {
                entityCode2 = EntityCode2.SellerCode;
                iddel_addr = data_record["iddel_addr"];
            }

            WriteN1Loop1(entityCode1, entityCode2, data_record,
                "iddel_addr",
                iddel_addr,
                "arclient_name",
                "arclient_addr1",
                "arclient_addr2",
                "arclient_city",
                "arclient_state",
                "arclient_zip",
                pDB_PER
            );
        }

        public void WriteN1Loop1_arclient_name(string arclient_name, string[] entityCode1, string[] entityCode2, DB_PER pDB_PER = null)
        {
            CIDataRecord data_record = new CIDataRecord(DB_VIVA.GetAddressArclientName(arclient_name));

            if (data_record.data_record == null) return;

            WriteN1Loop1(entityCode1, entityCode2, data_record,
                "iddel_addr",
                data_record["iddel_addr"],
                "arclient_name",
                "arclient_addr1",
                "arclient_addr2",
                "arclient_city",
                "arclient_state",
                "arclient_zip",
                pDB_PER
            );
        }

        public void WriteN1Loop1_ffaddr(int arinv_ident, string[] entityCode1, DB_PER pDB_PER = null)
        {
            string postalCode = DB_VIVA.GetPostalCode(arinv_ident);

            CIDataRecord addressST_Data = new CIDataRecord(DB_VIVA.GetAddressST(IDpartner, postalCode));

            string[] entityCode2;
            string iddel_addr;

            if (IDpartner == 30037)
            {
                entityCode2 = EntityCode2.BuyerCode;
                iddel_addr = "2000";
            }
            else
            {
                entityCode2 = EntityCode2.SellerCode;
                iddel_addr = addressST_Data["iddel_addr"];
            }

            //write N1Loop1 xml tag for shipto
            WriteN1Loop1(entityCode1, entityCode2, addressST_Data,
                "iddel_addr",
                iddel_addr,
                "name",
                "addr1",
                "addr2",
                "city",
                "state",
                "zip",
                pDB_PER
            );
        }

        public void WriteN1Loop1_wscie(string[] entityCode1, string[] entityCode2, DB_PER pDB_PER = null, string Id = "0")
        {
            CIDataRecord data_record = new CIDataRecord(DB_VIVA.GetAddressWscie());

            //ariva 101440 = by 850
            //ariva : 20036 = seller 810

            string commentId = "Fixed : Id provide by partner";

            if (IDpartner == 929)
            {
                commentId = "Fixed : Id provide by kruger";
                Id = "323646";
            }
            else if(Id == "0")
            {
                commentId = "wscie_cie_id";
                Id = data_record["wscie_cie_id"].ToString();
                Id = Id.PadLeft(2, '0');
            }

            //write N1Loop1 xml tag for 
            WriteN1Loop1(entityCode1, entityCode2, data_record,
                commentId,
                Id,
                "wscie_name",
                "wscie_adr1",
                "wscie_adr2",
                "wscie_city",
                "wscie_state",
                "wscie_zip",
                pDB_PER
            );
        }

        public void WriteN1Loop1_apsupp(int idVendor, string[] entityCode1, DB_PER pDB_PER = null)
        {
            CIDataRecord data_record = new CIDataRecord(DB_VIVA.GetAddressApsupp(idVendor));
            string[] entityCode2;

            string pId_addr;
            entityCode2 = EntityCode2.BuyerCode;
            pId_addr = data_record["apsupp_ident"].ToString();

            //write N1Loop1 xml tag for 
            WriteN1Loop1(entityCode1, entityCode2, data_record,
                "apsupp_ident",
                pId_addr,
                "apsupp_name",
                "apsupp_addr1",
                "apsupp_addr2",
                "apsupp_city",
                "apsupp_state",
                "apsupp_zip",
                pDB_PER
            );
        }

        public void WriteN9Loop_Technique(IDataRecord Data, IDataRecord RawDataDetails)
        {

            string xml = Data["edi_850_Xml_technique"].ToString();

            XDocument xmlDoc = XDocument.Parse(xml);

            XElement node;
            if ((node = xmlDoc.XPathSelectElement("//item[idprod = " + RawDataDetails["ivprod_ident"] + "]")) != null)
            {
                XElement code_pal;
                if((code_pal = node.XPathSelectElement(".//code_pal")) != null)
                {
                    //string base64ImageRepresentation = "";

                    string figFilename = @"C:\EDI_INFO" + @"\fig\" + code_pal.Value.TrimEnd('\n') + ".jpg";
                    if (File.Exists(figFilename))
                    {
                        //byte[] imageArray = System.IO.File.ReadAllBytes(figFilename);
                        //base64ImageRepresentation = Convert.ToBase64String(imageArray);

                        //WriteN9Loop1("imageTextRepresentation", "data:image/jpg;base64," + base64ImageRepresentation, "CODE_PAL_IMAGE");

                        if (wscie == "E")
                            WriteN9Loop1("url", @"client.envl.ca/images/edi-fig/" + code_pal.Value.TrimEnd('\n') + ".jpg", "CODE_PAL_URL");
                        else if (wscie == "M")
                            WriteN9Loop1("url", @"clients.multi-services.org/images/edi-fig/" + code_pal.Value.TrimEnd('\n') + ".jpg", "CODE_PAL_URL");
                    }
                    else
                    {
                        Error += "Error : Le fichier : " + figFilename + " est introuvable dans le serveur 252."  + NL;
                    }
  
                    if (node.XPathSelectElement(".//longueur").Value != "0" && node.XPathSelectElement(".//largeur").Value != "0" && node.XPathSelectElement(".//hauteur").Value != "0")
                    {
                        WriteN9Loop1("dimension", "Dimension max. ballots incluant palette."+ NL
                        + NL + "Long.: " + node.XPathSelectElement(".//longueur").Value
                        + NL + "Larg.: " + node.XPathSelectElement(".//largeur").Value
                        + NL + "Haut.: " + node.XPathSelectElement(".//hauteur").Value, "CODE_PAL_DIMENSION");
                    }
                }

                XElement MSG1 = node.XPathSelectElement(".//MSG1");

                if (MSG1 != null)
                    WriteN9Loop1("note technique", MSG1.Value, "TECH_SPECS");
            }
        }

        public void WriteN9Loop1(string Comment_MSG, string Segment_MSG, string Ref_N902 = "TEXT")
        {
            writer.WriteStartElement("N9Loop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("N9", "Segment", "N901 : Reference Identification Qualifier: Mutually Defined", "ZZ",
                                              "N902 : Reference Identification: Fixed", Ref_N902);

                string[]  msgArray = (Segment_MSG + NL).Replace("\r", "\n").Split('\n');
                foreach (string item in msgArray)
                {
                    if(item != "")
                    {
                        if (gIDataEdi_path["Edi_version"].ToString() == "00401")
                        {
                            WriteSegment("MSG", "Segment", "MSG01 : Free-Form Message Text: " + Comment_MSG, item.Trim());
                        }
                        else if (gIDataEdi_path["Edi_version"].ToString() == "00403")
                        {
                            WriteSegment("MTX", "Segment", "MTX01 : Note Reference Code: Mutually Defined", "ZZZ",
                                                           "MTX02 : Message Text: " + Comment_MSG, item.Trim());
                        }
                    }
                   
                }
            }
            writer.WriteEndElement(); //N9Loop1
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
            string Data_zip,
            DB_PER pDB_PER = null
        )
        {
            writer.WriteStartElement("N1Loop1");
            writer.WriteAttributeString("type", "Loop");
            {
                WriteSegment("N1", "Segment", "N101 : pEntityIdentifierCode: " + pEntityCode1[1], pEntityCode1[0],
                                              "N102 : " + Data_name, data_record[Data_name],
                                              "N103 : " + pEntityCode2[1], pEntityCode2[0],
                                              "N104 : " + Comment_pId_addr, pId_addr);
                if (data_record[Data_addr1] != "")
                {
                    string state;
                    if (data_record[Data_state].ToLower() == "qué" || data_record[Data_state].ToLower() == "que")
                    {
                        state = "QC";
                    }
                    else
                    {
                        state = data_record[Data_state];
                    }

                    WriteSegment("N3", "Segment", "N301 : " + Data_addr1, data_record[Data_addr1],
                                                  "N302 : " + Data_addr2, data_record[Data_addr2]);

                    WriteSegment("N4", "Segment", "N401 : " + Data_city, data_record[Data_city],
                                                  "N402 : " + Data_state, state,
                                                  "N403 : " + Data_zip, data_record[Data_zip],
                                                  "N404 : Fixed : Canada", "CA");
                }

            }
            if (pDB_PER != null) pDB_PER.Write();
            writer.WriteEndElement(); //N1Loop1
        }

        public class DB_PER
        {
            string[] PER01_Code;
            string PER02;
            List<string[]> PER = new List<string[]>();
            DB_XmlWriter db_xmlwriter;

            public DB_PER(DB_XmlWriter pdb_xmlwriter, string[] pPER01_Code, string pPER02_Name, string pPhone, string pEmail, string pFax)
            {
                db_xmlwriter = pdb_xmlwriter;
                PER01_Code = pPER01_Code;
                PER02 = pPER02_Name;

                if(pPhone != "")
                    PER.Add(new string[] { "TE", "Telephone", pPhone });

                if (pEmail != "")
                    PER.Add(new string[] { "EM", "Electronic Mail", pEmail });

                if (pFax != "")
                    PER.Add(new string[] { "FX", "Facsimile", pFax });

                if (PER.Count == 1)
                    PER.Add(new string[] { "x0x", "", "x0x" });

                if (PER.Count == 2)
                    PER.Add(new string[] { "x0x", "", "x0x" });
            }

            public void Write()
            {
                if (PER.Count == 0) return;

                db_xmlwriter.WriteSegment(
                    "PER", "Segment",
                    "PER01 : Contact Function Code : " + PER01_Code[1], PER01_Code[0],
                    "PER02 : Name", PER02,
                    "PER03 : Communication Number Qualifier : " + PER[0][1], PER[0][0],
                    "PER04 : Communication Number", PER[0][2],
                    "PER05 : Communication Number Qualifier : " + PER[1][1], PER[1][0],
                    "PER06 : Communication Number", PER[1][2],
                    "PER07 : Communication Number Qualifier : " + PER[2][1], PER[2][0],
                    "PER08 : Communication Number", PER[2][2]
                    );
            }
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
