using System;

namespace vivael
{
	public class data_wslongdistance : DataSource
	{
		public data_wslongdistance() { Table_name = i.name = "wslongdistance"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Description; public string Description { get { return _Description; } set { Set(ref _Description, value, "Description"); } }

	}
}