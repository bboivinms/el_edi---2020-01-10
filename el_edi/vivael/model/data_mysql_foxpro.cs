using System;

namespace vivael
{
	public class data_mysql_foxpro : DataSource
	{
		public data_mysql_foxpro() { Table_name = i.name = "mysql_foxpro"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private string _Mysql_Foxpro; public string Mysql_Foxpro { get { return _Mysql_Foxpro; } set { Set(ref _Mysql_Foxpro, value, "Mysql_Foxpro"); } }
		private string _Mysql_Table; public string Mysql_Table { get { return _Mysql_Table; } set { Set(ref _Mysql_Table, value, "Mysql_Table"); } }
		private DateTime? _Mysql_Treated; public DateTime? Mysql_Treated { get { return _Mysql_Treated; } set { Set(ref _Mysql_Treated, value, "Mysql_Treated"); } }
		private string _Mysql_Status; public string Mysql_Status { get { return _Mysql_Status; } set { Set(ref _Mysql_Status, value, "Mysql_Status"); } }
		private string _Mysql_Hash_Values; public string Mysql_Hash_Values { get { return _Mysql_Hash_Values; } set { Set(ref _Mysql_Hash_Values, value, "Mysql_Hash_Values"); } }
		private string _Foxpro_Error; public string Foxpro_Error { get { return _Foxpro_Error; } set { Set(ref _Foxpro_Error, value, "Foxpro_Error"); } }
		private string _Foxpro_Ai_Field; public string Foxpro_Ai_Field { get { return _Foxpro_Ai_Field; } set { Set(ref _Foxpro_Ai_Field, value, "Foxpro_Ai_Field"); } }
		private int? _Foxpro_Ai_Value; public int? Foxpro_Ai_Value { get { return _Foxpro_Ai_Value; } set { Set(ref _Foxpro_Ai_Value, value, "Foxpro_Ai_Value"); } }
		private int? _Ident_Fox; public int? Ident_Fox { get { return _Ident_Fox; } set { Set(ref _Ident_Fox, value, "Ident_Fox"); } }
		private DateTime? _Timestamp_Mod; public DateTime? Timestamp_Mod { get { return _Timestamp_Mod; } set { Set(ref _Timestamp_Mod, value, "Timestamp_Mod"); } }

	}
}