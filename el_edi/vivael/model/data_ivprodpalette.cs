using System;

namespace vivael
{
	public class data_ivprodpalette : DataSource
	{
		public data_ivprodpalette() { Table_name = i.name = "ivprodpalette"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Description; public string Description { get { return _Description; } set { Set(ref _Description, value, "Description"); } }
		private string _Fig; public string Fig { get { return _Fig; } set { Set(ref _Fig, value, "Fig"); } }

	}
}