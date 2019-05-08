using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using static EDI_DB.Data.Base;

namespace MySQL_Dll
{
    public class Main
    {
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        public EDI_RSS.Program_RSS Program_RSS = new EDI_RSS.Program_RSS(new string[0]);

        /**
         * Insert in the table edi_850 and edi_rss a purchase order
         * Params :
         * 1. string rss_datapath : C:\VIVAEL\DATA
         * 2. int idvendor : 56 idvendor
         * 3. int ident : 17703 : popo_ident or arinv_ident
         * 4. int edi_doc_number : 850
         * 5. string Xml_technique : le technique de chaque item dans un po
         * 6. string error : indique s'il manque des données dans le technique ou autres (optional)
         */
        public void MySQL(string rss_datapath, int idvendor, int ident, int edi_doc_number, string Xml_technique, string error = "")
        {
            vendor = new EDI_RSS.Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            //avec le datapath, on connect avec la bonne DB
            gIDataEdi_path = GetIDedi_path(rss_datapath); 
            if (!vendor.Edi_path_after_Setup()) return; //setup connection DB 

            gRss_request = edi_doc_number + "P";
            gRss_client = "ALL";

            if (gRss_client != "ALL") return;
            if (gRss_request != "810P" && gRss_request != "850P" && gRss_request != "855P" && gRss_request != "856P") return;

            string portID;
            portID = "X" + IDE + "_" + edi_doc_number;

            Params.Clear();
            Params.Add("?idvendor", idvendor.ToString());

            //verifie si le 850 pour le vendor spécifier est a send
            List<IDataRecord> edi_apsuppData = DB_RSS.HExecuteSQLQuery("SELECT * FROM rss_bus.edi_apsupp WHERE idvendor = ?idvendor AND " + portID + " = 'send'", Params);

            //si il y a au moins un record
            if (edi_apsuppData.Count != 0)
            {
                Params.Clear();
                Params.Add("?idvendor", idvendor.ToString());
                Params.Add("?ident", ident.ToString());

                DB_VIVA.HExecuteSQLNonQuery($"INSERT INTO edi_{edi_doc_number} (popo_ident) " +
                                            $"SELECT ident " +
                                            $"FROM popo " +
                                                $"WHERE status = 'R' AND IDVENDOR = ?idvendor AND " +
                                                    $"ident = ?ident AND " +
                                                    $"NOT EXISTS(SELECT 1 FROM edi_{edi_doc_number} AS edi_{edi_doc_number}e WHERE edi_{edi_doc_number}e.popo_ident = popo.ident);" +
                                            $"ALTER TABLE edi_{edi_doc_number} AUTO_INCREMENT = 1;", Params);

                if(Xml_technique != "") //if we have techniques 
                {
                    Xml_technique = Xml_technique.Replace("&", "&amp;");
                    //verify if picture's file of item palettisation exists
                    bool isEmpty = false;

                    XDocument xmlDoc;
                    xmlDoc = XDocument.Parse(Xml_technique);

                    IEnumerable<XElement> items = xmlDoc.XPathSelectElements("//item");

                    string xmlError = error;

                    XDocument xmlDocError = null;
                    if (xmlError == "")
                    {
                        xmlError = "<error>";
                        isEmpty = true;
                    }
                    else
                    {
                        xmlDocError = XDocument.Parse(xmlError);
                    }

                    foreach (var item in items)
                    {
                        XElement code_pal;
                        if ((code_pal = item.XPathSelectElement(".//code_pal")) != null)
                        {
                            string figFilename = @"C:\EDI_INFO" + @"\fig\" + code_pal.Value.TrimEnd('\n') + ".jpg";

                            if (!File.Exists(figFilename))
                            {
                                if (!isEmpty)
                                {
                                    XElement message2 = new XElement("msg_NotFound", "Le fichier : " + figFilename + " est introuvable.");

                                    XElement itemError = xmlDocError.XPathSelectElement("//item[idprod = " + item.XPathSelectElement(".//idprod").Value + "]");

                                    itemError.XPathSelectElement(".//msg_dimension").AddAfterSelf(message2);

                                    error = xmlDocError.ToString();
                                }
                                else
                                {
                                    xmlError += "<item>"
                                             + "<idprod>" + item.XPathSelectElement(".//idprod").Value + "</idprod>"
                                             + "<msg_NotFound> Le fichier : " + figFilename + " est introuvable.</msg_NotFound>"
                                             + "</item>";
                                }
                            }
                        }
                    }


                    if (isEmpty)
                    {
                        if (xmlError != "<error>")
                        {
                            xmlError += "</error>";
                            xmlDocError = XDocument.Parse(xmlError);
                            error = xmlDocError.ToString();
                        }
                        else
                        {
                            xmlError = "";
                            error = xmlError.ToString();
                        }
                    }

                    //update edi_{810, 850} with Xml_technique and error
                    Params.Clear();
                    Params.Add("?Xml_technique", Xml_technique);
                    Params.Add("?error", error);
                    Params.Add("?ident", ident.ToString());

                    DB_VIVA.HExecuteSQLQuery($"UPDATE edi_{edi_doc_number} SET Xml_technique = ?Xml_technique, error = ?error WHERE popo_ident = ?ident AND sent = 0; ", Params);
                }

                //insert into rss_bus 850, 810 transaction
                Params.Clear();
                Params.Add("?rss_client", gRss_client);   //ALL
                Params.Add("?rss_request", gRss_request); //850P
                Params.Add("?rss_datapath", rss_datapath);//exemple path: C:\VIVAEL\DATA

                IDedi_rss = DB_RSS.HExecuteSQLNonQuery(@"INSERT INTO rss_bus.edi_rss (rss_client, rss_request, rss_datapath) VALUES (?rss_client, ?rss_request, ?rss_datapath)", Params);

                if (IDedi_rss <= 0) return;
                
                EDI_RSS.Program_RSS.EdiFilename = IDedi_rss.ToString() + $"-{gRss_request}-{gRss_client}.txt";

                Program_RSS.DisPatch_IDedi_rss();  //creer un fichier dans serveur 252
            }
            //log les queries
            DB_RSS.LogData(Status_Queries);
        }

