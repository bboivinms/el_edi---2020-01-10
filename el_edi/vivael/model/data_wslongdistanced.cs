using System;

namespace vivael
{
	public class data_wslongdistanced : DataSource
	{
		public data_wslongdistanced() { Table_name = i.name = "wslongdistanced"; i.primary_1 = "idld"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Idld; public int Idld { get { return _Idld; } set { Set(ref _Idld, value, "Idld"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }

	}
}