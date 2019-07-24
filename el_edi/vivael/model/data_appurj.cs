using System;

namespace vivael
{
	public class data_appurj : DataSource
	{
		public data_appurj() { Table_name = i.name = "appurj"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Supp_Id; public int? Supp_Id { get { return _Supp_Id; } set { Set(ref _Supp_Id, value, "Supp_Id"); } }
		private string _Supp_Name; public string Supp_Name { get { return _Supp_Name; } set { Set(ref _Supp_Name, value, "Supp_Name"); } }
		private string _Inv_No; public string Inv_No { get { return _Inv_No; } set { Set(ref _Inv_No, value, "Inv_No"); } }
		private DateTime? _Inv_Date; public DateTime? Inv_Date { get { return _Inv_Date; } set { Set(ref _Inv_Date, value, "Inv_Date"); } }
		private DateTime? _Due_Date; public DateTime? Due_Date { get { return _Due_Date; } set { Set(ref _Due_Date, value, "Due_Date"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private decimal? _Mnt_Inv; public decimal? Mnt_Inv { get { return _Mnt_Inv; } set { Set(ref _Mnt_Inv, value, "Mnt_Inv"); } }
		private decimal? _Mnt_Gst; public decimal? Mnt_Gst { get { return _Mnt_Gst; } set { Set(ref _Mnt_Gst, value, "Mnt_Gst"); } }
		private decimal? _Mnt_Pst; public decimal? Mnt_Pst { get { return _Mnt_Pst; } set { Set(ref _Mnt_Pst, value, "Mnt_Pst"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private decimal? _Cur_Rate; public decimal? Cur_Rate { get { return _Cur_Rate; } set { Set(ref _Cur_Rate, value, "Cur_Rate"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Period; public byte? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }
		private DateTime? _Cr_Date; public DateTime? Cr_Date { get { return _Cr_Date; } set { Set(ref _Cr_Date, value, "Cr_Date"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private decimal? _Mnt_Hst; public decimal? Mnt_Hst { get { return _Mnt_Hst; } set { Set(ref _Mnt_Hst, value, "Mnt_Hst"); } }

	}
}