using System;

namespace vivael
{
	public class data_ivcocotrep : DataSource
	{
		public data_ivcocotrep() { Table_name = i.name = "ivcocotrep"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Clientid; public int? Clientid { get { return _Clientid; } set { Set(ref _Clientid, value, "Clientid"); } }
		private string _Devise; public string Devise { get { return _Devise; } set { Set(ref _Devise, value, "Devise"); } }
		private string _Cont_Nom; public string Cont_Nom { get { return _Cont_Nom; } set { Set(ref _Cont_Nom, value, "Cont_Nom"); } }
		private string _Cont_Fax; public string Cont_Fax { get { return _Cont_Fax; } set { Set(ref _Cont_Fax, value, "Cont_Fax"); } }
		private string _Cont_Email; public string Cont_Email { get { return _Cont_Email; } set { Set(ref _Cont_Email, value, "Cont_Email"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dte; public DateTime? Mod_Dte { get { return _Mod_Dte; } set { Set(ref _Mod_Dte, value, "Mod_Dte"); } }
		private string _Rep_Name; public string Rep_Name { get { return _Rep_Name; } set { Set(ref _Rep_Name, value, "Rep_Name"); } }
		private string _Sorte; public string Sorte { get { return _Sorte; } set { Set(ref _Sorte, value, "Sorte"); } }
		private string _Flute; public string Flute { get { return _Flute; } set { Set(ref _Flute, value, "Flute"); } }
		private string _Test; public string Test { get { return _Test; } set { Set(ref _Test, value, "Test"); } }
		private string _Style; public string Style { get { return _Style; } set { Set(ref _Style, value, "Style"); } }
		private string _Nbcoul; public string Nbcoul { get { return _Nbcoul; } set { Set(ref _Nbcoul, value, "Nbcoul"); } }
		private string _Enduit; public string Enduit { get { return _Enduit; } set { Set(ref _Enduit, value, "Enduit"); } }
		private string _Enduit_Oth; public string Enduit_Oth { get { return _Enduit_Oth; } set { Set(ref _Enduit_Oth, value, "Enduit_Oth"); } }
		private string _Fermeture; public string Fermeture { get { return _Fermeture; } set { Set(ref _Fermeture, value, "Fermeture"); } }
		private string _Item_Id_Print; public string Item_Id_Print { get { return _Item_Id_Print; } set { Set(ref _Item_Id_Print, value, "Item_Id_Print"); } }
		private decimal? _N_Longueur; public decimal? N_Longueur { get { return _N_Longueur; } set { Set(ref _N_Longueur, value, "N_Longueur"); } }
		private decimal? _N_Largeur; public decimal? N_Largeur { get { return _N_Largeur; } set { Set(ref _N_Largeur, value, "N_Largeur"); } }
		private decimal? _N_Hauteur; public decimal? N_Hauteur { get { return _N_Hauteur; } set { Set(ref _N_Hauteur, value, "N_Hauteur"); } }
		private decimal? _Sh_Size_Longueur; public decimal? Sh_Size_Longueur { get { return _Sh_Size_Longueur; } set { Set(ref _Sh_Size_Longueur, value, "Sh_Size_Longueur"); } }
		private decimal? _Sh_Size_Largeur; public decimal? Sh_Size_Largeur { get { return _Sh_Size_Largeur; } set { Set(ref _Sh_Size_Largeur, value, "Sh_Size_Largeur"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Gestion_Invtr; public string Gestion_Invtr { get { return _Gestion_Invtr; } set { Set(ref _Gestion_Invtr, value, "Gestion_Invtr"); } }
		private string _Qte_Annuel_Cons; public string Qte_Annuel_Cons { get { return _Qte_Annuel_Cons; } set { Set(ref _Qte_Annuel_Cons, value, "Qte_Annuel_Cons"); } }
		private string _Qte_Comm_Freq; public string Qte_Comm_Freq { get { return _Qte_Comm_Freq; } set { Set(ref _Qte_Comm_Freq, value, "Qte_Comm_Freq"); } }
		private string _Prix_Comm_Qte; public string Prix_Comm_Qte { get { return _Prix_Comm_Qte; } set { Set(ref _Prix_Comm_Qte, value, "Prix_Comm_Qte"); } }
		private int? _Cotno; public int? Cotno { get { return _Cotno; } set { Set(ref _Cotno, value, "Cotno"); } }
		private string _Livr; public string Livr { get { return _Livr; } set { Set(ref _Livr, value, "Livr"); } }
		private string _Typedemande; public string Typedemande { get { return _Typedemande; } set { Set(ref _Typedemande, value, "Typedemande"); } }
		private bool? _Soumission; public bool? Soumission { get { return _Soumission; } set { Set(ref _Soumission, value, "Soumission"); } }
		private DateTime? _Date_Requis; public DateTime? Date_Requis { get { return _Date_Requis; } set { Set(ref _Date_Requis, value, "Date_Requis"); } }
		private byte? _Jrs_Requis; public byte? Jrs_Requis { get { return _Jrs_Requis; } set { Set(ref _Jrs_Requis, value, "Jrs_Requis"); } }
		private string _Echantillon; public string Echantillon { get { return _Echantillon; } set { Set(ref _Echantillon, value, "Echantillon"); } }
		private string _Echnote; public string Echnote { get { return _Echnote; } set { Set(ref _Echnote, value, "Echnote"); } }

	}
}