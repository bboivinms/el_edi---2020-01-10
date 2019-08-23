using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using vivael.wscontrols;
using vivael.wsforms;
using static vivael.Globals;

namespace vivael.forms
{
    public partial class VivaMainWindow : Form
    {
        private WsSession Session;

        public VivaMainWindow()
        {
            InitializeComponent();
            TranslateMenu();
        }

        private void VivaMainWindow_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is MdiClient)
                {
                    ctrl.BackColor = Color.FromArgb(63, 71, 204);
                }
            }
        }

        public void SetSession(WsSession aSession)
        {
            Session = aSession;
        }

        private void TranslateMenu()
        {
            foreach (wsToolStripMenuItem menuItem in menuStrip.Items)  //Loop through the itemMenu
            {
                if (menuItem.HasDropDownItems)
                {
                    foreach (ToolStripItem item in menuItem.DropDownItems)
                    {
                        if (item is wsToolStripMenuItem)
                        {
                            wsToolStripMenuItem btnMenu = (wsToolStripMenuItem)item;

                            if (btnMenu.Text_EN != null && btnMenu.Text_FR != null)
                                btnMenu.Text = IIF(m0frch, btnMenu.Text_FR, btnMenu.Text_EN);
                        }
                    }
                }

                if (menuItem is wsToolStripMenuItem)
                {
                    if (menuItem.Text_EN != null && menuItem.Text_FR != null)
                        menuItem.Text = IIF(m0frch, menuItem.Text_FR, menuItem.Text_EN);
                }
            }

            foreach (WsToolStripButton button in toolStrip.Items)  //Loop through the buttonMenu
            {
                if (button is WsToolStripButton)
                {
                    if (button.Text_EN != null && button.Text_FR != null)
                        button.Text = IIF(m0frch, button.Text_FR, button.Text_EN);
                }
            }
        }

        private void Btn_aPropos_Click(object sender, EventArgs e)
        {
            Process.Start("http://multi-services.org/");
        }

        private void Btn_utilisateurs_Click(object sender, EventArgs e)
        {
            //wsmuser2 wsmuser2 = new wsmuser2();
            //wsmuser2.MdiParent = this;
            //wsmuser2.Init("wsmuser2", " ");
            oSession.Launch_Form("wsmuser2", " ", 0, false);
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReprésentantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //armrep armrep = new armrep();
            //armrep.MdiParent = this;
            //armrep.Init("armrep", " ");
            oSession.Launch_Form("armrep", " ", 0, false);
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            //wsprintform wsprintform = new wsprintform();
            //wsprintform.MdiParent = this;
            //wsprintform.Show();
            oPrintForm.Print("LISTIMPRIM", "lcCursorName", "VPFE," + STR(1000));
        }

        private void VivaMainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F1)
            { 
                XXALTF1();
            }
        }
    }
}
   
