using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using vivael;
using vivael.wsforms;
using static vivael.Globals;

namespace vivael.forms
{
    public partial class ffscontactemail : wsSearchForm2
    {
        public data_ffcontact cTemp1 { get; set; } = new data_ffcontact();
        public string Alpha { get; set; }
        public string Email { get; set; }
        public string query { get; set; } = "";
        public string orderby { get; set; } = "";

        public ffscontactemail()
        {
            InitializeComponent();
            Text = IIF(m0frch, "Recherche d'un courriel", "E-mail search");
            wsGrid1.Columns[0].HeaderText = IIF(m0frch, "Nom de contact", "Contact name");
            wsGrid1.Columns[1].HeaderText = IIF(m0frch, "Courriel", "E-mail ");
            TranslateForm(this);
        }

        private void Get_data()
        {
            WAIT("Busy loading data...", "WINDOW NOWAIT");
            this.wsGrid1.DataSource = "";
            this.doAfter_init();
        }

        public override void doAfter_init()
        {
            this.Btn_Ok.Enabled = true;
            this.wsGrid1.DataSource = "";

            if (EMPTY(this.Alpha))
            {
                query = $@"SELECT name, email FROM ffcontact
                           WHERE !EMPTY(email)
                           ORDER BY name asc";
                query = query.Replace("\r\n", "");

                gQuery(query, cTemp1, 0, 0, cTemp1.isFoxpro);

                if (cTemp1.RECCOUNT() <= 0)
                {
                    this.Btn_Ok.Enabled = false;
                }
            }
            else
            {
                if (!EMPTY(this.ScnSearch.Text) && this.Alpha == "1")
                {
                    query = $@"SELECT name, email FROM ffcontact
                                WHERE !EMPTY(email)
                                AND ALLTRIM(UPPER({Q2(this.ScnSearch.Text)}))$ UPPER(ffcontact.name)
                                ORDER BY name asc";

                    query = query.Replace("\r\n", "");
                    gQuery(query, cTemp1, 0, 0, cTemp1.isFoxpro);
                }
                else
                {
                    query = $@"SELECT name, email FROM ffcontact
                               WHERE !EMPTY(email)
                               AND UPPER(SUBSTR(ffcontact.name,1,1)) = UPPER({Q2(this.Alpha)})
                               ORDER BY name asc";
                    query = query.Replace("\r\n", "");
                    gQuery(query, cTemp1, 0, 0, cTemp1.isFoxpro);
                }

                if (cTemp1.RECCOUNT() <= 0)
                {
                    this.Btn_Ok.Enabled = false;
                }
            }

            this.wsGrid1.Refresh();

            if (cTemp1.ds.Tables.Count > 0)
            {
                this.wsGrid1.DataSource = cTemp1.ds.Tables[0];
                this.wsGrid1.Columns[0].DataPropertyName = "name";
                this.wsGrid1.Columns[1].DataPropertyName = "email";
            }

        }

        private void Wscommandbutton2_Click(object sender, EventArgs e)
        {
            this.Alpha = "A";
            this.Get_data();
        }

        private void Wscommandbutton3_Click(object sender, EventArgs e)
        {
            this.Alpha = "B";
            this.Get_data();
        }

        private void Wscommandbutton1_Click(object sender, EventArgs e)
        {
            this.Alpha = "C";
            this.Get_data();
        }

        private void Wscommandbutton6_Click(object sender, EventArgs e)
        {
            this.Alpha = "D";
            this.Get_data();
        }

        private void Wscommandbutton5_Click(object sender, EventArgs e)
        {
            this.Alpha = "E";
            this.Get_data();
        }

        private void Wscommandbutton4_Click(object sender, EventArgs e)
        {
            this.Alpha = "F";
            this.Get_data();
        }

        private void Wscommandbutton12_Click(object sender, EventArgs e)
        {
            this.Alpha = "G";
            this.Get_data();
        }

        private void Wscommandbutton11_Click(object sender, EventArgs e)
        {
            this.Alpha = "H";
            this.Get_data();
        }

        private void Wscommandbutton10_Click(object sender, EventArgs e)
        {
            this.Alpha = "I";
            this.Get_data();
        }

        private void Wscommandbutton9_Click(object sender, EventArgs e)
        {
            this.Alpha = "J";
            this.Get_data();
        }

        private void Wscommandbutton8_Click(object sender, EventArgs e)
        {
            this.Alpha = "K";
            this.Get_data();
        }

        private void Wscommandbutton7_Click(object sender, EventArgs e)
        {
            this.Alpha = "L";
            this.Get_data();
        }

        private void Wscommandbutton24_Click(object sender, EventArgs e)
        {
            this.Alpha = "M";
            this.Get_data();
        }

        private void Wscommandbutton23_Click(object sender, EventArgs e)
        {
            this.Alpha = "N";
            this.Get_data();
        }

        private void Wscommandbutton22_Click(object sender, EventArgs e)
        {
            this.Alpha = "O";
            this.Get_data();
        }

        private void Wscommandbutton21_Click(object sender, EventArgs e)
        {
            this.Alpha = "P";
            this.Get_data();
        }

        private void Wscommandbutton20_Click(object sender, EventArgs e)
        {
            this.Alpha = "Q";
            this.Get_data();
        }

        private void Wscommandbutton19_Click(object sender, EventArgs e)
        {
            this.Alpha = "R";
            this.Get_data();
        }

        private void Wscommandbutton18_Click(object sender, EventArgs e)
        {
            this.Alpha = "S";
            this.Get_data();
        }

        private void Wscommandbutton17_Click(object sender, EventArgs e)
        {
            this.Alpha = "T";
            this.Get_data();
        }

        private void Wscommandbutton16_Click(object sender, EventArgs e)
        {
            this.Alpha = "U";
            this.Get_data();
        }

        private void Wscommandbutton15_Click(object sender, EventArgs e)
        {
            this.Alpha = "V";
            this.Get_data();
        }

        private void Wscommandbutton14_Click(object sender, EventArgs e)
        {
            this.Alpha = "W";
            this.Get_data();
        }

        private void Wscommandbutton13_Click(object sender, EventArgs e)
        {
            this.Alpha = "X";
            this.Get_data();
        }

        private void Wscommandbutton25_Click(object sender, EventArgs e)
        {
            this.Alpha = "Y";
            this.Get_data();
        }

        private void Wscommandbutton26_Click(object sender, EventArgs e)
        {
            this.Alpha = "Z";
            this.Get_data();
        }

        private void Wscommandbutton27_Click(object sender, EventArgs e)
        {
            this.Alpha = "";
            this.Get_data();
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            this.Alpha = "1";
            this.Get_data();
        }

        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            BtnOk_OnClick();
        }

        private void Btn_cancel_Click(object sender, EventArgs e)
        {
            BtnCancel_OnClick();
        }

        private void ScnSearch_Leave(object sender, EventArgs e)
        {
            this.Alpha = "1";
            this.Get_data();
        }

        public override void BtnOk_OnClick()
        {
            this.Email = wsGrid1.CurrentRow.Cells[1].FormattedValue.ToString();
            this.Release();
        }

        public override void BtnCancel_OnClick()
        {
            this.Email = "";
            this.Release();
        }
    }
}
