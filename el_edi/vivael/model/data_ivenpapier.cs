using System;

namespace vivael
{
	public class data_ivenpapier : DataSource
	{
		public data_ivenpapier() { Table_name = i.name = "ivenpapier"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }

	}
}