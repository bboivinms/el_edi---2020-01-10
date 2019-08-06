using System;
using System.Drawing;
using System.Windows.Forms;
using vivael.wscontrols;
using static vivael.Globals;

namespace vivael.wsforms
{
    public partial class wsform : Form
    {
        private bool init_ok = false;
        private string cFunction;
        private string FormName;
        private string FormAction;
        private int FormRecno;
        private object SessionInstance;
        private string ParamPlus;
        private bool FixColor;
        private object Picture;

        private bool lAjout;
        private bool lModif;
        private bool lSupp;
        private bool lImp;
        private bool is_fixed;

        private object o_left;
        private object o_top;
        private object o_height;
        private object o_width;

        private int AlwaysOnTop;
        private int AlwaysOnBottom;
        private bool is_resizable;

        public DataSource sdPTable = new DataSource();
        public bool bTableIsSet = false;

        public int WindowType { get; set; }

        public wsform()
        {
            InitializeComponent();
        }

        public void Init(string cFormName = "", string cAction = "", int nInstance = 0, int nRecord = 0, string cParamPlus = "", bool lAjout = false, bool lModif = false, bool lSupp = false, bool lImp = false)
        {
            this.dobefore_init(); // Programer's hook

            if (init_ok == false)
            {
                Destroy();
            }

            if (m07to8)
            {
                //SET ENGINEBEHAVIOR 70
            }

            //Lorsqu'on est en développment, on load l'objet session ici
            if (TYPE(oSession) != typeof(object) || ISNULL(oSession))
            {
                oSession = new WsSession();
            }

            //Si modal on désactive tout les tool bar.
            if (this.WindowType == 1)
                oSession.Disabled_bar(0);

            if (TYPE(oSession) == typeof(object) && !ISNULL(oSession))
            {
                if (TYPE(nInstance) != typeof(int) || ISNULL(nInstance))
                {
                    this.cFunction = "";
                }
                else
                {
                    if (!EMPTY(nInstance))
                        this.cFunction = oSession.active_form[nInstance, 2];
                    else
                        this.cFunction = "";
                }
                this.FormName = cFormName;
                this.FormAction = cAction;
                this.FormRecno = nRecord;
                this.SessionInstance = nInstance;
                this.ParamPlus = cParamPlus;

                if (this.FixColor == false)
                {
                    this.BackColor = oSession.WBackColor;
                    this.ForeColor = oSession.WForeColor;
                    this.Picture = oSession.WPicture;
                }

                this.lAjout = lAjout;
                this.lModif = lModif;
                this.lSupp = lSupp;
                this.lImp = lImp;
            }
            else
            {
                this.cFunction = this.Name;
                this.FormName = this.Name;
                this.FormAction = "";
                this.SessionInstance = 0;
                this.ParamPlus = "";
                this.FormRecno = 0;
            }

            /*-----------------------------------------------------------*/
            /* Multi - language : go and get other language if need be   */
            /*-----------------------------------------------------------*/
            if (oSession.language != "EN" && oSession.language != "FR")
            {
                //WIP
            }

            /*-----------------------------------------------------------*/
            /* Keep current size and position & get last one             */
            /*-----------------------------------------------------------*/
            if (!this.is_fixed)
            {
                this.o_left = this.Left;
                this.o_top = this.Top;
                this.o_height = this.Height;
                this.o_width = this.Width;
                //SELECT sc_left, sc_top, sc_height, sc_width, sc_state, sc_ontop, sc_onbottom;
                //       FROM wskeepscn;
                //       WHERE ALLTRIM(usercode) == ALLTRIM(oSession.UserCode) AND;
                //             ALLTRIM(screen)   == ALLTRIM(THISFORM.Name);
                //       INTO ARRAY a_last_setup
                int[] a_last_setup = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

                if (a_last_setup.Length > 0)
                {
                    this.Left = a_last_setup[0];
                    this.Top = a_last_setup[1];
                    this.Height = a_last_setup[2];
                    this.Width = a_last_setup[3];
                    //* THISFORM.WindowState = a_last_setup(5)
                    this.AlwaysOnTop = a_last_setup[5];
                    this.AlwaysOnBottom = a_last_setup[6];
                }
            }
            if (this.is_resizable == true)
            {
                this.doresize();
                this.doafter_resize();
            }
            /*-----------------------------------------------------------*/
            if (oSession.date_format == "DMY")
            {
                //SET DATE DMY
            }
            else
            {
                //SET DATE  MDY
            }

            this.doafter_init(); // Programer's hook

            if (this.init_ok == false)
            { 
                this.Release();
                this.Destroy();
                this.Unload();

                return;
            }
        }

        private void Unload()
        {
            //WIP
            //*Save the current window size
            //UPDATE wskeepscn 

            //*Si modal on réactive tout les tool bar.
            if (this.WindowType == 1)
                oSession.enabled_bar(0);

            this.Close();
        }

        private void Release()
        {
            this.Hide();
        }

        private void Destroy()
        {
            //WIP
            if (!ISNULL(SessionInstance) && TYPE(SessionInstance) == typeof(int))
            {
                if ((int)SessionInstance > 0)
                {
                    oSession.shut_form((int)SessionInstance);
                }
            }
        }

        private void doresize()
        {
            //WIP
        }

        public void EnableDisable_fields(string vPEnableDisable = "") // , vPStartObject = null) // removed start object
        {
            if (!bTableIsSet)
            {
                return;
            }

            //Loop through the form and find groupbox with children and enable / disable fields
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox && control.HasChildren)
                {
                    foreach (Control ctrl in control.Controls) //loop through controls within the groupbox
                    {
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
                    }
                }
            }
        }

        public void formmenu()
        {
            //WIP
        }

        /**********Method virtual*************/
        public virtual void doafter_resize()
        {
            //WIP
        }

        public virtual void doafter_init()
        {
            //WIP
        }

        public virtual void dobefore_init()
        {
            //WIP
        }

        public virtual void dobefore_opentable()
        {
            //WIP
        }
    }
}
