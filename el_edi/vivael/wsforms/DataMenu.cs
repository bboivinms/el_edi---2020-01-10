using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael;
using vivael.forms;
using vivael.wscontrols;
using vivael.wsforms;
using static vivael.Globals;

namespace vivael.wsforms
{
    public partial class DataMenu : Form, WsControl
    {
        [
        Category("Translation"),
        TypeConverter(typeof(WsControl)),
        Editor(typeof(WsControl), typeof(string)),
        Description("The english text of the title form.  You can enter an english text here.")
        ]
        public string Text_EN { get; set; }

        [
        Category("Translation"),
        TypeConverter(typeof(WsControl)),
        Editor(typeof(WsControl), typeof(string)),
        Description("The french text of the title form.  You can enter an french text here.")
        ]
        public string Text_FR { get; set; }

        public DataMenu()
        {
            InitializeComponent();
            TranslateForm(this);
        }


        public object parameters;
        public DataSource sdPTable = new DataSource();
        public bool bTableIsSet = false;   //ADDED_VARIABLE_KJ_2018_10_30 // used to see if SetTable was called and Data Source manipulation is needed

        protected string search_form = "";           // *-- Name of the associated search form
        string notekey1_entity = "";       // *-- Main key 1 for the note. Ex.:"CLIENT"
        string notekey2_context = "";      // *-- Main key 2 for the note (Used to be more specific), usually blank.
        protected string formaction = "";  // *-- Action given when called by the menu (Usually blank)
        protected object SessionInstance = 0;           // *-- Instance in the Session.Active_form
        protected object uniqueid = 0;     // *-- if there is a unique sequencial id to fill in the main key, put the name of the field here
        protected string report_name = ""; // *-- Name of the attached report
        protected string report_type = "F";          // *-- Type <F>oxpro or <C>rystal of the attached report
        protected int newrecord = 0;       // *-- Used to bring back the saved record
        protected bool lAjout = true;
        protected bool lModif = true;
        protected bool lSupp = true;
        protected bool lImp = true;
        string search_form_param = "";
        protected object proportional_resize = true;
        bool use_transaction = false;
        int temp_id = 0;
        bool search_modal = true;           // KJ: 2018-10-03: Foxpro + Go Fish: Value is always true for vivasoft.pjx + only used in wsmaintform2
        protected bool init_ok = true;

        protected bool eof = false;         // *-- Currently on last record
        protected bool bof = false;         // *-- Currently on first record
        protected bool editing = false;     // *-- Currently in edition
        int nrecordbeforeadd = 0;           // *-- Record before performing an add
        protected string formname;                    // *-- Name of the form when called from the menu.
        protected bool adding = false;      // *-- .T. if we are in adding mode (new rec option)
        protected int FormRecno = 0;
        public object ParamPlus = false;    // *-- Used to keep an additionnal parameter when calling the form
        bool start_on_last = false;
        bool lreturnrec = false;
        protected object o_left = 0;
        protected object o_top = 0;
        protected object o_height = 0;
        protected object o_width = 0;
        protected bool is_resizable = false;
        protected object Picture;
        bool ldemo = false;
        bool search_form_lident = true;
        string search_form_order = "";
        protected string cFunction = "";

        wsreport WsReport1;

        protected int WindowType = 0;       // ADDED_VARIABLE_KJ_2018_06_05
        int record_position = -1;           // ADDED_VARIABLE_KJ_2018_06_05
        int? search_form_variant = null;    // ADDED_VARIABLE_KJ_2018_06_12
        protected bool Closable;            //ADDED_VARIABLE_KJ_2018_06_18

        string sMyOrder = "";               //ADDED_VARIABLE_KJ_2018_09_11 // used in navfirst to set order
        bool Modified { get; set; } //WIP

        public void doBefore_nav()
        {
            // -- Nothing in it. To use into the form. Called before moving the cursor.
        }

        public virtual void EnableButtons()
        {
            if (!IsFirst(sdPTable))
            {
                BtnFirst.Enabled = true;
                BtnPrev.Enabled = true;
            }
            else
            {
                BtnFirst.Enabled = false;
                BtnPrev.Enabled = false;
            }

            if (!IsLast(sdPTable))
            {
                BtnLast.Enabled = true;
                BtnNext.Enabled = true;
            }
            else
            {
                BtnLast.Enabled = false;
                BtnNext.Enabled = false;
            }

            // eof + bof = true if the respective states are Grayed
            eof = BtnLast.Enabled == false;
            bof = BtnFirst.Enabled == false;
        }

        public void SetTable(string sLMyTable, string sPMyOrder = "")
        {
            bTableIsSet = true;

            sdPTable = GetObject(sLMyTable) as DataSource;
            SetOrder(sPMyOrder);

            //ExecuteProcess(BtnFirst, trtClick)
        }

        public void SetPrimaryKey(DataSource sdPCursor, string primaryKey1, string primaryKey2 = "", string primaryKey3 = "")
        {
            sdPCursor.i.primary_1 = primaryKey1;

            if (primaryKey2 != "")
            {
                sdPCursor.i.primary_2 = primaryKey2;
            }

            if (primaryKey3 != "")
            {
                sdPCursor.i.primary_3 = primaryKey3;
            }
        }

