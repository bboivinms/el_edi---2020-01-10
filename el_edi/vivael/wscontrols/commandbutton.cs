using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vivael.wscontrols
{
    public partial class Commandbutton : Button, WsControl
    {
        public string Text_EN { get; set; }
        public string Text_FR { get; set; }

        public string ToolTipText { get; set; }
        ToolTip btn_toolTip;

        public Commandbutton()
        {
            InitializeComponent();
            btn_toolTip = new ToolTip();
        }

        /// <summary>
        /// When mouse user leave the button hide TooltipText
        /// </summary>
        private void Commandbutton_MouseLeave(object sender, EventArgs e)
        {
            if (ToolTipText != "")
            {
                btn_toolTip.Hide(this);
            }
        }

        /// <summary>
        /// When mouse user enter the button, show TooltipText
        /// </summary>
        private void Commandbutton_MouseEnter(object sender, EventArgs e)
        {
            if (ToolTipText != "")
            {
                btn_toolTip.Show(ToolTipText, this);
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
