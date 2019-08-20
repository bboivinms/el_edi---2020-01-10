using System;
using System.Diagnostics;
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
        public event Action<string> DofoxproRetInt;
        public event Action<string> DofoxproRetStr;

        public object Retval { get; set; }
        public bool RetBool { get; set; }
        public int RetInt { get; set; }
        public string RetStr { get; set; }

        private bool _DidFoxproFinish = false;

        /*********wssession property************/
        public object accnt_allowed_days { get { return DofoxproRet("accnt_allowed_days"); } set { SetVariable("accnt_allowed_days", value); } }
        public object accountant { get { return DofoxproRet("accountant"); } set { SetVariable("accountant", value); } }
        public object accounting { get { return DofoxproRet("accounting"); } set { SetVariable("accounting", value); } }
        public object accpac { get { return DofoxproRet("accpac"); } set { SetVariable("accpac", value); } }
        public object aci_active { get { return DofoxproRet("aci_active"); } set { SetVariable("aci_active", value); } }
        public object administrator { get { return DofoxproRet("administrator"); } set { SetVariable("administrator", value); } }
        public object auth_passwd { get { return DofoxproRet("auth_passwd"); } set { SetVariable("auth_passwd", value); } }
        public object auth_username { get { return DofoxproRet("auth_username"); } set { SetVariable("auth_username", value); } }
        public object auto_alert_on { get { return DofoxproRet("auto_alert_on"); } set { SetVariable("auto_alert_on", value); } }
        public object basket_active { get { return DofoxproRet("basket_active"); } set { SetVariable("basket_active", value); } }
        public object basket_folder { get { return DofoxproRet("basket_folder"); } set { SetVariable("basket_folder", value); } }
        public object basket_overwrite { get { return DofoxproRet("basket_overwrite"); } set { SetVariable("basket_overwrite", value); } }
        public int bdisabledforecolor { get { return ReturnInt("bdisabledforecolor"); } set { SetVariable("bdisabledforecolor", value, 'N'); } }
        public int bforecolor { get { return ReturnInt("bforecolor"); } set { SetVariable("bforecolor", value, 'N'); } }
        public object calc_period { get { return DofoxproRet("calc_period"); } set { SetVariable("calc_period", value); } }
        public object calc_year { get { return DofoxproRet("calc_year"); } set { SetVariable("calc_year", value); } }
        public object can_mod_report { get { return DofoxproRet("can_mod_report"); } set { SetVariable("can_mod_report", value); } }
        public object cheque { get { return DofoxproRet("cheque"); } set { SetVariable("cheque", value); } }
        public object chqtype { get { return DofoxproRet("chqtype"); } set { SetVariable("chqtype", value); } }
        public object cie_city { get { return DofoxproRet("cie_city"); } set { SetVariable("cie_city", value); } }
        public object cie_country { get { return DofoxproRet("cie_country"); } set { SetVariable("cie_country", value); } }
        public object cie_id { get { return DofoxproRet("cie_id"); } set { SetVariable("cie_id", value); } }
        public object cie_state { get { return DofoxproRet("cie_state"); } set { SetVariable("cie_state", value); } }
        public object ciename { get { return DofoxproRet("ciename"); } set { SetVariable("ciename", value); } }
        public object Ciepath { get { return DofoxproRet("ciepath"); } set { SetVariable("ciepath", value); } }
        public object commport { get { return DofoxproRet("commport"); } set { SetVariable("commport", value); } }
        public object consolidated_invoices { get { return DofoxproRet("consolidated_invoices"); } set { SetVariable("consolidated_invoices", value); } }
        public object cout_a_rack { get { return DofoxproRet("cout_a_rack"); } set { SetVariable("cout_a_rack", value); } }
        public object cout_fixe { get { return DofoxproRet("cout_fixe"); } set { SetVariable("cout_fixe", value); } }
        public object cout_int { get { return DofoxproRet("cout_int"); } set { SetVariable("cout_int", value); } }
        public object cout_s_rack { get { return DofoxproRet("cout_s_rack"); } set { SetVariable("cout_s_rack", value); } }
        public object cout_vente { get { return DofoxproRet("cout_vente"); } set { SetVariable("cout_vente", value); } }
        public object cpt { get { return DofoxproRet("cpt"); } set { SetVariable("cpt", value); } }
        public object crystal { get { return DofoxproRet("crystal"); } set { SetVariable("crystal", value); } }
        public object cur_ap_period { get { return DofoxproRet("cur_ap_period"); } set { SetVariable("cur_ap_period", value); } }
        public object cur_ap_year { get { return DofoxproRet("cur_ap_year"); } set { SetVariable("cur_ap_year", value); } }
        public object cur_ar_period { get { return DofoxproRet("cur_ar_period"); } set { SetVariable("cur_ar_period", value); } }
        public object cur_ar_year { get { return DofoxproRet("cur_ar_year"); } set { SetVariable("cur_ar_year", value); } }
        public object cur_gl_period { get { return DofoxproRet("cur_gl_period"); } set { SetVariable("cur_gl_period", value); } }
        public object cur_gl_year { get { return DofoxproRet("cur_gl_year"); } set { SetVariable("cur_gl_year", value); } }
        public object cur_onoff { get { return DofoxproRet("cur_onoff"); } set { SetVariable("cur_onoff", value); } }
        public object cur_op_period { get { return DofoxproRet("cur_op_period"); } set { SetVariable("cur_op_period", value); } }
        public object cur_op_year { get { return DofoxproRet("cur_op_year"); } set { SetVariable("cur_op_year", value); } }
        public object cur_year { get { return DofoxproRet("cur_year"); } set { SetVariable("cur_year", value); } }
        public object curapplication { get { return DofoxproRet("curapplication"); } set { SetVariable("curapplication", value); } }
        public object curapplication_no { get { return DofoxproRet("curapplication_no"); } set { SetVariable("curapplication_no", value); } }
        public object currency { get { return DofoxproRet("currency"); } set { SetVariable("currency", value); } }
        public object da_per10d { get { return DofoxproRet("da_per10d"); } set { SetVariable("da_per10d", value); } }
        public object da_per10f { get { return DofoxproRet("da_per10f"); } set { SetVariable("da_per10f", value); } }
        public object da_per11d { get { return DofoxproRet("da_per11d"); } set { SetVariable("da_per11d", value); } }
        public object da_per11f { get { return DofoxproRet("da_per11f"); } set { SetVariable("da_per11f", value); } }
        public object da_per12d { get { return DofoxproRet("da_per12d"); } set { SetVariable("da_per12d", value); } }
        public object da_per12f { get { return DofoxproRet("da_per12f"); } set { SetVariable("da_per12f", value); } }
        public object da_per1d { get { return DofoxproRet("da_per1d"); } set { SetVariable("da_per1d", value); } }
        public object da_per1f { get { return DofoxproRet("da_per1f"); } set { SetVariable("da_per1f", value); } }
        public object da_per2d { get { return DofoxproRet("da_per2d"); } set { SetVariable("da_per2d", value); } }
        public object da_per2f { get { return DofoxproRet("da_per2f"); } set { SetVariable("da_per2f", value); } }
        public object da_per3d { get { return DofoxproRet("da_per3d"); } set { SetVariable("da_per3d", value); } }
        public object da_per3f { get { return DofoxproRet("da_per3f"); } set { SetVariable("da_per3f", value); } }
        public object da_per4d { get { return DofoxproRet("da_per4d"); } set { SetVariable("da_per4d", value); } }
        public object da_per4f { get { return DofoxproRet("da_per4f"); } set { SetVariable("da_per4f", value); } }
        public object da_per5d { get { return DofoxproRet("da_per5d"); } set { SetVariable("da_per5d", value); } }
        public object da_per5f { get { return DofoxproRet("da_per5f"); } set { SetVariable("da_per5f", value); } }
        public object da_per6d { get { return DofoxproRet("da_per6d"); } set { SetVariable("da_per6d", value); } }
        public object da_per6f { get { return DofoxproRet("da_per6f"); } set { SetVariable("da_per6f", value); } }
        public object da_per7d { get { return DofoxproRet("da_per7d"); } set { SetVariable("da_per7d", value); } }
        public object da_per7f { get { return DofoxproRet("da_per7f"); } set { SetVariable("da_per7f", value); } }
        public object da_per8d { get { return DofoxproRet("da_per8d"); } set { SetVariable("da_per8d", value); } }
        public object da_per8f { get { return DofoxproRet("da_per8f"); } set { SetVariable("da_per8f", value); } }
        public object da_per9d { get { return DofoxproRet("da_per9d"); } set { SetVariable("da_per9d", value); } }
        public object da_per9f { get { return DofoxproRet("da_per9f"); } set { SetVariable("da_per9f", value); } }
        public object date_format { get { return DofoxproRet("date_format"); } set { SetVariable("date_format", value); } }
        public object dbexport { get { return DofoxproRet("dbexport"); } set { SetVariable("dbexport", value); } }
        public object dbimport { get { return DofoxproRet("dbimport"); } set { SetVariable("dbimport", value); } }
        public object dbwhouse { get { return DofoxproRet("dbwhouse"); } set { SetVariable("dbwhouse", value); } }
        public object def_tel_int { get { return DofoxproRet("def_tel_int"); } set { SetVariable("def_tel_int", value); } }
        public object demo { get { return DofoxproRet("demo"); } set { SetVariable("demo", value, 'L'); } }
        public object dept { get { return DofoxproRet("dept"); } set { SetVariable("dept", value); } }
        public bool development { get { return ReturnBool("development"); } set { SetVariable("development", value, 'L'); } }
        public object ecclicode { get { return DofoxproRet("ecclicode"); } set { SetVariable("ecclicode", value); } }
        public object eccode { get { return DofoxproRet("eccode"); } set { SetVariable("eccode", value); } }
        public object ecname { get { return DofoxproRet("ecname"); } set { SetVariable("ecname", value); } }
        public object eco_on { get { return DofoxproRet("eco_on"); } set { SetVariable("eco_on", value); } }
        public object eco_web { get { return DofoxproRet("eco_web"); } set { SetVariable("eco_web", value); } }
        public object email { get { return DofoxproRet("email"); } set { SetVariable("email", value); } }
        public bool email_bcc_self { get { return ReturnBool("email_bcc_self"); } set { SetVariable("email_bcc_self", value, 'L'); } }
        public object faxcover { get { return DofoxproRet("faxcover"); } set { SetVariable("faxcover", value); } }
        public object faxprefix { get { return DofoxproRet("faxprefix"); } set { SetVariable("faxprefix", value); } }
        public int fbackcolor { get { return ReturnInt("fbackcolor"); } set { SetVariable("fbackcolor", value, 'N'); } }
        public int fdisabledbackcolor { get { return ReturnInt("fdisabledbackcolor"); } set { SetVariable("fdisabledbackcolor", value, 'N'); } }
        public int fdisabledforecolor { get { return ReturnInt("fdisabledforecolor"); } set { SetVariable("fdisabledforecolor", value, 'N'); } }
        public int fforecolor { get { return ReturnInt("fforecolor"); } set { SetVariable("fforecolor", value, 'N'); } }
        public object forcedbasket { get { return DofoxproRet("forcedbasket"); } set { SetVariable("forcedbasket", value); } }
        public object forceperiod { get { return DofoxproRet("forceperiod"); } set { SetVariable("forceperiod", value); } }
        public object fxbtndisabledborder { get { return DofoxproRet("fxbtndisabledborder"); } set { SetVariable("fxbtndisabledborder", value); } }
        public object fxbtndisabledcolor { get { return DofoxproRet("fxbtndisabledcolor"); } set { SetVariable("fxbtndisabledcolor", value); } }
        public object fxbtndisabledfcolor { get { return DofoxproRet("fxbtndisabledfcolor"); } set { SetVariable("fxbtndisabledfcolor", value); } }
        public object fxbtnenabledborder { get { return DofoxproRet("fxbtnenabledborder"); } set { SetVariable("fxbtnenabledborder", value); } }
        public object fxbtnenabledcolor { get { return DofoxproRet("fxbtnenabledcolor"); } set { SetVariable("fxbtnenabledcolor", value); } }
        public object fxbtnenabledfcolor { get { return DofoxproRet("fxbtnenabledfcolor"); } set { SetVariable("fxbtnenabledfcolor", value); } }
        public object glmonthone { get { return DofoxproRet("glmonthone"); } set { SetVariable("glmonthone", value); } }
        public object glpermonth { get { return DofoxproRet("glpermonth"); } set { SetVariable("glpermonth", value); } }
        public object gst_rate { get { return DofoxproRet("gst_rate"); } set { SetVariable("gst_rate", value); } }
        public object help_start_doc { get { return DofoxproRet("help_start_doc"); } set { SetVariable("help_start_doc", value); } }
        public object idtax { get { return DofoxproRet("idtax"); } set { SetVariable("idtax", value); } }
        public object int_activity { get { return DofoxproRet("int_activity"); } set { SetVariable("int_activity", value); } }
        public object int_code { get { return DofoxproRet("int_code"); } set { SetVariable("int_code", value); } }
        public object inv_cod_when_zero { get { return DofoxproRet("inv_cod_when_zero"); } set { SetVariable("inv_cod_when_zero", value); } }
        public object invxml { get { return DofoxproRet("invxml"); } set { SetVariable("invxml", value); } }
        public object invxmldir { get { return DofoxproRet("invxmldir"); } set { SetVariable("invxmldir", value); } }
        public object is_synchro_central { get { return DofoxproRet("is_synchro_central"); } set { SetVariable("is_synchro_central", value); } }
        public object is_synchro_client { get { return DofoxproRet("is_synchro_client"); } set { SetVariable("is_synchro_client", value); } }
        public object language { get { return DofoxproRet("language"); } set { SetVariable("language", value); } }
        public int lbackcolor { get { return ReturnInt("lbackcolor"); } set { SetVariable("lbackcolor", value, 'N'); } }
        public int ldisabledbackcolor { get { return ReturnInt("ldisabledbackcolor"); } set { SetVariable("ldisabledbackcolor", value, 'N'); } }
        public int ldisabledforecolor { get { return ReturnInt("ldisabledforecolor"); } set { SetVariable("ldisabledforecolor", value, 'N'); } }
        public int lforecolor { get { return ReturnInt("lforecolor"); } set { SetVariable("lforecolor", value, 'N'); } }
        public int lic_users { get { return ReturnInt("lic_users"); } set { SetVariable("lic_users", value, 'N'); } }
        public object lic_users_control { get { return DofoxproRet("lic_users_control"); } set { SetVariable("lic_users_control", value); } }
        public object licence { get { return DofoxproRet("licence"); } set { SetVariable("licence", value); } }
        public object lineout { get { return DofoxproRet("lineout"); } set { SetVariable("lineout", value); } }
        public bool Lloginop { get { return ReturnBool("lloginop"); } set { SetVariable("lloginop", value, 'L'); } }
        public bool log_user { get { return ReturnBool("log_user"); } set { SetVariable("log_user", value, 'L'); } }
        public object loginscreen { get { return DofoxproRet("loginscreen"); } set { SetVariable("loginscreen", value, 'O'); } }
        public object lpstongst { get { return DofoxproRet("lpstongst"); } set { SetVariable("lpstongst", value); } }
        public object lshortcutmenu { get { return DofoxproRet("lshortcutmenu"); } set { SetVariable("lshortcutmenu", value); } }
        public object mail_attached { get { return DofoxproRet("mail_attached"); } set { SetVariable("mail_attached", value); } }
        public object mail_notes { get { return DofoxproRet("mail_notes"); } set { SetVariable("mail_notes", value); } }
        public object mail_subject { get { return DofoxproRet("mail_subject"); } set { SetVariable("mail_subject", value); } }
        public object mail_to { get { return DofoxproRet("mail_to"); } set { SetVariable("mail_to", value); } }
        public object mailport { get { return DofoxproRet("mailport"); } set { SetVariable("mailport", value); } }
        public object mailserver { get { return DofoxproRet("mailserver"); } set { SetVariable("mailserver", value); } }
        public object marge_est_glo { get { return DofoxproRet("marge_est_glo"); } set { SetVariable("marge_est_glo", value); } }
        public object multi_agent { get { return DofoxproRet("multi_agent"); } set { SetVariable("multi_agent", value); } }
        public object nb_cur_user { get { return DofoxproRet("nb_cur_user"); } set { SetVariable("nb_cur_user", value); } }
        public int nb_new_mesg { get { return ReturnInt("nb_new_mesg"); } set { SetVariable("nb_new_mesg", value, 'N'); } }
        public object nb_per_aux { get { return DofoxproRet("nb_per_aux"); } set { SetVariable("nb_per_aux", value); } }
        public object nb_per_gl { get { return DofoxproRet("nb_per_gl"); } set { SetVariable("nb_per_gl", value); } }
        public object news_run { get { return DofoxproRet("news_run"); } set { SetVariable("news_run", value); } }
        public object news_startup_page { get { return DofoxproRet("news_startup_page"); } set { SetVariable("news_startup_page", value); } }
        public object newsform { get { return DofoxproRet("newsform"); } set { SetVariable("newsform", value); } }
        public object nobracelet { get { return DofoxproRet("nobracelet"); } set { SetVariable("nobracelet", value); } }
        public object nocaisse { get { return DofoxproRet("nocaisse"); } set { SetVariable("nocaisse", value); } }
        public object nocheckcredit { get { return DofoxproRet("nocheckcredit"); } set { SetVariable("nocheckcredit", value); } }
        public object nogl_ap { get { return DofoxproRet("nogl_ap"); } set { SetVariable("nogl_ap", value); } }
        public object nogl_ap_disc { get { return DofoxproRet("nogl_ap_disc"); } set { SetVariable("nogl_ap_disc", value); } }
        public object nogl_ap_re { get { return DofoxproRet("nogl_ap_re"); } set { SetVariable("nogl_ap_re", value); } }
        public object nogl_ar { get { return DofoxproRet("nogl_ar"); } set { SetVariable("nogl_ar", value); } }
        public object nogl_ar_disc { get { return DofoxproRet("nogl_ar_disc"); } set { SetVariable("nogl_ar_disc", value); } }
        public object nogl_bnr { get { return DofoxproRet("nogl_bnr"); } set { SetVariable("nogl_bnr", value); } }
        public object nogl_bq { get { return DofoxproRet("nogl_bq"); } set { SetVariable("nogl_bq", value); } }
        public object nogl_bq_re { get { return DofoxproRet("nogl_bq_re"); } set { SetVariable("nogl_bq_re", value); } }
        public object nogl_contra { get { return DofoxproRet("nogl_contra"); } set { SetVariable("nogl_contra", value); } }
        public object nogl_error { get { return DofoxproRet("nogl_error"); } set { SetVariable("nogl_error", value); } }
        public object nogl_tps_ach { get { return DofoxproRet("nogl_tps_ach"); } set { SetVariable("nogl_tps_ach", value); } }
        public object nogl_tps_vte { get { return DofoxproRet("nogl_tps_vte"); } set { SetVariable("nogl_tps_vte", value); } }
        public object nogl_tvh_ach { get { return DofoxproRet("nogl_tvh_ach"); } set { SetVariable("nogl_tvh_ach", value); } }
        public object nogl_tvh_vte { get { return DofoxproRet("nogl_tvh_vte"); } set { SetVariable("nogl_tvh_vte", value); } }
        public object nogl_tvq_ach { get { return DofoxproRet("nogl_tvq_ach"); } set { SetVariable("nogl_tvq_ach", value); } }
        public object nogl_tvq_vte { get { return DofoxproRet("nogl_tvq_vte"); } set { SetVariable("nogl_tvq_vte", value); } }
        public object notps { get { return DofoxproRet("notps"); } set { SetVariable("notps", value); } }
        public object notvq { get { return DofoxproRet("notvq"); } set { SetVariable("notvq", value); } }
        public object office_no { get { return DofoxproRet("office_no"); } set { SetVariable("office_no", value); } }
        public object on_error_quit { get { return DofoxproRet("on_error_quit"); } set { SetVariable("on_error_quit", value); } }
        public bool opened { get { return ReturnBool("opened"); } set { SetVariable("opened", value, 'L'); } }
        public object owinfax { get { return DofoxproRet("owinfax"); } set { SetVariable("owinfax", value); } }
        public object pdfmessage { get { return DofoxproRet("pdfmessage"); } set { SetVariable("pdfmessage", value); } }
        public object period1 { get { return DofoxproRet("period1"); } set { SetVariable("period1", value); } }
        public object phoneint { get { return DofoxproRet("phoneint"); } set { SetVariable("phoneint", value); } }
        public object prix_est_do { get { return DofoxproRet("prix_est_do"); } set { SetVariable("prix_est_do", value); } }
        public object proxyhttpconnecttype { get { return DofoxproRet("proxyhttpconnecttype"); } set { SetVariable("proxyhttpconnecttype", value); } }
        public object proxyname { get { return DofoxproRet("proxyname"); } set { SetVariable("proxyname", value); } }
        public object proxypass { get { return DofoxproRet("proxypass"); } set { SetVariable("proxypass", value); } }
        public object proxyuser { get { return DofoxproRet("proxyuser"); } set { SetVariable("proxyuser", value); } }
        public object pst_rate { get { return DofoxproRet("pst_rate"); } set { SetVariable("pst_rate", value); } }
        public object region { get { return DofoxproRet("region"); } set { SetVariable("region", value); } }
        public object rep_inv { get { return DofoxproRet("rep_inv"); } set { SetVariable("rep_inv", value); } }
        public object running_terminal_server { get { return DofoxproRet("running_terminal_server"); } set { SetVariable("running_terminal_server", value); } }
        public object search_ret_param1 { get { return DofoxproRet("search_ret_param1"); } set { SetVariable("search_ret_param1", value); } }
        public object searchid { get { return DofoxproRet("searchid"); } set { SetVariable("searchid", value); } }
        public object sendmailsync { get { return DofoxproRet("sendmailsync"); } set { SetVariable("sendmailsync", value); } }
        public int sessionid { get { return ReturnInt("sessionid"); } set { SetVariable("sessionid", value, 'N'); } }
        public object shipmentnostyle { get { return DofoxproRet("shipmentnostyle"); } set { SetVariable("shipmentnostyle", value); } }
        public object shortcutmenu { get { return DofoxproRet("shortcutmenu"); } set { SetVariable("shortcutmenu", value); } }
        public object show_op_msg { get { return DofoxproRet("show_op_msg"); } set { SetVariable("show_op_msg", value); } }
        public object shutdown_count { get { return DofoxproRet("shutdown_count"); } set { SetVariable("shutdown_count", value); } }
        public object spicture { get { return DofoxproRet("spicture"); } set { SetVariable("spicture", value); } }
        public object tactisoft { get { return DofoxproRet("tactisoft"); } set { SetVariable("tactisoft", value); } }
        public object tmppath { get { return DofoxproRet("tmppath"); } set { SetVariable("tmppath", value); } }
        public object tvh_rate { get { return DofoxproRet("tvh_rate"); } set { SetVariable("tvh_rate", value); } }
        public object usdcad { get { return DofoxproRet("usdcad"); } set { SetVariable("usdcad", value); } }
        public object use { get { return DofoxproRet("use"); } set { SetVariable("use", value); } }
        public object use_longd { get { return DofoxproRet("use_longd"); } set { SetVariable("use_longd", value); } }
        public object use_office { get { return DofoxproRet("use_office"); } set { SetVariable("use_office", value); } }
        public object use_po { get { return DofoxproRet("use_po"); } set { SetVariable("use_po", value); } }
        public object userarrep { get { return DofoxproRet("userarrep"); } set { SetVariable("userarrep", value); } }
        public object userbasket { get { return DofoxproRet("userbasket"); } set { SetVariable("userbasket", value); } }
        public object usercanmodclientaccntg { get { return DofoxproRet("usercanmodclientaccntg"); } set { SetVariable("usercanmodclientaccntg", value); } }
        public object usercie { get { return DofoxproRet("usercie"); } set { SetVariable("usercie", value); } }
        public string usercode { get { return ReturnStr("usercode"); } set { SetVariable("usercode", value); } }
        public object useremail { get { return DofoxproRet("useremail"); } set { SetVariable("useremail", value); } }
        public object useremail2 { get { return DofoxproRet("useremail2"); } set { SetVariable("useremail2", value); } }
        public object useremailsignature { get { return DofoxproRet("useremailsignature"); } set { SetVariable("useremailsignature", value); } }
        public object usergroup { get { return DofoxproRet("usergroup"); } set { SetVariable("usergroup", value); } }
        public object username { get { return DofoxproRet("username"); } set { SetVariable("username", value); } }
        public object userphone { get { return DofoxproRet("userphone"); } set { SetVariable("userphone", value); } }
        public object usertimer { get { return DofoxproRet("usertimer"); } set { SetVariable("usertimer", value); } }
        public object usertitle { get { return DofoxproRet("usertitle"); } set { SetVariable("usertitle", value); } }
        public object usertype { get { return DofoxproRet("usertype"); } set { SetVariable("usertype", value); } }
        public object vabandon { get { return DofoxproRet("vabandon"); } set { SetVariable("vabandon", value); } }
        public object valid_accnt { get { return DofoxproRet("valid_accnt"); } set { SetVariable("valid_accnt", value); } }
        public object verif_crlimit_lastid { get { return DofoxproRet("verif_crlimit_lastid"); } set { SetVariable("verif_crlimit_lastid", value); } }
        public object vers_country { get { return DofoxproRet("vers_country"); } set { SetVariable("vers_country", value); } }
        public object wbackcolor { get { return DofoxproRet("wbackcolor"); } set { SetVariable("wbackcolor", value, 'N'); } }
        public object webpage { get { return DofoxproRet("webpage"); } set { SetVariable("webpage", value); } }
        public object wforecolor { get { return DofoxproRet("wforecolor"); } set { SetVariable("wforecolor", value, 'N'); } }
        public object wich_email { get { return DofoxproRet("wich_email"); } set { SetVariable("wich_email", value); } }
        public object wich_fax { get { return DofoxproRet("wich_fax"); } set { SetVariable("wich_fax", value); } }
        public object winfreight { get { return DofoxproRet("winfreight"); } set { SetVariable("winfreight", value); } }
        public object wpicture { get { return DofoxproRet("wpicture"); } set { SetVariable("wpicture", value); } }
        public object wscustom { get { return DofoxproRet("wscustom"); } set { SetVariable("wscustom", value); } }
        public object wsmenu_nb { get { return DofoxproRet("wsmenu_nb"); } set { SetVariable("wsmenu_nb", value); } }
        public object wsnewsdir { get { return DofoxproRet("wsnewsdir"); } set { SetVariable("wsnewsdir", value); } }
        public object wssession_table { get { return DofoxproRet("wssession_table"); } set { SetVariable("wssession_table", value); } }
        public object zart { get { return DofoxproRet("zart"); } set { SetVariable("zart", value); } }
        public object zebra { get { return DofoxproRet("zebra"); } set { SetVariable("zebra", value); } }
        public object zebra_active { get { return DofoxproRet("zebra_active"); } set { SetVariable("zebra_active", value); } }
        public object zebra_contrat_auto { get { return DofoxproRet("zebra_contrat_auto"); } set { SetVariable("zebra_contrat_auto", value); } }

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
        public object[] jourtxt { get; set; }
        public object[] moistxt { get; set; }
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
            jourtxt = new object[7];
            moistxt = new object[12];
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

        public int ReturnInt(string value)
        {
            RetInt = 0;
            DofoxproRetInt("xwssession." + value);  //Ex : xwssession.wsname

            // var wssession = new WsSession();
            // var subscriber = new EventSubscriber(xwssession2);
            Task.Delay(1).ContinueWith(t => wssession5.DofoxproRetInt(""));
            var result = subscriber5.WaitForEvent();
            // subscriber.Dispose();
            return RetInt;
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

        public void After()
        {
            _DidFoxproFinish = true;
        }

        //*********************************Méthode du wsswssion*********************************//
        public object Cdate(DateTime pDate, bool p0frch = false, bool pJourTxt = false)
        {
            //string cDate = "";
            //string cDay;

            //if (pDate == null)
            //{
            //    return cDate;
            //}

            //if (p0frch)
            //{
            //    if (pJourTxt)
            //    {
            //        cDate = FirstCharToUpper(pDate.ToString("dddd")) + " le " + (pDate.Day.ToString() == "1" ? "1er" : pDate.Day.ToString().Trim()) + " " + FirstCharToUpper(pDate.ToString("MMMM")) + " " + pDate.Year;
            //    }
            //    else
            //    {
            //        cDate = pDate.Day.ToString() == "1" ? "1er" : pDate.Day + " " + FirstCharToUpper(pDate.ToString("MMMM")) + " " + pDate.Year;
            //    }
            //}
            //else
            //{

            //    if (pDate.Day.ToString() == "1" || pDate.Day.ToString() == "21" || pDate.Day.ToString() == "31")
            //    {
            //        cDay = " " + pDate.Day.ToString().Trim() + "st ";
            //    }
            //    else if (pDate.Day.ToString() == "2" || pDate.Day.ToString() == "22")
            //    {
            //        cDay = " " + pDate.Day.ToString().Trim() + "nd ";
            //    }
            //    else if (pDate.Day.ToString() == "3" || pDate.Day.ToString() == "23")
            //    {
            //        cDay = " " + pDate.Day.ToString().Trim() + "rd ";
            //    }
            //    else
            //    {
            //        cDay = " " + pDate.Day.ToString().Trim() + "th ";
            //    }

            //    if (pJourTxt)
            //    {
            //        cDate = pDate.DayOfWeek + " " + pDate.ToString("MMMM", CultureInfo.GetCultureInfo("en-US")) + cDay + pDate.Year.ToString();
            //    }
            //    else
            //    {
            //        cDate = pDate.ToString("MMMM", CultureInfo.GetCultureInfo("en-US")) + cDay + pDate.Year.ToString();
            //    }
            //}

            //return cDate;

            DofoxproRet("cdate(" + FoxDate(pDate) + ", " + FoxBool(p0frch) + ", " + FoxBool(pJourTxt) + ")");
            return Retval;
        }

        public async Task Chariot()
        {
            _DidFoxproFinish = false;

            ExecFoxpro("chariot()");
            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
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

        public async Task refresh_param(string lWorkPer)
        {
            _DidFoxproFinish = false;

            ExecFoxpro("refresh_param(" + StrToFoxBool(lWorkPer) + ")");

            do
            {
                await Task.Delay(5);

            } while (_DidFoxproFinish == false);
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
