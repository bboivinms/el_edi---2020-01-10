using System;

namespace vivael
{
	public class data_trzip : DataSource
	{
		public data_trzip() { Table_name = i.name = "trzip"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Zip_From; public string Zip_From { get { return _Zip_From; } set { Set(ref _Zip_From, value, "Zip_From"); } }
		private string _Zip_To; public string Zip_To { get { return _Zip_To; } set { Set(ref _Zip_To, value, "Zip_To"); } }
		private int? _Idzone; public int? Idzone { get { return _Idzone; } set { Set(ref _Idzone, value, "Idzone"); } }

	}
}