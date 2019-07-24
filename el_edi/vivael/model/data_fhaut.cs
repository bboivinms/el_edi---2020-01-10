using System;

namespace vivael
{
	public class data_fhaut : DataSource
	{
		public data_fhaut() { Table_name = i.name = "fhaut"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Qtepaq; public int? Qtepaq { get { return _Qtepaq; } set { Set(ref _Qtepaq, value, "Qtepaq"); } }
		private short? _Nbpaq; public short? Nbpaq { get { return _Nbpaq; } set { Set(ref _Nbpaq, value, "Nbpaq"); } }

	}
}