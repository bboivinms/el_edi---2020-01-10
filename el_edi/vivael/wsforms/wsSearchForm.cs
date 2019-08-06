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
    public partial class wsSearchForm : Form
    {
        /// <summary>
        /// Record Id to bring back
        /// </summary>
        public int RecordId;
        public bool lIdent;
        public DataSource tableSource;

        public wsSearchForm(DataSource dataSource)
        {
            InitializeComponent();
            tableSource = dataSource;
            gQuery(dataSource.MyQuery, dataSource, 0, 0, dataSource.isFoxpro);
            wsGrid1.DataSource = dataSource.ds.Tables[0];
            wsGrid1.ReadOnly = true;
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
    }
}
