using System;

namespace vivael
{
	public class data_wsemail : DataSource
	{
		public data_wsemail() { Table_name = i.name = "wsemail"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Msgtype; public string Msgtype { get { return _Msgtype; } set { Set(ref _Msgtype, value, "Msgtype"); } }
		private string _Subject; public string Subject { get { return _Subject; } set { Set(ref _Subject, value, "Subject"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Attached; public string Attached { get { return _Attached; } set { Set(ref _Attached, value, "Attached"); } }
		private DateTime? _Cr_Dtime; public DateTime? Cr_Dtime { get { return _Cr_Dtime; } set { Set(ref _Cr_Dtime, value, "Cr_Dtime"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private bool? _Important; public bool? Important { get { return _Important; } set { Set(ref _Important, value, "Important"); } }
		private string _From_User; public string From_User { get { return _From_User; } set { Set(ref _From_User, value, "From_User"); } }
		private string _Dest_User; public string Dest_User { get { return _Dest_User; } set { Set(ref _Dest_User, value, "Dest_User"); } }
		private string _Dest_Adr; public string Dest_Adr { get { return _Dest_Adr; } set { Set(ref _Dest_Adr, value, "Dest_Adr"); } }
		private bool? _Sent; public bool? Sent { get { return _Sent; } set { Set(ref _Sent, value, "Sent"); } }
		private DateTime? _Sent_Dtime; public DateTime? Sent_Dtime { get { return _Sent_Dtime; } set { Set(ref _Sent_Dtime, value, "Sent_Dtime"); } }
		private string _Bcc; public string Bcc { get { return _Bcc; } set { Set(ref _Bcc, value, "Bcc"); } }
		private string _Cc; public string Cc { get { return _Cc; } set { Set(ref _Cc, value, "Cc"); } }
		private string _Sender; public string Sender { get { return _Sender; } set { Set(ref _Sender, value, "Sender"); } }

	}
}