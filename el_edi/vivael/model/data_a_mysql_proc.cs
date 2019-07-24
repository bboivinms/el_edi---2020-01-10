using System;

namespace vivael
{
	public class data_a_mysql_proc : DataSource
	{
		public data_a_mysql_proc() { Table_name = i.name = "a_mysql_proc"; i.primary_1 = "tablename"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int? _Ident; public int? Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Tablename; public string Tablename { get { return _Tablename; } set { Set(ref _Tablename, value, "Tablename"); } }
		private bool? _Domysql_Sync; public bool? Domysql_Sync { get { return _Domysql_Sync; } set { Set(ref _Domysql_Sync, value, "Domysql_Sync"); } }
		private bool? _Domysql_Nooverride; public bool? Domysql_Nooverride { get { return _Domysql_Nooverride; } set { Set(ref _Domysql_Nooverride, value, "Domysql_Nooverride"); } }
		private string _Resync; public string Resync { get { return _Resync; } set { Set(ref _Resync, value, "Resync"); } }
		private string _Resync_Field; public string Resync_Field { get { return _Resync_Field; } set { Set(ref _Resync_Field, value, "Resync_Field"); } }
		private string _Resync_Time; public string Resync_Time { get { return _Resync_Time; } set { Set(ref _Resync_Time, value, "Resync_Time"); } }
		private string _Primary_1; public string Primary_1 { get { return _Primary_1; } set { Set(ref _Primary_1, value, "Primary_1"); } }
		private string _Primary_2; public string Primary_2 { get { return _Primary_2; } set { Set(ref _Primary_2, value, "Primary_2"); } }
		private string _Primary_3; public string Primary_3 { get { return _Primary_3; } set { Set(ref _Primary_3, value, "Primary_3"); } }
		private string _My_Hash; public string My_Hash { get { return _My_Hash; } set { Set(ref _My_Hash, value, "My_Hash"); } }
		private string _My_Insert_Fields; public string My_Insert_Fields { get { return _My_Insert_Fields; } set { Set(ref _My_Insert_Fields, value, "My_Insert_Fields"); } }
		private string _My_Insert_Values; public string My_Insert_Values { get { return _My_Insert_Values; } set { Set(ref _My_Insert_Values, value, "My_Insert_Values"); } }
		private string _My_Update; public string My_Update { get { return _My_Update; } set { Set(ref _My_Update, value, "My_Update"); } }
		private int? _Tablecount3; public int? Tablecount3 { get { return _Tablecount3; } set { Set(ref _Tablecount3, value, "Tablecount3"); } }
		private int? _Tablecount4; public int? Tablecount4 { get { return _Tablecount4; } set { Set(ref _Tablecount4, value, "Tablecount4"); } }

	}
}