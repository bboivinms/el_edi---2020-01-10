using System;

namespace vivael
{
	public class data_wskeepscn : DataSource
	{
		public data_wskeepscn() { Table_name = i.name = "wskeepscn"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Usercode; public string Usercode { get { return _Usercode; } set { Set(ref _Usercode, value, "Usercode"); } }
		private string _Screen; public string Screen { get { return _Screen; } set { Set(ref _Screen, value, "Screen"); } }
		private short? _Sc_Left; public short? Sc_Left { get { return _Sc_Left; } set { Set(ref _Sc_Left, value, "Sc_Left"); } }
		private short? _Sc_Top; public short? Sc_Top { get { return _Sc_Top; } set { Set(ref _Sc_Top, value, "Sc_Top"); } }
		private short? _Sc_Height; public short? Sc_Height { get { return _Sc_Height; } set { Set(ref _Sc_Height, value, "Sc_Height"); } }
		private byte? _Sc_State; public byte? Sc_State { get { return _Sc_State; } set { Set(ref _Sc_State, value, "Sc_State"); } }
		private bool? _Sc_Ontop; public bool? Sc_Ontop { get { return _Sc_Ontop; } set { Set(ref _Sc_Ontop, value, "Sc_Ontop"); } }
		private bool? _Sc_Onbottom; public bool? Sc_Onbottom { get { return _Sc_Onbottom; } set { Set(ref _Sc_Onbottom, value, "Sc_Onbottom"); } }
		private short? _Sc_Width; public short? Sc_Width { get { return _Sc_Width; } set { Set(ref _Sc_Width, value, "Sc_Width"); } }

	}
}