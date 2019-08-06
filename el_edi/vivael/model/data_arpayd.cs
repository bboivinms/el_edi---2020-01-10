using System;

namespace vivael
{
	public class data_arpayd : DataSource
	{
		public data_arpayd() { Table_name = i.name = "arpayd"; i.primary_1 = "ident"; i.primary_2 = "seq"; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Seq; public int Seq { get { return _Seq; } set { Set(ref _Seq, value, "Seq"); } }
		private int? _Invid; public int? Invid { get { return _Invid; } set { Set(ref _Invid, value, "Invid"); } }
		private string _Invnocode; public string Invnocode { get { return _Invnocode; } set { Set(ref _Invnocode, value, "Invnocode"); } }
		private long? _Invno; public long? Invno { get { return _Invno; } set { Set(ref _Invno, value, "Invno"); } }
		private decimal? _Mnt_Paid; public decimal? Mnt_Paid { get { return _Mnt_Paid; } set { Set(ref _Mnt_Paid, value, "Mnt_Paid"); } }
		private decimal? _Mnt_Discount; public decimal? Mnt_Discount { get { return _Mnt_Discount; } set { Set(ref _Mnt_Discount, value, "Mnt_Discount"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Period; public byte? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }

	}
}