        public void ScreenToFile()
        {
            //WIP
        }

        public virtual void FileToScreen()
        {
            //*-- Nothing in it. To use into the form. Call to put the data to the screen.
        }

        public void Destroy()
        {
            if ((int)SessionInstance > 0)
            {
                oSession.shut_form((int)SessionInstance);
            }
        }

        public virtual bool Init(string cFormName, string cAction = "", object nInstance = null, int nRecno = 0, object cParamPlus = null,
                         bool lajout = true, bool lmodif = true, bool lsupp = true, bool limp = true)
        {
            // *
            // * Paramètres Action : ADD ---> Directement en ajout
            // *                     MOD ---> Directement en modif
            // *                     JUST1--> Pas de ADD, Ni de DEL, Record spécifique et direct en modif
            // *                     J1-----> Idem mais ne tombe pas en modif automatique
            // *                     FILTER-> Normal avec filtre sur table principale (filtre = cParamPlus)
            //
            // * Paramètres lAjout = .T. l'usager peut faire de l'ajout si .F. pas d'ajout possible
            // * Paramètres lModif = .T. l'usager peut faire de la modification si .F. pas de modification possible
            // * Paramètres lSupp  = .T. l'usager peut faire de destruction si .F. pas de destruction possible
            // * Paramètres lImp   = .T. l'usager peut faire de l'impression si .F. pas d'impression possible

            // && Seulement si appelé sans aucun paramètre

            if (ISNULL(cFormName))
            {
                m0frch = false;
                lajout = true;
                lmodif = true;
                lsupp = true;
                limp = true;
            }

            // * Si modal on désactive tout les tools bars.
            if (WindowType == 1)
            {
                oSession.Disabled_bar(0);
            }

            if(ISNULL(nInstance) || TYPE(nInstance) != typeof(int))
            {
                cFunction = "";
                nInstance = 0;
            }
            else
            {
                cFunction = oSession.active_form[(int)nInstance, 1].ToString(); 
            }

            formname = cFormName;
            formaction = Upper(cAction);
            SessionInstance = (int)nInstance;
            FormRecno = nRecno; 
            ParamPlus = cParamPlus;

            if (!m0xpscheme)
            {
                BackColor = oSession.WBackColor;
                ForeColor = oSession.WForeColor;
                Picture = oSession.WPicture;
            }

            this.lAjout = lajout;
            this.lModif = lmodif;
            this.lSupp =  lsupp;
            this.lImp =   limp;

            // * Disable print button if not needed
            if (EMPTY(report_name))
            { // && AND EMPTY(THISFORM.doprint)
                BtnPrint.Visible = false;
            }

            // * if JUST1 action, move modif button instead of add
            if (ALLTRIM(formaction) == "JUST1")
            {
                BtnNew.Visible = false;
                BtnModify.Top = BtnNew.Top;
                BtnModify.Left = BtnNew.Left;
                BtnDelete.Visible = true;
            }

            if (bTableIsSet && (ALLTRIM(formaction) == "FILTER" || ALLTRIM(formaction) == "ADDMODALFILTER"))
            {
                SET_FILTER(sdPTable, cParamPlus);
                gFirst(sdPTable, sMyOrder);
            }

            // * Programer Hook
            doAfter_init();

            if (init_ok == false)
            {
                RELEASE();
                Destroy();
                Unload();
                return false;
            }

            // * Disable the fields
            EnableDisable_fields(this, "D");

            // *---> if the form was called in Add mode
            if (ALLTRIM(formaction) == "ADD" || ALLTRIM(formaction) == "ADDMODAL" || ALLTRIM(formaction) == "ADDMODALFILTER")
            {
                if (ALLTRIM(formaction) == "ADDMODAL" || ALLTRIM(formaction) == "ADDMODALFILTER")
                {
                    //	WindowType = 1 // && Modal pour add      *********non non non: crée des problèmes
                    oSession.Disabled_bar(0);
                }
                ActionNew();
            }

            else if (bTableIsSet)
            {
                // *---> if we called it with a specific record
                if (FormRecno != 0)
                {
                    if (nRecno <= RECCOUNT(sdPTable))
                    {
                        // * Used for special processes in the form (empty here)
                        doBefore_nav();
                        NavGo(nRecno);

                        // * Used for special processes in the form (empty here)
                        doAfter_nav();
                    }
                }
                else
                {

                    if (start_on_last == true)
                    {
                        NavLast();
                    }
                    else
                    {
                        NavFirst();
                    }

                    if (bof && eof)
                    {
                        WAIT(IIF(m0frch, "Aucune entrée...", "No data..."), "WINDOW nowait");
                    }
                }

            }

            // *---> if the form was called in DELETE mode
            if (ALLTRIM(formaction) == "DEL")
            {
                ActionDelete();

            }
            else if (ALLTRIM(formaction) == "MOD")
            {
                ActionModify();
            }

           
            return true;
        }

