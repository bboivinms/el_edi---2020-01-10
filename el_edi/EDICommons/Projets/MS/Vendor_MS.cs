using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public class Vendor_MS : Vendor
    {
        override protected void Setup()
        {
            // users and passwords to setup
            DB_VIVA_Connection = DB_String("192.168.1.254", "viva_ms", "password_and_user_todo", IIF_LIVE("viva_ms", "viva_ms4"));
            DB_WEB_Connection = DB_String("192.168.1.253", "ms_web", "password_and_user_todo", IIF_LIVE("multis", "multis_test"));
        }

    }
}
