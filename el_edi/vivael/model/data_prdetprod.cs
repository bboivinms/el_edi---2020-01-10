using System;

namespace vivael
{
	public class data_prdetprod : DataSource
	{
		public data_prdetprod() { Table_name = i.name = "prdetprod"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idfab; public int? Idfab { get { return _Idfab; } set { Set(ref _Idfab, value, "Idfab"); } }
		private int? _Idphase; public int? Idphase { get { return _Idphase; } set { Set(ref _Idphase, value, "Idphase"); } }
		private string _Int_Ext; public string Int_Ext { get { return _Int_Ext; } set { Set(ref _Int_Ext, value, "Int_Ext"); } }
		private DateTime? _Datecel; public DateTime? Datecel { get { return _Datecel; } set { Set(ref _Datecel, value, "Datecel"); } }
		private string _Nopoachat; public string Nopoachat { get { return _Nopoachat; } set { Set(ref _Nopoachat, value, "Nopoachat"); } }
		private decimal? _Tempsest; public decimal? Tempsest { get { return _Tempsest; } set { Set(ref _Tempsest, value, "Tempsest"); } }
		private int? _Idmach; public int? Idmach { get { return _Idmach; } set { Set(ref _Idmach, value, "Idmach"); } }
		private int? _Idmat; public int? Idmat { get { return _Idmat; } set { Set(ref _Idmat, value, "Idmat"); } }
		private string _Notefab; public string Notefab { get { return _Notefab; } set { Set(ref _Notefab, value, "Notefab"); } }
		private decimal? _T_Reel; public decimal? T_Reel { get { return _T_Reel; } set { Set(ref _T_Reel, value, "T_Reel"); } }
		private decimal? _P_Complet; public decimal? P_Complet { get { return _P_Complet; } set { Set(ref _P_Complet, value, "P_Complet"); } }
		private int? _Idmach1; public int? Idmach1 { get { return _Idmach1; } set { Set(ref _Idmach1, value, "Idmach1"); } }
		private int? _Idmach2; public int? Idmach2 { get { return _Idmach2; } set { Set(ref _Idmach2, value, "Idmach2"); } }
		private int? _Idmach3; public int? Idmach3 { get { return _Idmach3; } set { Set(ref _Idmach3, value, "Idmach3"); } }
		private int? _Idmat1; public int? Idmat1 { get { return _Idmat1; } set { Set(ref _Idmat1, value, "Idmat1"); } }
		private int? _Idmat2; public int? Idmat2 { get { return _Idmat2; } set { Set(ref _Idmat2, value, "Idmat2"); } }
		private int? _Idmat3; public int? Idmat3 { get { return _Idmat3; } set { Set(ref _Idmat3, value, "Idmat3"); } }
		private bool? _Defaut1; public bool? Defaut1 { get { return _Defaut1; } set { Set(ref _Defaut1, value, "Defaut1"); } }
		private bool? _Defaut2; public bool? Defaut2 { get { return _Defaut2; } set { Set(ref _Defaut2, value, "Defaut2"); } }
		private bool? _Defaut3; public bool? Defaut3 { get { return _Defaut3; } set { Set(ref _Defaut3, value, "Defaut3"); } }
		private int? _Idco1; public int? Idco1 { get { return _Idco1; } set { Set(ref _Idco1, value, "Idco1"); } }
		private int? _Idco2; public int? Idco2 { get { return _Idco2; } set { Set(ref _Idco2, value, "Idco2"); } }
		private int? _Idco3; public int? Idco3 { get { return _Idco3; } set { Set(ref _Idco3, value, "Idco3"); } }
		private int? _Idco; public int? Idco { get { return _Idco; } set { Set(ref _Idco, value, "Idco"); } }
		private int? _Idpg; public int? Idpg { get { return _Idpg; } set { Set(ref _Idpg, value, "Idpg"); } }
		private int? _Idpg1; public int? Idpg1 { get { return _Idpg1; } set { Set(ref _Idpg1, value, "Idpg1"); } }
		private int? _Idpg2; public int? Idpg2 { get { return _Idpg2; } set { Set(ref _Idpg2, value, "Idpg2"); } }
		private int? _Idpg3; public int? Idpg3 { get { return _Idpg3; } set { Set(ref _Idpg3, value, "Idpg3"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private DateTime? _Date_Termine; public DateTime? Date_Termine { get { return _Date_Termine; } set { Set(ref _Date_Termine, value, "Date_Termine"); } }
		private bool? _Cedule; public bool? Cedule { get { return _Cedule; } set { Set(ref _Cedule, value, "Cedule"); } }
		private decimal? _Estime; public decimal? Estime { get { return _Estime; } set { Set(ref _Estime, value, "Estime"); } }
		private decimal? _Estime1; public decimal? Estime1 { get { return _Estime1; } set { Set(ref _Estime1, value, "Estime1"); } }
		private decimal? _Estime2; public decimal? Estime2 { get { return _Estime2; } set { Set(ref _Estime2, value, "Estime2"); } }
		private decimal? _Estime3; public decimal? Estime3 { get { return _Estime3; } set { Set(ref _Estime3, value, "Estime3"); } }
		private bool? _Lastfab; public bool? Lastfab { get { return _Lastfab; } set { Set(ref _Lastfab, value, "Lastfab"); } }
		private int? _Ordre; public int? Ordre { get { return _Ordre; } set { Set(ref _Ordre, value, "Ordre"); } }
		private int? _Setup; public int? Setup { get { return _Setup; } set { Set(ref _Setup, value, "Setup"); } }
		private int? _Setup1; public int? Setup1 { get { return _Setup1; } set { Set(ref _Setup1, value, "Setup1"); } }
		private int? _Setup2; public int? Setup2 { get { return _Setup2; } set { Set(ref _Setup2, value, "Setup2"); } }
		private int? _Setup3; public int? Setup3 { get { return _Setup3; } set { Set(ref _Setup3, value, "Setup3"); } }

	}
}