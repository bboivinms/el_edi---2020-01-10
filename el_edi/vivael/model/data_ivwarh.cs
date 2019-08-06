using System;

namespace vivael
{
	public class data_ivwarh : DataSource
	{
		public data_ivwarh() { Table_name = i.name = "ivwarh"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private bool? _Is_Main; public bool? Is_Main { get { return _Is_Main; } set { Set(ref _Is_Main, value, "Is_Main"); } }
		private string _Cie; public string Cie { get { return _Cie; } set { Set(ref _Cie, value, "Cie"); } }
		private bool? _Echu; public bool? Echu { get { return _Echu; } set { Set(ref _Echu, value, "Echu"); } }

	}
}