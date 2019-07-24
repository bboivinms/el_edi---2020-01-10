using System;

namespace vivael
{
	public class data_glgrrb : DataSource
	{
		public data_glgrrb() { Table_name = i.name = "glgrrb"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Grdesc; public string Grdesc { get { return _Grdesc; } set { Set(ref _Grdesc, value, "Grdesc"); } }
		private string _Totniv1; public string Totniv1 { get { return _Totniv1; } set { Set(ref _Totniv1, value, "Totniv1"); } }
		private string _Totniv2; public string Totniv2 { get { return _Totniv2; } set { Set(ref _Totniv2, value, "Totniv2"); } }
		private string _Totniv3; public string Totniv3 { get { return _Totniv3; } set { Set(ref _Totniv3, value, "Totniv3"); } }
		private string _Totniv4; public string Totniv4 { get { return _Totniv4; } set { Set(ref _Totniv4, value, "Totniv4"); } }
		private short? _Ordrerap; public short? Ordrerap { get { return _Ordrerap; } set { Set(ref _Ordrerap, value, "Ordrerap"); } }

	}
}