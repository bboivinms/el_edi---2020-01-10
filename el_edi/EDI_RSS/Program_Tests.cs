using EDICommons.Tools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDICommons;
using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public partial class Program_RSS
    {
        public void Test()
        {
            if (UseSystem == "local") { IsLocalTest = true; Test_810_STEP_2(); }
        }

        // Called by auto timer on 254 machine using parameters

        // Creates request to process modified 000
        // INSERT INTO edi_rss (rss_client, rss_request) VALUES ('ALL', '000P')
        // Creates tigger file : EdiFilename = IDedi_rss.ToString() + "-000P-ALL.txt";

        // Parameters
        // UseSystem            // Local // keeps the file locally in (C:\TMP\edi_test)
        //                      // Test  // dispatches the file in (\\192.168.1.252\edi_test) and is processed by RSSBus
        // Filename             // 000P-ALL to process all

        public void Test_855_STEP_1() { SetParams("Local", "edi_rss", "NONE", "855P-ALL", ""); }
        public void Test_810_STEP_1() { SetParams("Local", "edi_rss", "NONE", "810P-ALL", ""); }

        // Activates Program_000 and stores corresponding 000 XML files in RSS_send_path (C:\TMP for Local)
        // CreateNew()          // Creates new records
        // UpdateExisting()     // Updates modified records
        // GetData()            // Get unsent records
        // Xml000Writer()       // Writes XML file to RSS_send_path
        // UpdateFilename()     // Updates new file name // @"UPDATE edi_000 SET filename = ?filename WHERE ident = ?edi_ident; ";

        // Parameters
        // Filename             // Starts with the corresponding IDedi_rss WHERE rss_done = 0

        public void Test_855_STEP_2() { SetParams("Local", "edi_rss", "NONE", "13-855P-ALL.txt", ""); }
        public void Test_810_STEP_2() { SetParams("Local", "edi_rss", "NONE", "2-810P-ALL.txt", ""); }

        // Processes The filename to be set as sent that was processed in 000-STEP-2
        // edi_000.Sent = true WHERE Filename = { Filename }

        // Parameters
        // Filename             // Changes every time STEP-2 is processed, references a edi_000.Filename
        public void Test_855_STEP_3() { SetParams("Local", "855", "NONE", "30037-12135-4501000073-1544798977.26278", ""); }
        public void Test_810_STEP_3() { SetParams("Local", "810", "NONE", "30037-12135-4501000073-1544798977.26278", ""); }

    }
}