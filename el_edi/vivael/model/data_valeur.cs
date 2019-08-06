using System;

namespace vivael
{
	public class data_valeur : DataSource
	{
		public data_valeur() { Table_name = i.name = "valeur"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private int? _Champs1; public int? Champs1 { get { return _Champs1; } set { Set(ref _Champs1, value, "Champs1"); } }
		private int? _Champs2; public int? Champs2 { get { return _Champs2; } set { Set(ref _Champs2, value, "Champs2"); } }
		private int? _Champs3; public int? Champs3 { get { return _Champs3; } set { Set(ref _Champs3, value, "Champs3"); } }

	}
}