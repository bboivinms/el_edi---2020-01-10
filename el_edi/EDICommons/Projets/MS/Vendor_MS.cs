using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public class Vendor_MS : Vendor
    {
        override public string SetupViva(string DB_Name)
        {
            Status += "SetupViva: " + DB_Name + NL;
            return DB_String("192.168.1.254", "viva_ms", "Xjg8LJFJeGEk9y9HRr!zKCEyrPeRCvUWm", DB_Name);
        }

        override public string SetupWeb(string DB_Name)
        {
            Status += "SetupWeb: " + DB_Name + NL;
            return DB_String("192.168.1.253", "webcms", "mfnDLfntCDPADATh", DB_Name);
        }

    }
}
