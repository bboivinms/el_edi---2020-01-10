using System;

namespace vivael
{
	public class data_prkithis : DataSource
	{
		public data_prkithis() { Table_name = i.name = "prkithis"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idfab; public int? Idfab { get { return _Idfab; } set { Set(ref _Idfab, value, "Idfab"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private decimal? _Qty; public decimal? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private string _Entrepot; public string Entrepot { get { return _Entrepot; } set { Set(ref _Entrepot, value, "Entrepot"); } }
		private DateTime? _Datetraiter; public DateTime? Datetraiter { get { return _Datetraiter; } set { Set(ref _Datetraiter, value, "Datetraiter"); } }
		private string _Usager; public string Usager { get { return _Usager; } set { Set(ref _Usager, value, "Usager"); } }

	}
}