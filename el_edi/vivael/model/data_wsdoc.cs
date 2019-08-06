using System;

namespace vivael
{
	public class data_wsdoc : DataSource
	{
		public data_wsdoc() { Table_name = i.name = "wsdoc"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Tablename; public string Tablename { get { return _Tablename; } set { Set(ref _Tablename, value, "Tablename"); } }
		private int? _Tableid; public int? Tableid { get { return _Tableid; } set { Set(ref _Tableid, value, "Tableid"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Docpath; public string Docpath { get { return _Docpath; } set { Set(ref _Docpath, value, "Docpath"); } }

	}
}