using System;

namespace vivael
{
	public class data_ffcontact : DataSource
	{
		public data_ffcontact() { Table_name = i.name = "ffcontact"; i.primary_1 = "ident_ai"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident_Ai; public int Ident_Ai { get { return _Ident_Ai; } set { Set(ref _Ident_Ai, value, "Ident_Ai"); } }
		private int? _Ident; public int? Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private string _Title; public string Title { get { return _Title; } set { Set(ref _Title, value, "Title"); } }
		private string _Tel1; public string Tel1 { get { return _Tel1; } set { Set(ref _Tel1, value, "Tel1"); } }
		private string _Tel2; public string Tel2 { get { return _Tel2; } set { Set(ref _Tel2, value, "Tel2"); } }
		private string _Fax; public string Fax { get { return _Fax; } set { Set(ref _Fax, value, "Fax"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private string _Paget; public string Paget { get { return _Paget; } set { Set(ref _Paget, value, "Paget"); } }
		private string _Language; public string Language { get { return _Language; } set { Set(ref _Language, value, "Language"); } }
		private bool? _Principal; public bool? Principal { get { return _Principal; } set { Set(ref _Principal, value, "Principal"); } }
		private bool? _Accounting; public bool? Accounting { get { return _Accounting; } set { Set(ref _Accounting, value, "Accounting"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private bool? _Tel1_Free; public bool? Tel1_Free { get { return _Tel1_Free; } set { Set(ref _Tel1_Free, value, "Tel1_Free"); } }
		private bool? _Tel2_Free; public bool? Tel2_Free { get { return _Tel2_Free; } set { Set(ref _Tel2_Free, value, "Tel2_Free"); } }
		private bool? _Fax_Free; public bool? Fax_Free { get { return _Fax_Free; } set { Set(ref _Fax_Free, value, "Fax_Free"); } }
		private int? _Idcontact; public int? Idcontact { get { return _Idcontact; } set { Set(ref _Idcontact, value, "Idcontact"); } }
		private bool? _Ecomm; public bool? Ecomm { get { return _Ecomm; } set { Set(ref _Ecomm, value, "Ecomm"); } }
		private bool? _Dem_Prix; public bool? Dem_Prix { get { return _Dem_Prix; } set { Set(ref _Dem_Prix, value, "Dem_Prix"); } }
		private bool? _Poachat; public bool? Poachat { get { return _Poachat; } set { Set(ref _Poachat, value, "Poachat"); } }
		private string _Tel1poste; public string Tel1poste { get { return _Tel1poste; } set { Set(ref _Tel1poste, value, "Tel1poste"); } }
		private string _Tel2poste; public string Tel2poste { get { return _Tel2poste; } set { Set(ref _Tel2poste, value, "Tel2poste"); } }
		private bool? _Approb; public bool? Approb { get { return _Approb; } set { Set(ref _Approb, value, "Approb"); } }
		private bool? _Exlot; public bool? Exlot { get { return _Exlot; } set { Set(ref _Exlot, value, "Exlot"); } }

	}
}