using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static vivael.Globals;
using static EDI_DB.Data.Base;
using vivael.forms;

namespace vivael
{
    public class WsSession
    {
        public Dictionary<string, string> Params = new Dictionary<string, string>();
        /*********wssession property************/
        public object accnt_allowed_days { get; set; }
        public object accountant { get; set; }
        public object accounting { get; set; }
        public object accpac { get; set; }
        public object aci_active { get; set; }
        public bool administrator { get; set; }
        public object auth_passwd { get; set; }
        public object auth_username { get; set; }
        public object auto_alert_on { get; set; }
        public object basket_active { get; set; }
        public object basket_folder { get; set; }
        public object basket_overwrite { get; set; }
        public Color BdisabledForeColor { get; set; }
        public Color BForeColor { get; set; }
        public object calc_period { get; set; }
        public object calc_year { get; set; }
        public object can_mod_report { get; set; }
        public object CHEQUE { get; set; }
        public object chqtype { get; set; }
        public object cie_city { get; set; }
        public object cie_country { get; set; }
        public object cie_id { get; set; }
        public object cie_state { get; set; }
        public object ciename { get; set; }
        public string ciepath { get; set; }
        public object COMMPORT { get; set; }
        public object consolidated_invoices { get; set; }
        public object cout_a_rack { get; set; }
        public object cout_fixe { get; set; }
        public object cout_int { get; set; }
        public object cout_s_rack { get; set; }
        public object cout_vente { get; set; }
        public object cpt { get; set; }
        public object CRYSTAL { get; set; }
        public object cur_ap_period { get; set; }
        public object cur_ap_year { get; set; }
        public object cur_ar_period { get; set; }
        public object cur_ar_year { get; set; }
        public object cur_gl_period { get; set; }
        public object cur_gl_year { get; set; }
        public object cur_onoff { get; set; }
        public object cur_op_period { get; set; }
        public object cur_op_year { get; set; }
        public object cur_year { get; set; }
        public object curapplication { get; set; }
        public object curapplication_no { get; set; }
        public object currency { get; set; }
        public object da_per10d { get; set; }
        public object da_per10f { get; set; }
        public object da_per11d { get; set; }
        public object da_per11f { get; set; }
        public object da_per12d { get; set; }
        public object da_per12f { get; set; }
        public object da_per1d { get; set; }
        public object da_per1f { get; set; }
        public object da_per2d { get; set; }
        public object da_per2f { get; set; }
        public object da_per3d { get; set; }
        public object da_per3f { get; set; }
        public object da_per4d { get; set; }
        public object da_per4f { get; set; }
        public object da_per5d { get; set; }
        public object da_per5f { get; set; }
        public object da_per6d { get; set; }
        public object da_per6f { get; set; }
        public object da_per7d { get; set; }
        public object da_per7f { get; set; }
        public object da_per8d { get; set; }
        public object da_per8f { get; set; }
        public object da_per9d { get; set; }
        public object da_per9f { get; set; }
        public string date_format { get; set; }
        public object DBEXPORT { get; set; }
        public object DBIMPORT { get; set; }
        public object DBWHOUSE { get; set; }
        public object def_tel_int { get; set; }
        public object demo { get; set; }
        public object DEPT { get; set; }
        public bool Development { get; set; }
        public object ecclicode { get; set; }
        public object eccode { get; set; }
        public object ecname { get; set; }
        public object eco_on { get; set; }
        public object eco_web { get; set; }
        public object email { get; set; }
        public bool email_bcc_self { get; set; }
        public object FAXCOVER { get; set; }
        public object faxprefix { get; set; }
        public Color fBackColor { get; set; }
        public Color fdisabledBackColor { get; set; }
        public Color fdisabledForeColor { get; set; }
        public Color fForeColor { get; set; }
        public object forcedbasket { get; set; }
        public object forceperiod { get; set; }
        public object fxbtndisabledborder { get; set; }
        public object fxbtndisabledcolor { get; set; }
        public object fxbtndisabledfcolor { get; set; }
        public object fxbtnenabledborder { get; set; }
        public object fxbtnenabledcolor { get; set; }
        public object fxbtnenabledfcolor { get; set; }
        public object glmonthone { get; set; }
        public object glpermonth { get; set; }
        public object gst_rate { get; set; }
        public object help_start_doc { get; set; }
        public object idtax { get; set; }
        public object int_activity { get; set; }
        public object int_code { get; set; }
        public object inv_cod_when_zero { get; set; }
        public object invxml { get; set; }
        public object invxmldir { get; set; }
        public bool is_synchro_central { get; set; }
        public bool is_synchro_client { get; set; }
        public string language { get; set; }
        public Color LBackColor { get; set; }
        public Color LdisabledBackColor { get; set; }
        public Color LdisabledForeColor { get; set; }
        public Color LForeColor { get; set; }
        public int lic_users { get; set; }
        public object lic_users_control { get; set; }
        public object licence { get; set; }
        public object lineout { get; set; }
        public bool Lloginop { get; set; }
        public bool log_user { get; set; }
        public object loginscreen { get; set; }
        public object lpstongst { get; set; }
        public object lshortcutmenu { get; set; }
        public object mail_attached { get; set; }
        public object mail_notes { get; set; }
        public object mail_subject { get; set; }
        public object mail_to { get; set; }
        public object mailport { get; set; }
        public object mailserver { get; set; }
        public object marge_est_glo { get; set; }
        public object multi_agent { get; set; }
        public object nb_cur_user { get; set; }
        public int nb_new_mesg { get; set; }
        public object nb_per_aux { get; set; }
        public object nb_per_gl { get; set; }
        public object news_run { get; set; }
        public object news_startup_page { get; set; }
        public object newsform { get; set; }
        public object NOBRACELET { get; set; }
        public object NOCAISSE { get; set; }
        public object nocheckcredit { get; set; }
        public object nogl_ap { get; set; }
        public object nogl_ap_disc { get; set; }
        public object nogl_ap_re { get; set; }
        public object nogl_ar { get; set; }
        public object nogl_ar_disc { get; set; }
        public object nogl_bnr { get; set; }
        public object nogl_bq { get; set; }
        public object nogl_bq_re { get; set; }
        public object nogl_contra { get; set; }
        public object nogl_error { get; set; }
        public object nogl_tps_ach { get; set; }
        public object nogl_tps_vte { get; set; }
        public object nogl_tvh_ach { get; set; }
        public object nogl_tvh_vte { get; set; }
        public object nogl_tvq_ach { get; set; }
        public object nogl_tvq_vte { get; set; }
        public object notps { get; set; }
        public object notvq { get; set; }
        public object office_no { get; set; }
        public bool on_error_quit { get; set; }
        public bool opened { get; set; }
        public object owinfax { get; set; }
        public object pdfmessage { get; set; }
        public object period1 { get; set; }
        public object phoneint { get; set; }
        public object prix_est_do { get; set; }
        public object proxyhttpconnecttype { get; set; }
        public object proxyname { get; set; }
        public object proxypass { get; set; }
        public object proxyuser { get; set; }
        public object pst_rate { get; set; }
        public object region { get; set; }
        public object rep_inv { get; set; }
        public object running_terminal_server { get; set; }
        public object search_ret_param1 { get; set; }
        public int searchid { get; set; }
        public object sendmailsync { get; set; }
        public object sessionid { get; set; }
        public object shipmentnostyle { get; set; }
        public object shortcutmenu { get; set; }
        public object show_op_msg { get; set; }
        public object shutdown_count { get; set; }
        public object sPicture { get; set; }
        public object tactisoft { get; set; }
        public object tmppath { get; set; }
        public object tvh_rate { get; set; }
        public object usdcad { get; set; }
        public object use { get; set; }
        public object use_longd { get; set; }
        public object use_office { get; set; }
        public object use_po { get; set; }
        public object UserArrep { get; set; }
        public object userbasket { get; set; }
        public object UserCanModclientaccntg { get; set; }
        public object usercie { get; set; }
        public string UserCode { get; set; }
        public string UserEmail { get; set; }
        public object UserEmail2 { get; set; }
        public object UserEmailSignature { get; set; }
        public object UserGroup { get; set; }
        public object UserName { get; set; }
        public object userphone { get; set; }
        public object UserTimer { get; set; }
        public object usertitle { get; set; }
        public string UserType { get; set; }
        public object vabandon { get; set; }
        public object valid_accnt { get; set; }
        public object verif_crlimit_lastid { get; set; }
        public object vers_country { get; set; }
        public Color WBackColor { get; set; }
        public object webpage { get; set; }
        public Color WForeColor { get; set; }
        public object wich_email { get; set; }
        public object wich_fax { get; set; }
        public object winfreight { get; set; }
        public object WPicture { get; set; }
        public object wscustom { get; set; }
        public object wsmenu_nb { get; set; }
        public object WSNEWSDIR { get; set; }
        public object wssession_table { get; set; }
        public object zart { get; set; }
        public object zebra { get; set; }
        public object zebra_active { get; set; }
        public object zebra_contrat_auto { get; set; }

