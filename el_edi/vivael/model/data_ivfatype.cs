using System;

namespace vivael
{
	public class data_ivfatype : DataSource
	{
		public data_ivfatype() { Table_name = i.name = "ivfatype"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Type_Pic; public string Type_Pic { get { return _Type_Pic; } set { Set(ref _Type_Pic, value, "Type_Pic"); } }

	}
}