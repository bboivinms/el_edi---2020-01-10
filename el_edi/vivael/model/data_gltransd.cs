using System;

namespace vivael
{
	public class data_gltransd : DataSource
	{
		public data_gltransd() { Table_name = i.name = "gltransd"; i.primary_1 = "gltrans_id"; i.primary_2 = "seq"; i.primary_3 = null; isFoxpro = true; }

		private int _Gltrans_Id; public int Gltrans_Id { get { return _Gltrans_Id; } set { Set(ref _Gltrans_Id, value, "Gltrans_Id"); } }
		private int _Seq; public int Seq { get { return _Seq; } set { Set(ref _Seq, value, "Seq"); } }
		private int? _Glaccnt_Id; public int? Glaccnt_Id { get { return _Glaccnt_Id; } set { Set(ref _Glaccnt_Id, value, "Glaccnt_Id"); } }
		private decimal? _Mnt_Db; public decimal? Mnt_Db { get { return _Mnt_Db; } set { Set(ref _Mnt_Db, value, "Mnt_Db"); } }
		private decimal? _Mnt_Cr; public decimal? Mnt_Cr { get { return _Mnt_Cr; } set { Set(ref _Mnt_Cr, value, "Mnt_Cr"); } }
		private string _Cur; public string Cur { get { return _Cur; } set { Set(ref _Cur, value, "Cur"); } }
		private decimal? _Mnt_Db_Cur; public decimal? Mnt_Db_Cur { get { return _Mnt_Db_Cur; } set { Set(ref _Mnt_Db_Cur, value, "Mnt_Db_Cur"); } }
		private decimal? _Mnt_Cr_Cur; public decimal? Mnt_Cr_Cur { get { return _Mnt_Cr_Cur; } set { Set(ref _Mnt_Cr_Cur, value, "Mnt_Cr_Cur"); } }
		private decimal? _Cur_Rate; public decimal? Cur_Rate { get { return _Cur_Rate; } set { Set(ref _Cur_Rate, value, "Cur_Rate"); } }
		private bool? _Concil; public bool? Concil { get { return _Concil; } set { Set(ref _Concil, value, "Concil"); } }
		private DateTime? _Concil_Dte; public DateTime? Concil_Dte { get { return _Concil_Dte; } set { Set(ref _Concil_Dte, value, "Concil_Dte"); } }

	}
}