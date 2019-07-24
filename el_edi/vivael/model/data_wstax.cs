using System;

namespace vivael
{
	public class data_wstax : DataSource
	{
		public data_wstax() { Table_name = i.name = "wstax"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private decimal? _Gst_Rate; public decimal? Gst_Rate { get { return _Gst_Rate; } set { Set(ref _Gst_Rate, value, "Gst_Rate"); } }
		private decimal? _Pst_Rate; public decimal? Pst_Rate { get { return _Pst_Rate; } set { Set(ref _Pst_Rate, value, "Pst_Rate"); } }
		private decimal? _Hst_Rate; public decimal? Hst_Rate { get { return _Hst_Rate; } set { Set(ref _Hst_Rate, value, "Hst_Rate"); } }
		private string _Pst_No; public string Pst_No { get { return _Pst_No; } set { Set(ref _Pst_No, value, "Pst_No"); } }
		private string _Gst_No; public string Gst_No { get { return _Gst_No; } set { Set(ref _Gst_No, value, "Gst_No"); } }
		private string _Hst_No; public string Hst_No { get { return _Hst_No; } set { Set(ref _Hst_No, value, "Hst_No"); } }
		private bool? _Lpstongst; public bool? Lpstongst { get { return _Lpstongst; } set { Set(ref _Lpstongst, value, "Lpstongst"); } }

	}
}