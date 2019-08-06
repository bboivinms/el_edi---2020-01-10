using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.wsforms;
using static vivael.Globals;

namespace vivael.wsforms
{
    public partial class wsmaintform4 : DataMenu
    {
        public wsmaintform4()
        {
            InitializeComponent();
        }

        public void Dispatch()
        {
            //WIP
        }

        public void dobefore_release()
        {
            //WIP
        }

        public void Release()
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            /*
            /* SAVE WHEN ADD OR MOD MODE*/
            /* DELETE WHEN DEL MODE*/
            if (ALLTRIM(this.formaction) == "DEL" && (this.Text == "&Effacer" || this.Text == "&Delete"))
            {
                if(this.ActionDelete())
                {
                    this.Dispatch();
                    this.dobefore_release();
                    this.Release();
                }
            }
            else if (this.ActionSave())
            {
                this.Dispatch();
                this.dobefore_release();
                this.Release();
            }

        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            //*IF VIEW MODE, QUIT ONLY
            //* IF ADD / MOD MODE SAVE AND QUIT
            if (ALLTRIM(this.formaction) == "VIEW")
            {
                this.Release();
            }
            else
            {
                this.ActionUndo();
                this.Release();
            }
        }
    }
}
