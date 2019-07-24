using System;

namespace vivael
{
	public class data_wsnotes : DataSource
	{
		public data_wsnotes() { Table_name = i.name = "wsnotes"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Context1; public string Context1 { get { return _Context1; } set { Set(ref _Context1, value, "Context1"); } }
		private string _Context2; public string Context2 { get { return _Context2; } set { Set(ref _Context2, value, "Context2"); } }
		private string _Reckey; public string Reckey { get { return _Reckey; } set { Set(ref _Reckey, value, "Reckey"); } }
		private DateTime? _Cr_Dte; public DateTime? Cr_Dte { get { return _Cr_Dte; } set { Set(ref _Cr_Dte, value, "Cr_Dte"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private string _Subject; public string Subject { get { return _Subject; } set { Set(ref _Subject, value, "Subject"); } }
		private string _Attfile; public string Attfile { get { return _Attfile; } set { Set(ref _Attfile, value, "Attfile"); } }
		private bool? _Important; public bool? Important { get { return _Important; } set { Set(ref _Important, value, "Important"); } }
		private string _Touser; public string Touser { get { return _Touser; } set { Set(ref _Touser, value, "Touser"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }

	}
}