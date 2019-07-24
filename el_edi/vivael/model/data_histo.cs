using System;

namespace vivael
{
	public class data_histo : DataSource
	{
		public data_histo() { Table_name = i.name = "histo"; i.primary_1 = "do_not_sync"; i.primary_2 = "ident"; i.primary_3 = null; isFoxpro = false; }

		private string _Do_Not_Sync; public string Do_Not_Sync { get { return _Do_Not_Sync; } set { Set(ref _Do_Not_Sync, value, "Do_Not_Sync"); } }
		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Projet; public int? Projet { get { return _Projet; } set { Set(ref _Projet, value, "Projet"); } }
		private string _Code1; public string Code1 { get { return _Code1; } set { Set(ref _Code1, value, "Code1"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Papier; public string Papier { get { return _Papier; } set { Set(ref _Papier, value, "Papier"); } }
		private string _Column5; public string Column5 { get { return _Column5; } set { Set(ref _Column5, value, "Column5"); } }
		private string _Column6; public string Column6 { get { return _Column6; } set { Set(ref _Column6, value, "Column6"); } }
		private string _Column7; public string Column7 { get { return _Column7; } set { Set(ref _Column7, value, "Column7"); } }
		private string _Column8; public string Column8 { get { return _Column8; } set { Set(ref _Column8, value, "Column8"); } }
		private string _Column9; public string Column9 { get { return _Column9; } set { Set(ref _Column9, value, "Column9"); } }
		private string _Column10; public string Column10 { get { return _Column10; } set { Set(ref _Column10, value, "Column10"); } }
		private string _Column11; public string Column11 { get { return _Column11; } set { Set(ref _Column11, value, "Column11"); } }
		private string _Column12; public string Column12 { get { return _Column12; } set { Set(ref _Column12, value, "Column12"); } }
		private string _Column13; public string Column13 { get { return _Column13; } set { Set(ref _Column13, value, "Column13"); } }
		private string _Column14; public string Column14 { get { return _Column14; } set { Set(ref _Column14, value, "Column14"); } }
		private string _Column15; public string Column15 { get { return _Column15; } set { Set(ref _Column15, value, "Column15"); } }
		private string _Column16; public string Column16 { get { return _Column16; } set { Set(ref _Column16, value, "Column16"); } }
		private string _Column17; public string Column17 { get { return _Column17; } set { Set(ref _Column17, value, "Column17"); } }
		private string _Column18; public string Column18 { get { return _Column18; } set { Set(ref _Column18, value, "Column18"); } }
		private string _Column19; public string Column19 { get { return _Column19; } set { Set(ref _Column19, value, "Column19"); } }
		private string _Column20; public string Column20 { get { return _Column20; } set { Set(ref _Column20, value, "Column20"); } }
		private string _Column21; public string Column21 { get { return _Column21; } set { Set(ref _Column21, value, "Column21"); } }
		private string _Column22; public string Column22 { get { return _Column22; } set { Set(ref _Column22, value, "Column22"); } }
		private string _Column23; public string Column23 { get { return _Column23; } set { Set(ref _Column23, value, "Column23"); } }
		private string _Column24; public string Column24 { get { return _Column24; } set { Set(ref _Column24, value, "Column24"); } }
		private string _Column25; public string Column25 { get { return _Column25; } set { Set(ref _Column25, value, "Column25"); } }
		private string _Column26; public string Column26 { get { return _Column26; } set { Set(ref _Column26, value, "Column26"); } }
		private string _Column27; public string Column27 { get { return _Column27; } set { Set(ref _Column27, value, "Column27"); } }
		private string _Column28; public string Column28 { get { return _Column28; } set { Set(ref _Column28, value, "Column28"); } }
		private string _Column29; public string Column29 { get { return _Column29; } set { Set(ref _Column29, value, "Column29"); } }
		private string _Column30; public string Column30 { get { return _Column30; } set { Set(ref _Column30, value, "Column30"); } }
		private string _Column31; public string Column31 { get { return _Column31; } set { Set(ref _Column31, value, "Column31"); } }
		private string _Column32; public string Column32 { get { return _Column32; } set { Set(ref _Column32, value, "Column32"); } }
		private string _Column33; public string Column33 { get { return _Column33; } set { Set(ref _Column33, value, "Column33"); } }
		private string _Column34; public string Column34 { get { return _Column34; } set { Set(ref _Column34, value, "Column34"); } }
		private string _Column35; public string Column35 { get { return _Column35; } set { Set(ref _Column35, value, "Column35"); } }
		private string _Column36; public string Column36 { get { return _Column36; } set { Set(ref _Column36, value, "Column36"); } }
		private string _Column37; public string Column37 { get { return _Column37; } set { Set(ref _Column37, value, "Column37"); } }
		private string _Column38; public string Column38 { get { return _Column38; } set { Set(ref _Column38, value, "Column38"); } }
		private string _Column39; public string Column39 { get { return _Column39; } set { Set(ref _Column39, value, "Column39"); } }
		private string _Column40; public string Column40 { get { return _Column40; } set { Set(ref _Column40, value, "Column40"); } }
		private string _Column41; public string Column41 { get { return _Column41; } set { Set(ref _Column41, value, "Column41"); } }
		private string _Sacprod; public string Sacprod { get { return _Sacprod; } set { Set(ref _Sacprod, value, "Sacprod"); } }
		private string _Client; public string Client { get { return _Client; } set { Set(ref _Client, value, "Client"); } }
		private string _Addliv; public string Addliv { get { return _Addliv; } set { Set(ref _Addliv, value, "Addliv"); } }
		private string _Addfact; public string Addfact { get { return _Addfact; } set { Set(ref _Addfact, value, "Addfact"); } }
		private DateTime? _Dat; public DateTime? Dat { get { return _Dat; } set { Set(ref _Dat, value, "Dat"); } }
		private string _Equipement; public string Equipement { get { return _Equipement; } set { Set(ref _Equipement, value, "Equipement"); } }
		private string _Descriptio; public string Descriptio { get { return _Descriptio; } set { Set(ref _Descriptio, value, "Descriptio"); } }
		private long? _Qtecomm; public long? Qtecomm { get { return _Qtecomm; } set { Set(ref _Qtecomm, value, "Qtecomm"); } }
		private long? _N; public long? N { get { return _N; } set { Set(ref _N, value, "N"); } }
		private string _Bcclient; public string Bcclient { get { return _Bcclient; } set { Set(ref _Bcclient, value, "Bcclient"); } }
		private string _Type_Prod; public string Type_Prod { get { return _Type_Prod; } set { Set(ref _Type_Prod, value, "Type_Prod"); } }
		private long? _Qteproduit; public long? Qteproduit { get { return _Qteproduit; } set { Set(ref _Qteproduit, value, "Qteproduit"); } }

	}
}