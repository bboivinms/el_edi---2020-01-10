using MySQL_Dll;
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
            Main main = new Main();

            main.Load_DB(@"C:\vivastock2\data");
            /*
            main.MySQL(56, 33268, 850, @"<root>
<item>
<idprod>36693</idprod>
<line>1</line>
<code_pal>P2-01</code_pal>
<longueur>47</longueur>
<largeur>31</largeur>
<hauteur>45</hauteur>
<MSG1></MSG1></item></root>", ""); */

            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());

            // Program mc = new Program();

            // mc.Tester();

        }
    }
}
