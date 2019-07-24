using System;

namespace vivael
{
	public class data_prtemps : DataSource
	{
		public data_prtemps() { Table_name = i.name = "prtemps"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idfab; public int? Idfab { get { return _Idfab; } set { Set(ref _Idfab, value, "Idfab"); } }
		private DateTime? _Datedeb; public DateTime? Datedeb { get { return _Datedeb; } set { Set(ref _Datedeb, value, "Datedeb"); } }
		private decimal? _Hrsdeb; public decimal? Hrsdeb { get { return _Hrsdeb; } set { Set(ref _Hrsdeb, value, "Hrsdeb"); } }
		private DateTime? _Datefin; public DateTime? Datefin { get { return _Datefin; } set { Set(ref _Datefin, value, "Datefin"); } }
		private decimal? _Hrsfin; public decimal? Hrsfin { get { return _Hrsfin; } set { Set(ref _Hrsfin, value, "Hrsfin"); } }
		private int? _Idemp; public int? Idemp { get { return _Idemp; } set { Set(ref _Idemp, value, "Idemp"); } }
		private int? _Idphase; public int? Idphase { get { return _Idphase; } set { Set(ref _Idphase, value, "Idphase"); } }
		private int? _Idmat; public int? Idmat { get { return _Idmat; } set { Set(ref _Idmat, value, "Idmat"); } }
		private int? _Idmach; public int? Idmach { get { return _Idmach; } set { Set(ref _Idmach, value, "Idmach"); } }
		private int? _Up; public int? Up { get { return _Up; } set { Set(ref _Up, value, "Up"); } }
		private bool? _Termine; public bool? Termine { get { return _Termine; } set { Set(ref _Termine, value, "Termine"); } }
		private int? _Qteprod; public int? Qteprod { get { return _Qteprod; } set { Set(ref _Qteprod, value, "Qteprod"); } }
		private bool? _Kit; public bool? Kit { get { return _Kit; } set { Set(ref _Kit, value, "Kit"); } }
		private bool? _Etape; public bool? Etape { get { return _Etape; } set { Set(ref _Etape, value, "Etape"); } }
		private decimal? _Hrsdeb2; public decimal? Hrsdeb2 { get { return _Hrsdeb2; } set { Set(ref _Hrsdeb2, value, "Hrsdeb2"); } }
		private decimal? _Hrsdeb3; public decimal? Hrsdeb3 { get { return _Hrsdeb3; } set { Set(ref _Hrsdeb3, value, "Hrsdeb3"); } }
		private decimal? _Hrsdeb4; public decimal? Hrsdeb4 { get { return _Hrsdeb4; } set { Set(ref _Hrsdeb4, value, "Hrsdeb4"); } }
		private decimal? _Hrsfin2; public decimal? Hrsfin2 { get { return _Hrsfin2; } set { Set(ref _Hrsfin2, value, "Hrsfin2"); } }
		private decimal? _Hrsfin3; public decimal? Hrsfin3 { get { return _Hrsfin3; } set { Set(ref _Hrsfin3, value, "Hrsfin3"); } }
		private decimal? _Hrsfin4; public decimal? Hrsfin4 { get { return _Hrsfin4; } set { Set(ref _Hrsfin4, value, "Hrsfin4"); } }
		private decimal? _Hrstot; public decimal? Hrstot { get { return _Hrstot; } set { Set(ref _Hrstot, value, "Hrstot"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Cr_Dtet; public DateTime? Cr_Dtet { get { return _Cr_Dtet; } set { Set(ref _Cr_Dtet, value, "Cr_Dtet"); } }
		private DateTime? _Mod_Dtet; public DateTime? Mod_Dtet { get { return _Mod_Dtet; } set { Set(ref _Mod_Dtet, value, "Mod_Dtet"); } }
		private string _Note; public string Note { get { return _Note; } set { Set(ref _Note, value, "Note"); } }

	}
}