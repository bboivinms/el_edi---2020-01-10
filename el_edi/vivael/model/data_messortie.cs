using System;

namespace vivael
{
	public class data_messortie : DataSource
	{
		public data_messortie() { Table_name = i.name = "messortie"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Message; public string Message { get { return _Message; } set { Set(ref _Message, value, "Message"); } }

	}
}