        /***************Wssession Array property*************/
        public object[] a71over { get; set; }   //9
        public object[] a91over { get; set; }   //9
        public object[,] a_wsmenu { get; set; } //1,5
        public object[] active_bar { get; set; }   //1
        public string[,] active_form { get; set; }  //1,2
        public object[,] asemaine { get; set; } //52,2
        public object[,] aweek { get; set; } //52,2
        public object[] dizainef { get; set; }  //9
        public object[] dizainea { get; set; }  //9
        public object[] jourtxt { get; set; }
        public object[] moistxt { get; set; }
        public object[] nbjrsmois { get; set; } //1
        public object[] unitea { get; set; }   //19
        public object[] unitef { get; set; }  


        public WsSession()
        {
            a71over = new object[9];
            a91over = new object[9];
            a_wsmenu = new object[1,5];
            active_bar = new object[1];
            active_form = new string[1,2];
            asemaine = new object[52,2];
            aweek = new object[52,2];
            dizainef = new object[9];
            dizainea = new object[9];
            jourtxt = new object[7];
            moistxt = new object[12];
            nbjrsmois = new object[12];
            unitea = new object[19];
            unitef = new object[19];

            Init();
        }

        public void Init()
        {
            //Initialisation par defaut des couleurs de champs
            fBackColor = IntToColor(13565944);
            fForeColor = IntToColor(0);  //Color.FromArgb(0, 0, 0);
            fdisabledBackColor = IntToColor(15066597);
            fdisabledForeColor = IntToColor(16711680);
            //* Pour les captions
            LBackColor = IntToColor(12632256);
            LForeColor = IntToColor(0);
            LdisabledBackColor = IntToColor(12632256);  //Color.FromArgb(192, 192, 192);
            LdisabledForeColor = IntToColor(8421504); //Color.FromArgb(128, 128, 128);
            //* Pour les formes
            WBackColor = IntToColor(12632256); //Color.FromArgb(192, 192, 192);
            WForeColor = IntToColor(0);//Color.FromArgb(0, 0, 0);
            WPicture = "";
            //* Pour les boutons
            BForeColor = IntToColor(0); //Color.FromArgb(0, 0, 0);
            BdisabledForeColor = IntToColor(8421504); //Color.FromArgb(128, 128, 128);
            //* Pour l'ecran de fond
            sPicture = "WsBack.jpg";

            tmppath = Path.GetTempPath();   //SYS(2023);
            NOBRACELET = 'N';
            UserType = "";

            string FLine;

            //Read the "CONFIG.WS" file to get default directory
            if (!File.Exists("CONFIG.WS"))
            {
                MESSAGEBOX("CONFIG.WS missing!", 0, "Impossible to start");
                opened = false;
                return;
            }

            System.IO.StreamReader FHandle = new System.IO.StreamReader("CONFIG.WS");
            while ((FLine = FHandle.ReadLine()) != null)
            {
                // To set the development mode ON
                if (LEFT(FLine, 6) == "DEV=ON")
                    Development = true;

                // To set the Terminal server on ou off
                if (LEFT(FLine, 5) == "TS=ON")
                    running_terminal_server = true;

                // Basket (Will overwrite what ever in wscie)
                if (LEFT(FLine, 7) == "BASKET=")
                    forcedbasket = SUBSTR(FLine, 8);

                // Current directory
                if (LEFT(FLine, 9) == "DATAPATH=")
                    ciepath = SUBSTR(FLine, 9);

                // Directory for temporary files
                if (LEFT(FLine, 8) == "TMPPATH=")
                    tmppath = SUBSTR(FLine, 8);

                // 1st HELP SCREEN (html)
                if (LEFT(FLine, 7) == "HELP1=")
                    help_start_doc = SUBSTR(FLine, 8);

                // WEB INTERFACE STARTUP PAGE
                if (LEFT(FLine, 7) == "NEWS=")
                    news_startup_page = SUBSTR(FLine, 6);

                // What do we use for email
                if (LEFT(FLine, 6) == "EMAIL=")
                    wich_email = ALLTRIM(SUBSTR(FLine, 7));

                // What do we use for fax
                if (LEFT(FLine, 4) == "FAX=")
                    wich_fax = ALLTRIM(SUBSTR(FLine, 5));

                // What do we use for fax COVER PAGE
                if (LEFT(FLine, 9) == "FAXCOVER=")
                    FAXCOVER = ALLTRIM(SUBSTR(FLine, 10));

                // Were is the data warehouse
                if (LEFT(FLine, 9) == "DBWHOUSE=")
                    DBWHOUSE = ALLTRIM(SUBSTR(FLine, 10));

                // If we are in a region
                if (LEFT(FLine, 7) == "REGION=")
                    region = ALLTRIM(SUBSTR(FLine, 8));

                // Were to export data
                if (LEFT(FLine, 9) == "DBEXPORT=")
                    DBEXPORT = ALLTRIM(SUBSTR(FLine, 10));

                // Were is the data to import
                if (LEFT(FLine, 9) == "DBIMPORT=")
                    DBIMPORT = ALLTRIM(SUBSTR(FLine, 10));

                // For report in crystal report
                if (LEFT(FLine, 8) == "CRYSTAL=")
                    CRYSTAL = ALLTRIM(SUBSTR(FLine, 9));

                // For THE FORM WITH NEWS
                if (LEFT(FLine, 5) == "NEWS=")
                    WSNEWSDIR = ALLTRIM(SUBSTR(FLine, 6));

                // For the DEPT NO. OF P.O.S.
                if (LEFT(FLine, 5) == "DEPT=")
                    DEPT = INT(VAL(ALLTRIM(SUBSTR(FLine, 6))));

                // For the CAISSE NO. OF P.O.S.
                if (LEFT(FLine, 7) == "CAISSE=")
                    NOCAISSE = INT(VAL(ALLTRIM(SUBSTR(FLine, 8))));

                // COM OF P.O.S POLE.
                if (LEFT(FLine, 9) == "COMMPORT=")
                    COMMPORT = INT(VAL(ALLTRIM(SUBSTR(FLine, 10))));

                // P.O.S. Do not use bracelet scanner
                if (LEFT(FLine, 10) == "NOBRACELET=")
                    NOBRACELET = ALLTRIM(SUBSTR(FLine, 12));

                // Pour print des cheques
                if (LEFT(FLine, 9) == "CHEQUE=")
                    CHEQUE = ALLTRIM(SUBSTR(FLine, 8));
            }

            //FHandle.Close();

            // Ciepath MUST contains the data directory
            if (EMPTY(ciepath))
            {
                opened = false; // Session cannot go on
                return;
            }
            else
                opened = true; // Session properly startup

            refresh_param(true);
            if (opened == false)
                  return;
        }

