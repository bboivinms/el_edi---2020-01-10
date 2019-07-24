using System;

namespace vivael
{
	public class data_appaygl : DataSource
	{
		public data_appaygl() { Table_name = i.name = "appaygl"; i.primary_1 = "ident"; i.primary_2 = "seq"; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Seq; public int Seq { get { return _Seq; } set { Set(ref _Seq, value, "Seq"); } }
		private int? _Glaccnt_Id; public int? Glaccnt_Id { get { return _Glaccnt_Id; } set { Set(ref _Glaccnt_Id, value, "Glaccnt_Id"); } }
		private decimal? _Amount; public decimal? Amount { get { return _Amount; } set { Set(ref _Amount, value, "Amount"); } }

	}
}