using System;

namespace vivael
{
	public class data_wsfax : DataSource
	{
		public data_wsfax() { Table_name = i.name = "wsfax"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Report_Name; public string Report_Name { get { return _Report_Name; } set { Set(ref _Report_Name, value, "Report_Name"); } }
		private string _Dest; public string Dest { get { return _Dest; } set { Set(ref _Dest, value, "Dest"); } }
		private string _De; public string De { get { return _De; } set { Set(ref _De, value, "De"); } }
		private string _Company; public string Company { get { return _Company; } set { Set(ref _Company, value, "Company"); } }
		private string _Tel; public string Tel { get { return _Tel; } set { Set(ref _Tel, value, "Tel"); } }
		private string _Fcover; public string Fcover { get { return _Fcover; } set { Set(ref _Fcover, value, "Fcover"); } }
		private string _Tcover; public string Tcover { get { return _Tcover; } set { Set(ref _Tcover, value, "Tcover"); } }
		private string _Subject; public string Subject { get { return _Subject; } set { Set(ref _Subject, value, "Subject"); } }
		private DateTime? _Sent_Dtime; public DateTime? Sent_Dtime { get { return _Sent_Dtime; } set { Set(ref _Sent_Dtime, value, "Sent_Dtime"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dtime; public DateTime? Cr_Dtime { get { return _Cr_Dtime; } set { Set(ref _Cr_Dtime, value, "Cr_Dtime"); } }

	}
}