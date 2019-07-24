using System;

namespace vivael
{
	public class data_cocomi : DataSource
	{
		public data_cocomi() { Table_name = i.name = "cocomi"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Idco; public int Idco { get { return _Idco; } set { Set(ref _Idco, value, "Idco"); } }
		private int _Line; public int Line { get { return _Line; } set { Set(ref _Line, value, "Line"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private long? _Qty_Ord; public long? Qty_Ord { get { return _Qty_Ord; } set { Set(ref _Qty_Ord, value, "Qty_Ord"); } }
		private long? _Qty_To_Del; public long? Qty_To_Del { get { return _Qty_To_Del; } set { Set(ref _Qty_To_Del, value, "Qty_To_Del"); } }
		private long? _Qty_Del; public long? Qty_Del { get { return _Qty_Del; } set { Set(ref _Qty_Del, value, "Qty_Del"); } }
		private long? _Qty_Inv; public long? Qty_Inv { get { return _Qty_Inv; } set { Set(ref _Qty_Inv, value, "Qty_Inv"); } }
		private decimal? _Price; public decimal? Price { get { return _Price; } set { Set(ref _Price, value, "Price"); } }
		private decimal? _Gst; public decimal? Gst { get { return _Gst; } set { Set(ref _Gst, value, "Gst"); } }
		private decimal? _Pst; public decimal? Pst { get { return _Pst; } set { Set(ref _Pst, value, "Pst"); } }
		private int? _Idquote; public int? Idquote { get { return _Idquote; } set { Set(ref _Idquote, value, "Idquote"); } }
		private long? _Qty_Del_On_Rec; public long? Qty_Del_On_Rec { get { return _Qty_Del_On_Rec; } set { Set(ref _Qty_Del_On_Rec, value, "Qty_Del_On_Rec"); } }
		private int? _Nblot; public int? Nblot { get { return _Nblot; } set { Set(ref _Nblot, value, "Nblot"); } }
		private string _Unite; public string Unite { get { return _Unite; } set { Set(ref _Unite, value, "Unite"); } }
		private int? _Idquote_Order; public int? Idquote_Order { get { return _Idquote_Order; } set { Set(ref _Idquote_Order, value, "Idquote_Order"); } }
		private decimal? _Conv; public decimal? Conv { get { return _Conv; } set { Set(ref _Conv, value, "Conv"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private int? _Warh; public int? Warh { get { return _Warh; } set { Set(ref _Warh, value, "Warh"); } }
		private string _Qty_Notes; public string Qty_Notes { get { return _Qty_Notes; } set { Set(ref _Qty_Notes, value, "Qty_Notes"); } }
		private decimal? _Hst; public decimal? Hst { get { return _Hst; } set { Set(ref _Hst, value, "Hst"); } }
		private int? _Nopalet; public int? Nopalet { get { return _Nopalet; } set { Set(ref _Nopalet, value, "Nopalet"); } }
		private string _Nolot; public string Nolot { get { return _Nolot; } set { Set(ref _Nolot, value, "Nolot"); } }
		private int? _Qtentrec; public int? Qtentrec { get { return _Qtentrec; } set { Set(ref _Qtentrec, value, "Qtentrec"); } }
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
		private long? _Qty_Tra; public long? Qty_Tra { get { return _Qty_Tra; } set { Set(ref _Qty_Tra, value, "Qty_Tra"); } }
		private DateTime? _Req_Date; public DateTime? Req_Date { get { return _Req_Date; } set { Set(ref _Req_Date, value, "Req_Date"); } }
		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }

	}
}