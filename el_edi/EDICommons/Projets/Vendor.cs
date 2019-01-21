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
            Setup();
            After_Setup(); // Connection strings should be initialized in Setup override
        }

        protected string DB_String(string Server, string UserId, string Password, string DB_Name)
        {
            return $"server={Server};user id={UserId};password={Password};database={DB_Name};persistsecurityinfo=True;Allow User Variables=True;";
        }

        virtual protected void Setup()
        {

        }

        private void After_Setup()
        {
            IDataRecord RSS_edi_rss;

            DB_RSS = new EDI_DB.Data.CDB_RSS(DB_RSS_Connection);
            RSS_edi_rss = DB_RSS.GetDBConnection();

            if (RSS_edi_rss != null) DB_VIVA_Connection = RSS_edi_rss["edi_db_viva"].ToString();

            DB_VIVA = new EDI_DB.Data.CDB_VIVA(DB_VIVA_Connection);

            DB_WEB = new EDI_DB.Data.CDB_WEB(DB_WEB_Connection);
            DB_Logger = new EDI_DB.Data.CDB_Logger(DB_WEB_Connection);
        }
    }
}
