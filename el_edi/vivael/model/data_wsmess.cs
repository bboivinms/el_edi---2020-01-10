using System;

namespace vivael
{
	public class data_wsmess : DataSource
	{
		public data_wsmess() { Table_name = i.name = "wsmess"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Msg_1; public string Msg_1 { get { return _Msg_1; } set { Set(ref _Msg_1, value, "Msg_1"); } }
		private string _Msg_2; public string Msg_2 { get { return _Msg_2; } set { Set(ref _Msg_2, value, "Msg_2"); } }
		private string _Msg_3; public string Msg_3 { get { return _Msg_3; } set { Set(ref _Msg_3, value, "Msg_3"); } }

	}
}