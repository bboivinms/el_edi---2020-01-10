using System;

namespace vivael
{
	public class data_appur : DataSource
	{
		public data_appur() { Table_name = i.name = "appur"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

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
		private string _Gst_No; public string Gst_No { get { return _Gst_No; } set { Set(ref _Gst_No, value, "Gst_No"); } }
		private string _Pst_No; public string Pst_No { get { return _Pst_No; } set { Set(ref _Pst_No, value, "Pst_No"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Period; public byte? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }
		private decimal? _Mnt_Paid; public decimal? Mnt_Paid { get { return _Mnt_Paid; } set { Set(ref _Mnt_Paid, value, "Mnt_Paid"); } }
		private DateTime? _Cr_Date; public DateTime? Cr_Date { get { return _Cr_Date; } set { Set(ref _Cr_Date, value, "Cr_Date"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private int? _Post_Id; public int? Post_Id { get { return _Post_Id; } set { Set(ref _Post_Id, value, "Post_Id"); } }
		private byte? _Priority; public byte? Priority { get { return _Priority; } set { Set(ref _Priority, value, "Priority"); } }
		private bool? _Closed; public bool? Closed { get { return _Closed; } set { Set(ref _Closed, value, "Closed"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private int? _Idgl_Ap; public int? Idgl_Ap { get { return _Idgl_Ap; } set { Set(ref _Idgl_Ap, value, "Idgl_Ap"); } }
		private bool? _Accpac_Posted; public bool? Accpac_Posted { get { return _Accpac_Posted; } set { Set(ref _Accpac_Posted, value, "Accpac_Posted"); } }
		private bool? _Accpac_Ok; public bool? Accpac_Ok { get { return _Accpac_Ok; } set { Set(ref _Accpac_Ok, value, "Accpac_Ok"); } }
		private int? _Idpo; public int? Idpo { get { return _Idpo; } set { Set(ref _Idpo, value, "Idpo"); } }
		private int? _Idtax; public int? Idtax { get { return _Idtax; } set { Set(ref _Idtax, value, "Idtax"); } }
		private decimal? _Gst_Rate; public decimal? Gst_Rate { get { return _Gst_Rate; } set { Set(ref _Gst_Rate, value, "Gst_Rate"); } }
		private decimal? _Pst_Rate; public decimal? Pst_Rate { get { return _Pst_Rate; } set { Set(ref _Pst_Rate, value, "Pst_Rate"); } }
		private decimal? _Hst_Rate; public decimal? Hst_Rate { get { return _Hst_Rate; } set { Set(ref _Hst_Rate, value, "Hst_Rate"); } }
		private string _Hst_No; public string Hst_No { get { return _Hst_No; } set { Set(ref _Hst_No, value, "Hst_No"); } }
		private bool? _Lpstongst; public bool? Lpstongst { get { return _Lpstongst; } set { Set(ref _Lpstongst, value, "Lpstongst"); } }
		private decimal? _Mnt_Hst; public decimal? Mnt_Hst { get { return _Mnt_Hst; } set { Set(ref _Mnt_Hst, value, "Mnt_Hst"); } }
		private string _Equip; public string Equip { get { return _Equip; } set { Set(ref _Equip, value, "Equip"); } }
		private string _Pocode; public string Pocode { get { return _Pocode; } set { Set(ref _Pocode, value, "Pocode"); } }

	}
}