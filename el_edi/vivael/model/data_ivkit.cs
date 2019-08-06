using System;

namespace vivael
{
	public class data_ivkit : DataSource
	{
		public data_ivkit() { Table_name = i.name = "ivkit"; i.primary_1 = "idkit"; i.primary_2 = "line"; i.primary_3 = null; isFoxpro = true; }

		private int _Idkit; public int Idkit { get { return _Idkit; } set { Set(ref _Idkit, value, "Idkit"); } }
		private int _Line; public int Line { get { return _Line; } set { Set(ref _Line, value, "Line"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private decimal? _Qty; public decimal? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private int? _Ordre; public int? Ordre { get { return _Ordre; } set { Set(ref _Ordre, value, "Ordre"); } }
		private bool? _Dernier; public bool? Dernier { get { return _Dernier; } set { Set(ref _Dernier, value, "Dernier"); } }

	}
}