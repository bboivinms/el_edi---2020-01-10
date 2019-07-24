using System;

namespace vivael
{
	public class data_cobil : DataSource
	{
		public data_cobil() { Table_name = i.name = "cobil"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Del_Name; public string Del_Name { get { return _Del_Name; } set { Set(ref _Del_Name, value, "Del_Name"); } }
		private string _Del_Add; public string Del_Add { get { return _Del_Add; } set { Set(ref _Del_Add, value, "Del_Add"); } }
		private DateTime? _Bil_Dte; public DateTime? Bil_Dte { get { return _Bil_Dte; } set { Set(ref _Bil_Dte, value, "Bil_Dte"); } }
		private int? _Trp_Id; public int? Trp_Id { get { return _Trp_Id; } set { Set(ref _Trp_Id, value, "Trp_Id"); } }
		private decimal? _Trp_Mnt; public decimal? Trp_Mnt { get { return _Trp_Mnt; } set { Set(ref _Trp_Mnt, value, "Trp_Mnt"); } }
		private string _Trp_Mnt_Cur; public string Trp_Mnt_Cur { get { return _Trp_Mnt_Cur; } set { Set(ref _Trp_Mnt_Cur, value, "Trp_Mnt_Cur"); } }
		private decimal? _Trp_Curr_Rate; public decimal? Trp_Curr_Rate { get { return _Trp_Curr_Rate; } set { Set(ref _Trp_Curr_Rate, value, "Trp_Curr_Rate"); } }
		private string _Trp_Notes; public string Trp_Notes { get { return _Trp_Notes; } set { Set(ref _Trp_Notes, value, "Trp_Notes"); } }
		private string _Trp_Conditions; public string Trp_Conditions { get { return _Trp_Conditions; } set { Set(ref _Trp_Conditions, value, "Trp_Conditions"); } }
		private int? _Nb_Print; public int? Nb_Print { get { return _Nb_Print; } set { Set(ref _Nb_Print, value, "Nb_Print"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dtet; public DateTime? Cr_Dtet { get { return _Cr_Dtet; } set { Set(ref _Cr_Dtet, value, "Cr_Dtet"); } }
		private int? _Idcom; public int? Idcom { get { return _Idcom; } set { Set(ref _Idcom, value, "Idcom"); } }
		private string _Ref; public string Ref { get { return _Ref; } set { Set(ref _Ref, value, "Ref"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private string _Clientpo; public string Clientpo { get { return _Clientpo; } set { Set(ref _Clientpo, value, "Clientpo"); } }
		private DateTime? _Req_Dte; public DateTime? Req_Dte { get { return _Req_Dte; } set { Set(ref _Req_Dte, value, "Req_Dte"); } }
		private bool? _Consign; public bool? Consign { get { return _Consign; } set { Set(ref _Consign, value, "Consign"); } }
		private int? _Clientid; public int? Clientid { get { return _Clientid; } set { Set(ref _Clientid, value, "Clientid"); } }
		private string _Client_Name; public string Client_Name { get { return _Client_Name; } set { Set(ref _Client_Name, value, "Client_Name"); } }
		private string _Client_Addr; public string Client_Addr { get { return _Client_Addr; } set { Set(ref _Client_Addr, value, "Client_Addr"); } }
		private int? _Pick_Idzone; public int? Pick_Idzone { get { return _Pick_Idzone; } set { Set(ref _Pick_Idzone, value, "Pick_Idzone"); } }
		private decimal? _Vol_Boites; public decimal? Vol_Boites { get { return _Vol_Boites; } set { Set(ref _Vol_Boites, value, "Vol_Boites"); } }
		private decimal? _Vol_Autres; public decimal? Vol_Autres { get { return _Vol_Autres; } set { Set(ref _Vol_Autres, value, "Vol_Autres"); } }
		private int? _Del_Idzone; public int? Del_Idzone { get { return _Del_Idzone; } set { Set(ref _Del_Idzone, value, "Del_Idzone"); } }
		private int? _Po_C_Hino; public int? Po_C_Hino { get { return _Po_C_Hino; } set { Set(ref _Po_C_Hino, value, "Po_C_Hino"); } }
		private int? _Po_C_206; public int? Po_C_206 { get { return _Po_C_206; } set { Set(ref _Po_C_206, value, "Po_C_206"); } }
		private int? _Po_C_503; public int? Po_C_503 { get { return _Po_C_503; } set { Set(ref _Po_C_503, value, "Po_C_503"); } }
		private decimal? _Hrs_Rdv; public decimal? Hrs_Rdv { get { return _Hrs_Rdv; } set { Set(ref _Hrs_Rdv, value, "Hrs_Rdv"); } }
		private bool? _Zhino; public bool? Zhino { get { return _Zhino; } set { Set(ref _Zhino, value, "Zhino"); } }
		private bool? _Z206; public bool? Z206 { get { return _Z206; } set { Set(ref _Z206, value, "Z206"); } }
		private bool? _Z503; public bool? Z503 { get { return _Z503; } set { Set(ref _Z503, value, "Z503"); } }
		private string _Paddr1; public string Paddr1 { get { return _Paddr1; } set { Set(ref _Paddr1, value, "Paddr1"); } }
		private string _Paddr2; public string Paddr2 { get { return _Paddr2; } set { Set(ref _Paddr2, value, "Paddr2"); } }
		private string _Pcity; public string Pcity { get { return _Pcity; } set { Set(ref _Pcity, value, "Pcity"); } }
		private string _Pstate; public string Pstate { get { return _Pstate; } set { Set(ref _Pstate, value, "Pstate"); } }
		private string _Pcountry; public string Pcountry { get { return _Pcountry; } set { Set(ref _Pcountry, value, "Pcountry"); } }
		private string _Pzip; public string Pzip { get { return _Pzip; } set { Set(ref _Pzip, value, "Pzip"); } }
		private string _Daddr1; public string Daddr1 { get { return _Daddr1; } set { Set(ref _Daddr1, value, "Daddr1"); } }
		private string _Daddr2; public string Daddr2 { get { return _Daddr2; } set { Set(ref _Daddr2, value, "Daddr2"); } }
		private string _Dcity; public string Dcity { get { return _Dcity; } set { Set(ref _Dcity, value, "Dcity"); } }
		private string _Dstate; public string Dstate { get { return _Dstate; } set { Set(ref _Dstate, value, "Dstate"); } }
		private string _Dzip; public string Dzip { get { return _Dzip; } set { Set(ref _Dzip, value, "Dzip"); } }
		private string _Dcountry; public string Dcountry { get { return _Dcountry; } set { Set(ref _Dcountry, value, "Dcountry"); } }
		private string _Ram_Name; public string Ram_Name { get { return _Ram_Name; } set { Set(ref _Ram_Name, value, "Ram_Name"); } }
		private string _Ram_Del; public string Ram_Del { get { return _Ram_Del; } set { Set(ref _Ram_Del, value, "Ram_Del"); } }
		private DateTime? _Ram_Date; public DateTime? Ram_Date { get { return _Ram_Date; } set { Set(ref _Ram_Date, value, "Ram_Date"); } }
		private int? _Ram_Trailer; public int? Ram_Trailer { get { return _Ram_Trailer; } set { Set(ref _Ram_Trailer, value, "Ram_Trailer"); } }
		private int? _Del_Trailer; public int? Del_Trailer { get { return _Del_Trailer; } set { Set(ref _Del_Trailer, value, "Del_Trailer"); } }
		private int? _Ram_Id_Car; public int? Ram_Id_Car { get { return _Ram_Id_Car; } set { Set(ref _Ram_Id_Car, value, "Ram_Id_Car"); } }
		private decimal? _Ram_Mnt; public decimal? Ram_Mnt { get { return _Ram_Mnt; } set { Set(ref _Ram_Mnt, value, "Ram_Mnt"); } }
		private string _Ram_Mnt_Cur; public string Ram_Mnt_Cur { get { return _Ram_Mnt_Cur; } set { Set(ref _Ram_Mnt_Cur, value, "Ram_Mnt_Cur"); } }
		private decimal? _Ram_Curr_Rate; public decimal? Ram_Curr_Rate { get { return _Ram_Curr_Rate; } set { Set(ref _Ram_Curr_Rate, value, "Ram_Curr_Rate"); } }
		private string _Ram_Note; public string Ram_Note { get { return _Ram_Note; } set { Set(ref _Ram_Note, value, "Ram_Note"); } }
		private decimal? _Ram_Rdv; public decimal? Ram_Rdv { get { return _Ram_Rdv; } set { Set(ref _Ram_Rdv, value, "Ram_Rdv"); } }
		private string _Ram_Conditions; public string Ram_Conditions { get { return _Ram_Conditions; } set { Set(ref _Ram_Conditions, value, "Ram_Conditions"); } }
		private string _Ram_Add; public string Ram_Add { get { return _Ram_Add; } set { Set(ref _Ram_Add, value, "Ram_Add"); } }
		private string _Ram_Ref; public string Ram_Ref { get { return _Ram_Ref; } set { Set(ref _Ram_Ref, value, "Ram_Ref"); } }
		private decimal? _Valrel; public decimal? Valrel { get { return _Valrel; } set { Set(ref _Valrel, value, "Valrel"); } }
		private int? _Popotid1; public int? Popotid1 { get { return _Popotid1; } set { Set(ref _Popotid1, value, "Popotid1"); } }
		private byte? _Trpordre; public byte? Trpordre { get { return _Trpordre; } set { Set(ref _Trpordre, value, "Trpordre"); } }
		private decimal? _Tpstaux; public decimal? Tpstaux { get { return _Tpstaux; } set { Set(ref _Tpstaux, value, "Tpstaux"); } }
		private decimal? _Tvqtaux; public decimal? Tvqtaux { get { return _Tvqtaux; } set { Set(ref _Tvqtaux, value, "Tvqtaux"); } }
		private decimal? _Tvhtaux; public decimal? Tvhtaux { get { return _Tvhtaux; } set { Set(ref _Tvhtaux, value, "Tvhtaux"); } }
		private string _Pr_By; public string Pr_By { get { return _Pr_By; } set { Set(ref _Pr_By, value, "Pr_By"); } }
		private DateTime? _Pr_Dtet; public DateTime? Pr_Dtet { get { return _Pr_Dtet; } set { Set(ref _Pr_Dtet, value, "Pr_Dtet"); } }
		private bool? _Blship; public bool? Blship { get { return _Blship; } set { Set(ref _Blship, value, "Blship"); } }
		private string _Contact; public string Contact { get { return _Contact; } set { Set(ref _Contact, value, "Contact"); } }

	}
}