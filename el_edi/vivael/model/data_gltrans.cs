using System;

namespace vivael
{
	public class data_gltrans : DataSource
	{
		public data_gltrans() { Table_name = i.name = "gltrans"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Origin; public string Origin { get { return _Origin; } set { Set(ref _Origin, value, "Origin"); } }
		private DateTime? _Date; public DateTime? Date { get { return _Date; } set { Set(ref _Date, value, "Date"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Per; public byte? Acc_Per { get { return _Acc_Per; } set { Set(ref _Acc_Per, value, "Acc_Per"); } }
		private DateTime? _Cr_Dtime; public DateTime? Cr_Dtime { get { return _Cr_Dtime; } set { Set(ref _Cr_Dtime, value, "Cr_Dtime"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Mod_Dtime; public DateTime? Mod_Dtime { get { return _Mod_Dtime; } set { Set(ref _Mod_Dtime, value, "Mod_Dtime"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }

	}
}