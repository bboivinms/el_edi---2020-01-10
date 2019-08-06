using System;

namespace vivael
{
	public class data_wsbasket : DataSource
	{
		public data_wsbasket() { Table_name = i.name = "wsbasket"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Attachment; public string Attachment { get { return _Attachment; } set { Set(ref _Attachment, value, "Attachment"); } }
		private string _Own_By; public string Own_By { get { return _Own_By; } set { Set(ref _Own_By, value, "Own_By"); } }
		private string _Report_Title; public string Report_Title { get { return _Report_Title; } set { Set(ref _Report_Title, value, "Report_Title"); } }

	}
}