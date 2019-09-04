using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using vivael.wsforms;
using vivael.wscontrols;
using static vivael.Globals;
using vivael;
using barcode.forms;

namespace barcode.forms
{
    public partial class ffentrerprod : wsform
    {
        private int IDCLIENT;
        public object wprno, wcode,  wqte;
        private data_arclient arclient = new data_arclient();
        private DataSource lesrec = new DataSource();
        private bool SelectOnEntry;
        private int DataSessionId;

        public ffentrerprod()
        {
            InitializeComponent();
            wsGrid1.AutoGenerateColumns = false;
            lesrec.isFoxpro = true;
            this.GET_DATA();
        }

        
        private void btnQuit2_Click(object sender, EventArgs e)
        {
            this.btnQuit2.Focus();
            oSession.Shutdown();

            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.Traiter();

        }

        private void Traiter()
        {
                   
         //valider pour avoir une seul livraison
        int vcpt = 0;
            foreach (var row in lesrec.result)
            {
                if (Convert.ToBoolean(row["recept"]) == true)
                {
                    vcpt += 1;
                }
            }
           
            // message
            if (vcpt > 1)
            {
                MESSAGEBOX("Vous avec trop de réception sélectionné, transaction refusé", 0 + 16, "Message avertissement");
                return;
            }
            else
            { 
               if (vcpt== 1)
                  {
                    int nocurrent = 0;
                    foreach (var row in lesrec.result)
                    {
                        if (Convert.ToBoolean(row["recept"]) == true)
                        {
                            nocurrent += 1;
                            break;
                        }
                    }


                    //    * enregistrer la reception
                    string u = $"UPDATE prprod set papier_recu={lesrec.result[nocurrent]["recept"]}";
                    gQuery(u, true);


                    //         // impression feuille pour palette
                    //         // store des champs dans variable
                    //         //impression du rapport
                   
                    wprno=lesrec.result[nocurrent]["prno"];
                    wcode=lesrec.result[nocurrent]["code"];
                    
                    wqte=lesrec.result[nocurrent]["qte"];
                   

                    oPrintForm.Print("PAPCLI", "lcCursorName", "VPEF,", "", this.DataSessionId, "WSPRINTFORMPC");

                }
               else
                            {
                    MESSAGEBOX("Vous avez pas de réception sélectionné, transaction refusé", 0 + 16, "Message avertissement");
                    return;
                }
            }

            this.GET_DATA();
        }

        private void btn_raf_Click(object sender, EventArgs e)
        {
            //this.ScnCode.Text = "";
            //this.IDCLIENT = 0;
            //this.txtclient_code.Text = "";
            //this.txtClient_name.Text = "";
            //this.Refresh();
            //this.GET_DATA();
        }

        private void GET_DATA()
        {
         //this.wsGrid1.RecordSource = "";
         string q = $"SELECT prprod.ident, prprod.prcode, prprod.prno, prprod.idprod, prprod.idclient, " +
                $" prprod.prclientpo, prprod.statut, prprod.termine, prprod.qte, prprod.qtettprod, SUBSTR(prprod.noteprod, 1, 240) + '' AS NOTEPROD," +
                $" ivprod.code,ivprod.desc, arclient.code as codecli, 0000 as bo, 0000000000 as qtepr," +
                $" .F. as recept, arclient.name" +
                $" FROM prprod" +
                $" LEFT OUTER JOIN prkit" +
                $" ON prprod.prno = prkit.idfab" +
                $" LEFT OUTER JOIN arclient" +
                $" ON arclient.ident = prprod.idclient" +
                $" LEFT OUTER JOIN ivprod" +
                $" ON ivprod.ident = prprod.idprod" +
                $" WHERE(prprod.statut = 'O' OR prprod.statut = 'C' OR prprod.statut = 'E') AND prprod.termine =.F. and" +
                $" prkit.idprod = 7157 AND prprod.papier_recu =.F." +
                $" ORDER BY prprod.prno";

        
            gQuery(q, lesrec, 0, 0, lesrec.isFoxpro);

            wsGrid1.DataSource = lesrec.ds.Tables[0];
            wsGrid1.Columns[0].DataPropertyName = "prno";
            wsGrid1.Columns[1].DataPropertyName = "code";
            wsGrid1.Columns[2].DataPropertyName = "desc";
            wsGrid1.Columns[3].DataPropertyName = "qte";
            wsGrid1.Columns[4].DataPropertyName = "codecli";
            wsGrid1.Columns[5].DataPropertyName = "name";
            wsGrid1.Columns[6].DataPropertyName = "recept";
            wsGrid1.Columns[7].DataPropertyName = "noteprod";
            wsGrid1.Columns[8].DataPropertyName = "prclientpo";
                      
           this.wsGrid1.Refresh();
           this.Refresh();
        }

