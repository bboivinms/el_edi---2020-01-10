using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vivael.forms;
using static vivael.Globals;

namespace vivael.classes
{
    /// <summary>
    ///  Class that can be used to output a form from a single cursor
    /// </summary>
    /// ---------------------------------------------------------------------------
    ///        DD/MM/YY BY Code  Details
    /// ---------------------------------------------------------------------------
    /// <NN1>  19/09/06 EC EC19  Correction to default the basket correctly. </NN1>
    /// ---------------------------------------------------------------------------
    public class wsPrintForm
    {
        //**------- Private properties ------------***
        private string cCursorName = ""; //datasource
        private int DATASESSION;

        //**------- Public properties -------------***
        public string cFormName = "";
        public string cOptions = "";                // (P) rint, (F)ax, (E) mail, etc...
        public string cSpecialInstruction = "";     // When whe use FOR in the call of the report
        public string cAction = "";                 // Current selected action
        public int nDataSession = 0;                       // Use the correct DataSession for the cursor Rapport or if there is a FOR CONDITION USED IN THE CALL OF THE REPORT.

        //* SET PRINTER TO NAME lcprinter
        public string cDefaultPrinter = GETPRINTER(false); //SET('PRINTER',3);
        //* cDefaultPrinter     = lcprinter()
        public string cParam = "";
        public string cReportName = "";
        public string cFormCode = "";
        public string mNotes = "";          // Used for modify report
        public string cNotes = "";          // to set the note in the email
        public bool? lStdForm = false;
        public bool? lDefForm = false;
        public bool? lEnabled = false;
        public int nIdent = 0;
        public string cContact = "";        // Keep only for compatibility with old forms
        public string cContactEmail = "";
        public string cContactFax = "";
        public string cCie = "";
        public string cSubject = "";
        public string cSubjectEmail = "";
        public string cSubjectFax = "";
        public string cMailAction = "Ask";
        public string cFaxAction = "Ask";
        public string cFax = "";
        public string cMailTo = "";
        public string cCc = "";
        public string cBcc = oSession.email;
        public string cOutputName = "";
        public string cTempDir = oSession.tmppath;
        public string ctermedir = oSession.ciepath;
        public string cBasketDir = oSession.basket_folder;  // EC19
        public string cFormat = "PDF";      // Format pour EXPORT
        public string cType = "F";          // R = REPORT L = LABEL
        public bool lBatchFirst = true;
        public bool lBatch = false;
        public bool lMultiXFRX = false;     // Utiliser pour merger plusieur rapport en un document PDF(XFRX)
        public bool lFirstMultiXFRX = true; // Le premier coup on créer le fichier. Remettre à true après le process.
        public bool lStartApp = true;       // true = Ne pas démarrer l'application qui correspond au type de document
        public bool lOkExport = true;       // Click Ok dans la forme d'export
        public object loSession = null;
        public string cCritere = "";
        public string cZipName = "";
        public string cParamplus = "";
        //* pour le log ds fflog
        public string cLogOrigin = "";
        public string cLogDescr = "";
        public int iLOgConsolid = 0;
        public int iLogFileid = 0;
        public string cLogDetails = "";
        public bool lLogActive = false;
        public bool AddToBasket = false;
        public object oFreight;

        public wsPrintForm()
        {
            Init();
        }

        /// <summary>
        ///  wwPrintForm :: Init.                      
        ///  Sets the initial values      
        /// </summary>
        public void Init()
        {
            this.cOptions = "PVX"; // Default
            if (oSession.email_bcc_self && !EMPTY(oSession.UserEmail))
            {
                this.cBcc = oSession.UserEmail;
            }
        } // Init

