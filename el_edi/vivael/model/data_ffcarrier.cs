using System;

namespace vivael
{
	public class data_ffcarrier : DataSource
	{
		public data_ffcarrier() { Table_name = i.name = "ffcarrier"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private string _Addr1; public string Addr1 { get { return _Addr1; } set { Set(ref _Addr1, value, "Addr1"); } }
		private string _Addr2; public string Addr2 { get { return _Addr2; } set { Set(ref _Addr2, value, "Addr2"); } }
		private string _City; public string City { get { return _City; } set { Set(ref _City, value, "City"); } }
		private string _State; public string State { get { return _State; } set { Set(ref _State, value, "State"); } }
		private string _Zip; public string Zip { get { return _Zip; } set { Set(ref _Zip, value, "Zip"); } }
		private string _Country; public string Country { get { return _Country; } set { Set(ref _Country, value, "Country"); } }
		private string _Tel; public string Tel { get { return _Tel; } set { Set(ref _Tel, value, "Tel"); } }
		private string _Tel2; public string Tel2 { get { return _Tel2; } set { Set(ref _Tel2, value, "Tel2"); } }
		private string _Fax; public string Fax { get { return _Fax; } set { Set(ref _Fax, value, "Fax"); } }
		private string _Web; public string Web { get { return _Web; } set { Set(ref _Web, value, "Web"); } }
		private string _Trackweb; public string Trackweb { get { return _Trackweb; } set { Set(ref _Trackweb, value, "Trackweb"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private string _Account; public string Account { get { return _Account; } set { Set(ref _Account, value, "Account"); } }
		private byte? _Defaut; public byte? Defaut { get { return _Defaut; } set { Set(ref _Defaut, value, "Defaut"); } }
		private byte? _Trpdirect; public byte? Trpdirect { get { return _Trpdirect; } set { Set(ref _Trpdirect, value, "Trpdirect"); } }
		private int? _Lcieid; public int? Lcieid { get { return _Lcieid; } set { Set(ref _Lcieid, value, "Lcieid"); } }

	}
}