using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
            //WIP
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
            if(cSearchExpression == ",")
            {
                return cExpressionSearched.IndexOf(cSearchExpression, cExpressionSearched.ToString().IndexOf(",") + nOccurrence-1);
            }
            return cExpressionSearched.IndexOf(cSearchExpression, 0, nOccurrence);
        }

        public static bool SEEK(string cExpression)
        {
            return true;
        }

        /// <summary>
        /// Displays the Printer dialog box and returns the name of the selected printer.
        /// </summary>
        public static string GETPRINTER(bool showDialog = true)
        {
            PrintDialog pd = new PrintDialog();
            if(showDialog)
                pd.ShowDialog();
            PrinterSettings settings = pd.PrinterSettings;
            return settings.PrinterName;
        }

        public static void SETPRINTER(string printerName)
        {
            SetDefaultPrinter(printerName);
        }

        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Printer);

        /// <summary>
        /// Divides one numeric expression by another numeric expression and returns the remainder.
        /// </summary>
        /// <param name="nDividend">Specifies the dividend. The number of decimal places in nDividend determines the number of decimal places in the return value.</param>
        /// <param name="nDivisor">Specifies the divisor. A positive number is returned if nDivisor is positive, and a negative number is returned if nDivisor is negative.</param>
        /// <returns>Numeric value</returns>
        public static decimal MOD(decimal nDividend, decimal nDivisor)
        {
            return (nDividend % nDivisor);
        }

        /// <summary>
        /// Returns the year from the specified date or datetime expression.
        /// </summary>
        /// <param name="dExpression">Specifies a date expression from which YEAR( ) returns the year. dExpression can be a function that returns a date, or a Date-type memory variable, array element, or field. 
        /// It can also be a literal date string, such as {^1998-06-06}.</param>
        /// <returns>Numeric value</returns>
        public static int YEAR(string dExpression)
        {
            return DateTime.Parse(dExpression).Year;
        }

        /// <summary>
        /// Returns the year from the specified date or datetime expression.
        /// </summary>
        /// <param name="tExpression">Specifies a datetime expression from which YEAR() returns the year.</param>
        /// <returns>Numeric value</returns>
        public static int YEAR(DateTime tExpression)
        {
            return tExpression.Year;
        }
        
        /// <summary>
        /// Returns the current system date, which is controlled by the operating system, or creates a year 2000-compliant Date value.
        /// </summary>
        /// <param name="nYear">Specifies the year returned in the year 2000-compliant Date value. nYear can be a value from 100 to 9999.</param>
        /// <param name="nMonth">Specifies the month returned in the year 2000-compliant Date value. nMonth can be a value from 1 to 12.</param>
        /// <param name="nDay">Specifies the day returned in the year 2000-compliant Date value. nDay can be a value from 1 to 31.</param>
        /// <returns>Date</returns>
        public static DateTime DATE(int nYear = 0, int nMonth = 0, int nDay = 0)
        {
            if (nYear != 0 && nMonth != 0 && nDay != 0)
                return new DateTime(nYear, nMonth, nDay);
            else
                return DateTime.Today;
        }

        public static char CHR(int nANSICode)
        {
            return Convert.ToChar(nANSICode);
        }

        /// <summary>
        /// Locates the specified file.
        /// </summary>
        /// <param name="cFileName">Specifies the name of the file to locate. cFileName must include the file extension.
        /// You can include a path with the file name to search for a file in a directory or on a drive other than the current directory or drive.</param>
        /// <param name="nFlags">Specifies the kind of value FILE( ) returns when the file exists but might be marked with the Hidden or System attribute.
        /// The following table lists the values for nFlags.</param>
        /// <returns>Logical data type. FILE() returns True (.T.) if the specified file is found on disk; otherwise, it returns False (.F.).</returns>
        public static bool FILE(string cFileName, int nFlags = 0)
        {
            if (nFlags == 0)
            {
                FileAttributes Attribut = File.GetAttributes(cFileName);
                if ((Attribut & FileAttributes.Hidden) == FileAttributes.Hidden || (Attribut & FileAttributes.System) == FileAttributes.System)
                {
                    return false;
                }
            }

            return File.Exists(cFileName);
        }

        /// <summary>
        /// Locates the specified directory. 
        /// </summary>
        /// <param name="cDirectoryName">Specifies the name of the directory to locate. If you do not include an absolute path for the directory you specify,
        /// Visual FoxPro searches for the directory relative to the Visual FoxPro default directory.</param>
        /// <param name="nFlags">Specifies the kind of value DIRECTORY( ) returns when the directory
        /// exists but might be marked with the Hidden or System attribute. The following table lists the values for nFlags.</param>
        /// <returns>Logical data type. FILE() returns True (.T.) if the specified file is found on disk; otherwise, it returns False (.F.).</returns>
        public static bool DIRECTORY(string cDirectoryName, int nFlags = 0)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(cDirectoryName);
            FileAttributes Attribut = dirInfo.Attributes;
            if (nFlags == 0)
            {
                if ((Attribut & FileAttributes.Hidden) == FileAttributes.Hidden || (Attribut & FileAttributes.System) == FileAttributes.System)
                {
                    return false;
                }
            }
            return Directory.Exists(cDirectoryName);
        }

        /// <summary>
        /// Returns the number of elements, rows, or columns in an array.
        /// </summary>
        /// <param name="ArrayName">Specifies the name of the array. If you include only the array name, ALEN( ) returns the number of elements in the array.</param>
        /// <param name="nArrayAttribute">Determines whether ALEN( ) returns the number of elements, rows or columns in the array.</param>
        /// <returns>Numeric</returns>
        public static int ALEN(Array ArrayName, int nArrayAttribute = 0)
        {
            //if 0, Returns the number of elements in the array. Omitting nArrayAttribute is identical to specifying 0.
            if (nArrayAttribute == 0)
            {
                return ArrayName.Length;
            }
            //if 1, Returns the number of rows in the array.
            else if(nArrayAttribute == 1)
            {
                return ArrayName.GetLength(0);
            }
            //if 2, Returns the number of columns in the array. If the array is a one - dimensional array, ALEN() returns 0(no columns).
            else if(nArrayAttribute == 2)
            {
                if (ArrayName.Rank > 1)
                {
                    return ArrayName.GetLength(1);
                }
            }
            //else, return 0 it is an error.
            return 0;
        }

        /// <summary>
        /// Determines the number of characters in a character expression, indicating the length of the expression.
        /// </summary>
        /// <param name="cExpression">Specifies the character expression for which LEN( ) returns the number of characters.</param>
        /// <returns>Numeric. LEN( ) returns the number of characters in a character expression.</returns>
        public static int LEN(string cExpression)
        {
            return cExpression.Length;
        }

        /// <summary>
        /// Returns the numeric day of the month for a given Date or DateTime expression.
        /// </summary>
        /// <param name="date"></param>
        public static int DAY(DateTime date)
        {
            return date.Day;
        }

        /// <summary>
        /// Returns the number of the month for a given Date or DateTime expression.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static int MONTH(DateTime date)
        {
            return date.Month;
        }
    }
}