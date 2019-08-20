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
using System.Reflection;
using vivael.wsforms;
using System.Net.Mail;
using System.Net;

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
        public bool basket_active { get; set; }
        public string basket_folder { get; set; }
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
        public bool demo { get; set; } = false;
        public object DEPT { get; set; }
        public bool Development { get; set; }
        public object ecclicode { get; set; }
        public object eccode { get; set; }
        public object ecname { get; set; }
        public object eco_on { get; set; }
        public object eco_web { get; set; }
        public string email { get; set; }
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
        public string loginscreen { get; set; } 
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
        public byte? office_no { get; set; }
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
        public int sessionid { get; set; }
        public object shipmentnostyle { get; set; }
        public object shortcutmenu { get; set; }
        public object show_op_msg { get; set; }
        public object shutdown_count { get; set; }
        public object sPicture { get; set; }
        public object tactisoft { get; set; }
        public string tmppath { get; set; }
        public object tvh_rate { get; set; }
        public object usdcad { get; set; }
        public object use { get; set; }
        public object use_longd { get; set; }
        public bool use_office { get; set; }
        public object use_po { get; set; }
        public object UserArrep { get; set; }
        public object userbasket { get; set; }
        public object UserCanModclientaccntg { get; set; }
        public object usercie { get; set; }
        public string UserCode { get; set; }
        public string UserEmail { get; set; }
        public string UserEmail2 { get; set; }
        public object UserEmailSignature { get; set; }
        public object UserGroup { get; set; }
        public object UserName { get; set; }
        public object userphone { get; set; }
        public object UserTimer { get; set; }
        public object usertitle { get; set; }
        public string UserType { get; set; } = "";
        public object vabandon { get; set; }
        public object valid_accnt { get; set; }
        public object verif_crlimit_lastid { get; set; }
        public object vers_country { get; set; }
        public Color WBackColor { get; set; }
        public object webpage { get; set; }
        public Color WForeColor { get; set; }
        public string wich_email { get; set; }
        public object wich_fax { get; set; }
        public object winfreight { get; set; }
        public object WPicture { get; set; }
        public object wscustom { get; set; }
        public object wsmenu_nb { get; set; }
        public object WSNEWSDIR { get; set; }
        public object wssession_table { get; set; }
        public string zart { get; set; }
        public object zebra { get; set; }
        public object zebra_active { get; set; }
        public object zebra_contrat_auto { get; set; }

        /***************Wssession Array property*************/
        public object[,] a_wsmenu { get; set; } //1,5
        public object[] active_bar { get; set; }   //1
        public object[,] active_form { get; set; }  //1,2
        public object[] jourtxt { get; set; }
        public object[] moistxt { get; set; }
        public object[,] asemaine { get; set; } //52,2
        public object[,] aweek { get; set; } //52,2
        public object[] unitef { get; set; }
        public object[] unitea { get; set; }   //19
        public object[] dizainef { get; set; } 
        public object[] dizainea { get; set; }
        public object[] a71over { get; set; }   //9
        public object[] a91over { get; set; }   //9
        public object[] nbjrsmois { get; set; } //1



        public WsSession()
        {
            a_wsmenu = new object[1,5];
            active_bar = new object[1];
            active_form = new object[1,2];
            jourtxt = new object[7];
            moistxt = new object[12];
            asemaine = new object[52,2];
            aweek = new object[52,2];
            unitef = new object[20];
            unitea = new object[20];
            dizainef = new object[9];
            dizainea = new object[9];
            a71over = new object[9];
            a91over = new object[9];
            nbjrsmois = new object[12];

            Init();
        }

        public void Init()
        {
            StreamReader FHandle;
            string FLine;

            if (TYPE(m0frch) != typeof(bool) || ISNULL(m0frch))
                m0frch = true;

            tmppath = Path.GetTempPath();  //&& TMPFILES as defined in CONFIG.FPW (Can be changed in CONFIG.WS)  //SYS(2023);

            //Initialisation par defaut des couleurs de champs
            fBackColor = IntToColor(13565944);
            fForeColor = IntToColor(0);
            fdisabledBackColor = IntToColor(15066597);
            fdisabledForeColor = IntToColor(16711680);

            //* Pour les captions
            LBackColor = IntToColor(12632256);
            LForeColor = IntToColor(0);
            LdisabledBackColor = IntToColor(12632256); 
            LdisabledForeColor = IntToColor(8421504); 

            //* Pour les formes
            WBackColor = IntToColor(12632256); 
            WForeColor = IntToColor(0);
            WPicture = "";

            //* Pour les boutons
            BForeColor = IntToColor(0); 
            BdisabledForeColor = IntToColor(8421504); 

            //* Pour l'ecran de fond
            sPicture = "WsBack.jpg";

            tmppath = Path.GetTempPath();
            NOBRACELET = 'N';

            //Read the "CONFIG.WS" file to get default directory
            if (!FILE("CONFIG.WS"))
            {
                MESSAGEBOX("CONFIG.WS missing!", 0+16, "Impossible to start");
                opened = false;
                return;
            }

            FHandle = new System.IO.StreamReader("CONFIG.WS");
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

            FHandle.Close();

            // Ciepath MUST contains the data directory
            if (EMPTY(ciepath))
            {
                opened = false; // Session cannot go on
                return;
            }
            else
                opened = true; // Session properly startup


            bool lOk = false;

            if (m0checkdb == false)
            {
                lOk = true;
            }


            if (lOk)
            {
                this.refresh_param(true);
                if (this.opened == false)
                    return;
            }
            else
            {
                this.opened = false;
                return;
            }
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
            int nAnswer;

            //STORE SELECT() TO cur_area
            //SELECT * FROM wsmesg WHERE Wsmesg.msgtype != 'D' AND ALLTRIM(Wsmesg.dest_user) = ALLTRIM(this.UserCode) AND Wsmesg.read_yes = .F.
            //SELECT 0
            //USE Wsmesg ORDER touser
            //SET FILTER TO Wsmesg.msgtype != 'D' AND ALLTRIM(Wsmesg.dest_user) = ALLTRIM(this.UserCode) AND Wsmesg.read_yes = .F.
            //go top
            this.nb_new_mesg = 0;
            //do while !eof()
            //   this.nb_new_mesg = this.nb_new_mesg + 1
            //   skip
            ////ENDDO
            //SELECT * FROM wsmesg WHERE Wsmesg.msgtype = 'D' AND Wsmesg.read_yes = .F. AND ALLTRIM(Wsmesg.dest_user) = ALLTRIM(this.UserCode)
            //go top
            //do while !eof()
            //This.Dispatch(ALLTRIM(Wsmesg.subject))
            //SELECT Wsmesg
            //REPLACE Wsmesg.read_yes WITH .T.
            //skip
            //ENDDO
            //SET FILTER TO
            //USE
            //SELECT(cur_area)

            if(Upper(cShow) == "SHOW" && this.nb_new_mesg > 0)
            {
                nAnswer = MESSAGEBOX("You have " + ALLTRIM(STR(this.nb_new_mesg)) + " new message.  Do you want to see them ?", 4 + 32, "Internal messages", 10000);

                if (nAnswer == 6)
                {
                    //oSession.launch_form("WSREADMSG", "");
                    //* DO FORM wsreadmsg NAME FReadMesg LINKED
                }
            }
            else
            {
                if (Upper(cShow) != "SHOW")
                {
                   // oSession.launch_form("WSREADMSG", "");
                   //* DO FORM wsreadmsg NAME FReadMesg LINKED
                }
            }
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

        public int? get_next_id(string ltable, object loption = null)
        {

            //** Get the next id number in WsSeq
            //** And increase the table
            //*** NEW loption: If D, reset to 1 if date has change; If M, reset to 1 if month has change
            //***              If O, put office number first 

            int? the_id;

            the_id = 0;

            data_wsseq WsSeq = new data_wsseq();
            gQuery($"SELECT * FROM wsseq where tableid = '{ltable}'", WsSeq, 0, 0, WsSeq.isFoxpro);

            if (WsSeq.RECCOUNT() > 0)
            {
                //* No option
                if(TYPE("loption") == typeof(bool))
                {
                    the_id = WsSeq.Next_Id;
                    WsSeq.Next_Id += 1;

                    if (this.use_office && ALLTRIM(ltable) != "SEQCONSOL" && ALLTRIM(ltable) != "INVOICE")
                    {
                        the_id = (100000000 * oSession.office_no) + the_id;
                    }
                }
                else
                {
                    //* Specific option
                    switch (loption)
                    {
                        case "D":
                            if(WsSeq.Datelast != null)
                            {
                                if (DAY(DATE()) != DAY((DateTime)WsSeq.Datelast))
                                {
                                    the_id = 1;
                                    WsSeq.Next_Id = 2;
                                }
                                else
                                {
                                    the_id = WsSeq.Next_Id;
                                    WsSeq.Next_Id += 1;
                                }
                            }
                            break;

                        case "M":
                            if (WsSeq.Datelast != null)
                            {
                                if (MONTH(DATE()) != MONTH((DateTime)WsSeq.Datelast))
                                {
                                    the_id = 1;
                                    WsSeq.Next_Id = 2;
                                }
                                else
                                {
                                    the_id = WsSeq.Next_Id;
                                    WsSeq.Next_Id += 1;
                                }
                            }
                        break;
                        default:

                        break;
                    }
                    WsSeq.Datelast = DATE();
                }
                if (WsSeq.Datelast != null)
                {
                    DateTime aDate = (DateTime)WsSeq.Datelast;
                    string strDate = "{^" + aDate.ToString("yyyy-MM-dd") + "}";
                    gQuery($"UPDATE wsseq SET next_id = {WsSeq.Next_Id}, datelast = {strDate} where tableid = '{ltable}'", true);
                }
                
            }
            else
            {
                the_id = 1;

                if (TYPE(loption) == typeof(bool))
                {
                    gQuery($"INSERT INTO WsSeq(tableid, next_id, tmp_id, datelast) VALUES({ltable}, {2}, {0}, {"{^" + DATE().ToString("yyyy-MM-dd") + "}"}) ");
                }
            }

            return the_id;
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
            //** Get the next temp id number in WsSeq
            //** And increase the table

            int the_id = -1;

            //SELECT * FROM WsSeq WHERE TableId = tablename order by tableid //one record
          
            if (SEEK(ALLTRIM(Upper(tablename))))      //if count != 0
            {
                //the_id = WsSeq.tmp_Id; 
                //WsSeq.tmp_Id = WsSeq.tmp_Id - 1; //update wsseq tmp_id with  WsSeq.tmp_Id - 1
            }
            else
            {
                the_id = -1;
                //INSERT INTO WsSeq(tableid, next_id, tmp_id) VALUES(ltable, 1, -1)
            }

            return the_id;
        }

        public string get_unique_file_name(string pLong)
        {
            //*Parameter : "Long" get a file name with the temporary directory
            //*"Short" get a file name without the temporary directory
            //C:\Users\Multi-Service\AppData\Local\Temp\  tmp6103.tmp

            string lFileName = "";

            lFileName = ALLTRIM(SUBSTR(Path.GetTempFileName(), 42));
            if (pLong == "Long")
                lFileName = ALLTRIM(oSession.tmppath) +"\\" + ALLTRIM(lFileName);

            File.Create(ALLTRIM(oSession.tmppath) + "\\" + ALLTRIM(lFileName));

            return lFileName;
        }

        public void hide_bar()
        {
            
        }

        public void launch_bar(object lBarobjet)
        {
            
        }

        public object Launch_Form(object lFormName, object lAction, object lRecId = null, object cParamPlus = null)
        {
            //***
            //***LAUCH THE FORM(AND KEEP THE HANDLE IN ACTIVE_FORM[]
            //***
            object lAjout, lModif, lSupp, lImp, lfire, lFormType, lValeurRetour;
            int i, nInstance;

            if( TYPE(lRecId) != typeof(int) || ISNULL(lRecId)) // ISBLANK : not possible in c#
            {
                lRecId = 0; 
            }

            lValeurRetour = 0;

            if (this.opened == false)
            {
                MESSAGEBOX(IIF(m0frch, "Aucun utilisateur en cours", "No current user"), 0 + 16, IIF(m0frch, "Accès refusé", "Access not allowed"));
	            return null;
            }
            bool lfound = false;

            data_wspermis WsPermis = new data_wspermis();
            data_wsfunction WsFunction = new data_wsfunction();

            gQuery("SELECT * FROM WSPERMIS WHERE WSPERMIS.group = 'ALL' AND function = '" + ALLTRIM(lFormName.ToString()) +"' ORDER BY IDENT_AI ASC", WsPermis, 0, 0, WsPermis.isFoxpro);
            WsPermis.LoadRow();

            if(WsPermis.RECCOUNT() > 0)
            {
                lfound = true;
            }
            else
            {
                gQuery("SELECT * FROM WSPERMIS WHERE WSPERMIS.group = '" + ALLTRIM(this.UserGroup.ToString())+"' AND function = '" + ALLTRIM(lFormName.ToString()).ToUpper() + "' ORDER BY IDENT_AI ASC", WsPermis, 0, 0, WsPermis.isFoxpro);
                WsPermis.LoadRow();
                if (WsPermis.RECCOUNT() > 0)
                    lfound = true;
            }
            string tmpfunc, lFunctionDescr;
            if (lfound)
            {
                tmpfunc = WsPermis.Function;
                lAjout = WsPermis.Ajout;
                lModif = WsPermis.Modif;
                lSupp = WsPermis.Supp;
                lImp = WsPermis.Imp;

                gQuery("SELECT * FROM WSFUNCTION WHERE function = '" + tmpfunc + "' ORDER BY IDENT ASC", WsFunction, 0, 0, WsFunction.isFoxpro);
                WsFunction.LoadRow();
                if (WsFunction.RECCOUNT() > 0)
                {
                    lFormName = ALLTRIM(WsFunction.Pgm);
                    lFormType = WsFunction.Type;
                    lfire = true;
                    lFunctionDescr = WsFunction.Descr;

                    /*-------------- Log --------------*/
                    if (this.log_user)
                    {
                        gQuery("INSERT INTO wslog(date, heure, user, module, type, desc) VALUES(DATE(), TIME(), "+oSession.UserCode+", "+tmpfunc+", 'l', "+lFunctionDescr+")", true);
                    }

                    /*---- Function to fire only once -----*/
                    if (lFormType.ToString() == "1")
                    {
                        //* Verify if already in the active forms
                        nInstance = this.active_form.Length;

                        lfire = true;  //&& We have to fire it

                        for (i = 1; i < nInstance; i++)
                        {
                            if(TYPE(this.active_form[i,2]) == typeof(string))
                            {
                                if (this.active_form[i, 2].ToString() == tmpfunc)
                                {
                                    //* We got it already, so just raise it
                                    lfire = false;
                                    //&& THIS.Active_form[i, 1].zorder(0) && Raise it on top
                                    //this.active_form[i, 1].Show();
                                }
                            }
                        }
                    }
                    else
                    {
                        lfire = false; // && IF lFormType IS NOT 1 DO NOT FIRE IT.
                    }

                    /*------------------------------------*/
                    /* Form                               */
                    /*------------------------------------*/
                    if (lFormType.ToString() == "F" || lFormType.ToString() == " " || (bool)lfire == true)
                    {
                        nInstance = this.active_form.Length-2;

                        this.active_form[nInstance, 0] = ALLTRIM(lFormName + ALLTRIM(STR(nInstance)));
                        this.active_form[nInstance, 1] = tmpfunc;


                        // Call the form
                        string name = lFormName.ToString().Split('.')[0];

                        var _form = (DataMenu)GetForm(name);
                        if (_form != null)
                        {
                            _form.MdiParent = menu;
                            _form.Init(lFormName.ToString(), lAction.ToString(), nInstance, (int)lRecId, cParamPlus, (bool)lAjout,(bool)lModif, (bool)lSupp, (bool)lImp);
                            _form.Show();
                        }
                    }

                    /*------------------------------------*/
                    /* Modal form                         */
                    /*------------------------------------*/
                    if (lFormType.ToString() == "M")
                    {
                        nInstance = this.active_form.Length-2;

                        this.active_form[nInstance, 0] = ALLTRIM(lFormName + ALLTRIM(STR(nInstance)));
                        this.active_form[nInstance, 1] = tmpfunc;

                        //Call the form 
                        //DO FORM(lFormName) NAME THIS.Active_form[nInstance, 1];
                        //WITH lFormName, lAction, nInstance, lRecId, cParamPlus, ;
                        //lAjout, lModif, lSupp, lImp;
                        //LINKED TO lValeurRetour
                    }

                    /*------------------------------------*/
                    /* S form                             */
                    /*------------------------------------*/
                    if (lFormType.ToString() == "S")
                    {
                         //WIP
                    }

                    /*------------------------------------*/
                    /* Plain form                         */
                    /*------------------------------------*/
                    if (lFormType.ToString() == "X")
                    {
                        nInstance = this.active_form.Length;

                        this.active_form[nInstance, 1] = ALLTRIM(lFormName + ALLTRIM(STR(nInstance)));
                        this.active_form[nInstance, 2] = tmpfunc;
                        //DIMENSION THIS.Active_form[(nInstance + 1),2]


                        //* Call the form
                        string name = lFormName.ToString().Split('.')[0];
                        var _form = (Form)GetForm(name);
                        if (_form != null)
                        {
                            _form.MdiParent = menu;
                            _form.Show();
                        }
                    }

                    /*------------------------------------*/
                    /* ...or call a program               */
                    /*------------------------------------*/
                    if (lFormType.ToString() == "P")
                    {
                       //DO (lFormName)    //WIP
                    }

                    /*------------------------------------*/
                    /* ...or call a windows program       */
                    /*------------------------------------*/
                    if (lFormType.ToString() == "!")
                    {
                        this.Shellexec(lFormName.ToString());
                    }  
                }
                else
                {
                    if (m0frch)
                        MESSAGEBOX("Fonction inexistante", 16, "Contacter l'administrateur du système");
                    else
                        MESSAGEBOX("Function not found", 16, "Contact the system administrator");
                }
            }
            else
            {
                if (m0frch)
                    MESSAGEBOX("Accès refusé à cette fonction", 16, "Contacter l'administrateur du système");
                else
                    MESSAGEBOX("Access not allowed", 16, "Contact the system administrator");
            }

            return lValeurRetour;
        }

        public bool Logmsg(object pModule, object ptype, object pmessage, object pnotes)
        {
            //*Sauvegarde d'un message

            if(TYPE(pnotes) == typeof(bool))
            {
                //* IF ISNULL(pnotes)
                pnotes = ""; 
            }

            gQuery("INSERT INTO wslog(date, heure, user, module, type, desc) VALUES(DATE(), TIME(), " + this.UserCode + ", " + pModule + ", " + ptype + "," + pmessage + "," + pnotes + ")", true);

            return true;
        }

        public void Logon()
        {
            //*Logon process

            if (EMPTY(this.loginscreen))
            {
                wsLogin login = new wsLogin(this);
                login.ShowDialog();
                //DO FORM wslogin.scx NAME login
            }
            else
            {
                string llogin = this.loginscreen.ToString();
                Form form = (Form)GetForm(llogin);
                form.ShowDialog();
                //DO FORM & llogin NAME login
            }

            //if (EMPTY(this.UserCode))
            //    this.Shutdown();
        }

        //public void logonbc()
        //{
            //Not use
        //}

        public void long_distance()
        {

        }

        /// <summary>
        /// Open a form for send an email
        /// </summary>
        /// <param name="pIdent">wsmesg.ident TO go to the right message</param>
        /// <returns>
        /// 1 If user has selected SEND NOW on the email screen 
        /// 2 if user has selected SEND LATER on the email screen 
        /// 3 if user has deleted the email(CANCEL EMAIL)
        /// </returns>
        public int? mail_get_info(int? pIdent)
        {
            int? lresult = null;

            //GetForm("wsemailinfo");
            //DO FORM wsemailinfo NAME emailinfo;
            //            WITH pIdent;
            //            TO lresult;
            //            LINKED

            return lresult;
        }

        /// <summary>
        /// Create an email message in the queue (wsemail table) and Optionnaly send it right away
        /// Returns the ident of the create message (0 if failed)
        /// </summary>
        /// <param name="pAction">Action ("Ask" to call email screen, Else silence (if all info supplied in other prams)</param>
        /// <param name="pWhen">When   ("Now" to send immediately, Else, just put there to send later</param>
        /// <param name="pMailTo">MailTo (Email address(es) ex.: eric@vivasoft;benr@generation.net can have cc: or bcc: before each)</param>
        /// <param name="pCc">Carbon copy</param>
        /// <param name="pBcc">Blind Carbon copy</param>
        /// <param name="pSubject">Subject </param>
        /// <param name="pNotes">Notes</param>
        /// <param name="pAttachments">Attachments (Separated by ;)</param>
        /// <param name="pHtml">True, To send in html format (optional)</param>
        /// <param name="pSender">Sender name (optional)</param>
        public int? Mail_queue(string pAction, string pWhen, string pMailTo, string pCc, string pBcc, string pSubject, string pNotes, string pAttachments, bool pHtml = false, string pSender = "")
        {
            data_wsemail wsemail = new data_wsemail();
            int? lident, luseraction;
            bool lok;
            object cMailFrom;
            lident = 0;
            gCancelEmail = true;

            if(oSession.wich_email != "NONE")
            {
                // * If Action = "Ask", let's call the email screen
                if (pAction != "Ask" && EMPTY(pMailTo))
                {
                    MESSAGEBOX("Aucune adresse email!", 0 + 16, "Envoi impossible");
                    return 0;
                }

                //* 1) Put in queueue
                lident = this.get_next_id("WSEMAIL"); //---
                if (EMPTY(pMailTo))
                    pMailTo = "";

                if (EMPTY(pSubject))
                    pSubject = "";

                if (EMPTY(pNotes))
                    pNotes = "";

                if (EMPTY(pAttachments))
                    pAttachments = "";

                if (EMPTY(pCc))
                    pCc = "";

                if (EMPTY(pBcc))
                    pBcc = "";

                cMailFrom = "";
                if (TYPE(pSender) == typeof(string))
                {
                    if (!EMPTY(pSender))
                    {
                        cMailFrom = pSender; 
                    }
                }
                if(EMPTY(cMailFrom))
                {
                    if (EMPTY(this.UserEmail))
                    {
                        cMailFrom = ALLTRIM(oSession.email); 
                    }
                    else
                    {
                        cMailFrom = ALLTRIM(this.UserEmail);
                   }
                }
                string lEmailType;
                if (pHtml == true)
                {
                    lEmailType = "H";
                }
                else
                {
                    lEmailType = "E";
                }

                if(lident != null)
                {
                    string query =
                    $"INSERT INTO wsemail(ident, msgtype, dest_adr, subject, notes, attached, from_user, cr_by, cr_dtime, sent, cc, bcc, sender) " +
                    $"VALUES({lident}, {lEmailType}, {pMailTo}, {pSubject}, {pNotes}, {pAttachments}, {this.UserCode}, {this.UserCode}, DATETIME(), .F., {pCc}, {pBcc}, {cMailFrom})";
                    gQuery(query, wsemail.isFoxpro); //insert in db;
                }

                //*2) If pAction = "Ask", email screen
                if (pAction == "Ask")
                {
                    luseraction = this.mail_get_info(lident);  // 1 = send now 2 = send later 3 = email cancelled
                }
                else
                {
                    luseraction = 1; 
                }

                //*3) If pWhen = "Now", send right now
                if (pWhen == "Now" && luseraction == 1)
                {
                    gCancelEmail = false;

                    lok = this.mail_send(lident); 
 
                   if(lok == false)
                        lident = 0; 
                }
            }
            return lident;
        }

        /// <summary>
        ///     Send the specified queued message
        /// </summary>
        /// <param name="l_Queue_id"></param>
        /// <returns>Returns true or false</returns>
        public bool mail_send(int? l_Queue_id)
        {
            object cur_area, lok, lreturn;
            string[] la_mesg = new string[8] { "", "", "", "", "", "", "", "" };

            //WAIT(IIF(m0frch, "Envoi message...", "Sending message..."), "WINDOW NOWAIT");

            //STORE SELECT() TO cur_area
            //#define WWIPSTUFF_SHAREWARE false

            if (TYPE(loSmtp) != typeof(object)) // Ne pas recreer pour rien(EC30)
                loSmtp = new SmtpClient("smtp-mail.outlook.com");

            //SELECT msgtype, dest_adr, subject, notes, attached, cc, bcc, sender;
            //FROM wsemail;
            //WHERE wsemail.ident = l_Queue_id;
            //INTO ARRAY la_mesg

            loSmtp.Credentials = new NetworkCredential(ALLTRIM(this.UserEmail2), ALLTRIM(this.zart));
            loSmtp.EnableSsl = true;

            //la_mesg[2] : Subject in wsemail
            if (SUBSTR(la_mesg[2], 1, 6) == "FACTUR" || SUBSTR(la_mesg[2], 1, 6) == "CREDIT") {
                //*STORE "payables@envl.ca" TO la_mesg(8) 
                la_mesg[7] = "payable@envl.ca"; //sender in wsemail
                loSmtp.Credentials = new NetworkCredential("payable@envl.ca", "Yow643171");
                la_mesg[4] = "Bonjour, voici votre facture en attachement, Merci ";
            }
            if (SUBSTR(la_mesg[2], 1, 7) == "DEMANDE")
            { 
                la_mesg[7] = "arolland@envl.ca"; //sender in wsemail
                loSmtp.Credentials = new NetworkCredential("arolland@envl.ca", "Puq95627");
                //* STORE "Bonjour, voici votre facture en attachement, Merci " TO la_mesg(4) 
            }
            if(SUBSTR(la_mesg[2],1,10) == "Commande #")
            {
                la_mesg[7] = "achat@envl.ca"; //sender in wsemail
                loSmtp.Credentials = new NetworkCredential("arolland@envl.ca", "Puq95627");
                //* STORE "Bonjour, voici votre facture en attachement, Merci " TO la_mesg(4) 
            }
            if (SUBSTR(la_mesg[2], 1, 7) == "#Erreur")
            {
                la_mesg[7] = "web2@envl.ca"; //sender in wsemail
                loSmtp.Credentials = new NetworkCredential("noreply@multi-services.org", "Cuz813911");
                //* STORE "Bonjour, voici votre facture en attachement, Merci " TO la_mesg(4) 
            }

            return true;
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

        public void refresh_param(object lWorkPer)
        {
            /******Refresh oSession.(company parameters) from wscie******/
                    /****To be called before using them to have them uptodate****/

                    if (TYPE(lWorkPer) != typeof(bool) || ISNULL(lWorkPer))
                lWorkPer = false;

            data_wscie WsCie = new data_wscie();

            gQuery("SELECT * FROM wscie order by cie_id asc", WsCie, 0, 0, WsCie.isFoxpro);
            WsCie.LoadRow();

            if (WsCie.RECCOUNT() <= 0)
            {
                MESSAGEBOX("Undefined company parameters!", 0 + 16, "Major problem");
                opened = false;
                return;
            }

            //* Not seek right now since there is only one cie
            cie_id = WsCie.Cie_Id;
            ciename = WsCie.Cie_Name;
            licence = WsCie.Licence;
            cie_city = WsCie.Cie_City;
            cie_state = WsCie.Cie_State;
            cie_country = WsCie.Cie_Country;

            if (ALLTRIM(UserType) != "Accounting" || (bool)lWorkPer == true)
            {
                cur_gl_year = WsCie.Gl_Year;
                cur_gl_period = WsCie.Gl_Period;
                cur_ar_year = WsCie.Ar_Year;
                cur_ar_period = WsCie.Ar_Period;
                cur_ap_year = WsCie.Ap_Year;
                cur_ap_period = WsCie.Ap_Period;

                if (Lloginop == false)
                {
                    cur_op_year = WsCie.Op_Year;
                    cur_op_period = WsCie.Op_Period;
                }
            }

            cur_year = DateTime.Now.Year;//YEAR(DATE());
            //bool m0synchro = false;

            basket_overwrite = true;

            if (!ISNULL(WsCie.Valid_Accnt) && TYPE(WsCie.Valid_Accnt) == typeof(bool?))
                this.valid_accnt = WsCie.Valid_Accnt;
            else
                this.valid_accnt = true;

            if (TYPE(WsCie.Office_No) == typeof(byte?))
            {
                this.office_no = WsCie.Office_No;
                this.use_office = true;
            }
            else
            {
                this.office_no = 1;
                this.use_office = false;
            }

            if (TYPE(WsCie.Use_Longd) == typeof(bool?))
                this.use_longd = WsCie.Use_Longd;
            else
                this.use_longd = false;

            if (TYPE(WsCie.Use_Po) == typeof(bool?))
                this.use_po = WsCie.Use_Po;
            else
                this.use_po = false;

            if (TYPE(WsCie.Proxyname) == typeof(string))
                this.proxyname = WsCie.Proxyname;
            else
                this.proxyname = "";

            if (TYPE(WsCie.Proxyuser) == typeof(string))
                this.proxyuser = WsCie.Proxyuser;
            else
                this.proxyuser = "";

            if (TYPE(WsCie.Proxypass) == typeof(string))
                this.proxypass = WsCie.Proxypass;
            else
                this.proxypass = "";

            if (TYPE(WsCie.Glpermonth) == typeof(bool?))
                this.glpermonth = WsCie.Glpermonth;

            if (TYPE(WsCie.Glmonthone) == typeof(int?))
                this.glmonthone = WsCie.Glmonthone;

            this.webpage = WsCie.Website;
            this.gst_rate = WsCie.Gst_Rate;
            this.pst_rate = WsCie.Pst_Rate;
            this.tvh_rate = WsCie.Tvh_Rate;
            this.nogl_error = WsCie.Nogl_Error;
            this.nogl_ap = WsCie.Nogl_Ap;
            this.nogl_ap_re = WsCie.Nogl_Ap_Re;
            this.nogl_ar = WsCie.Nogl_Ar;
            this.nogl_bq = WsCie.Nogl_Bq;
            this.nogl_bq_re = WsCie.Nogl_Bq_Re;
            this.nogl_ap_disc = WsCie.Nogl_Ap_Disc;
            this.nogl_ar_disc = WsCie.Nogl_Ar_Disc;
            this.nogl_tps_ach = WsCie.Nogl_Tps_Ach;
            this.nogl_tvq_ach = WsCie.Nogl_Tvq_Ach;
            this.nogl_tvh_ach = WsCie.Nogl_Tvh_Ach;
            this.nogl_tps_vte = WsCie.Nogl_Tps_Vte;
            this.nogl_tvq_vte = WsCie.Nogl_Tvq_Vte;
            this.nogl_tvh_vte = WsCie.Nogl_Tvh_Vte;
            this.nogl_bnr = WsCie.Nogl_Bnr;
            this.nogl_contra = WsCie.Nogl_Contra;
            this.notps = WsCie.Notps;
            this.notvq = WsCie.Notvq;
            this.nb_per_aux = WsCie.Nb_Per_Aux;
            this.nb_per_gl = WsCie.Nb_Per_Gl;
            //*this.mailserver = WsCie.Mailserver;
            this.mailserver = "smtp-mail.outlook.com";
            //*this.auth_username = "noreply@multi-services.org";
            //*this.auth_passwd = "Cuz813911";
            this.faxprefix = WsCie.Faxprefix;
            this.currency = WsCie.Currency;
            this.lineout = WsCie.Lineout;
            this.int_activity = WsCie.Int_Activity;
            this.int_code = WsCie.Int_Code;
            this.prix_est_do = WsCie.Prix_Est_Do;
            this.marge_est_glo = WsCie.Marge_Est_Glo;
            this.cout_vente = WsCie.Cout_Vente;
            this.cout_fixe = WsCie.Cout_Fixe;
            this.cout_int = WsCie.Cout_Int;
            this.cout_s_rack = WsCie.Cout_S_Rack;
            this.cout_a_rack = WsCie.Cout_A_Rack;
            if (!EMPTY(WsCie.Rep_Inv)) //&& If empty, keep the default
            {
                this.rep_inv = WsCie.Rep_Inv;
            }
            this.wscustom = WsCie.Wscustom;
            this.email = WsCie.Email;
            this.eco_on = WsCie.Eco_On;
            this.eco_web = WsCie.Eco_Web;
            //*****************************
            this.da_per1d = WsCie.Da_Per1d;
            this.da_per1f = WsCie.Da_Per1f;
            this.da_per2d = WsCie.Da_Per2d;
            this.da_per2f = WsCie.Da_Per2f;
            this.da_per3d = WsCie.Da_Per3d;
            this.da_per3f = WsCie.Da_Per3f;
            this.da_per4d = WsCie.Da_Per4d;
            this.da_per4f = WsCie.Da_Per4f;
            this.da_per5d = WsCie.Da_Per5d;
            this.da_per5f = WsCie.Da_Per5f;
            this.da_per6d = WsCie.Da_Per6d;
            this.da_per6f = WsCie.Da_Per6f;
            this.da_per7d = WsCie.Da_Per7d;
            this.da_per7f = WsCie.Da_Per7f;
            this.da_per8d = WsCie.Da_Per8d;
            this.da_per8f = WsCie.Da_Per8f;
            this.da_per9d = WsCie.Da_Per9d;
            this.da_per9f = WsCie.Da_Per9f;
            this.da_per10d = WsCie.Da_Per10d;
            this.da_per10f = WsCie.Da_Per10f;
            this.da_per11d = WsCie.Da_Per11d;
            this.da_per11f = WsCie.Da_Per11f;
            this.da_per12d = WsCie.Da_Per12d;
            this.da_per12f = WsCie.Da_Per12f;
            //*******************************
            //&& Mois en Français
            this.moistxt[0] = "Janvier";
            this.moistxt[1] = "Février";
            this.moistxt[2] = "Mars";
            this.moistxt[3] = "Avril";
            this.moistxt[4] = "Mai";
            this.moistxt[5] = "Juin";
            this.moistxt[6] = "Juillet";
            this.moistxt[7] = "Août";
            this.moistxt[8] = "Septembre";
            this.moistxt[9] = "Octobre";
            this.moistxt[10] = "Novembre";
            this.moistxt[11] = "Décembre";
            //Jour en Français
            this.jourtxt[0] = "Dimanche";
            this.jourtxt[1] = "Lundi";
            this.jourtxt[2] = "Mardi";
            this.jourtxt[3] = "Mercredi";
            this.jourtxt[4] = "Jeudi";
            this.jourtxt[5] = "Vendredi";
            this.jourtxt[6] = "Samedi";

            for (int i = 0; i < 52; i++)
            {
                this.asemaine[i, 0] = "Semaine " + (i + 1);
                this.asemaine[i, 1] = i + 1;
            }

            for (int i = 0; i < 52; i++)
            {
                this.aweek[i, 0] = "Week " + (i + 1);
                this.aweek[i, 1] = i + 1;
            }

            this.unitef[0] = "ZERO";
            this.unitef[1] = "UN";
            this.unitef[2] = "DEUX";
            this.unitef[3] = "TROIS";
            this.unitef[4] = "QUATRE";
            this.unitef[5] = "CINQ";
            this.unitef[6] = "SIX";
            this.unitef[7] = "SEPT";
            this.unitef[8] = "HUIT";
            this.unitef[9] = "NEUF";
            this.unitef[10] = "DIX";
            this.unitef[11] = "ONZE";
            this.unitef[12] = "DOUZE";
            this.unitef[13] = "TREIZE";
            this.unitef[14] = "QUATORZE";
            this.unitef[15] = "QUINZE";
            this.unitef[16] = "SEIZE";
            this.unitef[17] = "DIX-SEPT";
            this.unitef[18] = "DIX-HUIT";
            this.unitef[19] = "DIX-NEUF";

            this.unitea[0] = "ZERO";
            this.unitea[1] = "ONE";
            this.unitea[2] = "TWO";
            this.unitea[3] = "THREE";
            this.unitea[4] = "FOUR";
            this.unitea[5] = "FIVE";
            this.unitea[6] = "SIX";
            this.unitea[7] = "SEVEN";
            this.unitea[8] = "EIGHT";
            this.unitea[9] = "NINE";
            this.unitea[10] = "TEN";
            this.unitea[11] = "ELEVEN";
            this.unitea[12] = "TWELVE";
            this.unitea[13] = "THIRTEEN";
            this.unitea[14] = "FOURTEEN";
            this.unitea[15] = "FIFTEEN";
            this.unitea[16] = "SIXTEEN";
            this.unitea[17] = "SEVENTEEN";
            this.unitea[18] = "EIGHTEEN";
            this.unitea[19] = "NINETEEN";


            this.dizainef[0] = "DIX";
            this.dizainef[1] = "VINGT";
            this.dizainef[2] = "TRENTE";
            this.dizainef[3] = "QUARANTE";
            this.dizainef[4] = "CINQUANTE";
            this.dizainef[5] = "SOIXANTE";
            this.dizainef[6] = "SOIXANTE-DIX";
            this.dizainef[7] = "QUATRE-VINGTS";
            this.dizainef[8] = "QUATRE-VINGT-DIX";

            this.dizainea[0] = "TEN";
            this.dizainea[1] = "TWENTY";
            this.dizainea[2] = "THIRTY";
            this.dizainea[3] = "FORTY";
            this.dizainea[4] = "FIFTY";
            this.dizainea[5] = "SIXTY";
            this.dizainea[6] = "SEVENTY";
            this.dizainea[7] = "EIGHTY";
            this.dizainea[8] = "NINETY";

            this.a71over[0] = "SOIXANTE ET ONZE";
            this.a71over[1] = "SOIXANTE-DOUZE";
            this.a71over[2] = "SOIXANTE-TREIZE";
            this.a71over[3] = "SOIXANTE-QUATORZE";
            this.a71over[4] = "SOIXANTE-QUINZE";
            this.a71over[5] = "SOIXANTE-SEIZE";
            this.a71over[6] = "SOIXANTE-DIX-SEPT";
            this.a71over[7] = "SOIXANTE-DIX-HUIT";
            this.a71over[8] = "SOIXANTE-DIX-NEUF";

            this.a91over[0] = "QUATRE-VINGT-ONZE";
            this.a91over[1] = "QUATRE-VINGT-DOUZE";
            this.a91over[2] = "QUATRE-VINGT-TREIZE";
            this.a91over[3] = "QUATRE-VINGT-QUATORZE";
            this.a91over[4] = "QUATRE-VINGT-QUINZE";
            this.a91over[5] = "QUATRE-VINGT-SEIZE";
            this.a91over[6] = "QUATRE-VINGT-DIX-SEPT";
            this.a91over[7] = "QUATRE-VINGT-DIX-HUIT";
            this.a91over[8] = "QUATRE-VINGT-DIX-NEUF";

            //&& Nb de jour par mois
            nbjrsmois[0] = 31;
            nbjrsmois[1] = IIF(MOD(YEAR(DATE()), 4) == 0, 29, 28);
            nbjrsmois[2] = 31;
            nbjrsmois[3] = 30;
            nbjrsmois[4] = 31;
            nbjrsmois[5] = 30;
            nbjrsmois[6] = 31;
            nbjrsmois[7] = 31;
            nbjrsmois[8] = 30;
            nbjrsmois[9] = 31;
            nbjrsmois[10] = 30;
            nbjrsmois[11] = 31;

            //&& SIGNIFICATION DU NO. DE LICENCE
            //&& EX: GOUDREAU
            //&& X--->GO = 71 + 79 = 150, DONC PRENDRE 0(Compliqué mais servira a vérifier avec nom cie)
            //&& X = DÉMO
            //&& X--->C pour CAD
            //&& X--->W->WINFREIGHT, T->TACTISOFT, Z->ZEBRA, A->WINFREIGHT + ZEBRA, B->WINFREIGHT + TACTISOFT, C->ALL
            //&& 9--->Pour 2000
            //&& XX-- > Nbr de users
            //&& 0001->Premier

            //&& DONC NO LICENCE = 0CC0120001 && GOUDREAU LE BON

            //&& DONC NO LICENCE = 9CC0020002 && ZEN LE BON
            //&& DONC NO LICENCE = 0UB9150001 && ITS LE BON
            //&& DONC NO LICENCE = 2CB0060001 && MAISLINER LE BON
            //&& DONC NO LICENCE = 1UB9030001 && NORVIK LE BON
            //&& DONC NO LICENCE = 2CB4050001 && CAC
            //&& DONC NO LICENCE = 7CC4050002 && NOVA CARGO
            //&& DONC NO LICENCE = 8CW4050003 && GMX
            //&& DONC NO LICENCE = 7CB4100001 && NORTHERN ARROW
            //&& DONC NO LICENCE = 9CLDI && TRANSPOLLDI
            //&& DONC NO LICENCE = 3WAY0705 && 3 WAY
            //&& NO LICENCE = 5FP610001 && FREIGHT PARTNERS


            //&& DONC NO LICENCE = 5PCPLUS && PC PLUS

            //&& DONC NO LICENCE = 2CC9060001 && MULTI - SERVICE GSTJ LE BON
            //&& DONC NO LICENCE = 6CC9990001 && ACCES CREDIT LE BON
            //&& DONC NO LICENCE = 4CC9990001 && GEOLAB

            if (this.demo == false)
            {
                if (SUBSTR(WsCie.Licence, 2, 1) == "C")
                    this.usdcad = "CAD";
                else
                    this.usdcad = "USD";
            }

            if (AT(SUBSTR(WsCie.Licence, 1, 1), "0123456789") != 0)
                this.demo = false; // && Normal
            else
            {
                if (SUBSTR(WsCie.Licence, 1, 1) == "X")
                    this.demo = true; //&& Démonstration system
                else
                    this.licence = "ERROR"; //&& Invalid licence
            }

            switch (SUBSTR(WsCie.Licence, 3, 1))
            {
                case "W":
                    this.winfreight = true;
                    break;
                case "T":
                    //*this.tactisoft = true; //&& KM1
                    break;
                case "Z":
                    this.zebra = true;
                    break;
                case "A":
                    this.winfreight = true;
                    this.zebra = true;
                    break;
                case "B":
                    this.winfreight = true;
                    //*this.tactisoft = true; //&& KM1
                    this.zebra = false;
                    break;
                case "C":
                    this.winfreight = true;
                    //*this.tactisoft = true; //&& KM1
                    this.zebra = true;
                    break;
            }

            if (ALLTRIM(this.licence.ToString()) == "1UB9030001")
                this.pdfmessage = ""; 
            else
                this.pdfmessage = "You will need a pdf reader program to read the attachment.  If you don't have one installed, you can download a free version at http://www.adobe.com/products/acrobat/readstep2.html."; 
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

        public void Shutdown()
        {
            //*** shutdown the application
            if (sessionid != 0)
            {
                //DELETE FROM(THIS.wssession_table) WHERE ident = THIS.Sessionid
            }

            //int i, isize;
            //isize = ALEN(this.active_form);
            //for (i = isize; i >= 0; i--)
            //{
            //    if (TYPE(this.active_form[0,i]) != typeof(bool) && !ISNULL(this.active_form[0,i]) && TYPE(this.active_form[0,i]) != typeof(string))
            //    {
            //        //active_form[0,i].QueryUnload();
            //        //active_form[0,i].Release();
            //    }
            //}
            //CLEAR EVENTS
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
