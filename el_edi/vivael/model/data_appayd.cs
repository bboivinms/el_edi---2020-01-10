using System;

namespace vivael
{
	public class data_appayd : DataSource
	{
		public data_appayd() { Table_name = i.name = "appayd"; i.primary_1 = "ident"; i.primary_2 = "seq"; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Seq; public int Seq { get { return _Seq; } set { Set(ref _Seq, value, "Seq"); } }
		private string _Inv_No; public string Inv_No { get { return _Inv_No; } set { Set(ref _Inv_No, value, "Inv_No"); } }
		private int _Idappur; public int Idappur { get { return _Idappur; } set { Set(ref _Idappur, value, "Idappur"); } }
		private decimal? _Mnt_Paid; public decimal? Mnt_Paid { get { return _Mnt_Paid; } set { Set(ref _Mnt_Paid, value, "Mnt_Paid"); } }
		private decimal? _Mnt_Disc; public decimal? Mnt_Disc { get { return _Mnt_Disc; } set { Set(ref _Mnt_Disc, value, "Mnt_Disc"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Period; public byte? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }

	}
}