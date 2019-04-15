using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDICommons;
using EDI_RSS;
using System.IO;
using static EDI_DB.Data.Base;
using EDI_RSS.Helpers;
using EDICommons.Tools;
using System.Xml;
using EDI_850;

namespace EDI_RSS
{
    public partial class Program_Base
    {
        protected static Program_RSS program_rss;

        static void Main(string[] args)
        {
            try
            {
                program_rss = new Program_RSS(args);
                program_rss.Routing(args);
            }
            catch (Exception ex)
            {
                DB_RSS.LogData("ERROR: " + ex.ToString());
            }
            finally
            {
                DB_RSS.LogData(Status);
                DB_RSS.LogData(Status_Queries);
            }

        }

        public string LogEventSource = "Undefined Processor";
        
        public Dictionary<string, string> Params = new Dictionary<string, string>();

        public bool ProcessArgs(string[] args)
        {
            bool ParamsOK = args.Length >= 5;
            
            UseSystem = ParamsOK ? args[0].ToLower() : "Unknown";

            program_rss.Test();

            if (!IsLocalTest)
            { 
                TransactionCode = ParamsOK ? args[1] : "Unknown";
                PortId = ParamsOK ? args[2] : "Unknown";
                Filename = ParamsOK ? args[3].Replace(" ", "") : ""; // RSSBus is sometimes adding spaces before and after hyphens (-)
                ErrorMessage = ParamsOK ? args[4] : $"ERROR: Main(): mysql.UpdateSent() not processed: Incorrect number of arguments. Expected at least 5, got { args.Length } ";
                if(args.Length >= 6)
                {
                    Filepath = args[5];
                }
            }
            return ParamsOK;
        }
        
        public void UpdateFilename(string tablaname, string filename, string edi_ident)
        {
            Params.Clear();
            Params.Add("?filename", filename);
            Params.Add("?edi_ident", edi_ident);

            DB_RSS.LogData($"UPDATE {tablaname} SET filename = {filename} WHERE (ident+0) = {edi_ident}; " + NL + "DB_VIVA.conn.ConnectionString: " + DB_VIVA.conn.ConnectionString + NL);
            DB_VIVA.HExecuteSQLQuery(@"UPDATE " + tablaname + " SET filename = ?filename WHERE ident = ?edi_ident; ", Params);
        }

    }

    public partial class Program_RSS : Program_Base
    {
        public static string EdiFilename = "";


        public Program_RSS(string[] args)
        {
        }

        public string[] PortIds = { "ELE", "ETE", "ETI", "ETL",
                                    "MLE", "MTE", "MTI", "MTL" };

        public string PortId_code;

        private XmlNamespaceManager nsmgr;

        public bool Routing(string[] args)
        {
            LogEventSource = "EDI RSS Processor";
            ProgramId = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();

            vendor = new Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            if (!(IsProcessArgs = ProcessArgs(args))) DB_RSS.LogData(ErrorMessage, LogEventSource);
            
            //** FIRST ROUTING **//
            if (PortId.Substring(1, 1) == ":"){ return P_STEP_1(); }

            //** SECOND ROUTING **//
            if (PortId == "ET_fox_to_rss"){ return P_STEP_2(); }

            //** LAST ROUTING **//
            PortId_code = PortId.Substring(0, 3).ToUpper();
            if (PortId == PortId_code + "_routing_out" || PortId.Substring(PortId.Length - 3) == "AS2") { return RoutingOut(); }
            if (PortId == PortId_code + "_routing_in") { return RoutingIn(); }

            return false;
        }

        public bool P_STEP_1()
        {
            // 254: System Scheduler : This runs the code to insert into edi_rss the path and document to be processed
            //      The port ID will always be a path and second character is a colon (:)
            // "Live" "edi_rss" "D:\Vivael\data" "855P-ALL" "[ErrorMessage]"
            // "Test" "edi_rss" "E:\TEST_VIVA_ENV\CLIENT_ARIVA_DATA" "855P-ALL" "[ErrorMessage]"
            gIDataEdi_path = GetIDedi_path(PortId.ToString());
            if (!vendor.After_Setup(false)) return false;
            
            if (gRss_client != "ALL") return false;
            if (gRss_request != "810P" && gRss_request != "850P" && gRss_request != "855P" && gRss_request != "856P") return false;

            Params.Clear();
            Params.Add("?rss_client", gRss_client);
            Params.Add("?rss_request", gRss_request);
            Params.Add("?rss_datapath", PortId);

            IDedi_rss = DB_VIVA.HExecuteSQLNonQuery(@"INSERT INTO rss_bus.edi_rss (rss_client, rss_request, rss_datapath) VALUES (?rss_client, ?rss_request, ?rss_datapath)", Params);
            if (IDedi_rss <= 0) return false;
            EdiFilename = IDedi_rss.ToString() + $"-{gRss_request}-{gRss_client}.txt";

            DisPatch_IDedi_rss();
            
            return true;
        }
        
