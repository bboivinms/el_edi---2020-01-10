using System;

namespace vivael
{
	public class data_estimad : DataSource
	{
		public data_estimad() { Table_name = i.name = "estimad"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private int? _Idesti; public int? Idesti { get { return _Idesti; } set { Set(ref _Idesti, value, "Idesti"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Ivline; public int? Ivline { get { return _Ivline; } set { Set(ref _Ivline, value, "Ivline"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private int? _Qte; public int? Qte { get { return _Qte; } set { Set(ref _Qte, value, "Qte"); } }
		private long? _Prix; public long? Prix { get { return _Prix; } set { Set(ref _Prix, value, "Prix"); } }
		private string _Unite; public string Unite { get { return _Unite; } set { Set(ref _Unite, value, "Unite"); } }

	}
}