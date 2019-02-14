﻿using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public class Vendor_MS : Vendor
    {
        override public string SetupViva(string DB_Name)
        {
            Status += "SetupViva: " + DB_Name + NL;
            return DB_String("192.168.1.254", "viva_ms", "password_and_user_todo", DB_Name);
        }

        override public string SetupWeb(string DB_Name)
        {
            Status += "SetupWeb: " + DB_Name + NL;
            return DB_String("192.168.1.253", "ms_web", "ms_web", DB_Name);
        }

    }
}
