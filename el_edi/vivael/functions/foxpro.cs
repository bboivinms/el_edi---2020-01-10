using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.wsforms;

namespace vivael
{
    public partial class Globals
    {
        private static readonly Random getrandom = new Random();

        public static string ALLTRIM(string vValue)
        {
            return vValue.Trim();
        }

        public static bool EMPTY(object vValue)
        {
            return vValue.ToString() != "";
        }

        public static bool EMPTY(string sValue)
        {
            return (sValue + "") == "";
        }

        public static string STR(object vValue)
        {
            return vValue.ToString();
        }

        public static int MESSAGEBOX(string eMessageText, int vNDialogBoxType = 0, string vCTitleBarText = "", int? vNTimeout = null)
        {
            //gMessageBox form = new gMessageBox();

            //form.vNDialogBoxType = vNDialogBoxType;
            //form.vCTitleBarText = vCTitleBarText;
            //form.eMessageText = eMessageText;
            //form.vNTimeout = vNTimeout;
            //form.ShowDialog();

            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
            MessageBoxIcon icon = MessageBoxIcon.None;
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;

            if (vNDialogBoxType >= 512)
            {
                defaultButton = MessageBoxDefaultButton.Button3;
                vNDialogBoxType -= 512;
            }
            else if (vNDialogBoxType >= 256)
            {
                defaultButton = MessageBoxDefaultButton.Button2;
                vNDialogBoxType -= 256;
            }

            if (vNDialogBoxType >= 64)
            {
                icon = MessageBoxIcon.Information;
                vNDialogBoxType -= 64;
            }
            else if (vNDialogBoxType >= 48)
            {
                icon = MessageBoxIcon.Exclamation;
                vNDialogBoxType -= 48;
            }
            else if (vNDialogBoxType >= 32)
            {
                icon = MessageBoxIcon.Question;
                vNDialogBoxType -= 32;
            }
            else if (vNDialogBoxType >= 16)
            {
                icon = MessageBoxIcon.Stop;
                vNDialogBoxType -= 16;
            }

            if (vNDialogBoxType >= 5)
            {
                messageBoxButtons = MessageBoxButtons.RetryCancel;
                vNDialogBoxType -= 5;
            }
            else if (vNDialogBoxType >= 4)
            {
                messageBoxButtons = MessageBoxButtons.YesNo;
                vNDialogBoxType -= 4;
            }
            else if (vNDialogBoxType >= 3)
            {
                messageBoxButtons = MessageBoxButtons.YesNoCancel;
                vNDialogBoxType -= 3;
            }
            else if (vNDialogBoxType >= 2)
            {
                messageBoxButtons = MessageBoxButtons.AbortRetryIgnore;
                vNDialogBoxType -= 2;
            }
            else if (vNDialogBoxType >= 1)
            {
                messageBoxButtons = MessageBoxButtons.OKCancel;
                vNDialogBoxType -= 1;
            }
            DialogResult result;

            if (vNTimeout != null)
            {
                AutoClosingMessageBox.Show(eMessageText, vCTitleBarText, (int)vNTimeout, messageBoxButtons, icon);
                return -1;
            }
            else
            {
                 result = MessageBox.Show(eMessageText, vCTitleBarText, messageBoxButtons, icon, defaultButton);
            }

            return (int)result; // temporarily return 1 until modal + parameters are working etc.
        }

        public static void WAIT(string sParam1, string sParam2)
        {
            gMsgBox(sParam1, sParam2);
        }

        public static int CINT(object vValue)
        {
            return Convert.ToInt32(vValue);
        }

        public static int RAND(int min = 0, int max = 1000000000)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }

        public static void BEGIN_TRANSACTION()
        {

        }

        public static void END_TRANSACTION()
        {

        }


        public static void TABLEREVERT(bool bLAllRows)
        {

        }

        public static int RECNO()
        {
            //NOTE: FOXPRO Function, gets the current record number, probably not used in mysql
            return 0;
        }

        public static bool ISNULL(object vValue)
        {

            return vValue == null;
        }

        public static void SET_FILTER(DataSource sdPTable, object vCParamPlus)
        {

        }

        public static int RECCOUNT(DataSource sdPTable)
        {
            return sdPTable.RECCOUNT();
        }

        public static object DO_FORM_LINKED(string sForm_name, object vForm_parameters)
        {
            //WIP: NOW(); // var form = Activator.CreateInstance(Type.GetType("vivael." + sForm_name)) as DataMenu;
            // form.parameters = vForm_parameters;
            // form.ShowDialog();

            return null; // temporarily return null until modal + parameters are working etc.
        }

        public static void DODEFAULT()
        {

        }

        public static void NODEFAULT()
        {

        }

        /// <summary>
        ///  Returns a specified number of characters from a character expression, starting with the leftmost character.
        /// </summary>
        public static string LEFT(string value, int length)
        {
            return value.Substring(0, length);
        }

        /// <summary>
        ///  Returns a character string from the given character expression or memo field, starting at a specified position in the character expression or memo field.
        /// </summary>
        public static string SUBSTR(string cExpression, int nStartPosition)
        {
            return cExpression.Substring(nStartPosition);
        }

        /// <summary>
        ///  Returns a character string from the given character expression or memo field, starting at a specified position in the character expression or memo field and continuing for a specified number of characters.
        /// </summary>
        public static string SUBSTR(string cExpression, int nStartPosition, int nCharactersReturned)
        {
            return cExpression.Substring(nStartPosition, nCharactersReturned);
        }

        /// <summary>
        ///  Evaluates a numeric expression and returns the integer portion of the expression.
        /// </summary>
        public static int INT(decimal nExpression)
        {
            return Convert.ToInt32(nExpression);
        }

        /// <summary>
        ///  Returns a numeric value from a character expression composed of numbers.
        /// </summary>
        public static decimal VAL(string value)
        {
            return Convert.ToDecimal(value);
        }
    }
}