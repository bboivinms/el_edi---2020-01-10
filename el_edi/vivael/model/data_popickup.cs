using System;

namespace vivael
{
	public class data_popickup : DataSource
	{
		public data_popickup() { Table_name = i.name = "popickup"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Pono; public int? Pono { get { return _Pono; } set { Set(ref _Pono, value, "Pono"); } }
		private DateTime? _Date; public DateTime? Date { get { return _Date; } set { Set(ref _Date, value, "Date"); } }
		private int? _Trpid; public int? Trpid { get { return _Trpid; } set { Set(ref _Trpid, value, "Trpid"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Qteliv; public int? Qteliv { get { return _Qteliv; } set { Set(ref _Qteliv, value, "Qteliv"); } }
		private int? _Espcam; public int? Espcam { get { return _Espcam; } set { Set(ref _Espcam, value, "Espcam"); } }
		private byte? _Trpordre; public byte? Trpordre { get { return _Trpordre; } set { Set(ref _Trpordre, value, "Trpordre"); } }

	}
}