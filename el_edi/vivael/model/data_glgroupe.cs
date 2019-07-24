using System;

namespace vivael
{
	public class data_glgroupe : DataSource
	{
		public data_glgroupe() { Table_name = i.name = "glgroupe"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private int? _Seq; public int? Seq { get { return _Seq; } set { Set(ref _Seq, value, "Seq"); } }
		private string _Accnt_Type; public string Accnt_Type { get { return _Accnt_Type; } set { Set(ref _Accnt_Type, value, "Accnt_Type"); } }
		private string _Operation; public string Operation { get { return _Operation; } set { Set(ref _Operation, value, "Operation"); } }

	}
}