        //*********************************Méthode du wsswssion*********************************//
        public object Cdate(DateTime pDate, bool p0frch = false, bool pJourTxt = false)
        {
            string cDate = "";
            string cDay;

            if (pDate == null)
            {
                return cDate;
            }

            if (p0frch)
            {
                if (pJourTxt)
                {
                    cDate = FirstCharToUpper(pDate.ToString("dddd")) + " le " + (pDate.Day.ToString() == "1" ? "1er" : pDate.Day.ToString().Trim()) + " " + FirstCharToUpper(pDate.ToString("MMMM")) + " " + pDate.Year;
                }
                else
                {
                    cDate = pDate.Day.ToString() == "1" ? "1er" : pDate.Day + " " + FirstCharToUpper(pDate.ToString("MMMM")) + " " + pDate.Year;
                }
            }
            else
            {

                if (pDate.Day.ToString() == "1" || pDate.Day.ToString() == "21" || pDate.Day.ToString() == "31")
                {
                    cDay = " " + pDate.Day.ToString().Trim() + "st ";
                }
                else if (pDate.Day.ToString() == "2" || pDate.Day.ToString() == "22")
                {
                    cDay = " " + pDate.Day.ToString().Trim() + "nd ";
                }
                else if (pDate.Day.ToString() == "3" || pDate.Day.ToString() == "23")
                {
                    cDay = " " + pDate.Day.ToString().Trim() + "rd ";
                }
                else
                {
                    cDay = " " + pDate.Day.ToString().Trim() + "th ";
                }

                if (pJourTxt)
                {
                    cDate = pDate.DayOfWeek + " " + pDate.ToString("MMMM", CultureInfo.GetCultureInfo("en-US")) + cDay + pDate.Year.ToString();
                }
                else
                {
                    cDate = pDate.ToString("MMMM", CultureInfo.GetCultureInfo("en-US")) + cDay + pDate.Year.ToString();
                }
            }

