using System;

namespace vivael
{
	public class data_wscurrate : DataSource
	{
		public data_wscurrate() { Table_name = i.name = "wscurrate"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private DateTime? _Rate_Dte; public DateTime? Rate_Dte { get { return _Rate_Dte; } set { Set(ref _Rate_Dte, value, "Rate_Dte"); } }
		private decimal? _Rate; public decimal? Rate { get { return _Rate; } set { Set(ref _Rate, value, "Rate"); } }

	}
}