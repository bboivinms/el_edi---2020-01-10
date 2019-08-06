using System;

namespace vivael
{
	public class data_projtype : DataSource
	{
		public data_projtype() { Table_name = i.name = "projtype"; i.primary_1 = "idtype"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Idtype; public int Idtype { get { return _Idtype; } set { Set(ref _Idtype, value, "Idtype"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }

	}
}