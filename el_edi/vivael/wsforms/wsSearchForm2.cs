using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static vivael.Globals;

namespace vivael.wsforms
{
    public partial class wsSearchForm2 : Form
    {
        public int DataSession = 2;
        public int RecordId = 0;
        public int SessionInstance = 0;
        public bool init_ok = true;
        public object Param = false;
        public object lIdent = false;
        public object cFunction = false;
        public bool fixcolor = false;
        public DataSource tableSource;
        private int WindowType = 1;
        private object Picture;

        public wsSearchForm2(DataSource dataSource)
        {
            InitializeComponent();
            tableSource = dataSource;
            gQuery(dataSource.MyQuery, dataSource, 0, 0, dataSource.isFoxpro);
            wsGrid1.DataSource = dataSource.ds.Tables[0];
            wsGrid1.ReadOnly = true;
        }

        public bool Init(string cParam, int nInstance)
        {
            if (!ISNULL(oSession) && TYPE(oSession) == typeof(object))
            {
                if (this.fixcolor == false) {
                    this.BackColor = oSession.WBackColor;
                    this.ForeColor = oSession.WForeColor;
                    this.Picture = oSession.WPicture;
                }
            }

            if (ISNULL(nInstance) || TYPE(nInstance) != typeof(int))
            {
                this.cFunction = "";
                this.SessionInstance = 0;
            }
            else
            {
                if (!EMPTY(nInstance))
                {
                    this.cFunction = oSession.active_form[nInstance-1, 1];
                    this.SessionInstance = nInstance-1;
                }
                else
                {
                    this.cFunction = "";
                    this.SessionInstance = 0;
                }
            }
            this.Param = cParam;

            //*Si modal on désactive tout les tools bars.
            if (this.WindowType == 1)
            {
                oSession.Disabled_bar(0);
            }

            this.doAfter_init();

            if (this.init_ok == false) {
                this.Destroy();
                this.Release();
                return false;
            }

            return true;
        }

        public virtual void doAfter_init()
        {
            //call in the child form
        }

        private void WsSearchForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //*Si modal on réactive tout les tool bar.
            if (this.WindowType == 1)
            {
                oSession.enabled_bar(0);
            }

            oSession.searchid = this.RecordId;
            oSession.Dispatch(this.Name);
        }

        public virtual void Destroy()
        {
           //nothing here
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            this.RecordId = RECNO(tableSource);
            this.Release();
        }

        public void Release()
        {
            Close();
        }

        private void BtnOk_OnClick()
        {
            if (wsGrid1.RowCount > 0)
            {
                this.RecordId = wsGrid1.CurrentCell.RowIndex;
            }
            else
                this.RecordId = RECNO(tableSource);

            this.DialogResult = DialogResult.OK;
            this.Release();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            BtnOk_OnClick();
        }

        private void WsGrid1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnOk_OnClick();
        }

        private void WsGrid1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnOk_OnClick();
        }

        public void FormMenu(string cType)
        {
            switch (ALLTRIM(cType))
            {
                case "P":
                    if (oSession.administrator)
                    {
                        if (!EMPTY(this.cFunction))
                        {
                            wsm1permis wsm1Permis = new wsm1permis();
                            wsm1Permis.Init(this.cFunction.ToString(), this.Text);
                            wsm1Permis.ShowDialog();
                        }
                        else
                        {
                            MESSAGEBOX(IIF(m0frch, "Cette fonction na pas besoin de permission!", "This function do not need permission!"), 16, IIF(m0frch, "Administrateur", "Administrator"));
                        }
                    }
                    else
                    {
                        MESSAGEBOX(IIF(m0frch, "Vous n'avez pas accès à cette fonction!", "You do not have access to this function!"), 16, IIF(m0frch, "Administrateur", "Administrator"));
                    }
                    break;
                case "H":

                    break;
                default:
                    break;
            }
        }

        private void WsSearchForm2_Click(object sender, EventArgs e)
        {
            if(MouseButtons == MouseButtons.Right)
            {
                MESSAGEBOX("Right click pressed");
                //DO wsformmenu.prg WITH THISFORM
            }
        }
    }
}
