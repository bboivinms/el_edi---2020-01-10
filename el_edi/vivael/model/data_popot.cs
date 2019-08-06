using System;

namespace vivael
{
	public class data_popot : DataSource
	{
		public data_popot() { Table_name = i.name = "popot"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Status; public string Status { get { return _Status; } set { Set(ref _Status, value, "Status"); } }
		private int? _Idvendor; public int? Idvendor { get { return _Idvendor; } set { Set(ref _Idvendor, value, "Idvendor"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private string _Vend_Name; public string Vend_Name { get { return _Vend_Name; } set { Set(ref _Vend_Name, value, "Vend_Name"); } }
		private string _Vend_Add; public string Vend_Add { get { return _Vend_Add; } set { Set(ref _Vend_Add, value, "Vend_Add"); } }
		private string _Del_Name; public string Del_Name { get { return _Del_Name; } set { Set(ref _Del_Name, value, "Del_Name"); } }
		private string _Del_Add; public string Del_Add { get { return _Del_Add; } set { Set(ref _Del_Add, value, "Del_Add"); } }
		private string _Ram_Name; public string Ram_Name { get { return _Ram_Name; } set { Set(ref _Ram_Name, value, "Ram_Name"); } }
		private string _Ram_Add; public string Ram_Add { get { return _Ram_Add; } set { Set(ref _Ram_Add, value, "Ram_Add"); } }
		private DateTime? _Po_Dte; public DateTime? Po_Dte { get { return _Po_Dte; } set { Set(ref _Po_Dte, value, "Po_Dte"); } }
		private DateTime? _Requ_Dte; public DateTime? Requ_Dte { get { return _Requ_Dte; } set { Set(ref _Requ_Dte, value, "Requ_Dte"); } }
		private DateTime? _Expe_Dte; public DateTime? Expe_Dte { get { return _Expe_Dte; } set { Set(ref _Expe_Dte, value, "Expe_Dte"); } }
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
		private DateTime? _Etd; public DateTime? Etd { get { return _Etd; } set { Set(ref _Etd, value, "Etd"); } }
		private DateTime? _Eta; public DateTime? Eta { get { return _Eta; } set { Set(ref _Eta, value, "Eta"); } }
		private DateTime? _Arr_Dt; public DateTime? Arr_Dt { get { return _Arr_Dt; } set { Set(ref _Arr_Dt, value, "Arr_Dt"); } }
		private byte? _Trp_Mode; public byte? Trp_Mode { get { return _Trp_Mode; } set { Set(ref _Trp_Mode, value, "Trp_Mode"); } }
		private string _Trp_Ref; public string Trp_Ref { get { return _Trp_Ref; } set { Set(ref _Trp_Ref, value, "Trp_Ref"); } }
		private string _Trp_Cont; public string Trp_Cont { get { return _Trp_Cont; } set { Set(ref _Trp_Cont, value, "Trp_Cont"); } }
		private string _Cust_Brk; public string Cust_Brk { get { return _Cust_Brk; } set { Set(ref _Cust_Brk, value, "Cust_Brk"); } }
		private decimal? _Cus_Mnt; public decimal? Cus_Mnt { get { return _Cus_Mnt; } set { Set(ref _Cus_Mnt, value, "Cus_Mnt"); } }
		private string _Cus_Mnt_Cur; public string Cus_Mnt_Cur { get { return _Cus_Mnt_Cur; } set { Set(ref _Cus_Mnt_Cur, value, "Cus_Mnt_Cur"); } }
		private decimal? _Cus_Curr_Rate; public decimal? Cus_Curr_Rate { get { return _Cus_Curr_Rate; } set { Set(ref _Cus_Curr_Rate, value, "Cus_Curr_Rate"); } }
		private string _Cust_Det; public string Cust_Det { get { return _Cust_Det; } set { Set(ref _Cust_Det, value, "Cust_Det"); } }
		private string _Prt_Note; public string Prt_Note { get { return _Prt_Note; } set { Set(ref _Prt_Note, value, "Prt_Note"); } }
		private string _Pocode; public string Pocode { get { return _Pocode; } set { Set(ref _Pocode, value, "Pocode"); } }
		private int? _Pono; public int? Pono { get { return _Pono; } set { Set(ref _Pono, value, "Pono"); } }
		private string _Signature; public string Signature { get { return _Signature; } set { Set(ref _Signature, value, "Signature"); } }
		private string _Clientpo; public string Clientpo { get { return _Clientpo; } set { Set(ref _Clientpo, value, "Clientpo"); } }
		private string _Contact; public string Contact { get { return _Contact; } set { Set(ref _Contact, value, "Contact"); } }
		private string _Contactfax; public string Contactfax { get { return _Contactfax; } set { Set(ref _Contactfax, value, "Contactfax"); } }
		private string _Contactemail; public string Contactemail { get { return _Contactemail; } set { Set(ref _Contactemail, value, "Contactemail"); } }
		private string _Ref_Fourn; public string Ref_Fourn { get { return _Ref_Fourn; } set { Set(ref _Ref_Fourn, value, "Ref_Fourn"); } }
		private bool? _Dte_Aprv; public bool? Dte_Aprv { get { return _Dte_Aprv; } set { Set(ref _Dte_Aprv, value, "Dte_Aprv"); } }
		private bool? _Prix_Conf; public bool? Prix_Conf { get { return _Prix_Conf; } set { Set(ref _Prix_Conf, value, "Prix_Conf"); } }
		private string _Num_Conf; public string Num_Conf { get { return _Num_Conf; } set { Set(ref _Num_Conf, value, "Num_Conf"); } }
		private string _Rec_Note; public string Rec_Note { get { return _Rec_Note; } set { Set(ref _Rec_Note, value, "Rec_Note"); } }
		private string _Pret_Note; public string Pret_Note { get { return _Pret_Note; } set { Set(ref _Pret_Note, value, "Pret_Note"); } }
		private bool? _Conf_Pret; public bool? Conf_Pret { get { return _Conf_Pret; } set { Set(ref _Conf_Pret, value, "Conf_Pret"); } }
		private DateTime? _Pret_Dte; public DateTime? Pret_Dte { get { return _Pret_Dte; } set { Set(ref _Pret_Dte, value, "Pret_Dte"); } }
		private bool? _Dem_Conf; public bool? Dem_Conf { get { return _Dem_Conf; } set { Set(ref _Dem_Conf, value, "Dem_Conf"); } }
		private int? _Idco; public int? Idco { get { return _Idco; } set { Set(ref _Idco, value, "Idco"); } }
		private bool? _Toute_Inve; public bool? Toute_Inve { get { return _Toute_Inve; } set { Set(ref _Toute_Inve, value, "Toute_Inve"); } }
		private bool? _Livrer_Sur_Recept; public bool? Livrer_Sur_Recept { get { return _Livrer_Sur_Recept; } set { Set(ref _Livrer_Sur_Recept, value, "Livrer_Sur_Recept"); } }
		private int? _Idtax; public int? Idtax { get { return _Idtax; } set { Set(ref _Idtax, value, "Idtax"); } }
		private decimal? _Gst_Rate; public decimal? Gst_Rate { get { return _Gst_Rate; } set { Set(ref _Gst_Rate, value, "Gst_Rate"); } }
		private decimal? _Pst_Rate; public decimal? Pst_Rate { get { return _Pst_Rate; } set { Set(ref _Pst_Rate, value, "Pst_Rate"); } }
		private decimal? _Hst_Rate; public decimal? Hst_Rate { get { return _Hst_Rate; } set { Set(ref _Hst_Rate, value, "Hst_Rate"); } }
		private bool? _Lpstongst; public bool? Lpstongst { get { return _Lpstongst; } set { Set(ref _Lpstongst, value, "Lpstongst"); } }
		private int? _Po_C_Hino; public int? Po_C_Hino { get { return _Po_C_Hino; } set { Set(ref _Po_C_Hino, value, "Po_C_Hino"); } }
		private int? _Po_C_206; public int? Po_C_206 { get { return _Po_C_206; } set { Set(ref _Po_C_206, value, "Po_C_206"); } }
		private int? _Po_C_503; public int? Po_C_503 { get { return _Po_C_503; } set { Set(ref _Po_C_503, value, "Po_C_503"); } }
		private bool? _Zhino; public bool? Zhino { get { return _Zhino; } set { Set(ref _Zhino, value, "Zhino"); } }
		private bool? _Z206; public bool? Z206 { get { return _Z206; } set { Set(ref _Z206, value, "Z206"); } }
		private bool? _Z503; public bool? Z503 { get { return _Z503; } set { Set(ref _Z503, value, "Z503"); } }
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
		private string _Raddr1; public string Raddr1 { get { return _Raddr1; } set { Set(ref _Raddr1, value, "Raddr1"); } }
		private string _Raddr2; public string Raddr2 { get { return _Raddr2; } set { Set(ref _Raddr2, value, "Raddr2"); } }
		private string _Rcity; public string Rcity { get { return _Rcity; } set { Set(ref _Rcity, value, "Rcity"); } }
		private string _Rstate; public string Rstate { get { return _Rstate; } set { Set(ref _Rstate, value, "Rstate"); } }
		private string _Rzip; public string Rzip { get { return _Rzip; } set { Set(ref _Rzip, value, "Rzip"); } }
		private string _Rcountry; public string Rcountry { get { return _Rcountry; } set { Set(ref _Rcountry, value, "Rcountry"); } }
		private bool? _Carte; public bool? Carte { get { return _Carte; } set { Set(ref _Carte, value, "Carte"); } }
		private string _Nomcarte; public string Nomcarte { get { return _Nomcarte; } set { Set(ref _Nomcarte, value, "Nomcarte"); } }
		private bool? _Echantillo; public bool? Echantillo { get { return _Echantillo; } set { Set(ref _Echantillo, value, "Echantillo"); } }
		private bool? _Cheque; public bool? Cheque { get { return _Cheque; } set { Set(ref _Cheque, value, "Cheque"); } }
		private bool? _Cheqterme; public bool? Cheqterme { get { return _Cheqterme; } set { Set(ref _Cheqterme, value, "Cheqterme"); } }
		private bool? _Surcharge; public bool? Surcharge { get { return _Surcharge; } set { Set(ref _Surcharge, value, "Surcharge"); } }
		private decimal? _Stot; public decimal? Stot { get { return _Stot; } set { Set(ref _Stot, value, "Stot"); } }

	}
}