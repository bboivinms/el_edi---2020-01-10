using System;

namespace vivael
{
	public class data_teitemeti : DataSource
	{
		public data_teitemeti() { Table_name = i.name = "teitemeti"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private decimal? _N_Largeur; public decimal? N_Largeur { get { return _N_Largeur; } set { Set(ref _N_Largeur, value, "N_Largeur"); } }
		private decimal? _N_Hauteur; public decimal? N_Hauteur { get { return _N_Hauteur; } set { Set(ref _N_Hauteur, value, "N_Hauteur"); } }
		private string _Cotcode; public string Cotcode { get { return _Cotcode; } set { Set(ref _Cotcode, value, "Cotcode"); } }
		private string _Cotdesc; public string Cotdesc { get { return _Cotdesc; } set { Set(ref _Cotdesc, value, "Cotdesc"); } }
		private decimal? _Cotlarg; public decimal? Cotlarg { get { return _Cotlarg; } set { Set(ref _Cotlarg, value, "Cotlarg"); } }
		private decimal? _Cothaut; public decimal? Cothaut { get { return _Cothaut; } set { Set(ref _Cothaut, value, "Cothaut"); } }
		private string _Cotmat; public string Cotmat { get { return _Cotmat; } set { Set(ref _Cotmat, value, "Cotmat"); } }
		private string _Cotadh; public string Cotadh { get { return _Cotadh; } set { Set(ref _Cotadh, value, "Cotadh"); } }
		private string _Cotfor; public string Cotfor { get { return _Cotfor; } set { Set(ref _Cotfor, value, "Cotfor"); } }
		private string _Cotfini; public string Cotfini { get { return _Cotfini; } set { Set(ref _Cotfini, value, "Cotfini"); } }
		private string _Cotdiam; public string Cotdiam { get { return _Cotdiam; } set { Set(ref _Cotdiam, value, "Cotdiam"); } }
		private int? _Cotnbl; public int? Cotnbl { get { return _Cotnbl; } set { Set(ref _Cotnbl, value, "Cotnbl"); } }
		private string _Cotqte; public string Cotqte { get { return _Cotqte; } set { Set(ref _Cotqte, value, "Cotqte"); } }
		private long? _Cur_Stock; public long? Cur_Stock { get { return _Cur_Stock; } set { Set(ref _Cur_Stock, value, "Cur_Stock"); } }
		private string _Materiel; public string Materiel { get { return _Materiel; } set { Set(ref _Materiel, value, "Materiel"); } }
		private string _Adhesif; public string Adhesif { get { return _Adhesif; } set { Set(ref _Adhesif, value, "Adhesif"); } }
		private string _Format; public string Format { get { return _Format; } set { Set(ref _Format, value, "Format"); } }
		private string _Fini; public string Fini { get { return _Fini; } set { Set(ref _Fini, value, "Fini"); } }
		private string _Diam_Core; public string Diam_Core { get { return _Diam_Core; } set { Set(ref _Diam_Core, value, "Diam_Core"); } }
		private int? _Nblarge; public int? Nblarge { get { return _Nblarge; } set { Set(ref _Nblarge, value, "Nblarge"); } }
		private string _Qteunite; public string Qteunite { get { return _Qteunite; } set { Set(ref _Qteunite, value, "Qteunite"); } }

	}
}