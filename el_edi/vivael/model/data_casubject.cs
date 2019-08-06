using System;

namespace vivael
{
	public class data_casubject : DataSource
	{
		public data_casubject() { Table_name = i.name = "casubject"; i.primary_1 = "descr"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }

	}
}