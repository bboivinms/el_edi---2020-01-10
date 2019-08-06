using static vivael.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.forms;
using static EDI_DB.Data.Base;
using EDI_RSS;
using System.IO;
using vivael.wsforms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

namespace vivael
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            gConnect(); //Connect to DB with datapath

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new wsmaintform5());

            oSession = new WsSession();

            if (oSession.opened == true)
            {
                oSession.Logon();
                if (oSession.UserCode == null)
                {
                    oSession.opened = false;
                }
            }

            if (oSession.opened == true)
            {
                oSession.curapplication = "VIVASoft2.0";
                oSession.nocheckcredit = false;

                if (oSession.date_format == "DMY")
                {
                    //SET DATE DMY
                }
                else
                {
                    //SET DATE MDY
                }

                VivaMainWindow menu = new VivaMainWindow();
                menu.SetSession(oSession);
                Application.Run(menu);
            }

            //wsmuser2 form = new wsmuser2();
            //Application.Run(form);
            //form.Init("wsmuser2", " ");

            //ReportDocument reportDocument = new ReportDocument();
            ////reportDocument.Load(@"\\Kkpg\e\programmation\Kevin\Liste de prix par client rev2.3 pour préavis augmentation-2.rpt");
            //reportDocument.Load(@"\\Kkpg\e\programmation\Remi\Liste des imprimeurs avec code FSC.rpt");

            //reportDocument.DataSourceConnections.Clear();
            //reportDocument.DataSourceConnections[0].SetConnection(@"C:\vivael\data", "", false);

            //ReportPreview preview = new ReportPreview(reportDocument);
            //Application.Run(preview);
        }
    }
}
