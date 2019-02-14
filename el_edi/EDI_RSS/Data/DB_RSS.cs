using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDICommons;
using static EDI_DB.Data.Base;
using EDI_RSS.Helpers;

namespace EDI_RSS
{
    public partial class Program_RSS : Program_Base
    {
        public void ProcessRSS()
        {
            if (TransactionCode == "edi_rss")
            {
                if (ProcessStep1()) return;
                if (ProcessStep2()) return;
            }
            else if (ErrorMessage == "")
            {
                if (ProcessStep3()) return;
            }

            // Nothing has been processed
            DB_RSS.LogData($"ERROR: Main(): ProcessRSS() not processed: TransactionCode ({TransactionCode}) not recognized: UseSystem {UseSystem} TransactionCode {TransactionCode} PortId {PortId} Filename {Filename} ErrorMessage {ErrorMessage}", LogEventSource);

        }

        public bool ProcessStep1()
        {
            if (Filename == "855P-ALL") { P_STEP_1("ALL", "855P"); return true; }
            if (Filename == "810P-ALL") { P_STEP_1("ALL", "810P"); return true; }
            if (Filename == "856P-ALL") { P_STEP_1("ALL", "856P"); return true; }
            if (Filename == "850P-ALL") { P_STEP_1("ALL", "850P"); return true; }
            return false;
        }

        public bool ProcessStep2()
        {
            if (gDataIDedi_rss == null) return false;

            if (gDataIDedi_rss["rss_request"].ToString() == "855P" &&
                gDataIDedi_rss["rss_client"].ToString() == "ALL") { new Program_855(); SetIDedi_RSS_done(); DB_RSS.LogData(Status); return true; }

            if (gDataIDedi_rss["rss_request"].ToString() == "856P" &&
                gDataIDedi_rss["rss_client"].ToString() == "ALL") { new Program_856(); SetIDedi_RSS_done(); DB_RSS.LogData(Status); return true; }

            if (gDataIDedi_rss["rss_request"].ToString() == "810P" &&
                gDataIDedi_rss["rss_client"].ToString() == "ALL") { new Program_810(); SetIDedi_RSS_done(); DB_RSS.LogData(Status); return true; }

            if (gDataIDedi_rss["rss_request"].ToString() == "850P" &&
                gDataIDedi_rss["rss_client"].ToString() == "ALL") { new Program_850(); SetIDedi_RSS_done(); DB_RSS.LogData(Status); return true; }


            return false;
        }

        public bool ProcessStep3()
        {
            if (TransactionCode == "855" && ErrorMessage == "") { P_STEP_3("edi_855"); return true; }
            if (TransactionCode == "810" && ErrorMessage == "") { P_STEP_3("edi_810"); return true; }
            if (TransactionCode == "856" && ErrorMessage == "") { P_STEP_3("edi_856"); return true; }
            if (TransactionCode == "850" && ErrorMessage == "") { P_STEP_3("edi_850"); return true; }
            return false;
        }

        // Usually setup
        public void P_STEP_1(string rss_client, string rss_request)
        {
            Params.Clear();
            Params.Add("?rss_client", rss_client);
            Params.Add("?rss_request", rss_request);
            Params.Add("?rss_datapath", PortId);

            IDedi_rss = DB_VIVA.HExecuteSQLNonQuery(@"INSERT INTO rss_bus.edi_rss (rss_client, rss_request, rss_datapath) VALUES (?rss_client, ?rss_request, ?rss_datapath)", Params);
            if (IDedi_rss <= 0) return;
            EdiFilename = IDedi_rss.ToString() + $"-{rss_request}-{rss_client}.txt";

            DisPatch_IDedi_rss();

            DB_RSS.LogData(Status);
        }
        
        public void P_STEP_3(string Tablename)
        {
            Status += $"Main(): UseSystem {UseSystem} TransactionCode {TransactionCode} PortId {PortId} Filename {Filename} Tablename {Tablename} ErrorMessage {ErrorMessage}";
            UpdateSent(Tablename, Filename);
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
            DB_VIVA.HExecuteSQLQuery (@"UPDATE " + table + " SET sent = true WHERE LOCATE(Filename, ?Filename); ", Params);
        }
    }

}
