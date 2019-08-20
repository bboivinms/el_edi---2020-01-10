using EDI_RSS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.classes;
using vivael.forms;
using vivael.wscontrols;

namespace vivael
{
    public partial class Globals
    {
        // Foxpro notes: 
        // - Please note that in foxpro, all variables are automatically boolean and set to false, until explicitly set
        // - The height of a form needs to be 30px bigger than foxpro form height since it includes the header portion that includes min/max/close buttons
        //
        // WinDev resserved Name = replacement Name
        // currency = rn_currency
        // Visible = rn_Visible

        static Globals() { }
        public Globals() { }

        public static int NULL_INT = -987654321;
        public static string CR = "\r\n";
        public static string Active = "Active";
        public static string Grayed = "Grayed";

        public static string gsUserName;
        public static DataSource gsdWsUser;
        public static string gsDatabase = "vivadata4";
        //public static Vendor vendor = new EDI_RSS.Vendor();

        public static object no_version = 2019.00;
        public static bool m0frch = true;           //True for french and false for English
        public static object m0flat = false;        //&& Lui, il marche en 3D
        public static object m0xp = false;
        public static object m0xpxcheme = false;
        public static bool m0xpscheme = false;      //ADDED_VARIABLE_KJ_2018_06_05 // KJ: 2018-10-03: Foxpro + GoFish: Never set to true
        public static bool m07to8 = false;
        public static bool m0checkdb = false;

        public static WsSession oSession; // oSession = new wssession // automatically creates new
        public static wsPrintForm oPrintForm;
        public static VivaMainWindow menu;

        public static object oReindexer;
        public static object oVivaSoft;
        public static object MySQL_lnHandle;
        public static object gidclient;
        public static object gmd5; //CREATEOBJECT("MD5")
        public static object idproduit;

        //mysql
        public static object wMyLog = "";
        public static object wMyErrorLog = "";
        public static object MySQLError = "";
        public static object MySQLExpectedCount = 0;
        public static object mySQLActualCount = 0;
        public static object iswebemail = false;

        public static object MySQL_lnHandle2 = 0;
        public static object wMyLog2 = "";
        public static object wMyErrorLog2 = "";
        public static object MySQLError2 = "";
        public static object MySQLExpectedCount2 = 0;
        public static object mySQLActualCount2 = 0;
        public static object MYSQL_LNHANDLE_IS_BOOL2 = false;
        public static object tv = false;
        public static object trfval = 0;
        public static object loc = "";
        public static object vmaint = "";

        public static object glastattempt;
        public static int pArRep = 0; //&& For users that are rep, this is their rep id
        public static object pArLimited = false; //&& The user is limited to his own accounts
        public static object lset_menu = false;
        public static object lcDatabase;

        public static SmtpClient loSmtp = new SmtpClient("smtp-mail.outlook.com");
        public static object lcimp;
        public static object blcouriel;
        public static object lastInsertId;
        public static bool isPompoThere = false;
        public static bool gCancelEmail = true;

        // gwsfield is array<growth=1> of wsfield // Should no longer be needed, was added in order to add properties to textbox in windev
        public static int gIPType = 0;

        /// <summary>
        /// Returns a Color value from a Integer expression.
        /// </summary>
        /// <param name="intColor">Specifies a integer expression of a color.</param>
        /// <returns>Color. IntToColor() returns a Color.</returns>
        public static Color IntToColor(int intColor)
        {
            byte[] byteColor = BitConverter.GetBytes(intColor);
            return Color.FromArgb(byteColor[0], byteColor[1], byteColor[2]);
        }

        public static void TranslateForm(Control aContainer)
        {
            foreach (Control ctrl in aContainer.Controls)  //Loop through the control
            {
                if(ctrl is wsgroupbox || ctrl is Panel)
                {
                    TranslateForm(ctrl);
                }

                if (ctrl is WsControl)
                {
                    WsControl control = (WsControl)ctrl;
                    if (control.Text_EN != null && control.Text_FR != null)
                        ctrl.Text = IIF(m0frch, control.Text_FR, control.Text_EN);
                }
            }

            if (aContainer is WsControl)
            {
                WsControl control = (WsControl)aContainer;
                if (control.Text_EN != null && control.Text_FR != null)
                    aContainer.Text = IIF(m0frch, control.Text_FR, control.Text_EN);
            }
        }

        public static object GetForm(string FormName)
        {
            var _formName = (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                             where t.Name.Equals(FormName)
                             select t.FullName).Single();
            object _form = Activator.CreateInstance(Type.GetType(_formName));

            return _form;
        }

        /// <summary>
        ///  Called by ALT-F1 everywhere                 
        /// </summary>
        public static void XXALTF1()
        {
            WAIT("You pressed ALT-F1", "WINDOW NOWAIT");
            return;
        }

        /// <summary>
        ///  Standard function to use instead of messagebox for simple message                                       
        /// </summary>
        /// <param name="pmessage">Message to display</param>
        /// <param name="ptitle">Title to display</param>
        public static int XMessage(string pmessage, string ptitle)
        {
            return MESSAGEBOX(pmessage, 0 + 64, ptitle);
        }

        /// <summary>
        ///  Standard function to use instead of messagebox for simple error message                                       
        /// </summary>
        /// <param name="pmessage">Message to display</param>
        /// <param name="ptitle">Title to display</param>
        public static int XError(string pmessage, string ptitle)
        {
            return MESSAGEBOX(pmessage, 0 + 16, ptitle);
        }

        /// <summary>
        ///  Standard function to use instead of messagebox for simple message 
        /// </summary>
        /// <param name="pmessage">Message to display</param>
        /// <param name="ptitle">Title to display</param>
        /// <returns>true = Yes</returns>
        public static bool XYesNo(string pmessage, string ptitle)
        {
            int theanswer;
            theanswer = MESSAGEBOX(pmessage, 4 + 32 + 256, ptitle);
            if (theanswer == 6)
                return true; // && Yes
            else
                return false; // && No
        }
    }
}
