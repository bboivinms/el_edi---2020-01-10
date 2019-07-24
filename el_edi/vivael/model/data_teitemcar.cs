using System;

namespace vivael
{
	public class data_teitemcar : DataSource
	{
		public data_teitemcar() { Table_name = i.name = "teitemcar"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private decimal? _N_Longueur; public decimal? N_Longueur { get { return _N_Longueur; } set { Set(ref _N_Longueur, value, "N_Longueur"); } }
		private decimal? _N_Largeur; public decimal? N_Largeur { get { return _N_Largeur; } set { Set(ref _N_Largeur, value, "N_Largeur"); } }
		private decimal? _N_Hauteur; public decimal? N_Hauteur { get { return _N_Hauteur; } set { Set(ref _N_Hauteur, value, "N_Hauteur"); } }
		private string _Cotcode; public string Cotcode { get { return _Cotcode; } set { Set(ref _Cotcode, value, "Cotcode"); } }
		private string _Cotdesc; public string Cotdesc { get { return _Cotdesc; } set { Set(ref _Cotdesc, value, "Cotdesc"); } }
		private decimal? _Cotlong; public decimal? Cotlong { get { return _Cotlong; } set { Set(ref _Cotlong, value, "Cotlong"); } }
		private decimal? _Cotlarg; public decimal? Cotlarg { get { return _Cotlarg; } set { Set(ref _Cotlarg, value, "Cotlarg"); } }
		private decimal? _Cothaut; public decimal? Cothaut { get { return _Cothaut; } set { Set(ref _Cothaut, value, "Cothaut"); } }
		private string _Style; public string Style { get { return _Style; } set { Set(ref _Style, value, "Style"); } }
		private string _Test; public string Test { get { return _Test; } set { Set(ref _Test, value, "Test"); } }
		private string _Test2; public string Test2 { get { return _Test2; } set { Set(ref _Test2, value, "Test2"); } }
		private string _Flute; public string Flute { get { return _Flute; } set { Set(ref _Flute, value, "Flute"); } }
		private string _Nbcoul; public string Nbcoul { get { return _Nbcoul; } set { Set(ref _Nbcoul, value, "Nbcoul"); } }
		private string _Cotstyle; public string Cotstyle { get { return _Cotstyle; } set { Set(ref _Cotstyle, value, "Cotstyle"); } }
		private string _Cottest; public string Cottest { get { return _Cottest; } set { Set(ref _Cottest, value, "Cottest"); } }
		private string _Cottest2; public string Cottest2 { get { return _Cottest2; } set { Set(ref _Cottest2, value, "Cottest2"); } }
		private string _Cotflute; public string Cotflute { get { return _Cotflute; } set { Set(ref _Cotflute, value, "Cotflute"); } }
		private string _Cotnbcoul; public string Cotnbcoul { get { return _Cotnbcoul; } set { Set(ref _Cotnbcoul, value, "Cotnbcoul"); } }
		private long? _Cur_Stock; public long? Cur_Stock { get { return _Cur_Stock; } set { Set(ref _Cur_Stock, value, "Cur_Stock"); } }

	}
}