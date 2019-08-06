using System;

namespace vivael
{
	public class data_ivcmcotrep : DataSource
	{
		public data_ivcmcotrep() { Table_name = i.name = "ivcmcotrep"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

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
		private string _Papier; public string Papier { get { return _Papier; } set { Set(ref _Papier, value, "Papier"); } }
		private string _Format; public string Format { get { return _Format; } set { Set(ref _Format, value, "Format"); } }
		private string _Ouvert; public string Ouvert { get { return _Ouvert; } set { Set(ref _Ouvert, value, "Ouvert"); } }
		private string _Ferme; public string Ferme { get { return _Ferme; } set { Set(ref _Ferme, value, "Ferme"); } }
		private string _Colrecto; public string Colrecto { get { return _Colrecto; } set { Set(ref _Colrecto, value, "Colrecto"); } }
		private string _Colverso; public string Colverso { get { return _Colverso; } set { Set(ref _Colverso, value, "Colverso"); } }
		private string _Finiscoul; public string Finiscoul { get { return _Finiscoul; } set { Set(ref _Finiscoul, value, "Finiscoul"); } }
		private string _Vernis_Lamin; public string Vernis_Lamin { get { return _Vernis_Lamin; } set { Set(ref _Vernis_Lamin, value, "Vernis_Lamin"); } }
		private long? _Livqte; public long? Livqte { get { return _Livqte; } set { Set(ref _Livqte, value, "Livqte"); } }
		private bool? _Livcouv; public bool? Livcouv { get { return _Livcouv; } set { Set(ref _Livcouv, value, "Livcouv"); } }
		private string _Livbroc; public string Livbroc { get { return _Livbroc; } set { Set(ref _Livbroc, value, "Livbroc"); } }
		private long? _Livtable; public long? Livtable { get { return _Livtable; } set { Set(ref _Livtable, value, "Livtable"); } }
		private bool? _Trou; public bool? Trou { get { return _Trou; } set { Set(ref _Trou, value, "Trou"); } }
		private int? _Trounb; public int? Trounb { get { return _Trounb; } set { Set(ref _Trounb, value, "Trounb"); } }
		private string _Trouposphy; public string Trouposphy { get { return _Trouposphy; } set { Set(ref _Trouposphy, value, "Trouposphy"); } }
		private string _Troudiam; public string Troudiam { get { return _Troudiam; } set { Set(ref _Troudiam, value, "Troudiam"); } }
		private bool? _Numero; public bool? Numero { get { return _Numero; } set { Set(ref _Numero, value, "Numero"); } }
		private int? _Nbpos; public int? Nbpos { get { return _Nbpos; } set { Set(ref _Nbpos, value, "Nbpos"); } }
		private string _Numposphy; public string Numposphy { get { return _Numposphy; } set { Set(ref _Numposphy, value, "Numposphy"); } }
		private string _Numcoul; public string Numcoul { get { return _Numcoul; } set { Set(ref _Numcoul, value, "Numcoul"); } }
		private string _Nb_Lot_Cmb; public string Nb_Lot_Cmb { get { return _Nb_Lot_Cmb; } set { Set(ref _Nb_Lot_Cmb, value, "Nb_Lot_Cmb"); } }
		private string _Nb_Lot_Cmb_Oth; public string Nb_Lot_Cmb_Oth { get { return _Nb_Lot_Cmb_Oth; } set { Set(ref _Nb_Lot_Cmb_Oth, value, "Nb_Lot_Cmb_Oth"); } }
		private string _Nb_Lot_Cmb_Coul; public string Nb_Lot_Cmb_Coul { get { return _Nb_Lot_Cmb_Coul; } set { Set(ref _Nb_Lot_Cmb_Coul, value, "Nb_Lot_Cmb_Coul"); } }
		private string _Nb_Lot_Cmb_Plaq; public string Nb_Lot_Cmb_Plaq { get { return _Nb_Lot_Cmb_Plaq; } set { Set(ref _Nb_Lot_Cmb_Plaq, value, "Nb_Lot_Cmb_Plaq"); } }
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