using System;

namespace vivael
{
	public class data_edi_810v : DataSource
	{
		public data_edi_810v() { Table_name = i.name = "edi_810v"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = false; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Idvendor; public string Idvendor { get { return _Idvendor; } set { Set(ref _Idvendor, value, "Idvendor"); } }
		private byte _Sent; public byte Sent { get { return _Sent; } set { Set(ref _Sent, value, "Sent"); } }
		private string _Filename; public string Filename { get { return _Filename; } set { Set(ref _Filename, value, "Filename"); } }
		private DateTime? _Arinv_Invdte; public DateTime? Arinv_Invdte { get { return _Arinv_Invdte; } set { Set(ref _Arinv_Invdte, value, "Arinv_Invdte"); } }
		private string _Arinv_Invno; public string Arinv_Invno { get { return _Arinv_Invno; } set { Set(ref _Arinv_Invno, value, "Arinv_Invno"); } }
		private string _Arinv_Po; public string Arinv_Po { get { return _Arinv_Po; } set { Set(ref _Arinv_Po, value, "Arinv_Po"); } }
		private string _Arinv_Idbil; public string Arinv_Idbil { get { return _Arinv_Idbil; } set { Set(ref _Arinv_Idbil, value, "Arinv_Idbil"); } }
		private string _Stname; public string Stname { get { return _Stname; } set { Set(ref _Stname, value, "Stname"); } }
		private string _Stiddel_Addr; public string Stiddel_Addr { get { return _Stiddel_Addr; } set { Set(ref _Stiddel_Addr, value, "Stiddel_Addr"); } }
		private string _Staddr1; public string Staddr1 { get { return _Staddr1; } set { Set(ref _Staddr1, value, "Staddr1"); } }
		private string _Staddr2; public string Staddr2 { get { return _Staddr2; } set { Set(ref _Staddr2, value, "Staddr2"); } }
		private string _Stcity; public string Stcity { get { return _Stcity; } set { Set(ref _Stcity, value, "Stcity"); } }
		private string _Ststate; public string Ststate { get { return _Ststate; } set { Set(ref _Ststate, value, "Ststate"); } }
		private string _Stzip; public string Stzip { get { return _Stzip; } set { Set(ref _Stzip, value, "Stzip"); } }
		private string _Arinv_Inv_Mnt; public string Arinv_Inv_Mnt { get { return _Arinv_Inv_Mnt; } set { Set(ref _Arinv_Inv_Mnt, value, "Arinv_Inv_Mnt"); } }
		private string _Error; public string Error { get { return _Error; } set { Set(ref _Error, value, "Error"); } }
		private string _Programid; public string Programid { get { return _Programid; } set { Set(ref _Programid, value, "Programid"); } }
		private string _Xml810raw; public string Xml810raw { get { return _Xml810raw; } set { Set(ref _Xml810raw, value, "Xml810raw"); } }

	}
}