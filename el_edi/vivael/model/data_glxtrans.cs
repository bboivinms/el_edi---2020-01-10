using System;

namespace vivael
{
	public class data_glxtrans : DataSource
	{
		public data_glxtrans() { Table_name = i.name = "glxtrans"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Transid; public int Transid { get { return _Transid; } set { Set(ref _Transid, value, "Transid"); } }
		private int? _Glaccnt_Id; public int? Glaccnt_Id { get { return _Glaccnt_Id; } set { Set(ref _Glaccnt_Id, value, "Glaccnt_Id"); } }
		private string _Origin; public string Origin { get { return _Origin; } set { Set(ref _Origin, value, "Origin"); } }
		private decimal? _Mnt_Db; public decimal? Mnt_Db { get { return _Mnt_Db; } set { Set(ref _Mnt_Db, value, "Mnt_Db"); } }
		private decimal? _Mnt_Cr; public decimal? Mnt_Cr { get { return _Mnt_Cr; } set { Set(ref _Mnt_Cr, value, "Mnt_Cr"); } }
		private string _Cur; public string Cur { get { return _Cur; } set { Set(ref _Cur, value, "Cur"); } }
		private decimal? _Mnt_Db_Cur; public decimal? Mnt_Db_Cur { get { return _Mnt_Db_Cur; } set { Set(ref _Mnt_Db_Cur, value, "Mnt_Db_Cur"); } }
		private decimal? _Mnt_Cr_Cur; public decimal? Mnt_Cr_Cur { get { return _Mnt_Cr_Cur; } set { Set(ref _Mnt_Cr_Cur, value, "Mnt_Cr_Cur"); } }
		private int? _Supp_Cli_Id; public int? Supp_Cli_Id { get { return _Supp_Cli_Id; } set { Set(ref _Supp_Cli_Id, value, "Supp_Cli_Id"); } }
		private string _Supp_Cli_Name; public string Supp_Cli_Name { get { return _Supp_Cli_Name; } set { Set(ref _Supp_Cli_Name, value, "Supp_Cli_Name"); } }
		private string _Ref; public string Ref { get { return _Ref; } set { Set(ref _Ref, value, "Ref"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private DateTime? _Date; public DateTime? Date { get { return _Date; } set { Set(ref _Date, value, "Date"); } }
		private int? _Refid; public int? Refid { get { return _Refid; } set { Set(ref _Refid, value, "Refid"); } }

	}
}