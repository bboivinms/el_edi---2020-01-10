using System;

namespace vivael
{
	public class data_ivenco : DataSource
	{
		public data_ivenco() { Table_name = i.name = "ivenco"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }

	}
}