        public bool QueryUnload()
        {

            if (!bTableIsSet) { return true; }

            if (editing)
            {
                if (oSession.on_error_quit == false)
                { // && Only if we are not quitting because of an error

                    MESSAGEBOX(IIF(m0frch, "Terminer l'édition (Sauvegarde ou abandon)", "Current edition must be saved or cancelled)"), 0 + 16,
                                IIF(m0frch, "Sortie impossible", "Exit not allowed now"));

                    NODEFAULT();
                    return false;
                }
                else
                {
                    ActionUndo();
                    DODEFAULT();
                }
            }
            else
            {
                // * Verify if user changed something and save/discard them
                if (!Verify_change())
                {
                    NODEFAULT();
                    return false;
                }
                else
                {
                    DODEFAULT();
                }
            }

            return true; //WIP: gotta check what the default return should be
        }

        public new void Refresh()
        {
            RefreshBar();

            if (!editing)
            {
                if (!eof && !bof)
                {
                    nrecordbeforeadd = RECNO(sdPTable);
                }
                else
                {
                    nrecordbeforeadd = 0;
                }
            }
        }

        public new void Resize()
        {
            doResize();
            doAfter_resize();
        }

        public void RightClick()
        {
        }

        public int Unload()
        {
            // * Si modal on réactive tout les tool bar.
            if (WindowType == 1)
            {
                oSession.enabled_bar(0);
            }

            if (ALLTRIM(formaction) == "ADDMODAL" || ALLTRIM(formaction) == "ADDMODALFILTER")
            {
                return newrecord;
            }

            DODEFAULT();

            return 0; //WIP: return value was undefined
        }

        public bool ActionDelete()
        {
            if (!bTableIsSet) { return false; }

            int nResult;

            if (Valid_del())
            {
                //WIP: int.. get from messagebox
                nResult = MESSAGEBOX(IIF(m0frch, "Effacer l'entrée courante ?",
                                    "Delete the current entry ?"),
                                    4 + 32 + 256,
                                    IIF(m0frch, "Suppression données", "Data supression"));

                if (nResult == 6)//if yes
                {
                    doBefore_delete();
                    sdPTable.SaveRow("delete");
                }
                else
                {
                    return false;
                }

                ScreenToFile();

                doAfter_delete();

                // *---> if we called it with a specific record (=NO NAVIGATION)
                if (FormRecno != 0)
                {
                    RELEASE();
                }
                else
                {
                    gPrevious(sdPTable);

                    gNext(sdPTable);

                    FileToScreen();
                }
            }
            return true;
        }

        public void ActionModify()
        {
            if (!bTableIsSet)
            {
                return;
            }

            //* Verify if user changed something and save/discard them
            if (!Verify_change())
            {
                return;
            }

            // gMsgBox("ActionModify2")
            // * Verify if new is permitted
            if (!Valid_mod())
            {
                return;
            }

            editing = true; // && We are in editing mode

            // * Enable the fields
            EnableDisable_fields(this, "E");


            //* Used for special processes in the form (empty here)
            doBefore_mod();

            //* Cancel if we changed the current add action in the doBefore_new
            if (editing == false)
            {
                return;
            }

            if (!(eof && bof))
            {
                nrecordbeforeadd = RECNO(sdPTable);
            }
            else
            {
                nrecordbeforeadd = 0;
            }

            editing = true;

            Refresh();

            //* Used for special processes in the form (empty here)
            doAfter_mod();
        }

        public void ActionNew()
        {
            if (!bTableIsSet) //if we have set a table for the form
            {
                return;
            }

            //int vId_key;

            //* Verify if user changed something and save/discard them
            if (!Verify_change())
            {
                return;
            }

            //	* Verify if new is permitted
            if (!Valid_new())
            {
                return;
            }

            adding = true; // We are in adding mode

            // * Enable the fields
            EnableDisable_fields(this, "E");

            //* Used for special processes in the form (empty here)
            doBefore_new();

            // * Cancel if we changed the current add action in the doBefore_new
            if (adding == false)
            {
                return;
            }

            if (!(eof && bof))
            {
                nrecordbeforeadd = RECNO(sdPTable);
            }
            else
            {
                nrecordbeforeadd = 0;
            }

            temp_id = 0;

            //if (EMPTY(uniqueid))  //= field name in a table
            //{
            //    //UNKNOWN_KJ_2018_05_24// APPEND BLANK
            //    //peut-etre alternative : INSERT INTO sdtable.tablename (+ primary key +) VALUES ( max primary key + 1 )
            //}
            //else
            //{
            //    // * if this table requires a unique ident, we insert it with a temporary number (negative)
            //    vId_key = 0;
            //    vId_key = oSession.get_temp_id(Upper(sdPTable.Table_name));
            //    temp_id = vId_key;
            //    gQuery("INSERT INTO " + ALLTRIM(sdPTable.Table_name) + " (" + uniqueid + ") VALUES (" + ALLTRIM(STR(vId_key)) + ")");
            //}

            editing = true;
            Refresh();

            //* Used for special processes in the form (empty here)
            doAfter_new();
        }

