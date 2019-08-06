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
                        if(item is wsToolStripMenuItem)
                        {
                            wsToolStripMenuItem btnMenu = (wsToolStripMenuItem)item;

                            if (btnMenu.Text_EN != null && btnMenu.Text_FR != null)
                                btnMenu.Text = IIF(m0frch, btnMenu.Text_FR, btnMenu.Text_EN);
                        }
                    }
                }

                if (menuItem is wsToolStripMenuItem)
                {
                    if(menuItem.Text_EN != null && menuItem.Text_FR != null)
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
            wsmuser2 form = new wsmuser2();
            form.MdiParent = this;
            form.Init("wsmuser2", " ");
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //******Method for Testing form only******
        private void WsToolStripButton1_Click(object sender, EventArgs e)
        {
            wsmaintform5 test = new wsmaintform5();
            test.MdiParent = this;
            test.Init("wsmaintform5", " ");
        }
    }
}
