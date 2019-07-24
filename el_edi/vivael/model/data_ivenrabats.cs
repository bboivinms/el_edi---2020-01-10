using System;

namespace vivael
{
	public class data_ivenrabats : DataSource
	{
		public data_ivenrabats() { Table_name = i.name = "ivenrabats"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }

	}
}