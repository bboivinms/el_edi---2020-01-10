using System;

namespace vivael
{
	public class data_edi_855v : DataSource
	{
		public data_edi_855v() { Table_name = i.name = "edi_855v"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Popo_Ident; public int? Popo_Ident { get { return _Popo_Ident; } set { Set(ref _Popo_Ident, value, "Popo_Ident"); } }
		private string _Status; public string Status { get { return _Status; } set { Set(ref _Status, value, "Status"); } }
		private string _Validator; public string Validator { get { return _Validator; } set { Set(ref _Validator, value, "Validator"); } }
		private byte _Sent; public byte Sent { get { return _Sent; } set { Set(ref _Sent, value, "Sent"); } }
		private string _Filename; public string Filename { get { return _Filename; } set { Set(ref _Filename, value, "Filename"); } }
		private string _Popo_Pono; public string Popo_Pono { get { return _Popo_Pono; } set { Set(ref _Popo_Pono, value, "Popo_Pono"); } }
		private DateTime? _Po_Dte; public DateTime? Po_Dte { get { return _Po_Dte; } set { Set(ref _Po_Dte, value, "Po_Dte"); } }
		private string _Popo_Del_Name; public string Popo_Del_Name { get { return _Popo_Del_Name; } set { Set(ref _Popo_Del_Name, value, "Popo_Del_Name"); } }
		private string _Iddel_Addr; public string Iddel_Addr { get { return _Iddel_Addr; } set { Set(ref _Iddel_Addr, value, "Iddel_Addr"); } }
		private string _Xml855raw; public string Xml855raw { get { return _Xml855raw; } set { Set(ref _Xml855raw, value, "Xml855raw"); } }
		private string _Error; public string Error { get { return _Error; } set { Set(ref _Error, value, "Error"); } }
		private string _Programid; public string Programid { get { return _Programid; } set { Set(ref _Programid, value, "Programid"); } }

	}
}