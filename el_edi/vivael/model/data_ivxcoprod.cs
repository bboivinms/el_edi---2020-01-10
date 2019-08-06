using System;

namespace vivael
{
	public class data_ivxcoprod : DataSource
	{
		public data_ivxcoprod() { Table_name = i.name = "ivxcoprod"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Style; public string Style { get { return _Style; } set { Set(ref _Style, value, "Style"); } }
		private string _Test; public string Test { get { return _Test; } set { Set(ref _Test, value, "Test"); } }
		private string _Test2; public string Test2 { get { return _Test2; } set { Set(ref _Test2, value, "Test2"); } }
		private string _Flute; public string Flute { get { return _Flute; } set { Set(ref _Flute, value, "Flute"); } }
		private string _Fermet; public string Fermet { get { return _Fermet; } set { Set(ref _Fermet, value, "Fermet"); } }
		private string _Autre; public string Autre { get { return _Autre; } set { Set(ref _Autre, value, "Autre"); } }
		private string _Nbcoul; public string Nbcoul { get { return _Nbcoul; } set { Set(ref _Nbcoul, value, "Nbcoul"); } }
		private string _Enduit; public string Enduit { get { return _Enduit; } set { Set(ref _Enduit, value, "Enduit"); } }
		private string _Cire; public string Cire { get { return _Cire; } set { Set(ref _Cire, value, "Cire"); } }
		private int? _Consom; public int? Consom { get { return _Consom; } set { Set(ref _Consom, value, "Consom"); } }
		private string _Consom_Note; public string Consom_Note { get { return _Consom_Note; } set { Set(ref _Consom_Note, value, "Consom_Note"); } }
		private string _Livr; public string Livr { get { return _Livr; } set { Set(ref _Livr, value, "Livr"); } }
		private string _Livr_Note; public string Livr_Note { get { return _Livr_Note; } set { Set(ref _Livr_Note, value, "Livr_Note"); } }
		private string _Mat_Decoup; public string Mat_Decoup { get { return _Mat_Decoup; } set { Set(ref _Mat_Decoup, value, "Mat_Decoup"); } }
		private byte? _Mat_Nb; public byte? Mat_Nb { get { return _Mat_Nb; } set { Set(ref _Mat_Nb, value, "Mat_Nb"); } }
		private string _Mat_Note; public string Mat_Note { get { return _Mat_Note; } set { Set(ref _Mat_Note, value, "Mat_Note"); } }
		private string _Code_Pal; public string Code_Pal { get { return _Code_Pal; } set { Set(ref _Code_Pal, value, "Code_Pal"); } }
		private string _Paquet_Attache; public string Paquet_Attache { get { return _Paquet_Attache; } set { Set(ref _Paquet_Attache, value, "Paquet_Attache"); } }
		private short? _Nb_Paquet_Attache; public short? Nb_Paquet_Attache { get { return _Nb_Paquet_Attache; } set { Set(ref _Nb_Paquet_Attache, value, "Nb_Paquet_Attache"); } }
		private string _Other; public string Other { get { return _Other; } set { Set(ref _Other, value, "Other"); } }
		private string _Item_Id_Print; public string Item_Id_Print { get { return _Item_Id_Print; } set { Set(ref _Item_Id_Print, value, "Item_Id_Print"); } }

	}
}