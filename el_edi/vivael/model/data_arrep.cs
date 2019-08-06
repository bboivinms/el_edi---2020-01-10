using System;

namespace vivael
{
	public class data_arrep : DataSource
	{
		public data_arrep() { Table_name = i.name = "arrep"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private string _Usercode; public string Usercode { get { return _Usercode; } set { Set(ref _Usercode, value, "Usercode"); } }
		private string _Comm_On; public string Comm_On { get { return _Comm_On; } set { Set(ref _Comm_On, value, "Comm_On"); } }
		private long? _Comm_Vol1; public long? Comm_Vol1 { get { return _Comm_Vol1; } set { Set(ref _Comm_Vol1, value, "Comm_Vol1"); } }
		private long? _Comm_Vol2; public long? Comm_Vol2 { get { return _Comm_Vol2; } set { Set(ref _Comm_Vol2, value, "Comm_Vol2"); } }
		private long? _Comm_Vol3; public long? Comm_Vol3 { get { return _Comm_Vol3; } set { Set(ref _Comm_Vol3, value, "Comm_Vol3"); } }
		private long? _Comm_Vol4; public long? Comm_Vol4 { get { return _Comm_Vol4; } set { Set(ref _Comm_Vol4, value, "Comm_Vol4"); } }
		private long? _Comm_Vol5; public long? Comm_Vol5 { get { return _Comm_Vol5; } set { Set(ref _Comm_Vol5, value, "Comm_Vol5"); } }
		private long? _Comm_Vol6; public long? Comm_Vol6 { get { return _Comm_Vol6; } set { Set(ref _Comm_Vol6, value, "Comm_Vol6"); } }
		private long? _Comm_Vol7; public long? Comm_Vol7 { get { return _Comm_Vol7; } set { Set(ref _Comm_Vol7, value, "Comm_Vol7"); } }
		private long? _Comm_Vol8; public long? Comm_Vol8 { get { return _Comm_Vol8; } set { Set(ref _Comm_Vol8, value, "Comm_Vol8"); } }
		private long? _Comm_Vol9; public long? Comm_Vol9 { get { return _Comm_Vol9; } set { Set(ref _Comm_Vol9, value, "Comm_Vol9"); } }
		private long? _Comm_Vol10; public long? Comm_Vol10 { get { return _Comm_Vol10; } set { Set(ref _Comm_Vol10, value, "Comm_Vol10"); } }
		private decimal? _Comm1; public decimal? Comm1 { get { return _Comm1; } set { Set(ref _Comm1, value, "Comm1"); } }
		private decimal? _Comm2; public decimal? Comm2 { get { return _Comm2; } set { Set(ref _Comm2, value, "Comm2"); } }
		private decimal? _Comm3; public decimal? Comm3 { get { return _Comm3; } set { Set(ref _Comm3, value, "Comm3"); } }
		private decimal? _Comm4; public decimal? Comm4 { get { return _Comm4; } set { Set(ref _Comm4, value, "Comm4"); } }
		private decimal? _Comm5; public decimal? Comm5 { get { return _Comm5; } set { Set(ref _Comm5, value, "Comm5"); } }
		private decimal? _Comm6; public decimal? Comm6 { get { return _Comm6; } set { Set(ref _Comm6, value, "Comm6"); } }
		private decimal? _Comm7; public decimal? Comm7 { get { return _Comm7; } set { Set(ref _Comm7, value, "Comm7"); } }
		private decimal? _Comm8; public decimal? Comm8 { get { return _Comm8; } set { Set(ref _Comm8, value, "Comm8"); } }
		private decimal? _Comm9; public decimal? Comm9 { get { return _Comm9; } set { Set(ref _Comm9, value, "Comm9"); } }
		private decimal? _Comm10; public decimal? Comm10 { get { return _Comm10; } set { Set(ref _Comm10, value, "Comm10"); } }
		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Title; public string Title { get { return _Title; } set { Set(ref _Title, value, "Title"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private bool? _Inactif; public bool? Inactif { get { return _Inactif; } set { Set(ref _Inactif, value, "Inactif"); } }
		private int? _Budprosp; public int? Budprosp { get { return _Budprosp; } set { Set(ref _Budprosp, value, "Budprosp"); } }

	}
}