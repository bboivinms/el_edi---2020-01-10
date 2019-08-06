using System;

namespace vivael
{
	public class data_wspform : DataSource
	{
		public data_wspform() { Table_name = i.name = "wspform"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Formcode; public string Formcode { get { return _Formcode; } set { Set(ref _Formcode, value, "Formcode"); } }
		private string _Formname; public string Formname { get { return _Formname; } set { Set(ref _Formname, value, "Formname"); } }
		private string _Formfile; public string Formfile { get { return _Formfile; } set { Set(ref _Formfile, value, "Formfile"); } }
		private bool? _Std_Form; public bool? Std_Form { get { return _Std_Form; } set { Set(ref _Std_Form, value, "Std_Form"); } }
		private bool? _Def_Form; public bool? Def_Form { get { return _Def_Form; } set { Set(ref _Def_Form, value, "Def_Form"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private bool? _Enabled; public bool? Enabled { get { return _Enabled; } set { Set(ref _Enabled, value, "Enabled"); } }

	}
}