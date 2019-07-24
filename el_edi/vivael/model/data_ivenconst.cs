using System;

namespace vivael
{
	public class data_ivenconst : DataSource
	{
		public data_ivenconst() { Table_name = i.name = "ivenconst"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Construct_Dessin; public string Construct_Dessin { get { return _Construct_Dessin; } set { Set(ref _Construct_Dessin, value, "Construct_Dessin"); } }

	}
}