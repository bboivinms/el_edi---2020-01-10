using System;

namespace vivael
{
	public class data_arcashj : DataSource
	{
		public data_arcashj() { Table_name = i.name = "arcashj"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Custid; public int? Custid { get { return _Custid; } set { Set(ref _Custid, value, "Custid"); } }
		private string _Ref; public string Ref { get { return _Ref; } set { Set(ref _Ref, value, "Ref"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private DateTime? _Dte_Paid; public DateTime? Dte_Paid { get { return _Dte_Paid; } set { Set(ref _Dte_Paid, value, "Dte_Paid"); } }
		private string _Type_Pay; public string Type_Pay { get { return _Type_Pay; } set { Set(ref _Type_Pay, value, "Type_Pay"); } }
		private decimal? _Mnt_Paid; public decimal? Mnt_Paid { get { return _Mnt_Paid; } set { Set(ref _Mnt_Paid, value, "Mnt_Paid"); } }
		private decimal? _Mnt_Discount; public decimal? Mnt_Discount { get { return _Mnt_Discount; } set { Set(ref _Mnt_Discount, value, "Mnt_Discount"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private decimal? _Cur_Rate; public decimal? Cur_Rate { get { return _Cur_Rate; } set { Set(ref _Cur_Rate, value, "Cur_Rate"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Period; public byte? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }
		private DateTime? _Cr_Date; public DateTime? Cr_Date { get { return _Cr_Date; } set { Set(ref _Cr_Date, value, "Cr_Date"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private int? _Idtyppay; public int? Idtyppay { get { return _Idtyppay; } set { Set(ref _Idtyppay, value, "Idtyppay"); } }

	}
}