using System;
using System.Drawing;
using System.Windows.Forms;
using vivael.wscontrols;
using static vivael.Globals;

namespace vivael.wsforms
{
    public partial class wsform : DataMenu
    {
        protected object report_action { get; set; } = false;
        protected bool FixColor { get; set; } = false;
        protected bool is_fixed { get; set; } = false; //If set to true, don't read last position and setup
        protected int AlwaysOnTop { get; set; }
        protected int AlwaysOnBottom { get; set; }

        public wsform()
        {
            InitializeComponent();
        }

        public override bool Init(string cFormName, string cAction = "", object nInstance = null, int nRecord = 0, object cParamPlus = null,
                         bool lAjout = true, bool lModif = true, bool lSupp = true, bool lImp = true)
        {
            this.dobefore_init(); // Programer's hook

            if (init_ok == false)
            {
                Destroy();
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
                    this.cFunction = oSession.active_form[(int)nInstance, 2].ToString();
                }
                formname = cFormName;
                formaction = cAction;
                FormRecno = nRecord;
                SessionInstance = nInstance;
                ParamPlus = cParamPlus;

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
                this.formname = this.Name;
                this.formaction = "";
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

            this.doafter_init(); // Programer's hook

            if (this.init_ok == false)
            { 
                this.Release();
                this.Destroy();
                this.Unload();
                return false;
            }

            return true;
        }

        private new void Unload()
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

        private new void Destroy()
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
