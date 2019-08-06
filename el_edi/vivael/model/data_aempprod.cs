using System;

namespace vivael
{
	public class data_aempprod : DataSource
	{
		public data_aempprod() { Table_name = i.name = "aempprod"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _No; public string No { get { return _No; } set { Set(ref _No, value, "No"); } }
		private string _Nom; public string Nom { get { return _Nom; } set { Set(ref _Nom, value, "Nom"); } }
		private decimal? _Tauxhor; public decimal? Tauxhor { get { return _Tauxhor; } set { Set(ref _Tauxhor, value, "Tauxhor"); } }
		private string _Poste; public string Poste { get { return _Poste; } set { Set(ref _Poste, value, "Poste"); } }
		private string _Quart; public string Quart { get { return _Quart; } set { Set(ref _Quart, value, "Quart"); } }
		private string _Note; public string Note { get { return _Note; } set { Set(ref _Note, value, "Note"); } }
		private bool? _Inactif; public bool? Inactif { get { return _Inactif; } set { Set(ref _Inactif, value, "Inactif"); } }
		private bool? _Caltemps; public bool? Caltemps { get { return _Caltemps; } set { Set(ref _Caltemps, value, "Caltemps"); } }
		private decimal? _Nbrhrs; public decimal? Nbrhrs { get { return _Nbrhrs; } set { Set(ref _Nbrhrs, value, "Nbrhrs"); } }
		private int? _Password; public int? Password { get { return _Password; } set { Set(ref _Password, value, "Password"); } }
		private bool? _Ajusteur; public bool? Ajusteur { get { return _Ajusteur; } set { Set(ref _Ajusteur, value, "Ajusteur"); } }
		private string _Idflag; public string Idflag { get { return _Idflag; } set { Set(ref _Idflag, value, "Idflag"); } }

	}
}