using System;

namespace vivael
{
	public class data_ivxeqprod : DataSource
	{
		public data_ivxeqprod() { Table_name = i.name = "ivxeqprod"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Format; public string Format { get { return _Format; } set { Set(ref _Format, value, "Format"); } }
		private string _Materiel; public string Materiel { get { return _Materiel; } set { Set(ref _Materiel, value, "Materiel"); } }
		private string _Adhesif; public string Adhesif { get { return _Adhesif; } set { Set(ref _Adhesif, value, "Adhesif"); } }
		private string _Nbcoulrecto; public string Nbcoulrecto { get { return _Nbcoulrecto; } set { Set(ref _Nbcoulrecto, value, "Nbcoulrecto"); } }
		private string _Nbcoulverso; public string Nbcoulverso { get { return _Nbcoulverso; } set { Set(ref _Nbcoulverso, value, "Nbcoulverso"); } }
		private bool? _Coul4; public bool? Coul4 { get { return _Coul4; } set { Set(ref _Coul4, value, "Coul4"); } }
		private string _Finiscoul; public string Finiscoul { get { return _Finiscoul; } set { Set(ref _Finiscoul, value, "Finiscoul"); } }
		private string _Embspecial; public string Embspecial { get { return _Embspecial; } set { Set(ref _Embspecial, value, "Embspecial"); } }
		private string _Fini; public string Fini { get { return _Fini; } set { Set(ref _Fini, value, "Fini"); } }
		private string _Qteunite; public string Qteunite { get { return _Qteunite; } set { Set(ref _Qteunite, value, "Qteunite"); } }
		private int? _Nblarge; public int? Nblarge { get { return _Nblarge; } set { Set(ref _Nblarge, value, "Nblarge"); } }
		private string _Autre; public string Autre { get { return _Autre; } set { Set(ref _Autre, value, "Autre"); } }
		private int? _Opt_Enroul; public int? Opt_Enroul { get { return _Opt_Enroul; } set { Set(ref _Opt_Enroul, value, "Opt_Enroul"); } }
		private string _Diam_Core; public string Diam_Core { get { return _Diam_Core; } set { Set(ref _Diam_Core, value, "Diam_Core"); } }
		private bool? _Perfore; public bool? Perfore { get { return _Perfore; } set { Set(ref _Perfore, value, "Perfore"); } }
		private string _Dimension; public string Dimension { get { return _Dimension; } set { Set(ref _Dimension, value, "Dimension"); } }

	}
}