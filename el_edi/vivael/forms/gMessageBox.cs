using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vivael
{
    public partial class gMessageBox : Form
    {
        public int vNDialogBoxType = 0;
        public string vCTitleBarText = "";
        public string eMessageText = "";
        public int? vNTimeout = null;

        public gMessageBox(string titlebar = "", string message = "", int? timeout = null)
        {
            InitializeComponent();
            this.Text = titlebar;
            this.lblMessage.Text = message;
            vNTimeout = timeout;
            this.ShowDialog();
        }

        private void GMessageBox_Load(object sender, EventArgs e)
        {
            if(vNTimeout != null)
            {
                _ = CloseAfterDelay((int)vNTimeout);
            }
        }

        public async Task CloseAfterDelay(int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
            this.Close();
        }
    }
}