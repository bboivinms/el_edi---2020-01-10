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

namespace barcode.forms
{
    public partial class wajust : vivael.wsforms.wsform
    {
        private int lRecordId;
        public wajust()
        
        {
            InitializeComponent();
        }

        private void wstextbox1_Click(object sender, EventArgs e)
        {

        }

        private void BtnSeach_click(object sender, EventArgs e)
        {
           


        //DO FORM ivsprod NAME Fsearch TO lRecordId LINKED
        //IF lRecordId<> 0

        //    STORE SELECT() TO cur_area


        //    SELECT ivprod

        //    GO RECORD lRecordId

        //    IF ivprod.is_service
        //        = MESSAGEBOX(iif(m0frch, "Cet item est un service!", "This item is a service"),;
        //            0 + 16,"")
        //		Thisform.idprod = 0

        //        THISFORM.txtLast_cost.Value = 0

        //        THISFORM.txtUnit.Value = ""

        //        THISFORM.btnCalcul.Visible = .F.
        //        SELECT(cur_area)

        //        RETURN 0

        //    ELSE

        //        Thisform.idprod = ivprod.ident

        //        ThisForm.txtCode.Value = ivprod.code

        //        ThisForm.txtDesc.Value = ivprod.desc

        //        THISFORM.txtLast_cost.Value = ivprod.ac_lst_cost

        //        THISFORM.txtUnit.Value = ivprod.unit

        //        THISFORM.btnCalcul.Visible = .T.

        //    ENDIF

        //    SELECT(cur_area)
        //ENDIF

        }
    }
}