        public void ActionNote()
        {
            if (!bTableIsSet) { return; }

            //*** ACTION CALL CONTEXTUAL NOTES
            //*** NOTE(S) IDENTIFIED BY ENTITY+CONTEXT+STR(REC-MAIN-KEY)
            //*** EX.: "CLIENT"+""+STR(client.id)
            //*** 

            object thekey;

            if (!EMPTY(uniqueid))
            {
                thekey = STR(ALLTRIM(sdPTable.Table_name) + "." + uniqueid);
            }
            else
            {
                thekey = STR(RECNO(sdPTable));
            }

            OpenSister(new wsMesg(), notekey1_entity, notekey2_context, thekey);   //NOTE_CHECK_CODE_KJ_2018_05_24//NAME = MesgForm + LINKED//UNKNOWN
        }

        private void OpenSister(Form wsForm, string notekey1_entity, string notekey2_context, object thekey)
        {
            //WIP
        }

        public void ActionPrint()
        {

            if (report_name == "" || report_type == "X")
            {
                doPrint();
            }
            else
            {

                //* if there is a standard attached report
                WsReport1 = new wsreport();
                WsReport1.report_name = report_name;
                WsReport1.report_type = report_type;
                WsReport1.report_print(); // && Action
                WsReport1 = null;
            }
        }

        public bool ActionSave()
        {
            if (!bTableIsSet)
            {
                return false;
            }

            //**** PERFORM THE SAVE if VALIDATION OK  ****
            //**** return .T. if SAVED, .F. if FAILED ****

            //int id_key;
            string sError_message;

            //* Do the save only if valid_say returns .T.
            if (!Valid_sav()) { return false; }

            if (use_transaction == true)
            {
                BEGIN_TRANSACTION();
            }

            // * Used for special processes in the form (empty here)
            doBefore_sav();

            //// * if there is a main sequential key (INTEGER) to update
            //if (adding && !EMPTY(uniqueid))
            //{
            //    id_key = oSession.get_next_id(Upper(sdPTable.Table_name));

            //    if (id_key != 0)
            //    {
            //        uniqueid = id_key;
            //    }

            //    //* Next situation should only append when testing without the menu (and oSession)
            //    if (id_key == 0)
            //    {
            //        id_key = CINT(RAND() * 100000);
            //        {
            //            uniqueid = id_key;

            //            WAIT("Uniqueid = " + STR(id_key), "WINDOW NOWAIT");
            //        }
            //    }
            //}

            // * Save the data (main table only)
            ScreenToFile();

            if (adding)
                sdPTable.SaveRow("insert");
            else
                sdPTable.SaveRow("update");

            //sError_message = gSaveRow(sdPTable);
            sError_message = "";
            if (sError_message != "")
            {
                WAIT(IIF(m0frch, "Erreur de sauvegarde...(" + sError_message + ")", "Error with save...(" + sError_message + ")"), "WINDOW NOWAIT");

                return false;
            }

            // * Used for special process in the form
            doBefore_savdetail();

            // * Used for special processes in the form (empty here)
            doAfter_sav();

            if (use_transaction == true)
            {
                END_TRANSACTION();
            }

            editing = false;
            adding = false;
            gLast(sdPTable);
            EnableButtons();

            // * Disable the fields
            EnableDisable_fields(this, "D");
            Refresh();
            WAIT(IIF(m0frch, "Sauvegardé...", "Saved..."), "WINDOW NOWAIT");
            return true;
        }

        public void ActionUndo()
        {
            if (!bTableIsSet)
            {
                return;
            }

            TABLEREVERT(true);

            editing = false;
            adding = false;

            //* Used for special processes in the form (empty here)
            doAfter_undo();

            if (ALLTRIM(formaction) == "ADD" || ALLTRIM(formaction) == "ADDMODAL" ||
                ALLTRIM(formaction) == "ADDMODALFILTER")
            {
                newrecord = 0;

                RELEASE(); // && if the form was called in ADD mode, quit if cancelled by user

            }
            else
            {
                if (nrecordbeforeadd != 0)
                {
                    NavGo(nrecordbeforeadd);
                }

                //* Disable the fields
                EnableDisable_fields(this, "D");

                Refresh();

                FileToScreen();
            }


            WAIT(IIF(m0frch, "Annulé...", "Cancelled..."), "WINDOW NOWAIT");
        }

        public void doBefore_opentable()
        {
        }

        public void doResize()
        {
        }

