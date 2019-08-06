using System;

namespace vivael
{
	public class data_arinvec : DataSource
	{
		public data_arinvec() { Table_name = i.name = "arinvec"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private byte? _Invline; public byte? Invline { get { return _Invline; } set { Set(ref _Invline, value, "Invline"); } }
		private string _Invcode; public string Invcode { get { return _Invcode; } set { Set(ref _Invcode, value, "Invcode"); } }
		private decimal? _Ecost_Mnt; public decimal? Ecost_Mnt { get { return _Ecost_Mnt; } set { Set(ref _Ecost_Mnt, value, "Ecost_Mnt"); } }
		private string _Ecost_Mnt_; public string Ecost_Mnt_ { get { return _Ecost_Mnt_; } set { Set(ref _Ecost_Mnt_, value, "Ecost_Mnt_"); } }
		private string _Ppd_Col; public string Ppd_Col { get { return _Ppd_Col; } set { Set(ref _Ppd_Col, value, "Ppd_Col"); } }
		private int? _Ecost_Supp; public int? Ecost_Supp { get { return _Ecost_Supp; } set { Set(ref _Ecost_Supp, value, "Ecost_Supp"); } }
		private string _Ecost_Ref; public string Ecost_Ref { get { return _Ecost_Ref; } set { Set(ref _Ecost_Ref, value, "Ecost_Ref"); } }

	}
}