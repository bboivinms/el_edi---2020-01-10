using System;

namespace vivael
{
	public class data_ivprodimage : DataSource
	{
		public data_ivprodimage() { Table_name = i.name = "ivprodimage"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Image; public string Image { get { return _Image; } set { Set(ref _Image, value, "Image"); } }

	}
}