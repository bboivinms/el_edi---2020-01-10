using System;

namespace vivael
{
	public class data_projetinfo : DataSource
	{
		public data_projetinfo() { Table_name = i.name = "projetinfo"; i.primary_1 = "numéro"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Numéro; public int Numéro { get { return _Numéro; } set { Set(ref _Numéro, value, "Numéro"); } }
		private string _Description; public string Description { get { return _Description; } set { Set(ref _Description, value, "Description"); } }
		private string _Note; public string Note { get { return _Note; } set { Set(ref _Note, value, "Note"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private string _Priorité; public string Priorité { get { return _Priorité; } set { Set(ref _Priorité, value, "Priorité"); } }
		private DateTime? _Datedem; public DateTime? Datedem { get { return _Datedem; } set { Set(ref _Datedem, value, "Datedem"); } }
		private string _Approuve; public string Approuve { get { return _Approuve; } set { Set(ref _Approuve, value, "Approuve"); } }
		private DateTime? _Dateapprob; public DateTime? Dateapprob { get { return _Dateapprob; } set { Set(ref _Dateapprob, value, "Dateapprob"); } }
		private DateTime? _Datemod; public DateTime? Datemod { get { return _Datemod; } set { Set(ref _Datemod, value, "Datemod"); } }
		private string _Par; public string Par { get { return _Par; } set { Set(ref _Par, value, "Par"); } }
		private string _Version; public string Version { get { return _Version; } set { Set(ref _Version, value, "Version"); } }
		private string _Noteprog; public string Noteprog { get { return _Noteprog; } set { Set(ref _Noteprog, value, "Noteprog"); } }
		private string _Module; public string Module { get { return _Module; } set { Set(ref _Module, value, "Module"); } }
		private string _Noteapp; public string Noteapp { get { return _Noteapp; } set { Set(ref _Noteapp, value, "Noteapp"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dte; public DateTime? Mod_Dte { get { return _Mod_Dte; } set { Set(ref _Mod_Dte, value, "Mod_Dte"); } }

	}
}