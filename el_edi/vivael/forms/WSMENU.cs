using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vivael.wsforms
{
    public partial class WSMENU : Form
    {
        public WSMENU()
        {
            InitializeComponent();

            SetMenu(1);
        }

        public void SetMenu(int MenuNumber)
        {
            tabControl1.Top = 0;
            tabControl2.Top = 0;

            tabControl1.Visible = MenuNumber == 1;
            tabControl2.Visible = MenuNumber == 2;
        }

        private void WSMENU_Load(object sender, EventArgs e)
        {

        }
    }
}
