using System;

namespace vivael
{
	public class data_wsschem : DataSource
	{
		public data_wsschem() { Table_name = i.name = "wsschem"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Desc; public string Desc { get { return _Desc; } set { Set(ref _Desc, value, "Desc"); } }
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

	}
}