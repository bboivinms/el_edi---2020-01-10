using System;

namespace vivael
{
	public class data_prplanif : DataSource
	{
		public data_prplanif() { Table_name = i.name = "prplanif"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Nomach; public string Nomach { get { return _Nomach; } set { Set(ref _Nomach, value, "Nomach"); } }
		private int? _Ordre; public int? Ordre { get { return _Ordre; } set { Set(ref _Ordre, value, "Ordre"); } }
		private string _Item; public string Item { get { return _Item; } set { Set(ref _Item, value, "Item"); } }
		private string _Client; public string Client { get { return _Client; } set { Set(ref _Client, value, "Client"); } }
		private int? _Prno; public int? Prno { get { return _Prno; } set { Set(ref _Prno, value, "Prno"); } }
		private decimal? _Temps; public decimal? Temps { get { return _Temps; } set { Set(ref _Temps, value, "Temps"); } }
		private long? _Qte; public long? Qte { get { return _Qte; } set { Set(ref _Qte, value, "Qte"); } }
		private string _Nouveau; public string Nouveau { get { return _Nouveau; } set { Set(ref _Nouveau, value, "Nouveau"); } }
		private DateTime? _Date_Requi; public DateTime? Date_Requi { get { return _Date_Requi; } set { Set(ref _Date_Requi, value, "Date_Requi"); } }
		private string _Attente; public string Attente { get { return _Attente; } set { Set(ref _Attente, value, "Attente"); } }
		private DateTime? _Date_Plani; public DateTime? Date_Plani { get { return _Date_Plani; } set { Set(ref _Date_Plani, value, "Date_Plani"); } }
		private long? _Qte_Restan; public long? Qte_Restan { get { return _Qte_Restan; } set { Set(ref _Qte_Restan, value, "Qte_Restan"); } }
		private int? _Nbrheure; public int? Nbrheure { get { return _Nbrheure; } set { Set(ref _Nbrheure, value, "Nbrheure"); } }
		private bool? _Rush; public bool? Rush { get { return _Rush; } set { Set(ref _Rush, value, "Rush"); } }
		private int? _Idnomach; public int? Idnomach { get { return _Idnomach; } set { Set(ref _Idnomach, value, "Idnomach"); } }
		private bool? _Termine; public bool? Termine { get { return _Termine; } set { Set(ref _Termine, value, "Termine"); } }
		private bool? _Tinfo; public bool? Tinfo { get { return _Tinfo; } set { Set(ref _Tinfo, value, "Tinfo"); } }
		private bool? _Tinv; public bool? Tinv { get { return _Tinv; } set { Set(ref _Tinv, value, "Tinv"); } }
		private bool? _Tetape; public bool? Tetape { get { return _Tetape; } set { Set(ref _Tetape, value, "Tetape"); } }
		private bool? _Tcout; public bool? Tcout { get { return _Tcout; } set { Set(ref _Tcout, value, "Tcout"); } }
		private int? _Machineid; public int? Machineid { get { return _Machineid; } set { Set(ref _Machineid, value, "Machineid"); } }

	}
}