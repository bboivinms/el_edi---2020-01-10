using static vivael.Globals;
using MySQL_Dll;
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
using vivael.classes;

namespace vivael
{
     /****************************************************************************************
     *****************************************************************************************
     **                                                                                     **
     ** (c) Copyright 2019 Multi-Services GSTJ inc.                                         **
     **                                                                                     **
     *****************************************************************************************
     *****************************************************************************************
     *****************************************************************************************
     ** Pgm   : Vivael                                                                      **
     ** Desc. : Main program for VIVASoft Envl project                                      **
     *****************************************************************************************
     ** To remove when live or when test report mysql                                       **
     ** reportDocument.DataSourceConnections.Clear();                                       **
     ** reportDocument.DataSourceConnections[0].SetConnection(@"C:\vivael\data", "", false);** 
     ****************************************************************************************/
    static class Program
    {
        private static MySQL_Dll.Main pMySQL_Dll = new MySQL_Dll.Main();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            pMySQL_Dll.Load_DB("", @"C:\Vivael\Data");
            //gCreateFoxMysql_proc();
            StartFoxproForm();
        }

        static public void StartFoxproForm()
        {

            oSession = new WsSession();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //wsemailinfo wsemailinfo = new wsemailinfo();
            //wsemailinfo.Init(204);
            if (oSession.opened == true)
            {
                oSession.Logon();
                if (EMPTY(oSession.UserCode))
                {
                    oSession.opened = false;
                }
            }

            //*oSession.wich_email = "CDOSYS"

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

                oPrintForm = new wsPrintForm();
                oPrintForm.cFormCode = "LISTIMPRIM";

                menu = new VivaMainWindow();
                menu.SetSession(oSession);
                Application.Run(menu);
            }

        }

        private static void ConsolePrint(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
