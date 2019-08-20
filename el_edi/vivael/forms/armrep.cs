using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using vivael.wscontrols;
using vivael.wsforms;
using static vivael.Globals;

namespace vivael.forms
{
    public partial class armrep : wsmaintform5
    {
        private data_arrep arrep = new data_arrep();

        public armrep()
        {
            InitializeComponent();
            uniqueid = "ident";

            //setup des data
            wsCheckBox.source = arrep;
            SetQuery("SELECT * FROM arrep ORDER BY NAME ASC", 0, 0, arrep);
            sdPTable = arrep;

            //setup de la grid
            wsGrid1.DataSource = arrep.ds.Tables[0];
        }

        public override void doBefore_new()
        {
            wsGrid1.ClearSelection();
            arrep.ResetProperties();
            arrep.Comm_On = "G";
        }

        public override void doAfter_new()
        {
            arrep.noCurrent = 0;
        }

        public override void doAfter_sav()
        {
            RefreshGrid();
        }

        public override void doAfter_delete()
        {
            RefreshGrid();
        }

        public override void doAfter_undo()
        {
            wsGrid1.Rows[sdPTable.noCurrent].Selected = true;
        }

        private void RefreshGrid()
        {
            int currentRecord = arrep.noCurrent;
            gQuery(arrep.MyQuery, arrep, 0, 0, arrep.isFoxpro);
            sdPTable = arrep;
            wsGrid1.DataSource = arrep.ds.Tables[0];

            wsGrid1.ClearSelection();
            wsGrid1.CurrentCell = wsGrid1.Rows[currentRecord].Cells[0];
            SelectionChange();
        }
    }
}
