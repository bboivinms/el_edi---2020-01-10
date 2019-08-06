using System;

namespace vivael
{
	public class data_ivqty : DataSource
	{
		public data_ivqty() { Table_name = i.name = "ivqty"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Idwareh; public int? Idwareh { get { return _Idwareh; } set { Set(ref _Idwareh, value, "Idwareh"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private int? _Idpack; public int? Idpack { get { return _Idpack; } set { Set(ref _Idpack, value, "Idpack"); } }
		private decimal? _Qty; public decimal? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private decimal? _Qtyunit; public decimal? Qtyunit { get { return _Qtyunit; } set { Set(ref _Qtyunit, value, "Qtyunit"); } }

	}
}