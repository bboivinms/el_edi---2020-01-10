using System;

namespace vivael
{
	public class data_appurd : DataSource
	{
		public data_appurd() { Table_name = i.name = "appurd"; i.primary_1 = "ident"; i.primary_2 = "seq"; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Seq; public int Seq { get { return _Seq; } set { Set(ref _Seq, value, "Seq"); } }
		private int? _Glaccnt; public int? Glaccnt { get { return _Glaccnt; } set { Set(ref _Glaccnt, value, "Glaccnt"); } }
		private decimal? _Amount; public decimal? Amount { get { return _Amount; } set { Set(ref _Amount, value, "Amount"); } }

	}
}