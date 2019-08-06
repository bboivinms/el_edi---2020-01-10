using System;

namespace vivael
{
	public class data_infoheader : DataSource
	{
		public data_infoheader() { Table_name = i.name = "infoheader"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Ponum; public string Ponum { get { return _Ponum; } set { Set(ref _Ponum, value, "Ponum"); } }
		private string _Fournipo; public string Fournipo { get { return _Fournipo; } set { Set(ref _Fournipo, value, "Fournipo"); } }
		private DateTime? _Dateinfo; public DateTime? Dateinfo { get { return _Dateinfo; } set { Set(ref _Dateinfo, value, "Dateinfo"); } }
		private string _Client_Name; public string Client_Name { get { return _Client_Name; } set { Set(ref _Client_Name, value, "Client_Name"); } }
		private string _Client_Add; public string Client_Add { get { return _Client_Add; } set { Set(ref _Client_Add, value, "Client_Add"); } }
		private DateTime? _Date_Requis; public DateTime? Date_Requis { get { return _Date_Requis; } set { Set(ref _Date_Requis, value, "Date_Requis"); } }
		private DateTime? _Date_Commande; public DateTime? Date_Commande { get { return _Date_Commande; } set { Set(ref _Date_Commande, value, "Date_Commande"); } }
		private string _Status; public string Status { get { return _Status; } set { Set(ref _Status, value, "Status"); } }
		private string _Tempseval; public string Tempseval { get { return _Tempseval; } set { Set(ref _Tempseval, value, "Tempseval"); } }
		private string _Prodcode; public string Prodcode { get { return _Prodcode; } set { Set(ref _Prodcode, value, "Prodcode"); } }
		private string _Idprod; public string Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private long? _Qty; public long? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private string _Description; public string Description { get { return _Description; } set { Set(ref _Description, value, "Description"); } }
		private string _Commande; public string Commande { get { return _Commande; } set { Set(ref _Commande, value, "Commande"); } }
		private DateTime? _Approdate; public DateTime? Approdate { get { return _Approdate; } set { Set(ref _Approdate, value, "Approdate"); } }
		private string _Approtime; public string Approtime { get { return _Approtime; } set { Set(ref _Approtime, value, "Approtime"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Fournisseur; public string Fournisseur { get { return _Fournisseur; } set { Set(ref _Fournisseur, value, "Fournisseur"); } }
		private string _Fourniident; public string Fourniident { get { return _Fourniident; } set { Set(ref _Fourniident, value, "Fourniident"); } }
		private DateTime? _Datefourni; public DateTime? Datefourni { get { return _Datefourni; } set { Set(ref _Datefourni, value, "Datefourni"); } }
		private string _Heurefourni; public string Heurefourni { get { return _Heurefourni; } set { Set(ref _Heurefourni, value, "Heurefourni"); } }
		private byte? _Envoifourni; public byte? Envoifourni { get { return _Envoifourni; } set { Set(ref _Envoifourni, value, "Envoifourni"); } }
		private DateTime? _Dateenvoi; public DateTime? Dateenvoi { get { return _Dateenvoi; } set { Set(ref _Dateenvoi, value, "Dateenvoi"); } }
		private string _Refpo; public string Refpo { get { return _Refpo; } set { Set(ref _Refpo, value, "Refpo"); } }
		private decimal? _Tempstotal; public decimal? Tempstotal { get { return _Tempstotal; } set { Set(ref _Tempstotal, value, "Tempstotal"); } }
		private bool? _Envoificher; public bool? Envoificher { get { return _Envoificher; } set { Set(ref _Envoificher, value, "Envoificher"); } }
		private bool? _Repeatex; public bool? Repeatex { get { return _Repeatex; } set { Set(ref _Repeatex, value, "Repeatex"); } }
		private bool? _Envoifilms; public bool? Envoifilms { get { return _Envoifilms; } set { Set(ref _Envoifilms, value, "Envoifilms"); } }
		private DateTime? _Date1; public DateTime? Date1 { get { return _Date1; } set { Set(ref _Date1, value, "Date1"); } }
		private string _Heure1; public string Heure1 { get { return _Heure1; } set { Set(ref _Heure1, value, "Heure1"); } }
		private string _Sortie; public string Sortie { get { return _Sortie; } set { Set(ref _Sortie, value, "Sortie"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dtet; public DateTime? Cr_Dtet { get { return _Cr_Dtet; } set { Set(ref _Cr_Dtet, value, "Cr_Dtet"); } }
		private string _Sortiepo; public string Sortiepo { get { return _Sortiepo; } set { Set(ref _Sortiepo, value, "Sortiepo"); } }
		private DateTime? _Sortiedate; public DateTime? Sortiedate { get { return _Sortiedate; } set { Set(ref _Sortiedate, value, "Sortiedate"); } }
		private string _Sortieheure; public string Sortieheure { get { return _Sortieheure; } set { Set(ref _Sortieheure, value, "Sortieheure"); } }
		private string _Fournifilms; public string Fournifilms { get { return _Fournifilms; } set { Set(ref _Fournifilms, value, "Fournifilms"); } }

	}
}