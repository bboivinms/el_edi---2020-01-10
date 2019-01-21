using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public class Vendor_EL : Vendor
    {
        override protected void Setup()
        {
            DB_RSS_Connection = DB_String("192.168.1.254", "viva_envl", "Xjg8LJFJeGEk9y9HRr!zKCEyrPeRCvUWm", "rss_bus");
            DB_WEB_Connection = DB_String("192.168.1.254", "envl_web", "7Cf!688ZFFYSvMDywNmcPxrwVMbdxVkQQ", IIF_LIVE("envl_clients", "envl_test"));

            // KJ: 2019-01-21: VIVA Connection can be overwritten depending on current PortId
            DB_VIVA_Connection = DB_String("192.168.1.254", "viva_envl", "Xjg8LJFJeGEk9y9HRr!zKCEyrPeRCvUWm", IIF_LIVE("viva_env", "vivadata4"));
        }

    }
}
