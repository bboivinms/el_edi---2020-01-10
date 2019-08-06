using System;

namespace vivael
{
	public class data_wscountry : DataSource
	{
		public data_wscountry() { Table_name = i.name = "wscountry"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private string _Flag; public string Flag { get { return _Flag; } set { Set(ref _Flag, value, "Flag"); } }

	}
}