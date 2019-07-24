using System;

namespace vivael
{
	public class data_infodetail : DataSource
	{
		public data_infodetail() { Table_name = i.name = "infodetail"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private int? _Ident; public int? Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private DateTime? _Date1; public DateTime? Date1 { get { return _Date1; } set { Set(ref _Date1, value, "Date1"); } }
		private string _Travail; public string Travail { get { return _Travail; } set { Set(ref _Travail, value, "Travail"); } }
		private string _Temps; public string Temps { get { return _Temps; } set { Set(ref _Temps, value, "Temps"); } }

	}
}