using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoquilleViva
{
    public class EventSubscriberTests
    {
        public void EventSubscriber_WaitForPastEvents()
        {
            var wssession = new WsSession();
            var subscriber = new EventSubscriber(wssession);
            wssession.DofoxproRet("");
            //VerifyResults(subscriber);
        }

        public void EventSubscriber_WaitForFutureEvents()
        {
            var wssession = new WsSession();
            var subscriber = new EventSubscriber(wssession);
            Task.Delay(1).ContinueWith(t => wssession.DofoxproRet(""));
            var result = subscriber.WaitForEvent();
        }

        static void VerifyResults(EventSubscriber subscriber)
        {
            var result = subscriber.WaitForEvent();
            if (result.Name == nameof(WsSession.DofoxproRet) && result.Params.Length == 1) { return;  };
        }
    }

    public class WsSession
    {
        public event Action<string> Dofoxpro;
        public event Action<string> DofoxproSet;
        public event Action<string> DofoxproRet2;
        public event Action<string> DofoxproRetBool;
        //public event Action<string> DofoxproRetInt;
        public event Action<string> DofoxproRetStr;

        public object Retval { get; set; }
        public bool RetBool { get; set; }
        public int RetInt { get; set; }
        public string RetStr { get; set; }

        private bool _DidFoxproFinish = false;

        /*********wssession property************/
        public object accnt_allowed_days { get; set; }
        public object accountant { get; set; }
        public object accounting { get; set; }
        public object accpac { get; set; }
        public object aci_active { get; set; }
        public object administrator { get; set; }
        public object auth_passwd { get; set; }
        public object auth_username { get; set; }
        public object auto_alert_on { get; set; }
        public object basket_active { get; set; }
        public object basket_folder { get; set; }
        public object basket_overwrite { get; set; }
        public int bdisabledforecolor { get; set; } = 0;
        public int bforecolor { get; set; } = 0;
        public object calc_period   { get; set; }
        public object calc_year     { get; set; }
        public object can_mod_report { get; set; }
        public object cheque        { get; set; }
        public object chqtype       { get; set; }
        public object cie_city      { get; set; }
        public object cie_country   { get; set; }
        public object cie_id        { get; set; }
        public object cie_state     { get; set; }
        public object ciename       { get; set; }
        public object Ciepath { get; set; }
        public object commport { get; set; }
        public object consolidated_invoices { get; set; }
        public object cout_a_rack { get; set; }
        public object cout_fixe { get; set; }
        public object cout_int { get; set; }
        public object cout_s_rack { get; set; }
        public object cout_vente { get; set; }
        public object cpt { get; set; }
        public object crystal { get; set; }
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
        public object date_format { get; set; }
        public object dbexport { get; set; }
        public object dbimport { get; set; }
        public object dbwhouse { get; set; }
        public object def_tel_int { get; set; }
        public object demo { get; set; }
        public object dept { get; set; }
        public bool development { get; set; } = false;
        public object ecclicode { get; set; }
        public object eccode { get; set; }
        public object ecname { get; set; }
        public object eco_on { get; set; }
        public object eco_web { get; set; }
        public object email { get; set; }
        public bool email_bcc_self { get; set; } = false;
        public object faxcover  { get; set; }
        public object faxprefix { get; set; }
        public int fbackcolor { get; set; } = 0;
        public int fdisabledbackcolor { get; set; } = 0;
        public int fdisabledforecolor { get; set; } = 0;
        public int fforecolor { get; set; } = 0;
        public object forcedbasket { get; set; }
        public object forceperiod  { get; set; }
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
        public object is_synchro_central { get; set; }
        public object is_synchro_client { get; set; }
        public object language { get; set; }
        public int lbackcolor { get; set; } = 0;
        public int ldisabledbackcolor { get; set; } = 0;
        public int ldisabledforecolor { get; set; } = 0;
        public int lforecolor { get; set; } = 0;
        public int lic_users { get; set; } = 0;
        public object lic_users_control { get; set; }
        public object licence { get; set; }
        public object lineout { get; set; }
        public bool Lloginop { get; set; } = false;
        public bool log_user { get; set; } = false;
        public string loginscreen { get; set; } = "";
        public object lpstongst { get; set; }
        public object lshortcutmenu { get; set; }
        public object mail_attached { get; set; }
        public object mail_notes { get; set; }
        public object mail_subject  { get; set; }
        public object mail_to           { get; set; }
        public object mailport          { get; set; }
        public object mailserver        { get; set; }
        public object marge_est_glo     { get; set; }
        public object multi_agent       { get; set; }
        public object nb_cur_user       { get; set; }
        public int nb_new_mesg { get; set; } = 0;
        public object nb_per_aux        { get; set; }
        public object nb_per_gl         { get; set; }
        public object news_run          { get; set; }
        public object news_startup_page { get; set; }
        public object newsform { get; set; }
        public object nobracelet { get; set; }
        public object nocaisse      { get; set; }
        public object nocheckcredit { get; set; }
        public object nogl_ap       { get; set; }
        public object nogl_ap_disc  { get; set; }
        public object nogl_ap_re    { get; set; }
        public object nogl_ar       { get; set; }
        public object nogl_ar_disc  { get; set; }
        public object nogl_bnr      { get; set; }
        public object nogl_bq       { get; set; }
        public object nogl_bq_re    { get; set; }
        public object nogl_contra   { get; set; }
        public object nogl_error { get; set; }
        public object nogl_tps_ach { get; set; }
        public object nogl_tps_vte { get; set; }
        public object nogl_tvh_ach { get; set; }
        public object nogl_tvh_vte { get; set; }
        public object nogl_tvq_ach { get; set; }
        public object nogl_tvq_vte { get; set; }
        public object notps             { get; set; }
        public object notvq             { get; set; }
        public object office_no         { get; set; }
        public object on_error_quit     { get; set; }
        public bool opened { get; set; } = false;
        public object owinfax           { get; set; }
        public object pdfmessage        { get; set; }
        public object period1 { get; set; }
        public object phoneint                  { get; set; }
        public object prix_est_do               { get; set; }
        public object proxyhttpconnecttype      { get; set; }
        public object proxyname                 { get; set; }
        public object proxypass                 { get; set; }
        public object proxyuser                 { get; set; }
        public object pst_rate                  { get; set; }
        public object region                    { get; set; }
        public object rep_inv                   { get; set; }
        public object running_terminal_server   { get; set; }
        public object search_ret_param1         { get; set; }
        public object searchid { get; set; }
        public object sendmailsync          { get; set; }
        public int sessionid { get; set; } = 0;
        public object shipmentnostyle       { get; set; }
        public object shortcutmenu          { get; set; }
        public object show_op_msg           { get; set; }
        public object shutdown_count { get; set; }
        public object spicture                  { get; set; }
        public object tactisoft                 { get; set; }
        public object tmppath                   { get; set; }
        public object tvh_rate                  { get; set; }
        public object usdcad                    { get; set; }
        public object use                       { get; set; }
        public object use_longd                 { get; set; }
        public object use_office                { get; set; }
        public object use_po                    { get; set; }
        public object userarrep                 { get; set; }
        public object userbasket                { get; set; }
        public object usercanmodclientaccntg { get; set; }
        public object usercie                   { get; set; }
        public string usercode { get; set; } = "";
        public object useremail             { get; set; }
        public object useremail2            { get; set; }
        public object useremailsignature    { get; set; }
        public object usergroup             { get; set; }
        public string username { get; set; } = "";
        public object userphone             { get; set; }
        public object usertimer             { get; set; }
        public object usertitle             { get; set; }
        public object usertype              { get; set; }
        public object vabandon              { get; set; }
        public object valid_accnt           { get; set; }
        public object verif_crlimit_lastid  { get; set; }
        public object vers_country          { get; set; }
        public object wbackcolor            { get; set; }
        public object webpage               { get; set; }
        public object wforecolor            { get; set; }
        public object wich_email            { get; set; }
        public object wich_fax              { get; set; }
        public object winfreight            { get; set; }
        public object wpicture              { get; set; }
        public object wscustom              { get; set; }
        public object wsmenu_nb             { get; set; }
        public object wsnewsdir             { get; set; }
        public object wssession_table       { get; set; }
        public object zart                  { get; set; }
        public object zebra                 { get; set; }
        public object zebra_active          { get; set; }
        public object zebra_contrat_auto { get; set; }

        /***************Wssession Array property*************/
        public object[] a71over { get; set; }   //9
        public object[] a91over { get; set; }   //9
        public object[,] a_wsmenu { get; set; } //1,5
        public object[] active_bar { get; set; }   //1
        public object[,] active_form { get; set; }  //1,2
        public object[,] asemaine { get; set; } //52,2
        public object[,] aweek { get; set; } //52,2
        public object[] dizainef { get; set; }  //9
        public object[] dizainea { get; set; }  //9
        public Array jourtxt { get; set; }
        public Array moistxt { get; set; }
        public object[] nbjrsmois { get; set; } //1
        public object[] unitea { get; set; }   //19
        public object[] unitef { get; set; }   //19

        private WsSession wssession1;
        private WsSession wssession2;
        private WsSession wssession3;
        private WsSession wssession4;
        private WsSession wssession5;
        private WsSession wssession6;

        private EventSubscriber subscriber1;
        private EventSubscriber subscriber2;
        private EventSubscriber subscriber3;
        private EventSubscriber subscriber4;
        private EventSubscriber subscriber5;
        private EventSubscriber subscriber6;

        public WsSession()
        {
            a71over = new object[9];
            a91over = new object[9];
            a_wsmenu = new object[1,5];
            active_bar = new object[1];
            active_form = new object[1,2];
            asemaine = new object[52,2];
            aweek = new object[52,2];
            dizainef = new object[9];
            dizainea = new object[9];
            jourtxt = new string[7];
            moistxt = new string[12];

            nbjrsmois = new object[12];
            unitea = new object[19];
            unitef = new object[19];
        }


        public void Init()
        {
            wssession1 = new WsSession();
            wssession2 = new WsSession();
            wssession3 = new WsSession();
            wssession4 = new WsSession();
            wssession5 = new WsSession();
            wssession6 = new WsSession();
            subscriber1 = new EventSubscriber(wssession1);
            subscriber2 = new EventSubscriber(wssession2);
            subscriber3 = new EventSubscriber(wssession3);
            subscriber4 = new EventSubscriber(wssession4);
            subscriber5 = new EventSubscriber(wssession5);
            subscriber6 = new EventSubscriber(wssession6);
        }

        public void ExecFoxpro(string command, bool isFunction = false)
        {
            if (isFunction)
            {
                Dofoxpro(command);
            }
            else
            {
                Dofoxpro("xwssession." + command);
            }

            //WsSession wssession = new WsSession();
            //EventSubscriber subscriber = new EventSubscriber(wssession);
            Task.Delay(1).ContinueWith(t => wssession1.Dofoxpro(""));
            var result = subscriber1.WaitForEvent();
        }

        public void SetVariable(string name, object value, char type = 'C')
        {
            if(type == 'C')
            {
                value = Q2(value.ToString().Replace("\r\n", ""));
            }
            else if(type == 'L')
            {
                value = FoxBool((bool)value);
            }
            else if(type == 'N')
            {
                value = (int)value;
            }
            else if (type == 'O')
            {
               //do nothing
            }

            DofoxproSet("xwssession." + name + " = " + value);      //xwssession.wsname = Q2(value)

            // var wssession = new WsSession();
            // var subscriber = new EventSubscriber(wssession);
            Task.Delay(1).ContinueWith(t => wssession2.DofoxproSet(""));
            var result = subscriber2.WaitForEvent();
            // subscriber.Dispose();
        }

        public object DofoxproRet(string value)
        {
            Retval = null;
            DofoxproRet2("xwssession." + value);  //Ex : xwssession.wsname

            // var wssession = new WsSession();
            // var subscriber = new EventSubscriber(xwssession2);
            Task.Delay(1).ContinueWith(t => wssession3.DofoxproRet2(""));
            var result = subscriber3.WaitForEvent();
            // subscriber.Dispose();
            return Retval;
        }

        public bool ReturnBool(string value, bool isFunction = false)
        {
            RetBool = false;

            if (isFunction)
            {
                DofoxproRetBool(value);
            }
            else
            {
                DofoxproRetBool("xwssession." + value); 
            }

            // var wssession = new WsSession();
            // var subscriber = new EventSubscriber(xwssession2);
            Task.Delay(1).ContinueWith(t => wssession4.DofoxproRetBool(""));
            var result = subscriber4.WaitForEvent();
            // subscriber.Dispose();
            return RetBool;
        }

        public int ReturnInt(int value)
        {
            //RetInt = 0;
            //DofoxproRetInt("xwssession." + value);  //Ex : xwssession.wsname

            //// var wssession = new WsSession();
            //// var subscriber = new EventSubscriber(xwssession2);
            //Task.Delay(1).ContinueWith(t => wssession5.DofoxproRetInt(""));
            //var result = subscriber5.WaitForEvent();
            //// subscriber.Dispose();
            //return RetInt;

            return value;
        }

        public string ReturnStr(string value)
        {
            RetStr = "";
            DofoxproRetStr("xwssession." + value);  //Ex : xwssession.wsname

            // var wssession = new WsSession();
            // var subscriber = new EventSubscriber(xwssession2);
            Task.Delay(1).ContinueWith(t => wssession6.DofoxproRetStr(""));
            var result = subscriber6.WaitForEvent();
            // subscriber.Dispose();
            return RetStr;
        }

        public async Task Do_init()
        {
            _DidFoxproFinish = false;

            ExecFoxpro("do_init()");

            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task Test()
        {
            _DidFoxproFinish = false;

            ExecFoxpro("test()");

            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public bool IsCSharp(string cMember)
        {
            var members = new Dictionary<string, bool>();
            //Methods of wssession
            members.Add("Do_init".ToLower(), true);
            members.Add("Test".ToLower(), true);
            members.Add("Cdate".ToLower(), false);
            members.Add("refresh_param".ToLower(), false);
            //Property of wssession
            members.Add("fBackColor".ToLower(), true);
            members.Add("moistxt".ToLower(), false);
            members.Add("jourtxt".ToLower(), false);
            members.Add("a71over".ToLower(), false);
            members.Add("a91over".ToLower(), false);
            members.Add("a_wsmenu".ToLower(), false);
            members.Add("active_bar".ToLower(), false);

            if (members.ContainsKey(cMember))
            {
                if (members[cMember])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

            
        }

        public void After()
        {
            _DidFoxproFinish = true;
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

            //DofoxproRet("cdate(" + FoxDate(pDate) + ", " + FoxBool(p0frch) + ", " + FoxBool(pJourTxt) + ")");
            //return Retval;
        }

        public void Chariot()
        {
            ExecFoxpro("chariot()");
        }

        public async Task Check_integra(object pFrom)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("check_integra(" + Q2(pFrom) + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task Check_mesg(string cShow)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("check_mesg(" + Q2(cShow) + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task Check_shutdown()
        {
            _DidFoxproFinish = false;

            ExecFoxpro("check_shutdown()");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task Createdir(object pDir)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("createdir(" + Q2(pDir) + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task Disabled_bar(object nInstance)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("disabled_bar(" + nInstance + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task Dispatch(object paction)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("dispatch(" + paction + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task do_menu(object p_lang)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("do_menu(" + p_lang + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task enabled_bar(object nInstance)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("enabled_bar(" + nInstance + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public object exist_bar(object cBarname)
        {
            DofoxproRet("exist_bar(" + Q2(cBarname) + ")");
            return Retval;
        }

        public object fax_get_info(object pIdent)
        {
            DofoxproRet("fax_get_info(" + pIdent + ")");
            return Retval;
        }

        public object fax_queue(object pAction, object pWhen, object REP_NAME, object pFaxTo, object pCie, object pSubject, object pFax)
        {
            DofoxproRet("fax_queue(" + Q2(pAction) + ", " + Q2(pWhen) + ", " + Q2(REP_NAME) + ", " + Q2(pFaxTo) + ", " + Q2(pCie) + ", " + Q2(pSubject) + ", " + Q2(pFax) + ")");
            return Retval;
        }

        public object fax_send(object l_Queue_id)
        {
            DofoxproRet("fax_send(" + l_Queue_id + ")");
            return Retval;
        }

        public async Task fourn_valid()
        {
            _DidFoxproFinish = false;

            ExecFoxpro("fourn_valid()");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task get_next_id(object ltable, object loption)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("get_next_id(" + Q2(ltable) + ", " + Q2(loption) + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
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

        public void get_temp_id()
        {

        }

        public void get_unique_file_name()
        {
           
        }

        public void hide_bar()
        {

        }

        public async Task launch_bar(object lBarobjet)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("launch_bar(" + lBarobjet + ")");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public object launch_form(object lFormName, string lAction, int lRecId, string cParamPlus)
        {
            DofoxproRet("launch_form(" + Q2(lFormName) + ", " + Q2(lAction) + ", " + lRecId + ", " + Q2(cParamPlus) + ")");
            return Retval;
        }

        public void logmsg()
        {

        }

        public async Task Logon()
        {
            _DidFoxproFinish = false;

            ExecFoxpro("Logon()");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

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

        public void refresh_param(string lWorkPer)
        {
            ExecFoxpro("refresh_param(" + StrToFoxBool(lWorkPer) + ")");
        }

        public void releasefoxtoolbars()
        {
            int slnFor;
            string[] aToolbars;

            aToolbars = new string[11];

            aToolbars[0] = "Color Palette";
            aToolbars[1] = "Database Designer";
            aToolbars[2] = "Form Controls";
            aToolbars[3] = "Form Designer";
            aToolbars[4] = "Layout";
            aToolbars[5] = "Print Preview";
            aToolbars[6] = "Query Designer";
            aToolbars[7] = "Report Controls";
            aToolbars[8] = "Report Designer";
            aToolbars[9] = "Standard";
            aToolbars[10] = "View Designer";

            for(slnFor = 0; slnFor < 11; slnFor++)
            {
                ReturnBool("WVISIBLE(" + Q2(aToolbars[slnFor]) + ")", true);
                if (RetBool)
                {
                    ExecFoxpro("HIDE WINDOW(" + Q2(aToolbars[slnFor]) + ")", true);
                }
            }
        }

        public void Shellexec(string commands)
        {
            //try
            //{
            //    // create the ProcessStartInfo using "cmd" as the program to be run,
            //    // and "/c " as the parameters.
            //    // Incidentally, /c tells cmd that we want it to execute the command that follows,
            //    // and then exit.
            //    System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + commands);

            //    // The following commands are needed to redirect the standard output.
            //    // This means that it will be redirected to the Process.StandardOutput StreamReader.
            //    procStartInfo.RedirectStandardOutput = true;
            //    procStartInfo.UseShellExecute = false;
            //    // Do not create the black window.
            //    procStartInfo.CreateNoWindow = true;
            //    // Now we create a process, assign its ProcessStartInfo and start it
            //    System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //    proc.StartInfo = procStartInfo;
            //    proc.Start();
            //}
            //catch (Exception objException)
            //{
            //    // Log the exception
            //    File.WriteAllText(@"C:\Users\Multi-Service\source\repos\CoquilleViva\CoquilleViva\bin\Debug\netstandard2.0\error.txt", objException.ToString());
            //}

            ExecFoxpro("shellexec('" + commands + "')");
        }

        public async Task show_bar(int nInstance)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("show_bar(" + nInstance + ")");

            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public void Showhelp(string link = "")
        {
            //Shellexec(link);
            ExecFoxpro("showhelp(" + Q2(link) + ")");
        }

        public async Task shut_bar(object cBarname)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("shut_bar(" + cBarname + ")");

            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task shut_form(int nInstance)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("shut_form(" + nInstance + ")");

            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
        }

        public async Task shutdown()
        {
            _DidFoxproFinish = false;

            ExecFoxpro("shutdown()");

            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
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
            DofoxproRet("xwssession.web_date(" + FoxDate(pDate) + ")");
            return Retval;
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
            if (value == "True" || value == "Vrai")
                return ".T.";
            else if (value == "False" || value == "Faux")
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
