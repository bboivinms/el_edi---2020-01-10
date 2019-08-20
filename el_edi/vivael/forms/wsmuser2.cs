using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using vivael.wscontrols;
using vivael.wsforms;
using static vivael.Globals;

namespace vivael.forms
{
    public partial class wsmuser2 : wsmaintform2
    {
        private data_wsuser wsuser = new data_wsuser();
        private data_wsgroup wsgroup = new data_wsgroup();
        private data_arrep arrep = new data_arrep();
        private data_wslang wslang = new data_wslang();

        public wsmuser2()
        {
            InitializeComponent();
            TranslateForm(this);

            wsCheckBox.source = wsoptiongroup.source = wsnumbox.source = wsuser;

            SetQuery("SELECT * FROM wsuser", 0, 1, wsuser);
            sdPTable = wsuser;

            if (IsFirst(wsuser))
            {
                BtnFirst.Enabled = false;
                BtnPrev.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                FileToScreen();

                FillComboBoxWithData(wsgroup, wsComboBox1, "DESC", "CODE"); //fill combobox1 with the wsgroup table data
                FillComboBoxWithData(arrep, wsComboBox4, "NAME", "IDENT"); //fill combobox4 with the arrep table data
                FillComboBoxWithData(wslang, wsComboBox3, "DESCR", "CODE"); //fill combobox3 with the wslang table data
                wsComboBox2.Items.AddRange(new string[] { "", "Accounting", "Management", "Operation", "Sales" });

                bindControls(wsuser, this);

            }
            catch (Exception ex) { string x = ex.ToString(); }
        }

        public override void FileToScreen()
        {
            wsuser.LoadRow();
        }

        public void FillComboBoxWithData(DataSource source, wsComboBox comboBox, string display ="", string value = "")
        {
            source.ds = gQuery("SELECT " + display + ", " + value + " FROM " + source.i.name, source, 0, 0, source.isFoxpro);

            comboBox.DisplayMember = display;

            comboBox.ValueMember = value;

            DataRow row = source.ds.Tables[0].NewRow();
            row[display] = "";
            row[value] = "";
            source.ds.Tables[0].Rows.InsertAt(row, 0);

            comboBox.DataSource = source.ds.Tables[0];
        }

        public override bool Valid_sav()
        {
            if (EMPTY(txtCode.Text))
            {
                MESSAGEBOX(IIF(m0frch, "Un code est obligatoire", "A code is mandatory"), 0 + 16, "");
                this.txtCode.Focus();
	            return false;
            }
            if (EMPTY(txtName.Text))
            {
                MESSAGEBOX(IIF(m0frch, "Un nom est obligatoire", "A name is mandatory"), 0 + 16, "");
                txtName.Focus();
                return false;
            }
            if (EMPTY(txtPasswd.Text))
            {
                MESSAGEBOX(IIF(m0frch, "Un mot de passe est obligatoire", "A password is mandatory"), 0 + 16, "");
                this.txtPasswd.Focus();
                return false;
            }
            return true;
        }

        public override void doBefore_new()
        {
            wsuser.ResetProperties();
        }

        public override void doAfter_new()
        {
            wsuser.Date_Format = 1;
            wsoptiongroup1.Refresh();

            chkActive.Checked = true;
            txtCode.Focus();
        }

        public override void doBefore_sav()
        {
            wsuser.Fbackcolor = 13565944;
            wsuser.Fdisabledbackcolor = 15066597;
            wsuser.Fforecolor = 0;
            wsuser.Fdisabledforecolor = 16711680;
            wsuser.Wbackcolor = 12632256;
            wsuser.Wpicture = "";
            wsuser.Wforecolor = 0;
            wsuser.Lbackcolor = 12632256;
            wsuser.Ldisabledbackcolor = 12632256;
            wsuser.Lforecolor = 0;
            wsuser.Ldisabledforecolor = 8421504;
            wsuser.Bforecolor = 0;
            wsuser.Bdisabledforecolor = 8421504;
            wsuser.Spicture = "";

            if (m0frch)
                wsuser.Language = "FR";
            else
                wsuser.Language = "EN";
        }

    }
}
