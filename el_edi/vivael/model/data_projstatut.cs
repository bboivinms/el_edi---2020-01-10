using System;

namespace vivael
{
	public class data_projstatut : DataSource
	{
		public data_projstatut() { Table_name = i.name = "projstatut"; i.primary_1 = "idstatut"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Idstatut; public int Idstatut { get { return _Idstatut; } set { Set(ref _Idstatut, value, "Idstatut"); } }
		private string _Statut; public string Statut { get { return _Statut; } set { Set(ref _Statut, value, "Statut"); } }

	}
}