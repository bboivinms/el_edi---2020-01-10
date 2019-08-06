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

        /*-- Name of the associated search form*/
        string search_form = "";

        //*-- Main key 1 for the note. Ex.:"CLIENT"
        string notekey1_entity = "";

        //* --Main key 2 for the note (Used to be more specific), usually blank.
        string notekey2_context = "";

        //* --Instance in the Session.Active_form
        int? sessioninstance = 0;

        //* --If there is a unique sequencial id to fill in the main key, put the name of the field here
        string uniqueid = "";
        //* --For a header-detail program, put the name of the view (in the grid) here.
        string detailviewname = "";
        //*-- Put to false to avoid checking changes in the parent class.
        bool detailviewcheckchanges = true;

        //* --Type < F > oxpor or<C> rystal of the attached report
        string report_type = "F";

        string search_form_param = "";
        bool proportional_resize = true;
        bool use_transaction = true;
        bool init_ok = true;

        //* --Record before performing an add
        bool nrecordbeforeadd = false;

        //*-- Used to keep an additionnal parameter when calling the form
        bool paramplus = false;
        bool start_on_last = false;
        bool lreturnrec = false;
        bool o_left = false;
        bool o_top = false;
        bool o_height = false;
        bool o_width = false;
        bool is_resizable = false;
        bool is_fixed = false;
        bool cfunction = false;

        public wsmaintform5()
        {
            InitializeComponent();
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
                    if (lajout)
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
                        if (lmodif)
                        { // &&VERIFIE SI L'USAGER PEUT FAIRE de LA MODIFICATION

                            BtnModify.Visible = true;
                        }
                        else
                        {
                            BtnModify.Visible = false;
                        }

                        if (lsupp)
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
                        if (limp)
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