            return cDate;
        }

        public void Chariot()
        {
            
        }

        public void Check_integra(object pFrom)
        {
            
        }

        public void Check_mesg(string cShow)
        {
           
        }

        public void Check_shutdown()
        {
           
        }

        public void Createdir(object pDir)
        {
          
        }

        public void Disabled_bar(object nInstance)
        {
           
        }

        public void Dispatch(object paction)
        {
            
        }

        public void do_menu(object p_lang)
        {
            
        }

        public void enabled_bar(object nInstance)
        {
            
        }

        public object exist_bar(object cBarname)
        {
            return "";
        }

        public object fax_get_info(object pIdent)
        {
            return "";
        }

        public object fax_queue(object pAction, object pWhen, object REP_NAME, object pFaxTo, object pCie, object pSubject, object pFax)
        {
            return "";
        }

        public object fax_send(object l_Queue_id)
        {
            return "";
        }

        public void fourn_valid()
        {

        }

        public int get_next_id(object ltable, object loption = null)
        {
            return 0;
        }

        public void get_period_from_date()
        {

        }

        public void get_rate()
        {

        }

        public void get_rate_op()
        {

        }

        public void get_taxrates()
        {

        }

        public int get_temp_id(string tablename)
        {
            return 0;
        }

        public void get_unique_file_name()
        {
           
        }

