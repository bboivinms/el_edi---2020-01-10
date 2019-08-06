using System;

namespace vivael
{
	public class data_ivxcmprod : DataSource
	{
		public data_ivxcmprod() { Table_name = i.name = "ivxcmprod"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Format; public string Format { get { return _Format; } set { Set(ref _Format, value, "Format"); } }
		private string _Ouvert; public string Ouvert { get { return _Ouvert; } set { Set(ref _Ouvert, value, "Ouvert"); } }
		private string _Ferme; public string Ferme { get { return _Ferme; } set { Set(ref _Ferme, value, "Ferme"); } }
		private string _Papier; public string Papier { get { return _Papier; } set { Set(ref _Papier, value, "Papier"); } }
		private bool? _Trou; public bool? Trou { get { return _Trou; } set { Set(ref _Trou, value, "Trou"); } }
		private int? _Trounb; public int? Trounb { get { return _Trounb; } set { Set(ref _Trounb, value, "Trounb"); } }
		private bool? _Numero; public bool? Numero { get { return _Numero; } set { Set(ref _Numero, value, "Numero"); } }
		private int? _Nbpos; public int? Nbpos { get { return _Nbpos; } set { Set(ref _Nbpos, value, "Nbpos"); } }
		private bool? _Cellostd; public bool? Cellostd { get { return _Cellostd; } set { Set(ref _Cellostd, value, "Cellostd"); } }
		private long? _Celloqte; public long? Celloqte { get { return _Celloqte; } set { Set(ref _Celloqte, value, "Celloqte"); } }
		private bool? _Btstd; public bool? Btstd { get { return _Btstd; } set { Set(ref _Btstd, value, "Btstd"); } }
		private long? _Btstdqte; public long? Btstdqte { get { return _Btstdqte; } set { Set(ref _Btstdqte, value, "Btstdqte"); } }
		private string _Autre; public string Autre { get { return _Autre; } set { Set(ref _Autre, value, "Autre"); } }
		private string _Colrecto; public string Colrecto { get { return _Colrecto; } set { Set(ref _Colrecto, value, "Colrecto"); } }
		private string _Colverso; public string Colverso { get { return _Colverso; } set { Set(ref _Colverso, value, "Colverso"); } }
		private int? _Colautre; public int? Colautre { get { return _Colautre; } set { Set(ref _Colautre, value, "Colautre"); } }
		private long? _Livqte; public long? Livqte { get { return _Livqte; } set { Set(ref _Livqte, value, "Livqte"); } }
		private string _Livbroc; public string Livbroc { get { return _Livbroc; } set { Set(ref _Livbroc, value, "Livbroc"); } }
		private long? _Livtable; public long? Livtable { get { return _Livtable; } set { Set(ref _Livtable, value, "Livtable"); } }
		private bool? _Livcouv; public bool? Livcouv { get { return _Livcouv; } set { Set(ref _Livcouv, value, "Livcouv"); } }
		private string _Livcote; public string Livcote { get { return _Livcote; } set { Set(ref _Livcote, value, "Livcote"); } }
		private string _Trouposphy; public string Trouposphy { get { return _Trouposphy; } set { Set(ref _Trouposphy, value, "Trouposphy"); } }
		private string _Troudiam; public string Troudiam { get { return _Troudiam; } set { Set(ref _Troudiam, value, "Troudiam"); } }
		private string _Numposphy; public string Numposphy { get { return _Numposphy; } set { Set(ref _Numposphy, value, "Numposphy"); } }
		private string _Numcoul; public string Numcoul { get { return _Numcoul; } set { Set(ref _Numcoul, value, "Numcoul"); } }
		private bool? _Fsclogo; public bool? Fsclogo { get { return _Fsclogo; } set { Set(ref _Fsclogo, value, "Fsclogo"); } }
		private bool? _Recylogo; public bool? Recylogo { get { return _Recylogo; } set { Set(ref _Recylogo, value, "Recylogo"); } }
		private decimal? _Poid1000; public decimal? Poid1000 { get { return _Poid1000; } set { Set(ref _Poid1000, value, "Poid1000"); } }

	}
}