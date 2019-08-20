using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static vivael.Globals;

namespace vivael.wscontrols
{
    public partial class cntprintform2 : UserControl
    {
        data_wspform PFORM = new data_wspform();

        public cntprintform2()
        {
            InitializeComponent();
        }

        public void Init()
        {
            this.REQUERY_CMB();
        }

        private void REQUERY_CMB()
        {
            gQuery($"SELECT * FROM WSPFORM WHERE ALLTRIM(WSPFORM.FORMCODE) == ALLTRIM({Q2(oPrintForm.cFormCode)}) ORDER BY DEF_FORM DESC",PFORM, 0,0,true);

            PFORM.LoadRow();

            cmbPrintForm.DisplayMember = "Formname";
            cmbPrintForm.ValueMember = "Ident";

            this.cmbPrintForm.DataSource = PFORM.ds.Tables[0];

            this.cmbPrintForm.Text = PFORM.Formname;
            this.cmbPrintForm.Refresh();
            this.InteractiveChange();

        }

        private void SavePrinter()
        {
            data_wslastprint cursor = new data_wslastprint();
            gQuery($"SELECT * FROM wslastprint WHERE ALLTRIM(wslastprint.usercode) == ALLTRIM({Q2(oSession.UserCode)}) AND ALLTRIM(wslastprint.report_name) == ALLTRIM({Q2(oPrintForm.cReportName)})", cursor, 0, 0, true);

            if(cursor.result != null)
            {
                gQuery($"UPDATE wslastprint SET printer_name = {Q2(oPrintForm.cDefaultPrinter)} WHERE ALLTRIM(wslastprint.usercode) == ALLTRIM({Q2(oSession.UserCode)}) AND ALLTRIM(wslastprint.report_name) == ALLTRIM({Q2(oPrintForm.cReportName)})", true);
            }
            else
            {
                gQuery($"INSERT INTO wslastprint(usercode, report_name, printer_name) VALUES({Q2(oSession.UserCode)}, {Q2(oPrintForm.cReportName)}, {Q2(oPrintForm.cDefaultPrinter)})", true);
            }
        }

        private void CmbPrintForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            InteractiveChange();
        }

        private void InteractiveChange()
        {
            oPrintForm.lStdForm = PFORM.Std_Form;
            oPrintForm.cFormCode = PFORM.Formcode;
            oPrintForm.cReportName = ALLTRIM(PFORM.Formfile);
            oPrintForm.nIdent = PFORM.Ident;
            oPrintForm.cFormName = PFORM.Formname;
            oPrintForm.lDefForm = PFORM.Def_Form;
            oPrintForm.mNotes = PFORM.Notes;
            oPrintForm.lEnabled = PFORM.Enabled;

            data_wslastprint cur_printer = new data_wslastprint();
            gQuery($"SELECT * FROM wslastprint WHERE ALLTRIM(wslastprint.usercode) == ALLTRIM({Q2(oSession.UserCode)}) AND ALLTRIM(wslastprint.report_name) == ALLTRIM({Q2(oPrintForm.cReportName)})", cur_printer, 0, 0, true);

            cur_printer.LoadRow();

            if(cur_printer.result != null)
            {
                SETPRINTER(ALLTRIM(cur_printer.Printer_Name)); //SET PRINTER TO NAME(ALLTRIM(cur_printer.printer_name))

                oPrintForm.cDefaultPrinter = cur_printer.Printer_Name;
                this.lblCurPrint.Text = IIF(m0frch, "Imprimante courante: ", "Current printer: ") + ALLTRIM(cur_printer.Printer_Name);

            }
            else
            {
                this.lblCurPrint.Text = IIF(m0frch, "Imprimante courante: ", "Current printer: ") + ALLTRIM(oPrintForm.cDefaultPrinter);
                this.SavePrinter();
            }

        }

        private void Wslink1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string lcPrinter = GETPRINTER();

            SETPRINTER(ALLTRIM(lcPrinter));//SET('PRINTER', 3)
            oPrintForm.cDefaultPrinter = lcPrinter; 

            this.SavePrinter();
            this.lblCurPrint.Text = IIF(m0frch, "Imprimante courante: ", "Current printer: ") + ALLTRIM(oPrintForm.cDefaultPrinter);
        }
    }
}
