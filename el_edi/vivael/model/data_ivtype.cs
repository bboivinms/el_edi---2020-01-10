using System;

namespace vivael
{
	public class data_ivtype : DataSource
	{
		public data_ivtype() { Table_name = i.name = "ivtype"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
		private int? _Idgl_Inv; public int? Idgl_Inv { get { return _Idgl_Inv; } set { Set(ref _Idgl_Inv, value, "Idgl_Inv"); } }
		private int? _Idgl_Adj; public int? Idgl_Adj { get { return _Idgl_Adj; } set { Set(ref _Idgl_Adj, value, "Idgl_Adj"); } }
		private int? _Idgl_Rev; public int? Idgl_Rev { get { return _Idgl_Rev; } set { Set(ref _Idgl_Rev, value, "Idgl_Rev"); } }
		private decimal? _Pctg; public decimal? Pctg { get { return _Pctg; } set { Set(ref _Pctg, value, "Pctg"); } }
		private int? _Idgl_Cost; public int? Idgl_Cost { get { return _Idgl_Cost; } set { Set(ref _Idgl_Cost, value, "Idgl_Cost"); } }

	}
}