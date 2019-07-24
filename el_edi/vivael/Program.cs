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
            //Application.Run(new Form1());

            oSession = new WsSession();
            Form1 form = new Form1();
            form.Init("popo", " ");
        }
    }
}
