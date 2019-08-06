using System;

namespace vivael
{
	public class data_prcalend : DataSource
	{
		public data_prcalend() { Table_name = i.name = "prcalend"; i.primary_1 = "ca_ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ca_Ident; public int Ca_Ident { get { return _Ca_Ident; } set { Set(ref _Ca_Ident, value, "Ca_Ident"); } }
		private DateTime? _Ca_Date; public DateTime? Ca_Date { get { return _Ca_Date; } set { Set(ref _Ca_Date, value, "Ca_Date"); } }
		private string _Ca_Desc; public string Ca_Desc { get { return _Ca_Desc; } set { Set(ref _Ca_Desc, value, "Ca_Desc"); } }

	}
}