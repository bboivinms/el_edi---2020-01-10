using System;

namespace vivael
{
	public class data_trrate : DataSource
	{
		public data_trrate() { Table_name = i.name = "trrate"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idclient; public int? Idclient { get { return _Idclient; } set { Set(ref _Idclient, value, "Idclient"); } }
		private int? _From_Idzone; public int? From_Idzone { get { return _From_Idzone; } set { Set(ref _From_Idzone, value, "From_Idzone"); } }
		private int? _To_Idzone; public int? To_Idzone { get { return _To_Idzone; } set { Set(ref _To_Idzone, value, "To_Idzone"); } }
		private int? _From_Qty; public int? From_Qty { get { return _From_Qty; } set { Set(ref _From_Qty, value, "From_Qty"); } }
		private int? _To_Qty; public int? To_Qty { get { return _To_Qty; } set { Set(ref _To_Qty, value, "To_Qty"); } }
		private decimal? _Unit_Rate; public decimal? Unit_Rate { get { return _Unit_Rate; } set { Set(ref _Unit_Rate, value, "Unit_Rate"); } }
		private decimal? _Min; public decimal? Min { get { return _Min; } set { Set(ref _Min, value, "Min"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }

	}
}