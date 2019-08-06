using System;

namespace vivael
{
	public class data_prkit : DataSource
	{
		public data_prkit() { Table_name = i.name = "prkit"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idfab; public int? Idfab { get { return _Idfab; } set { Set(ref _Idfab, value, "Idfab"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Line; public int? Line { get { return _Line; } set { Set(ref _Line, value, "Line"); } }
		private decimal? _Qty; public decimal? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private string _Unit; public string Unit { get { return _Unit; } set { Set(ref _Unit, value, "Unit"); } }
		private decimal? _Qtedjprep; public decimal? Qtedjprep { get { return _Qtedjprep; } set { Set(ref _Qtedjprep, value, "Qtedjprep"); } }

	}
}