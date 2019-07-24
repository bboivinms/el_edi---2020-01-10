using System;

namespace vivael
{
	public class data_ivencotrep : DataSource
	{
		public data_ivencotrep() { Table_name = i.name = "ivencotrep"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Ident_Estima; public int? Ident_Estima { get { return _Ident_Estima; } set { Set(ref _Ident_Estima, value, "Ident_Estima"); } }
		private int? _Ident_Ivprix; public int? Ident_Ivprix { get { return _Ident_Ivprix; } set { Set(ref _Ident_Ivprix, value, "Ident_Ivprix"); } }
		private int? _Clientid; public int? Clientid { get { return _Clientid; } set { Set(ref _Clientid, value, "Clientid"); } }
		private string _Cont_Nom; public string Cont_Nom { get { return _Cont_Nom; } set { Set(ref _Cont_Nom, value, "Cont_Nom"); } }
		private string _Cont_Fax; public string Cont_Fax { get { return _Cont_Fax; } set { Set(ref _Cont_Fax, value, "Cont_Fax"); } }
		private string _Cont_Email; public string Cont_Email { get { return _Cont_Email; } set { Set(ref _Cont_Email, value, "Cont_Email"); } }
		private string _Devise; public string Devise { get { return _Devise; } set { Set(ref _Devise, value, "Devise"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dte; public DateTime? Mod_Dte { get { return _Mod_Dte; } set { Set(ref _Mod_Dte, value, "Mod_Dte"); } }
		private string _Rep_Name; public string Rep_Name { get { return _Rep_Name; } set { Set(ref _Rep_Name, value, "Rep_Name"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Idprod_Base; public int? Idprod_Base { get { return _Idprod_Base; } set { Set(ref _Idprod_Base, value, "Idprod_Base"); } }
		private int? _Idprod_Soum; public int? Idprod_Soum { get { return _Idprod_Soum; } set { Set(ref _Idprod_Soum, value, "Idprod_Soum"); } }
		private string _Typedem; public string Typedem { get { return _Typedem; } set { Set(ref _Typedem, value, "Typedem"); } }
		private bool? _Soumission; public bool? Soumission { get { return _Soumission; } set { Set(ref _Soumission, value, "Soumission"); } }
		private DateTime? _Datereq; public DateTime? Datereq { get { return _Datereq; } set { Set(ref _Datereq, value, "Datereq"); } }
		private decimal? _Jrsreq; public decimal? Jrsreq { get { return _Jrsreq; } set { Set(ref _Jrsreq, value, "Jrsreq"); } }
		private string _Echantillon; public string Echantillon { get { return _Echantillon; } set { Set(ref _Echantillon, value, "Echantillon"); } }
		private string _Echnote; public string Echnote { get { return _Echnote; } set { Set(ref _Echnote, value, "Echnote"); } }
		private string _Format; public string Format { get { return _Format; } set { Set(ref _Format, value, "Format"); } }
		private string _Autformat; public string Autformat { get { return _Autformat; } set { Set(ref _Autformat, value, "Autformat"); } }
		private string _Construct; public string Construct { get { return _Construct; } set { Set(ref _Construct, value, "Construct"); } }
		private string _Rabat; public string Rabat { get { return _Rabat; } set { Set(ref _Rabat, value, "Rabat"); } }
		private string _Typrab; public string Typrab { get { return _Typrab; } set { Set(ref _Typrab, value, "Typrab"); } }
		private string _Autrab; public string Autrab { get { return _Autrab; } set { Set(ref _Autrab, value, "Autrab"); } }
		private string _Colle; public string Colle { get { return _Colle; } set { Set(ref _Colle, value, "Colle"); } }
		private string _Papier; public string Papier { get { return _Papier; } set { Set(ref _Papier, value, "Papier"); } }
		private string _Autpap; public string Autpap { get { return _Autpap; } set { Set(ref _Autpap, value, "Autpap"); } }
		private string _Poids; public string Poids { get { return _Poids; } set { Set(ref _Poids, value, "Poids"); } }
		private bool? _Papcli; public bool? Papcli { get { return _Papcli; } set { Set(ref _Papcli, value, "Papcli"); } }
		private string _Fenetre1; public string Fenetre1 { get { return _Fenetre1; } set { Set(ref _Fenetre1, value, "Fenetre1"); } }
		private string _Fenetre2; public string Fenetre2 { get { return _Fenetre2; } set { Set(ref _Fenetre2, value, "Fenetre2"); } }
		private decimal? _Fen1haut; public decimal? Fen1haut { get { return _Fen1haut; } set { Set(ref _Fen1haut, value, "Fen1haut"); } }
		private decimal? _Fen1larg; public decimal? Fen1larg { get { return _Fen1larg; } set { Set(ref _Fen1larg, value, "Fen1larg"); } }
		private decimal? _Fen1disg; public decimal? Fen1disg { get { return _Fen1disg; } set { Set(ref _Fen1disg, value, "Fen1disg"); } }
		private decimal? _Fen1disb; public decimal? Fen1disb { get { return _Fen1disb; } set { Set(ref _Fen1disb, value, "Fen1disb"); } }
		private decimal? _Fen2haut; public decimal? Fen2haut { get { return _Fen2haut; } set { Set(ref _Fen2haut, value, "Fen2haut"); } }
		private decimal? _Fen2larg; public decimal? Fen2larg { get { return _Fen2larg; } set { Set(ref _Fen2larg, value, "Fen2larg"); } }
		private decimal? _Fen2disg; public decimal? Fen2disg { get { return _Fen2disg; } set { Set(ref _Fen2disg, value, "Fen2disg"); } }
		private decimal? _Fen2disb; public decimal? Fen2disb { get { return _Fen2disb; } set { Set(ref _Fen2disb, value, "Fen2disb"); } }
		private string _Fenplast; public string Fenplast { get { return _Fenplast; } set { Set(ref _Fenplast, value, "Fenplast"); } }
		private string _Imprecto; public string Imprecto { get { return _Imprecto; } set { Set(ref _Imprecto, value, "Imprecto"); } }
		private string _Impverso; public string Impverso { get { return _Impverso; } set { Set(ref _Impverso, value, "Impverso"); } }
		private string _Impint; public string Impint { get { return _Impint; } set { Set(ref _Impint, value, "Impint"); } }
		private string _Typefsc; public string Typefsc { get { return _Typefsc; } set { Set(ref _Typefsc, value, "Typefsc"); } }
		private string _Langfsc; public string Langfsc { get { return _Langfsc; } set { Set(ref _Langfsc, value, "Langfsc"); } }
		private string _Rensenv; public string Rensenv { get { return _Rensenv; } set { Set(ref _Rensenv, value, "Rensenv"); } }
		private string _Typeliv; public string Typeliv { get { return _Typeliv; } set { Set(ref _Typeliv, value, "Typeliv"); } }
		private string _Makeship; public string Makeship { get { return _Makeship; } set { Set(ref _Makeship, value, "Makeship"); } }
		private int? _Cotno; public int? Cotno { get { return _Cotno; } set { Set(ref _Cotno, value, "Cotno"); } }
		private string _Livr; public string Livr { get { return _Livr; } set { Set(ref _Livr, value, "Livr"); } }
		private string _Qteancons; public string Qteancons { get { return _Qteancons; } set { Set(ref _Qteancons, value, "Qteancons"); } }
		private string _Qtecomfre; public string Qtecomfre { get { return _Qtecomfre; } set { Set(ref _Qtecomfre, value, "Qtecomfre"); } }
		private string _Prixcoqte; public string Prixcoqte { get { return _Prixcoqte; } set { Set(ref _Prixcoqte, value, "Prixcoqte"); } }
		private bool? _Fenstd; public bool? Fenstd { get { return _Fenstd; } set { Set(ref _Fenstd, value, "Fenstd"); } }
		private bool? _Chk_Rabat_0; public bool? Chk_Rabat_0 { get { return _Chk_Rabat_0; } set { Set(ref _Chk_Rabat_0, value, "Chk_Rabat_0"); } }
		private bool? _Chk_Rabat_1; public bool? Chk_Rabat_1 { get { return _Chk_Rabat_1; } set { Set(ref _Chk_Rabat_1, value, "Chk_Rabat_1"); } }
		private bool? _Chk_Rabat_2; public bool? Chk_Rabat_2 { get { return _Chk_Rabat_2; } set { Set(ref _Chk_Rabat_2, value, "Chk_Rabat_2"); } }
		private bool? _Chk_Fen_Nb_1; public bool? Chk_Fen_Nb_1 { get { return _Chk_Fen_Nb_1; } set { Set(ref _Chk_Fen_Nb_1, value, "Chk_Fen_Nb_1"); } }
		private bool? _Chk_Fen_1; public bool? Chk_Fen_1 { get { return _Chk_Fen_1; } set { Set(ref _Chk_Fen_1, value, "Chk_Fen_1"); } }
		private string _Cmb_Encre; public string Cmb_Encre { get { return _Cmb_Encre; } set { Set(ref _Cmb_Encre, value, "Cmb_Encre"); } }
		private bool? _Chk_Fsc_1; public bool? Chk_Fsc_1 { get { return _Chk_Fsc_1; } set { Set(ref _Chk_Fsc_1, value, "Chk_Fsc_1"); } }
		private bool? _Chk_Bleed_1; public bool? Chk_Bleed_1 { get { return _Chk_Bleed_1; } set { Set(ref _Chk_Bleed_1, value, "Chk_Bleed_1"); } }
		private string _Rdo_Liv; public string Rdo_Liv { get { return _Rdo_Liv; } set { Set(ref _Rdo_Liv, value, "Rdo_Liv"); } }
		private string _Txt_Qte_Annuel_Cons; public string Txt_Qte_Annuel_Cons { get { return _Txt_Qte_Annuel_Cons; } set { Set(ref _Txt_Qte_Annuel_Cons, value, "Txt_Qte_Annuel_Cons"); } }
		private decimal? _Txt_Qte_Comm_Freq_1; public decimal? Txt_Qte_Comm_Freq_1 { get { return _Txt_Qte_Comm_Freq_1; } set { Set(ref _Txt_Qte_Comm_Freq_1, value, "Txt_Qte_Comm_Freq_1"); } }
		private decimal? _Txt_Qte_Comm_Freq_2; public decimal? Txt_Qte_Comm_Freq_2 { get { return _Txt_Qte_Comm_Freq_2; } set { Set(ref _Txt_Qte_Comm_Freq_2, value, "Txt_Qte_Comm_Freq_2"); } }
		private decimal? _Txt_Qte_Comm_Freq_3; public decimal? Txt_Qte_Comm_Freq_3 { get { return _Txt_Qte_Comm_Freq_3; } set { Set(ref _Txt_Qte_Comm_Freq_3, value, "Txt_Qte_Comm_Freq_3"); } }
		private decimal? _Txt_Qte_Comm_Freq_4; public decimal? Txt_Qte_Comm_Freq_4 { get { return _Txt_Qte_Comm_Freq_4; } set { Set(ref _Txt_Qte_Comm_Freq_4, value, "Txt_Qte_Comm_Freq_4"); } }
		private decimal? _Txt_Qte_Comm_Freq_5; public decimal? Txt_Qte_Comm_Freq_5 { get { return _Txt_Qte_Comm_Freq_5; } set { Set(ref _Txt_Qte_Comm_Freq_5, value, "Txt_Qte_Comm_Freq_5"); } }
		private decimal? _Txt_Prix_Base; public decimal? Txt_Prix_Base { get { return _Txt_Prix_Base; } set { Set(ref _Txt_Prix_Base, value, "Txt_Prix_Base"); } }
		private decimal? _Txt_Prix_Imp_1; public decimal? Txt_Prix_Imp_1 { get { return _Txt_Prix_Imp_1; } set { Set(ref _Txt_Prix_Imp_1, value, "Txt_Prix_Imp_1"); } }
		private decimal? _Txt_Prix_Imp_2; public decimal? Txt_Prix_Imp_2 { get { return _Txt_Prix_Imp_2; } set { Set(ref _Txt_Prix_Imp_2, value, "Txt_Prix_Imp_2"); } }
		private decimal? _Txt_Prix_Imp_3; public decimal? Txt_Prix_Imp_3 { get { return _Txt_Prix_Imp_3; } set { Set(ref _Txt_Prix_Imp_3, value, "Txt_Prix_Imp_3"); } }
		private decimal? _Txt_Prix_Imp_4; public decimal? Txt_Prix_Imp_4 { get { return _Txt_Prix_Imp_4; } set { Set(ref _Txt_Prix_Imp_4, value, "Txt_Prix_Imp_4"); } }
		private decimal? _Txt_Prix_Imp_5; public decimal? Txt_Prix_Imp_5 { get { return _Txt_Prix_Imp_5; } set { Set(ref _Txt_Prix_Imp_5, value, "Txt_Prix_Imp_5"); } }
		private decimal? _Txt_Prix_1; public decimal? Txt_Prix_1 { get { return _Txt_Prix_1; } set { Set(ref _Txt_Prix_1, value, "Txt_Prix_1"); } }
		private decimal? _Txt_Prix_2; public decimal? Txt_Prix_2 { get { return _Txt_Prix_2; } set { Set(ref _Txt_Prix_2, value, "Txt_Prix_2"); } }
		private decimal? _Txt_Prix_3; public decimal? Txt_Prix_3 { get { return _Txt_Prix_3; } set { Set(ref _Txt_Prix_3, value, "Txt_Prix_3"); } }
		private decimal? _Txt_Prix_4; public decimal? Txt_Prix_4 { get { return _Txt_Prix_4; } set { Set(ref _Txt_Prix_4, value, "Txt_Prix_4"); } }
		private decimal? _Txt_Prix_5; public decimal? Txt_Prix_5 { get { return _Txt_Prix_5; } set { Set(ref _Txt_Prix_5, value, "Txt_Prix_5"); } }
		private bool? _Bprod_Search; public bool? Bprod_Search { get { return _Bprod_Search; } set { Set(ref _Bprod_Search, value, "Bprod_Search"); } }

	}
}