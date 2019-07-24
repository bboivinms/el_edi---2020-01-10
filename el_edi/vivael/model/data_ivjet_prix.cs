using System;

namespace vivael
{
	public class data_ivjet_prix : DataSource
	{
		public data_ivjet_prix() { Table_name = i.name = "ivjet_prix"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private int? _Nb_Cote; public int? Nb_Cote { get { return _Nb_Cote; } set { Set(ref _Nb_Cote, value, "Nb_Cote"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private string _Enveloppe; public string Enveloppe { get { return _Enveloppe; } set { Set(ref _Enveloppe, value, "Enveloppe"); } }
		private int? _Qte; public int? Qte { get { return _Qte; } set { Set(ref _Qte, value, "Qte"); } }
		private decimal? _Pn25; public decimal? Pn25 { get { return _Pn25; } set { Set(ref _Pn25, value, "Pn25"); } }
		private decimal? _Pn50; public decimal? Pn50 { get { return _Pn50; } set { Set(ref _Pn50, value, "Pn50"); } }
		private decimal? _Pn75; public decimal? Pn75 { get { return _Pn75; } set { Set(ref _Pn75, value, "Pn75"); } }
		private decimal? _Pn90; public decimal? Pn90 { get { return _Pn90; } set { Set(ref _Pn90, value, "Pn90"); } }
		private decimal? _Pp25; public decimal? Pp25 { get { return _Pp25; } set { Set(ref _Pp25, value, "Pp25"); } }
		private decimal? _Pp50; public decimal? Pp50 { get { return _Pp50; } set { Set(ref _Pp50, value, "Pp50"); } }
		private decimal? _Pp75; public decimal? Pp75 { get { return _Pp75; } set { Set(ref _Pp75, value, "Pp75"); } }
		private decimal? _Pp90; public decimal? Pp90 { get { return _Pp90; } set { Set(ref _Pp90, value, "Pp90"); } }
		private decimal? _Pnp25; public decimal? Pnp25 { get { return _Pnp25; } set { Set(ref _Pnp25, value, "Pnp25"); } }
		private decimal? _Pnp50; public decimal? Pnp50 { get { return _Pnp50; } set { Set(ref _Pnp50, value, "Pnp50"); } }
		private decimal? _Pnp75; public decimal? Pnp75 { get { return _Pnp75; } set { Set(ref _Pnp75, value, "Pnp75"); } }
		private decimal? _Pnp90; public decimal? Pnp90 { get { return _Pnp90; } set { Set(ref _Pnp90, value, "Pnp90"); } }
		private decimal? _P2p25; public decimal? P2p25 { get { return _P2p25; } set { Set(ref _P2p25, value, "P2p25"); } }
		private decimal? _P2p50; public decimal? P2p50 { get { return _P2p50; } set { Set(ref _P2p50, value, "P2p50"); } }
		private decimal? _P2p75; public decimal? P2p75 { get { return _P2p75; } set { Set(ref _P2p75, value, "P2p75"); } }
		private decimal? _P2p90; public decimal? P2p90 { get { return _P2p90; } set { Set(ref _P2p90, value, "P2p90"); } }
		private decimal? _P3c25; public decimal? P3c25 { get { return _P3c25; } set { Set(ref _P3c25, value, "P3c25"); } }
		private decimal? _P3c50; public decimal? P3c50 { get { return _P3c50; } set { Set(ref _P3c50, value, "P3c50"); } }
		private decimal? _P3c75; public decimal? P3c75 { get { return _P3c75; } set { Set(ref _P3c75, value, "P3c75"); } }
		private decimal? _P3c90; public decimal? P3c90 { get { return _P3c90; } set { Set(ref _P3c90, value, "P3c90"); } }

	}
}