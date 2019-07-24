using System;

namespace vivael
{
	public class data_appay : DataSource
	{
		public data_appay() { Table_name = i.name = "appay"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Supp_Id; public int? Supp_Id { get { return _Supp_Id; } set { Set(ref _Supp_Id, value, "Supp_Id"); } }
		private string _Supp_Name; public string Supp_Name { get { return _Supp_Name; } set { Set(ref _Supp_Name, value, "Supp_Name"); } }
		private byte? _Type_Pay; public byte? Type_Pay { get { return _Type_Pay; } set { Set(ref _Type_Pay, value, "Type_Pay"); } }
		private string _Ref; public string Ref { get { return _Ref; } set { Set(ref _Ref, value, "Ref"); } }
		private int? _Nopaymnt; public int? Nopaymnt { get { return _Nopaymnt; } set { Set(ref _Nopaymnt, value, "Nopaymnt"); } }
		private DateTime? _Dte_Paid; public DateTime? Dte_Paid { get { return _Dte_Paid; } set { Set(ref _Dte_Paid, value, "Dte_Paid"); } }
		private decimal? _Mnt_Paid; public decimal? Mnt_Paid { get { return _Mnt_Paid; } set { Set(ref _Mnt_Paid, value, "Mnt_Paid"); } }
		private decimal? _Mnt_Disc; public decimal? Mnt_Disc { get { return _Mnt_Disc; } set { Set(ref _Mnt_Disc, value, "Mnt_Disc"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private decimal? _Cur_Rate; public decimal? Cur_Rate { get { return _Cur_Rate; } set { Set(ref _Cur_Rate, value, "Cur_Rate"); } }
		private short _Acc_Year; public short Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte _Acc_Period; public byte Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }
		private DateTime? _Cr_Date; public DateTime? Cr_Date { get { return _Cr_Date; } set { Set(ref _Cr_Date, value, "Cr_Date"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private int? _Post_Id; public int? Post_Id { get { return _Post_Id; } set { Set(ref _Post_Id, value, "Post_Id"); } }
		private int? _Bq_Accnt_Id; public int? Bq_Accnt_Id { get { return _Bq_Accnt_Id; } set { Set(ref _Bq_Accnt_Id, value, "Bq_Accnt_Id"); } }
		private bool? _Concil; public bool? Concil { get { return _Concil; } set { Set(ref _Concil, value, "Concil"); } }
		private byte? _Nb_Print; public byte? Nb_Print { get { return _Nb_Print; } set { Set(ref _Nb_Print, value, "Nb_Print"); } }
		private DateTime? _Concil_Dte; public DateTime? Concil_Dte { get { return _Concil_Dte; } set { Set(ref _Concil_Dte, value, "Concil_Dte"); } }
		private bool? _Voided; public bool? Voided { get { return _Voided; } set { Set(ref _Voided, value, "Voided"); } }
		private DateTime? _Voided_Dte; public DateTime? Voided_Dte { get { return _Voided_Dte; } set { Set(ref _Voided_Dte, value, "Voided_Dte"); } }
		private int? _Voided_Id; public int? Voided_Id { get { return _Voided_Id; } set { Set(ref _Voided_Id, value, "Voided_Id"); } }
		private string _Inv_Curr; public string Inv_Curr { get { return _Inv_Curr; } set { Set(ref _Inv_Curr, value, "Inv_Curr"); } }
		private decimal? _Inv_Curr_Rte; public decimal? Inv_Curr_Rte { get { return _Inv_Curr_Rte; } set { Set(ref _Inv_Curr_Rte, value, "Inv_Curr_Rte"); } }
		private decimal? _Mnt_Paid_Cur; public decimal? Mnt_Paid_Cur { get { return _Mnt_Paid_Cur; } set { Set(ref _Mnt_Paid_Cur, value, "Mnt_Paid_Cur"); } }
		private decimal? _Mnt_Disc_Cur; public decimal? Mnt_Disc_Cur { get { return _Mnt_Disc_Cur; } set { Set(ref _Mnt_Disc_Cur, value, "Mnt_Disc_Cur"); } }
		private string _Voided_Reason; public string Voided_Reason { get { return _Voided_Reason; } set { Set(ref _Voided_Reason, value, "Voided_Reason"); } }
		private short? _Voided_Year; public short? Voided_Year { get { return _Voided_Year; } set { Set(ref _Voided_Year, value, "Voided_Year"); } }
		private byte? _Voided_Period; public byte? Voided_Period { get { return _Voided_Period; } set { Set(ref _Voided_Period, value, "Voided_Period"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }

	}
}