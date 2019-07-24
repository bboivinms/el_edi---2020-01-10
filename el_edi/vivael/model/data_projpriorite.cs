using System;

namespace vivael
{
	public class data_projpriorite : DataSource
	{
		public data_projpriorite() { Table_name = i.name = "projpriorite"; i.primary_1 = "idpriorité"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Idpriorité; public int Idpriorité { get { return _Idpriorité; } set { Set(ref _Idpriorité, value, "Idpriorité"); } }
		private string _Priorité; public string Priorité { get { return _Priorité; } set { Set(ref _Priorité, value, "Priorité"); } }

	}
}