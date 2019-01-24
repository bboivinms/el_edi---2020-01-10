using System.Collections.Generic;
using System.Data;
using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public partial class Program_Base
    {
        protected static Program_RSS program_rss;

        static void Main(string[] args)
        {
            program_rss = new Program_RSS();
            program_rss.Setup(args);

            if (!IsProcessArgs) return;

            program_rss.ProcessRSS();
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
            }
            return ParamsOK;
        }

        public void ProcessVendor()
        {
            vendor = new Vendor_EL();
        }

        public void UpdateFilename(string tablaname, string filename, string edi_ident)
        {
            Params.Clear();
            Params.Add("?filename", filename);
            Params.Add("?edi_ident", edi_ident);

            DB_VIVA.HExecuteSQLNonQuery(@"UPDATE " + tablaname + " SET filename = ?filename WHERE ident = ?edi_ident; ", Params);
        }
    }

    public partial class Program_RSS
    {
        public static string EdiFilename = "";


        public Program_RSS()
        {
        }

        public void Setup(string[] args)
        {
            LogEventSource = "EDI RSS Processor";

            if (!(IsProcessArgs = ProcessArgs(args))) DB_Logger.LogData(ErrorMessage, LogEventSource);

            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));
            SetIDedi_rss();
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

            Params.Add("?IDedi_rss", IDedi_rss.ToString());
            //Enlever "(OR rss_done = 1)"
            results = DB_RSS.HExecuteSQLQuery(@"SELECT * FROM edi_rss LEFT JOIN rss_bus.edi_path ON edi_path.edi_path = edi_rss.rss_datapath WHERE (rss_done = 0 OR rss_done = 1) AND IDedi_rss = ?IDedi_rss", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            IDataRecord result = results[0];

            return result;
        }

        public void SetIDedi_RSS_done()
        {
            Params.Add("?rss_status", Status);
            Params.Add("?rss_error", Error);

            DB_RSS.HExecuteSQLQuery(@"  UPDATE rss_bus.edi_rss SET 
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
            gDataIDedi_rss = GetIdedi_rss();
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