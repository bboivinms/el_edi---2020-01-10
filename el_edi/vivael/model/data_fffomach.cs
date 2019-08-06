using System;

namespace vivael
{
	public class data_fffomach : DataSource
	{
		public data_fffomach() { Table_name = i.name = "fffomach"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Nomach; public string Nomach { get { return _Nomach; } set { Set(ref _Nomach, value, "Nomach"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private int? _Idsupp; public int? Idsupp { get { return _Idsupp; } set { Set(ref _Idsupp, value, "Idsupp"); } }
		private string _Modele; public string Modele { get { return _Modele; } set { Set(ref _Modele, value, "Modele"); } }
		private short? _Annee; public short? Annee { get { return _Annee; } set { Set(ref _Annee, value, "Annee"); } }
		private string _Marques; public string Marques { get { return _Marques; } set { Set(ref _Marques, value, "Marques"); } }
		private string _Typemach; public string Typemach { get { return _Typemach; } set { Set(ref _Typemach, value, "Typemach"); } }
		private decimal? _Flomin; public decimal? Flomin { get { return _Flomin; } set { Set(ref _Flomin, value, "Flomin"); } }
		private decimal? _Flomax; public decimal? Flomax { get { return _Flomax; } set { Set(ref _Flomax, value, "Flomax"); } }
		private decimal? _Flamin; public decimal? Flamin { get { return _Flamin; } set { Set(ref _Flamin, value, "Flamin"); } }
		private decimal? _Flamax; public decimal? Flamax { get { return _Flamax; } set { Set(ref _Flamax, value, "Flamax"); } }
		private decimal? _Epaismin; public decimal? Epaismin { get { return _Epaismin; } set { Set(ref _Epaismin, value, "Epaismin"); } }
		private decimal? _Epaismax; public decimal? Epaismax { get { return _Epaismax; } set { Set(ref _Epaismax, value, "Epaismax"); } }
		private decimal? _Plomin; public decimal? Plomin { get { return _Plomin; } set { Set(ref _Plomin, value, "Plomin"); } }
		private decimal? _Plomax; public decimal? Plomax { get { return _Plomax; } set { Set(ref _Plomax, value, "Plomax"); } }
		private decimal? _Plamin; public decimal? Plamin { get { return _Plamin; } set { Set(ref _Plamin, value, "Plamin"); } }
		private decimal? _Plamax; public decimal? Plamax { get { return _Plamax; } set { Set(ref _Plamax, value, "Plamax"); } }
		private decimal? _Hautmin; public decimal? Hautmin { get { return _Hautmin; } set { Set(ref _Hautmin, value, "Hautmin"); } }
		private decimal? _Hautmax; public decimal? Hautmax { get { return _Hautmax; } set { Set(ref _Hautmax, value, "Hautmax"); } }
		private decimal? _Vitmax; public decimal? Vitmax { get { return _Vitmax; } set { Set(ref _Vitmax, value, "Vitmax"); } }
		private byte? _Nbcoulmax; public byte? Nbcoulmax { get { return _Nbcoulmax; } set { Set(ref _Nbcoulmax, value, "Nbcoulmax"); } }
		private string _Cacarton; public string Cacarton { get { return _Cacarton; } set { Set(ref _Cacarton, value, "Cacarton"); } }
		private string _Infomachfo; public string Infomachfo { get { return _Infomachfo; } set { Set(ref _Infomachfo, value, "Infomachfo"); } }
		private bool? _Flute_A; public bool? Flute_A { get { return _Flute_A; } set { Set(ref _Flute_A, value, "Flute_A"); } }
		private bool? _Flute_B; public bool? Flute_B { get { return _Flute_B; } set { Set(ref _Flute_B, value, "Flute_B"); } }
		private bool? _Flute_C; public bool? Flute_C { get { return _Flute_C; } set { Set(ref _Flute_C, value, "Flute_C"); } }
		private bool? _Flute_D; public bool? Flute_D { get { return _Flute_D; } set { Set(ref _Flute_D, value, "Flute_D"); } }
		private bool? _Flute_E; public bool? Flute_E { get { return _Flute_E; } set { Set(ref _Flute_E, value, "Flute_E"); } }
		private bool? _Flute_F; public bool? Flute_F { get { return _Flute_F; } set { Set(ref _Flute_F, value, "Flute_F"); } }
		private bool? _Flute_N; public bool? Flute_N { get { return _Flute_N; } set { Set(ref _Flute_N, value, "Flute_N"); } }
		private bool? _Flute_S; public bool? Flute_S { get { return _Flute_S; } set { Set(ref _Flute_S, value, "Flute_S"); } }
		private bool? _Flute_Ac; public bool? Flute_Ac { get { return _Flute_Ac; } set { Set(ref _Flute_Ac, value, "Flute_Ac"); } }
		private bool? _Flute_Bc; public bool? Flute_Bc { get { return _Flute_Bc; } set { Set(ref _Flute_Bc, value, "Flute_Bc"); } }
		private bool? _Flute_Be; public bool? Flute_Be { get { return _Flute_Be; } set { Set(ref _Flute_Be, value, "Flute_Be"); } }
		private bool? _Flute_Ec; public bool? Flute_Ec { get { return _Flute_Ec; } set { Set(ref _Flute_Ec, value, "Flute_Ec"); } }
		private bool? _Flute_Ed; public bool? Flute_Ed { get { return _Flute_Ed; } set { Set(ref _Flute_Ed, value, "Flute_Ed"); } }
		private bool? _Flute_Acc; public bool? Flute_Acc { get { return _Flute_Acc; } set { Set(ref _Flute_Acc, value, "Flute_Acc"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dte; public DateTime? Mod_Dte { get { return _Mod_Dte; } set { Set(ref _Mod_Dte, value, "Mod_Dte"); } }
		private string _Noserie; public string Noserie { get { return _Noserie; } set { Set(ref _Noserie, value, "Noserie"); } }
		private decimal? _Cout_Min; public decimal? Cout_Min { get { return _Cout_Min; } set { Set(ref _Cout_Min, value, "Cout_Min"); } }
		private decimal? _Cout_Max; public decimal? Cout_Max { get { return _Cout_Max; } set { Set(ref _Cout_Max, value, "Cout_Max"); } }
		private decimal? _Cout_Moyen; public decimal? Cout_Moyen { get { return _Cout_Moyen; } set { Set(ref _Cout_Moyen, value, "Cout_Moyen"); } }
		private bool? _Impression; public bool? Impression { get { return _Impression; } set { Set(ref _Impression, value, "Impression"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private int? _Hrsprod; public int? Hrsprod { get { return _Hrsprod; } set { Set(ref _Hrsprod, value, "Hrsprod"); } }
		private bool? _Horsusage; public bool? Horsusage { get { return _Horsusage; } set { Set(ref _Horsusage, value, "Horsusage"); } }
		private DateTime? _Date_Prevu; public DateTime? Date_Prevu { get { return _Date_Prevu; } set { Set(ref _Date_Prevu, value, "Date_Prevu"); } }
		private string _Loc_Resv; public string Loc_Resv { get { return _Loc_Resv; } set { Set(ref _Loc_Resv, value, "Loc_Resv"); } }
		private decimal? _Setcoul; public decimal? Setcoul { get { return _Setcoul; } set { Set(ref _Setcoul, value, "Setcoul"); } }
		private decimal? _Setformat; public decimal? Setformat { get { return _Setformat; } set { Set(ref _Setformat, value, "Setformat"); } }
		private decimal? _Setpapier; public decimal? Setpapier { get { return _Setpapier; } set { Set(ref _Setpapier, value, "Setpapier"); } }
		private decimal? _Setconst; public decimal? Setconst { get { return _Setconst; } set { Set(ref _Setconst, value, "Setconst"); } }
		private decimal? _Setfen; public decimal? Setfen { get { return _Setfen; } set { Set(ref _Setfen, value, "Setfen"); } }

	}
}