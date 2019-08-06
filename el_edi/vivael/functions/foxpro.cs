using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.wsforms;

namespace vivael
{
    public partial class Globals
    {
        private static readonly Random getrandom = new Random();

        /// <summary>
        ///  Removes all leading and trailing spaces.
        /// </summary>
        public static string ALLTRIM(string vValue)
        {
            return vValue.Trim();
        }

        /// <summary>
        ///  Removes all leading and trailing spaces or parsing characters from the specified character expression, or all leading and trailing zero (0) bytes from the specified binary expression.
        /// </summary>
        public static string ALLTRIM(string value, char cParseChar, char cParseChar2)
        {
            return value.Trim(cParseChar, cParseChar2);
        }

        /// <summary>
        ///  Determines whether an expression evaluates to empty.
        /// </summary>
        public static bool EMPTY(object vValue)
        {
            return vValue.ToString() != "";
        }

        /// <summary>
        ///  Determines whether an string expression evaluates to a empty string.
        /// </summary>
        public static bool EMPTY(string sValue)
        {
            return (sValue + "") == "";
        }

        /// <summary>
        /// Returns the character equivalent of a numeric expression
        /// </summary>
        /// <param name="vValue">Specifies the numeric expression to evaluate.</param>
        /// <param name="nExpression">Not use in C#, just for be like Foxpro</param>
        /// <param name="nDecimalPlaces">Specifies the number of decimal places in the character string returned. If nDecimalPlaces is omitted, the number of decimal places defaults to zero (0).</param>
        /// <returns>Character data type. STR() returns a character string equivalent to the specified numeric expression.</returns>
        public static string STR(object vValue, int nExpression = 0, int nDecimalPlaces = 0)
        {
            if(vValue.GetType() == typeof(double))
            {
                vValue = Math.Round(Convert.ToDouble(vValue), nDecimalPlaces);
            }
            return vValue.ToString();
        }

        /// <summary>
        /// Displays a user-defined dialog box.
        /// </summary>
        /// <param name="eMessageText">Specifies the text that appears in the dialog box. You can also specify any valid Visual FoxPro function, object, or data type instead of eMessageText.
        /// The maximum amount of text you can specify is 1024 characters.</param>
        /// <param name="vNDialogBoxType">Specifies the buttons and icons that appear in the dialog box, the default button when the dialog box is displayed, and the behavior of the dialog box.</param>
        /// <param name="vCTitleBarText">Specifies the text that appears in the title bar of the dialog box. If you omit cTitleBarText, nothing will appears in the title bar.</param>
        /// <param name="vNTimeout">Specifies the number of milliseconds Visual FoxPro displays eMessageText without input from the keyboard or the mouse before clearing eMessageText.</param>
        /// <returns></returns>
        public static int MESSAGEBOX(string eMessageText, int vNDialogBoxType = 0, string vCTitleBarText = "", int? vNTimeout = null)
        {
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

            return (int)result;
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

        public static int RECNO(DataSource sdPTable)
        {
            //NOTE: FOXPRO Function, gets the current record number, probably not used in mysql
            return sdPTable.noCurrent;
        }

        /// <summary>
        /// Returns true if an expression evaluates to a null value; otherwise, ISNULL() returns false.
        /// </summary>
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
        /// Returns a specified number of characters from a character expression, starting with the leftmost character.
        /// </summary>
        /// <param name="cExpression">Specifies the character expression that LEFT() returns characters from.</param>
        /// <param name="nExpression">Specifies the number of characters returned from the character expression. If nExpression is greater than the length of cExpression, all of the character expression is returned.
        /// If nExpression is negative or 0, LEFT( ) returns an empty string.</param>
        /// <returns>Character. LEFT() returns a character string.</returns>
        public static string LEFT(string cExpression, int nExpression)
        {
            return cExpression.Substring(0, nExpression);
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

        /// <summary>
        /// Returns the data type of an expression.
        /// </summary>
        public static Type TYPE(object value)
        {
            return value.GetType();
        }

        /// <summary>
        /// Searches a character expression for the occurrence of another character expression and returns the position where the string was found.
        /// </summary>
        public static int AT(string cSearchExpression, string cExpressionSearched, int nOccurrence = 1)
        {
            return cExpressionSearched.IndexOf(cSearchExpression, 0, nOccurrence);
        }
    }
}