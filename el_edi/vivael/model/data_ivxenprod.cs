using System;

namespace vivael
{
	public class data_ivxenprod : DataSource
	{
		public data_ivxenprod() { Table_name = i.name = "ivxenprod"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Format; public string Format { get { return _Format; } set { Set(ref _Format, value, "Format"); } }
		private string _Poids; public string Poids { get { return _Poids; } set { Set(ref _Poids, value, "Poids"); } }
		private string _Papier; public string Papier { get { return _Papier; } set { Set(ref _Papier, value, "Papier"); } }
		private string _Recto; public string Recto { get { return _Recto; } set { Set(ref _Recto, value, "Recto"); } }
		private string _Verso; public string Verso { get { return _Verso; } set { Set(ref _Verso, value, "Verso"); } }
		private string _Fenetre; public string Fenetre { get { return _Fenetre; } set { Set(ref _Fenetre, value, "Fenetre"); } }
		private bool? _Fenstd; public bool? Fenstd { get { return _Fenstd; } set { Set(ref _Fenstd, value, "Fenstd"); } }
		private decimal? _Fengauche; public decimal? Fengauche { get { return _Fengauche; } set { Set(ref _Fengauche, value, "Fengauche"); } }
		private decimal? _Fenbas; public decimal? Fenbas { get { return _Fenbas; } set { Set(ref _Fenbas, value, "Fenbas"); } }
		private decimal? _Fenhaut; public decimal? Fenhaut { get { return _Fenhaut; } set { Set(ref _Fenhaut, value, "Fenhaut"); } }
		private decimal? _Fenlarge; public decimal? Fenlarge { get { return _Fenlarge; } set { Set(ref _Fenlarge, value, "Fenlarge"); } }
		private string _Construct; public string Construct { get { return _Construct; } set { Set(ref _Construct, value, "Construct"); } }
		private string _Ouverture; public string Ouverture { get { return _Ouverture; } set { Set(ref _Ouverture, value, "Ouverture"); } }
		private string _Autre; public string Autre { get { return _Autre; } set { Set(ref _Autre, value, "Autre"); } }
		private string _Rabats; public string Rabats { get { return _Rabats; } set { Set(ref _Rabats, value, "Rabats"); } }
		private string _Interieur; public string Interieur { get { return _Interieur; } set { Set(ref _Interieur, value, "Interieur"); } }
		private string _Fenetre2; public string Fenetre2 { get { return _Fenetre2; } set { Set(ref _Fenetre2, value, "Fenetre2"); } }
		private bool? _Fenstd2; public bool? Fenstd2 { get { return _Fenstd2; } set { Set(ref _Fenstd2, value, "Fenstd2"); } }
		private decimal? _Fengauche2; public decimal? Fengauche2 { get { return _Fengauche2; } set { Set(ref _Fengauche2, value, "Fengauche2"); } }
		private decimal? _Fenbas2; public decimal? Fenbas2 { get { return _Fenbas2; } set { Set(ref _Fenbas2, value, "Fenbas2"); } }
		private decimal? _Fenhaut2; public decimal? Fenhaut2 { get { return _Fenhaut2; } set { Set(ref _Fenhaut2, value, "Fenhaut2"); } }
		private decimal? _Fenlarge2; public decimal? Fenlarge2 { get { return _Fenlarge2; } set { Set(ref _Fenlarge2, value, "Fenlarge2"); } }
		private string _Fenplast; public string Fenplast { get { return _Fenplast; } set { Set(ref _Fenplast, value, "Fenplast"); } }
		private string _Fenplast2; public string Fenplast2 { get { return _Fenplast2; } set { Set(ref _Fenplast2, value, "Fenplast2"); } }
		private string _Colle; public string Colle { get { return _Colle; } set { Set(ref _Colle, value, "Colle"); } }
		private string _Typrab; public string Typrab { get { return _Typrab; } set { Set(ref _Typrab, value, "Typrab"); } }
		private bool? _Fsclogo; public bool? Fsclogo { get { return _Fsclogo; } set { Set(ref _Fsclogo, value, "Fsclogo"); } }
		private bool? _Recylogo; public bool? Recylogo { get { return _Recylogo; } set { Set(ref _Recylogo, value, "Recylogo"); } }

	}
}