using System;

namespace vivael
{
	public class data_mysql_log : DataSource
	{
		public data_mysql_log() { Table_name = i.name = "mysql_log"; i.primary_1 = "idmysql_log"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Idmysql_Log; public int Idmysql_Log { get { return _Idmysql_Log; } set { Set(ref _Idmysql_Log, value, "Idmysql_Log"); } }
		private string _Mysql_Log; public string Mysql_Log { get { return _Mysql_Log; } set { Set(ref _Mysql_Log, value, "Mysql_Log"); } }
		private string _Mysql_Type; public string Mysql_Type { get { return _Mysql_Type; } set { Set(ref _Mysql_Type, value, "Mysql_Type"); } }

	}
}