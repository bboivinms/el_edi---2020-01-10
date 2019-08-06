using System;

namespace vivael
{
	public class data_edi_855 : DataSource
	{
		public data_edi_855() { Table_name = i.name = "edi_855"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Idcocom; public int Idcocom { get { return _Idcocom; } set { Set(ref _Idcocom, value, "Idcocom"); } }
		private string _Status; public string Status { get { return _Status; } set { Set(ref _Status, value, "Status"); } }
		private string _Validator; public string Validator { get { return _Validator; } set { Set(ref _Validator, value, "Validator"); } }
		private byte _Sent; public byte Sent { get { return _Sent; } set { Set(ref _Sent, value, "Sent"); } }
		private string _Filename; public string Filename { get { return _Filename; } set { Set(ref _Filename, value, "Filename"); } }

	}
}