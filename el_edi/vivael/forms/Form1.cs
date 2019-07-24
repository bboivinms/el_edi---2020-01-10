using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static vivael.Globals;

namespace vivael.forms
{
    public partial class Form1 : vivael.Wsmaintform2
    {
        private data_wsuser wsuser = new data_wsuser();

        public Form1()
        {
            InitializeComponent();
            SetQuery("SELECT * FROM wsuser", 0, 1, wsuser);
            sdPTable = wsuser;

            if (IsFirst(wsuser))
            {
                BtnFirst.Enabled = false;
                BtnPrev.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {


                FileToScreen();

                foreach (Control control in this.Controls)
                {
                    bindControl(control, wsuser);
                }

            }
            catch (Exception ex) { string x = ex.ToString(); }
        }

        public override void FileToScreen()
        {
            wsuser.LoadRow();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Console.Clear();
            gCreateUpdate(wsuser);
            //wsuser.SaveRow();
        }
    }
}
