using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDICommons;
using static EDI_DB.Data.Base;

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
            else if (TransactionCode == "855" && ErrorMessage == "")
            {
                if (ProcessStep3()) return;
            }

            // Nothing has been processed
            DB_Logger.LogData($"ERROR: Main(): ProcessRSS() not processed: TransactionCode ({TransactionCode}) not recognized: UseSystem {UseSystem} TransactionCode {TransactionCode} PortId {PortId} Filename {Filename} ErrorMessage {ErrorMessage}", LogEventSource);

        }

        public bool ProcessStep1()
        {
            if (Filename == "855P-ALL") { P_STEP_1("ALL", "855P"); return true; }
            if (Filename == "810P-ALL") { P_STEP_1("ALL", "810P"); return true; }
            return false;
        }

        public bool ProcessStep2()
        {
            if (gDataIDedi_rss == null) return false;

            if (gDataIDedi_rss["rss_request"].ToString() == "855P" &&
                gDataIDedi_rss["rss_client"].ToString() == "ALL") { Setup_RSS_send_path(gDataIDedi_rss["855_port"].ToString()); new Program_855(); SetIDedi_RSS_done(); return true; }

            if (gDataIDedi_rss["rss_request"].ToString() == "810P" &&
                gDataIDedi_rss["rss_client"].ToString() == "ALL") { Setup_RSS_send_path(gDataIDedi_rss["810_port"].ToString()); new Program_810(); SetIDedi_RSS_done(); return true; }

            return false;
        }

        public bool ProcessStep3()
        {
            if (TransactionCode == "855" && ErrorMessage == "") { P_STEP_3("edi_855"); return true; }
            if (TransactionCode == "810" && ErrorMessage == "") { P_STEP_3("edi_810"); return true; }
            return false;
        }

        public void P_STEP_1(string rss_client, string rss_request)
        {
            Params.Clear();
            Params.Add("?rss_client", rss_client);
            Params.Add("?rss_request", rss_request);

            IDedi_rss = DB_VIVA.HExecuteSQLNonQuery(@"INSERT INTO rss_bus.edi_rss (rss_client, rss_request) VALUES (?rss_client, ?rss_request)", Params);
            if (IDedi_rss <= 0) return;
            EdiFilename = IDedi_rss.ToString() + $"-{rss_request}-{rss_client}.txt";

            DisPatch_IDedi_rss();
        }
        
        public void P_STEP_3(string Tablename)
        {
            DB_Logger.LogData($"Main(): UseSystem {UseSystem} TransactionCode {TransactionCode} PortId {PortId} Filename {Filename} Tablename {Tablename} ErrorMessage {ErrorMessage}", LogEventSource);
            UpdateSent(Tablename, Filename);
        }

        public void UpdateSent(string table, string filename)
        {
            // DBLogger.LogData($"DB_RSS(): UpdateSent: Using table: {table} and filename: {filename}", Program_RSS.LogEventSource);

            if (table != "edi_855" && table != "edi_810")
            {
                DB_Logger.LogData($"ERROR: DB_RSS(): UpdateSent: Abort: Table not found {table} (filename: {filename})", LogEventSource);
                return;
            }

            MySqlCommand cmd = DB_VIVA.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"UPDATE " + table + " SET sent = true WHERE LOCATE(Filename,?Filename); ";

            cmd.Parameters.AddWithValue("?filename", filename);

            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
            }
        }
    }

}
