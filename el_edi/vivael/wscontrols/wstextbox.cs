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
    public partial class wstextbox : TextBox,  IDataControls
    {

        public string State { get; set; }
        public string apControlSource { get; set; }
        public string apType { get; set; }

        public wstextbox()
        {
            InitializeComponent();
        }
    }
}
