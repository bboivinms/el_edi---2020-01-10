using System;

namespace vivael
{
	public class data_ivpricei : DataSource
	{
		public data_ivpricei() { Table_name = i.name = "ivpricei"; i.primary_1 = "idprice"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Idprice; public int Idprice { get { return _Idprice; } set { Set(ref _Idprice, value, "Idprice"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Idpack; public int? Idpack { get { return _Idpack; } set { Set(ref _Idpack, value, "Idpack"); } }
		private decimal? _Price; public decimal? Price { get { return _Price; } set { Set(ref _Price, value, "Price"); } }

	}
}