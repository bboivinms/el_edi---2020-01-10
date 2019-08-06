using System;

namespace vivael
{
	public class data_arslsj : DataSource
	{
		public data_arslsj() { Table_name = i.name = "arslsj"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Custid; public int? Custid { get { return _Custid; } set { Set(ref _Custid, value, "Custid"); } }
		private string _Invnocode; public string Invnocode { get { return _Invnocode; } set { Set(ref _Invnocode, value, "Invnocode"); } }
		private int? _Invno; public int? Invno { get { return _Invno; } set { Set(ref _Invno, value, "Invno"); } }
		private DateTime? _Inv_Date; public DateTime? Inv_Date { get { return _Inv_Date; } set { Set(ref _Inv_Date, value, "Inv_Date"); } }
		private DateTime? _Due_Date; public DateTime? Due_Date { get { return _Due_Date; } set { Set(ref _Due_Date, value, "Due_Date"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private decimal? _Inv_Mnt; public decimal? Inv_Mnt { get { return _Inv_Mnt; } set { Set(ref _Inv_Mnt, value, "Inv_Mnt"); } }
		private decimal? _Gst_Mnt; public decimal? Gst_Mnt { get { return _Gst_Mnt; } set { Set(ref _Gst_Mnt, value, "Gst_Mnt"); } }
		private decimal? _Pst_Mnt; public decimal? Pst_Mnt { get { return _Pst_Mnt; } set { Set(ref _Pst_Mnt, value, "Pst_Mnt"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private decimal? _Cur_Rate; public decimal? Cur_Rate { get { return _Cur_Rate; } set { Set(ref _Cur_Rate, value, "Cur_Rate"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Period; public byte? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }
		private DateTime? _Cr_Date; public DateTime? Cr_Date { get { return _Cr_Date; } set { Set(ref _Cr_Date, value, "Cr_Date"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private string _Activity; public string Activity { get { return _Activity; } set { Set(ref _Activity, value, "Activity"); } }
		private int? _Consolno; public int? Consolno { get { return _Consolno; } set { Set(ref _Consolno, value, "Consolno"); } }
		private int? _Consolid; public int? Consolid { get { return _Consolid; } set { Set(ref _Consolid, value, "Consolid"); } }
		private int? _Fileid; public int? Fileid { get { return _Fileid; } set { Set(ref _Fileid, value, "Fileid"); } }
		private decimal? _Tvh_Mnt; public decimal? Tvh_Mnt { get { return _Tvh_Mnt; } set { Set(ref _Tvh_Mnt, value, "Tvh_Mnt"); } }

	}
}