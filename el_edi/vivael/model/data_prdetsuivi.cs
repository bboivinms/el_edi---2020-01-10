using System;

namespace vivael
{
	public class data_prdetsuivi : DataSource
	{
		public data_prdetsuivi() { Table_name = i.name = "prdetsuivi"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idfab; public int? Idfab { get { return _Idfab; } set { Set(ref _Idfab, value, "Idfab"); } }
		private int? _Idmach; public int? Idmach { get { return _Idmach; } set { Set(ref _Idmach, value, "Idmach"); } }
		private int? _Idmat; public int? Idmat { get { return _Idmat; } set { Set(ref _Idmat, value, "Idmat"); } }
		private DateTime? _Date_Travail; public DateTime? Date_Travail { get { return _Date_Travail; } set { Set(ref _Date_Travail, value, "Date_Travail"); } }
		private decimal? _Hrs; public decimal? Hrs { get { return _Hrs; } set { Set(ref _Hrs, value, "Hrs"); } }
		private int? _Qte; public int? Qte { get { return _Qte; } set { Set(ref _Qte, value, "Qte"); } }
		private bool? _Termine; public bool? Termine { get { return _Termine; } set { Set(ref _Termine, value, "Termine"); } }

	}
}