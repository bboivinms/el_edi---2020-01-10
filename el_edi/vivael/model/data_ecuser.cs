using System;

namespace vivael
{
	public class data_ecuser : DataSource
	{
		public data_ecuser() { Table_name = i.name = "ecuser"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Clientid; public int? Clientid { get { return _Clientid; } set { Set(ref _Clientid, value, "Clientid"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Passwd; public string Passwd { get { return _Passwd; } set { Set(ref _Passwd, value, "Passwd"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Language; public string Language { get { return _Language; } set { Set(ref _Language, value, "Language"); } }
		private bool? _Admin; public bool? Admin { get { return _Admin; } set { Set(ref _Admin, value, "Admin"); } }

	}
}