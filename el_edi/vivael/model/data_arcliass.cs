using System;

namespace vivael
{
	public class data_arcliass : DataSource
	{
		public data_arcliass() { Table_name = i.name = "arcliass"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idarclient; public int? Idarclient { get { return _Idarclient; } set { Set(ref _Idarclient, value, "Idarclient"); } }
		private int? _Idarclient_As; public int? Idarclient_As { get { return _Idarclient_As; } set { Set(ref _Idarclient_As, value, "Idarclient_As"); } }
		private string _Ascode; public string Ascode { get { return _Ascode; } set { Set(ref _Ascode, value, "Ascode"); } }

	}
}