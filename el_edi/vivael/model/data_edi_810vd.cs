using System;

namespace vivael
{
	public class data_edi_810vd : DataSource
	{
		public data_edi_810vd() { Table_name = i.name = "edi_810vd"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Arinvd_Invline; public int? Arinvd_Invline { get { return _Arinvd_Invline; } set { Set(ref _Arinvd_Invline, value, "Arinvd_Invline"); } }
		private string _Arinvd_Qty; public string Arinvd_Qty { get { return _Arinvd_Qty; } set { Set(ref _Arinvd_Qty, value, "Arinvd_Qty"); } }
		private string _Unitmeasurementcode; public string Unitmeasurementcode { get { return _Unitmeasurementcode; } set { Set(ref _Unitmeasurementcode, value, "Unitmeasurementcode"); } }
		private string _Arinvd_Inv_Mnt_Unit; public string Arinvd_Inv_Mnt_Unit { get { return _Arinvd_Inv_Mnt_Unit; } set { Set(ref _Arinvd_Inv_Mnt_Unit, value, "Arinvd_Inv_Mnt_Unit"); } }
		private string _Unitpricecode; public string Unitpricecode { get { return _Unitpricecode; } set { Set(ref _Unitpricecode, value, "Unitpricecode"); } }
		private string _Ivprixdcli_Codecli; public string Ivprixdcli_Codecli { get { return _Ivprixdcli_Codecli; } set { Set(ref _Ivprixdcli_Codecli, value, "Ivprixdcli_Codecli"); } }
		private string _Ivprod_Code; public string Ivprod_Code { get { return _Ivprod_Code; } set { Set(ref _Ivprod_Code, value, "Ivprod_Code"); } }
		private string _Ivprod_Desc; public string Ivprod_Desc { get { return _Ivprod_Desc; } set { Set(ref _Ivprod_Desc, value, "Ivprod_Desc"); } }
		private string _Arinvd_Idbil; public string Arinvd_Idbil { get { return _Arinvd_Idbil; } set { Set(ref _Arinvd_Idbil, value, "Arinvd_Idbil"); } }
		private string _Cocom_Clientpo; public string Cocom_Clientpo { get { return _Cocom_Clientpo; } set { Set(ref _Cocom_Clientpo, value, "Cocom_Clientpo"); } }
		private string _Cocom_Ident; public string Cocom_Ident { get { return _Cocom_Ident; } set { Set(ref _Cocom_Ident, value, "Cocom_Ident"); } }
		private string _Programid; public string Programid { get { return _Programid; } set { Set(ref _Programid, value, "Programid"); } }
		private string _Xml810itemraw; public string Xml810itemraw { get { return _Xml810itemraw; } set { Set(ref _Xml810itemraw, value, "Xml810itemraw"); } }

	}
}