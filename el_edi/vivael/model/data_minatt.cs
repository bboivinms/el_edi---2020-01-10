using System;

namespace vivael
{
	public class data_minatt : DataSource
	{
		public data_minatt() { Table_name = i.name = "minatt"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private bool? _Cro_Pro; public bool? Cro_Pro { get { return _Cro_Pro; } set { Set(ref _Cro_Pro, value, "Cro_Pro"); } }
		private bool? _Cro_Com; public bool? Cro_Com { get { return _Cro_Com; } set { Set(ref _Cro_Com, value, "Cro_Com"); } }
		private int? _Clientid; public int? Clientid { get { return _Clientid; } set { Set(ref _Clientid, value, "Clientid"); } }
		private int? _Ivprod; public int? Ivprod { get { return _Ivprod; } set { Set(ref _Ivprod, value, "Ivprod"); } }
		private string _Clientname; public string Clientname { get { return _Clientname; } set { Set(ref _Clientname, value, "Clientname"); } }
		private long? _Qte_Min; public long? Qte_Min { get { return _Qte_Min; } set { Set(ref _Qte_Min, value, "Qte_Min"); } }
		private bool? _Min_Att; public bool? Min_Att { get { return _Min_Att; } set { Set(ref _Min_Att, value, "Min_Att"); } }

	}
}