using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static vivael.Globals;

namespace vivael.wscontrols
{
    public partial class Wsbtnsearch : Commandbutton
    {
        public Wsbtnsearch()
        {
            InitializeComponent();
            if (this.Enabled)
            {
                this.Image = Properties.Resources.LOOK;
            }
            else
            {
                this.Image = Properties.Resources.Lookx;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void Wsbtnsearch_EnabledChanged(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                this.Image = Properties.Resources.LOOK;
            }
            else
            {
                this.Image = Properties.Resources.Lookx;
            }
            
        }
    }
}
