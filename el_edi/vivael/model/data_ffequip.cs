using System;

namespace vivael
{
	public class data_ffequip : DataSource
	{
		public data_ffequip() { Table_name = i.name = "ffequip"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Noequip; public string Noequip { get { return _Noequip; } set { Set(ref _Noequip, value, "Noequip"); } }
		private string _Descriptio; public string Descriptio { get { return _Descriptio; } set { Set(ref _Descriptio, value, "Descriptio"); } }
		private bool? _Inactif; public bool? Inactif { get { return _Inactif; } set { Set(ref _Inactif, value, "Inactif"); } }
		private string _Noplaque; public string Noplaque { get { return _Noplaque; } set { Set(ref _Noplaque, value, "Noplaque"); } }
		private string _Noserie; public string Noserie { get { return _Noserie; } set { Set(ref _Noserie, value, "Noserie"); } }
		private DateTime? _Dateacquis; public DateTime? Dateacquis { get { return _Dateacquis; } set { Set(ref _Dateacquis, value, "Dateacquis"); } }
		private int? _Hauteur; public int? Hauteur { get { return _Hauteur; } set { Set(ref _Hauteur, value, "Hauteur"); } }
		private int? _Longueur; public int? Longueur { get { return _Longueur; } set { Set(ref _Longueur, value, "Longueur"); } }
		private int? _Largeur; public int? Largeur { get { return _Largeur; } set { Set(ref _Largeur, value, "Largeur"); } }
		private string _Marque; public string Marque { get { return _Marque; } set { Set(ref _Marque, value, "Marque"); } }
		private string _Modele; public string Modele { get { return _Modele; } set { Set(ref _Modele, value, "Modele"); } }
		private short? _Année; public short? Année { get { return _Année; } set { Set(ref _Année, value, "Année"); } }
		private DateTime? _Datefingar; public DateTime? Datefingar { get { return _Datefingar; } set { Set(ref _Datefingar, value, "Datefingar"); } }
		private bool? _Livraison; public bool? Livraison { get { return _Livraison; } set { Set(ref _Livraison, value, "Livraison"); } }
		private string _Note; public string Note { get { return _Note; } set { Set(ref _Note, value, "Note"); } }
		private bool? _Remorque; public bool? Remorque { get { return _Remorque; } set { Set(ref _Remorque, value, "Remorque"); } }
		private bool? _Chariot; public bool? Chariot { get { return _Chariot; } set { Set(ref _Chariot, value, "Chariot"); } }
		private int? _Idgl; public int? Idgl { get { return _Idgl; } set { Set(ref _Idgl, value, "Idgl"); } }

	}
}