using System;

namespace vivael
{
	public class data_caaction : DataSource
	{
		public data_caaction() { Table_name = i.name = "caaction"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Coderelated; public string Coderelated { get { return _Coderelated; } set { Set(ref _Coderelated, value, "Coderelated"); } }
		private int? _Idrelated; public int? Idrelated { get { return _Idrelated; } set { Set(ref _Idrelated, value, "Idrelated"); } }
		private string _Related; public string Related { get { return _Related; } set { Set(ref _Related, value, "Related"); } }
		private string _Typeaction; public string Typeaction { get { return _Typeaction; } set { Set(ref _Typeaction, value, "Typeaction"); } }
		private string _Typecalendar; public string Typecalendar { get { return _Typecalendar; } set { Set(ref _Typecalendar, value, "Typecalendar"); } }
		private string _Subject; public string Subject { get { return _Subject; } set { Set(ref _Subject, value, "Subject"); } }
		private string _Details; public string Details { get { return _Details; } set { Set(ref _Details, value, "Details"); } }
		private bool? _Done; public bool? Done { get { return _Done; } set { Set(ref _Done, value, "Done"); } }
		private DateTime? _Done_Dte; public DateTime? Done_Dte { get { return _Done_Dte; } set { Set(ref _Done_Dte, value, "Done_Dte"); } }
		private DateTime? _Action_Dte; public DateTime? Action_Dte { get { return _Action_Dte; } set { Set(ref _Action_Dte, value, "Action_Dte"); } }
		private string _Action_Hr; public string Action_Hr { get { return _Action_Hr; } set { Set(ref _Action_Hr, value, "Action_Hr"); } }
		private bool? _Important; public bool? Important { get { return _Important; } set { Set(ref _Important, value, "Important"); } }
		private string _Attached; public string Attached { get { return _Attached; } set { Set(ref _Attached, value, "Attached"); } }
		private DateTime? _Cr_Datetime; public DateTime? Cr_Datetime { get { return _Cr_Datetime; } set { Set(ref _Cr_Datetime, value, "Cr_Datetime"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private int? _Idrate; public int? Idrate { get { return _Idrate; } set { Set(ref _Idrate, value, "Idrate"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Datetime; public DateTime? Mod_Datetime { get { return _Mod_Datetime; } set { Set(ref _Mod_Datetime, value, "Mod_Datetime"); } }

	}
}