using System;

namespace vivael
{
	public class data_wspermis : DataSource
	{
		public data_wspermis() { Table_name = i.name = "wspermis"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private string _Group; public string Group { get { return _Group; } set { Set(ref _Group, value, "Group"); } }
		private string _Function; public string Function { get { return _Function; } set { Set(ref _Function, value, "Function"); } }
		private bool? _Ajout; public bool? Ajout { get { return _Ajout; } set { Set(ref _Ajout, value, "Ajout"); } }
		private bool? _Modif; public bool? Modif { get { return _Modif; } set { Set(ref _Modif, value, "Modif"); } }
		private bool? _Supp; public bool? Supp { get { return _Supp; } set { Set(ref _Supp, value, "Supp"); } }
		private bool? _Imp; public bool? Imp { get { return _Imp; } set { Set(ref _Imp, value, "Imp"); } }

	}
}