using System;

namespace vivael
{
	public class data_appuri : DataSource
	{
		public data_appuri() { Table_name = i.name = "appuri"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Line; public int? Line { get { return _Line; } set { Set(ref _Line, value, "Line"); } }
		private int? _Idpo; public int? Idpo { get { return _Idpo; } set { Set(ref _Idpo, value, "Idpo"); } }
		private int _Idprod; public int Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private decimal? _Sugg_Amnt; public decimal? Sugg_Amnt { get { return _Sugg_Amnt; } set { Set(ref _Sugg_Amnt, value, "Sugg_Amnt"); } }

	}
}