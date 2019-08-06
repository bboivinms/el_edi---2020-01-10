using System;

namespace vivael
{
	public class data_edi_856v : DataSource
	{
		public data_edi_856v() { Table_name = i.name = "edi_856v"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private int? _Idvendor; public int? Idvendor { get { return _Idvendor; } set { Set(ref _Idvendor, value, "Idvendor"); } }
		private long _Popo_Ref; public long Popo_Ref { get { return _Popo_Ref; } set { Set(ref _Popo_Ref, value, "Popo_Ref"); } }
		private byte _Sent; public byte Sent { get { return _Sent; } set { Set(ref _Sent, value, "Sent"); } }
		private string _Filename; public string Filename { get { return _Filename; } set { Set(ref _Filename, value, "Filename"); } }
		private DateTime? _Ship_Date; public DateTime? Ship_Date { get { return _Ship_Date; } set { Set(ref _Ship_Date, value, "Ship_Date"); } }
		private DateTime? _Shipped_Date; public DateTime? Shipped_Date { get { return _Shipped_Date; } set { Set(ref _Shipped_Date, value, "Shipped_Date"); } }
		private DateTime? _Estimated_Delivery_Date; public DateTime? Estimated_Delivery_Date { get { return _Estimated_Delivery_Date; } set { Set(ref _Estimated_Delivery_Date, value, "Estimated_Delivery_Date"); } }
		private int? _Shipmentid; public int? Shipmentid { get { return _Shipmentid; } set { Set(ref _Shipmentid, value, "Shipmentid"); } }
		private string _Popoi_Qty; public string Popoi_Qty { get { return _Popoi_Qty; } set { Set(ref _Popoi_Qty, value, "Popoi_Qty"); } }
		private string _Packagingcode; public string Packagingcode { get { return _Packagingcode; } set { Set(ref _Packagingcode, value, "Packagingcode"); } }
		private string _Stname; public string Stname { get { return _Stname; } set { Set(ref _Stname, value, "Stname"); } }
		private string _Staddr1; public string Staddr1 { get { return _Staddr1; } set { Set(ref _Staddr1, value, "Staddr1"); } }
		private string _Staddr2; public string Staddr2 { get { return _Staddr2; } set { Set(ref _Staddr2, value, "Staddr2"); } }
		private string _Stcity; public string Stcity { get { return _Stcity; } set { Set(ref _Stcity, value, "Stcity"); } }
		private string _Ststate; public string Ststate { get { return _Ststate; } set { Set(ref _Ststate, value, "Ststate"); } }
		private string _Stzip; public string Stzip { get { return _Stzip; } set { Set(ref _Stzip, value, "Stzip"); } }
		private string _Shiptoaddr; public string Shiptoaddr { get { return _Shiptoaddr; } set { Set(ref _Shiptoaddr, value, "Shiptoaddr"); } }
		private string _Programid; public string Programid { get { return _Programid; } set { Set(ref _Programid, value, "Programid"); } }
		private string _Xml856raw; public string Xml856raw { get { return _Xml856raw; } set { Set(ref _Xml856raw, value, "Xml856raw"); } }

	}
}