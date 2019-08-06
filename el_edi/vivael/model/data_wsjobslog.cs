using System;

namespace vivael
{
	public class data_wsjobslog : DataSource
	{
		public data_wsjobslog() { Table_name = i.name = "wsjobslog"; i.primary_1 = "idjobs"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Idjobs; public int Idjobs { get { return _Idjobs; } set { Set(ref _Idjobs, value, "Idjobs"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private DateTime? _Donedate; public DateTime? Donedate { get { return _Donedate; } set { Set(ref _Donedate, value, "Donedate"); } }

	}
}