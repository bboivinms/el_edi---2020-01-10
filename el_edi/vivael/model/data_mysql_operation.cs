using System;

namespace vivael
{
	public class data_mysql_operation : DataSource
	{
		public data_mysql_operation() { Table_name = i.name = "mysql_operation"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private DateTime? _Operation_Date; public DateTime? Operation_Date { get { return _Operation_Date; } set { Set(ref _Operation_Date, value, "Operation_Date"); } }
		private string _Usercode; public string Usercode { get { return _Usercode; } set { Set(ref _Usercode, value, "Usercode"); } }
		private string _Tablename; public string Tablename { get { return _Tablename; } set { Set(ref _Tablename, value, "Tablename"); } }
		private int? _Count_Insert; public int? Count_Insert { get { return _Count_Insert; } set { Set(ref _Count_Insert, value, "Count_Insert"); } }
		private int? _Count_Update; public int? Count_Update { get { return _Count_Update; } set { Set(ref _Count_Update, value, "Count_Update"); } }
		private int? _Count_Delete; public int? Count_Delete { get { return _Count_Delete; } set { Set(ref _Count_Delete, value, "Count_Delete"); } }
		private int? _Count_Total; public int? Count_Total { get { return _Count_Total; } set { Set(ref _Count_Total, value, "Count_Total"); } }

	}
}