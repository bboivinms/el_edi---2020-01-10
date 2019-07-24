using System;

namespace vivael
{
	public class data_wslog : DataSource
	{
		public data_wslog() { Table_name = i.name = "wslog"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private DateTime? _Date; public DateTime? Date { get { return _Date; } set { Set(ref _Date, value, "Date"); } }
		private string _Heure; public string Heure { get { return _Heure; } set { Set(ref _Heure, value, "Heure"); } }
		private string _User; public string User { get { return _User; } set { Set(ref _User, value, "User"); } }
		private string _Module; public string Module { get { return _Module; } set { Set(ref _Module, value, "Module"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private string _Note; public string Note { get { return _Note; } set { Set(ref _Note, value, "Note"); } }
		private string _Mem_Dump; public string Mem_Dump { get { return _Mem_Dump; } set { Set(ref _Mem_Dump, value, "Mem_Dump"); } }

	}
}