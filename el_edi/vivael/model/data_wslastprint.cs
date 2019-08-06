using System;

namespace vivael
{
	public class data_wslastprint : DataSource
	{
		public data_wslastprint() { Table_name = i.name = "wslastprint"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Usercode; public string Usercode { get { return _Usercode; } set { Set(ref _Usercode, value, "Usercode"); } }
		private string _Report_Name; public string Report_Name { get { return _Report_Name; } set { Set(ref _Report_Name, value, "Report_Name"); } }
		private string _Printer_Name; public string Printer_Name { get { return _Printer_Name; } set { Set(ref _Printer_Name, value, "Printer_Name"); } }

	}
}