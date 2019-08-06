using System;

namespace vivael
{
	public class data_ivdemtranspd : DataSource
	{
		public data_ivdemtranspd() { Table_name = i.name = "ivdemtranspd"; i.primary_1 = "iddemtransp"; i.primary_2 = "line"; i.primary_3 = null; isFoxpro = true; }

		private int _Iddemtransp; public int Iddemtransp { get { return _Iddemtransp; } set { Set(ref _Iddemtransp, value, "Iddemtransp"); } }
		private short _Line; public short Line { get { return _Line; } set { Set(ref _Line, value, "Line"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Qty; public int? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }
		private string _Descprod; public string Descprod { get { return _Descprod; } set { Set(ref _Descprod, value, "Descprod"); } }
		private decimal? _Vol_Boites; public decimal? Vol_Boites { get { return _Vol_Boites; } set { Set(ref _Vol_Boites, value, "Vol_Boites"); } }
		private decimal? _Vol_Autres; public decimal? Vol_Autres { get { return _Vol_Autres; } set { Set(ref _Vol_Autres, value, "Vol_Autres"); } }

	}
}