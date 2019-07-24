using System;

namespace vivael
{
	public class data_popoi : DataSource
	{
		public data_popoi() { Table_name = i.name = "popoi"; i.primary_1 = "idpo"; i.primary_2 = "line"; i.primary_3 = null; isFoxpro = true; }

		private int _Idpo; public int Idpo { get { return _Idpo; } set { Set(ref _Idpo, value, "Idpo"); } }
		private int _Line; public int Line { get { return _Line; } set { Set(ref _Line, value, "Line"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private long? _Qty_Ord; public long? Qty_Ord { get { return _Qty_Ord; } set { Set(ref _Qty_Ord, value, "Qty_Ord"); } }
		private long? _Qty_Rcv; public long? Qty_Rcv { get { return _Qty_Rcv; } set { Set(ref _Qty_Rcv, value, "Qty_Rcv"); } }
		private long? _Qty_Plrcv; public long? Qty_Plrcv { get { return _Qty_Plrcv; } set { Set(ref _Qty_Plrcv, value, "Qty_Plrcv"); } }
		private DateTime? _Date_Rcv; public DateTime? Date_Rcv { get { return _Date_Rcv; } set { Set(ref _Date_Rcv, value, "Date_Rcv"); } }
		private decimal? _Cost; public decimal? Cost { get { return _Cost; } set { Set(ref _Cost, value, "Cost"); } }
		private string _Cost_Cur; public string Cost_Cur { get { return _Cost_Cur; } set { Set(ref _Cost_Cur, value, "Cost_Cur"); } }
		private decimal? _Gst; public decimal? Gst { get { return _Gst; } set { Set(ref _Gst, value, "Gst"); } }
		private decimal? _Pst; public decimal? Pst { get { return _Pst; } set { Set(ref _Pst, value, "Pst"); } }
		private int? _Qtyctns; public int? Qtyctns { get { return _Qtyctns; } set { Set(ref _Qtyctns, value, "Qtyctns"); } }
		private string _Unit; public string Unit { get { return _Unit; } set { Set(ref _Unit, value, "Unit"); } }
		private int? _Idprix; public int? Idprix { get { return _Idprix; } set { Set(ref _Idprix, value, "Idprix"); } }
		private int? _Nblot; public int? Nblot { get { return _Nblot; } set { Set(ref _Nblot, value, "Nblot"); } }
		private string _Unite; public string Unite { get { return _Unite; } set { Set(ref _Unite, value, "Unite"); } }
		private int? _Idprix_Order; public int? Idprix_Order { get { return _Idprix_Order; } set { Set(ref _Idprix_Order, value, "Idprix_Order"); } }
		private decimal? _Conv; public decimal? Conv { get { return _Conv; } set { Set(ref _Conv, value, "Conv"); } }
		private decimal? _Tot_Paid; public decimal? Tot_Paid { get { return _Tot_Paid; } set { Set(ref _Tot_Paid, value, "Tot_Paid"); } }
		private string _Qty_Notes; public string Qty_Notes { get { return _Qty_Notes; } set { Set(ref _Qty_Notes, value, "Qty_Notes"); } }
		private decimal? _Hst; public decimal? Hst { get { return _Hst; } set { Set(ref _Hst, value, "Hst"); } }

	}
}