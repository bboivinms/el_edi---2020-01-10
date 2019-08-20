using System;

namespace vivael
{
	public class data_mysql_proc : DataSource
	{
		public data_mysql_proc() { Table_name = i.name = "mysql_proc"; i.primary_1 = "tablename"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private string _Tablename; public string Tablename { get { return _Tablename; } set { Set(ref _Tablename, value, "Tablename"); } }
		private byte? _Domysql_Sync; public byte? Domysql_Sync { get { return _Domysql_Sync; } set { Set(ref _Domysql_Sync, value, "Domysql_Sync"); } }
		private byte? _Domysql_Nooverride; public byte? Domysql_Nooverride { get { return _Domysql_Nooverride; } set { Set(ref _Domysql_Nooverride, value, "Domysql_Nooverride"); } }
		private byte? _Isfoxpro; public byte? Isfoxpro { get { return _Isfoxpro; } set { Set(ref _Isfoxpro, value, "Isfoxpro"); } }
		private string _Primary_1; public string Primary_1 { get { return _Primary_1; } set { Set(ref _Primary_1, value, "Primary_1"); } }
		private string _Primary_2; public string Primary_2 { get { return _Primary_2; } set { Set(ref _Primary_2, value, "Primary_2"); } }
		private string _Primary_3; public string Primary_3 { get { return _Primary_3; } set { Set(ref _Primary_3, value, "Primary_3"); } }
		private string _My_Hash; public string My_Hash { get { return _My_Hash; } set { Set(ref _My_Hash, value, "My_Hash"); } }
		private string _My_Insert_Fields; public string My_Insert_Fields { get { return _My_Insert_Fields; } set { Set(ref _My_Insert_Fields, value, "My_Insert_Fields"); } }
		private string _My_Insert_Values; public string My_Insert_Values { get { return _My_Insert_Values; } set { Set(ref _My_Insert_Values, value, "My_Insert_Values"); } }
		private string _My_Update; public string My_Update { get { return _My_Update; } set { Set(ref _My_Update, value, "My_Update"); } }
		private string _Resync; public string Resync { get { return _Resync; } set { Set(ref _Resync, value, "Resync"); } }
		private string _Resync_Field; public string Resync_Field { get { return _Resync_Field; } set { Set(ref _Resync_Field, value, "Resync_Field"); } }
		private string _Resync_Time; public string Resync_Time { get { return _Resync_Time; } set { Set(ref _Resync_Time, value, "Resync_Time"); } }
		private int? _Tablecount1; public int? Tablecount1 { get { return _Tablecount1; } set { Set(ref _Tablecount1, value, "Tablecount1"); } }
		private int? _Tablecount2; public int? Tablecount2 { get { return _Tablecount2; } set { Set(ref _Tablecount2, value, "Tablecount2"); } }
		private int? _Tablecount3; public int? Tablecount3 { get { return _Tablecount3; } set { Set(ref _Tablecount3, value, "Tablecount3"); } }
		private int? _Tablecount4; public int? Tablecount4 { get { return _Tablecount4; } set { Set(ref _Tablecount4, value, "Tablecount4"); } }
		private string _Columns1; public string Columns1 { get { return _Columns1; } set { Set(ref _Columns1, value, "Columns1"); } }
		private string _Columns2; public string Columns2 { get { return _Columns2; } set { Set(ref _Columns2, value, "Columns2"); } }
		private DateTime? _Timestamp2; public DateTime? Timestamp2 { get { return _Timestamp2; } set { Set(ref _Timestamp2, value, "Timestamp2"); } }

	}
}