        /**
         * Insert in the table edi_810 and edi_rss a invoice
         * Params :
         * 1. string rss_datapath : C:\VIVAEL\DATA
         * 2. int idclient : 2004
         * 3. int ident : 17703 : arinv_ident
         * 4. int edi_doc_number : 850, 810, 855, 856, etc.
         */
        public void MySQL_client(string rss_datapath, int idclient, int ident, int edi_doc_number)
        {
            vendor = new EDI_RSS.Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            //avec le datapath, on connect avec la bonne DB
            gIDataEdi_path = GetIDedi_path(rss_datapath);
            if (!vendor.Edi_path_after_Setup()) return; //setup connection DB 

            gRss_request = edi_doc_number + "P";
            gRss_client = "ALL";

            if (gRss_client != "ALL") return;
            if (gRss_request != "810P" && gRss_request != "850P" && gRss_request != "855P" && gRss_request != "856P") return;

            string portID;
            portID = "X" + IDE + "_" + edi_doc_number;

            Params.Clear();
            Params.Add("?idclient", idclient.ToString());

            //verifie si le 850 pour le vendor spécifier est a send
            List<IDataRecord> edi_arclientData = DB_RSS.HExecuteSQLQuery("SELECT * FROM rss_bus.edi_arclient WHERE idclient = ?idclient AND " + portID + " = 'send'", Params);

            //si il y a au moins un record
            if (edi_arclientData.Count != 0)
            {
                Params.Clear();
                Params.Add("?idclient", idclient.ToString());
                Params.Add("?ident", ident.ToString());

                DB_VIVA.HExecuteSQLNonQuery($"INSERT INTO edi_{edi_doc_number} (arinv_ident) " +
                                            $"SELECT ident " +
                                            $"FROM arinv " +
                                                $"WHERE   status = 'P' AND custid = ?idclient AND " +
                                                    $"ident = ?ident AND " +
                                                    $"NOT EXISTS(SELECT 1 FROM edi_{edi_doc_number} AS edi_{edi_doc_number}e WHERE edi_{edi_doc_number}e.arinv_ident = arinv.ident);" +
                                            $"ALTER TABLE edi_{edi_doc_number} AUTO_INCREMENT = 1;", Params);


                //insert into rss_bus 850, 810 transaction
                Params.Clear();
                Params.Add("?rss_client", gRss_client);   //ALL
                Params.Add("?rss_request", gRss_request); //850P
                Params.Add("?rss_datapath", rss_datapath);//exemple path: C:\VIVAEL\DATA

                IDedi_rss = DB_RSS.HExecuteSQLNonQuery(@"INSERT INTO rss_bus.edi_rss (rss_client, rss_request, rss_datapath) VALUES (?rss_client, ?rss_request, ?rss_datapath)", Params);

                if (IDedi_rss <= 0) return;

                EDI_RSS.Program_RSS.EdiFilename = IDedi_rss.ToString() + $"-{gRss_request}-{gRss_client}.txt";

                Program_RSS.DisPatch_IDedi_rss();  //creer un fichier dans serveur 252
            }
            //log les queries
            DB_RSS.LogData(Status_Queries);
        }

        public Edi855v[] SelectEdi_855v()
        {
            vendor = new EDI_RSS.Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            gIDataEdi_path = GetIDedi_path(@"C:\VivaStock2\DATA");
            if (!vendor.After_Setup(false)) return new List<Edi855v>().ToArray(); //setup connection DB

            List<IDataRecord> result = DB_VIVA.HExecuteSQLQuery("SELECT * FROM edi_855v");

            List<Edi855v> edi855V = new List<Edi855v>();
            foreach (var item in result)
            {
                edi855V.Add(new Edi855v(item));
            }

            return edi855V.ToArray();
        }

    }
}
