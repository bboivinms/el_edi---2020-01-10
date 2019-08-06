using System;

namespace vivael
{
	public class data_ffmatrice : DataSource
	{
		public data_ffmatrice() { Table_name = i.name = "ffmatrice"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private string _Format; public string Format { get { return _Format; } set { Set(ref _Format, value, "Format"); } }
		private string _Style; public string Style { get { return _Style; } set { Set(ref _Style, value, "Style"); } }
		private string _Die; public string Die { get { return _Die; } set { Set(ref _Die, value, "Die"); } }
		private decimal? _Flap; public decimal? Flap { get { return _Flap; } set { Set(ref _Flap, value, "Flap"); } }
		private decimal? _Backflao; public decimal? Backflao { get { return _Backflao; } set { Set(ref _Backflao, value, "Backflao"); } }
		private decimal? _Seamgauche; public decimal? Seamgauche { get { return _Seamgauche; } set { Set(ref _Seamgauche, value, "Seamgauche"); } }
		private decimal? _Seamdroit; public decimal? Seamdroit { get { return _Seamdroit; } set { Set(ref _Seamdroit, value, "Seamdroit"); } }
		private string _Idmachine; public string Idmachine { get { return _Idmachine; } set { Set(ref _Idmachine, value, "Idmachine"); } }
		private decimal? _Updlong; public decimal? Updlong { get { return _Updlong; } set { Set(ref _Updlong, value, "Updlong"); } }
		private decimal? _Uplargue; public decimal? Uplargue { get { return _Uplargue; } set { Set(ref _Uplargue, value, "Uplargue"); } }
		private short? _M1; public short? M1 { get { return _M1; } set { Set(ref _M1, value, "M1"); } }
		private string _Desc1; public string Desc1 { get { return _Desc1; } set { Set(ref _Desc1, value, "Desc1"); } }
		private short? _M2; public short? M2 { get { return _M2; } set { Set(ref _M2, value, "M2"); } }
		private string _Desc2; public string Desc2 { get { return _Desc2; } set { Set(ref _Desc2, value, "Desc2"); } }
		private short? _M3; public short? M3 { get { return _M3; } set { Set(ref _M3, value, "M3"); } }
		private string _Desc3; public string Desc3 { get { return _Desc3; } set { Set(ref _Desc3, value, "Desc3"); } }
		private short? _M4; public short? M4 { get { return _M4; } set { Set(ref _M4, value, "M4"); } }
		private string _Desc4; public string Desc4 { get { return _Desc4; } set { Set(ref _Desc4, value, "Desc4"); } }
		private short? _M5; public short? M5 { get { return _M5; } set { Set(ref _M5, value, "M5"); } }
		private string _Desc5; public string Desc5 { get { return _Desc5; } set { Set(ref _Desc5, value, "Desc5"); } }
		private short? _M6; public short? M6 { get { return _M6; } set { Set(ref _M6, value, "M6"); } }
		private string _Desc6; public string Desc6 { get { return _Desc6; } set { Set(ref _Desc6, value, "Desc6"); } }
		private short? _M7; public short? M7 { get { return _M7; } set { Set(ref _M7, value, "M7"); } }
		private string _Desc7; public string Desc7 { get { return _Desc7; } set { Set(ref _Desc7, value, "Desc7"); } }
		private short? _M8; public short? M8 { get { return _M8; } set { Set(ref _M8, value, "M8"); } }
		private string _Desc8; public string Desc8 { get { return _Desc8; } set { Set(ref _Desc8, value, "Desc8"); } }
		private short? _M9; public short? M9 { get { return _M9; } set { Set(ref _M9, value, "M9"); } }
		private string _Desc9; public string Desc9 { get { return _Desc9; } set { Set(ref _Desc9, value, "Desc9"); } }
		private bool? _Inactif; public bool? Inactif { get { return _Inactif; } set { Set(ref _Inactif, value, "Inactif"); } }

	}
}