        public bool P_STEP_2()
        {
            // PortID: ET_fox_to_rss
            // "Test" "edi_rss" "[PortId]" "[Filename]" ""
            // Filename should contain a valid IDedi_rss
            // Foxpro: Form_cobil: Get_Bil() Creates file with IDedi_rss that it inserted in DB

            // get IDedi_rss from FileName, ID stops at first non numeric character, so extra comments can be used;
            IDedi_rss = GetFirstInt(Filename);
            gIDataEdi_path = GetIdedi_rss();

            if (!vendor.After_Setup(true)) return false;

            if (gRss_request == "855P" && gRss_client == "ALL") { new Program_855(); return ProcessStep2_After(); }
            if (gRss_request == "856P" && gRss_client == "ALL") { new Program_856(); return ProcessStep2_After(); }
            if (gRss_request == "810P" && gRss_client == "ALL") { new Program_810(); return ProcessStep2_After(); }
            if (gRss_request == "850P" && gRss_client == "ALL") { new Program_850_OUT(); return ProcessStep2_After(); }

            return false;
        }

        public bool ProcessStep2_After()
        {
            SetIDedi_RSS_done();
            return true;
        }

        public bool RoutingIn()
        {
            string path = "C:\\TMP_IN\\Westrock-MultiServices_ASN_000000008.xml";
            // Load the document and set the root element.  
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNode root = doc.DocumentElement;

            // Add the namespace for see the nodes of the xml file
            nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("ic", "http://www.rssbus.com");

            string Isa15 = root.SelectSingleNode("//ic:ISA15", nsmgr).InnerText;
            arclient_idedi = root.SelectSingleNode("//ic:ISA06", nsmgr).InnerText;
            edi_doc_number = int.Parse(root.SelectSingleNode("//ic:ST01", nsmgr).InnerText);

            if (Array.IndexOf(PortIds, PortId_code) < 0)
            {
                return vendor.After_Setup(false);
            }

            wscie = PortId_code.Substring(0, 1);
            IDE = PortId_code.Substring(1, 2);

            if (arclient_idedi == "" || (edi_doc_number != 810 && edi_doc_number != 855 && edi_doc_number != 856 && edi_doc_number != 850))
            {
                Status += "Parse error" + NL;
                DB_RSS.LogData("ERROR: File not properly formatted: " + NL + Status);
                return false;
            }

            if (edi_doc_number == 810 || edi_doc_number == 855 || edi_doc_number == 856)
            {
                Status += "Sending information out to a vendor (apsupp)" + NL;
                gIDataEdi_path = GetEdi_partner("edi_apsupp");
            }

            if (edi_doc_number == 850)
            {
                Status += "Sending information out to a buyer (arclient)" + NL;
                gIDataEdi_path = GetEdi_partner("edi_arclient");
            }

            if (!vendor.After_Setup(false))
            {
                return false;
            }

            alias = gIDataEdi_path["alias"].ToString();
            IDE_status = gIDataEdi_path["IDE_status"].ToString().ToLower();

            if (IDE_status == "send" || IDE_status == "create")
            {
                if (edi_doc_number == 850)
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.IndentChars = "\t";
                    settings.OmitXmlDeclaration = true;

                    var sw = new StringWriter();
                    using (var xw = XmlWriter.Create(sw, settings))
                    {
                        xw.WriteStartElement("root");
                        {
                            xw.WriteStartElement("Customer");
                            {
                                xw.WriteElementString("Id", "", arclient_ident.ToString());
                                int n = 1;

                                XmlNode N1Loop1 = Get_Node(root, "//N1Loop1[N1/N101 = 'ST']");
                                if (N1Loop1 != null)
                                {
                                    xw.WriteElementString("STName", "", IIF_NULL(N1Loop1, ".//N102"));

                                    if (Get_Node(N1Loop1, ".//N3") != null)
                                    {
                                        //N3
                                        foreach (XmlNode i in Get_Node(N1Loop1, ".//N3").ChildNodes)
                                        {
                                            if (i.NodeType != XmlNodeType.Comment)
                                            {
                                                xw.WriteElementString("STAddress" + n, "", i.InnerText);
                                                n++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! : N3 is missing");
                                    }

                                    if (Get_Node(N1Loop1, ".//N4") != null)
                                    {
                                        //N4
                                        string[] strWords = { "STCity", "STCountry", "STPostalCode", "STState" };
                                        n = 0;
                                        foreach (XmlNode i in Get_Node(N1Loop1, ".//N4").ChildNodes)
                                        {
                                            if (i.NodeType != XmlNodeType.Comment)
                                            {
                                                xw.WriteElementString(strWords[n], "", i.InnerText);
                                                n++;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error : N4 is missing");
                                    }
                                    xw.WriteElementString("STN103", "", IIF_NULL(N1Loop1, ".//N103"));
                                    xw.WriteElementString("STN104", "", IIF_NULL(N1Loop1, ".//N104"));
                                }
                                else
                                {
                                    xw.WriteElementString("Error", "", "Error : ST is missing");
                                }

                                N1Loop1 = Get_Node(root, "//N1Loop1[N1/N101 = 'BY']");
                                if (N1Loop1 != null)
                                {
                                    if (Get_Node(N1Loop1, ".//PER") != null)
                                    {
                                        //PER
                                        for (int i = 1; i < 9; i++)
                                        {
                                            xw.WriteElementString("PER0" + i, "", IIF_NULL(N1Loop1, ".//PER/PER0" + i));
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error : PER is missing");
                                    }
                                }
                                else
                                {
                                    xw.WriteElementString("Error", "", "Error : BY is missing");
                                }

                            }
                            xw.WriteEndElement(); //Customers

                            xw.WriteStartElement("Order");
                            {
                                //DTM01 = 004
                                xw.WriteElementString("Date", StringToDate(IIF_NULL(root, "//DTM[DTM01 = '004']/DTM02")));

                                //Number
                                xw.WriteElementString("Number", IIF_NULL(root, "//BEG/BEG03"));

                                //DTM01 = 002
                                xw.WriteElementString("RequestedShipDate", StringToDate(IIF_NULL(root, "//DTM[DTM01 = '002']/DTM02")));

                                //harcode
                                xw.WriteElementString("CreatedBy", "EDI-" + wscie + IDE);
                                xw.WriteElementString("Status", "EDI-" + wscie + IDE);
                                xw.WriteElementString("UserCode", "XEDI-" + wscie + IDE);

                                ////MSG
                                //xw.WriteElementString("MSG", IIF_NULL(root, "//N9Loop1/MTX/MSG"));

                                //items
                                int nb = 1;
                                XmlNode PO1Loop1;
                                while ((PO1Loop1 = Get_Node(root, "//PO1Loop1[" + nb + "]", false)) != null)
                                {
                                    xw.WriteStartElement("OrderItem");
                                    {
                                        xw.WriteElementString("ItemDescription", IIF_NULL(PO1Loop1, ".//PIDLoop1/PID/PID05"));
                                        xw.WriteElementString("ItemId", IIF_NULL(PO1Loop1, ".//PO1/PO109"));
                                        xw.WriteElementString("CustomerItemId", IIF_NULL(PO1Loop1, ".//PO1/PO107"));
                                        xw.WriteElementString("ItemLineId", IIF_NULL(PO1Loop1, ".//PO1/PO101"));
                                        xw.WriteElementString("ItemQuantity", IIF_NULL(PO1Loop1, ".//PO1/PO102"));
                                        xw.WriteElementString("ItemUnitOfMeasure", IIF_NULL(PO1Loop1, ".//PO1/PO103"));
                                        xw.WriteElementString("ItemRate", IIF_NULL(PO1Loop1, ".//PO1/PO104"));
                                        xw.WriteElementString("ItemUnitOfPrice", IIF_NULL(PO1Loop1, ".//PO1/PO105"));
                                        xw.WriteElementString("TimeModified", DateTime.Now.ToString().Replace(" ", "T"));
                                        xw.WriteElementString("Status", "EDI-" + wscie + IDE);
                                        xw.WriteElementString("RequestedShipDate", StringToDate(IIF_NULL(PO1Loop1, ".//DTM[DTM01 = '002']/DTM02")));
                                        nb++;
                                    }
                                    xw.WriteEndElement(); //OrderItem 
                                }
                            }
                            xw.WriteEndElement(); //Order
                        }
                        xw.WriteEndElement(); //root
                    } //xmlwriter

                    string text;
                    text = "\n";
                    text += File.ReadAllText(path, Encoding.UTF8);
                    sw.WriteLine(text);

                    XMLProcessor_850_New proc = new XMLProcessor_850_New();
                    proc.ProcessOrder(sw.ToString());
                }

                if (edi_doc_number == 810)
                {
                    XMLProcessor_810 proc810 = new XMLProcessor_810(nsmgr);
                    proc810.ProcessOrder(root, path);
                }

                if (edi_doc_number == 855)
                {
                    XMLProcessor_855 proc855 = new XMLProcessor_855(nsmgr, doc);
                    proc855.ProcessOrder(root, path);
                }

                if (edi_doc_number == 856)
                {
                    XMLProcessor_856 proc856 = new XMLProcessor_856(nsmgr, doc);
                    proc856.ProcessOrder(root, path);
                }

            } //if send or create

            return true;
        }

        public bool RoutingOut()
        {
            // If using a PortId, it should pertain to one client or supplier only
            // You will need to check the client + portid + if routing has been configured for the document type
            // Need to get type of document to see if its a arclient or apsupp
            
            if (Array.IndexOf(PortIds, PortId_code) < 0)
            {
                return vendor.After_Setup(false);
            }

            wscie = PortId_code.Substring(0, 1);
            IDE = PortId_code.Substring(1, 2);

            // Only on outgoing files that we have control overfilenames
            // Going to have to check port if its routing in or routing out

            arclient_ident = GetInt(Filename.Substring(0, 5));
            edi_doc_number = GetInt(Filename.Substring(6, 3));

            EdiProcess = "Routing Out or AS2";

            Status += "PortId: " + PortId_code + NL;
            Status += "PortId_code: " + PortId_code + NL;
            Status += "Wscie: " + wscie + NL;
            Status += "IDE: " + IDE + NL;
            Status += "Filename to be parsed: " + Filename + NL;
            Status += "arclient_ident: " + arclient_ident.ToString() + NL;
            Status += "edi_doc_number: " + edi_doc_number.ToString() + NL;

            if (arclient_ident <= 0 || (edi_doc_number != 810 && edi_doc_number != 855 && edi_doc_number != 856 && edi_doc_number != 850))
            {
                Status += "Parse error" + NL;
                DB_RSS.LogData("ERROR: File not properly formatted: " + NL + Status);
                return false;
            }

            if (edi_doc_number == 810 || edi_doc_number == 855 || edi_doc_number == 856)
            {
                Status += "Sending information out to a buyer (arclient)" + NL;
                gIDataEdi_path = GetEdi_partner("edi_arclient");
            }

            if (edi_doc_number == 850)
            {
                Status += "Sending information out to a vendor (apsupp)" + NL;
                gIDataEdi_path = GetEdi_partner("edi_apsupp");
            }

            if (!vendor.After_Setup(false))
            {
                return false;
            }

            alias = gIDataEdi_path["alias"].ToString();
            IDE_status = gIDataEdi_path["IDE_status"].ToString().ToLower();

            if (IDE_status == "send" || IDE_status == "create")
            {
                string FileContents = "Empty";

                DB_RSS.LogData("Filepath : " + Filepath + NL);

                using (StreamReader sr = File.OpenText(Filepath)) { FileContents = sr.ReadToEnd(); }

                if (PortId == PortId_code + "_routing_out" && IDE_status == "send")
                {
                    DB_RSS.LogData($"Sending: file to port {wscie}{IDE}_{alias}_AS2 " + NL + "FileName: " + Filename + NL + FileContents);
                    SetRouting_out_path("AS2");
                    File.Copy(Filepath, Path.Combine(RSS_send_path, Filename));

                }
                else if (PortId.Substring(PortId.Length - 3) == "AS2")
                {
                    Status += "ErrorMessage: " + ErrorMessage + NL;
                    if (ErrorMessage == "")
                    {
                        UpdateSent("edi_" + edi_doc_number, Filename);
                    }
                    else
                    {
                        DB_RSS.LogData($"ErrorMessage: " + ErrorMessage + NL);
                    }
                }
            }

            return true;
        }

        public void UpdateSent(string table, string pFilename)
        {
            if (table != "edi_855" && table != "edi_810" && table != "edi_856" && table != "edi_850")
            {
                DB_RSS.LogData($"ERROR: DB_RSS(): UpdateSent: Abort: Table not found {table} (Filename: {pFilename})");
                return;
            }

            Params.Clear();
            Params.Add("?Filename", pFilename);
            DB_VIVA.HExecuteSQLQuery(@"UPDATE " + table + " SET sent = true WHERE LOCATE(Filename, ?Filename); ", Params);
        }

        public void DisPatch_IDedi_rss()
        {
            if (EdiFilename != "")
            {
                if (UseSystem == "local")
                {
                    System.IO.File.WriteAllText(@"C:\TMP\edi_test\" + EdiFilename, $"EDI processing: using {IDedi_rss.ToString()} as IDedi_rss");
                }
                else
                {
                    System.IO.File.WriteAllText(@"\\192.168.1.252\edi_test\" + EdiFilename, $"EDI processing: using {IDedi_rss.ToString()} as IDedi_rss");
                }
            }
        }
        
        public IDataRecord GetIdedi_rss()
        {
            List<IDataRecord> results;

            Params.Clear();
            Params.Add("?IDedi_rss", IDedi_rss.ToString());
            
            results = DB_RSS.HExecuteSQLQuery(@"SELECT * FROM edi_rss LEFT JOIN rss_bus.edi_path ON edi_path.edi_path = edi_rss.rss_datapath WHERE rss_done = 0 AND IDedi_rss = ?IDedi_rss", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            IDataRecord result = results[0];

            return result;
        }

        public void SetIDedi_RSS_done()
        {
            Params.Add("?rss_status", Status);
            Params.Add("?rss_error", Error);

            DB_RSS.HExecuteSQLQuery(@" UPDATE rss_bus.edi_rss SET 
                                                    rss_done = 1, 
                                                    rss_status = ?rss_status, 
                                                    rss_error = ?rss_error      
                                            WHERE IDedi_rss = ?IDedi_rss", Params);
        }
        
        public void SetParams(string TheUseSystem, string TheTransactionCode, string ThePortId, string TheFilename, string TheErrorMessage)
        {
            // Overrides Parameters
            UseSystem = TheUseSystem.ToLower();
            TransactionCode = TheTransactionCode;
            PortId = ThePortId;
            Filename = TheFilename;
            ErrorMessage = TheErrorMessage;
        }

        public int GetFirstInt(string text)
        {
            string retVal = "0";

            foreach (char c in text)
            {
                if (!char.IsDigit(c)) return int.Parse(retVal);
                retVal += c;
            }
            return int.Parse(retVal);
        }

        /**
         * return a xml node with the namespace in the xpath
         */
        public XmlNode Get_Node(XmlNode node, string xpath, bool isBrackets = true)
        {
            xpath = xpath.Replace("/", "/ic:");
            xpath = xpath.Replace("/ic:/ic:", "//ic:");
            if (isBrackets)
                xpath = xpath.Replace("[", "[ic:");

            return node.SelectSingleNode(xpath, nsmgr);
        }

        /**
         * return the value of a xml node if is not null
         */
        public string IIF_NULL(XmlNode node, string xpath, string nullValue = "")
        {
            if (Get_Node(node, xpath) == null)
            {
                return nullValue;
            }

            return Get_Node(node, xpath).InnerText;
        }

        /**
         * return a string date in the format : yyyy-MM-dd
         */
        public string StringToDate(string date)
        {
            string year = date.Substring(0, 4);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);

            string outputDate = year + "-" + month + "-" + day;

            return outputDate;
        }
    }
}