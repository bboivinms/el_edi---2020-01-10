using System;

namespace vivael
{
	public class data_ivquoted : DataSource
	{
		public data_ivquoted() { Table_name = i.name = "ivquoted"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Idquote; public int Idquote { get { return _Idquote; } set { Set(ref _Idquote, value, "Idquote"); } }
		private int? _Idprix; public int? Idprix { get { return _Idprix; } set { Set(ref _Idprix, value, "Idprix"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Ivline; public int? Ivline { get { return _Ivline; } set { Set(ref _Ivline, value, "Ivline"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private int? _Qte; public int? Qte { get { return _Qte; } set { Set(ref _Qte, value, "Qte"); } }
		private decimal? _Prix; public decimal? Prix { get { return _Prix; } set { Set(ref _Prix, value, "Prix"); } }
		private string _Unite; public string Unite { get { return _Unite; } set { Set(ref _Unite, value, "Unite"); } }

	}
}