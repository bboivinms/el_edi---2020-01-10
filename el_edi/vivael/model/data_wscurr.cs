using System;

namespace vivael
{
	public class data_wscurr : DataSource
	{
		public data_wscurr() { Table_name = i.name = "wscurr"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Country; public string Country { get { return _Country; } set { Set(ref _Country, value, "Country"); } }
		private int? _Nogl_Ar; public int? Nogl_Ar { get { return _Nogl_Ar; } set { Set(ref _Nogl_Ar, value, "Nogl_Ar"); } }
		private int? _Nogl_Acc_Ap; public int? Nogl_Acc_Ap { get { return _Nogl_Acc_Ap; } set { Set(ref _Nogl_Acc_Ap, value, "Nogl_Acc_Ap"); } }
		private int? _Nogl_Ap; public int? Nogl_Ap { get { return _Nogl_Ap; } set { Set(ref _Nogl_Ap, value, "Nogl_Ap"); } }
		private int? _Nogl_Bq; public int? Nogl_Bq { get { return _Nogl_Bq; } set { Set(ref _Nogl_Bq, value, "Nogl_Bq"); } }
		private int? _Def_Aptyppay; public int? Def_Aptyppay { get { return _Def_Aptyppay; } set { Set(ref _Def_Aptyppay, value, "Def_Aptyppay"); } }
		private int? _Nogl_Contra; public int? Nogl_Contra { get { return _Nogl_Contra; } set { Set(ref _Nogl_Contra, value, "Nogl_Contra"); } }
		private int? _Nogl_Bq_Chrg; public int? Nogl_Bq_Chrg { get { return _Nogl_Bq_Chrg; } set { Set(ref _Nogl_Bq_Chrg, value, "Nogl_Bq_Chrg"); } }

	}
}