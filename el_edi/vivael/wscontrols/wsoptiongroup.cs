using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpGroup;
using static vivael.Globals;

namespace vivael.wscontrols
{
    public partial class wsoptiongroup : OpGroup.OptionGroup, IDataControls
    {
        private string[] dataMember;
        public string State { get; set; }
        public string apControlSource { get; set; }
        public string apType { get; set; }
        public static DataSource source { get; set; }

        public wsoptiongroup()
        {
            InitializeComponent();
        }

        private void Wsoptiongroup_ValueChanged(object sender, EventArgs e)
        {
            dataMember = apControlSource.Split('.');
            source.SetProperty(ToTitleCase(dataMember[1]), ((wsoptiongroup)sender).Value);
        }
    }
}
