using System;

namespace vivael
{
	public class data_wscity : DataSource
	{
		public data_wscity() { Table_name = i.name = "wscity"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private string _Countrycode; public string Countrycode { get { return _Countrycode; } set { Set(ref _Countrycode, value, "Countrycode"); } }

	}
}