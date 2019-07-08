using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
         * 2. int id : 56 idvendor ou 30037 pour clientid or custid
         * 3. int ident : 17703 : popo_ident or arinv_ident or cobil_ident
         * 4. int edi_doc_number : 850
         * 5. string Xml_technique : le technique de chaque item dans un po
         * 6. string error : indique s'il manque des données dans le technique ou autres (optional)
         */
        public string MySQL(string rss_datapath, int id, int ident, int edi_doc_number, string Xml_technique = "", string error = "")
        {
            try
            {
                vendor = new EDI_RSS.Vendor();
                DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

                Status += $"datapath: {rss_datapath + NL}";

                //avec le datapath, on connect avec la bonne DB
                gIDataEdi_path = GetIDedi_path(rss_datapath);
                if (!vendor.Edi_path_after_Setup()) return "Erreur connection"; //setup connection DB 

                string portID;
                portID = "X" + IDE + "_" + edi_doc_number; //X LE _ 850

                Params.Clear();
                Params.Add("?id", id.ToString());

                List<IDataRecord> edi_Data = null;
                string tablename = "";
                string fieldname_id = "";
                string status = "";

                if (edi_doc_number == 850)
                {
                    //verifie si le 850 pour le vendor spécifié est a send
                    edi_Data = DB_RSS.HExecuteSQLQuery("SELECT * FROM rss_bus.edi_apsupp WHERE idvendor = ?id AND (" + portID + " = 'send' OR " + portID + " = 'create')", Params);
                    tablename = "popo";
                    fieldname_id = "IDVENDOR";

                    if (IDE.Substring(0, 1) == "L")
                        status = "(status = 'L' OR status = 'O' OR status = 'N')"; // for live
                    else if (IDE.Substring(0, 1) == "T")
                        status = "(status = 'L' OR status = 'O' OR status = 'N' OR status = 'R')"; // for testing 
                    else
                        status = "(status = 'L' OR status = 'O' OR status = 'N' OR status = 'R')"; // for testing local
                }
                else if (edi_doc_number == 810 || edi_doc_number == 856)
                {
                    //verifie si le 810 ou 856 pour le client spécifier est a send
                    edi_Data = DB_RSS.HExecuteSQLQuery("SELECT * FROM rss_bus.edi_arclient WHERE idclient = ?id AND (" + portID + " = 'send' OR " + portID + " = 'create')", Params);

                    if (edi_doc_number == 810)
                    {
                        tablename = "arinv";
                        fieldname_id = "CUSTID";
                        status = "status = 'P'";
                    }
                    else
                    {
                        tablename = "cobil";
                        fieldname_id = "CLIENTID";
                        status = "STATUT = 'C'";
                    }

                }

                //s'il y a au moins un record
                if (edi_Data.Count != 0)
                {
                    Params.Clear();
                    Params.Add("?ident", ident.ToString());

                    List<IDataRecord> result = DB_VIVA.HExecuteSQLQuery($"SELECT * FROM {tablename} WHERE ident = ?ident AND {status}", Params);

                    if (result.Count < 0) //if we have zero result
                    {
                        DB_RSS.LogData("Status do not correspond : " + status);
                        return "";
                    }

                    Params.Clear();
                    Params.Add("?id", id.ToString());
                    Params.Add("?ident", ident.ToString());

                    DB_VIVA.HExecuteSQLNonQuery($"INSERT INTO edi_{edi_doc_number} ({tablename}_ident) " +
                                                $"SELECT ident " +
                                                $"FROM {tablename} " +
                                                    $"WHERE {status} AND {fieldname_id} = ?id AND " +
                                                        $"ident = ?ident AND " +
                                                        $"NOT EXISTS(SELECT 1 FROM edi_{edi_doc_number} AS edi_{edi_doc_number}e WHERE edi_{edi_doc_number}e.{tablename}_ident = {tablename}.ident);" +
                                                $"ALTER TABLE edi_{edi_doc_number} AUTO_INCREMENT = 1;", Params);

                    if (edi_doc_number == 856)
                    {
                        //update pour mettre le ship date
                        System.DateTime dte_now = System.DateTime.Now;

                        Params.Clear();
                        Params.Add("?dte_now", dte_now.ToString());
                        Params.Add("?ident", ident.ToString());

                        DB_VIVA.HExecuteSQLQuery($"UPDATE edi_856 SET Ship_date = ?dte_now WHERE cobil_ident = ?ident;", Params);
                    }

                    if (Xml_technique != "") //if we have techniques 
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

                        //update edi_{850} with Xml_technique and error
                        Params.Clear();
                        Params.Add("?Xml_technique", Xml_technique);
                        Params.Add("?error", error);
                        Params.Add("?ident", ident.ToString());

                        DB_VIVA.HExecuteSQLQuery($"UPDATE edi_{edi_doc_number} SET Xml_technique = ?Xml_technique, error = ?error WHERE {tablename}_ident = ?ident AND sent = 0; ", Params);
                    }

                    //rss_bus has access to the document
                    DispatchEdi_rss(rss_datapath, edi_doc_number);
                }
                //log les queries
                DB_RSS.LogData(Status_Queries);
                //clear the logs for keep one queries per execution
                Status_Queries = "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return "SUCCESS";
        }

        public string Get_DB_VIVA(string rss_datapath, string default_value = "")
        {
            vendor = new EDI_RSS.Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            Status += $"datapath: {rss_datapath + NL}";

            //avec le datapath, on connect avec la bonne DB
            gIDataEdi_path = GetIDedi_path(rss_datapath);

            if (gIDataEdi_path == null) return default_value; //setup connection DB 

            return gIDataEdi_path["edi_db_viva"].ToString(); 
        }

        public void DispatchEdi_rss(string rss_datapath, int edi_doc_number)
        {
            vendor = new EDI_RSS.Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            Status += $"datapath: {rss_datapath + NL}";

            //avec le datapath, on connect avec la bonne DB
            gIDataEdi_path = GetIDedi_path(rss_datapath);
            if (!vendor.Edi_path_after_Setup()) return; //setup connection DB 

            gRss_request = edi_doc_number + "P";
            gRss_client = "ALL";

            if (gRss_client != "ALL") return;
            if (gRss_request != "810P" && gRss_request != "850P" && gRss_request != "855P" && gRss_request != "856P") return;

            //insert into rss_bus 850, 810 transaction
            Params.Clear();
            Params.Add("?rss_client", gRss_client);   //ALL
            Params.Add("?rss_request", gRss_request); //850P
            Params.Add("?rss_datapath", rss_datapath);//exemple path: C:\VIVAEL\DATA

            IDedi_rss = DB_RSS.HExecuteSQLNonQuery(@"INSERT INTO rss_bus.edi_rss (rss_client, rss_request, rss_datapath) VALUES (?rss_client, ?rss_request, ?rss_datapath)", Params);

            if (IDedi_rss <= 0) return;

            EDI_RSS.Program_RSS.EdiFilename = IDedi_rss.ToString() + $"-{gRss_request}-{gRss_client}.txt";

            if(rss_datapath.ToUpper() == @"C:\VIVAEL\DATA".ToUpper() || rss_datapath.ToUpper() == @"C:\VivaStock2\DATA".ToUpper())
            {
                UseSystem = "local";
            }
            Program_RSS.DisPatch_IDedi_rss();  //creer un fichier dans serveur 252
        }

        /**
         * Insert in the table edi_855
         */
        public void InsertEdi_855(string rss_datapath, int idclient, int ident, int edi_doc_number)
        {
            vendor = new EDI_RSS.Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            Status += $"datapath: {rss_datapath + NL}";

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

            //verifie si le 855 pour le client spécifier est a send
            List<IDataRecord> edi_arclientData = DB_RSS.HExecuteSQLQuery($"SELECT * FROM rss_bus.edi_arclient WHERE idclient = ?idclient AND ({portID} = 'send' OR {portID} = 'create')", Params);

            //si il y a au moins un record
            if (edi_arclientData.Count != 0)
            {
                Params.Clear();
                Params.Add("?idclient", idclient.ToString());
                Params.Add("?ident", ident.ToString());

                DB_VIVA.HExecuteSQLNonQuery($@"INSERT INTO edi_{edi_doc_number} (IdCocom, Status, Validator)
                                            SELECT ident, 'N', ''
                                           FROM cocom 
                                                WHERE status = 'N' AND clientid = ?idclient AND 
                                                    ident = ?ident AND
                                                   NOT EXISTS(SELECT 1 FROM edi_{edi_doc_number} AS edi_{edi_doc_number}e WHERE edi_{edi_doc_number}e.IdCocom = cocom.ident);
                                           ALTER TABLE edi_{edi_doc_number} AUTO_INCREMENT = 1;", Params);

            }
            //log les queries
            DB_RSS.LogData(Status_Queries);
            //clear the logs for keep one queries per execution
            Status_Queries = ""; 
        }

        public string GetStatut(string rss_datapath)
        {
            rss_datapath.Replace(@"\\", @"\");

            string lStatut = "(statut = 'W' OR statut = 'E')";

            vendor = new EDI_RSS.Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            Status += $"datapath: {rss_datapath + NL}";

            gIDataEdi_path = GetIDedi_path(rss_datapath);
            if (!vendor.Edi_path_after_Setup()) return ""; //setup connection DB 

            Params.Clear();
            Params.Add("?edi_path", rss_datapath.ToString());

            List<IDataRecord> result = DB_RSS.HExecuteSQLQuery("SELECT edi_code FROM rss_bus.edi_path WHERE edi_path = ?edi_path", Params);

            if(result.Count > 0)
            {
                lStatut = "(statut = 'W' OR statut = 'EDI-" + result[0]["edi_code"].ToString() + "')";
            }
            return lStatut;
        }

        //public Edi855v[] SelectEdi_855v()
        //{
        //    vendor = new EDI_RSS.Vendor();
        //    DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

        //    gIDataEdi_path = GetIDedi_path(@"C:\VivaStock2\DATA");
        //    if (!vendor.Edi_path_after_Setup()) return new List<Edi855v>().ToArray(); //setup connection DB

        //    List<IDataRecord> result = DB_VIVA.HExecuteSQLQuery("SELECT * FROM edi_855v");

        //    List<Edi855v> edi855V = new List<Edi855v>();
        //    foreach (var item in result)
        //    {
        //        edi855V.Add(new Edi855v(item));
        //    }

        //    return edi855V.ToArray();
        //}

    }
}
