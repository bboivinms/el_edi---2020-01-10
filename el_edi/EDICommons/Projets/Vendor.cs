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

        protected Vendor SubVendor = null;

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
            Status += "SetupRSS: " + DB_Name + NL;

            return DB_RSS_Connection = DB_String("192.168.1.254", "viva_envl", "Xjg8LJFJeGEk9y9HRr!zKCEyrPeRCvUWm", DB_Name);
        }

        virtual public string SetupViva(string DB_Name)
        {
            if (SubVendor != null) return DB_VIVA_Connection = SubVendor.SetupViva(DB_Name);
            return "";
        }

        virtual public string SetupWeb(string DB_Name)
        {
            if (SubVendor != null) return DB_WEB_Connection = SubVendor.SetupWeb(DB_Name);
            return "";
        }
        
        public void After_Setup()
        {
            string DB_VIVA_name = "";
            string DB_WEB_name = "";
            IDataRecord IDataEdi_path;

            /* IDataRecord RSS_edi_rss;
            RSS_edi_rss = DB_RSS.GetDBConnection();
            if (RSS_edi_rss != null) DB_VIVA_name = RSS_edi_rss["edi_db_viva"].ToString(); */

            if (gDataIDedi_path != null) { IDataEdi_path = gDataIDedi_path; }
            else if (gDataIDedi_rss != null) { IDataEdi_path = gDataIDedi_rss; }
            else return;
            // Missing path if port id = ETE etc. before processing information...

            DB_VIVA_name = IDataEdi_path["edi_db_viva"].ToString();
            DB_WEB_name = IDataEdi_path["edi_db_web"].ToString();

            if (IDataEdi_path["edi_code"].ToString().Substring(0, 1).ToUpper() == "E") vendor.SubVendor = new Vendor_EL();
            if (IDataEdi_path["edi_code"].ToString().Substring(0, 1).ToUpper() == "M") vendor.SubVendor = new Vendor_MS();

            EdiPath = IDataEdi_path["edi_path"].ToString();
            
            vendor.SetupViva(DB_VIVA_name);
            vendor.SetupWeb(DB_WEB_name);

            Status += "DB_VIVA_Connection: " + DB_VIVA_Connection + NL;
            Status += "DB_WEB_Connection: " + DB_WEB_Connection + NL;

            DB_VIVA = new EDI_DB.Data.CDB_VIVA(DB_VIVA_Connection);
            DB_WEB = new EDI_DB.Data.CDB_WEB(DB_WEB_Connection);

        }
    }
}
