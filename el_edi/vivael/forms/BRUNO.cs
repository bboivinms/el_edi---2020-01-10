using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vivael.wsforms
{
    public partial class Form1 : Form
    {
        //public static CDB_VIVA DB_VIVA; // pour exécuter dbmanager
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        private DataTable lesrec7;
        private DataTable lesrec6;
        private DataTable lesrec0;
        

        public Form1()
        {
            string Server = "192.168.1.254";
            string UserId = "viva_envl";
            string Password = "Xjg8LJFJeGEk9y9HRr!zKCEyrPeRCvUWm";
            string DB_Name = "vivadata4";

            //DB_VIVA = new CDB_VIVA($"server={Server};user id={UserId};password={Password};database={DB_Name};persistsecurityinfo=True;Allow User Variables=True;");

            InitializeComponent();
            get_data();
            
        }

        public void get_data()
        {
            //lesrec7 = DB_VIVA.ExecuteMySql(@"select prprod.ident, prprod.prcode
            //                from prprod; ");
            //lesrec6 = DB_VIVA.ExecuteMySql(@"select prprod.ident, prprod.prcode
            //                from prprod; ");

            //merge / Union
            lesrec6.Merge(lesrec7);
            //*On mais en ordre
            //SELECT* FROM lesrec5 ORDER BY lesrec5.prno INTO CURSOR lesrec0 READWRITE
           
            lesrec6.DefaultView.Sort = "prno asc";
            lesrec6 = lesrec6.DefaultView.ToTable();
            lesrec0 = lesrec6;

            //convert DataTable to a dataTableReader
            DataTableReader dtr;
            dtr = lesrec0.CreateDataReader();

            //convert DataTableReader to a dataSet
            DataSet ds = new DataSet();
            ds.Load(dtr, LoadOption.PreserveChanges, "");




            // mettre la logique
            //"DELETE FROM lesrec5 WHERE lesrec0.sp_local = "DO" OR lesrec0.sp_local = "DI" OR lesrec0.sp_local = "COUT""   //les Deletes
            foreach (DataRow row in lesrec0.Rows)
            {
                if (row["code"].ToString().Trim() == "DO" || row["code"].ToString().Trim() == "DI" || row["code"].ToString().Trim() == "COUT")
                {
                    row.Delete();
                }
            }
            lesrec0.AcceptChanges();

            var sw1 = 0;
            var vno = 0;
            var vcode = "";
            // STORE lesrec0.prno TO vno
            foreach (DataRow row in lesrec0.Rows)
            {
                if (row["code"].ToString().Trim() == vcode.Trim() && sw1 == 1 && Convert.ToInt32(row["prno"].ToString()) == vno)
                {

                }
                else
                {
                    row.SetField("chcode", row["code"].ToString());
                    vcode = row["code"].ToString();
                    vno = Convert.ToInt32(row["prno"].ToString());
                }
            }
            //DO WHILE !EOF()
            //   IF ALLTRIM(lesrec0.code)== ALLTRIM(vcode) AND sw1 = 1 AND lesrec0.prno = vno
            //   ELSE
            //      replace lesrec0.chcode WITH lesrec0.code
            //      STORE lesrec0.code TO vcode
            //      STORE lesrec0.prno TO vno
            //   ENDIF
            //   SELECT lesrec0
            //   SKIP
            //   sw1 = 1
            //ENDDO


            //lien entre colonne de la grille et les noms des champs d'un select
            dataGridView1.Columns[0].DataPropertyName = "ident";
            //dataGridView1.Columns[1].DataPropertyName = "prcode";

            //lie les donnée à la grille
            dataGridView1.DataSource = ds.Tables[0];
        }
        public void traiter()
        {

        }

        private void btn_appliquer(object sender, EventArgs e)
        {
            traiter();
        }
    }
}
