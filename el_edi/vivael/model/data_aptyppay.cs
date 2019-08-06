using System;

namespace vivael
{
	public class data_aptyppay : DataSource
	{
		public data_aptyppay() { Table_name = i.name = "aptyppay"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private byte _Ident; public byte Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private int? _Bq_Accnt_Id; public int? Bq_Accnt_Id { get { return _Bq_Accnt_Id; } set { Set(ref _Bq_Accnt_Id, value, "Bq_Accnt_Id"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private bool? _Chq; public bool? Chq { get { return _Chq; } set { Set(ref _Chq, value, "Chq"); } }
		private bool? _Input_Ref; public bool? Input_Ref { get { return _Input_Ref; } set { Set(ref _Input_Ref, value, "Input_Ref"); } }
		private int? _Next_Chq; public int? Next_Chq { get { return _Next_Chq; } set { Set(ref _Next_Chq, value, "Next_Chq"); } }

	}
}