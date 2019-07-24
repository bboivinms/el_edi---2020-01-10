using System;

namespace vivael
{
	public class data_glsgrb : DataSource
	{
		public data_glsgrb() { Table_name = i.name = "glsgrb"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }

	}
}