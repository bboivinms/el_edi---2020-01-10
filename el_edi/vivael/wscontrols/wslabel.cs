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
    public partial class wslabel : Label, WsControl
    {
        /*-- Put to true to keep the color as set regardless user's selection*/
        private bool FixColor = false;

        public string Text_EN { get; set; }
        public string Text_FR { get; set; }

        public wslabel()
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

                    if(!Enabled)
                    {
                        BackColor = oSession.LdisabledBackColor;
                        ForeColor = oSession.LdisabledForeColor;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
