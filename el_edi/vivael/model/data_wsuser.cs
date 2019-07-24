using System;

namespace vivael
{
	public class data_wsuser : DataSource
	{
		public data_wsuser() { Table_name = i.name = "wsuser"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private decimal? _Idnum; public decimal? Idnum { get { return _Idnum; } set { Set(ref _Idnum, value, "Idnum"); } }
		private string _Group; public string Group { get { return _Group; } set { Set(ref _Group, value, "Group"); } }
		private string _Passwd; public string Passwd { get { return _Passwd; } set { Set(ref _Passwd, value, "Passwd"); } }
		private bool? _Active; public bool? Active { get { return _Active; } set { Set(ref _Active, value, "Active"); } }
		private byte? _Usertimer; public byte? Usertimer { get { return _Usertimer; } set { Set(ref _Usertimer, value, "Usertimer"); } }
		private int? _Fbackcolor; public int? Fbackcolor { get { return _Fbackcolor; } set { Set(ref _Fbackcolor, value, "Fbackcolor"); } }
		private int? _Fforecolor; public int? Fforecolor { get { return _Fforecolor; } set { Set(ref _Fforecolor, value, "Fforecolor"); } }
		private int? _Fdisabledbackcolor; public int? Fdisabledbackcolor { get { return _Fdisabledbackcolor; } set { Set(ref _Fdisabledbackcolor, value, "Fdisabledbackcolor"); } }
		private int? _Fdisabledforecolor; public int? Fdisabledforecolor { get { return _Fdisabledforecolor; } set { Set(ref _Fdisabledforecolor, value, "Fdisabledforecolor"); } }
		private int? _Lbackcolor; public int? Lbackcolor { get { return _Lbackcolor; } set { Set(ref _Lbackcolor, value, "Lbackcolor"); } }
		private int? _Lforecolor; public int? Lforecolor { get { return _Lforecolor; } set { Set(ref _Lforecolor, value, "Lforecolor"); } }
		private int? _Ldisabledbackcolor; public int? Ldisabledbackcolor { get { return _Ldisabledbackcolor; } set { Set(ref _Ldisabledbackcolor, value, "Ldisabledbackcolor"); } }
		private int? _Ldisabledforecolor; public int? Ldisabledforecolor { get { return _Ldisabledforecolor; } set { Set(ref _Ldisabledforecolor, value, "Ldisabledforecolor"); } }
		private int? _Wbackcolor; public int? Wbackcolor { get { return _Wbackcolor; } set { Set(ref _Wbackcolor, value, "Wbackcolor"); } }
		private int? _Wforecolor; public int? Wforecolor { get { return _Wforecolor; } set { Set(ref _Wforecolor, value, "Wforecolor"); } }
		private string _Wpicture; public string Wpicture { get { return _Wpicture; } set { Set(ref _Wpicture, value, "Wpicture"); } }
		private int? _Bforecolor; public int? Bforecolor { get { return _Bforecolor; } set { Set(ref _Bforecolor, value, "Bforecolor"); } }
		private int? _Bdisabledforecolor; public int? Bdisabledforecolor { get { return _Bdisabledforecolor; } set { Set(ref _Bdisabledforecolor, value, "Bdisabledforecolor"); } }
		private string _Spicture; public string Spicture { get { return _Spicture; } set { Set(ref _Spicture, value, "Spicture"); } }
		private string _Language; public string Language { get { return _Language; } set { Set(ref _Language, value, "Language"); } }
		private string _Ubar1; public string Ubar1 { get { return _Ubar1; } set { Set(ref _Ubar1, value, "Ubar1"); } }
		private string _Ubar2; public string Ubar2 { get { return _Ubar2; } set { Set(ref _Ubar2, value, "Ubar2"); } }
		private string _Ubar3; public string Ubar3 { get { return _Ubar3; } set { Set(ref _Ubar3, value, "Ubar3"); } }
		private string _Ubar4; public string Ubar4 { get { return _Ubar4; } set { Set(ref _Ubar4, value, "Ubar4"); } }
		private string _Ubar5; public string Ubar5 { get { return _Ubar5; } set { Set(ref _Ubar5, value, "Ubar5"); } }
		private string _Ubar6; public string Ubar6 { get { return _Ubar6; } set { Set(ref _Ubar6, value, "Ubar6"); } }
		private string _Ubar7; public string Ubar7 { get { return _Ubar7; } set { Set(ref _Ubar7, value, "Ubar7"); } }
		private string _Ubar8; public string Ubar8 { get { return _Ubar8; } set { Set(ref _Ubar8, value, "Ubar8"); } }
		private string _Ubar9; public string Ubar9 { get { return _Ubar9; } set { Set(ref _Ubar9, value, "Ubar9"); } }
		private string _Ubar10; public string Ubar10 { get { return _Ubar10; } set { Set(ref _Ubar10, value, "Ubar10"); } }
		private string _Ubarimg1; public string Ubarimg1 { get { return _Ubarimg1; } set { Set(ref _Ubarimg1, value, "Ubarimg1"); } }
		private string _Ubarimg2; public string Ubarimg2 { get { return _Ubarimg2; } set { Set(ref _Ubarimg2, value, "Ubarimg2"); } }
		private string _Ubarimg3; public string Ubarimg3 { get { return _Ubarimg3; } set { Set(ref _Ubarimg3, value, "Ubarimg3"); } }
		private string _Ubarimg4; public string Ubarimg4 { get { return _Ubarimg4; } set { Set(ref _Ubarimg4, value, "Ubarimg4"); } }
		private string _Ubarimg5; public string Ubarimg5 { get { return _Ubarimg5; } set { Set(ref _Ubarimg5, value, "Ubarimg5"); } }
		private string _Ubarimg6; public string Ubarimg6 { get { return _Ubarimg6; } set { Set(ref _Ubarimg6, value, "Ubarimg6"); } }
		private string _Ubarimg7; public string Ubarimg7 { get { return _Ubarimg7; } set { Set(ref _Ubarimg7, value, "Ubarimg7"); } }
		private string _Ubarimg8; public string Ubarimg8 { get { return _Ubarimg8; } set { Set(ref _Ubarimg8, value, "Ubarimg8"); } }
		private string _Ubarimg9; public string Ubarimg9 { get { return _Ubarimg9; } set { Set(ref _Ubarimg9, value, "Ubarimg9"); } }
		private string _Ubarimg10; public string Ubarimg10 { get { return _Ubarimg10; } set { Set(ref _Ubarimg10, value, "Ubarimg10"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private byte? _Sec_Level; public byte? Sec_Level { get { return _Sec_Level; } set { Set(ref _Sec_Level, value, "Sec_Level"); } }
		private bool? _Canmodclientaccntg; public bool? Canmodclientaccntg { get { return _Canmodclientaccntg; } set { Set(ref _Canmodclientaccntg, value, "Canmodclientaccntg"); } }
		private bool? _Can_Mod_Report; public bool? Can_Mod_Report { get { return _Can_Mod_Report; } set { Set(ref _Can_Mod_Report, value, "Can_Mod_Report"); } }
		private int? _Arrep; public int? Arrep { get { return _Arrep; } set { Set(ref _Arrep, value, "Arrep"); } }
		private bool? _Limited; public bool? Limited { get { return _Limited; } set { Set(ref _Limited, value, "Limited"); } }
		private int? _Date_Format; public int? Date_Format { get { return _Date_Format; } set { Set(ref _Date_Format, value, "Date_Format"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private bool? _Email_Bcc_Self; public bool? Email_Bcc_Self { get { return _Email_Bcc_Self; } set { Set(ref _Email_Bcc_Self, value, "Email_Bcc_Self"); } }
		private string _Email_Signature; public string Email_Signature { get { return _Email_Signature; } set { Set(ref _Email_Signature, value, "Email_Signature"); } }
		private string _Msn; public string Msn { get { return _Msn; } set { Set(ref _Msn, value, "Msn"); } }
		private string _Tel; public string Tel { get { return _Tel; } set { Set(ref _Tel, value, "Tel"); } }
		private string _Title; public string Title { get { return _Title; } set { Set(ref _Title, value, "Title"); } }
		private bool? _Administrator; public bool? Administrator { get { return _Administrator; } set { Set(ref _Administrator, value, "Administrator"); } }
		private string _Basket_Dir; public string Basket_Dir { get { return _Basket_Dir; } set { Set(ref _Basket_Dir, value, "Basket_Dir"); } }
		private bool? _Accountant; public bool? Accountant { get { return _Accountant; } set { Set(ref _Accountant, value, "Accountant"); } }
		private bool? _Set_Menu; public bool? Set_Menu { get { return _Set_Menu; } set { Set(ref _Set_Menu, value, "Set_Menu"); } }
		private bool? _Msg_Recep; public bool? Msg_Recep { get { return _Msg_Recep; } set { Set(ref _Msg_Recep, value, "Msg_Recep"); } }
		private string _Cie; public string Cie { get { return _Cie; } set { Set(ref _Cie, value, "Cie"); } }

	}
}