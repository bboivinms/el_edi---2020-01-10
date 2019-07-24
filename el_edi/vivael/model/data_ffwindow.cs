using System;

namespace vivael
{
	public class data_ffwindow : DataSource
	{
		public data_ffwindow() { Table_name = i.name = "ffwindow"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private int? _Idmach; public int? Idmach { get { return _Idmach; } set { Set(ref _Idmach, value, "Idmach"); } }
		private int? _Idmach2; public int? Idmach2 { get { return _Idmach2; } set { Set(ref _Idmach2, value, "Idmach2"); } }
		private int? _Idmach3; public int? Idmach3 { get { return _Idmach3; } set { Set(ref _Idmach3, value, "Idmach3"); } }
		private decimal? _Hauteur; public decimal? Hauteur { get { return _Hauteur; } set { Set(ref _Hauteur, value, "Hauteur"); } }
		private decimal? _Largeur; public decimal? Largeur { get { return _Largeur; } set { Set(ref _Largeur, value, "Largeur"); } }
		private decimal? _Hauteur2; public decimal? Hauteur2 { get { return _Hauteur2; } set { Set(ref _Hauteur2, value, "Hauteur2"); } }
		private decimal? _Largeur2; public decimal? Largeur2 { get { return _Largeur2; } set { Set(ref _Largeur2, value, "Largeur2"); } }
		private decimal? _Orientation; public decimal? Orientation { get { return _Orientation; } set { Set(ref _Orientation, value, "Orientation"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private decimal? _Distg; public decimal? Distg { get { return _Distg; } set { Set(ref _Distg, value, "Distg"); } }
		private decimal? _Distb; public decimal? Distb { get { return _Distb; } set { Set(ref _Distb, value, "Distb"); } }
		private decimal? _Distg1; public decimal? Distg1 { get { return _Distg1; } set { Set(ref _Distg1, value, "Distg1"); } }
		private decimal? _Distg2; public decimal? Distg2 { get { return _Distg2; } set { Set(ref _Distg2, value, "Distg2"); } }
		private decimal? _Bloc; public decimal? Bloc { get { return _Bloc; } set { Set(ref _Bloc, value, "Bloc"); } }
		private decimal? _Film; public decimal? Film { get { return _Film; } set { Set(ref _Film, value, "Film"); } }
		private decimal? _Up; public decimal? Up { get { return _Up; } set { Set(ref _Up, value, "Up"); } }
		private string _Gummer; public string Gummer { get { return _Gummer; } set { Set(ref _Gummer, value, "Gummer"); } }
		private bool? _Blocs; public bool? Blocs { get { return _Blocs; } set { Set(ref _Blocs, value, "Blocs"); } }
		private bool? _Blocd; public bool? Blocd { get { return _Blocd; } set { Set(ref _Blocd, value, "Blocd"); } }
		private string _Gear; public string Gear { get { return _Gear; } set { Set(ref _Gear, value, "Gear"); } }

	}
}