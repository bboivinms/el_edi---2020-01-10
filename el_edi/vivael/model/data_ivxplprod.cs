using System;

namespace vivael
{
	public class data_ivxplprod : DataSource
	{
		public data_ivxplprod() { Table_name = i.name = "ivxplprod"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Mat; public string Mat { get { return _Mat; } set { Set(ref _Mat, value, "Mat"); } }
		private string _Epaiss; public string Epaiss { get { return _Epaiss; } set { Set(ref _Epaiss, value, "Epaiss"); } }
		private string _Util; public string Util { get { return _Util; } set { Set(ref _Util, value, "Util"); } }
		private bool? _Coul; public bool? Coul { get { return _Coul; } set { Set(ref _Coul, value, "Coul"); } }
		private bool? _Cote; public bool? Cote { get { return _Cote; } set { Set(ref _Cote, value, "Cote"); } }
		private string _Encre; public string Encre { get { return _Encre; } set { Set(ref _Encre, value, "Encre"); } }
		private int? _Prcblanc; public int? Prcblanc { get { return _Prcblanc; } set { Set(ref _Prcblanc, value, "Prcblanc"); } }
		private int? _Prccoul; public int? Prccoul { get { return _Prccoul; } set { Set(ref _Prccoul, value, "Prccoul"); } }
		private int? _Prvernis; public int? Prvernis { get { return _Prvernis; } set { Set(ref _Prvernis, value, "Prvernis"); } }
		private string _Saclarg; public string Saclarg { get { return _Saclarg; } set { Set(ref _Saclarg, value, "Saclarg"); } }
		private string _Sacbc; public string Sacbc { get { return _Sacbc; } set { Set(ref _Sacbc, value, "Sacbc"); } }
		private string _Sacccourt; public string Sacccourt { get { return _Sacccourt; } set { Set(ref _Sacccourt, value, "Sacccourt"); } }
		private string _Sacclong; public string Sacclong { get { return _Sacclong; } set { Set(ref _Sacclong, value, "Sacclong"); } }
		private string _Sacgf; public string Sacgf { get { return _Sacgf; } set { Set(ref _Sacgf, value, "Sacgf"); } }
		private string _Saclevext; public string Saclevext { get { return _Saclevext; } set { Set(ref _Saclevext, value, "Saclevext"); } }
		private string _Saclevint; public string Saclevint { get { return _Saclevint; } set { Set(ref _Saclevint, value, "Saclevint"); } }
		private string _Sacentete; public string Sacentete { get { return _Sacentete; } set { Set(ref _Sacentete, value, "Sacentete"); } }
		private string _Roullarg; public string Roullarg { get { return _Roullarg; } set { Set(ref _Roullarg, value, "Roullarg"); } }
		private string _Roultole; public string Roultole { get { return _Roultole; } set { Set(ref _Roultole, value, "Roultole"); } }
		private string _Roulrepet; public string Roulrepet { get { return _Roulrepet; } set { Set(ref _Roulrepet, value, "Roulrepet"); } }
		private string _Roultol; public string Roultol { get { return _Roultol; } set { Set(ref _Roultol, value, "Roultol"); } }
		private string _Roulgc; public string Roulgc { get { return _Roulgc; } set { Set(ref _Roulgc, value, "Roulgc"); } }
		private string _Roulcote1; public string Roulcote1 { get { return _Roulcote1; } set { Set(ref _Roulcote1, value, "Roulcote1"); } }
		private string _Roulcote2; public string Roulcote2 { get { return _Roulcote2; } set { Set(ref _Roulcote2, value, "Roulcote2"); } }
		private string _Autforme; public string Autforme { get { return _Autforme; } set { Set(ref _Autforme, value, "Autforme"); } }
		private bool? _Autembob; public bool? Autembob { get { return _Autembob; } set { Set(ref _Autembob, value, "Autembob"); } }
		private string _Autdialrlx; public string Autdialrlx { get { return _Autdialrlx; } set { Set(ref _Autdialrlx, value, "Autdialrlx"); } }
		private string _Autnote; public string Autnote { get { return _Autnote; } set { Set(ref _Autnote, value, "Autnote"); } }

	}
}