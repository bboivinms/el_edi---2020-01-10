using System;

namespace vivael
{
	public class data_ivprixdcli : DataSource
	{
		public data_ivprixdcli() { Table_name = i.name = "ivprixdcli"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Idclient; public int? Idclient { get { return _Idclient; } set { Set(ref _Idclient, value, "Idclient"); } }
		private decimal? _Taux; public decimal? Taux { get { return _Taux; } set { Set(ref _Taux, value, "Taux"); } }
		private string _Codecli; public string Codecli { get { return _Codecli; } set { Set(ref _Codecli, value, "Codecli"); } }
		private decimal? _Escbase; public decimal? Escbase { get { return _Escbase; } set { Set(ref _Escbase, value, "Escbase"); } }
		private string _Note; public string Note { get { return _Note; } set { Set(ref _Note, value, "Note"); } }
		private bool? _Contrat; public bool? Contrat { get { return _Contrat; } set { Set(ref _Contrat, value, "Contrat"); } }
		private decimal? _Prixc; public decimal? Prixc { get { return _Prixc; } set { Set(ref _Prixc, value, "Prixc"); } }
		private decimal? _Prixpal; public decimal? Prixpal { get { return _Prixpal; } set { Set(ref _Prixpal, value, "Prixpal"); } }
		private decimal? _Tauxpal; public decimal? Tauxpal { get { return _Tauxpal; } set { Set(ref _Tauxpal, value, "Tauxpal"); } }
		private string _Mod_By1; public string Mod_By1 { get { return _Mod_By1; } set { Set(ref _Mod_By1, value, "Mod_By1"); } }
		private DateTime? _Mod_Dt1; public DateTime? Mod_Dt1 { get { return _Mod_Dt1; } set { Set(ref _Mod_Dt1, value, "Mod_Dt1"); } }
		private string _Mod_By2; public string Mod_By2 { get { return _Mod_By2; } set { Set(ref _Mod_By2, value, "Mod_By2"); } }
		private DateTime? _Mod_Dt2; public DateTime? Mod_Dt2 { get { return _Mod_Dt2; } set { Set(ref _Mod_Dt2, value, "Mod_Dt2"); } }
		private DateTime? _Datefinc; public DateTime? Datefinc { get { return _Datefinc; } set { Set(ref _Datefinc, value, "Datefinc"); } }

	}
}