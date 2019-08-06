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
    public partial class wslink : LinkLabel, WsControl
    {
        /*-- Put to true to keep the color as set regardless user's selection*/
        private bool FixColor = false;
        private Color orig_fcolor;
        private Color highlight_fcolor = Color.FromArgb(255, 0, 0);

        public string Text_EN { get; set; }
        public string Text_FR { get; set; }

        public wslink()
        {
            InitializeComponent();
        }

        public void Init()
        {
            if (TYPE(oSession) == typeof(object) && !ISNULL(oSession))
            {
                if (!FixColor)
                {
                    BackColor = oSession.LBackColor;
                    ForeColor = oSession.LForeColor;

                    if (!Enabled)
                    {
                        BackColor = oSession.LdisabledBackColor;
                        ForeColor = oSession.LdisabledForeColor;
                    }
                }
            }
            this.orig_fcolor = this.ForeColor;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void Wslink_MouseLeave(object sender, EventArgs e)
        {
            this.ForeColor = this.orig_fcolor;
        }

        private void Wslink_MouseEnter(object sender, EventArgs e)
        {
            this.ForeColor = this.highlight_fcolor;
        }
    }
}
