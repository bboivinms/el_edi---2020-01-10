using System;

namespace vivael
{
	public class data_edi_856vd : DataSource
	{
		public data_edi_856vd() { Table_name = i.name = "edi_856vd"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Shipmentid; public int? Shipmentid { get { return _Shipmentid; } set { Set(ref _Shipmentid, value, "Shipmentid"); } }
		private string _Popo_Pono; public string Popo_Pono { get { return _Popo_Pono; } set { Set(ref _Popo_Pono, value, "Popo_Pono"); } }
		private string _Popo_Dte; public string Popo_Dte { get { return _Popo_Dte; } set { Set(ref _Popo_Dte, value, "Popo_Dte"); } }
		private string _Popo_Ident; public string Popo_Ident { get { return _Popo_Ident; } set { Set(ref _Popo_Ident, value, "Popo_Ident"); } }
		private int? _Popoi_Line; public int? Popoi_Line { get { return _Popoi_Line; } set { Set(ref _Popoi_Line, value, "Popoi_Line"); } }
		private string _Ivprix_Ref_Fourn; public string Ivprix_Ref_Fourn { get { return _Ivprix_Ref_Fourn; } set { Set(ref _Ivprix_Ref_Fourn, value, "Ivprix_Ref_Fourn"); } }
		private string _Ivprod_Code; public string Ivprod_Code { get { return _Ivprod_Code; } set { Set(ref _Ivprod_Code, value, "Ivprod_Code"); } }
		private string _Ivprod_Desc; public string Ivprod_Desc { get { return _Ivprod_Desc; } set { Set(ref _Ivprod_Desc, value, "Ivprod_Desc"); } }
		private string _Ivprod_Ident; public string Ivprod_Ident { get { return _Ivprod_Ident; } set { Set(ref _Ivprod_Ident, value, "Ivprod_Ident"); } }
		private string _Qtyshipped; public string Qtyshipped { get { return _Qtyshipped; } set { Set(ref _Qtyshipped, value, "Qtyshipped"); } }
		private string _Unitqtyshippedcode; public string Unitqtyshippedcode { get { return _Unitqtyshippedcode; } set { Set(ref _Unitqtyshippedcode, value, "Unitqtyshippedcode"); } }
		private string _Measurementvalue; public string Measurementvalue { get { return _Measurementvalue; } set { Set(ref _Measurementvalue, value, "Measurementvalue"); } }
		private string _Measurementcode; public string Measurementcode { get { return _Measurementcode; } set { Set(ref _Measurementcode, value, "Measurementcode"); } }
		private string _Serialnumber; public string Serialnumber { get { return _Serialnumber; } set { Set(ref _Serialnumber, value, "Serialnumber"); } }
		private string _Programid; public string Programid { get { return _Programid; } set { Set(ref _Programid, value, "Programid"); } }
		private string _Xml856itemraw; public string Xml856itemraw { get { return _Xml856itemraw; } set { Set(ref _Xml856itemraw, value, "Xml856itemraw"); } }

	}
}