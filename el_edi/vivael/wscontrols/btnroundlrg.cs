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
    public partial class btnroundlrg: PictureBox
    {

        public btnroundlrg()
        {
            InitializeComponent();
        }

        private void LeftClick()
        {
            if (Tag.ToString() != "On1")
            {
                Image = Properties.Resources.BOUT_ON1;
                Tag = "On1";
            }
            else
            {
                Image = Properties.Resources.BOUT_OFF;
                Tag = "Off";
            }
        }

        private void RightClick()
        {
            if (Tag.ToString() != "On2")
            {
                Image = Properties.Resources.BOUT_ON2;
                Tag = "On2";
            }
            else
            {
                Image = Properties.Resources.BOUT_OFF;
                Tag = "Off";
            }
        }

        private void Btnroundlrg_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    LeftClick();
                    break;

                case MouseButtons.Right:
                    RightClick();
                    break;
            }
        }
    }
}
