using System;

namespace vivael
{
	public class data_wsjobs : DataSource
	{
		public data_wsjobs() { Table_name = i.name = "wsjobs"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private short? _Todotime; public short? Todotime { get { return _Todotime; } set { Set(ref _Todotime, value, "Todotime"); } }
		private DateTime? _Tododate; public DateTime? Tododate { get { return _Tododate; } set { Set(ref _Tododate, value, "Tododate"); } }
		private byte? _Priority; public byte? Priority { get { return _Priority; } set { Set(ref _Priority, value, "Priority"); } }
		private bool? _Regular; public bool? Regular { get { return _Regular; } set { Set(ref _Regular, value, "Regular"); } }
		private string _Prog; public string Prog { get { return _Prog; } set { Set(ref _Prog, value, "Prog"); } }
		private bool? _Done; public bool? Done { get { return _Done; } set { Set(ref _Done, value, "Done"); } }
		private string _Details; public string Details { get { return _Details; } set { Set(ref _Details, value, "Details"); } }
		private bool? _D1; public bool? D1 { get { return _D1; } set { Set(ref _D1, value, "D1"); } }
		private bool? _D2; public bool? D2 { get { return _D2; } set { Set(ref _D2, value, "D2"); } }
		private bool? _D3; public bool? D3 { get { return _D3; } set { Set(ref _D3, value, "D3"); } }
		private bool? _D4; public bool? D4 { get { return _D4; } set { Set(ref _D4, value, "D4"); } }
		private bool? _D5; public bool? D5 { get { return _D5; } set { Set(ref _D5, value, "D5"); } }
		private bool? _D6; public bool? D6 { get { return _D6; } set { Set(ref _D6, value, "D6"); } }
		private bool? _D7; public bool? D7 { get { return _D7; } set { Set(ref _D7, value, "D7"); } }
		private string _Typeprog; public string Typeprog { get { return _Typeprog; } set { Set(ref _Typeprog, value, "Typeprog"); } }
		private DateTime? _Done_Dtetime; public DateTime? Done_Dtetime { get { return _Done_Dtetime; } set { Set(ref _Done_Dtetime, value, "Done_Dtetime"); } }

	}
}