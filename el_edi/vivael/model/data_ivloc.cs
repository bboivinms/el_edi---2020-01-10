using System;

namespace vivael
{
	public class data_ivloc : DataSource
	{
		public data_ivloc() { Table_name = i.name = "ivloc"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Idwareh; public int Idwareh { get { return _Idwareh; } set { Set(ref _Idwareh, value, "Idwareh"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private bool? _Is_Out; public bool? Is_Out { get { return _Is_Out; } set { Set(ref _Is_Out, value, "Is_Out"); } }
		private bool? _Prod; public bool? Prod { get { return _Prod; } set { Set(ref _Prod, value, "Prod"); } }

	}
}