using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDI_DB.Data;
using static EDI_DB.Data.Base;
using EDI_RSS;

namespace EDI_DB.Data
{
    static public class Base
    {
        // Expected parameters placeholders
        public static bool IsProcessArgs = false;
        public static string UseSystem = "";
        public static string TransactionCode = "";
        public static string PortId = "";
        public static string Filename = "";
        public static string ErrorMessage = "";
        // End

        public static Vendor vendor;
        
        public static string RSS_send_path = "";
        public static string NL = "\r\n";
        public static string Status = "";
        public static string Error = "";

        public static CDB_Logger DB_Logger;
        public static CDB_VIVA DB_VIVA;
        public static CDB_WEB DB_WEB;

        public static int arclient_ident;
        public static string arclient_short_name;
        public static long IDedi_rss = 0;

        public static bool TimePassed(int hour, int minute)
        {
            if (hour < 0 || hour > 24) hour = 0;
            if (minute < 0 || minute > 60) minute = 0;

            return TimeSpan.Compare(DateTime.Now.TimeOfDay, DateTime.Parse($"2010/01/01 {hour}:{minute}:00.000").TimeOfDay) > 0;
        }

        public static void SetupClient(int pArclient_ident)
        {
            arclient_ident = pArclient_ident;
            arclient_short_name = "";

            if (arclient_ident == 30037) arclient_short_name = "ariva";

            // Using test only for live and tests
            RSS_send_path = "";
            if(TransactionCode == "855" || TransactionCode == "810")
            {
                if (UseSystem == "live") { RSS_send_path = $@"C:\Program Files\RSSBus\RSSBus Connect\data_test\envl\ET_{arclient_short_name}\ET_{arclient_short_name}_xml_x12_{TransactionCode}_rss\Send"; }
                if (UseSystem == "local") { RSS_send_path = @"C:\TMP"; }
                else { RSS_send_path = $@"C:\Program Files\RSSBus\RSSBus Connect\data_test\envl\ET_{arclient_short_name}\ET_{arclient_short_name}_xml_x12_{TransactionCode}_rss\Send"; }
                Status += "RSS_send_path: " + RSS_send_path + NL;
            }
        }

        public static string IIF_LIVE(string IfLive, string IfTest)
        {
            if (UseSystem == "live") return IfLive;
            return IfTest;
        }

        public static string ToAlphaNumeric(string str)
        {
            char[] arr = str.Where(c => (char.IsLetterOrDigit(c) ||
                             char.IsWhiteSpace(c) ||
                             c == '-')).ToArray();

            return new string(arr);
        }

        public static decimal GetDecimal(object value)
        {
            decimal retval = 0;

            if (value == null) return 0;
            if (value == DBNull.Value) return 0;
            try
            {
                retval = Convert.ToDecimal(value.ToString());
            }
            catch
            {
            }
            return retval;
        }

        public static DateTime SkipWeekendsAndHolidays(DateTime TheDate)
        {
            // KJ: 2018-11-05: Check ActualShipDate, ensure not on Saturday or Sunday
            // KJ: 2018-11-05: TODO: Also exclude vacation days
            if (TheDate.DayOfWeek == DayOfWeek.Saturday) TheDate = TheDate.AddDays(2);
            if (TheDate.DayOfWeek == DayOfWeek.Sunday) TheDate = TheDate.AddDays(1);

            return TheDate;
        }

    }

    public class DB_Parent
    {
        public Dictionary<string, string> Params { get; set; }

        public MySqlConnection conn { get; set; }

        public MySqlTransaction BeginTransaction() { return conn.BeginTransaction(); }

        public MySqlCommand CreateCommand() { return conn.CreateCommand(); }

        public void Open() { conn.Open(); }

        public void Close() { conn.Close(); }

    }

    public class CDB_Logger : DB_Parent
    {
        public CDB_Logger(string Connection)
        {
            conn = new MySqlConnection(Connection);
        }

        public void LogData(string message, string mysql_type = "EDI_LogData")
        {
            MySqlCommand cmd = CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"INSERT INTO mysql_log (mysql_log, mysql_type) VALUES (?mysql_log, ?mysql_type); ";

            cmd.Parameters.AddWithValue("?mysql_log" , message);
            cmd.Parameters.AddWithValue("?mysql_type", mysql_type);

            try
            {
                Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
        }
    }

    public class CDB_WEB : DB_Parent
    {
        public CDB_WEB(string Connection)
        {
            conn = new MySqlConnection(Connection);
        }
    }

    public class CDB_VIVA : DB_Parent
    {
        
        public CDB_VIVA(string Connection)
        {
            conn = new MySqlConnection(Connection);
        }

