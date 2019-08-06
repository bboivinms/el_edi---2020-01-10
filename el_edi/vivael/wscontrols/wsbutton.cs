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
    public partial class wsbutton : Button, WsControl
    {
        public string Text_EN { get; set; }
        public string Text_FR { get; set; }

        public wsbutton()
        {
            InitializeComponent();
        }

        //[System.Diagnostics.DebuggerStepThrough]
        //protected override void OnPaint(PaintEventArgs pe)
        //{
        //    base.OnPaint(pe);
        //}
    }
}
