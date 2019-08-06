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
    public partial class btnroundsml: PictureBox
    {

        public btnroundsml()
        {
            InitializeComponent();
        }

        private void LeftClick()
        {
            if (Tag.ToString() != "V")
            {
                Image = Properties.Resources.BT_GREEN;
                Tag = "V";
            }
            else
            {
                Image = Properties.Resources.BT_GREY;
                Tag = "G";
            }
        }

        private void RightClick()
        {
            if (Tag.ToString() != "R")
            {
                Image = Properties.Resources.BT_RED;
                Tag = "R";
            }
            else
            {
                Image = Properties.Resources.BT_GREY;
                Tag = "G";
            }
        }

        private void Btnroundsml_MouseClick(object sender, MouseEventArgs e)
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
