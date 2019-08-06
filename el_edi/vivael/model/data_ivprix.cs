using System;

namespace vivael
{
	public class data_ivprix : DataSource
	{
		public data_ivprix() { Table_name = i.name = "ivprix"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idproduit; public int? Idproduit { get { return _Idproduit; } set { Set(ref _Idproduit, value, "Idproduit"); } }
		private int? _Idvendor; public int? Idvendor { get { return _Idvendor; } set { Set(ref _Idvendor, value, "Idvendor"); } }
		private string _Contact; public string Contact { get { return _Contact; } set { Set(ref _Contact, value, "Contact"); } }
		private string _Fax; public string Fax { get { return _Fax; } set { Set(ref _Fax, value, "Fax"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private DateTime? _Dte; public DateTime? Dte { get { return _Dte; } set { Set(ref _Dte, value, "Dte"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private string _Your_Ref; public string Your_Ref { get { return _Your_Ref; } set { Set(ref _Your_Ref, value, "Your_Ref"); } }
		private long? _Qte1; public long? Qte1 { get { return _Qte1; } set { Set(ref _Qte1, value, "Qte1"); } }
		private long? _Qte2; public long? Qte2 { get { return _Qte2; } set { Set(ref _Qte2, value, "Qte2"); } }
		private long? _Qte3; public long? Qte3 { get { return _Qte3; } set { Set(ref _Qte3, value, "Qte3"); } }
		private long? _Qte4; public long? Qte4 { get { return _Qte4; } set { Set(ref _Qte4, value, "Qte4"); } }
		private int? _Qte5; public int? Qte5 { get { return _Qte5; } set { Set(ref _Qte5, value, "Qte5"); } }
		private decimal? _Prix1; public decimal? Prix1 { get { return _Prix1; } set { Set(ref _Prix1, value, "Prix1"); } }
		private decimal? _Prix2; public decimal? Prix2 { get { return _Prix2; } set { Set(ref _Prix2, value, "Prix2"); } }
		private decimal? _Prix3; public decimal? Prix3 { get { return _Prix3; } set { Set(ref _Prix3, value, "Prix3"); } }
		private decimal? _Prix4; public decimal? Prix4 { get { return _Prix4; } set { Set(ref _Prix4, value, "Prix4"); } }
		private decimal? _Prix5; public decimal? Prix5 { get { return _Prix5; } set { Set(ref _Prix5, value, "Prix5"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private DateTime? _Statut_Dte; public DateTime? Statut_Dte { get { return _Statut_Dte; } set { Set(ref _Statut_Dte, value, "Statut_Dte"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Unite1; public string Unite1 { get { return _Unite1; } set { Set(ref _Unite1, value, "Unite1"); } }
		private string _Unite2; public string Unite2 { get { return _Unite2; } set { Set(ref _Unite2, value, "Unite2"); } }
		private string _Unite3; public string Unite3 { get { return _Unite3; } set { Set(ref _Unite3, value, "Unite3"); } }
		private string _Unite4; public string Unite4 { get { return _Unite4; } set { Set(ref _Unite4, value, "Unite4"); } }
		private string _Unite5; public string Unite5 { get { return _Unite5; } set { Set(ref _Unite5, value, "Unite5"); } }
		private int? _Nblot1; public int? Nblot1 { get { return _Nblot1; } set { Set(ref _Nblot1, value, "Nblot1"); } }
		private int? _Nblot2; public int? Nblot2 { get { return _Nblot2; } set { Set(ref _Nblot2, value, "Nblot2"); } }
		private int? _Nblot3; public int? Nblot3 { get { return _Nblot3; } set { Set(ref _Nblot3, value, "Nblot3"); } }
		private int? _Nblot4; public int? Nblot4 { get { return _Nblot4; } set { Set(ref _Nblot4, value, "Nblot4"); } }
		private int? _Nblot5; public int? Nblot5 { get { return _Nblot5; } set { Set(ref _Nblot5, value, "Nblot5"); } }
		private string _Ref_Fourn; public string Ref_Fourn { get { return _Ref_Fourn; } set { Set(ref _Ref_Fourn, value, "Ref_Fourn"); } }
		private int? _Old_Ident; public int? Old_Ident { get { return _Old_Ident; } set { Set(ref _Old_Ident, value, "Old_Ident"); } }
		private bool? _Augment; public bool? Augment { get { return _Augment; } set { Set(ref _Augment, value, "Augment"); } }
		private decimal? _Augment_Taux; public decimal? Augment_Taux { get { return _Augment_Taux; } set { Set(ref _Augment_Taux, value, "Augment_Taux"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dte; public DateTime? Mod_Dte { get { return _Mod_Dte; } set { Set(ref _Mod_Dte, value, "Mod_Dte"); } }
		private string _Ref_Precedent; public string Ref_Precedent { get { return _Ref_Precedent; } set { Set(ref _Ref_Precedent, value, "Ref_Precedent"); } }
		private bool? _Repeat_Exact; public bool? Repeat_Exact { get { return _Repeat_Exact; } set { Set(ref _Repeat_Exact, value, "Repeat_Exact"); } }
		private bool? _Avec_Modif; public bool? Avec_Modif { get { return _Avec_Modif; } set { Set(ref _Avec_Modif, value, "Avec_Modif"); } }
		private decimal? _Prix_Unit1; public decimal? Prix_Unit1 { get { return _Prix_Unit1; } set { Set(ref _Prix_Unit1, value, "Prix_Unit1"); } }
		private decimal? _Prix_Unit2; public decimal? Prix_Unit2 { get { return _Prix_Unit2; } set { Set(ref _Prix_Unit2, value, "Prix_Unit2"); } }
		private decimal? _Prix_Unit3; public decimal? Prix_Unit3 { get { return _Prix_Unit3; } set { Set(ref _Prix_Unit3, value, "Prix_Unit3"); } }
		private decimal? _Prix_Unit4; public decimal? Prix_Unit4 { get { return _Prix_Unit4; } set { Set(ref _Prix_Unit4, value, "Prix_Unit4"); } }
		private decimal? _Prix_Unit5; public decimal? Prix_Unit5 { get { return _Prix_Unit5; } set { Set(ref _Prix_Unit5, value, "Prix_Unit5"); } }

	}
}