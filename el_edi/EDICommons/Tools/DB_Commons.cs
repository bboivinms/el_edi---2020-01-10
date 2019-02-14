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
using System.Diagnostics;
using System.Text.RegularExpressions;

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
        public static string Filepath = "";
        public static string ErrorMessage = "";
        public static string ProgramId = "";
        public static string EdiPath = "";
        public static string EdiProcess = "";
        // End

        public static Vendor vendor;
        
        public static string RSS_send_path = "";
        public static string NL = "\r\n";
        public static string Status = "";
        public static string Status_Queries = "";
        public static string Error = "";

        public static bool IsLocalTest = false;

        public static CDB_RSS DB_RSS;
        public static CDB_VIVA DB_VIVA;
        public static CDB_WEB DB_WEB;

        public static string wscie = "";
        public static string IDE = "";
        public static string IDE_status = "";
        public static string alias = "";
        public static int arclient_ident = 0;
        public static int edi_doc_number = 0;
        public static string arclient_short_name;
        public static long IDedi_rss = 0;

        public static IDataRecord gDataIDedi_rss;
        public static IDataRecord gDataIDedi_path;

        public static bool TimePassed(int hour, int minute)
        {
            if (hour < 0 || hour > 24) hour = 0;
            if (minute < 0 || minute > 60) minute = 0;

            return TimeSpan.Compare(DateTime.Now.TimeOfDay, DateTime.Parse($"2010/01/01 {hour}:{minute}:00.000").TimeOfDay) > 0;
        }
        
        public static void SetRouting_out_path(string TheType)
        {
            string where = "error";
            if (IDE.Substring(0, 1) == "L") { where = "data_live"; }
            if (IDE.Substring(0, 1) == "T") { where = "data_test"; }

            if(TheType == "routing_out" || TheType == "routing_in")
            {
                RSS_send_path = $@"C:\Program Files\RSSBus\RSSBus Connect\{where}\routing\{wscie}{IDE}_routing\{wscie}{IDE}_{TheType}\Send";
            }
            else 
            {
                RSS_send_path = $@"C:\Program Files\RSSBus\RSSBus Connect\{where}\envl\{alias}\{wscie}{IDE}_{alias}\{wscie}{IDE}_{alias}_{TheType}\Send";
            }


        }

        public static void SetupClient(int pArclient_ident)
        {
            arclient_ident = pArclient_ident;
            arclient_short_name = "";

            if (arclient_ident == 30037) arclient_short_name = "ariva";
        }

        public static string ToAlphaNumeric(string str)
        {
            char[] arr = str.Where(c => (char.IsLetterOrDigit(c) ||
                             char.IsWhiteSpace(c) ||
                             c == '-')).ToArray();

            return new string(arr);
        }

        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static int GetInt(object Expression)
        {
            if (!IsNumeric(Expression)) return 0;
            return Convert.ToInt32(Expression);
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


        public static IDataRecord GetEdi_arclient()
        {
            if (IDE == "") return null;
            if (edi_doc_number != 810 && edi_doc_number != 855 && edi_doc_number != 856 && edi_doc_number != 850) return null;
            if (arclient_ident <= 0) return null;
            if (wscie == "") return null;

            List<IDataRecord> results;

            Dictionary<string, string> Params = new Dictionary<string, string>();

            Params.Clear();
            Params.Add("?idclient", arclient_ident.ToString());
            Params.Add("?wscie", wscie);

            results = DB_RSS.HExecuteSQLQuery($@"
                SELECT 
                    alias,
                    X{IDE}_{edi_doc_number} AS IDE_status,
                    X{IDE}_path AS IDE_path,
                    edi_path.*
                    FROM edi_arclient
				INNER JOIN
					edi_path ON X{IDE}_path = edi_path
                WHERE
                    idclient = ?idclient AND
                    wscie = ?wscie
                ", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            IDataRecord result = results[0];

            return result;
        }
    }

    public class DB_Parent
    {
        public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();

        public MySqlConnection conn { get; set; }

        public MySqlTransaction BeginTransaction() { return conn.BeginTransaction(); }

        public MySqlCommand CreateCommand() { return conn.CreateCommand(); }

        // public void Open() { conn.Open(); }

        // public void Close() { conn.Close(); }
        
        public long HExecuteSQLNonQuery(string slpMySQLQuery, Dictionary<string, string> pParams = null)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = slpMySQLQuery;
            long LastInsertedId = 0;

            string Parameters = "";

            try
            {
                if (pParams != null)
                {
                    foreach (KeyValuePair<string, string> pParam in pParams)
                    {
                        cmd.Parameters.AddWithValue(pParam.Key, pParam.Value);
                        Parameters += "Key: " + pParam.Key + " Value: " + pParam.Value + NL;
                    }
                }

                cmd.ExecuteNonQuery();

                LastInsertedId = cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                DB_RSS.LogData("ERROR: " + ex.Message + NL + ex.ToString() + NL + "SQL: " + slpMySQLQuery + NL + "Params: " + Parameters + NL);
            }
            finally
            {
                Status_Queries += "HExecuteSQLNonQuery: SQL: " + slpMySQLQuery + NL + "Params: " + Parameters + NL;
                Status_Queries += "Connection: " + conn.ConnectionString + NL;
                Status_Queries += "HExecuteSQLNonQuery END" + NL;
            }

            // WIP
            return LastInsertedId;
        }

        public List<IDataRecord> HExecuteSQLQuery(string slpMySQLQuery, Dictionary<string, string> pParams = null)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = slpMySQLQuery;

            string Parameters = "";

            List<IDataRecord> sdPCursor = null;

            try
            {
                if (pParams != null)
                {
                    foreach (KeyValuePair<string, string> pParam in pParams)
                    {
                        cmd.Parameters.AddWithValue(pParam.Key, pParam.Value);
                        Parameters += "Key: " + pParam.Key + " Value: " + pParam.Value + NL;
                    }
                }

                MySqlDataReader rd = cmd.ExecuteReader();
                sdPCursor = rd.Cast<IDataRecord>().ToList();
                rd.Close();
            }
            catch (Exception ex)
            {
                DB_RSS.LogData("ERROR: " + ex.Message + NL + ex.ToString() + NL + "SQL: " + slpMySQLQuery + NL + "Params: " + Parameters + NL + "Connection: " + conn.ConnectionString + NL);
                sdPCursor = null;
            }
            finally
            {
                Status_Queries += "HExecuteSQLQuery: SQL: " + slpMySQLQuery + NL + "Params: " + Parameters + NL;
                Status_Queries += "Connection: " + conn.ConnectionString + NL;
                Status_Queries += "HExecuteSQLQuery END" + NL;
            }

            // WIP
            return sdPCursor;
        }

        ~DB_Parent()
        {
            try
            {
                conn.Close();
            }
            finally
            {
            }
        }

    }

    public class CDB_RSS : DB_Parent
    {
        public CDB_RSS(string Connection)
        {
            conn = new MySqlConnection(Connection);
            conn.Open();
        }

        public void LogData(string message, string mysql_type = "EDI_LogData")
        {
            MySqlCommand cmd = CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"INSERT INTO mysql_log (mysql_log, mysql_type, mysql_programid, mysql_portid, mysql_clientid, mysql_datapath) VALUES (?mysql_log, ?mysql_type, ?mysql_programid, ?mysql_portid, ?mysql_clientid, ?mysql_datapath); ";

            cmd.Parameters.AddWithValue("?mysql_log", message);
            cmd.Parameters.AddWithValue("?mysql_type", mysql_type);
            cmd.Parameters.AddWithValue("?mysql_programid", ProgramId);
            cmd.Parameters.AddWithValue("?mysql_portid", PortId);
            cmd.Parameters.AddWithValue("?mysql_clientid", arclient_ident.ToString());
            cmd.Parameters.AddWithValue("?mysql_datapath", EdiPath);
            cmd.Parameters.AddWithValue("?mysql_process", EdiProcess);

            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
            }
        }
    }

    public class CDB_WEB : DB_Parent
    {
        public CDB_WEB(string Connection)
        {
            conn = new MySqlConnection(Connection);
            conn.Open();
        }
    }
    
    public class CDB_VIVA : DB_Parent
    {
        
        public CDB_VIVA(string Connection)
        {
            conn = new MySqlConnection(Connection);
            conn.Open();
        }
        
        public IDataRecord GetAddressBT(int arclient_ident)
        {
            List<IDataRecord> results;
            Params.Clear();
            Params.Add("arclient_ident", arclient_ident.ToString());

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

        public IDataRecord GetAddressArclient(int arclient_ident)
        {
            List<IDataRecord> results;
            Params.Clear();
            Params.Add("arclient_ident", arclient_ident.ToString());

            results = HExecuteSQLQuery(@"
                SELECT 
                    CONCAT('4', CAST(ident AS CHAR)) AS iddel_addr,
                    Name AS arclient_name,
                    addr1 AS arclient_addr1,
                    addr2 AS arclient_addr2,
                    city AS arclient_city,
                    state AS arclient_state, 
                    zip AS arclient_zip, 
                    country AS arclient_country
                FROM arclient 
                WHERE ident = ?arclient_ident", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            return results[0];
        }

        public string GetPostalCode(int arinv_ident)
        {
            List<IDataRecord> results;
            string postalCode;
            Params.Clear();
            Params.Add("arinv_ident", arinv_ident.ToString());

            results = HExecuteSQLQuery(@"
                SELECT 
                   VLIVREA 
                FROM vivadata4.arinv
                WHERE IDENT = ?arinv_ident", Params);

            postalCode = FindPostalCode(results[0]["VLIVREA"].ToString());

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            return postalCode;
        }

        //Find a postal code in a text with endline
        public string FindPostalCode(string input)
        {
            string[] lines = input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"[A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9] *$";

            foreach (string line in lines)
            {
                
                if (Regex.IsMatch(line, pattern))
                {
                    return line;
                }
            }
            return "";
        }

        public IDataRecord GetAddressST(int arclient_ident, string pZip)
        {
            pZip = pZip.ToUpper().Replace(" ", "");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT * FROM (
                                (SELECT CONCAT('4', CAST(ident AS CHAR)) AS iddel_addr, 2 AS myorder, ident, name, CONCAT(name, ' ', addr1, ' ', city) AS address,
					                    addr1, addr2, city, state, zip, country
					                FROM arclient WHERE ident=?arclient_ident)
	                                UNION ALL 
	                            (SELECT CONCAT('1', CAST(ident AS CHAR)) AS iddel_addr, 1 AS myorder, cliid as ident, name, CONCAT(name, ' ', addr1, ' ', city) AS address,
					                    addr1, addr2, city, state, zip, country
					                FROM ffaddr   WHERE cliid=?arclient_ident)) AS ffaddr_union
                                WHERE REPLACE(zip, ' ', '') = ?pZip
                                ORDER BY myorder
                                ";

            /* // references to arcliass is currently not used
	                    UNION ALL 
                        (SELECT CONCAT('2', CAST(arclient.ident AS CHAR)) AS iddel_addr, 2 AS myorder, arclient.ident, name, CONCAT('as: ', name, ' ', addr1, ' ', city) as address,
					                     addr1, addr2, city, state, zip, country
					                     FROM arcliass INNER JOIN arclient ON arcliass.idarclient_as = arclient.ident
					                     WHERE arcliass.idarclient=?arclient_ident)
	                     UNION ALL 
	                    (SELECT CONCAT('3', CAST(ffaddr.ident AS CHAR)) AS iddel_addr, 2 AS myorder, cliid as ident, name, CONCAT('as: ', name, ' ', addr1, ' ', city) as address,
				                     addr1, addr2, city, state, zip, country
				                     FROM arcliass INNER JOIN ffaddr ON arcliass.idarclient_as = ffaddr.cliid
	 			                     WHERE arcliass.idarclient=?arclient_ident) 
            */

            cmd.Parameters.AddWithValue("?arclient_ident", arclient_ident);
            cmd.Parameters.AddWithValue("?pZip", pZip);

            List<IDataRecord> result = null;

            try
            {
                MySqlDataReader rd = cmd.ExecuteReader();
                result = rd.Cast<IDataRecord>().ToList();
                rd.Close();
                if (result.Count > 0) { return result[0];}
            }
            catch (System.Exception e)
            {
                var X = e.Message;
                // LogWriter.WriteMessage(Program.LogEventSource, $"Error caught: {e.Message}");
            }
            finally
            {
            }

            return null;
        }

        public IDataRecord GetAddressWscie(int cie_id = 1)
        {
            List<IDataRecord> results;
            Params.Clear();
            Params.Add("cie_id", cie_id.ToString());

            results = HExecuteSQLQuery(@"
                SELECT 
                    cie_id AS wscie_cie_id,
                    cie_name AS wscie_name,
                    cie_adr1 AS wscie_adr1,
                    cie_adr2 AS wscie_adr2,
                    cie_city AS wscie_city,
                    cie_state AS wscie_state, 
                    cie_zip AS wscie_zip, 
                    cie_country AS wscie_country
                FROM wscie 
                WHERE cie_id = ?cie_id", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            return results[0];
        }

        public IDataRecord GetAddressApsupp(int idVendor)
        {
            List<IDataRecord> results;
            Params.Clear();
            Params.Add("idVendor", idVendor.ToString());

            results = HExecuteSQLQuery(@"
                SELECT 
                    ident AS apsupp_ident,
                    name AS apsupp_name,
                    addr1 AS apsupp_addr1,
                    addr2 AS apsupp_addr2,
                    city AS apsupp_city,
                    state apsupp_state,
                    zip apsupp_zip,
                    country AS apsupp_country
                FROM apsupp 
                WHERE ident = ?idVendor", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            return results[0];
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