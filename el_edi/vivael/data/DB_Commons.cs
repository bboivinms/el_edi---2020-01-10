using vivael.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDI_DB.Data
{

    public static class Base
    {
        public static bool TimePassed(int hour, int minute)
        {
            if (hour < 0 || hour > 24) hour = 0;
            if (minute < 0 || minute > 60) minute = 0;

            return TimeSpan.Compare(DateTime.Today.TimeOfDay, DateTime.Parse($"2010/01/01 {hour}:{minute}:00.000").TimeOfDay) > 0;
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
        protected MySqlConnection conn { get; set; }

        public MySqlTransaction BeginTransaction() { return conn.BeginTransaction(); }
        
        public MySqlCommand CreateCommand() { return conn.CreateCommand(); }

        public string GetDatabase() { try { return conn.Database; } catch { } return ""; }

        public void Open() { conn.Open(); }

        public void Close() { conn.Close(); }

    }

    public class DB_Logger : DB_Parent
    {
        public DB_Logger(string UseSystem)
        {
            conn = new MySqlConnection(UseSystem == "live" ? vivael.Properties.Settings.Default.envl_253_live : vivael.Properties.Settings.Default.envl_253_test);
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

    public class DB_253 : DB_Parent
    {
        public DB_253(string UseSystem)
        {
            conn = new MySqlConnection(UseSystem == "live" ? vivael.Properties.Settings.Default.envl_253_live : vivael.Properties.Settings.Default.envl_253_test);
        }
    }

    public class DB_254 : DB_Parent
    {
        
        public DB_254(string UseSystem)
        {
            conn = new MySqlConnection(UseSystem == "live" ? vivael.Properties.Settings.Default.envl_254_live : vivael.Properties.Settings.Default.envl_254_test);
        }

        public List<IDataRecord> GetAddress(int idclient, String pZip)
        {
            pZip = pZip.ToUpper().Replace(" ", "");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT * FROM (
                                (SELECT CONCAT('4', CAST(ident AS CHAR)) AS iddel_addr, 2 AS myorder, ident, name, CONCAT(name, ' ', addr1, ' ', city) AS adresse,
					                    addr1, addr2, city, state, zip, country
					                FROM arclient WHERE ident=?idclient)
	                                UNION ALL 
	                            (SELECT CONCAT('1', CAST(ident AS CHAR)) AS iddel_addr, 1 AS myorder, cliid as ident, name, CONCAT(name, ' ', addr1, ' ', city) AS adresse,
					                    addr1, addr2, city, state, zip, country
					                FROM ffaddr   WHERE cliid=?idclient)) AS ffaddr_union
                                WHERE REPLACE(zip, ' ', '') = ?pZip
                                ORDER BY myorder
                                ";

            /* // references to arcliass is currently not used
	                    UNION ALL 
                        (SELECT CONCAT('2', CAST(arclient.ident AS CHAR)) AS iddel_addr, 2 AS myorder, arclient.ident, name, CONCAT('as: ', name, ' ', addr1, ' ', city) as adresse,
					                     addr1, addr2, city, state, zip, country
					                     FROM arcliass INNER JOIN arclient ON arcliass.idarclient_as = arclient.ident
					                     WHERE arcliass.idarclient=?idclient)
	                     UNION ALL 
	                    (SELECT CONCAT('3', CAST(ffaddr.ident AS CHAR)) AS iddel_addr, 2 AS myorder, cliid as ident, name, CONCAT('as: ', name, ' ', addr1, ' ', city) as adresse,
				                     addr1, addr2, city, state, zip, country
				                     FROM arcliass INNER JOIN ffaddr ON arcliass.idarclient_as = ffaddr.cliid
	 			                     WHERE arcliass.idarclient=?idclient) 
            */

            cmd.Parameters.AddWithValue("?idclient", idclient);
            cmd.Parameters.AddWithValue("?pZip", pZip);

            List<IDataRecord> result = null;

            try
            {
                conn.Open();
                MySqlDataReader rd = cmd.ExecuteReader();
                result = rd.Cast<IDataRecord>().ToList();
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

            return result;
        }
        
    }

}
