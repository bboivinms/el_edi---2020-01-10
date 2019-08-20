using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.wscontrols;
using static vivael.Globals;

namespace vivael.wsforms
{
    public partial class wsPrint : Form
    {
        private string ParentScreen = "";
        public string Action = "Q";
        private object Picture;
        public int WindowType { get; set; } = 1;

        public wsPrint(string pParentScreen, string pOptions)
        {
            InitializeComponent();
            Text = (IIF(m0frch, "Impression", "Reporting"));

            Init(pParentScreen, pOptions);
        }

        
         public void Init(string pParentScreen, string pOptions)
        { 
		    if(TYPE(oSession) == typeof(object) && !ISNULL(oSession))
            {
                this.BackColor = oSession.WBackColor;
                this.ForeColor = oSession.WForeColor;
                this.Picture = oSession.WPicture;
            }

            //* Si modal on désactive tout les tools bars.
            if (this.WindowType == 1)
                oSession.Disabled_bar(0);

            this.ParentScreen = pParentScreen.ToString();

            if (pOptions == "") //&& Not passed
                pOptions = "VP"; 

	        if(pOptions.ToString().Contains("V")) 
			    this.BtnView.Enabled = true;
            else
                this.BtnView.Enabled = false;
		    
		    if(pOptions.ToString().Contains("P"))
			    this.BtnPrint.Enabled = true;
            else
                this.BtnPrint.Enabled = false;

            if (pOptions.ToString().Contains("F") || pOptions.ToString().Contains("E") || pOptions.ToString().Contains("X"))
            {
                this.BtnFax.Visible = true;
                this.BtnEmail.Visible = true;
                this.BtnExport.Visible = true;
            }
            else
            {
                this.BtnFax.Visible = false;
                this.BtnEmail.Visible = false;
                this.BtnExport.Visible = false;
            }

            if (pOptions.ToString().Contains("F"))
                this.BtnFax.Enabled = true;
            else
                this.BtnFax.Enabled = false;

            if (pOptions.ToString().Contains("E"))
                this.BtnEmail.Enabled = true;
            else
                this.BtnEmail.Enabled = false;

            if (pOptions.ToString().Contains("X"))
                this.BtnExport.Enabled = true;
            else
                this.BtnExport.Enabled = false;

            PrinterSettings settings = new PrinterSettings();
            this.ScnCurPrinter.Text = settings.PrinterName; //SET('PRINTER', 3)
         }

        public new void Show()
        {
            if(WindowType == 1)
                this.ShowDialog();
            else
                base.Show();
        }

        public void Formmenu()
        {
            //WIP
        }

        public void RELEASE()
        {
            Close();
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            Action = "V";
            RELEASE();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Action = "P";
            RELEASE();
        }

        private void BtnFax_Click(object sender, EventArgs e)
        {
            Action = "F";
            RELEASE();
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            Action = "E";
            RELEASE();
        }

        private void Wscommandbutton1_Click(object sender, EventArgs e)
        {
            Action = "Q";
            RELEASE();
        }

        private void Wscommandbutton2_Click(object sender, EventArgs e)
        {
            string lcPrinter = GETPRINTER();
            ScnCurPrinter.Text = lcPrinter;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            Action = "X";
            RELEASE();
        }
    }
}
