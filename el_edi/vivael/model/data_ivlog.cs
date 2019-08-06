using System;

namespace vivael
{
	public class data_ivlog : DataSource
	{
		public data_ivlog() { Table_name = i.name = "ivlog"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private int? _Idtrans; public int? Idtrans { get { return _Idtrans; } set { Set(ref _Idtrans, value, "Idtrans"); } }
		private int? _Idprod; public int? Idprod { get { return _Idprod; } set { Set(ref _Idprod, value, "Idprod"); } }
		private int? _Idwareh; public int? Idwareh { get { return _Idwareh; } set { Set(ref _Idwareh, value, "Idwareh"); } }
		private string _Location; public string Location { get { return _Location; } set { Set(ref _Location, value, "Location"); } }
		private DateTime? _Dtetime; public DateTime? Dtetime { get { return _Dtetime; } set { Set(ref _Dtetime, value, "Dtetime"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private long? _Qty; public long? Qty { get { return _Qty; } set { Set(ref _Qty, value, "Qty"); } }

	}
}