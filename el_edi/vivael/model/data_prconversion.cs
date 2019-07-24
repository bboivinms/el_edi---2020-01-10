using System;

namespace vivael
{
	public class data_prconversion : DataSource
	{
		public data_prconversion() { Table_name = i.name = "prconversion"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Decimal; public string Decimal { get { return _Decimal; } set { Set(ref _Decimal, value, "Decimal"); } }
		private string _Pouce; public string Pouce { get { return _Pouce; } set { Set(ref _Pouce, value, "Pouce"); } }

	}
}