        public void hide_bar()
        {

        }

        public void launch_bar(object lBarobjet)
        {
            
        }

        public object launch_form(object lFormName, string lAction, int lRecId, string cParamPlus)
        {
            return "";
        }

        public void logmsg()
        {

        }

        public void Logon()
        {
            wsLogin login = new wsLogin(this);
            login.ShowDialog();
        }

        //public void logonbc()
        //{
        //Not use
        //}

        public void long_distance()
        {

        }

        public void mail_get_info()
        {

        }

        public void mail_queue()
        {

        }

        public void mail_send()
        {

        }

        public void mmerge()
        {

        }

        public void mod_followup()
        {

        }

        public void nbr_days()
        {

        }

        public void numtochar()
        {

        }

        public void on_off()
        {

        }

        public void pool_job()
        {

        }

        public void refresh_param(bool lWorkPer)
        {
            data_wscie WsCie = new data_wscie();

            gQuery("SELECT * FROM wscie order by cie_id asc", WsCie, 0, 0, WsCie.isFoxpro);
            WsCie.LoadRow();

            if (WsCie.RECCOUNT() > 0)
            {
                cie_id      = WsCie.Cie_Id;
                ciename     = WsCie.Cie_Name;
                licence     = WsCie.Licence;
                cie_city    = WsCie.Cie_City;
                cie_state   = WsCie.Cie_State;
                cie_country = WsCie.Cie_Country;

                if (ALLTRIM(UserType) != "Accounting" || lWorkPer == true)
                {
                    cur_gl_year   = WsCie.Gl_Year;
                    cur_gl_period = WsCie.Gl_Period;
                    cur_ar_year   = WsCie.Ar_Year;
                    cur_ar_period = WsCie.Ar_Period;
                    cur_ap_year   = WsCie.Ap_Year;
                    cur_ap_period = WsCie.Ap_Period;

                    if (Lloginop == false)
                    {
                        cur_op_year   = WsCie.Op_Year;
                        cur_op_period = WsCie.Op_Period;
                    }
                }
            }
            else
            {
                MESSAGEBOX("Undefined company parameters!", 0, "Major problem");
                opened = false;
                return;
            }

            cur_year = DateTime.Now.Year;//YEAR(DATE());
            aci_active = true;
        }

