using System;

namespace vivael
{
	public class data_arpaygl : DataSource
	{
		public data_arpaygl() { Table_name = i.name = "arpaygl"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Seq; public int? Seq { get { return _Seq; } set { Set(ref _Seq, value, "Seq"); } }
		private int? _Glaccnt_Id; public int? Glaccnt_Id { get { return _Glaccnt_Id; } set { Set(ref _Glaccnt_Id, value, "Glaccnt_Id"); } }
		private decimal? _Mnt_Db; public decimal? Mnt_Db { get { return _Mnt_Db; } set { Set(ref _Mnt_Db, value, "Mnt_Db"); } }
		private decimal? _Mnt_Cr; public decimal? Mnt_Cr { get { return _Mnt_Cr; } set { Set(ref _Mnt_Cr, value, "Mnt_Cr"); } }

	}
}