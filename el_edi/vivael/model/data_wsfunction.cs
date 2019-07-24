using System;

namespace vivael
{
	public class data_wsfunction : DataSource
	{
		public data_wsfunction() { Table_name = i.name = "wsfunction"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Function; public string Function { get { return _Function; } set { Set(ref _Function, value, "Function"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private string _Pgm; public string Pgm { get { return _Pgm; } set { Set(ref _Pgm, value, "Pgm"); } }
		private string _Option; public string Option { get { return _Option; } set { Set(ref _Option, value, "Option"); } }
		private string _Defprinter; public string Defprinter { get { return _Defprinter; } set { Set(ref _Defprinter, value, "Defprinter"); } }
		private string _Software; public string Software { get { return _Software; } set { Set(ref _Software, value, "Software"); } }

	}
}