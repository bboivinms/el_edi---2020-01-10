using System;

namespace vivael
{
	public class data_edi_850 : DataSource
	{
		public data_edi_850() { Table_name = i.name = "edi_850"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Popo_Ident; public int Popo_Ident { get { return _Popo_Ident; } set { Set(ref _Popo_Ident, value, "Popo_Ident"); } }
		private byte _Sent; public byte Sent { get { return _Sent; } set { Set(ref _Sent, value, "Sent"); } }
		private string _Filename; public string Filename { get { return _Filename; } set { Set(ref _Filename, value, "Filename"); } }
		private string _Xml_Technique; public string Xml_Technique { get { return _Xml_Technique; } set { Set(ref _Xml_Technique, value, "Xml_Technique"); } }
		private string _Error; public string Error { get { return _Error; } set { Set(ref _Error, value, "Error"); } }

	}
}