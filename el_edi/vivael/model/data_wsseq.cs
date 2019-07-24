using System;

namespace vivael
{
	public class data_wsseq : DataSource
	{
		public data_wsseq() { Table_name = i.name = "wsseq"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Tableid; public string Tableid { get { return _Tableid; } set { Set(ref _Tableid, value, "Tableid"); } }
		private int? _Next_Id; public int? Next_Id { get { return _Next_Id; } set { Set(ref _Next_Id, value, "Next_Id"); } }
		private int? _Tmp_Id; public int? Tmp_Id { get { return _Tmp_Id; } set { Set(ref _Tmp_Id, value, "Tmp_Id"); } }
		private DateTime? _Datelast; public DateTime? Datelast { get { return _Datelast; } set { Set(ref _Datelast, value, "Datelast"); } }

	}
}