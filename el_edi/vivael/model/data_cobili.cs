using System;

namespace vivael
{
	public class data_cobili : DataSource
	{
		public data_cobili() { Table_name = i.name = "cobili"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int _Idcobil; public int Idcobil { get { return _Idcobil; } set { Set(ref _Idcobil, value, "Idcobil"); } }
		private int _Line; public int Line { get { return _Line; } set { Set(ref _Line, value, "Line"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private long? _Qty; public long? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }
		private decimal? _Price; public decimal? Price { get { return _Price; } set { Set(ref _Price, value, "Price"); } }
		private decimal? _Gst; public decimal? Gst { get { return _Gst; } set { Set(ref _Gst, value, "Gst"); } }
		private decimal? _Pst; public decimal? Pst { get { return _Pst; } set { Set(ref _Pst, value, "Pst"); } }
		private long? _Qty_Inv; public long? Qty_Inv { get { return _Qty_Inv; } set { Set(ref _Qty_Inv, value, "Qty_Inv"); } }
		private long? _Qty_To_Ship; public long? Qty_To_Ship { get { return _Qty_To_Ship; } set { Set(ref _Qty_To_Ship, value, "Qty_To_Ship"); } }
		private string _Detail; public string Detail { get { return _Detail; } set { Set(ref _Detail, value, "Detail"); } }
		private decimal? _Conv; public decimal? Conv { get { return _Conv; } set { Set(ref _Conv, value, "Conv"); } }
		private string _Unite; public string Unite { get { return _Unite; } set { Set(ref _Unite, value, "Unite"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private int? _Warh; public int? Warh { get { return _Warh; } set { Set(ref _Warh, value, "Warh"); } }
		private bool? _Consign; public bool? Consign { get { return _Consign; } set { Set(ref _Consign, value, "Consign"); } }
		private string _Po_No; public string Po_No { get { return _Po_No; } set { Set(ref _Po_No, value, "Po_No"); } }
		private int? _Idcom; public int? Idcom { get { return _Idcom; } set { Set(ref _Idcom, value, "Idcom"); } }
		private int? _Nopalet; public int? Nopalet { get { return _Nopalet; } set { Set(ref _Nopalet, value, "Nopalet"); } }
		private string _Nolot; public string Nolot { get { return _Nolot; } set { Set(ref _Nolot, value, "Nolot"); } }
		private string _Qty_Notes; public string Qty_Notes { get { return _Qty_Notes; } set { Set(ref _Qty_Notes, value, "Qty_Notes"); } }
		private short? _Palliv; public short? Palliv { get { return _Palliv; } set { Set(ref _Palliv, value, "Palliv"); } }
		private long? _Qty_Tra; public long? Qty_Tra { get { return _Qty_Tra; } set { Set(ref _Qty_Tra, value, "Qty_Tra"); } }
		private short? _Pacpc1; public short? Pacpc1 { get { return _Pacpc1; } set { Set(ref _Pacpc1, value, "Pacpc1"); } }
		private short? _Pacpc2; public short? Pacpc2 { get { return _Pacpc2; } set { Set(ref _Pacpc2, value, "Pacpc2"); } }
		private short? _Pacpc3; public short? Pacpc3 { get { return _Pacpc3; } set { Set(ref _Pacpc3, value, "Pacpc3"); } }
		private short? _Pacpc4; public short? Pacpc4 { get { return _Pacpc4; } set { Set(ref _Pacpc4, value, "Pacpc4"); } }
		private short? _Pacpc5; public short? Pacpc5 { get { return _Pacpc5; } set { Set(ref _Pacpc5, value, "Pacpc5"); } }
		private short? _Pareg1; public short? Pareg1 { get { return _Pareg1; } set { Set(ref _Pareg1, value, "Pareg1"); } }
		private short? _Pareg2; public short? Pareg2 { get { return _Pareg2; } set { Set(ref _Pareg2, value, "Pareg2"); } }
		private short? _Pareg3; public short? Pareg3 { get { return _Pareg3; } set { Set(ref _Pareg3, value, "Pareg3"); } }
		private short? _Pareg4; public short? Pareg4 { get { return _Pareg4; } set { Set(ref _Pareg4, value, "Pareg4"); } }
		private short? _Pareg5; public short? Pareg5 { get { return _Pareg5; } set { Set(ref _Pareg5, value, "Pareg5"); } }
		private short? _Pasec1; public short? Pasec1 { get { return _Pasec1; } set { Set(ref _Pasec1, value, "Pasec1"); } }
		private short? _Pasec2; public short? Pasec2 { get { return _Pasec2; } set { Set(ref _Pasec2, value, "Pasec2"); } }
		private short? _Pasec3; public short? Pasec3 { get { return _Pasec3; } set { Set(ref _Pasec3, value, "Pasec3"); } }
		private short? _Pasec4; public short? Pasec4 { get { return _Pasec4; } set { Set(ref _Pasec4, value, "Pasec4"); } }
		private short? _Pasec5; public short? Pasec5 { get { return _Pasec5; } set { Set(ref _Pasec5, value, "Pasec5"); } }
		private short? _Pachep1; public short? Pachep1 { get { return _Pachep1; } set { Set(ref _Pachep1, value, "Pachep1"); } }
		private short? _Pachep2; public short? Pachep2 { get { return _Pachep2; } set { Set(ref _Pachep2, value, "Pachep2"); } }
		private short? _Pachep3; public short? Pachep3 { get { return _Pachep3; } set { Set(ref _Pachep3, value, "Pachep3"); } }
		private short? _Pachep4; public short? Pachep4 { get { return _Pachep4; } set { Set(ref _Pachep4, value, "Pachep4"); } }
		private short? _Pachep5; public short? Pachep5 { get { return _Pachep5; } set { Set(ref _Pachep5, value, "Pachep5"); } }
		private short? _Pams1; public short? Pams1 { get { return _Pams1; } set { Set(ref _Pams1, value, "Pams1"); } }
		private short? _Pams2; public short? Pams2 { get { return _Pams2; } set { Set(ref _Pams2, value, "Pams2"); } }
		private short? _Pams3; public short? Pams3 { get { return _Pams3; } set { Set(ref _Pams3, value, "Pams3"); } }
		private short? _Pams4; public short? Pams4 { get { return _Pams4; } set { Set(ref _Pams4, value, "Pams4"); } }
		private short? _Pams5; public short? Pams5 { get { return _Pams5; } set { Set(ref _Pams5, value, "Pams5"); } }

	}
}