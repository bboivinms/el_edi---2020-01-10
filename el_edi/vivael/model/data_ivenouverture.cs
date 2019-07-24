using System;

namespace vivael
{
	public class data_ivenouverture : DataSource
	{
		public data_ivenouverture() { Table_name = i.name = "ivenouverture"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Ouv_Dessin; public string Ouv_Dessin { get { return _Ouv_Dessin; } set { Set(ref _Ouv_Dessin, value, "Ouv_Dessin"); } }

	}
}