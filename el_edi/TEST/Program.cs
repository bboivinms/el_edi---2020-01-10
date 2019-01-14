using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST
{
    class Program
    {
        public string string_val = "super_string haha";

        public void Tester()
        {
            // Grabs the integer by the variables name
            string test = (string)GetType().GetField("string_val").GetValue(this);

            MessageBox.Show(test);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());

            // Program mc = new Program();

            // mc.Tester();

        }
    }
}
