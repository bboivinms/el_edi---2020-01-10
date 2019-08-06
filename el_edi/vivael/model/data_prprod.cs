using System;

namespace vivael
{
	public class data_prprod : DataSource
	{
		public data_prprod() { Table_name = i.name = "prprod"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Prcode; public string Prcode { get { return _Prcode; } set { Set(ref _Prcode, value, "Prcode"); } }
		private int? _Prno; public int? Prno { get { return _Prno; } set { Set(ref _Prno, value, "Prno"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Idclient; public int? Idclient { get { return _Idclient; } set { Set(ref _Idclient, value, "Idclient"); } }
		private string _Prref; public string Prref { get { return _Prref; } set { Set(ref _Prref, value, "Prref"); } }
		private string _Prclientpo; public string Prclientpo { get { return _Prclientpo; } set { Set(ref _Prclientpo, value, "Prclientpo"); } }
		private DateTime? _Prreq_Date; public DateTime? Prreq_Date { get { return _Prreq_Date; } set { Set(ref _Prreq_Date, value, "Prreq_Date"); } }
		private bool? _Prdte_Aprv; public bool? Prdte_Aprv { get { return _Prdte_Aprv; } set { Set(ref _Prdte_Aprv, value, "Prdte_Aprv"); } }
		private bool? _Prt_Inv; public bool? Prt_Inv { get { return _Prt_Inv; } set { Set(ref _Prt_Inv, value, "Prt_Inv"); } }
		private bool? _Prliv_Sur_; public bool? Prliv_Sur_ { get { return _Prliv_Sur_; } set { Set(ref _Prliv_Sur_, value, "Prliv_Sur_"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private string _Vend_Name; public string Vend_Name { get { return _Vend_Name; } set { Set(ref _Vend_Name, value, "Vend_Name"); } }
		private string _Vend_Add; public string Vend_Add { get { return _Vend_Add; } set { Set(ref _Vend_Add, value, "Vend_Add"); } }
		private string _Noteprod; public string Noteprod { get { return _Noteprod; } set { Set(ref _Noteprod, value, "Noteprod"); } }
		private long? _Qte; public long? Qte { get { return _Qte; } set { Set(ref _Qte, value, "Qte"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dtet; public DateTime? Cr_Dtet { get { return _Cr_Dtet; } set { Set(ref _Cr_Dtet, value, "Cr_Dtet"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dtet; public DateTime? Mod_Dtet { get { return _Mod_Dtet; } set { Set(ref _Mod_Dtet, value, "Mod_Dtet"); } }
		private long? _Qtettprod; public long? Qtettprod { get { return _Qtettprod; } set { Set(ref _Qtettprod, value, "Qtettprod"); } }
		private bool? _Termine; public bool? Termine { get { return _Termine; } set { Set(ref _Termine, value, "Termine"); } }
		private DateTime? _Dateprevu; public DateTime? Dateprevu { get { return _Dateprevu; } set { Set(ref _Dateprevu, value, "Dateprevu"); } }
		private bool? _Dateprevucheck; public bool? Dateprevucheck { get { return _Dateprevucheck; } set { Set(ref _Dateprevucheck, value, "Dateprevucheck"); } }
		private int? _Idfsc; public int? Idfsc { get { return _Idfsc; } set { Set(ref _Idfsc, value, "Idfsc"); } }
		private string _Approb; public string Approb { get { return _Approb; } set { Set(ref _Approb, value, "Approb"); } }
		private bool? _Rush; public bool? Rush { get { return _Rush; } set { Set(ref _Rush, value, "Rush"); } }
		private string _Prcontact; public string Prcontact { get { return _Prcontact; } set { Set(ref _Prcontact, value, "Prcontact"); } }
		private int? _Prrepeate; public int? Prrepeate { get { return _Prrepeate; } set { Set(ref _Prrepeate, value, "Prrepeate"); } }
		private bool? _Prrepeatm; public bool? Prrepeatm { get { return _Prrepeatm; } set { Set(ref _Prrepeatm, value, "Prrepeatm"); } }
		private bool? _Prinfographie; public bool? Prinfographie { get { return _Prinfographie; } set { Set(ref _Prinfographie, value, "Prinfographie"); } }
		private DateTime? _Prdate_Recep; public DateTime? Prdate_Recep { get { return _Prdate_Recep; } set { Set(ref _Prdate_Recep, value, "Prdate_Recep"); } }
		private DateTime? _Prdate_Envoie; public DateTime? Prdate_Envoie { get { return _Prdate_Envoie; } set { Set(ref _Prdate_Envoie, value, "Prdate_Envoie"); } }
		private DateTime? _Prdate_Envoiemodif; public DateTime? Prdate_Envoiemodif { get { return _Prdate_Envoiemodif; } set { Set(ref _Prdate_Envoiemodif, value, "Prdate_Envoiemodif"); } }
		private DateTime? _Prdate_Approb; public DateTime? Prdate_Approb { get { return _Prdate_Approb; } set { Set(ref _Prdate_Approb, value, "Prdate_Approb"); } }
		private string _Prnoteinfo; public string Prnoteinfo { get { return _Prnoteinfo; } set { Set(ref _Prnoteinfo, value, "Prnoteinfo"); } }
		private int? _Prnoreprod; public int? Prnoreprod { get { return _Prnoreprod; } set { Set(ref _Prnoreprod, value, "Prnoreprod"); } }
		private DateTime? _Prdate_Fin; public DateTime? Prdate_Fin { get { return _Prdate_Fin; } set { Set(ref _Prdate_Fin, value, "Prdate_Fin"); } }
		private bool? _Echantil; public bool? Echantil { get { return _Echantil; } set { Set(ref _Echantil, value, "Echantil"); } }
		private bool? _Mat_Recu; public bool? Mat_Recu { get { return _Mat_Recu; } set { Set(ref _Mat_Recu, value, "Mat_Recu"); } }
		private decimal? _No_Ach_Ass; public decimal? No_Ach_Ass { get { return _No_Ach_Ass; } set { Set(ref _No_Ach_Ass, value, "No_Ach_Ass"); } }
		private DateTime? _Date_Recu; public DateTime? Date_Recu { get { return _Date_Recu; } set { Set(ref _Date_Recu, value, "Date_Recu"); } }

	}
}