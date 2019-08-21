using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static vivael.Globals;

namespace vivael
{
    public partial class wsmainform2 : DataMenuOld
    {
        public wsmainform2()
        {
            InitializeComponent();
        }

        private void wsmainform2_Load(object sender, EventArgs e)
        {
            try
            {
                data_wsseq Test = new data_wsseq();
                gQuery("SELECT * FROM wsseq", Test);

                // ' WHERE criteria ORDER BY next_id
                // limit 0, 1 // first record
                // limit 1, 1 // second record
                // need to get last record
                // need to find current record

                foreach (IDataRecord DataCocom in Test.result)
                {
                    // NOTE: FIELDS ARE CASE SENSITIVE!
                    Test.LoadRow(DataCocom);
                    // MessageBox.Show("ident: " + Test.IDENT.ToString());
                    // sTest = DataCocom["tablename"].ToString();
                }
            }
            catch (Exception ex) { string x; x = ex.ToString(); }
        }
    }
}
