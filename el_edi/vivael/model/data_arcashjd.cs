using System;

namespace vivael
{
	public class data_arcashjd : DataSource
	{
		public data_arcashjd() { Table_name = i.name = "arcashjd"; i.primary_1 = "ident"; i.primary_2 = "seq"; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Seq; public int Seq { get { return _Seq; } set { Set(ref _Seq, value, "Seq"); } }
		private int? _Glaccnt; public int? Glaccnt { get { return _Glaccnt; } set { Set(ref _Glaccnt, value, "Glaccnt"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private decimal? _Mnt_Db_Cur; public decimal? Mnt_Db_Cur { get { return _Mnt_Db_Cur; } set { Set(ref _Mnt_Db_Cur, value, "Mnt_Db_Cur"); } }
		private decimal? _Mnt_Cr_Cur; public decimal? Mnt_Cr_Cur { get { return _Mnt_Cr_Cur; } set { Set(ref _Mnt_Cr_Cur, value, "Mnt_Cr_Cur"); } }
		private decimal? _Mnt_Db; public decimal? Mnt_Db { get { return _Mnt_Db; } set { Set(ref _Mnt_Db, value, "Mnt_Db"); } }
		private decimal? _Mnt_Cr; public decimal? Mnt_Cr { get { return _Mnt_Cr; } set { Set(ref _Mnt_Cr, value, "Mnt_Cr"); } }

	}
}