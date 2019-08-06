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
    public partial class wsCheckBox : CheckBox, IDataControls, WsControl
    {
        public string Text_EN { get; set; }
        public string Text_FR { get; set; }

        public string apControlSource { get; set; }
        public string apType { get; set; }
        public static DataSource source { get; set; }
        public wsCheckBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void WsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
             string[] dataMember;
            dataMember = apControlSource.Split('.');
            source.SetProperty(ToTitleCase(dataMember[1]), ((wsCheckBox)sender).Checked);
        }
    }
}
