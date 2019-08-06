using System;

namespace vivael
{
	public class data_arcode : DataSource
	{
		public data_arcode() { Table_name = i.name = "arcode"; i.primary_1 = "activity"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private string _Activity; public string Activity { get { return _Activity; } set { Set(ref _Activity, value, "Activity"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Showcode; public string Showcode { get { return _Showcode; } set { Set(ref _Showcode, value, "Showcode"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Descr2; public string Descr2 { get { return _Descr2; } set { Set(ref _Descr2, value, "Descr2"); } }
		private string _Descr3; public string Descr3 { get { return _Descr3; } set { Set(ref _Descr3, value, "Descr3"); } }
		private string _Short; public string Short { get { return _Short; } set { Set(ref _Short, value, "Short"); } }
		private string _Short2; public string Short2 { get { return _Short2; } set { Set(ref _Short2, value, "Short2"); } }
		private string _Short3; public string Short3 { get { return _Short3; } set { Set(ref _Short3, value, "Short3"); } }
		private byte? _Mawb_Position; public byte? Mawb_Position { get { return _Mawb_Position; } set { Set(ref _Mawb_Position, value, "Mawb_Position"); } }
		private int? _Glaccnt_Rev; public int? Glaccnt_Rev { get { return _Glaccnt_Rev; } set { Set(ref _Glaccnt_Rev, value, "Glaccnt_Rev"); } }
		private int? _Glaccnt_Cost; public int? Glaccnt_Cost { get { return _Glaccnt_Cost; } set { Set(ref _Glaccnt_Cost, value, "Glaccnt_Cost"); } }
		private byte? _Tx_Gst_Code; public byte? Tx_Gst_Code { get { return _Tx_Gst_Code; } set { Set(ref _Tx_Gst_Code, value, "Tx_Gst_Code"); } }
		private byte? _Tx_Pst_Code; public byte? Tx_Pst_Code { get { return _Tx_Pst_Code; } set { Set(ref _Tx_Pst_Code, value, "Tx_Pst_Code"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Datetime; public DateTime? Cr_Datetime { get { return _Cr_Datetime; } set { Set(ref _Cr_Datetime, value, "Cr_Datetime"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Datetime; public DateTime? Mod_Datetime { get { return _Mod_Datetime; } set { Set(ref _Mod_Datetime, value, "Mod_Datetime"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private bool? _Isduty; public bool? Isduty { get { return _Isduty; } set { Set(ref _Isduty, value, "Isduty"); } }
		private byte? _Stat_Head; public byte? Stat_Head { get { return _Stat_Head; } set { Set(ref _Stat_Head, value, "Stat_Head"); } }

	}
}