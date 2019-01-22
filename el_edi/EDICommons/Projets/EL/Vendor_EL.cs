using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public class Vendor_EL : Vendor
    {
        override public string SetupRSS(string DB_Name = "rss_bus")
        {
            return DB_RSS_Connection = GetDB_String(DB_Name);
        }

        override public string SetupViva(string DB_Name)
        {
            if(string.IsNullOrEmpty(DB_Name)) DB_Name = IIF_LIVE("viva_env", "vivadata4");
            return DB_VIVA_Connection = GetDB_String(DB_Name);
        }

        override public string SetupWeb(string DB_Name)
        {
            if (string.IsNullOrEmpty(DB_Name)) DB_Name = IIF_LIVE("envl_clients", "envl_test");
            return DB_WEB_Connection = DB_String("192.168.1.254", "envl_web", "7Cf!688ZFFYSvMDywNmcPxrwVMbdxVkQQ", DB_Name);
        }

        override public string GetDB_String(string DB_Name)
        {
            return DB_String("192.168.1.254", "viva_envl", "Xjg8LJFJeGEk9y9HRr!zKCEyrPeRCvUWm", DB_Name);
        }



    }
}
