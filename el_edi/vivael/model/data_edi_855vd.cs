using System;

namespace vivael
{
	public class data_edi_855vd : DataSource
	{
		public data_edi_855vd() { Table_name = i.name = "edi_855vd"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Popoi_Line; public string Popoi_Line { get { return _Popoi_Line; } set { Set(ref _Popoi_Line, value, "Popoi_Line"); } }
		private string _Popoi_Qty_Tot; public string Popoi_Qty_Tot { get { return _Popoi_Qty_Tot; } set { Set(ref _Popoi_Qty_Tot, value, "Popoi_Qty_Tot"); } }
		private string _Popoi_Unit; public string Popoi_Unit { get { return _Popoi_Unit; } set { Set(ref _Popoi_Unit, value, "Popoi_Unit"); } }
		private decimal? _Popoi_Cost; public decimal? Popoi_Cost { get { return _Popoi_Cost; } set { Set(ref _Popoi_Cost, value, "Popoi_Cost"); } }
		private string _Popoi_Unite; public string Popoi_Unite { get { return _Popoi_Unite; } set { Set(ref _Popoi_Unite, value, "Popoi_Unite"); } }
		private string _Ivprix_Ref_Fourn; public string Ivprix_Ref_Fourn { get { return _Ivprix_Ref_Fourn; } set { Set(ref _Ivprix_Ref_Fourn, value, "Ivprix_Ref_Fourn"); } }
		private string _Ivprod_Code; public string Ivprod_Code { get { return _Ivprod_Code; } set { Set(ref _Ivprod_Code, value, "Ivprod_Code"); } }
		private string _Ivprod_Desc; public string Ivprod_Desc { get { return _Ivprod_Desc; } set { Set(ref _Ivprod_Desc, value, "Ivprod_Desc"); } }
		private string _Popo_Pono; public string Popo_Pono { get { return _Popo_Pono; } set { Set(ref _Popo_Pono, value, "Popo_Pono"); } }
		private int? _Popoi_Idpo; public int? Popoi_Idpo { get { return _Popoi_Idpo; } set { Set(ref _Popoi_Idpo, value, "Popoi_Idpo"); } }
		private string _Statuscode; public string Statuscode { get { return _Statuscode; } set { Set(ref _Statuscode, value, "Statuscode"); } }
		private string _Popoi_Qty_Ord; public string Popoi_Qty_Ord { get { return _Popoi_Qty_Ord; } set { Set(ref _Popoi_Qty_Ord, value, "Popoi_Qty_Ord"); } }
		private string _Popoi_Item_Unit; public string Popoi_Item_Unit { get { return _Popoi_Item_Unit; } set { Set(ref _Popoi_Item_Unit, value, "Popoi_Item_Unit"); } }
		private DateTime? _Popo_Expe_Dte; public DateTime? Popo_Expe_Dte { get { return _Popo_Expe_Dte; } set { Set(ref _Popo_Expe_Dte, value, "Popo_Expe_Dte"); } }
		private string _Programid; public string Programid { get { return _Programid; } set { Set(ref _Programid, value, "Programid"); } }
		private string _Error; public string Error { get { return _Error; } set { Set(ref _Error, value, "Error"); } }
		private string _Xml855itemraw; public string Xml855itemraw { get { return _Xml855itemraw; } set { Set(ref _Xml855itemraw, value, "Xml855itemraw"); } }

	}
}