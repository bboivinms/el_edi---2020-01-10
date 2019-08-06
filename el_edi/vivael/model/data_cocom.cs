using System;

namespace vivael
{
	public class data_cocom : DataSource
	{
		public data_cocom() { Table_name = i.name = "cocom"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Status; public string Status { get { return _Status; } set { Set(ref _Status, value, "Status"); } }
		private int? _Clientid; public int? Clientid { get { return _Clientid; } set { Set(ref _Clientid, value, "Clientid"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private string _Client_Name; public string Client_Name { get { return _Client_Name; } set { Set(ref _Client_Name, value, "Client_Name"); } }
		private string _Client_Add; public string Client_Add { get { return _Client_Add; } set { Set(ref _Client_Add, value, "Client_Add"); } }
		private string _Del_Name; public string Del_Name { get { return _Del_Name; } set { Set(ref _Del_Name, value, "Del_Name"); } }
		private string _Del_Add; public string Del_Add { get { return _Del_Add; } set { Set(ref _Del_Add, value, "Del_Add"); } }
		private DateTime? _Co_Dte; public DateTime? Co_Dte { get { return _Co_Dte; } set { Set(ref _Co_Dte, value, "Co_Dte"); } }
		private DateTime? _Promis_Dte; public DateTime? Promis_Dte { get { return _Promis_Dte; } set { Set(ref _Promis_Dte, value, "Promis_Dte"); } }
		private int? _Trp_Id; public int? Trp_Id { get { return _Trp_Id; } set { Set(ref _Trp_Id, value, "Trp_Id"); } }
		private decimal? _Trp_Mnt; public decimal? Trp_Mnt { get { return _Trp_Mnt; } set { Set(ref _Trp_Mnt, value, "Trp_Mnt"); } }
		private string _Trp_Mnt_Cur; public string Trp_Mnt_Cur { get { return _Trp_Mnt_Cur; } set { Set(ref _Trp_Mnt_Cur, value, "Trp_Mnt_Cur"); } }
		private decimal? _Trp_Curr_Rate; public decimal? Trp_Curr_Rate { get { return _Trp_Curr_Rate; } set { Set(ref _Trp_Curr_Rate, value, "Trp_Curr_Rate"); } }
		private string _Trp_Notes; public string Trp_Notes { get { return _Trp_Notes; } set { Set(ref _Trp_Notes, value, "Trp_Notes"); } }
		private string _Trp_Track; public string Trp_Track { get { return _Trp_Track; } set { Set(ref _Trp_Track, value, "Trp_Track"); } }
		private string _Trp_Conditions; public string Trp_Conditions { get { return _Trp_Conditions; } set { Set(ref _Trp_Conditions, value, "Trp_Conditions"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private decimal? _Curr_Rate; public decimal? Curr_Rate { get { return _Curr_Rate; } set { Set(ref _Curr_Rate, value, "Curr_Rate"); } }
		private int? _Nb_Print; public int? Nb_Print { get { return _Nb_Print; } set { Set(ref _Nb_Print, value, "Nb_Print"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dtet; public DateTime? Cr_Dtet { get { return _Cr_Dtet; } set { Set(ref _Cr_Dtet, value, "Cr_Dtet"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dtet; public DateTime? Mod_Dtet { get { return _Mod_Dtet; } set { Set(ref _Mod_Dtet, value, "Mod_Dtet"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private int? _Idwarh; public int? Idwarh { get { return _Idwarh; } set { Set(ref _Idwarh, value, "Idwarh"); } }
		private string _Clientpo; public string Clientpo { get { return _Clientpo; } set { Set(ref _Clientpo, value, "Clientpo"); } }
		private DateTime? _Req_Dte; public DateTime? Req_Dte { get { return _Req_Dte; } set { Set(ref _Req_Dte, value, "Req_Dte"); } }
		private string _Termes; public string Termes { get { return _Termes; } set { Set(ref _Termes, value, "Termes"); } }
		private string _Surplus; public string Surplus { get { return _Surplus; } set { Set(ref _Surplus, value, "Surplus"); } }
		private string _Cond_Entr; public string Cond_Entr { get { return _Cond_Entr; } set { Set(ref _Cond_Entr, value, "Cond_Entr"); } }
		private string _Transport; public string Transport { get { return _Transport; } set { Set(ref _Transport, value, "Transport"); } }
		private string _Contact; public string Contact { get { return _Contact; } set { Set(ref _Contact, value, "Contact"); } }
		private string _Contactfax; public string Contactfax { get { return _Contactfax; } set { Set(ref _Contactfax, value, "Contactfax"); } }
		private string _Contactemail; public string Contactemail { get { return _Contactemail; } set { Set(ref _Contactemail, value, "Contactemail"); } }
		private string _Notes_Int; public string Notes_Int { get { return _Notes_Int; } set { Set(ref _Notes_Int, value, "Notes_Int"); } }
		private bool? _Dte_Liv_Conf; public bool? Dte_Liv_Conf { get { return _Dte_Liv_Conf; } set { Set(ref _Dte_Liv_Conf, value, "Dte_Liv_Conf"); } }
		private bool? _Prix_Conf; public bool? Prix_Conf { get { return _Prix_Conf; } set { Set(ref _Prix_Conf, value, "Prix_Conf"); } }
		private bool? _Non_Recue_Client; public bool? Non_Recue_Client { get { return _Non_Recue_Client; } set { Set(ref _Non_Recue_Client, value, "Non_Recue_Client"); } }
		private bool? _Dte_Importante; public bool? Dte_Importante { get { return _Dte_Importante; } set { Set(ref _Dte_Importante, value, "Dte_Importante"); } }
		private int? _Popoid; public int? Popoid { get { return _Popoid; } set { Set(ref _Popoid, value, "Popoid"); } }
		private int? _Popoid2; public int? Popoid2 { get { return _Popoid2; } set { Set(ref _Popoid2, value, "Popoid2"); } }
		private int? _Popoid3; public int? Popoid3 { get { return _Popoid3; } set { Set(ref _Popoid3, value, "Popoid3"); } }
		private int? _Popoid4; public int? Popoid4 { get { return _Popoid4; } set { Set(ref _Popoid4, value, "Popoid4"); } }
		private int? _Popoid5; public int? Popoid5 { get { return _Popoid5; } set { Set(ref _Popoid5, value, "Popoid5"); } }
		private int? _Popoid6; public int? Popoid6 { get { return _Popoid6; } set { Set(ref _Popoid6, value, "Popoid6"); } }
		private int? _Popoid7; public int? Popoid7 { get { return _Popoid7; } set { Set(ref _Popoid7, value, "Popoid7"); } }
		private int? _Popoid8; public int? Popoid8 { get { return _Popoid8; } set { Set(ref _Popoid8, value, "Popoid8"); } }
		private int? _Popoid9; public int? Popoid9 { get { return _Popoid9; } set { Set(ref _Popoid9, value, "Popoid9"); } }
		private int? _Popoid10; public int? Popoid10 { get { return _Popoid10; } set { Set(ref _Popoid10, value, "Popoid10"); } }
		private int? _Idtax; public int? Idtax { get { return _Idtax; } set { Set(ref _Idtax, value, "Idtax"); } }
		private decimal? _Gst_Rate; public decimal? Gst_Rate { get { return _Gst_Rate; } set { Set(ref _Gst_Rate, value, "Gst_Rate"); } }
		private decimal? _Pst_Rate; public decimal? Pst_Rate { get { return _Pst_Rate; } set { Set(ref _Pst_Rate, value, "Pst_Rate"); } }
		private decimal? _Hst_Rate; public decimal? Hst_Rate { get { return _Hst_Rate; } set { Set(ref _Hst_Rate, value, "Hst_Rate"); } }
		private bool? _Lpstongst; public bool? Lpstongst { get { return _Lpstongst; } set { Set(ref _Lpstongst, value, "Lpstongst"); } }
		private bool? _Attente; public bool? Attente { get { return _Attente; } set { Set(ref _Attente, value, "Attente"); } }
		private string _Attente_Txt; public string Attente_Txt { get { return _Attente_Txt; } set { Set(ref _Attente_Txt, value, "Attente_Txt"); } }
		private bool? _Exclure_Du_Dash; public bool? Exclure_Du_Dash { get { return _Exclure_Du_Dash; } set { Set(ref _Exclure_Du_Dash, value, "Exclure_Du_Dash"); } }
		private bool? _Rec_Env; public bool? Rec_Env { get { return _Rec_Env; } set { Set(ref _Rec_Env, value, "Rec_Env"); } }
		private string _Paddr1; public string Paddr1 { get { return _Paddr1; } set { Set(ref _Paddr1, value, "Paddr1"); } }
		private string _Paddr2; public string Paddr2 { get { return _Paddr2; } set { Set(ref _Paddr2, value, "Paddr2"); } }
		private string _Pcity; public string Pcity { get { return _Pcity; } set { Set(ref _Pcity, value, "Pcity"); } }
		private string _Pstate; public string Pstate { get { return _Pstate; } set { Set(ref _Pstate, value, "Pstate"); } }
		private string _Pzip; public string Pzip { get { return _Pzip; } set { Set(ref _Pzip, value, "Pzip"); } }
		private string _Pcountry; public string Pcountry { get { return _Pcountry; } set { Set(ref _Pcountry, value, "Pcountry"); } }
		private string _Daddr1; public string Daddr1 { get { return _Daddr1; } set { Set(ref _Daddr1, value, "Daddr1"); } }
		private string _Daddr2; public string Daddr2 { get { return _Daddr2; } set { Set(ref _Daddr2, value, "Daddr2"); } }
		private string _Dcity; public string Dcity { get { return _Dcity; } set { Set(ref _Dcity, value, "Dcity"); } }
		private string _Dstate; public string Dstate { get { return _Dstate; } set { Set(ref _Dstate, value, "Dstate"); } }
		private string _Dzip; public string Dzip { get { return _Dzip; } set { Set(ref _Dzip, value, "Dzip"); } }
		private string _Dcountry; public string Dcountry { get { return _Dcountry; } set { Set(ref _Dcountry, value, "Dcountry"); } }
		private int? _Invno; public int? Invno { get { return _Invno; } set { Set(ref _Invno, value, "Invno"); } }
		private short? _Nblivmax; public short? Nblivmax { get { return _Nblivmax; } set { Set(ref _Nblivmax, value, "Nblivmax"); } }
		private int? _Prodid1; public int? Prodid1 { get { return _Prodid1; } set { Set(ref _Prodid1, value, "Prodid1"); } }
		private int? _Prodid2; public int? Prodid2 { get { return _Prodid2; } set { Set(ref _Prodid2, value, "Prodid2"); } }
		private int? _Prodid3; public int? Prodid3 { get { return _Prodid3; } set { Set(ref _Prodid3, value, "Prodid3"); } }
		private int? _Prodid4; public int? Prodid4 { get { return _Prodid4; } set { Set(ref _Prodid4, value, "Prodid4"); } }
		private int? _Prodid5; public int? Prodid5 { get { return _Prodid5; } set { Set(ref _Prodid5, value, "Prodid5"); } }
		private int? _Prodid6; public int? Prodid6 { get { return _Prodid6; } set { Set(ref _Prodid6, value, "Prodid6"); } }
		private int? _Prodid7; public int? Prodid7 { get { return _Prodid7; } set { Set(ref _Prodid7, value, "Prodid7"); } }
		private int? _Prodid8; public int? Prodid8 { get { return _Prodid8; } set { Set(ref _Prodid8, value, "Prodid8"); } }
		private int? _Prodid9; public int? Prodid9 { get { return _Prodid9; } set { Set(ref _Prodid9, value, "Prodid9"); } }
		private decimal? _Tpstaux; public decimal? Tpstaux { get { return _Tpstaux; } set { Set(ref _Tpstaux, value, "Tpstaux"); } }
		private decimal? _Tvqtaux; public decimal? Tvqtaux { get { return _Tvqtaux; } set { Set(ref _Tvqtaux, value, "Tvqtaux"); } }
		private decimal? _Tvhtaux; public decimal? Tvhtaux { get { return _Tvhtaux; } set { Set(ref _Tvhtaux, value, "Tvhtaux"); } }
		private string _Stweb; public string Stweb { get { return _Stweb; } set { Set(ref _Stweb, value, "Stweb"); } }
		private bool? _Blship; public bool? Blship { get { return _Blship; } set { Set(ref _Blship, value, "Blship"); } }

	}
}