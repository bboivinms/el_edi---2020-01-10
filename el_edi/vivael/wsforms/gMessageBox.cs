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
        private Button btnOk;

        public int vNDialogBoxType = 0;
        public string vCTitleBarText = "";
        public string eMessageText = "";
        public int? vNTimeout = null;
        public int Return;

        public gMessageBox()
        {
            InitializeComponent();
        }

        private void GMessageBox_Load(object sender, EventArgs e)
        {
            this.Text = vCTitleBarText;
            this.lblMessage.Text = eMessageText;
            Return = -1;

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

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Return = 1;
            this.Close();
        }

        private void LblMessage_Resize(object sender, EventArgs e)
        {
            if(this.Width < lblMessage.Width)
            {
                Width = lblMessage.Width + 30;
            }
        }

    }
}