        public void EnableDisable_fields(Control aContainer, string vPEnableDisable = "") // , vPStartObject = null) // removed start object
        {
            if (!bTableIsSet)
            {
                return;
            }

            //Loop through the form and find groupbox with children and enable / disable fields
            foreach (Control ctrl in aContainer.Controls)
            {
                if (ctrl is wsgroupbox || ctrl is Panel)
                {
                    EnableDisable_fields(ctrl, vPEnableDisable);
                }

                if (ctrl is wstextbox || ctrl is wsComboBox || ctrl is wsnumbox)
                {
                    ctrl.Enabled = vPEnableDisable == "E";

                    if (!ctrl.Enabled)
                    {
                        ctrl.BackColor = oSession.fdisabledBackColor;
                        ctrl.ForeColor = oSession.fdisabledForeColor;
                    }
                    else
                    {
                        ctrl.BackColor = oSession.fBackColor;
                        ctrl.ForeColor = oSession.fForeColor;
                    }
                }

                if (ctrl is wsCheckBox || ctrl is wsoptiongroup)
                {
                    ctrl.Enabled = vPEnableDisable == "E";

                    if (!ctrl.Enabled)
                    {
                        ctrl.ForeColor = oSession.fdisabledForeColor;
                    }
                    else
                    {
                        ctrl.ForeColor = oSession.fForeColor;
                    }
                }

                if (ctrl is Label)
                {
                    ctrl.Enabled = vPEnableDisable == "E";

                    if (!ctrl.Enabled)
                    {
                        ctrl.ForeColor = oSession.LdisabledForeColor;
                        ctrl.BackColor = oSession.LdisabledBackColor;

                    }
                    else
                    {
                        ctrl.ForeColor = oSession.LForeColor;
                        ctrl.BackColor = oSession.LBackColor;
                    }
                }

                if(ctrl is wsGrid)
                {
                    ctrl.Enabled = vPEnableDisable == "D";
                }
            }

            //foreach (Control control in this.Controls)
            //{
            //    if (control is wstextbox || control is wsComboBox)
            //    {
            //        control.Enabled = vPEnableDisable == "E";

            //        if (!control.Enabled)
            //        {
            //            control.BackColor = oSession.fdisabledBackColor;
            //        }
            //        else
            //        {
            //            control.BackColor = oSession.fBackColor;
            //        }
            //    }
            //}
            /*
            while (EnumControl(MyWindow, i) != "")
            {
                if (!ISNULL(gAP({ EnumControl(MyWindow, i)}))) 
                {
                    if (gAP({ EnumControl(MyWindow, i)}).lEnableDisable) 
                    {
                        { EnumControl(MyWindow, i)}..InputEnabled = vPEnableDisable = "E";
                    }

                    if (vPEnableDisable = "E")
                    {
                        { EnumControl(MyWindow, i)}..Color = oSession.lforecolor;
                    }
                    else
                    {
                        { EnumControl(MyWindow, i)}..Color = oSession.ldisabledforecolor;
                    }
                }
                i++;
            }*/
        }

        public void FormMenu(string cType)
        {

            if (ALLTRIM(cType) == "P")
            {
                if (oSession.administrator)
                {
                    if (!EMPTY(cFunction))
                    {
                        OpenSister(new wsm1permis(), cFunction, Text, "");
                    }
                }
                else
                {
                    MESSAGEBOX(IIF(m0frch, "Cette fonction na pas besoin de permission!", "This function do not need permission!"), 16, IIF(m0frch, "Administrateur", "Administrator"));
                }
            }
            else
            {

                MESSAGEBOX(IIF(m0frch, "Vous n'avez pas accès à cette fonction!", "You do not have access to this function!"), 16, IIF(m0frch, "Administrateur", "Administrator"));

            }
        }

        public void Get_dispatch(string paction)
        {
        }

        public void NavFirst()
        {
            if (!bTableIsSet)
            {
                return;
            }

            //* Verify if user changed something and save/discard them
            if (!Verify_change())
            {
                return;
            }

            //* Used for special processes in the form (empty here)
            doBefore_nav();

            record_position = -1;

            if (gFirst(sdPTable, sMyOrder))
            {
                FileToScreen();

                record_position = 0;
            }

            EnableButtons();

            Refresh();

            //* Used for special processes in the form (empty here)
            doAfter_nav();
        }

        public void NavGo(int nLRecordId)
        {
            if (!bTableIsSet)
            {
                return;
            }

            // * Attention: NO VALIDATION, So make sure record Id is good before going here
            // * Used for special processes in the form (empty here)
            doBefore_nav();

            if (gGo(sdPTable, nLRecordId))
            {
                FileToScreen();
                record_position = nLRecordId;
            }

            EnableButtons();
            Refresh();
            doAfter_nav();
        }

        public void NavLast()
        {
            if (!bTableIsSet)
            {
                return;
            }

            //* Verify if user changed something and save/discard them
            if (!Verify_change())
            {
                return;
            }

            //* Used for special processes in the form (empty here)
            doBefore_nav();

            if (gLast(sdPTable))
            {
                //BtnFirst.Enabled = true;
                //BtnPrev.Enabled = true;

                //BtnLast.Enabled = false;
                //BtnNext.Enabled = false;
                FileToScreen();

                //record_position = RECCOUNT(sdPTable) - 1;
            }

            EnableButtons();
            Refresh();

            //* Used for special processes in the form (empty here)
            doAfter_nav();
        }

        public void NavNext()
        {
            if (!bTableIsSet)
            {
                return;
            }


            int nPos;

            //* Verify if user changed something and save/discard them
            if (!Verify_change())
            {
                return;
            }

            //* Used for special processes in the form (empty here)
            doBefore_nav();

            nPos = HSavePosition(sdPTable);
            gFirst(sdPTable, sMyOrder);
            HRestorePosition(sdPTable, nPos);
            gNext(sdPTable);

            /// ADDED STUFF
            FileToScreen();
            EnableButtons();
            Refresh();

            //* Used for special processes in the form (empty here)
            doAfter_nav();
        }