        private void ScnCode_Leave(object sender, EventArgs e)
        {
            if (!EMPTY(this.ScnCode.Text))
            {
                WAIT("Busy loading data...", "WINDOW NOWAIT");
                int ncode = 0;
                                                
                ncode = INT(VAL(this.ScnCode.Text));
                this.IDCLIENT = 0;
                //this.txtclient_code.Text = "";
                //this.txtClient_name.Text = "";
                this.Refresh();
                this.get_data2();
             }
        }

        private void get_data2()
        {
         
            string q = $"SELECT prprod.ident, prprod.prcode, prprod.prno, prprod.idprod, prprod.idclient, " +
                 $" prprod.prclientpo, prprod.statut, prprod.termine, prprod.qte, prprod.qtettprod, SUBSTR(prprod.noteprod, 1, 240) + '' AS NOTEPROD," +
                 $" ivprod.code,ivprod.desc, arclient.code as codecli, 0000 as bo, 0000000000 as qtepr," +
                 $" .F. as recept, arclient.name" +
                 $" FROM prprod" +
                 $" LEFT OUTER JOIN prkit" +
                 $" ON prprod.prno = prkit.idfab" +
                 $" LEFT OUTER JOIN arclient" +
                 $" ON arclient.ident = prprod.idclient" +
                 $" LEFT OUTER JOIN ivprod" +
                 $" ON ivprod.ident = prprod.idprod" +
                 $" WHERE(prprod.statut = 'O' OR prprod.statut = 'C' OR prprod.statut = 'E') AND prprod.termine =.F. and" +
                 $" prkit.idprod = 7157 AND prprod.papier_recu =.F. AND" +
                 $" (prprod.prno = INT(VAL('{this.ScnCode.Text}')) OR VAL('{this.IDCLIENT}') = PRPROD.IDCLIENT)"+
            $" ORDER BY prprod.prno";

            gQuery(q, lesrec, 0, 0, lesrec.isFoxpro);

            wsGrid1.DataSource = lesrec.ds.Tables[0];
            wsGrid1.Columns[0].DataPropertyName = "prno";
            wsGrid1.Columns[1].DataPropertyName = "code";
            wsGrid1.Columns[2].DataPropertyName = "desc";
            wsGrid1.Columns[3].DataPropertyName = "qte";
            wsGrid1.Columns[4].DataPropertyName = "codecli";
            wsGrid1.Columns[5].DataPropertyName = "name";
            wsGrid1.Columns[6].DataPropertyName = "recept";
            wsGrid1.Columns[7].DataPropertyName = "noteprod";
            wsGrid1.Columns[8].DataPropertyName = "prclientpo";

            this.wsGrid1.Refresh();
         }

        //private void txtclient_code_Leave(object sender, EventArgs e)
        //{
        //    this.ScnCode.Text = "";
        //    this.Refresh();

        //    if (!EMPTY(this.IDCLIENT))
        //    {
        //        int nclient = INT(this.IDCLIENT);
        //        string q = $"SELECT * from arclient where arclient.ident={nclient} order by arclient.ident asc";
        //        gQuery(q, arclient, 0, 0, arclient.isFoxpro);
        //        arclient.LoadRow();
        //        //this.txtclient_code.Text = arclient.Code;
        //        //this.txtClient_name.Text = arclient.Name;
        //    }

        //    if (!EMPTY(this.txtclient_code.Text))
        //    {
        //        string q = $"SELECT * from arclient where arclient.code={ALLTRIM(this.txtclient_code.Text)} order by arclient.code asc";
        //        gQuery(q, arclient, 0, 0, arclient.isFoxpro);


        //        if (arclient.RECCOUNT() > 0)
        //        {
        //            this.IDCLIENT = arclient.Ident;
        //            this.txtClient_name.Text = arclient.Name;
        //        }

        //        else
        //        {
        //            this.IDCLIENT = 0;
        //            MESSAGEBOX(IIF(m0frch, "Code de client inexistant.",
        //                  "Client not found."), 0 + 16, "");
        //            this.SelectOnEntry = true;
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        this.IDCLIENT = 0;
        //     }
        //    this.get_data2();
             
        //}

        private void btnSearchprod_Click(object sender, EventArgs e)
        {
            // *Private lRecordId, cur_area

            this.ScnCode.Text = "";
            this.Refresh();

            //Do Form arsclient Name Fsearch To lRecordId Linked
            //If lRecordId <> 0
              
            //    Select arclient
            //    Go Record lRecordId

            //    Thisform.idclient = arclient.ident
            //    This.Parent.txtClient_name.Value = arclient.Name
            //    This.Parent.txtClient_code.Value = arclient.Code



            //    Select (cur_area)
            //ENDIF

            //THISFORM.GEt_data2()
           
        }
    }
}