        /// <summary>
        ///  wwPrintForm::Print.                                        
        ///  Main method to print(or fax, or export, ...)    
        /// </summary>
        /// <param name="lcFormCode"></param>
        /// <param name="lcCursorName"></param>
        /// <param name="lcOptions"></param>
        /// <param name="lcSpecialInstruction"></param>
        /// <param name="lnDataSession"></param>
        /// <param name="lcPrintForm"></param>
        /// <param name="lcType"></param>
        /// <param name="lcBatch"></param>
        /// <param name="lcParamplus"></param>
        public void Print(string lcFormCode, string lcCursorName = "", string lcOptions = "", string lcSpecialInstruction = "", int lnDataSession = 0, string lcPrintForm = "", string lcType = "", object lcBatch =  null, string lcParamplus = "")
        {

            this.cFormCode = ALLTRIM(lcFormCode);
            this.cCursorName = lcCursorName;

            if (TYPE(lcParamplus) != typeof(string) || ISNULL(lcParamplus))
                this.cParamplus = "";
            else
                this.cParamplus = lcParamplus;


            if (TYPE(lcType) != typeof(string) || ISNULL(lcType) || EMPTY(lcType))
                this.cType = "R";
            else
                this.cType = lcType;


            if (!ISNULL(lcBatch) && TYPE(lcBatch) == typeof(bool))
                lBatch = (bool)lcBatch;
            else
                lBatch = false;


            if (AT(",", lcOptions, 1) > 0)
            {
                this.cOptions = SUBSTR(lcOptions, 0, AT(",", lcOptions, 1));
                this.cParam = SUBSTR(lcOptions, AT(",", lcOptions, 1) + 1);
            }
            else
                this.cOptions = lcOptions;


            this.cSpecialInstruction = lcSpecialInstruction;
            this.nDataSession = lnDataSession;

            if (this.nDataSession != 0)  
                DATASESSION = this.nDataSession;  //UNKNOWN


            if (this.lBatch && this.lBatchFirst == false)
            {
                this.SelectAction("P");
            }

            if( this.cOptions == "p")
            {
                this.SelectAction("p");
            }

            if (this.lBatchFirst && this.cOptions != "p")
            {
                if (EMPTY(lcPrintForm))
                {
                    oSession.Launch_Form("wsprintform", "", 0, this.cParamplus);
                }
                else
                {
                    //WIP
                    Console.WriteLine("Pas d'autres formulaire pour imprimer, prendre wsprintform : ligne 174");
                    //oSession.Launch_Form(lcPrintForm, "", 0, this.cParamplus);
                }
            }

        } // Print

