using System;

namespace vivael
{
	public class data_glbudget : DataSource
	{
		public data_glbudget() { Table_name = i.name = "glbudget"; i.primary_1 = "year"; i.primary_2 = "idglaccnt"; i.primary_3 = null; isFoxpro = true; }

		private int? _Ident; public int? Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private short _Year; public short Year { get { return _Year; } set { Set(ref _Year, value, "Year"); } }
		private int _Idglaccnt; public int Idglaccnt { get { return _Idglaccnt; } set { Set(ref _Idglaccnt, value, "Idglaccnt"); } }
		private decimal? _Mntper1; public decimal? Mntper1 { get { return _Mntper1; } set { Set(ref _Mntper1, value, "Mntper1"); } }
		private decimal? _Mntper2; public decimal? Mntper2 { get { return _Mntper2; } set { Set(ref _Mntper2, value, "Mntper2"); } }
		private decimal? _Mntper3; public decimal? Mntper3 { get { return _Mntper3; } set { Set(ref _Mntper3, value, "Mntper3"); } }
		private decimal? _Mntper4; public decimal? Mntper4 { get { return _Mntper4; } set { Set(ref _Mntper4, value, "Mntper4"); } }
		private decimal? _Mntper5; public decimal? Mntper5 { get { return _Mntper5; } set { Set(ref _Mntper5, value, "Mntper5"); } }
		private decimal? _Mntper6; public decimal? Mntper6 { get { return _Mntper6; } set { Set(ref _Mntper6, value, "Mntper6"); } }
		private decimal? _Mntper7; public decimal? Mntper7 { get { return _Mntper7; } set { Set(ref _Mntper7, value, "Mntper7"); } }
		private decimal? _Mntper8; public decimal? Mntper8 { get { return _Mntper8; } set { Set(ref _Mntper8, value, "Mntper8"); } }
		private decimal? _Mntper9; public decimal? Mntper9 { get { return _Mntper9; } set { Set(ref _Mntper9, value, "Mntper9"); } }
		private decimal? _Mntper10; public decimal? Mntper10 { get { return _Mntper10; } set { Set(ref _Mntper10, value, "Mntper10"); } }
		private decimal? _Mntper11; public decimal? Mntper11 { get { return _Mntper11; } set { Set(ref _Mntper11, value, "Mntper11"); } }
		private decimal? _Mntper12; public decimal? Mntper12 { get { return _Mntper12; } set { Set(ref _Mntper12, value, "Mntper12"); } }
		private decimal? _Mntglobal; public decimal? Mntglobal { get { return _Mntglobal; } set { Set(ref _Mntglobal, value, "Mntglobal"); } }

	}
}