using System;

namespace vivael
{
	public class data_iveqcotrep : DataSource
	{
		public data_iveqcotrep() { Table_name = i.name = "iveqcotrep"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
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
		private string _Fini; public string Fini { get { return _Fini; } set { Set(ref _Fini, value, "Fini"); } }
		private int? _Nblarge; public int? Nblarge { get { return _Nblarge; } set { Set(ref _Nblarge, value, "Nblarge"); } }
		private string _Qteunite; public string Qteunite { get { return _Qteunite; } set { Set(ref _Qteunite, value, "Qteunite"); } }
		private decimal? _N_Largeur; public decimal? N_Largeur { get { return _N_Largeur; } set { Set(ref _N_Largeur, value, "N_Largeur"); } }
		private decimal? _N_Hauteur; public decimal? N_Hauteur { get { return _N_Hauteur; } set { Set(ref _N_Hauteur, value, "N_Hauteur"); } }
		private int? _Pliage; public int? Pliage { get { return _Pliage; } set { Set(ref _Pliage, value, "Pliage"); } }
		private string _Diam_Core; public string Diam_Core { get { return _Diam_Core; } set { Set(ref _Diam_Core, value, "Diam_Core"); } }
		private string _Diam_Core_Oth; public string Diam_Core_Oth { get { return _Diam_Core_Oth; } set { Set(ref _Diam_Core_Oth, value, "Diam_Core_Oth"); } }
		private string _Diam_Ext; public string Diam_Ext { get { return _Diam_Ext; } set { Set(ref _Diam_Ext, value, "Diam_Ext"); } }
		private string _Diam_Ext_Oth; public string Diam_Ext_Oth { get { return _Diam_Ext_Oth; } set { Set(ref _Diam_Ext_Oth, value, "Diam_Ext_Oth"); } }
		private string _Format; public string Format { get { return _Format; } set { Set(ref _Format, value, "Format"); } }
		private string _Appli_Rouleau; public string Appli_Rouleau { get { return _Appli_Rouleau; } set { Set(ref _Appli_Rouleau, value, "Appli_Rouleau"); } }
		private decimal? _Larg_1_Etq; public decimal? Larg_1_Etq { get { return _Larg_1_Etq; } set { Set(ref _Larg_1_Etq, value, "Larg_1_Etq"); } }
		private byte? _Larg_Varie; public byte? Larg_Varie { get { return _Larg_Varie; } set { Set(ref _Larg_Varie, value, "Larg_Varie"); } }
		private decimal? _Larg_Varie_Po; public decimal? Larg_Varie_Po { get { return _Larg_Varie_Po; } set { Set(ref _Larg_Varie_Po, value, "Larg_Varie_Po"); } }
		private decimal? _Larg_Varie_Min; public decimal? Larg_Varie_Min { get { return _Larg_Varie_Min; } set { Set(ref _Larg_Varie_Min, value, "Larg_Varie_Min"); } }
		private decimal? _Larg_Varie_Max; public decimal? Larg_Varie_Max { get { return _Larg_Varie_Max; } set { Set(ref _Larg_Varie_Max, value, "Larg_Varie_Max"); } }
		private decimal? _Haut_1_Etq; public decimal? Haut_1_Etq { get { return _Haut_1_Etq; } set { Set(ref _Haut_1_Etq, value, "Haut_1_Etq"); } }
		private byte? _Haut_Varie; public byte? Haut_Varie { get { return _Haut_Varie; } set { Set(ref _Haut_Varie, value, "Haut_Varie"); } }
		private decimal? _Haut_Varie_Po; public decimal? Haut_Varie_Po { get { return _Haut_Varie_Po; } set { Set(ref _Haut_Varie_Po, value, "Haut_Varie_Po"); } }
		private decimal? _Haut_Varie_Min; public decimal? Haut_Varie_Min { get { return _Haut_Varie_Min; } set { Set(ref _Haut_Varie_Min, value, "Haut_Varie_Min"); } }
		private decimal? _Haut_Varie_Max; public decimal? Haut_Varie_Max { get { return _Haut_Varie_Max; } set { Set(ref _Haut_Varie_Max, value, "Haut_Varie_Max"); } }
		private string _Materiel; public string Materiel { get { return _Materiel; } set { Set(ref _Materiel, value, "Materiel"); } }
		private string _Adhesif; public string Adhesif { get { return _Adhesif; } set { Set(ref _Adhesif, value, "Adhesif"); } }
		private string _Temperature; public string Temperature { get { return _Temperature; } set { Set(ref _Temperature, value, "Temperature"); } }
		private string _Appli_Sur; public string Appli_Sur { get { return _Appli_Sur; } set { Set(ref _Appli_Sur, value, "Appli_Sur"); } }
		private string _Appli_Sur_Oth; public string Appli_Sur_Oth { get { return _Appli_Sur_Oth; } set { Set(ref _Appli_Sur_Oth, value, "Appli_Sur_Oth"); } }
		private string _Type_Equip; public string Type_Equip { get { return _Type_Equip; } set { Set(ref _Type_Equip, value, "Type_Equip"); } }
		private string _Type_Equip_Oth; public string Type_Equip_Oth { get { return _Type_Equip_Oth; } set { Set(ref _Type_Equip_Oth, value, "Type_Equip_Oth"); } }
		private string _Nbcoulrecto; public string Nbcoulrecto { get { return _Nbcoulrecto; } set { Set(ref _Nbcoulrecto, value, "Nbcoulrecto"); } }
		private string _Nbcoulrecto_Oth; public string Nbcoulrecto_Oth { get { return _Nbcoulrecto_Oth; } set { Set(ref _Nbcoulrecto_Oth, value, "Nbcoulrecto_Oth"); } }
		private string _Impr_Pms; public string Impr_Pms { get { return _Impr_Pms; } set { Set(ref _Impr_Pms, value, "Impr_Pms"); } }
		private string _Impr_Pms_Oth; public string Impr_Pms_Oth { get { return _Impr_Pms_Oth; } set { Set(ref _Impr_Pms_Oth, value, "Impr_Pms_Oth"); } }
		private string _Nbcoulverso1; public string Nbcoulverso1 { get { return _Nbcoulverso1; } set { Set(ref _Nbcoulverso1, value, "Nbcoulverso1"); } }
		private string _Nbcoulverso2; public string Nbcoulverso2 { get { return _Nbcoulverso2; } set { Set(ref _Nbcoulverso2, value, "Nbcoulverso2"); } }
		private string _Impr_Buttcut; public string Impr_Buttcut { get { return _Impr_Buttcut; } set { Set(ref _Impr_Buttcut, value, "Impr_Buttcut"); } }
		private string _Num_Pre_Impr; public string Num_Pre_Impr { get { return _Num_Pre_Impr; } set { Set(ref _Num_Pre_Impr, value, "Num_Pre_Impr"); } }
		private string _Finiscoul; public string Finiscoul { get { return _Finiscoul; } set { Set(ref _Finiscoul, value, "Finiscoul"); } }
		private string _Vernis_Lamin; public string Vernis_Lamin { get { return _Vernis_Lamin; } set { Set(ref _Vernis_Lamin, value, "Vernis_Lamin"); } }
		private string _Cond_Travail; public string Cond_Travail { get { return _Cond_Travail; } set { Set(ref _Cond_Travail, value, "Cond_Travail"); } }
		private string _Nb_Lot_Cmb; public string Nb_Lot_Cmb { get { return _Nb_Lot_Cmb; } set { Set(ref _Nb_Lot_Cmb, value, "Nb_Lot_Cmb"); } }
		private string _Nb_Lot_Cmb_Oth; public string Nb_Lot_Cmb_Oth { get { return _Nb_Lot_Cmb_Oth; } set { Set(ref _Nb_Lot_Cmb_Oth, value, "Nb_Lot_Cmb_Oth"); } }
		private string _Nb_Lot_Cmb_Coul; public string Nb_Lot_Cmb_Coul { get { return _Nb_Lot_Cmb_Coul; } set { Set(ref _Nb_Lot_Cmb_Coul, value, "Nb_Lot_Cmb_Coul"); } }
		private string _Nb_Lot_Cmb_Plaq; public string Nb_Lot_Cmb_Plaq { get { return _Nb_Lot_Cmb_Plaq; } set { Set(ref _Nb_Lot_Cmb_Plaq, value, "Nb_Lot_Cmb_Plaq"); } }
		private string _Perforation; public string Perforation { get { return _Perforation; } set { Set(ref _Perforation, value, "Perforation"); } }
		private string _Perf_Spec; public string Perf_Spec { get { return _Perf_Spec; } set { Set(ref _Perf_Spec, value, "Perf_Spec"); } }
		private string _Perf_Spec_Oth; public string Perf_Spec_Oth { get { return _Perf_Spec_Oth; } set { Set(ref _Perf_Spec_Oth, value, "Perf_Spec_Oth"); } }
		private string _Split; public string Split { get { return _Split; } set { Set(ref _Split, value, "Split"); } }
		private string _Instr_Spec; public string Instr_Spec { get { return _Instr_Spec; } set { Set(ref _Instr_Spec, value, "Instr_Spec"); } }
		private string _Instr_Spec_Oth; public string Instr_Spec_Oth { get { return _Instr_Spec_Oth; } set { Set(ref _Instr_Spec_Oth, value, "Instr_Spec_Oth"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Gestion_Invtr; public string Gestion_Invtr { get { return _Gestion_Invtr; } set { Set(ref _Gestion_Invtr, value, "Gestion_Invtr"); } }
		private string _Qte_Annuel_Cons; public string Qte_Annuel_Cons { get { return _Qte_Annuel_Cons; } set { Set(ref _Qte_Annuel_Cons, value, "Qte_Annuel_Cons"); } }
		private string _Qte_Comm_Freq; public string Qte_Comm_Freq { get { return _Qte_Comm_Freq; } set { Set(ref _Qte_Comm_Freq, value, "Qte_Comm_Freq"); } }
		private string _Prix_Comm_Qte; public string Prix_Comm_Qte { get { return _Prix_Comm_Qte; } set { Set(ref _Prix_Comm_Qte, value, "Prix_Comm_Qte"); } }
		private string _Nom_Imp_Tt; public string Nom_Imp_Tt { get { return _Nom_Imp_Tt; } set { Set(ref _Nom_Imp_Tt, value, "Nom_Imp_Tt"); } }
		private string _Modele_Imp_Tt; public string Modele_Imp_Tt { get { return _Modele_Imp_Tt; } set { Set(ref _Modele_Imp_Tt, value, "Modele_Imp_Tt"); } }
		private string _Larg_Rub_Thermal; public string Larg_Rub_Thermal { get { return _Larg_Rub_Thermal; } set { Set(ref _Larg_Rub_Thermal, value, "Larg_Rub_Thermal"); } }
		private string _Long_Rub_Thermal; public string Long_Rub_Thermal { get { return _Long_Rub_Thermal; } set { Set(ref _Long_Rub_Thermal, value, "Long_Rub_Thermal"); } }
		private string _Qualite_Rub_Thermal; public string Qualite_Rub_Thermal { get { return _Qualite_Rub_Thermal; } set { Set(ref _Qualite_Rub_Thermal, value, "Qualite_Rub_Thermal"); } }
		private string _Couleur_Rub_Thermal; public string Couleur_Rub_Thermal { get { return _Couleur_Rub_Thermal; } set { Set(ref _Couleur_Rub_Thermal, value, "Couleur_Rub_Thermal"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
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