        /// <summary>
        ///  wwPrintForm::SelectAction.
        /// Allows the user to select the action within the
        /// available options(cOptions)                         
        ///           The selected action goes into this.cAction           
        /// </summary>
        /// <param name="lcAction"></param>
        public void SelectAction(string lcAction)
        {
            string cReportCommand;
            ReportDocument reportDocument = new ReportDocument();
            reportDocument.Load(@"C:\vivael\CrystalReport\" + this.cReportName);

            reportDocument.DataSourceConnections.Clear();  //To remove when live or when test report mysql
            reportDocument.DataSourceConnections[0].SetConnection(@"C:\vivael\data", "", false); 

            PrintDialog print = new PrintDialog();

            this.cAction = lcAction; //* for selection

            if (this.nDataSession != 0)
                DATASESSION = this.nDataSession;  //UNKNOWN

            switch (lcAction)
            {
                case "V": //Preview

                    ReportPreview loPrv = new ReportPreview(reportDocument);
                    loPrv.Text = "Print Preview";
                    loPrv.Show();

                    break;
                case "P": //Print WITH DIALOG

                    print.AllowSomePages = true;
                    print.AllowPrintToFile = false;

                    if (print.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int copies, fromPage, toPage;
                        bool collate;
                        if (print.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.AllPages)
                        {
                            copies = print.PrinterSettings.Copies;
                            fromPage = 0;
                            toPage = 0;
                            collate = print.PrinterSettings.Collate;
                        }
                        else
                        {
                            copies = print.PrinterSettings.Copies;
                            fromPage = print.PrinterSettings.FromPage;
                            toPage = print.PrinterSettings.ToPage;
                            collate = print.PrinterSettings.Collate;
                        }


                        reportDocument.PrintOptions.PrinterName = print.PrinterSettings.PrinterName;
                        reportDocument.PrintToPrinter(copies, collate, fromPage, toPage);
                    }
                    print.Dispose();

                    break;
                case "p": //Print WITHOUT PROMPT

                    reportDocument.PrintOptions.PrinterName = print.PrinterSettings.PrinterName;
                    reportDocument.PrintToPrinter(print.PrinterSettings.Copies, print.PrinterSettings.Collate, print.PrinterSettings.FromPage, print.PrinterSettings.ToPage);

                    print.Dispose();

                    break;
                case "f": //fax
                    //NOT USED TODAY
                    break;
                case "E": //Email

                    if (EMPTY(this.cContactEmail) && !EMPTY(this.cContact))
                    {
                        this.cContactEmail = this.cContact;
                    }

                    if(EMPTY(this.cSubjectEmail) && !EMPTY(this.cSubject))
                    {
                        this.cSubjectEmail = this.cSubject;
                    }

                    if(this.lFirstMultiXFRX == true)
                    {
                        this.cOutputName = oSession.get_unique_file_name("Short");

                        //this.loSession = XFRX("XFRX#INIT");
                        if (!EMPTY(this.cZipName))
                        {
                            //this.loSession.SetParams(ALLTRIM(this.cTempdir) + "\\" + ALLTRIM(this.cOutputName), this.cTempdir, true,,,, "PDF", ALLTRIM(this.cTempdir) + "\\" + ALLTRIM(this.cZipName) + ".ZIP", true, true);
                        }
                        else
                        {
                            //this.loSession.SetParams(ALLTRIM(this.cTempdir) + "\\" + ALLTRIM(this.cOutputName), this.cTempdir, true,,,, "PDF");
                        }

                        //this.loSession.setAuthor(oSession.UserName);
                        //this.loSession.setTitle("");
                        //this.loSession.setSubject(THIS.cSubjectEmail);
                        //this.loSession.setCreator(oSession.UserName);
                        //this.loSession.setProducer("Enveloppe Laurentide Inc.");
                        this.lFirstMultiXFRX = false;
                    }
                    //this.loSession.setEmbeddingType(2);
                    //this.loSession.ProcessReport(THIS.cReportName, SUBSTR(THIS.cSpecialInstruction, 5),,,);

                    if (this.lMultiXFRX == false)
                    {
                        //this.loSession.finalize();
                        if (!EMPTY(this.cZipName))
                        {
                            oSession.Mail_queue(this.cMailAction, "Now", this.cMailTo, this.cCc, this.cBcc, this.cSubjectEmail, this.cNotes, ALLTRIM(this.cTempDir) + "\\" + ALLTRIM(this.cZipName) + ".ZIP");
                            this.cZipName = "";
                        }
                        else
                        {
                            oSession.Mail_queue(this.cMailAction, "Now", this.cMailTo, this.cCc, this.cBcc, this.cSubjectEmail, this.cNotes, ALLTRIM(this.cTempDir) + "\\" + ALLTRIM(this.cOutputName) + ".PDF");
                        }

                        if (isPompoThere == true)
                        {
                            //**si on envoie un courriel et non annuler
                            if (gCancelEmail == false)
                            {
                                //Code for Edi850(strXML, errorXML)
                            }
                        }

                        this.lFirstMultiXFRX = true;
                        this.cOutputName = "";
                    }

                    //*Log into fflog
                    if (this.lLogActive && (this.iLOgConsolid != 0 || this.iLogFileid != 0) && !EMPTY(this.cLogDescr))
                    {
                        //oFreight.save_fflog(this.cLogOrigin, ALLTRIM(this.cLogDescr), this.iLOgConsolid, this.iLogFileid, "Emailed to " + ALLTRIM(this.cMailTo), this.cLogDetails);
                    }

                    break;
                case "D": //Email DIRECT

                    break;
                case "Z": //Email avec fichier termes

                    break;
                case "B": //Basket
                    //NOT USED
                    break;
                case "X": //Export
                    //NOT USED
                    break;
                case "M": //Modify  && A FAIRE : LABEL

                    break;
                case "N": //New   && A FAIRE : LABEL

                    break;
            }
        }

        /// <summary>
        ///  wwPrintForm::Update_wspform(). 
        ///  Update the table wspform with new values
        /// </summary>
        public void Update_wspform()
        {
            //UPDATE wspform;
            //SET wspform.def_form = THIS.lDefForm,;
            //wspform.Enabled = THIS.lEnabled;
            //WHERE wspform.ident = THIS.nIdent
        }
    }
}