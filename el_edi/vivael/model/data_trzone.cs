using System;

namespace vivael
{
	public class data_trzone : DataSource
	{
		public data_trzone() { Table_name = i.name = "trzone"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }

	}
}