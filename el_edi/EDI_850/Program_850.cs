using System;
using System.IO;
using EDICommons.Tools;
using EDI_RSS;
using static EDI_DB.Data.Base;

namespace EDI_850
{
    public class Program_850
    {
        public static readonly string LogEventSource = "EDI 850 Processor";

        public static string XmlFilePath = "";

        public static string PortId_code;

        static void Main(string[] args)
        {
            try
            {
                ProgramId = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                vendor = new Vendor();
                DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

                if (args.Length < 3)
                {
                    LogWriter.WriteMessage(LogEventSource, $"Incorrect number of arguments. Expected at least 3, got {args.Length}");
                    return;
                }

                XmlFilePath = args[0];
                UseSystem = args[1].ToLower();
                PortId = args[2];

                Status += "args.Length: " + args.Length + NL;
                Status += "PortId: " + PortId + NL;
                Status += "XmlFilePath: " + XmlFilePath + NL;

                if (!File.Exists(XmlFilePath))
                {
                    LogWriter.WriteMessage(LogEventSource, $"Specified XML file could not be found: {XmlFilePath}");
                    return;
                }

                if (UseSystem != "live" && UseSystem != "test")
                {
                    LogWriter.WriteMessage(LogEventSource, $"2nd command line argument expects either \"live\" or \"test\", got: {UseSystem}");
                    return;
                }

                if (PortId.Substring(1, 1) != ":")
                {
                    LogWriter.WriteMessage(LogEventSource, $"Expected PortId should be an rss_bus.edi_path directory");
                    return;
                }

                gIDataEdi_path = GetIDedi_path(PortId);
                
                if(gIDataEdi_path == null)
                {
                    LogWriter.WriteMessage(LogEventSource, $"PortId not found: {PortId}");
                    return;
                }

                PortId_code = gIDataEdi_path["edi_code"].ToString().Substring(0, 3).ToUpper();
                wscie = PortId_code.Substring(0, 1);
                IDE = PortId_code.Substring(1, 2);
                arclient_ident = 30037;
                edi_doc_number = 850;
                EdiProcess = "Routing In 850";

                if (edi_doc_number == 850)
                {
                    Status += "Sending information out to a buyer (arclient)" + NL;
                    gIDataEdi_path = GetEdi_partner("edi_arclient");
                }
                else
                {
                    LogWriter.WriteMessage(LogEventSource, $"edi_doc_number not found: {edi_doc_number}");
                    return;
                }

                if (!vendor.After_Setup(false)) return;

                XMLProcessor_850 proc = new XMLProcessor_850();
                proc.ProcessOrder();
            }
            catch (Exception ex)
            {
                DB_RSS.LogData("ERROR: " + ex.ToString());
            }
            finally
            {
                DB_RSS.LogData(Status);
                DB_RSS.LogData(Status_Queries);
            }

        }

    }
}
