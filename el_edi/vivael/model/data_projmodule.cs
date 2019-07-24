using System;

namespace vivael
{
	public class data_projmodule : DataSource
	{
		public data_projmodule() { Table_name = i.name = "projmodule"; i.primary_1 = "idmodule"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Idmodule; public int Idmodule { get { return _Idmodule; } set { Set(ref _Idmodule, value, "Idmodule"); } }
		private string _Module; public string Module { get { return _Module; } set { Set(ref _Module, value, "Module"); } }

	}
}