        public void NavPrev()
        {
            if (!bTableIsSet)
            {
                return;
            }

            int nPos;

            //* Verify if user changed something and save/discard them
            if (!Verify_change())
            {
                return;
            }

            //* Used for special processes in the form (empty here)
            doBefore_nav();
            nPos = HSavePosition(sdPTable);

            gFirst(sdPTable, sMyOrder);
            HRestorePosition(sdPTable, nPos);
            gPrevious(sdPTable);

            /// ADDED STUFF
            FileToScreen();

            EnableButtons();
            Refresh();

            //* Used for special processes in the form (empty here)
            doAfter_nav();

            return;

        }

        public void NavSearch()
        {
            if (!bTableIsSet)
            {
                return;
            }

            // *** public void THAT CALL THE SEARCH SCREEN ***
            int lRecordId = NULL_INT;

            // * Verify if user changed something and save/discard them
            if (!Verify_change())
            {
                return;
            }

            wsSearchForm wsSearch = new wsSearchForm(sdPTable);
            DialogResult dr = wsSearch.ShowDialog();

            if (dr == DialogResult.OK || dr == DialogResult.Cancel)
            {
                NavGo(wsSearch.RecordId);
            }

            FileToScreen();
            EnableButtons();
            ////WIP: TO CHECK WHERE THE IFS ARE SITUATED
            //if (!EMPTY(search_form) && search_modal)
            //{
            //    // *----------------------------------------------------------*
            //    // * if there is a search form, use it to get the proper rec. *
            //    // *----------------------------------------------------------*

            //    // WIP: 2 LINES TO FIX
            //     //search_form_variant.search_form_param = search_form_param;
            //    //lRecordId = DO_FORM_LINKED(search_form, search_form_variant);

            //    if (lRecordId != NULL_INT && search_form_lident == false) //  && return record number
            //    {
            //        if (lRecordId <= RECCOUNT(sdPTable))
            //        {
            //            NavGo(lRecordId);
            //        }
            //    }
            //}

            //if (lRecordId != NULL_INT && search_form_lident == true) //  && return ident
            //{
            //    // * Used for special processes in the form (empty here)
            //    doBefore_nav();

            //    gSearch(sdPTable, "ident", lRecordId + "");

            //    EnableButtons();

            //    // STORE "SET ORDER TO " + THISFORM.Search_form_order TO cCommand
            //    // &cCommand
            //    // SEEK lRecordId
            //    // if FOUND()
            //    // Thisform.bof = BOF()
            //    // Thisform.eof = EOF()
            //    // } else {
            //    // NAVGO(nRecNo)
            //    // }
            //}
        }
          
        public void NavSearch2()
        {
            if (!bTableIsSet)
            {
                return;
            }

            // gTaskLog((dbgInfo(dbgElement, dbgCallingProcess)), (dbgInfo(dbgElement)))

            if (!EMPTY(oSession.searchid) && search_form_lident == false)
            { //  && return record number

                if (oSession.searchid <= RECCOUNT(sdPTable))
                {
                    NavGo(oSession.searchid);
                }
            }

            if (!EMPTY(oSession.searchid) && search_form_lident == true) //  && return ident
            {
                // * Used for special processes in the form (empty here)
                doBefore_nav();

                //		STORE RECNO(ThisForm.DataEnvironment.InitialSelectedAlias) TO nRecNo
                //		STORE "SET ORDER TO " + THISFORM.Search_form_order TO cCommand
                //		&cCommand
                //		SEEK oSession.SearchId
                //		if FOUND()
                //			Thisform.bof = BOF()
                //			Thisform.eof = EOF()
                //		} else {
                //			GO RECORD nRecNo
                //			Thisform.bof = BOF()
                //			Thisform.eof = EOF()
                //		
                //		}

                Refresh();

                // * Used for special processes in the form (empty here)
                doAfter_nav();

            }
        }

