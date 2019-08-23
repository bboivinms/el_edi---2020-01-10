using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static vivael.Globals;
using vivael;
using vivael.wsforms;

namespace barcode.forms
{
    public partial class wsprintformpc : wsform
    {
        public wsprintformpc()
        {
            InitializeComponent();
            TranslateForm(this);
            this.cntprintform21.Init();
        }

        public override void dobefore_init()
        {
            //* Allowed actions
            if (oPrintForm.cOptions.ToString().Contains("V"))
                this.BtnView.Enabled = true;
            else
                this.BtnView.Enabled = false;

            if (oPrintForm.cOptions.ToString().Contains("P"))
                this.BtnPrint.Enabled = true;
            else
                this.BtnPrint.Enabled = false;

            if (oPrintForm.cOptions.ToString().Contains("F"))
                this.BtnFax.Enabled = true;
            else
                this.BtnFax.Enabled = false;

            if (oPrintForm.cOptions.ToString().Contains("E"))
                this.BtnEmail.Enabled = true;
            else
                this.BtnEmail.Enabled = false;

            if (oPrintForm.cOptions.ToString().Contains("B"))
            {
                this.BtnBasket.Enabled = true;
                this.BtnViewBasket.Enabled = true;
            }
            else
            {
                this.BtnBasket.Enabled = false;
                this.BtnViewBasket.Enabled = false;
            }

            if (oPrintForm.cOptions.ToString().Contains("X"))
            {
                this.BtnExport.Enabled = true;
            }
            else
            {
                this.BtnExport.Enabled = false;
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            oPrintForm.SelectAction("V");
        }

        private void BtnPrint2_Click(object sender, EventArgs e)
        {
            oPrintForm.SelectAction("p");
            if(oPrintForm.lBatchFirst == false)
            {
                this.RELEASE();
            }
        }

        private void BtnFax_Click(object sender, EventArgs e)
        {
            //NOT USED TODAY
            //oPrintForm.SelectAction("F");
        }

        private void BtnEmail_Click(object sender, EventArgs e)
        {
            oPrintForm.SelectAction("E");
        }

        private void Wscommandbutton1_Click(object sender, EventArgs e)
        {
            RELEASE();
        }

        private void Wscommandbutton2_Click(object sender, EventArgs e)
        {
            string lcPrinter = GETPRINTER();
            this.cntprintform21.lblCurPrint.Text = lcPrinter;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            oPrintForm.SelectAction("X");
        }

        private void BtnBasket_Click(object sender, EventArgs e)
        {
            //NOT USED
            //if (!EMPTY(oSession.basket_active))
            //{
            //    //DO FORM wsbasketx2
            //    if (oPrintForm.AddToBasket)
            //    {
            //        oPrintForm.SelectAction("B");
            //    }

            //    oPrintForm.AddToBasket = false;
            //}
            //else
            //{
            //    MESSAGEBOX(IIF(m0frch, "Basket non defini!", "Basket not defined!"), 16, "");
            //}

        }

        private void BtnViewBasket_Click(object sender, EventArgs e)
        {
            //NOT USED
            //oSession.Shellexec(ALLTRIM(oPrintForm.cBasketDir));
        }
    }
}
