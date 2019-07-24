using System;

namespace vivael
{
	public class data_iveqformat : DataSource
	{
		public data_iveqformat() { Table_name = i.name = "iveqformat"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Format_Pic; public string Format_Pic { get { return _Format_Pic; } set { Set(ref _Format_Pic, value, "Format_Pic"); } }

	}
}