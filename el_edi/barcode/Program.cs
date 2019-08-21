using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.forms;

namespace barcode
{
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ffpapiercli());
        }
    }
}
