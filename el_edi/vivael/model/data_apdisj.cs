using System;

namespace vivael
{
	public class data_apdisj : DataSource
	{
		public data_apdisj() { Table_name = i.name = "apdisj"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Supp_Id; public int Supp_Id { get { return _Supp_Id; } set { Set(ref _Supp_Id, value, "Supp_Id"); } }
		private string _Supp_Name; public string Supp_Name { get { return _Supp_Name; } set { Set(ref _Supp_Name, value, "Supp_Name"); } }
		private string _Ref; public string Ref { get { return _Ref; } set { Set(ref _Ref, value, "Ref"); } }
		private int? _Nopaymnt; public int? Nopaymnt { get { return _Nopaymnt; } set { Set(ref _Nopaymnt, value, "Nopaymnt"); } }
		private DateTime? _Dis_Date; public DateTime? Dis_Date { get { return _Dis_Date; } set { Set(ref _Dis_Date, value, "Dis_Date"); } }
		private byte? _Type_Pay; public byte? Type_Pay { get { return _Type_Pay; } set { Set(ref _Type_Pay, value, "Type_Pay"); } }
		private decimal? _Mnt_Paid; public decimal? Mnt_Paid { get { return _Mnt_Paid; } set { Set(ref _Mnt_Paid, value, "Mnt_Paid"); } }
		private decimal? _Mnt_Disc; public decimal? Mnt_Disc { get { return _Mnt_Disc; } set { Set(ref _Mnt_Disc, value, "Mnt_Disc"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private decimal? _Cur_Rate; public decimal? Cur_Rate { get { return _Cur_Rate; } set { Set(ref _Cur_Rate, value, "Cur_Rate"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private decimal? _Acc_Period; public decimal? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }
		private DateTime? _Cr_Date; public DateTime? Cr_Date { get { return _Cr_Date; } set { Set(ref _Cr_Date, value, "Cr_Date"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Voided_Dte; public DateTime? Voided_Dte { get { return _Voided_Dte; } set { Set(ref _Voided_Dte, value, "Voided_Dte"); } }
		private bool? _Voided; public bool? Voided { get { return _Voided; } set { Set(ref _Voided, value, "Voided"); } }
		private string _Voided_Reason; public string Voided_Reason { get { return _Voided_Reason; } set { Set(ref _Voided_Reason, value, "Voided_Reason"); } }
		private int? _Voided_Id; public int? Voided_Id { get { return _Voided_Id; } set { Set(ref _Voided_Id, value, "Voided_Id"); } }
		private int? _Voided_No_Pay; public int? Voided_No_Pay { get { return _Voided_No_Pay; } set { Set(ref _Voided_No_Pay, value, "Voided_No_Pay"); } }

	}
}