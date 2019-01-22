using EDICommons.Tools;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public class Vendor
    {

        protected string DB_RSS_Connection;
        protected string DB_VIVA_Connection;
        protected string DB_WEB_Connection;

        public Vendor()
        {
            SetupRSS("rss_bus");
        }

        protected string DB_String(string Server, string UserId, string Password, string DB_Name)
        {
            return $"server={Server};user id={UserId};password={Password};database={DB_Name};persistsecurityinfo=True;Allow User Variables=True;";
        }

        virtual public string SetupRSS(string DB_Name = "rss_bus")
        {
            return "";
        }

        virtual public string SetupViva(string DB_Name)
        {
            return "";
        }

        virtual public string SetupWeb(string DB_Name)
        {
            return "";
        }

        virtual public string GetDB_String(string DB_Name)
        {
            return "";
        }

        public void After_Setup()
        {
            IDataRecord RSS_edi_rss;

            RSS_edi_rss = DB_RSS.GetDBConnection();

            if (RSS_edi_rss != null) DB_VIVA_Connection = GetDB_String(RSS_edi_rss["edi_db_viva"].ToString());
            else if (gDataIDedi_rss != null) DB_VIVA_Connection = GetDB_String(gDataIDedi_rss["edi_db_viva"].ToString());

            vendor.SetupViva(DB_VIVA_Connection);
            vendor.SetupWeb(DB_WEB_Connection);

            Status += "DB_VIVA_Connection: " + DB_VIVA_Connection + NL;
            Status += "DB_WEB_Connection: " + DB_WEB_Connection + NL;

            DB_VIVA = new EDI_DB.Data.CDB_VIVA(DB_VIVA_Connection);

            DB_WEB = new EDI_DB.Data.CDB_WEB(DB_WEB_Connection);
            DB_Logger = new EDI_DB.Data.CDB_Logger(DB_WEB_Connection);

        }
    }
}
