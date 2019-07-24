using System;

namespace vivael
{
	public class data_glaccnt : DataSource
	{
		public data_glaccnt() { Table_name = i.name = "glaccnt"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Accnt_No; public int? Accnt_No { get { return _Accnt_No; } set { Set(ref _Accnt_No, value, "Accnt_No"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private string _Accnt_Type; public string Accnt_Type { get { return _Accnt_Type; } set { Set(ref _Accnt_Type, value, "Accnt_Type"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private DateTime? _Cr_Dtime; public DateTime? Cr_Dtime { get { return _Cr_Dtime; } set { Set(ref _Cr_Dtime, value, "Cr_Dtime"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Mod_Dtime; public DateTime? Mod_Dtime { get { return _Mod_Dtime; } set { Set(ref _Mod_Dtime, value, "Mod_Dtime"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private bool? _Active; public bool? Active { get { return _Active; } set { Set(ref _Active, value, "Active"); } }
		private bool? _Appl_Purch; public bool? Appl_Purch { get { return _Appl_Purch; } set { Set(ref _Appl_Purch, value, "Appl_Purch"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private int? _Idgroupe; public int? Idgroupe { get { return _Idgroupe; } set { Set(ref _Idgroupe, value, "Idgroupe"); } }
		private bool? _Is_Bank; public bool? Is_Bank { get { return _Is_Bank; } set { Set(ref _Is_Bank, value, "Is_Bank"); } }
		private int? _Idglgrrb; public int? Idglgrrb { get { return _Idglgrrb; } set { Set(ref _Idglgrrb, value, "Idglgrrb"); } }
		private bool? _Cptdv; public bool? Cptdv { get { return _Cptdv; } set { Set(ref _Cptdv, value, "Cptdv"); } }
		private int? _Idssgr; public int? Idssgr { get { return _Idssgr; } set { Set(ref _Idssgr, value, "Idssgr"); } }

	}
}