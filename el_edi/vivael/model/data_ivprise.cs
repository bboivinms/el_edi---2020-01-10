using System;

namespace vivael
{
	public class data_ivprise : DataSource
	{
		public data_ivprise() { Table_name = i.name = "ivprise"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Nom; public string Nom { get { return _Nom; } set { Set(ref _Nom, value, "Nom"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private string _Entrepot; public string Entrepot { get { return _Entrepot; } set { Set(ref _Entrepot, value, "Entrepot"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private decimal? _Lastcost; public decimal? Lastcost { get { return _Lastcost; } set { Set(ref _Lastcost, value, "Lastcost"); } }
		private decimal? _Qty; public decimal? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private decimal? _Vcoul; public decimal? Vcoul { get { return _Vcoul; } set { Set(ref _Vcoul, value, "Vcoul"); } }
		private bool? _Approv; public bool? Approv { get { return _Approv; } set { Set(ref _Approv, value, "Approv"); } }
		private bool? _Ajust; public bool? Ajust { get { return _Ajust; } set { Set(ref _Ajust, value, "Ajust"); } }
		private bool? _Mov; public bool? Mov { get { return _Mov; } set { Set(ref _Mov, value, "Mov"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dte; public DateTime? Mod_Dte { get { return _Mod_Dte; } set { Set(ref _Mod_Dte, value, "Mod_Dte"); } }
		private char? _Type; public char? Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }

	}
}