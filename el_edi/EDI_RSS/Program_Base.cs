using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public partial class Program_Base
    {
        protected static Program_RSS program_rss;

        static void Main(string[] args)
        {
            try
            {
                program_rss = new Program_RSS();
                program_rss.Setup(args);

                if (!IsProcessArgs) return;

                program_rss.ProcessRSS();

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

            ProcessVendor();

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

        public void ProcessVendor()
        {
            vendor = new Vendor();
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

    public partial class Program_RSS
    {
        public static string EdiFilename = "";


        public Program_RSS()
        {
        }

        public string[] PortIds = { "ELE", "ETE", "ETI", "ETL",
                                    "MLE", "MTE", "MTI", "MTL" };

        public string PortId_code;

        public void Setup(string[] args)
        {
            LogEventSource = "EDI RSS Processor";
            ProgramId = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();

            if (!(IsProcessArgs = ProcessArgs(args))) DB_RSS.LogData(ErrorMessage, LogEventSource);

            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            // If using a PortId, it should pertain to one client or supplier only
            // You will need to check the client + portid + if routing has been configured for the document type
            // Need to get type of document to see if its a arclient or apsupp
            PortId_code = PortId.Substring(0, 3).ToUpper();
            if (Array.IndexOf(PortIds, PortId_code) >= 0)
            {
                wscie = PortId_code.Substring(0, 1);
                IDE = PortId_code.Substring(1, 2);

                if (PortId == PortId_code + "_routing_out" || PortId.Substring(PortId.Length-3) == "AS2")
                {
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

                    if (arclient_ident <= 0 || edi_doc_number <= 0)
                    {
                        Status += "Parse error" + NL;
                        DB_RSS.LogData("ERROR: File not properly formatted: " + NL + Status);
                        return;
                    }
                    
                    if (edi_doc_number == 810 || edi_doc_number == 855 || edi_doc_number == 856) // we are sending information out to a buyer (arclient)
                    {
                        Status += "Sending information out to a buyer (arclient)" + NL;
                        gDataIDedi_path = GetEdi_arclient();
                        if(gDataIDedi_path != null)
                        {
                            alias = gDataIDedi_path["alias"].ToString();
                            IDE_status = gDataIDedi_path["IDE_status"].ToString().ToLower();
                            EdiPath = gDataIDedi_path["IDE_path"].ToString().ToLower();
                        }

                        if(IDE_status == "send" || IDE_status == "create")
                        {
                            string FileContents = "Empty";
                            
                            SetRouting_out_path("routing_out");
                            // Open the stream and read it back.

                            DB_RSS.LogData("Filepath : " + Filepath + NL);

                            using (StreamReader sr = File.OpenText(Filepath)){ FileContents = sr.ReadToEnd(); }

                            if (PortId == PortId_code + "_routing_out" && IDE_status == "send")
                            {
                                DB_RSS.LogData($"Sending: file to port {wscie}{IDE}_{alias}_AS2 " + NL + "FileName: " + Filename + NL + FileContents);
                                SetRouting_out_path("AS2");
                                File.Copy(Filepath, Path.Combine(RSS_send_path, Filename));

                            }
                            else
                            {
                                vendor.After_Setup();
                                Status += "ErrorMessage: " + ErrorMessage + NL;
                                if (ErrorMessage == "")
                                {
                                    UpdateSent("edi_855", Filename);
                                }
                                else
                                {
                                    DB_RSS.LogData($"ErrorMessage: " + ErrorMessage + NL);
                                }
                            }

                        }
                    }

                    if (edi_doc_number == 850) // we are sending information out to a vendor (apsupp)
                    {
                        Status += "Sending information out to a vendor (apsupp)" + NL;
                    }

                    if(gDataIDedi_path == null)
                    {
                        DB_RSS.LogData("ERROR: Could not get routing information : " + NL + Status);
                    }
                }
                else
                {
                    DB_RSS.LogData("ERROR: Port not configured: " + NL + Status);
                }
            }
            else
            {
                // General call to edi_rss
                PortId_code = "";
                SetIDedi_rss();
            }

            vendor.After_Setup();
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

        public IDataRecord GetIDedi_path(string edi_path)
        {
            List<IDataRecord> results;

            Params.Clear();
            Params.Add("?edi_path", edi_path);

            results = DB_RSS.HExecuteSQLQuery(@"SELECT * FROM edi_path WHERE edi_path = ?edi_path", Params);

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

        public void SetIDedi_rss()
        {
            // get IDedi_rss from FileName, ID stops at first non numeric character, so extra comments can be used;
            // get rss_request + other info in table for dispatching
            // do a MySQL query based on the ID in FileName
            IDedi_rss = GetFirstInt(Filename);
            gDataIDedi_path = GetIDedi_path(PortId.ToString());
            if (gDataIDedi_path == null)
            {
                gDataIDedi_rss = GetIdedi_rss();
                wscie = gDataIDedi_rss["edi_code"].ToString().Substring(0, 1);
                IDE = gDataIDedi_rss["edi_code"].ToString().Substring(1, 2);
            }
            else
            {
                wscie = gDataIDedi_path["edi_code"].ToString().Substring(0, 1);
                IDE = gDataIDedi_path["edi_code"].ToString().Substring(1, 2);
            }
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

    }
}