        public void releasefoxtoolbars()
        {

        }

        public void Shellexec(string commands)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + commands);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
            }
            catch (Exception objException)
            {
                // Log the exception
                File.WriteAllText(@"error.txt", objException.ToString());
            }
        }

        public void show_bar(int nInstance)
        {

        }

        public void Showhelp(string link = "")
        {
            Shellexec(link);
        }

        public void shut_bar()
        {

        }

        public void shut_form(int? nInstance)
        {
            //WIP
        }

        public void shutdown()
        {

        }

        public void synchro()
        {

        }

        public void time_tot()
        {

        }

        public void verif_crlimit()
        {

        }

        public object Web_date(DateTime pDate)
        {
            return pDate;
        }

        //*************Méthode utilitaire**************//
        public string Q2(object value)
        {
            return '"' + value.ToString() + '"';

        }
        public string FoxDate(DateTime pDate)
        {
            //string strDate = FoxSTR(pDate.Month) + "/" + FoxSTR(pDate.Day) + "/" + pDate.ToString("yy");  
            string strDate = "DATE(" + pDate.ToString("yyyy") + ", " + FoxSTR(pDate.Month) + ", " + FoxSTR(pDate.Day) + ")"; //DATE(2019, 06, 18)
            return strDate;
        }

        public string FoxSTR(int? pText)
        {

            if (pText == null)
                return "00";

            if (pText < 10)
                return "0" + pText.ToString();
            else
                return pText.ToString();
        }

        public string FoxBool(bool value)
        {
            if (value)
                return ".T.";
            else
                return ".F.";
        }

        public string StrToFoxBool(string value)
        {
            if (value == "True")
                return ".T.";
            else if (value == "False")
                return ".F.";
            else
                return "";
        }
        public string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("FirstCharToUpper Error : parameter input is null or Empty");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}
