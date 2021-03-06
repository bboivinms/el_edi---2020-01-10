﻿using EDICommons.Tools;
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
            if (UseSystem == "local") { IsLocalTest = true; Test_STEP_IN_855(); }
        }

        // Called by auto timer on 254 machine using parameters

        // Creates request to process modified 000
        // INSERT INTO edi_rss (rss_client, rss_request) VALUES ('ALL', '000P')
        // Creates tigger file : EdiFilename = IDedi_rss.ToString() + "-000P-ALL.txt";

        // Parameters
        // UseSystem            // Local // keeps the file locally in (C:\TMP\edi_test)
        //                      // Test  // dispatches the file in (\\192.168.1.252\edi_test) and is processed by RSSBus
        // Filename             // 000P-ALL to process all

        public void Test_855_STEP_1() { SetParams("Test", "edi_rss", @"E:\TEST_VIVA_ENV\CLIENT_ARIVA_DATA", "855P-ALL", "[ErrorMessage]", ""); } //script on 254 and foxpro
        // public void Test_810_STEP_1() { SetParams("Local", "edi_rss", @"C:\VIVAEL\DATA", "810P-ALL", ""); } //foxpro
         //public void Test_856_STEP_1() { SetParams("Test", "856", @"C:\VIVAEL\DATA", "856P-ALL", "[ErrorMessage]", ""); } //foxpro
        // public void Test_850_STEP_1() { SetParams("Local", "edi_rss", @"C:\VIVAEL\DATA", "850P-ALL", ""); } //done by foxpro

        // Activates Program_000 and stores corresponding 000 XML files in RSS_send_path (C:\TMP for Local)
        // CreateNew()          // Creates new records
        // UpdateExisting()     // Updates modified records
        // GetData()            // Get unsent records
        // Xml000Writer()       // Writes XML file to RSS_send_path
        // UpdateFilename()     // Updates new file name // @"UPDATE edi_000 SET filename = ?filename WHERE ident = ?edi_ident; ";

        // Parameters
        // Filename             // Starts with the corresponding IDedi_rss WHERE rss_done = 0

        public void Test_855_STEP_2() { SetParams("Local", "edi_rss", "ET_fox_to_rss", "110-855P-ALL.txt", "", ""); }
        public void Test_810_STEP_2() { SetParams("Local", "edi_rss", "ET_fox_to_rss", "3-810P-ALL.txt", "", ""); }
        public void Test_856_STEP_2() { SetParams("Local", "edi_rss", "ET_fox_to_rss", "1275-856P-ALL.txt", "", ""); }
        public void Test_850_STEP_2() { SetParams("Local", "edi_rss", "ET_fox_to_rss", "1648-850P-ALL", "", ""); }

        // Processes The filename to be set as sent that was processed in 000-STEP-2
        // edi_000.Sent = true WHERE Filename = { Filename }

        // Parameters
        // Filename             // Changes every time STEP-2 is processed, references a edi_000.Filename
        public void Test_STEP_IN() { SetParams("Local", "810", "MTL_routing_in", "2019-05-16-10-23-17-009145_000000019_151530263.xml", "", @"C:\TMP_IN\2019-05-16-10-23-17-009145_000000019_151530263.xml"); }
        public void Test_STEP_IN_850() { SetParams("Local", "850", "ETL_routing_in", "2019-06-12-15-48-26-6543211_111481215.xml", "", @"C:\TMP_IN\2019-06-12-15-48-26-6543211_111481215.xml"); }
        public void Test_STEP_IN_855() { SetParams("Live", "855", "MLE_routing_in", "MTI-Routing-IN-00056-855--POID-0-PO-059288-1565811434.8731.xml", "", @"C:\TMP_IN\MTI-Routing-IN-00056-855--POID-0-PO-059288-1565811434.8731.xml"); }
        public void Test_STEP_IN_856() { SetParams("Test", "856", "MTI_routing_in", "MTI-Routing-IN-00056-856--PO-4228069894-1565806355.24286.xml", "", @"C:\TMP_IN\MTI-Routing-IN-00056-856--PO-4228069894-1565806355.24286.xml"); }
        public void Test_855_STEP_3() { SetParams("Local", "855", "ETI_routing_out", "30037-855-12135-4501000073-1544798977.26278", "", ""); }
        public void Test_810_STEP_3() { SetParams("Local", "810", "NONE", "30037-12135-4501000073-1544798977.26278", "", ""); }
        public void Test_856_STEP_3() { SetParams("Local", "856", "NONE", "30037-12135-4501000073-1544798977.26278", "", ""); }
        public void Test_850_STEP_3() { SetParams("Local", "850", "MTL_routing_out", "00056-850-12135-4501000073-1544798977.26278", "", ""); }

    }
}