        public long HExecuteSQLNonQuery(string slpMySQLQuery, Dictionary<string, string> Params = null)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = slpMySQLQuery;
            
            try
            {
                if (Params != null)
                {
                    foreach (KeyValuePair<string, string> Param in Params)
                    {
                        cmd.Parameters.AddWithValue(Param.Key, Param.Value);
                    }
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                conn.Close();
                return 0;
            }
            finally
            {
                conn.Close();
            }

            // WIP
            return cmd.LastInsertedId;
        }

        public List<IDataRecord> HExecuteSQLQuery(string slpMySQLQuery, Dictionary<string, string> Params = null)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = slpMySQLQuery;

            List<IDataRecord> sdPCursor = null;

            try
            {
                if (Params != null)
                {
                    foreach (KeyValuePair<string, string> Param in Params)
                    {
                        cmd.Parameters.AddWithValue(Param.Key, Param.Value);
                    }
                }

                conn.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                sdPCursor = rd.Cast<IDataRecord>().ToList();
            }
            catch
            {
                conn.Close();
                return null;
            }
            finally
            {
                conn.Close();
            }

            // WIP
            return sdPCursor;
        }

        public IDataRecord GetAddressBT(int arclient_ident)
        {
            List<IDataRecord> results;
            Params.Clear();
            Params.Add("arclient_ident", "arclient_ident");

            results = HExecuteSQLQuery(@"
                SELECT 
                    CONCAT('4', CAST(ident AS CHAR)) AS iddel_addr,
                    Name,
                    Code,
                    CONCAT(addr1, '\n', city, '(', state, ')\n', zip, '\n', country, '\n', tel1) AS Address
                FROM arclient 
                WHERE ident = ?arclient_ident", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            return results[0];
        }

        public IDataRecord GetAddressST(int arclient_ident, string pZip)
        {
            pZip = pZip.ToUpper().Replace(" ", "");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT * FROM (
                                (SELECT CONCAT('4', CAST(ident AS CHAR)) AS iddel_addr, 2 AS myorder, ident, name, CONCAT(name, ' ', addr1, ' ', city) AS adresse,
					                    addr1, addr2, city, state, zip, country
					                FROM arclient WHERE ident=?arclient_ident)
	                                UNION ALL 
	                            (SELECT CONCAT('1', CAST(ident AS CHAR)) AS iddel_addr, 1 AS myorder, cliid as ident, name, CONCAT(name, ' ', addr1, ' ', city) AS adresse,
					                    addr1, addr2, city, state, zip, country
					                FROM ffaddr   WHERE cliid=?arclient_ident)) AS ffaddr_union
                                WHERE REPLACE(zip, ' ', '') = ?pZip
                                ORDER BY myorder
                                ";

            /* // references to arcliass is currently not used
	                    UNION ALL 
                        (SELECT CONCAT('2', CAST(arclient.ident AS CHAR)) AS iddel_addr, 2 AS myorder, arclient.ident, name, CONCAT('as: ', name, ' ', addr1, ' ', city) as adresse,
					                     addr1, addr2, city, state, zip, country
					                     FROM arcliass INNER JOIN arclient ON arcliass.idarclient_as = arclient.ident
					                     WHERE arcliass.idarclient=?arclient_ident)
	                     UNION ALL 
	                    (SELECT CONCAT('3', CAST(ffaddr.ident AS CHAR)) AS iddel_addr, 2 AS myorder, cliid as ident, name, CONCAT('as: ', name, ' ', addr1, ' ', city) as adresse,
				                     addr1, addr2, city, state, zip, country
				                     FROM arcliass INNER JOIN ffaddr ON arcliass.idarclient_as = ffaddr.cliid
	 			                     WHERE arcliass.idarclient=?arclient_ident) 
            */

            cmd.Parameters.AddWithValue("?arclient_ident", arclient_ident);
            cmd.Parameters.AddWithValue("?pZip", pZip);

            List<IDataRecord> result = null;

            try
            {
                conn.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                result = rd.Cast<IDataRecord>().ToList();
                if (result.Count > 0) { return result[0];}
            }
            catch (System.Exception e)
            {
                var X = e.Message;
                // LogWriter.WriteMessage(Program.LogEventSource, $"Error caught: {e.Message}");
            }
            finally
            {
                conn.Close();
            }

            return null;
        }
    }

    public class CIDataRecord
    {
        public IDataRecord data_record;

        public CIDataRecord(IDataRecord pData_record)
        {
            data_record = pData_record;
        }

        public string this[string propertyName]
        {
            get { return data_record[propertyName].ToString(); }
            set {  }
        }
    }
}
