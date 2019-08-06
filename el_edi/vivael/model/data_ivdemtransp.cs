using System;

namespace vivael
{
	public class data_ivdemtransp : DataSource
	{
		public data_ivdemtransp() { Table_name = i.name = "ivdemtransp"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Pick_Name; public string Pick_Name { get { return _Pick_Name; } set { Set(ref _Pick_Name, value, "Pick_Name"); } }
		private string _Pick_Add; public string Pick_Add { get { return _Pick_Add; } set { Set(ref _Pick_Add, value, "Pick_Add"); } }
		private string _Del_Name; public string Del_Name { get { return _Del_Name; } set { Set(ref _Del_Name, value, "Del_Name"); } }
		private string _Del_Add; public string Del_Add { get { return _Del_Add; } set { Set(ref _Del_Add, value, "Del_Add"); } }
		private DateTime? _Dte_Requir; public DateTime? Dte_Requir { get { return _Dte_Requir; } set { Set(ref _Dte_Requir, value, "Dte_Requir"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Dtime; public DateTime? Cr_Dtime { get { return _Cr_Dtime; } set { Set(ref _Cr_Dtime, value, "Cr_Dtime"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Dtime; public DateTime? Mod_Dtime { get { return _Mod_Dtime; } set { Set(ref _Mod_Dtime, value, "Mod_Dtime"); } }
		private int? _Trp_Id; public int? Trp_Id { get { return _Trp_Id; } set { Set(ref _Trp_Id, value, "Trp_Id"); } }
		private string _Trp_Condit; public string Trp_Condit { get { return _Trp_Condit; } set { Set(ref _Trp_Condit, value, "Trp_Condit"); } }
		private decimal? _Trp_Mnt; public decimal? Trp_Mnt { get { return _Trp_Mnt; } set { Set(ref _Trp_Mnt, value, "Trp_Mnt"); } }
		private string _Trp_Mnt_Cu; public string Trp_Mnt_Cu { get { return _Trp_Mnt_Cu; } set { Set(ref _Trp_Mnt_Cu, value, "Trp_Mnt_Cu"); } }
		private string _Notes_Dema; public string Notes_Dema { get { return _Notes_Dema; } set { Set(ref _Notes_Dema, value, "Notes_Dema"); } }
		private string _Trp_Ref; public string Trp_Ref { get { return _Trp_Ref; } set { Set(ref _Trp_Ref, value, "Trp_Ref"); } }
		private string _Status; public string Status { get { return _Status; } set { Set(ref _Status, value, "Status"); } }
		private DateTime? _Dte_Delive; public DateTime? Dte_Delive { get { return _Dte_Delive; } set { Set(ref _Dte_Delive, value, "Dte_Delive"); } }
		private string _Received_B; public string Received_B { get { return _Received_B; } set { Set(ref _Received_B, value, "Received_B"); } }
		private string _Notes_Deli; public string Notes_Deli { get { return _Notes_Deli; } set { Set(ref _Notes_Deli, value, "Notes_Deli"); } }
		private int? _Idclient; public int? Idclient { get { return _Idclient; } set { Set(ref _Idclient, value, "Idclient"); } }
		private int? _Pick_Idzon; public int? Pick_Idzon { get { return _Pick_Idzon; } set { Set(ref _Pick_Idzon, value, "Pick_Idzon"); } }
		private int? _Del_Idzone; public int? Del_Idzone { get { return _Del_Idzone; } set { Set(ref _Del_Idzone, value, "Del_Idzone"); } }
		private DateTime? _Dte_Required; public DateTime? Dte_Required { get { return _Dte_Required; } set { Set(ref _Dte_Required, value, "Dte_Required"); } }
		private decimal? _Hrs_Rdv; public decimal? Hrs_Rdv { get { return _Hrs_Rdv; } set { Set(ref _Hrs_Rdv, value, "Hrs_Rdv"); } }
		private string _Trp_Conditions; public string Trp_Conditions { get { return _Trp_Conditions; } set { Set(ref _Trp_Conditions, value, "Trp_Conditions"); } }
		private string _Notes_Demand; public string Notes_Demand { get { return _Notes_Demand; } set { Set(ref _Notes_Demand, value, "Notes_Demand"); } }
		private string _Notes_Delivery; public string Notes_Delivery { get { return _Notes_Delivery; } set { Set(ref _Notes_Delivery, value, "Notes_Delivery"); } }
		private int? _Pick_Idzone; public int? Pick_Idzone { get { return _Pick_Idzone; } set { Set(ref _Pick_Idzone, value, "Pick_Idzone"); } }
		private DateTime? _Dte_Delivered; public DateTime? Dte_Delivered { get { return _Dte_Delivered; } set { Set(ref _Dte_Delivered, value, "Dte_Delivered"); } }
		private string _Trp_Mnt_Cur; public string Trp_Mnt_Cur { get { return _Trp_Mnt_Cur; } set { Set(ref _Trp_Mnt_Cur, value, "Trp_Mnt_Cur"); } }
		private string _Received_By; public string Received_By { get { return _Received_By; } set { Set(ref _Received_By, value, "Received_By"); } }
		private int? _Po_C_Hino; public int? Po_C_Hino { get { return _Po_C_Hino; } set { Set(ref _Po_C_Hino, value, "Po_C_Hino"); } }
		private int? _Po_C_206; public int? Po_C_206 { get { return _Po_C_206; } set { Set(ref _Po_C_206, value, "Po_C_206"); } }
		private int? _Po_C_503; public int? Po_C_503 { get { return _Po_C_503; } set { Set(ref _Po_C_503, value, "Po_C_503"); } }
		private bool? _Zhino; public bool? Zhino { get { return _Zhino; } set { Set(ref _Zhino, value, "Zhino"); } }
		private bool? _Z206; public bool? Z206 { get { return _Z206; } set { Set(ref _Z206, value, "Z206"); } }
		private bool? _Z503; public bool? Z503 { get { return _Z503; } set { Set(ref _Z503, value, "Z503"); } }
		private string _Paddr1; public string Paddr1 { get { return _Paddr1; } set { Set(ref _Paddr1, value, "Paddr1"); } }
		private string _Paddr2; public string Paddr2 { get { return _Paddr2; } set { Set(ref _Paddr2, value, "Paddr2"); } }
		private string _Pcity; public string Pcity { get { return _Pcity; } set { Set(ref _Pcity, value, "Pcity"); } }
		private string _Pstate; public string Pstate { get { return _Pstate; } set { Set(ref _Pstate, value, "Pstate"); } }
		private string _Pzip; public string Pzip { get { return _Pzip; } set { Set(ref _Pzip, value, "Pzip"); } }
		private string _Pcountry; public string Pcountry { get { return _Pcountry; } set { Set(ref _Pcountry, value, "Pcountry"); } }
		private string _Daddr1; public string Daddr1 { get { return _Daddr1; } set { Set(ref _Daddr1, value, "Daddr1"); } }
		private string _Daddr2; public string Daddr2 { get { return _Daddr2; } set { Set(ref _Daddr2, value, "Daddr2"); } }
		private string _Dcity; public string Dcity { get { return _Dcity; } set { Set(ref _Dcity, value, "Dcity"); } }
		private string _Dstate; public string Dstate { get { return _Dstate; } set { Set(ref _Dstate, value, "Dstate"); } }
		private string _Dzip; public string Dzip { get { return _Dzip; } set { Set(ref _Dzip, value, "Dzip"); } }
		private string _Dcountry; public string Dcountry { get { return _Dcountry; } set { Set(ref _Dcountry, value, "Dcountry"); } }
		private string _Typecf; public string Typecf { get { return _Typecf; } set { Set(ref _Typecf, value, "Typecf"); } }
		private string _Typecf_D; public string Typecf_D { get { return _Typecf_D; } set { Set(ref _Typecf_D, value, "Typecf_D"); } }
		private DateTime? _Dte_Cueil; public DateTime? Dte_Cueil { get { return _Dte_Cueil; } set { Set(ref _Dte_Cueil, value, "Dte_Cueil"); } }
		private int? _Popotid1; public int? Popotid1 { get { return _Popotid1; } set { Set(ref _Popotid1, value, "Popotid1"); } }
		private int? _Popotid2; public int? Popotid2 { get { return _Popotid2; } set { Set(ref _Popotid2, value, "Popotid2"); } }
		private int? _Popotid3; public int? Popotid3 { get { return _Popotid3; } set { Set(ref _Popotid3, value, "Popotid3"); } }
		private byte? _Trpordre; public byte? Trpordre { get { return _Trpordre; } set { Set(ref _Trpordre, value, "Trpordre"); } }

	}
}