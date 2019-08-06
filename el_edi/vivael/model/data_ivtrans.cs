using System;

namespace vivael
{
	public class data_ivtrans : DataSource
	{
		public data_ivtrans() { Table_name = i.name = "ivtrans"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private int _Idtrans; public int Idtrans { get { return _Idtrans; } set { Set(ref _Idtrans, value, "Idtrans"); } }
		private string _Transtype; public string Transtype { get { return _Transtype; } set { Set(ref _Transtype, value, "Transtype"); } }
		private int _Idwareh; public int Idwareh { get { return _Idwareh; } set { Set(ref _Idwareh, value, "Idwareh"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private int? _Gl_Idtrans; public int? Gl_Idtrans { get { return _Gl_Idtrans; } set { Set(ref _Gl_Idtrans, value, "Gl_Idtrans"); } }
		private int? _Gl_Idgl_Db; public int? Gl_Idgl_Db { get { return _Gl_Idgl_Db; } set { Set(ref _Gl_Idgl_Db, value, "Gl_Idgl_Db"); } }
		private int? _Gl_Idgl_Cr; public int? Gl_Idgl_Cr { get { return _Gl_Idgl_Cr; } set { Set(ref _Gl_Idgl_Cr, value, "Gl_Idgl_Cr"); } }
		private decimal? _Gl_Mnt; public decimal? Gl_Mnt { get { return _Gl_Mnt; } set { Set(ref _Gl_Mnt, value, "Gl_Mnt"); } }
		private long? _Qty; public long? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private int _Idprod; public int Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Period; public byte? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }
		private DateTime? _Dte_Trans; public DateTime? Dte_Trans { get { return _Dte_Trans; } set { Set(ref _Dte_Trans, value, "Dte_Trans"); } }
		private string _Ref_Descr; public string Ref_Descr { get { return _Ref_Descr; } set { Set(ref _Ref_Descr, value, "Ref_Descr"); } }
		private string _Ref; public string Ref { get { return _Ref; } set { Set(ref _Ref, value, "Ref"); } }
		private int? _Idref; public int? Idref { get { return _Idref; } set { Set(ref _Idref, value, "Idref"); } }
		private string _Cr_Par; public string Cr_Par { get { return _Cr_Par; } set { Set(ref _Cr_Par, value, "Cr_Par"); } }
		private DateTime? _Cr_Dtime; public DateTime? Cr_Dtime { get { return _Cr_Dtime; } set { Set(ref _Cr_Dtime, value, "Cr_Dtime"); } }
		private int? _Noref; public int? Noref { get { return _Noref; } set { Set(ref _Noref, value, "Noref"); } }
		private string _Payer; public string Payer { get { return _Payer; } set { Set(ref _Payer, value, "Payer"); } }
		private decimal? _Mnt_Payer; public decimal? Mnt_Payer { get { return _Mnt_Payer; } set { Set(ref _Mnt_Payer, value, "Mnt_Payer"); } }

	}
}