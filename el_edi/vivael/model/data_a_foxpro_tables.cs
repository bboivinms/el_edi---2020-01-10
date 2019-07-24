using System;

namespace vivael
{
	public class data_a_foxpro_tables : DataSource
	{
		public data_a_foxpro_tables() { Table_name = i.name = "a_foxpro_tables"; i.primary_1 = "tablename"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int? _Ident; public int? Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Tablename; public string Tablename { get { return _Tablename; } set { Set(ref _Tablename, value, "Tablename"); } }
		private int? _Tablecount1; public int? Tablecount1 { get { return _Tablecount1; } set { Set(ref _Tablecount1, value, "Tablecount1"); } }
		private int? _Tablecount2; public int? Tablecount2 { get { return _Tablecount2; } set { Set(ref _Tablecount2, value, "Tablecount2"); } }
		private int? _Tablecount3; public int? Tablecount3 { get { return _Tablecount3; } set { Set(ref _Tablecount3, value, "Tablecount3"); } }
		private int? _Tablecount4; public int? Tablecount4 { get { return _Tablecount4; } set { Set(ref _Tablecount4, value, "Tablecount4"); } }
		private string _Columns1; public string Columns1 { get { return _Columns1; } set { Set(ref _Columns1, value, "Columns1"); } }
		private string _Columns2; public string Columns2 { get { return _Columns2; } set { Set(ref _Columns2, value, "Columns2"); } }
		private string _Status_Insert; public string Status_Insert { get { return _Status_Insert; } set { Set(ref _Status_Insert, value, "Status_Insert"); } }
		private string _Status_Update; public string Status_Update { get { return _Status_Update; } set { Set(ref _Status_Update, value, "Status_Update"); } }
		private DateTime? _Timestamp2; public DateTime? Timestamp2 { get { return _Timestamp2; } set { Set(ref _Timestamp2, value, "Timestamp2"); } }

	}
}