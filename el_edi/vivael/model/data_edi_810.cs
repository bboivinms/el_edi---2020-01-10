using System;

namespace vivael
{
	public class data_edi_810 : DataSource
	{
		public data_edi_810() { Table_name = i.name = "edi_810"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Arinv_Ident; public int Arinv_Ident { get { return _Arinv_Ident; } set { Set(ref _Arinv_Ident, value, "Arinv_Ident"); } }
		private byte _Sent; public byte Sent { get { return _Sent; } set { Set(ref _Sent, value, "Sent"); } }
		private string _Filename; public string Filename { get { return _Filename; } set { Set(ref _Filename, value, "Filename"); } }

	}
}