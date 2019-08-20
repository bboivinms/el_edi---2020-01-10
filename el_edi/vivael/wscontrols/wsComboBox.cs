using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vivael.wscontrols
{
    public partial class wsComboBox : ComboBox, IDataControls
    {
        private const int WM_ENABLE = 0x000A;

        public string apControlSource { get; set; }
        public string apType { get; set; }
        public bool BoundTo { get; set; }  = true;
        public bool lenabledisable { get; set; } = true;
        public wsComboBox()
        {
            InitializeComponent();
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                // The WM_ACTIVATEAPP message occurs when the application
                // becomes the active application or becomes inactive.
                case WM_ENABLE:
                    if (this.Enabled) { base.WndProc(ref m); }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
            
        }

        private void Control1_HandleCreated(Object sender, EventArgs e)
        {

            this.Enabled = !this.Enabled;
            this.Enabled = !this.Enabled;

        }
    }
}
