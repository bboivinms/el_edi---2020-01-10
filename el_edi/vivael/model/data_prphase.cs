using System;

namespace vivael
{
	public class data_prphase : DataSource
	{
		public data_prphase() { Table_name = i.name = "prphase"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _No; public string No { get { return _No; } set { Set(ref _No, value, "No"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private bool? _Caltemps; public bool? Caltemps { get { return _Caltemps; } set { Set(ref _Caltemps, value, "Caltemps"); } }

	}
}