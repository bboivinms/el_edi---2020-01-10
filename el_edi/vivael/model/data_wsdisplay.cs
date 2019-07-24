using System;

namespace vivael
{
	public class data_wsdisplay : DataSource
	{
		public data_wsdisplay() { Table_name = i.name = "wsdisplay"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Displtype; public string Displtype { get { return _Displtype; } set { Set(ref _Displtype, value, "Displtype"); } }
		private string _Screen; public string Screen { get { return _Screen; } set { Set(ref _Screen, value, "Screen"); } }
		private int? _Reckey; public int? Reckey { get { return _Reckey; } set { Set(ref _Reckey, value, "Reckey"); } }
		private short? _Sc_Left; public short? Sc_Left { get { return _Sc_Left; } set { Set(ref _Sc_Left, value, "Sc_Left"); } }
		private short? _Sc_Top; public short? Sc_Top { get { return _Sc_Top; } set { Set(ref _Sc_Top, value, "Sc_Top"); } }
		private short? _Sc_Height; public short? Sc_Height { get { return _Sc_Height; } set { Set(ref _Sc_Height, value, "Sc_Height"); } }
		private short? _Sc_Width; public short? Sc_Width { get { return _Sc_Width; } set { Set(ref _Sc_Width, value, "Sc_Width"); } }
		private string _Sc_Title; public string Sc_Title { get { return _Sc_Title; } set { Set(ref _Sc_Title, value, "Sc_Title"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }

	}
}