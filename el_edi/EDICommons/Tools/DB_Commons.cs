﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDI_DB.Data;
using EDI_RSS;
using static EDI_DB.Data.Base;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using System.IO;

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
        public static string Fileidentifier = "";
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
        public static string Debug = "";
        public static string Status_Queries = "";
        public static string Error = "";

        // public static IDataRecord gDataIDedi_rss;
        // public static IDataRecord gDataIDedi_path;
        public static IDataRecord gIDataEdi_path;
        public static string gRss_datapath = "";

        public static bool IsLocalTest = false;

        public static CDB_RSS DB_RSS;
        public static CDB_VIVA DB_VIVA;
        public static CDB_WEB DB_WEB;

        public static string wscie = "";
        public static string IDE = "";
        public static string IDE_status = "";
        public static string Edi_protocol = ""; 
        public static string alias = "";
        public static int IDpartner = 0; 
        public static string arclient_idedi = "";
        public static int edi_doc_number = 0;
        public static string arclient_short_name;
        public static long IDedi_rss = 0;

        public static string gRss_request;
        public static string gRss_client;

        public static string PortId_code;

        public static T IIf<T>(bool expression, T truePart, T falsePart) { return expression ? truePart : falsePart; }

        public static bool TimePassed(int hour, int minute)
        {
            if (hour < 0 || hour > 24) hour = 0;
            if (minute < 0 || minute > 60) minute = 0;

            return TimeSpan.Compare(DateTime.Now.TimeOfDay, DateTime.Parse($"2010/01/01 {hour}:{minute}:00.000").TimeOfDay) > 0;
        }

        public static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }

        public static void CopyFile(string copyFromPath, string copyToPath)
        {
            Status += $"CopyFile(copyFromPath: {copyFromPath}, copyToPath: {copyToPath})"+ NL;

            if (File.Exists(copyToPath))
            {
                var target = new FileInfo(copyToPath);
                if (target.IsReadOnly)
                    target.IsReadOnly = false;
            }

            var origin = new FileInfo(copyFromPath);
            origin.CopyTo(copyToPath, true);

            var destination = new FileInfo(copyToPath);
            if (destination.IsReadOnly)
            {
                destination.IsReadOnly = false;
                destination.CreationTime = DateTime.Now;
                destination.LastWriteTime = DateTime.Now;
                destination.LastAccessTime = DateTime.Now;
                destination.IsReadOnly = true;
            }
            else
            {
                destination.CreationTime = DateTime.Now;
                destination.LastWriteTime = DateTime.Now;
                destination.LastAccessTime = DateTime.Now;
            }
        }

        public static string GetGlobalCopies_path()
        {
            return @"C:\Program Files\RSSBus\RSSBus Connect\data\GlobalCopies\Send";
        }

        public static void SetRouting_out_path(string TheType, string ToWhere = "Send")
        {
            string where = "error";
            if (IDE.Substring(0, 1) == "L")
            {
                if(IDpartner == 56)
                {
                    where = "data";
                }
                else
                {
                    where = "data_live";
                }
            }
            if (IDE.Substring(0, 1) == "T") { where = "data_test"; }

            if (IDE.Substring(1, 1) == "L")
            {
                RSS_send_path = $@"C:\TMP";
            }
            else if (TheType == "routing_out" || TheType == "routing_in")
            {
                RSS_send_path = $@"C:\Program Files\RSSBus\RSSBus Connect\{where}\routing\{wscie}{IDE}_routing\{wscie}{IDE}_{TheType}\{ToWhere}";
            }
            else 
            {
                //RSS_send_path = $@"C:\Program Files\RSSBus\RSSBus Connect\{where}\envl\{alias}\{wscie}{IDE}_{alias}\{wscie}{IDE}_{alias}_{TheType}\Send";

                if(wscie == "E")
                {
                    RSS_send_path = $@"C:\Program Files\RSSBus\RSSBus Connect\{where}\envl\{alias}\{wscie}{IDE}_{alias}\{wscie}{IDE}_{alias}_{TheType}\{ToWhere}";
                }
                else if(wscie == "M")
                {
                    RSS_send_path = $@"C:\Program Files\RSSBus\RSSBus Connect\{where}\ms\{alias}\{wscie}{IDE}_{alias}\{wscie}{IDE}_{alias}_{TheType}\{ToWhere}";
                }  
            }

            Status += ($"SetRouting_out_path(TheType: {TheType}, ToWhere: {ToWhere}): RSS_send_path: {RSS_send_path + NL}");
        }

        public static void SetupClient(int pArclient_ident)
        {
            IDpartner = pArclient_ident;
            arclient_short_name = "";

            if (IDpartner == 30037) arclient_short_name = "ariva";
        }

        public static string ToAlphaNumeric(string str)
        {
            char[] arr = str.Where(c => (char.IsLetterOrDigit(c) ||
                             char.IsWhiteSpace(c) ||
                             c == '-' || c == '_')).ToArray();

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


        public static IDataRecord GetEdi_partner(string table)
        {
            if (IDE == "") return null;
            if (edi_doc_number != 810 && edi_doc_number != 855 && edi_doc_number != 856 && edi_doc_number != 850) return null;
            if (IDpartner <= 0 && arclient_idedi == "") return null;
            if (wscie == "") return null;
            if (table != "edi_arclient" && table != "edi_apsupp") return null;

            string ID = "";
            string inner_log = "";
            if (table == "edi_arclient") { ID = "idclient"; }
            if (table == "edi_apsupp") { ID = "idvendor"; }

            List<IDataRecord> results;

            Dictionary<string, string> Params = new Dictionary<string, string>();

            Params.Clear();
            Params.Add("?idclient", IDpartner.ToString()); //idclient or idvendor
            Params.Add("?arclient_idedi", arclient_idedi);
            Params.Add("?wscie", wscie);

            results = DB_RSS.HExecuteSQLQuery($@"
                SELECT 
                    {ID} AS id,
                    alias,
                    Has_accent,
                    Edi_version,
                    Edi_protocol,
                    X{IDE}_{edi_doc_number} AS IDE_status,
                    X{IDE}_path AS IDE_path,
                    edi_path.*
                    FROM {table}
				INNER JOIN
					edi_path ON X{IDE}_path = edi_path
                WHERE
                    ({ID} = ?idclient OR {table}.idedi = ?arclient_idedi OR {table}.idedi_test = ?arclient_idedi) AND 
                    wscie = ?wscie
                ", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            IDataRecord result = results[0];

            inner_log += "Wscie: " + wscie + NL;
            inner_log += "IDE: " + IDE + NL;
            inner_log += "Filename to be parsed: " + Filename + NL;
            inner_log += "arclient_ident: " + IDpartner.ToString() + NL; //idclient or idvendor
            inner_log += "edi_doc_number: " + edi_doc_number.ToString() + NL;

            alias = result["alias"].ToString();
            IDpartner = Convert.ToInt32(result["id"]); //idclient or idvendor | id_vendor_client

            DB_RSS.LogData(inner_log);

            Status += inner_log;

            return result;
        }


        public static IDataRecord GetIDedi_path(string edi_path)
        {
            List<IDataRecord> results;

            Dictionary<string, string> Params = new Dictionary<string, string>();

            Params.Clear();
            Params.Add("?edi_path", edi_path);

            results = DB_RSS.HExecuteSQLQuery(@"SELECT * FROM edi_path WHERE UPPER(edi_path) = UPPER(?edi_path)", Params);

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            IDataRecord result = results[0];

            gRss_datapath = edi_path.ToUpper();

            return result;
        }
    }

    public class DB_Parent
    {
        public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();

        public MySqlConnection conn { get; set; }

        public MySqlTransaction BeginTransaction() { return conn.BeginTransaction(); }

        public MySqlCommand CreateCommand() { return conn.CreateCommand(); }

        public string GetDatabase() { try { return conn.Database; } catch { } return ""; }

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


        public DataSet HExecuteSQLQueryDataSet(string slpMySQLQuery, Dictionary<string, string> pParams = null)
        {
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = slpMySQLQuery;
            string Parameters = "";
            DataSet sdPCursor = new DataSet();
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
                DataTable dt = new DataTable();
                dt.Load(rd);
                sdPCursor.Tables.Add(dt);
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
            cmd.Parameters.AddWithValue("?mysql_clientid", IDpartner.ToString());
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

        
        public void LogEmail(GMail mail)
        {
            MySqlCommand cmd = CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"INSERT INTO gmail ( mail_smtp,  mail_user,  mail_datapath,  mail_from,  mail_to,  mail_cc,  mail_bcc,  mail_body,  mail_subject) 
                                VALUES            (?mail_smtp, ?mail_user, ?mail_datapath, ?mail_from, ?mail_to, ?mail_cc, ?mail_bcc, ?mail_body, ?mail_subject) ; ";

            cmd.Parameters.AddWithValue("?mail_smtp", mail.mail_smtp);
            cmd.Parameters.AddWithValue("?mail_user", mail.mail_user);
            cmd.Parameters.AddWithValue("?mail_datapath", EdiPath);
            cmd.Parameters.AddWithValue("?mail_from", mail.mail_from);
            cmd.Parameters.AddWithValue("?mail_to", mail.mail_to);
            cmd.Parameters.AddWithValue("?mail_cc", mail.mail_cc);
            cmd.Parameters.AddWithValue("?mail_bcc", mail.mail_bcc);
            cmd.Parameters.AddWithValue("?mail_body", mail.mail_body);
            cmd.Parameters.AddWithValue("?mail_subject", mail.mail_subject);

            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
            }
        } 
    }

    
    public class GMail : MailMessage
    {
        public SmtpClient mail_client;
        public string mail_smtp = "smtp-mail.outlook.com";
        public string mail_user = "noreply@multi-services.org";
        public string mail_pw = "Cuz813911";
        public string mail_from = "web2@envl.ca";
        public string mail_name = "";
        public MailAddress mail_dev_email = new MailAddress("kjohnston@multi-services.org");

        // readonly properties
        public string mail_to { get { return this.To.ToString(); } }
        public string mail_cc { get { return this.CC.ToString(); } }
        public string mail_bcc { get { return this.Bcc.ToString(); } }
        public string mail_body { get { return this.Body.ToString(); } }
        public string mail_subject { get { return this.Subject.ToString(); } }
        public string mail_header { get { return this.Headers.ToString(); } }

        public GMail(string FromName)
        {
            mail_name = FromName;
            mail_client = new SmtpClient(mail_smtp);
            mail_client.Credentials = new NetworkCredential(mail_user, mail_pw);
            mail_client.EnableSsl = true;

            this.IsBodyHtml = true;
            this.Headers.Add("Message-Id",
                         String.Format("<{0}@{1}>",
                         Guid.NewGuid().ToString(),
                        "envl.ca"));

            MailAddress from = new MailAddress(mail_from, mail_name, System.Text.Encoding.UTF8);
            this.From = from;
        }

        public void Send()
        {
            if (this.To.Count == 0) { this.To.Add(mail_dev_email); }
            else if (!this.To.Contains(mail_dev_email) &&
                     !this.Bcc.Contains(mail_dev_email)) { this.Bcc.Add(mail_dev_email); }

            string SubjectTestMsg = "Test server: " + wscie + IDE;

            if (UseSystem != "live" && (this.Subject.Left(SubjectTestMsg.Length) != SubjectTestMsg))
            {
                this.Subject = "Test server: " + wscie + IDE + " : " + this.Subject;
            }

            DB_RSS.LogEmail(this);
            mail_client.Send(this);
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

        public IDataRecord GetAddressArclientName(string arclient_name, int iddel_addr_start_num = 4)
        {
            List<IDataRecord> results;
            Params.Clear();
            Params.Add("arclient_name", arclient_name.ToString().Replace('-', ' ').Replace(".", ""));

            results = HExecuteSQLQuery($@"
                SELECT 
                    CONCAT('{iddel_addr_start_num}', CAST(ident AS CHAR)) AS iddel_addr,
                    Name AS arclient_name,
                    addr1 AS arclient_addr1,
                    addr2 AS arclient_addr2,
                    city AS arclient_city,
                    state AS arclient_state, 
                    zip AS arclient_zip, 
                    country AS arclient_country
                FROM arclient 
                WHERE REPLACE(REPLACE(name, '-', ' '), '.', '') = ?arclient_name", Params);

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

            results = DB_VIVA.HExecuteSQLQuery(@"
                SELECT 
                   VLIVREA 
                FROM arinv
                WHERE IDENT = ?arinv_ident", Params);

            postalCode = FindPostalCode(results[0]["VLIVREA"].ToString());

            if (results == null) { return null; }
            if (results.Count == 0) { return null; }

            return postalCode;
        }

        //Find a postal code in a text with endline
        public static string FindPostalCode(string input)
        {
            string[] lines = input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"([A-VXY][0-9][A-Z] ?[0-9][A-Z][0-9] *)((?:[a-zA-Zé]* *))*$";
            RegexOptions options = RegexOptions.IgnoreCase;

            foreach (string line in lines)//cherche chaque ligne dans le texte pour trouver un code postal
            {

                if (Regex.IsMatch(line, pattern, options))//pour un ligne vérifie si il y a un code postal
                {
                    Match m = Regex.Match(line, pattern, options);
                    return m.Groups[1].Value; //retourne le code postal seulement
                }
            }
            return ""; //sinon retourne rien
        }

        public IDataRecord GetAddressST(int arclient_ident, string pZip)
        {
            pZip = pZip.ToUpper().Replace(" ", "");

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = @"SELECT * FROM (
            //                    (SELECT CONCAT('4', CAST(ident AS CHAR)) AS iddel_addr, 2 AS myorder, ident, name, CONCAT(name, ' ', addr1, ' ', city) AS address,
            //             addr1, addr2, city, state, zip, country
            //         FROM arclient WHERE ident=?arclient_ident)
            //                     UNION ALL 
            //                 (SELECT CONCAT('1', CAST(ident AS CHAR)) AS iddel_addr, 1 AS myorder, cliid as ident, name, CONCAT(name, ' ', addr1, ' ', city) AS address,
            //             addr1, addr2, city, state, zip, country
            //         FROM ffaddr   WHERE cliid=?arclient_ident)) AS ffaddr_union
            //                    WHERE REPLACE(zip, ' ', '') = ?pZip
            //                    ORDER BY myorder
            //                    ";

            //À tester
            cmd.CommandText = @" SELECT * FROM (
                                (SELECT CONCAT('4', CAST(arclient.ident AS CHAR)) AS iddel_addr, 2 AS myorder, arclient.ident, name, CONCAT(name, ' ', addr1, ' ', city) AS address,
                                        addr1, addr2, city, state, zip, country, edi_faddr.iddel_addr_91 AS edi_faddr_iddel_addr_91, edi_faddr.iddel_addr_92 AS edi_faddr_iddel_addr_92
                                    FROM arclient
                                    LEFT JOIN rss_bus.edi_faddr ON edi_faddr.type = 'B' AND edi_faddr.idpartner = ?arclient_ident  AND REPLACE(edi_faddr.code_postal, ' ', '') = ?pZip
                                WHERE arclient.ident = ?arclient_ident)

                                UNION ALL
                                (SELECT CONCAT('1', CAST(ffaddr.ident AS CHAR)) AS iddel_addr, 1 AS myorder, cliid as ident, name, CONCAT(name, ' ', addr1, ' ', city) AS address,
                                        addr1, addr2, city, state, zip, country, edi_faddr.iddel_addr_91 AS edi_faddr_iddel_addr_91, edi_faddr.iddel_addr_92 AS edi_faddr_iddel_addr_92
                                    FROM ffaddr
                                    LEFT JOIN rss_bus.edi_faddr ON edi_faddr.type = 'B' AND edi_faddr.idpartner = ?arclient_ident  AND REPLACE(edi_faddr.code_postal, ' ', '') = ?pZip
                                WHERE cliid = ?arclient_ident)) AS ffaddr_union
                                WHERE REPLACE(zip, ' ', '') = ?pZip

                                ORDER BY myorder";


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