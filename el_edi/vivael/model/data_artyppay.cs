using System;

namespace vivael
{
	public class data_artyppay : DataSource
	{
		public data_artyppay() { Table_name = i.name = "artyppay"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private int? _Idgl; public int? Idgl { get { return _Idgl; } set { Set(ref _Idgl, value, "Idgl"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private bool? _Is_Creditcard; public bool? Is_Creditcard { get { return _Is_Creditcard; } set { Set(ref _Is_Creditcard, value, "Is_Creditcard"); } }
		private bool? _Is_Cash; public bool? Is_Cash { get { return _Is_Cash; } set { Set(ref _Is_Cash, value, "Is_Cash"); } }

	}
}