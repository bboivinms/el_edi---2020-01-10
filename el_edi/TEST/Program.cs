using EDI_RSS;
using System;
using System.IO;
using System.Windows.Forms;
using static EDI_DB.Data.Base;

namespace TEST
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {

            vendor = new EDI_RSS.Vendor();
            DB_RSS = new EDI_DB.Data.CDB_RSS(vendor.SetupRSS("rss_bus"));

            string datapath = @"C:\Vivael\Data";

            //avec le datapath, on connect avec la bonne DB
            gIDataEdi_path = GetIDedi_path(datapath);
            
            if (!vendor.Edi_path_after_Setup()) return; //setup connection DB 
            UseSystem = "test";

            ClassGenerator.Generate("wsseq");
            Console.ReadKey();
            //Email810Writer email810 = new Email810Writer("1559678249,74847");

            //email810.Build();

            //email810.Send();

            //Email855Writer email855 = new Email855Writer("1560286398.67263");

            //email855.Build();

            //email855.Send();

            //Email856Writer email856 = new Email856Writer("1560187197.61072");

            //email856.Build();

            //email856.Send();

            //Main main = new Main();
            //string message = main.MySQL(@"C:\VIVAEL\DATA", 30037, 219, 856);
            // main.MySQL(@"C:\VivaStock2\Data", 1254, 33235, 850);


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }

        public static object IsNull(object value)
        {
            if (value == null)
            {
                return 0;
            }

            return value;
        }
    }
}