        public virtual void RefreshBar()
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
                    BtnFirst.Visible = false;
                    BtnPrev.Visible = false;
                    BtnNext.Visible = false;
                    BtnLast.Visible = false;
                    BtnSearch.Visible = false;
                    BtnPrint.Visible = false;
                }
                else
                {
                    BtnFirst.Visible = true;
                    BtnPrev.Visible = true;
                    BtnNext.Visible = true;
                    BtnLast.Visible = true;

                    EnableButtons();

                    BtnSearch.Visible = true;


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
                    BtnFirst.Visible = false;
                    BtnPrev.Visible = false;
                    BtnNext.Visible = false;
                    BtnLast.Visible = false;
                    BtnSearch.Visible = false;
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
                    if (ALLTRIM(formaction) == "JUST1")
                    { //  && With JUST1, we are sure that we have data

                        BtnModify.Top = BtnNew.Top;
                        BtnModify.Left = BtnNew.Left;
                        // *--------------------------------*
                        // * Special for just1 option       *
                        // *--------------------------------*
                        BtnFirst.Visible = false;
                        BtnPrev.Visible = false;
                        BtnNext.Visible = false;
                        BtnLast.Visible = false;
                        BtnSearch.Visible = false;

                        if (EMPTY(report_name))
                        { // && AND EMPTY(doprint)
                            BtnPrint.Visible = false;
                        }
                        else
                        {
                            BtnPrint.Visible = true;
                        }


                        BtnNew.Visible = false;

                        if (eof && bof)
                        { // && No data
                            BtnModify.Visible = false;
                        }
                        else
                        {
                            BtnModify.Visible = true;
                        }

                        BtnDelete.Visible = false;
                        BtnSave.Visible = false;
                        BtnUndo.Visible = false;
                    }
                    else
                    {
                        // *--------------------------------*
                        // * Regular                        *
                        // *--------------------------------*
                        if (lAjout && ALLTRIM(formaction) != "J1")
                        { //	&&VERIFIE SI L'USAGER PEUT FAIRE DE L'AJOUT
                            BtnNew.Visible = true;
                        }
                        else
                        {
                            BtnNew.Visible = false;
                        }


                        if (eof && bof)
                        { // && No data

                            BtnFirst.Visible = false;
                            BtnPrev.Visible = false;
                            BtnNext.Visible = false;
                            BtnLast.Visible = false;
                            BtnSearch.Visible = false;
                            BtnModify.Visible = false;
                            BtnDelete.Visible = false;
                            BtnPrint.Visible = false;

                        }
                        else
                        {
                            // *---> if we called it WITH À specific record (=No NAVIGATION)
                            if (FormRecno != 0)
                            {
                                BtnFirst.Visible = false;
                                BtnPrev.Visible = false;
                                BtnNext.Visible = false;
                                BtnLast.Visible = false;
                                BtnSearch.Visible = false;
                            }
                            else
                            { // && No SPECIFIC RECORD

                                BtnFirst.Visible = true;
                                BtnPrev.Visible = true;
                                BtnNext.Visible = true;
                                BtnLast.Visible = true;
                                BtnSearch.Visible = true;
                            }


                            if (lModif)
                            { // &&VERIFIE SI L'USAGER PEUT FAIRE de LA MODIFICATION

                                BtnModify.Visible = true;
                            }
                            else
                            {
                                BtnModify.Visible = false;
                            }


                            if (lSupp && ALLTRIM(formaction) != "J1")
                            { // &&VERIFIE SI L'USAGER PEUT FAIRE de LA DESTRUCTION
                                BtnDelete.Visible = true;
                            }
                            else
                            {
                                BtnDelete.Visible = false;
                            }

                            EnableButtons();
                        }


                        if (EMPTY(report_name))
                        { // && AND EMPTY(doprint)
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

                    } // && JUST1 OR not


                    BtnQuit.Visible = true;
                    Closable = true;
                }
            }
        }


        public bool Valid_del()
        {

            //*** VALIDATION if WE CAN DELETE OR NOT     ***
            //*** return .T. if OK TO DELETE, .F. if NOT ***
            //
            //* if nothing is in the form, validation ok by default
            return true;
        }

        public bool Valid_mod()
        {
            //*** VALIDATION if WE CAN MODIFY THE CURRENT RECORD OR NOT     ***
            //*** return .T. if OK TO ADD, .F. if NOT ***

            //* if nothing is in the form, validation ok by default
            return true;

        }

        public bool Valid_new()
        {
            //*** VALIDATION if WE CAN ADD A NEW RECORD OR NOT     ***
            //*** return .T. if OK TO ADD, .F. if NOT ***
            //* if nothing is in the form, validation ok by default

            return true;
        }

        public virtual bool Valid_sav()
        {

            //*** VALIDATION if WE CAN SAVE OR NOT     ***
            //*** return .T. if OK TO SAVE, .F. if NOT ***

            //* if nothing is in the form, validation ok by default
            return true;
        }

        public bool Verify_change()
        {
            if (!bTableIsSet)
            {
                return false;
            }
            // *** VERIFY CHANGED BEFORE LOOSING THE CURRENT RECORD (WHEN 
            // *** ADDING A NEW ONE OR NAVIGATING)
            // *** RETURNS .F. if VALIDATION FAILED THE SAVE, .T. if OK
            // *** ---> So normally, always comes back with .T.

            //bool bL_status = true;

                // * Do we have an error if yes no change
            if (oSession.on_error_quit)
            {
                return false;
            }

            bool lmodified = false;

            if (Modified)
            {
                lmodified = true;
            }

            // * Hook for additionnal verification not handled here
            if (!lmodified)
            {
                lmodified = Verify_change_plus();
            }
   
            // * if yes, how do we handle it ?
            if (lmodified)
            {

                int? nResult;

                if (m0frch)
                {
                    //WIP
                    nResult = MESSAGEBOX("L'entrée courante a été modifiée.  Sauvegarder ?", 4 + 32 + 0, "Changement des données");
                }
                else
                {
                    //WIP
                    nResult = MESSAGEBOX("The current entry has been modified.  Save it now ?", 4 + 32 + 0, "Data changes detected");
                }

                if (nResult == 7)
                {
                    ActionUndo();

                    return true;
                }
                else
                {
                    // * Save the current record & 
                    // * return .T. if saved ok, .F. if saved failed
                    bool l_status = ActionSave();

                    return l_status;
                }
            }

            return true; //-1==-1; // Need to check if the -1 is required or used
        }

        public bool Verify_change_plus()
        {
            if (!bTableIsSet)
            {
                return false;
            }

            //* Just a hook to add verification not handled on InitialSelected
            return false; // not Modified
        }

        public void FindFirstField()
        {
            //* Find the first field for input
            //* (It will be the first on top left)
            //* return name of first field
        }

        public virtual void doAfter_nav()
        {
            //*-- Nothing in it. To use into the form. Called after moving the cursor (and after refresh).
        }
        public virtual void doBefore_new()
        {
          //*-- Nothing in it. To use into the form. Called before adding a new record.
        }
        public virtual void doAfter_new()
        {
          //*-- Nothing in it. To use into the form. Called after adding a new record (After the refresh).
        }
        public virtual void doBefore_sav()
        {
            //*-- Nothing in it. To use into the form. Called before saving the current record.
        }
        public virtual void doAfter_sav()
        {
          //*-- Nothing in it. To use into the form. Called after saving the current record.
        }
        public virtual void doAfter_undo()
        {
        }
        public virtual void doAfter_delete()
        {
        }
        public void doBefore_delete()
        {
        }
        public void doPrint()
        {
          //*-- Hook to process printing not handled by regular THISFORM.report_name

        }
        public void doBefore_savdetail()
        {
          //*-- Hook to put some code before saving the details view
        }
        public virtual void doAfter_init()
        {
          //*-- Hook to add code to form.init without having to issue a nodefault
        }
        public void doBefore_mod()
        {
        }
        public void doAfter_mod()
        {
        }
        public void doAfter_resize()
        {
        }

        public void SetQuery(string sLMyQuery, int noRec = 0, int count = 0, DataSource data = null)
        {
            bTableIsSet = true;
            if(data == null)
            {
                data = sdPTable;
            }
            data.noCurrent = noRec;
            data.MyQuery = sLMyQuery;

            gQuery(sLMyQuery, data, noRec, count, data.isFoxpro);
        }

        public void SetOrder(string sPMyOrder = "")
        {
            if (sPMyOrder == "RESET")
            {
                sMyOrder = "";
            }
            else
            {
                if (sPMyOrder != "")
                {
                    sMyOrder = sPMyOrder;
                }

                NavFirst();

                // NOTE: KJ: 2018-09-11 Cannot restore position after change of order, would need a different function that uses PK or something
                // NavFirst on order change until we can restore position        }

            }
        }

        private void DataMenu_Load(object sender, EventArgs e)
        {

        }

        public void RELEASE()
        {
            Close();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            RELEASE();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            ActionPrint();
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            ActionUndo();
            if (ALLTRIM(formaction) == "ADD" || ALLTRIM(formaction) == "MOD")
            {
                formaction = "JUST1";

                RefreshBar();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ActionSave();

            if (ALLTRIM(formaction) == "ADD" || ALLTRIM(formaction) == "MOD")
            {
                newrecord = RECNO(sdPTable);
                formaction = "JUST1";

                RefreshBar();
                // * THISFORM.Release()  no, we will do it when we go out
            }

            if (ALLTRIM(formaction) == "ADDMODAL" || ALLTRIM(formaction) == "ADDMODALFILTER")
            {
                newrecord = RECNO(sdPTable);

                RELEASE();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            NavSearch();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            ActionModify();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ActionDelete();
            if (ALLTRIM(formaction) == "DEL")
            {
                RELEASE();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ActionNew();
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            NavLast();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            NavNext();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            NavPrev();
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            NavFirst();
        }

        public void bindControls(DataSource source, Control aContainer)
        {
            string propertyName = "";
            string[] dataMember;

            foreach (Control ctrl in aContainer.Controls)
            {
                if (ctrl is GroupBox)
                {
                    bindControls(source, ctrl);
                } 

                if (ctrl.GetType().GetInterface("IDataControls") == typeof(IDataControls))
                {
                    IDataControls iControl = (IDataControls)ctrl;
                    dataMember = iControl.apControlSource.Split('.');

                    if (iControl is TextBox)
                    {
                        propertyName = "Text";
                    }

                    if (iControl is CheckBox)
                    {
                        propertyName = "Checked";
                    }

                    if (iControl is wsoptiongroup || iControl is wsnumbox)
                    {
                        propertyName = "Value";
                    }

                    if (iControl is ComboBox)
                    {
                        propertyName = "SelectedValue";

                        if (dataMember[1] == "type")
                        {
                            propertyName = "Text";
                        }
                    }

                    if (dataMember.Count() != 2)
                    {
                        return;
                    }

                    if (dataMember[0] == source.Table_name)
                    {
                        if (dataMember[1] == "")
                        {
                            return;
                        }
                        ctrl.DataBindings.Clear();

                        ctrl.DataBindings.Add(propertyName, source, ToTitleCase(dataMember[1]), false, DataSourceUpdateMode.OnPropertyChanged);
                    }

                }

            } //end foreach form control
            
        }

    }
}