using System;

namespace vivael
{
	public class data_wsholy : DataSource
	{
		public data_wsholy() { Table_name = i.name = "wsholy"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private DateTime? _Dte; public DateTime? Dte { get { return _Dte; } set { Set(ref _Dte, value, "Dte"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Descr2; public string Descr2 { get { return _Descr2; } set { Set(ref _Descr2, value, "Descr2"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private string _Usercode; public string Usercode { get { return _Usercode; } set { Set(ref _Usercode, value, "Usercode"); } }

	}
}