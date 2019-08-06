using System;

namespace vivael
{
	public class data_ivfacotrep : DataSource
	{
		public data_ivfacotrep() { Table_name = i.name = "ivfacotrep"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Cotno; public int? Cotno { get { return _Cotno; } set { Set(ref _Cotno, value, "Cotno"); } }
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
		private string _Typedemande; public string Typedemande { get { return _Typedemande; } set { Set(ref _Typedemande, value, "Typedemande"); } }
		private bool? _Soumission; public bool? Soumission { get { return _Soumission; } set { Set(ref _Soumission, value, "Soumission"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private bool? _Ncr; public bool? Ncr { get { return _Ncr; } set { Set(ref _Ncr, value, "Ncr"); } }
		private bool? _Bond; public bool? Bond { get { return _Bond; } set { Set(ref _Bond, value, "Bond"); } }
		private decimal? _N_Longueur; public decimal? N_Longueur { get { return _N_Longueur; } set { Set(ref _N_Longueur, value, "N_Longueur"); } }
		private decimal? _N_Largeur; public decimal? N_Largeur { get { return _N_Largeur; } set { Set(ref _N_Largeur, value, "N_Largeur"); } }
		private bool? _Grifgl; public bool? Grifgl { get { return _Grifgl; } set { Set(ref _Grifgl, value, "Grifgl"); } }
		private bool? _Grifdr; public bool? Grifdr { get { return _Grifdr; } set { Set(ref _Grifdr, value, "Grifdr"); } }
		private bool? _Colgl; public bool? Colgl { get { return _Colgl; } set { Set(ref _Colgl, value, "Colgl"); } }
		private bool? _Coldr; public bool? Coldr { get { return _Coldr; } set { Set(ref _Coldr, value, "Coldr"); } }
		private string _Bretg; public string Bretg { get { return _Bretg; } set { Set(ref _Bretg, value, "Bretg"); } }
		private string _Bretd; public string Bretd { get { return _Bretd; } set { Set(ref _Bretd, value, "Bretd"); } }
		private string _Jeuxcol; public string Jeuxcol { get { return _Jeuxcol; } set { Set(ref _Jeuxcol, value, "Jeuxcol"); } }
		private bool? _Trouage; public bool? Trouage { get { return _Trouage; } set { Set(ref _Trouage, value, "Trouage"); } }
		private string _Troupartie; public string Troupartie { get { return _Troupartie; } set { Set(ref _Troupartie, value, "Troupartie"); } }
		private string _Troudiam; public string Troudiam { get { return _Troudiam; } set { Set(ref _Troudiam, value, "Troudiam"); } }
		private bool? _Numero; public bool? Numero { get { return _Numero; } set { Set(ref _Numero, value, "Numero"); } }
		private string _Numposphy; public string Numposphy { get { return _Numposphy; } set { Set(ref _Numposphy, value, "Numposphy"); } }
		private string _Numcoul; public string Numcoul { get { return _Numcoul; } set { Set(ref _Numcoul, value, "Numcoul"); } }
		private int? _Numnbr; public int? Numnbr { get { return _Numnbr; } set { Set(ref _Numnbr, value, "Numnbr"); } }
		private int? _Nbplaque; public int? Nbplaque { get { return _Nbplaque; } set { Set(ref _Nbplaque, value, "Nbplaque"); } }
		private int? _Pts1; public int? Pts1 { get { return _Pts1; } set { Set(ref _Pts1, value, "Pts1"); } }
		private string _Papier1; public string Papier1 { get { return _Papier1; } set { Set(ref _Papier1, value, "Papier1"); } }
		private bool? _Micr1; public bool? Micr1 { get { return _Micr1; } set { Set(ref _Micr1, value, "Micr1"); } }
		private bool? _Blocage1; public bool? Blocage1 { get { return _Blocage1; } set { Set(ref _Blocage1, value, "Blocage1"); } }
		private bool? _Verso1; public bool? Verso1 { get { return _Verso1; } set { Set(ref _Verso1, value, "Verso1"); } }
		private string _Perfore1; public string Perfore1 { get { return _Perfore1; } set { Set(ref _Perfore1, value, "Perfore1"); } }
		private string _Encref1; public string Encref1 { get { return _Encref1; } set { Set(ref _Encref1, value, "Encref1"); } }
		private string _Design1; public string Design1 { get { return _Design1; } set { Set(ref _Design1, value, "Design1"); } }
		private int? _Pts2; public int? Pts2 { get { return _Pts2; } set { Set(ref _Pts2, value, "Pts2"); } }
		private string _Papier2; public string Papier2 { get { return _Papier2; } set { Set(ref _Papier2, value, "Papier2"); } }
		private bool? _Micr2; public bool? Micr2 { get { return _Micr2; } set { Set(ref _Micr2, value, "Micr2"); } }
		private bool? _Blocage2; public bool? Blocage2 { get { return _Blocage2; } set { Set(ref _Blocage2, value, "Blocage2"); } }
		private bool? _Verso2; public bool? Verso2 { get { return _Verso2; } set { Set(ref _Verso2, value, "Verso2"); } }
		private string _Perfore2; public string Perfore2 { get { return _Perfore2; } set { Set(ref _Perfore2, value, "Perfore2"); } }
		private string _Encref2; public string Encref2 { get { return _Encref2; } set { Set(ref _Encref2, value, "Encref2"); } }
		private string _Design2; public string Design2 { get { return _Design2; } set { Set(ref _Design2, value, "Design2"); } }
		private int? _Pts3; public int? Pts3 { get { return _Pts3; } set { Set(ref _Pts3, value, "Pts3"); } }
		private string _Papier3; public string Papier3 { get { return _Papier3; } set { Set(ref _Papier3, value, "Papier3"); } }
		private bool? _Micr3; public bool? Micr3 { get { return _Micr3; } set { Set(ref _Micr3, value, "Micr3"); } }
		private bool? _Blocage3; public bool? Blocage3 { get { return _Blocage3; } set { Set(ref _Blocage3, value, "Blocage3"); } }
		private bool? _Verso3; public bool? Verso3 { get { return _Verso3; } set { Set(ref _Verso3, value, "Verso3"); } }
		private string _Perfore3; public string Perfore3 { get { return _Perfore3; } set { Set(ref _Perfore3, value, "Perfore3"); } }
		private string _Encref3; public string Encref3 { get { return _Encref3; } set { Set(ref _Encref3, value, "Encref3"); } }
		private string _Design3; public string Design3 { get { return _Design3; } set { Set(ref _Design3, value, "Design3"); } }
		private int? _Pts4; public int? Pts4 { get { return _Pts4; } set { Set(ref _Pts4, value, "Pts4"); } }
		private string _Papier4; public string Papier4 { get { return _Papier4; } set { Set(ref _Papier4, value, "Papier4"); } }
		private bool? _Micr4; public bool? Micr4 { get { return _Micr4; } set { Set(ref _Micr4, value, "Micr4"); } }
		private bool? _Blocage4; public bool? Blocage4 { get { return _Blocage4; } set { Set(ref _Blocage4, value, "Blocage4"); } }
		private bool? _Verso4; public bool? Verso4 { get { return _Verso4; } set { Set(ref _Verso4, value, "Verso4"); } }
		private string _Perfore4; public string Perfore4 { get { return _Perfore4; } set { Set(ref _Perfore4, value, "Perfore4"); } }
		private string _Encref4; public string Encref4 { get { return _Encref4; } set { Set(ref _Encref4, value, "Encref4"); } }
		private string _Design4; public string Design4 { get { return _Design4; } set { Set(ref _Design4, value, "Design4"); } }
		private int? _Pts5; public int? Pts5 { get { return _Pts5; } set { Set(ref _Pts5, value, "Pts5"); } }
		private string _Papier5; public string Papier5 { get { return _Papier5; } set { Set(ref _Papier5, value, "Papier5"); } }
		private bool? _Micr5; public bool? Micr5 { get { return _Micr5; } set { Set(ref _Micr5, value, "Micr5"); } }
		private bool? _Blocage5; public bool? Blocage5 { get { return _Blocage5; } set { Set(ref _Blocage5, value, "Blocage5"); } }
		private bool? _Verso5; public bool? Verso5 { get { return _Verso5; } set { Set(ref _Verso5, value, "Verso5"); } }
		private string _Perfore5; public string Perfore5 { get { return _Perfore5; } set { Set(ref _Perfore5, value, "Perfore5"); } }
		private string _Encref5; public string Encref5 { get { return _Encref5; } set { Set(ref _Encref5, value, "Encref5"); } }
		private string _Design5; public string Design5 { get { return _Design5; } set { Set(ref _Design5, value, "Design5"); } }
		private int? _Pts6; public int? Pts6 { get { return _Pts6; } set { Set(ref _Pts6, value, "Pts6"); } }
		private string _Papier6; public string Papier6 { get { return _Papier6; } set { Set(ref _Papier6, value, "Papier6"); } }
		private bool? _Micr6; public bool? Micr6 { get { return _Micr6; } set { Set(ref _Micr6, value, "Micr6"); } }
		private bool? _Blocage6; public bool? Blocage6 { get { return _Blocage6; } set { Set(ref _Blocage6, value, "Blocage6"); } }
		private bool? _Verso6; public bool? Verso6 { get { return _Verso6; } set { Set(ref _Verso6, value, "Verso6"); } }
		private string _Perfore6; public string Perfore6 { get { return _Perfore6; } set { Set(ref _Perfore6, value, "Perfore6"); } }
		private string _Encref6; public string Encref6 { get { return _Encref6; } set { Set(ref _Encref6, value, "Encref6"); } }
		private string _Design6; public string Design6 { get { return _Design6; } set { Set(ref _Design6, value, "Design6"); } }
		private int? _Pts7; public int? Pts7 { get { return _Pts7; } set { Set(ref _Pts7, value, "Pts7"); } }
		private string _Papier7; public string Papier7 { get { return _Papier7; } set { Set(ref _Papier7, value, "Papier7"); } }
		private bool? _Micr7; public bool? Micr7 { get { return _Micr7; } set { Set(ref _Micr7, value, "Micr7"); } }
		private bool? _Blocage7; public bool? Blocage7 { get { return _Blocage7; } set { Set(ref _Blocage7, value, "Blocage7"); } }
		private bool? _Verso7; public bool? Verso7 { get { return _Verso7; } set { Set(ref _Verso7, value, "Verso7"); } }
		private string _Perfore7; public string Perfore7 { get { return _Perfore7; } set { Set(ref _Perfore7, value, "Perfore7"); } }
		private string _Encref7; public string Encref7 { get { return _Encref7; } set { Set(ref _Encref7, value, "Encref7"); } }
		private string _Design7; public string Design7 { get { return _Design7; } set { Set(ref _Design7, value, "Design7"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Instr_Spec; public string Instr_Spec { get { return _Instr_Spec; } set { Set(ref _Instr_Spec, value, "Instr_Spec"); } }
		private string _Instr_Spec_Oth; public string Instr_Spec_Oth { get { return _Instr_Spec_Oth; } set { Set(ref _Instr_Spec_Oth, value, "Instr_Spec_Oth"); } }
		private string _Livr; public string Livr { get { return _Livr; } set { Set(ref _Livr, value, "Livr"); } }
		private string _Gestion_Invtr; public string Gestion_Invtr { get { return _Gestion_Invtr; } set { Set(ref _Gestion_Invtr, value, "Gestion_Invtr"); } }
		private string _Qte_Annuel_Cons; public string Qte_Annuel_Cons { get { return _Qte_Annuel_Cons; } set { Set(ref _Qte_Annuel_Cons, value, "Qte_Annuel_Cons"); } }
		private string _Qte_Comm_Freq; public string Qte_Comm_Freq { get { return _Qte_Comm_Freq; } set { Set(ref _Qte_Comm_Freq, value, "Qte_Comm_Freq"); } }
		private DateTime? _Date_Requis; public DateTime? Date_Requis { get { return _Date_Requis; } set { Set(ref _Date_Requis, value, "Date_Requis"); } }
		private byte? _Jrs_Requis; public byte? Jrs_Requis { get { return _Jrs_Requis; } set { Set(ref _Jrs_Requis, value, "Jrs_Requis"); } }
		private string _Echantillon; public string Echantillon { get { return _Echantillon; } set { Set(ref _Echantillon, value, "Echantillon"); } }
		private string _Echnote; public string Echnote { get { return _Echnote; } set { Set(ref _Echnote, value, "Echnote"); } }

	}
}