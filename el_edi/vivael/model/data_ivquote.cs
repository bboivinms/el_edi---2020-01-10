using System;

namespace vivael
{
	public class data_ivquote : DataSource
	{
		public data_ivquote() { Table_name = i.name = "ivquote"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idproduit; public int? Idproduit { get { return _Idproduit; } set { Set(ref _Idproduit, value, "Idproduit"); } }
		private int? _Idclient; public int? Idclient { get { return _Idclient; } set { Set(ref _Idclient, value, "Idclient"); } }
		private string _Contact; public string Contact { get { return _Contact; } set { Set(ref _Contact, value, "Contact"); } }
		private string _Fax; public string Fax { get { return _Fax; } set { Set(ref _Fax, value, "Fax"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private DateTime? _Dte; public DateTime? Dte { get { return _Dte; } set { Set(ref _Dte, value, "Dte"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private string _Your_Ref; public string Your_Ref { get { return _Your_Ref; } set { Set(ref _Your_Ref, value, "Your_Ref"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private DateTime? _Statut_Dte; public DateTime? Statut_Dte { get { return _Statut_Dte; } set { Set(ref _Statut_Dte, value, "Statut_Dte"); } }
		private string _Bottom_Note; public string Bottom_Note { get { return _Bottom_Note; } set { Set(ref _Bottom_Note, value, "Bottom_Note"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private decimal? _Prix1; public decimal? Prix1 { get { return _Prix1; } set { Set(ref _Prix1, value, "Prix1"); } }
		private decimal? _Prix2; public decimal? Prix2 { get { return _Prix2; } set { Set(ref _Prix2, value, "Prix2"); } }
		private decimal? _Prix3; public decimal? Prix3 { get { return _Prix3; } set { Set(ref _Prix3, value, "Prix3"); } }
		private decimal? _Prix4; public decimal? Prix4 { get { return _Prix4; } set { Set(ref _Prix4, value, "Prix4"); } }
		private decimal? _Prix5; public decimal? Prix5 { get { return _Prix5; } set { Set(ref _Prix5, value, "Prix5"); } }
		private int? _Qte1; public int? Qte1 { get { return _Qte1; } set { Set(ref _Qte1, value, "Qte1"); } }
		private int? _Qte2; public int? Qte2 { get { return _Qte2; } set { Set(ref _Qte2, value, "Qte2"); } }
		private int? _Qte3; public int? Qte3 { get { return _Qte3; } set { Set(ref _Qte3, value, "Qte3"); } }
		private int? _Qte4; public int? Qte4 { get { return _Qte4; } set { Set(ref _Qte4, value, "Qte4"); } }
		private int? _Qte5; public int? Qte5 { get { return _Qte5; } set { Set(ref _Qte5, value, "Qte5"); } }
		private decimal? _Idprix1; public decimal? Idprix1 { get { return _Idprix1; } set { Set(ref _Idprix1, value, "Idprix1"); } }
		private decimal? _Idprix2; public decimal? Idprix2 { get { return _Idprix2; } set { Set(ref _Idprix2, value, "Idprix2"); } }
		private decimal? _Idprix3; public decimal? Idprix3 { get { return _Idprix3; } set { Set(ref _Idprix3, value, "Idprix3"); } }
		private decimal? _Idprix4; public decimal? Idprix4 { get { return _Idprix4; } set { Set(ref _Idprix4, value, "Idprix4"); } }
		private decimal? _Idprix5; public decimal? Idprix5 { get { return _Idprix5; } set { Set(ref _Idprix5, value, "Idprix5"); } }
		private string _Unite1; public string Unite1 { get { return _Unite1; } set { Set(ref _Unite1, value, "Unite1"); } }
		private string _Unite2; public string Unite2 { get { return _Unite2; } set { Set(ref _Unite2, value, "Unite2"); } }
		private string _Unite3; public string Unite3 { get { return _Unite3; } set { Set(ref _Unite3, value, "Unite3"); } }
		private string _Unite4; public string Unite4 { get { return _Unite4; } set { Set(ref _Unite4, value, "Unite4"); } }
		private string _Unite5; public string Unite5 { get { return _Unite5; } set { Set(ref _Unite5, value, "Unite5"); } }
		private string _Termes; public string Termes { get { return _Termes; } set { Set(ref _Termes, value, "Termes"); } }
		private string _Surplus; public string Surplus { get { return _Surplus; } set { Set(ref _Surplus, value, "Surplus"); } }
		private string _Cond_Entr; public string Cond_Entr { get { return _Cond_Entr; } set { Set(ref _Cond_Entr, value, "Cond_Entr"); } }
		private string _Transport; public string Transport { get { return _Transport; } set { Set(ref _Transport, value, "Transport"); } }
		private int? _Nblot1; public int? Nblot1 { get { return _Nblot1; } set { Set(ref _Nblot1, value, "Nblot1"); } }
		private int? _Nblot2; public int? Nblot2 { get { return _Nblot2; } set { Set(ref _Nblot2, value, "Nblot2"); } }
		private int? _Nblot3; public int? Nblot3 { get { return _Nblot3; } set { Set(ref _Nblot3, value, "Nblot3"); } }
		private int? _Nblot4; public int? Nblot4 { get { return _Nblot4; } set { Set(ref _Nblot4, value, "Nblot4"); } }
		private int? _Nblot5; public int? Nblot5 { get { return _Nblot5; } set { Set(ref _Nblot5, value, "Nblot5"); } }
		private decimal? _Temps_Infog; public decimal? Temps_Infog { get { return _Temps_Infog; } set { Set(ref _Temps_Infog, value, "Temps_Infog"); } }
		private decimal? _Taux_Infog; public decimal? Taux_Infog { get { return _Taux_Infog; } set { Set(ref _Taux_Infog, value, "Taux_Infog"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dte; public DateTime? Mod_Dte { get { return _Mod_Dte; } set { Set(ref _Mod_Dte, value, "Mod_Dte"); } }
		private bool? _Augment; public bool? Augment { get { return _Augment; } set { Set(ref _Augment, value, "Augment"); } }
		private decimal? _Augment_Taux; public decimal? Augment_Taux { get { return _Augment_Taux; } set { Set(ref _Augment_Taux, value, "Augment_Taux"); } }
		private int? _Old_Ident; public int? Old_Ident { get { return _Old_Ident; } set { Set(ref _Old_Ident, value, "Old_Ident"); } }
		private string _Language; public string Language { get { return _Language; } set { Set(ref _Language, value, "Language"); } }
		private decimal? _Prix_Moyen; public decimal? Prix_Moyen { get { return _Prix_Moyen; } set { Set(ref _Prix_Moyen, value, "Prix_Moyen"); } }
		private short? _Nblivmax; public short? Nblivmax { get { return _Nblivmax; } set { Set(ref _Nblivmax, value, "Nblivmax"); } }

	}
}