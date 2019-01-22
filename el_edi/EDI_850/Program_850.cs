using EDICommons.Tools;
using System.IO;
using static EDI_DB.Data.Base;

namespace EDI_850
{
    public class Program_850
    {
        public static readonly string LogEventSource = "EDI 850 Processor";

        public static string XmlFilePath = "";

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                LogWriter.WriteMessage(LogEventSource, $"Incorrect number of arguments. Expected 2, got {args.Length}");
                return;
            }

            XmlFilePath = args[0];
            UseSystem = args[1].ToLower();

            if (!File.Exists(XmlFilePath))
            {
                LogWriter.WriteMessage(LogEventSource, $"Specified XML file could not be found: {XmlFilePath}");
                return;
            }

            if(UseSystem != "live" && UseSystem != "test")
            {
                LogWriter.WriteMessage(LogEventSource, $"2nd command line argument expects either \"live\" or \"test\", got: {UseSystem}");
                return;
            }

            vendor = new EDI_RSS.Vendor_EL();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));
            vendor.After_Setup();

            XMLProcessor_850 proc = new XMLProcessor_850();
            proc.ProcessOrder();
        }

    }
}
