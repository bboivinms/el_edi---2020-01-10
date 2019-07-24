using System;

namespace vivael
{
	public class data_edi_856 : DataSource
	{
		public data_edi_856() { Table_name = i.name = "edi_856"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Cobil_Ident; public int Cobil_Ident { get { return _Cobil_Ident; } set { Set(ref _Cobil_Ident, value, "Cobil_Ident"); } }
		private byte _Sent; public byte Sent { get { return _Sent; } set { Set(ref _Sent, value, "Sent"); } }
		private string _Filename; public string Filename { get { return _Filename; } set { Set(ref _Filename, value, "Filename"); } }
		private DateTime? _Ship_Date; public DateTime? Ship_Date { get { return _Ship_Date; } set { Set(ref _Ship_Date, value, "Ship_Date"); } }

	}
}