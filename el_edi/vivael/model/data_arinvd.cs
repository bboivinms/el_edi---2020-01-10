using System;

namespace vivael
{
	public class data_arinvd : DataSource
	{
		public data_arinvd() { Table_name = i.name = "arinvd"; i.primary_1 = "ident"; i.primary_2 = "invline"; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private byte _Invline; public byte Invline { get { return _Invline; } set { Set(ref _Invline, value, "Invline"); } }
		private string _Invcode; public string Invcode { get { return _Invcode; } set { Set(ref _Invcode, value, "Invcode"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private decimal? _Inv_Mnt; public decimal? Inv_Mnt { get { return _Inv_Mnt; } set { Set(ref _Inv_Mnt, value, "Inv_Mnt"); } }
		private string _Inv_Mnt_Cur; public string Inv_Mnt_Cur { get { return _Inv_Mnt_Cur; } set { Set(ref _Inv_Mnt_Cur, value, "Inv_Mnt_Cur"); } }
		private byte? _Tx_Gst_Code; public byte? Tx_Gst_Code { get { return _Tx_Gst_Code; } set { Set(ref _Tx_Gst_Code, value, "Tx_Gst_Code"); } }
		private byte? _Tx_Pst_Code; public byte? Tx_Pst_Code { get { return _Tx_Pst_Code; } set { Set(ref _Tx_Pst_Code, value, "Tx_Pst_Code"); } }
		private bool? _Isduty; public bool? Isduty { get { return _Isduty; } set { Set(ref _Isduty, value, "Isduty"); } }
		private int? _Idcom; public int? Idcom { get { return _Idcom; } set { Set(ref _Idcom, value, "Idcom"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private decimal? _Qty; public decimal? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private decimal? _Inv_Mnt_Unit; public decimal? Inv_Mnt_Unit { get { return _Inv_Mnt_Unit; } set { Set(ref _Inv_Mnt_Unit, value, "Inv_Mnt_Unit"); } }
		private int? _Idbil; public int? Idbil { get { return _Idbil; } set { Set(ref _Idbil, value, "Idbil"); } }
		private decimal? _Conv; public decimal? Conv { get { return _Conv; } set { Set(ref _Conv, value, "Conv"); } }
		private string _Unite; public string Unite { get { return _Unite; } set { Set(ref _Unite, value, "Unite"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private int? _Warh; public int? Warh { get { return _Warh; } set { Set(ref _Warh, value, "Warh"); } }
		private int? _Bil_Line; public int? Bil_Line { get { return _Bil_Line; } set { Set(ref _Bil_Line, value, "Bil_Line"); } }
		private string _Nofsc; public string Nofsc { get { return _Nofsc; } set { Set(ref _Nofsc, value, "Nofsc"); } }

	}
}