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
    public partial class wsmaintform5 : DataMenu
    {
        int DataSession = 2;
        bool DoCreate = true;
        bool ShowTips = true;
        int BufferMode = 2;
        bool AutoCenter = true;

        //*-- Main key 1 for the note. Ex.:"CLIENT"
        string notekey1_entity = "";

        //* --Main key 2 for the note (Used to be more specific), usually blank.
        string notekey2_context = "";


        //* --If there is a unique sequencial id to fill in the main key, put the name of the field here
        //string uniqueid = "";
        //* --For a header-detail program, put the name of the view (in the grid) here.
        string detailviewname = "";
        //*-- Put to false to avoid checking changes in the parent class.
        bool detailviewcheckchanges = true;

        string search_form_param = "";
        bool use_transaction = true;

        //* --Record before performing an add
        bool nrecordbeforeadd = false;

        bool start_on_last = false;
        bool lreturnrec = false;
      
        bool is_fixed = false;

        public wsmaintform5()
        {
            InitializeComponent();
            wsGrid1.AutoGenerateColumns = false;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            try
            {
                FileToScreen();
                bindControls(sdPTable, this);

            }
            catch (Exception ex) { string x = ex.ToString(); }
        }

        public override void FileToScreen()
        {
            sdPTable.LoadRow();
        }

        private void SelectionChange(object sender, EventArgs e)
        {
            SelectionChange();
        }

        public void SelectionChange()
        {
            if (wsGrid1.CurrentCell != null)
            {
                gQuery(sdPTable.MyQuery, sdPTable, wsGrid1.CurrentCell.RowIndex, 1, sdPTable.isFoxpro);
                sdPTable.noCurrent = wsGrid1.CurrentCell.RowIndex;
                FileToScreen();
            }
        }

        public override void RefreshBar()
        {
            if (!bTableIsSet)
            {
                return;
            }

            if (ALLTRIM(formaction) == "READONLY")
            {
                // *------------------------------------------*
                // * Visualization only - No changes          *
                // *------------------------------------------*
                if (eof && bof) // && No data
                {
                    BtnPrint.Visible = false;
                }
                else
                {
                    if (EMPTY(report_name)) // && AND EMPTY(doprint)
                    {
                        BtnPrint.Visible = false;
                    }
                    else
                    {
                        BtnPrint.Visible = true;
                    }
                }
                BtnNew.Visible = false;
                BtnModify.Visible = false;
                BtnDelete.Visible = false;
                BtnSave.Visible = false;
                BtnUndo.Visible = false;
            }
            else
            {   // && NOT READONLY
                // *------------------------------------------*
                // * Currently in EDITION (Modif or Add)      *
                // *------------------------------------------*
                if (editing || adding)
                {
                    BtnPrint.Visible = false;
                    BtnNew.Visible = false;
                    BtnModify.Visible = false;
                    BtnDelete.Visible = false;
                    BtnSave.Visible = true;
                    BtnUndo.Visible = true;
                    BtnQuit.Visible = false;
                    Closable = false;
                }
                else
                { // && NOT IN EDIT MODE
                  // *------------------------------------------*
                  // * In screen but NOT in edition             *
                  // *------------------------------------------*

                    // *--------------------------------*
                    // * Regular                        *
                    // *--------------------------------*
                    if (lAjout)
                    { //	&&VERIFIE SI L'USAGER PEUT FAIRE DE L'AJOUT
                        BtnNew.Visible = true;
                    }
                    else
                    {
                        BtnNew.Visible = false;
                    }


                    if (eof && bof)
                    { // && No data
                        BtnModify.Visible = false;
                        BtnDelete.Visible = false;
                        BtnPrint.Visible = false;
                    }
                    else
                    {
                        if (lModif)
                        { // &&VERIFIE SI L'USAGER PEUT FAIRE de LA MODIFICATION

                            BtnModify.Visible = true;
                        }
                        else
                        {
                            BtnModify.Visible = false;
                        }

                        if (lSupp)
                        { // &&VERIFIE SI L'USAGER PEUT FAIRE de LA DESTRUCTION
                            BtnDelete.Visible = true;
                        }
                        else
                        {
                            BtnDelete.Visible = false;
                        }
                    }


                    if (EMPTY(report_name))
                    {
                        BtnPrint.Visible = false;
                    }
                    else
                    {
                        if (lImp)
                        {
                            if (bof && eof)
                            {
                                BtnPrint.Visible = false;
                            }
                            else
                            {
                                BtnPrint.Visible = true;
                            }
                        }
                        else
                        {
                            BtnPrint.Visible = false;
                        }
                    }

                    BtnSave.Visible = false;
                    BtnUndo.Visible = false;
                    BtnQuit.Visible = true;
                    Closable = true;
                }
            }

        }

    }
}
