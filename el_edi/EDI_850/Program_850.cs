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
            if (args.Length < 2)
            {
                LogWriter.WriteMessage(LogEventSource, $"Incorrect number of arguments. Expected at least 2, got {args.Length}");
                return;
            }

            XmlFilePath = args[0];
            UseSystem = args[1].ToLower();

            Status += "args.Length: " + args.Length + NL;

            PortId = args.Length >= 3 ? args[2] : "Unknown";

            Status += "PortId: " + PortId + NL;
            Status += "XmlFilePath: " + XmlFilePath + NL;

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

            DB_Logger.LogData(Status);
        }

    }
}
