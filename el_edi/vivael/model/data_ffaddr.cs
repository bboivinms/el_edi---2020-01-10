using System;

namespace vivael
{
	public class data_ffaddr : DataSource
	{
		public data_ffaddr() { Table_name = i.name = "ffaddr"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Cliid; public int? Cliid { get { return _Cliid; } set { Set(ref _Cliid, value, "Cliid"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private string _Addr1; public string Addr1 { get { return _Addr1; } set { Set(ref _Addr1, value, "Addr1"); } }
		private string _Addr2; public string Addr2 { get { return _Addr2; } set { Set(ref _Addr2, value, "Addr2"); } }
		private string _City; public string City { get { return _City; } set { Set(ref _City, value, "City"); } }
		private string _State; public string State { get { return _State; } set { Set(ref _State, value, "State"); } }
		private string _Zip; public string Zip { get { return _Zip; } set { Set(ref _Zip, value, "Zip"); } }
		private string _Country; public string Country { get { return _Country; } set { Set(ref _Country, value, "Country"); } }
		private string _Tel1; public string Tel1 { get { return _Tel1; } set { Set(ref _Tel1, value, "Tel1"); } }
		private string _Tel2; public string Tel2 { get { return _Tel2; } set { Set(ref _Tel2, value, "Tel2"); } }
		private string _Fax; public string Fax { get { return _Fax; } set { Set(ref _Fax, value, "Fax"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Contact; public string Contact { get { return _Contact; } set { Set(ref _Contact, value, "Contact"); } }
		private string _Hrsouv; public string Hrsouv { get { return _Hrsouv; } set { Set(ref _Hrsouv, value, "Hrsouv"); } }
		private int? _Idzone; public int? Idzone { get { return _Idzone; } set { Set(ref _Idzone, value, "Idzone"); } }
		private int? _Ct_Appoint; public int? Ct_Appoint { get { return _Ct_Appoint; } set { Set(ref _Ct_Appoint, value, "Ct_Appoint"); } }
		private string _Ct_Contact; public string Ct_Contact { get { return _Ct_Contact; } set { Set(ref _Ct_Contact, value, "Ct_Contact"); } }
		private string _Ct_Tel; public string Ct_Tel { get { return _Ct_Tel; } set { Set(ref _Ct_Tel, value, "Ct_Tel"); } }
		private bool? _Ct_Certifica; public bool? Ct_Certifica { get { return _Ct_Certifica; } set { Set(ref _Ct_Certifica, value, "Ct_Certifica"); } }
		private int? _Ct_Def_Tr; public int? Ct_Def_Tr { get { return _Ct_Def_Tr; } set { Set(ref _Ct_Def_Tr, value, "Ct_Def_Tr"); } }
		private int? _Ct_Snow_Tr; public int? Ct_Snow_Tr { get { return _Ct_Snow_Tr; } set { Set(ref _Ct_Snow_Tr, value, "Ct_Snow_Tr"); } }
		private string _Ct_Note_Tr; public string Ct_Note_Tr { get { return _Ct_Note_Tr; } set { Set(ref _Ct_Note_Tr, value, "Ct_Note_Tr"); } }
		private bool? _Ct_Lun; public bool? Ct_Lun { get { return _Ct_Lun; } set { Set(ref _Ct_Lun, value, "Ct_Lun"); } }
		private bool? _Ct_Mar; public bool? Ct_Mar { get { return _Ct_Mar; } set { Set(ref _Ct_Mar, value, "Ct_Mar"); } }
		private bool? _Ct_Mer; public bool? Ct_Mer { get { return _Ct_Mer; } set { Set(ref _Ct_Mer, value, "Ct_Mer"); } }
		private bool? _Ct_Jeu; public bool? Ct_Jeu { get { return _Ct_Jeu; } set { Set(ref _Ct_Jeu, value, "Ct_Jeu"); } }
		private bool? _Ct_Ven; public bool? Ct_Ven { get { return _Ct_Ven; } set { Set(ref _Ct_Ven, value, "Ct_Ven"); } }
		private bool? _Ct_Sam; public bool? Ct_Sam { get { return _Ct_Sam; } set { Set(ref _Ct_Sam, value, "Ct_Sam"); } }
		private decimal? _Ct_D1_Lun; public decimal? Ct_D1_Lun { get { return _Ct_D1_Lun; } set { Set(ref _Ct_D1_Lun, value, "Ct_D1_Lun"); } }
		private decimal? _Ct_F1_Lun; public decimal? Ct_F1_Lun { get { return _Ct_F1_Lun; } set { Set(ref _Ct_F1_Lun, value, "Ct_F1_Lun"); } }
		private decimal? _Ct_D1_Mar; public decimal? Ct_D1_Mar { get { return _Ct_D1_Mar; } set { Set(ref _Ct_D1_Mar, value, "Ct_D1_Mar"); } }
		private decimal? _Ct_F1_Mar; public decimal? Ct_F1_Mar { get { return _Ct_F1_Mar; } set { Set(ref _Ct_F1_Mar, value, "Ct_F1_Mar"); } }
		private decimal? _Ct_D1_Mer; public decimal? Ct_D1_Mer { get { return _Ct_D1_Mer; } set { Set(ref _Ct_D1_Mer, value, "Ct_D1_Mer"); } }
		private decimal? _Ct_F1_Mer; public decimal? Ct_F1_Mer { get { return _Ct_F1_Mer; } set { Set(ref _Ct_F1_Mer, value, "Ct_F1_Mer"); } }
		private decimal? _Ct_D1_Jeu; public decimal? Ct_D1_Jeu { get { return _Ct_D1_Jeu; } set { Set(ref _Ct_D1_Jeu, value, "Ct_D1_Jeu"); } }
		private decimal? _Ct_F1_Jeu; public decimal? Ct_F1_Jeu { get { return _Ct_F1_Jeu; } set { Set(ref _Ct_F1_Jeu, value, "Ct_F1_Jeu"); } }
		private decimal? _Ct_D1_Ven; public decimal? Ct_D1_Ven { get { return _Ct_D1_Ven; } set { Set(ref _Ct_D1_Ven, value, "Ct_D1_Ven"); } }
		private decimal? _Ct_F1_Ven; public decimal? Ct_F1_Ven { get { return _Ct_F1_Ven; } set { Set(ref _Ct_F1_Ven, value, "Ct_F1_Ven"); } }
		private decimal? _Ct_D1_Sam; public decimal? Ct_D1_Sam { get { return _Ct_D1_Sam; } set { Set(ref _Ct_D1_Sam, value, "Ct_D1_Sam"); } }
		private decimal? _Ct_F1_Sam; public decimal? Ct_F1_Sam { get { return _Ct_F1_Sam; } set { Set(ref _Ct_F1_Sam, value, "Ct_F1_Sam"); } }
		private decimal? _Ct_D2_Lun; public decimal? Ct_D2_Lun { get { return _Ct_D2_Lun; } set { Set(ref _Ct_D2_Lun, value, "Ct_D2_Lun"); } }
		private decimal? _Ct_F2_Lun; public decimal? Ct_F2_Lun { get { return _Ct_F2_Lun; } set { Set(ref _Ct_F2_Lun, value, "Ct_F2_Lun"); } }
		private decimal? _Ct_D2_Mar; public decimal? Ct_D2_Mar { get { return _Ct_D2_Mar; } set { Set(ref _Ct_D2_Mar, value, "Ct_D2_Mar"); } }
		private decimal? _Ct_F2_Mar; public decimal? Ct_F2_Mar { get { return _Ct_F2_Mar; } set { Set(ref _Ct_F2_Mar, value, "Ct_F2_Mar"); } }
		private decimal? _Ct_D2_Mer; public decimal? Ct_D2_Mer { get { return _Ct_D2_Mer; } set { Set(ref _Ct_D2_Mer, value, "Ct_D2_Mer"); } }
		private decimal? _Ct_F2_Mer; public decimal? Ct_F2_Mer { get { return _Ct_F2_Mer; } set { Set(ref _Ct_F2_Mer, value, "Ct_F2_Mer"); } }
		private decimal? _Ct_D2_Jeu; public decimal? Ct_D2_Jeu { get { return _Ct_D2_Jeu; } set { Set(ref _Ct_D2_Jeu, value, "Ct_D2_Jeu"); } }
		private decimal? _Ct_F2_Jeu; public decimal? Ct_F2_Jeu { get { return _Ct_F2_Jeu; } set { Set(ref _Ct_F2_Jeu, value, "Ct_F2_Jeu"); } }
		private decimal? _Ct_D2_Ven; public decimal? Ct_D2_Ven { get { return _Ct_D2_Ven; } set { Set(ref _Ct_D2_Ven, value, "Ct_D2_Ven"); } }
		private decimal? _Ct_F2_Ven; public decimal? Ct_F2_Ven { get { return _Ct_F2_Ven; } set { Set(ref _Ct_F2_Ven, value, "Ct_F2_Ven"); } }
		private decimal? _Ct_D2_Sam; public decimal? Ct_D2_Sam { get { return _Ct_D2_Sam; } set { Set(ref _Ct_D2_Sam, value, "Ct_D2_Sam"); } }
		private decimal? _Ct_F2_Sam; public decimal? Ct_F2_Sam { get { return _Ct_F2_Sam; } set { Set(ref _Ct_F2_Sam, value, "Ct_F2_Sam"); } }
		private string _Cart_Ond_Palet; public string Cart_Ond_Palet { get { return _Cart_Ond_Palet; } set { Set(ref _Cart_Ond_Palet, value, "Cart_Ond_Palet"); } }
		private string _Mode_Empilage; public string Mode_Empilage { get { return _Mode_Empilage; } set { Set(ref _Mode_Empilage, value, "Mode_Empilage"); } }
		private string _Paquet_Attache; public string Paquet_Attache { get { return _Paquet_Attache; } set { Set(ref _Paquet_Attache, value, "Paquet_Attache"); } }
		private string _Type_Decharge; public string Type_Decharge { get { return _Type_Decharge; } set { Set(ref _Type_Decharge, value, "Type_Decharge"); } }
		private int? _Ballots_Long; public int? Ballots_Long { get { return _Ballots_Long; } set { Set(ref _Ballots_Long, value, "Ballots_Long"); } }
		private int? _Ballots_Larg; public int? Ballots_Larg { get { return _Ballots_Larg; } set { Set(ref _Ballots_Larg, value, "Ballots_Larg"); } }
		private int? _Ballots_Haut; public int? Ballots_Haut { get { return _Ballots_Haut; } set { Set(ref _Ballots_Haut, value, "Ballots_Haut"); } }
		private string _Pal_Notes; public string Pal_Notes { get { return _Pal_Notes; } set { Set(ref _Pal_Notes, value, "Pal_Notes"); } }
		private bool? _Crit_Mat_Liv; public bool? Crit_Mat_Liv { get { return _Crit_Mat_Liv; } set { Set(ref _Crit_Mat_Liv, value, "Crit_Mat_Liv"); } }
		private bool? _Crit_Tra_Liv; public bool? Crit_Tra_Liv { get { return _Crit_Tra_Liv; } set { Set(ref _Crit_Tra_Liv, value, "Crit_Tra_Liv"); } }
		private bool? _Gst_Exem; public bool? Gst_Exem { get { return _Gst_Exem; } set { Set(ref _Gst_Exem, value, "Gst_Exem"); } }
		private bool? _Pst_Exem; public bool? Pst_Exem { get { return _Pst_Exem; } set { Set(ref _Pst_Exem, value, "Pst_Exem"); } }
		private bool? _Tvh_Ch; public bool? Tvh_Ch { get { return _Tvh_Ch; } set { Set(ref _Tvh_Ch, value, "Tvh_Ch"); } }
		private string _Gst_No; public string Gst_No { get { return _Gst_No; } set { Set(ref _Gst_No, value, "Gst_No"); } }
		private string _Pst_No; public string Pst_No { get { return _Pst_No; } set { Set(ref _Pst_No, value, "Pst_No"); } }
		private decimal? _Tvhtaux; public decimal? Tvhtaux { get { return _Tvhtaux; } set { Set(ref _Tvhtaux, value, "Tvhtaux"); } }
		private bool? _Blship; public bool? Blship { get { return _Blship; } set { Set(ref _Blship, value, "Blship"); } }

	}
}