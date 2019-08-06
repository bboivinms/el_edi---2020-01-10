using System;

namespace vivael
{
	public class data_ivplainte : DataSource
	{
		public data_ivplainte() { Table_name = i.name = "ivplainte"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Bl_Ms; public int? Bl_Ms { get { return _Bl_Ms; } set { Set(ref _Bl_Ms, value, "Bl_Ms"); } }
		private int? _Nocommcli; public int? Nocommcli { get { return _Nocommcli; } set { Set(ref _Nocommcli, value, "Nocommcli"); } }
		private int? _Idcli; public int? Idcli { get { return _Idcli; } set { Set(ref _Idcli, value, "Idcli"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Fact_Ms; public int? Fact_Ms { get { return _Fact_Ms; } set { Set(ref _Fact_Ms, value, "Fact_Ms"); } }
		private int? _Qte_Defect; public int? Qte_Defect { get { return _Qte_Defect; } set { Set(ref _Qte_Defect, value, "Qte_Defect"); } }
		private string _Raison_Cli; public string Raison_Cli { get { return _Raison_Cli; } set { Set(ref _Raison_Cli, value, "Raison_Cli"); } }
		private string _Suivi_Cli; public string Suivi_Cli { get { return _Suivi_Cli; } set { Set(ref _Suivi_Cli, value, "Suivi_Cli"); } }
		private byte? _Action_Cli; public byte? Action_Cli { get { return _Action_Cli; } set { Set(ref _Action_Cli, value, "Action_Cli"); } }
		private short? _Action_Cli_Cr_Pct; public short? Action_Cli_Cr_Pct { get { return _Action_Cli_Cr_Pct; } set { Set(ref _Action_Cli_Cr_Pct, value, "Action_Cli_Cr_Pct"); } }
		private int? _No_Po; public int? No_Po { get { return _No_Po; } set { Set(ref _No_Po, value, "No_Po"); } }
		private int? _Qte_Produite; public int? Qte_Produite { get { return _Qte_Produite; } set { Set(ref _Qte_Produite, value, "Qte_Produite"); } }
		private string _No_Production; public string No_Production { get { return _No_Production; } set { Set(ref _No_Production, value, "No_Production"); } }
		private int? _Idfourn; public int? Idfourn { get { return _Idfourn; } set { Set(ref _Idfourn, value, "Idfourn"); } }
		private string _Nego_Fourn; public string Nego_Fourn { get { return _Nego_Fourn; } set { Set(ref _Nego_Fourn, value, "Nego_Fourn"); } }
		private string _Reglement_Fourn; public string Reglement_Fourn { get { return _Reglement_Fourn; } set { Set(ref _Reglement_Fourn, value, "Reglement_Fourn"); } }
		private byte? _Action_Fourn; public byte? Action_Fourn { get { return _Action_Fourn; } set { Set(ref _Action_Fourn, value, "Action_Fourn"); } }
		private short? _Action_Fourn_Cr_Pct; public short? Action_Fourn_Cr_Pct { get { return _Action_Fourn_Cr_Pct; } set { Set(ref _Action_Fourn_Cr_Pct, value, "Action_Fourn_Cr_Pct"); } }
		private int? _Qte_Retournee; public int? Qte_Retournee { get { return _Qte_Retournee; } set { Set(ref _Qte_Retournee, value, "Qte_Retournee"); } }
		private int? _Qte_Reparee; public int? Qte_Reparee { get { return _Qte_Reparee; } set { Set(ref _Qte_Reparee, value, "Qte_Reparee"); } }
		private string _No_Cr_Fourn; public string No_Cr_Fourn { get { return _No_Cr_Fourn; } set { Set(ref _No_Cr_Fourn, value, "No_Cr_Fourn"); } }
		private decimal? _Mnt_Cr_Fourn; public decimal? Mnt_Cr_Fourn { get { return _Mnt_Cr_Fourn; } set { Set(ref _Mnt_Cr_Fourn, value, "Mnt_Cr_Fourn"); } }
		private int? _No_Cr_Cli; public int? No_Cr_Cli { get { return _No_Cr_Cli; } set { Set(ref _No_Cr_Cli, value, "No_Cr_Cli"); } }
		private decimal? _Mnt_Cr_Cli; public decimal? Mnt_Cr_Cli { get { return _Mnt_Cr_Cli; } set { Set(ref _Mnt_Cr_Cli, value, "Mnt_Cr_Cli"); } }
		private string _Notes_Credit; public string Notes_Credit { get { return _Notes_Credit; } set { Set(ref _Notes_Credit, value, "Notes_Credit"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dte; public DateTime? Mod_Dte { get { return _Mod_Dte; } set { Set(ref _Mod_Dte, value, "Mod_Dte"); } }
		private int? _In_Noprod; public int? In_Noprod { get { return _In_Noprod; } set { Set(ref _In_Noprod, value, "In_Noprod"); } }
		private decimal? _In_Qteprod; public decimal? In_Qteprod { get { return _In_Qteprod; } set { Set(ref _In_Qteprod, value, "In_Qteprod"); } }
		private string _In_Nego; public string In_Nego { get { return _In_Nego; } set { Set(ref _In_Nego, value, "In_Nego"); } }
		private string _In_Regle; public string In_Regle { get { return _In_Regle; } set { Set(ref _In_Regle, value, "In_Regle"); } }
		private string _No_Etampe; public string No_Etampe { get { return _No_Etampe; } set { Set(ref _No_Etampe, value, "No_Etampe"); } }

	}
}