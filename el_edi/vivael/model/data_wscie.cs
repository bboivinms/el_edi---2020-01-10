using System;

namespace vivael
{
	public class data_wscie : DataSource
	{
		public data_wscie() { Table_name = i.name = "wscie"; i.primary_1 = "cie_id"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Cie_Id; public int Cie_Id { get { return _Cie_Id; } set { Set(ref _Cie_Id, value, "Cie_Id"); } }
		private string _Cie_Name; public string Cie_Name { get { return _Cie_Name; } set { Set(ref _Cie_Name, value, "Cie_Name"); } }
		private string _Cie_Adr1; public string Cie_Adr1 { get { return _Cie_Adr1; } set { Set(ref _Cie_Adr1, value, "Cie_Adr1"); } }
		private string _Cie_Adr2; public string Cie_Adr2 { get { return _Cie_Adr2; } set { Set(ref _Cie_Adr2, value, "Cie_Adr2"); } }
		private string _Cie_City; public string Cie_City { get { return _Cie_City; } set { Set(ref _Cie_City, value, "Cie_City"); } }
		private string _Cie_State; public string Cie_State { get { return _Cie_State; } set { Set(ref _Cie_State, value, "Cie_State"); } }
		private string _Cie_Zip; public string Cie_Zip { get { return _Cie_Zip; } set { Set(ref _Cie_Zip, value, "Cie_Zip"); } }
		private string _Cie_Country; public string Cie_Country { get { return _Cie_Country; } set { Set(ref _Cie_Country, value, "Cie_Country"); } }
		private string _Cie_Tel; public string Cie_Tel { get { return _Cie_Tel; } set { Set(ref _Cie_Tel, value, "Cie_Tel"); } }
		private string _Cie_Fax; public string Cie_Fax { get { return _Cie_Fax; } set { Set(ref _Cie_Fax, value, "Cie_Fax"); } }
		private short? _Gl_Year; public short? Gl_Year { get { return _Gl_Year; } set { Set(ref _Gl_Year, value, "Gl_Year"); } }
		private byte? _Gl_Period; public byte? Gl_Period { get { return _Gl_Period; } set { Set(ref _Gl_Period, value, "Gl_Period"); } }
		private short? _Ar_Year; public short? Ar_Year { get { return _Ar_Year; } set { Set(ref _Ar_Year, value, "Ar_Year"); } }
		private byte? _Ar_Period; public byte? Ar_Period { get { return _Ar_Period; } set { Set(ref _Ar_Period, value, "Ar_Period"); } }
		private short? _Ap_Year; public short? Ap_Year { get { return _Ap_Year; } set { Set(ref _Ap_Year, value, "Ap_Year"); } }
		private byte? _Ap_Period; public byte? Ap_Period { get { return _Ap_Period; } set { Set(ref _Ap_Period, value, "Ap_Period"); } }
		private short? _Op_Year; public short? Op_Year { get { return _Op_Year; } set { Set(ref _Op_Year, value, "Op_Year"); } }
		private byte? _Op_Period; public byte? Op_Period { get { return _Op_Period; } set { Set(ref _Op_Period, value, "Op_Period"); } }
		private decimal? _Gst_Rate; public decimal? Gst_Rate { get { return _Gst_Rate; } set { Set(ref _Gst_Rate, value, "Gst_Rate"); } }
		private decimal? _Pst_Rate; public decimal? Pst_Rate { get { return _Pst_Rate; } set { Set(ref _Pst_Rate, value, "Pst_Rate"); } }
		private int? _Last_Van; public int? Last_Van { get { return _Last_Van; } set { Set(ref _Last_Van, value, "Last_Van"); } }
		private int? _Nogl_Ap_Re; public int? Nogl_Ap_Re { get { return _Nogl_Ap_Re; } set { Set(ref _Nogl_Ap_Re, value, "Nogl_Ap_Re"); } }
		private int? _Nogl_Ap; public int? Nogl_Ap { get { return _Nogl_Ap; } set { Set(ref _Nogl_Ap, value, "Nogl_Ap"); } }
		private int? _Nogl_Ap_Disc; public int? Nogl_Ap_Disc { get { return _Nogl_Ap_Disc; } set { Set(ref _Nogl_Ap_Disc, value, "Nogl_Ap_Disc"); } }
		private int? _Nogl_Ar; public int? Nogl_Ar { get { return _Nogl_Ar; } set { Set(ref _Nogl_Ar, value, "Nogl_Ar"); } }
		private int? _Nogl_Ar_Disc; public int? Nogl_Ar_Disc { get { return _Nogl_Ar_Disc; } set { Set(ref _Nogl_Ar_Disc, value, "Nogl_Ar_Disc"); } }
		private int? _Nogl_Bq; public int? Nogl_Bq { get { return _Nogl_Bq; } set { Set(ref _Nogl_Bq, value, "Nogl_Bq"); } }
		private int? _Nogl_Bq_Re; public int? Nogl_Bq_Re { get { return _Nogl_Bq_Re; } set { Set(ref _Nogl_Bq_Re, value, "Nogl_Bq_Re"); } }
		private int? _Nogl_Tps_Ach; public int? Nogl_Tps_Ach { get { return _Nogl_Tps_Ach; } set { Set(ref _Nogl_Tps_Ach, value, "Nogl_Tps_Ach"); } }
		private int? _Nogl_Tvq_Ach; public int? Nogl_Tvq_Ach { get { return _Nogl_Tvq_Ach; } set { Set(ref _Nogl_Tvq_Ach, value, "Nogl_Tvq_Ach"); } }
		private int? _Nogl_Tps_Vte; public int? Nogl_Tps_Vte { get { return _Nogl_Tps_Vte; } set { Set(ref _Nogl_Tps_Vte, value, "Nogl_Tps_Vte"); } }
		private int? _Nogl_Tvq_Vte; public int? Nogl_Tvq_Vte { get { return _Nogl_Tvq_Vte; } set { Set(ref _Nogl_Tvq_Vte, value, "Nogl_Tvq_Vte"); } }
		private int? _Nogl_Bnr; public int? Nogl_Bnr { get { return _Nogl_Bnr; } set { Set(ref _Nogl_Bnr, value, "Nogl_Bnr"); } }
		private int? _Nogl_Xrate; public int? Nogl_Xrate { get { return _Nogl_Xrate; } set { Set(ref _Nogl_Xrate, value, "Nogl_Xrate"); } }
		private int? _Nogl_Error; public int? Nogl_Error { get { return _Nogl_Error; } set { Set(ref _Nogl_Error, value, "Nogl_Error"); } }
		private string _Notps; public string Notps { get { return _Notps; } set { Set(ref _Notps, value, "Notps"); } }
		private string _Notvq; public string Notvq { get { return _Notvq; } set { Set(ref _Notvq, value, "Notvq"); } }
		private byte? _Nb_Per_Gl; public byte? Nb_Per_Gl { get { return _Nb_Per_Gl; } set { Set(ref _Nb_Per_Gl, value, "Nb_Per_Gl"); } }
		private byte? _Nb_Per_Aux; public byte? Nb_Per_Aux { get { return _Nb_Per_Aux; } set { Set(ref _Nb_Per_Aux, value, "Nb_Per_Aux"); } }
		private string _Mailserver; public string Mailserver { get { return _Mailserver; } set { Set(ref _Mailserver, value, "Mailserver"); } }
		private string _Faxprefix; public string Faxprefix { get { return _Faxprefix; } set { Set(ref _Faxprefix, value, "Faxprefix"); } }
		private string _Currency; public string Currency { get { return _Currency; } set { Set(ref _Currency, value, "Currency"); } }
		private string _Lineout; public string Lineout { get { return _Lineout; } set { Set(ref _Lineout, value, "Lineout"); } }
		private string _Cie_Lang; public string Cie_Lang { get { return _Cie_Lang; } set { Set(ref _Cie_Lang, value, "Cie_Lang"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private string _Website; public string Website { get { return _Website; } set { Set(ref _Website, value, "Website"); } }
		private string _Int_Activity; public string Int_Activity { get { return _Int_Activity; } set { Set(ref _Int_Activity, value, "Int_Activity"); } }
		private string _Int_Code; public string Int_Code { get { return _Int_Code; } set { Set(ref _Int_Code, value, "Int_Code"); } }
		private string _Logo; public string Logo { get { return _Logo; } set { Set(ref _Logo, value, "Logo"); } }
		private string _Logo_Prt; public string Logo_Prt { get { return _Logo_Prt; } set { Set(ref _Logo_Prt, value, "Logo_Prt"); } }
		private string _Eco_Name; public string Eco_Name { get { return _Eco_Name; } set { Set(ref _Eco_Name, value, "Eco_Name"); } }
		private string _Eco_Footer; public string Eco_Footer { get { return _Eco_Footer; } set { Set(ref _Eco_Footer, value, "Eco_Footer"); } }
		private string _Rep_Inv; public string Rep_Inv { get { return _Rep_Inv; } set { Set(ref _Rep_Inv, value, "Rep_Inv"); } }
		private string _Rep_Subtitle; public string Rep_Subtitle { get { return _Rep_Subtitle; } set { Set(ref _Rep_Subtitle, value, "Rep_Subtitle"); } }
		private int? _Db_Version; public int? Db_Version { get { return _Db_Version; } set { Set(ref _Db_Version, value, "Db_Version"); } }
		private int? _Sy_Version; public int? Sy_Version { get { return _Sy_Version; } set { Set(ref _Sy_Version, value, "Sy_Version"); } }
		private bool? _Eco_On; public bool? Eco_On { get { return _Eco_On; } set { Set(ref _Eco_On, value, "Eco_On"); } }
		private string _Eco_Web; public string Eco_Web { get { return _Eco_Web; } set { Set(ref _Eco_Web, value, "Eco_Web"); } }
		private bool? _Wscustom; public bool? Wscustom { get { return _Wscustom; } set { Set(ref _Wscustom, value, "Wscustom"); } }
		private string _Licence; public string Licence { get { return _Licence; } set { Set(ref _Licence, value, "Licence"); } }
		private decimal? _Version; public decimal? Version { get { return _Version; } set { Set(ref _Version, value, "Version"); } }
		private string _Usdcad; public string Usdcad { get { return _Usdcad; } set { Set(ref _Usdcad, value, "Usdcad"); } }
		private bool? _Zebra; public bool? Zebra { get { return _Zebra; } set { Set(ref _Zebra, value, "Zebra"); } }
		private string _Zeb_In; public string Zeb_In { get { return _Zeb_In; } set { Set(ref _Zeb_In, value, "Zeb_In"); } }
		private string _Zeb_Out; public string Zeb_Out { get { return _Zeb_Out; } set { Set(ref _Zeb_Out, value, "Zeb_Out"); } }
		private string _Zeb_Whr; public string Zeb_Whr { get { return _Zeb_Whr; } set { Set(ref _Zeb_Whr, value, "Zeb_Whr"); } }
		private string _Zeb_Activity; public string Zeb_Activity { get { return _Zeb_Activity; } set { Set(ref _Zeb_Activity, value, "Zeb_Activity"); } }
		private byte? _Monthper1; public byte? Monthper1 { get { return _Monthper1; } set { Set(ref _Monthper1, value, "Monthper1"); } }
		private string _Diskid; public string Diskid { get { return _Diskid; } set { Set(ref _Diskid, value, "Diskid"); } }
		private string _Client_Tracking; public string Client_Tracking { get { return _Client_Tracking; } set { Set(ref _Client_Tracking, value, "Client_Tracking"); } }
		private int? _Nogl_Contra; public int? Nogl_Contra { get { return _Nogl_Contra; } set { Set(ref _Nogl_Contra, value, "Nogl_Contra"); } }
		private decimal? _Tvh_Rate; public decimal? Tvh_Rate { get { return _Tvh_Rate; } set { Set(ref _Tvh_Rate, value, "Tvh_Rate"); } }
		private int? _Nogl_Tvh_Vte; public int? Nogl_Tvh_Vte { get { return _Nogl_Tvh_Vte; } set { Set(ref _Nogl_Tvh_Vte, value, "Nogl_Tvh_Vte"); } }
		private string _Posignature; public string Posignature { get { return _Posignature; } set { Set(ref _Posignature, value, "Posignature"); } }
		private string _Pocode; public string Pocode { get { return _Pocode; } set { Set(ref _Pocode, value, "Pocode"); } }
		private int? _Pono; public int? Pono { get { return _Pono; } set { Set(ref _Pono, value, "Pono"); } }
		private int? _Idprice; public int? Idprice { get { return _Idprice; } set { Set(ref _Idprice, value, "Idprice"); } }
		private decimal? _Taux_Infog; public decimal? Taux_Infog { get { return _Taux_Infog; } set { Set(ref _Taux_Infog, value, "Taux_Infog"); } }
		private int? _Db_Version_Acct; public int? Db_Version_Acct { get { return _Db_Version_Acct; } set { Set(ref _Db_Version_Acct, value, "Db_Version_Acct"); } }
		private int? _Prt_State_Logo; public int? Prt_State_Logo { get { return _Prt_State_Logo; } set { Set(ref _Prt_State_Logo, value, "Prt_State_Logo"); } }
		private string _Xdir; public string Xdir { get { return _Xdir; } set { Set(ref _Xdir, value, "Xdir"); } }
		private string _Xtype; public string Xtype { get { return _Xtype; } set { Set(ref _Xtype, value, "Xtype"); } }
		private bool? _Xauto_Upd; public bool? Xauto_Upd { get { return _Xauto_Upd; } set { Set(ref _Xauto_Upd, value, "Xauto_Upd"); } }
		private int? _Idprodinfo; public int? Idprodinfo { get { return _Idprodinfo; } set { Set(ref _Idprodinfo, value, "Idprodinfo"); } }
		private string _Proxyname; public string Proxyname { get { return _Proxyname; } set { Set(ref _Proxyname, value, "Proxyname"); } }
		private string _Proxyuser; public string Proxyuser { get { return _Proxyuser; } set { Set(ref _Proxyuser, value, "Proxyuser"); } }
		private string _Proxypass; public string Proxypass { get { return _Proxypass; } set { Set(ref _Proxypass, value, "Proxypass"); } }
		private bool? _Glpermonth; public bool? Glpermonth { get { return _Glpermonth; } set { Set(ref _Glpermonth, value, "Glpermonth"); } }
		private int? _Glmonthone; public int? Glmonthone { get { return _Glmonthone; } set { Set(ref _Glmonthone, value, "Glmonthone"); } }
		private decimal? _Co_Pctg; public decimal? Co_Pctg { get { return _Co_Pctg; } set { Set(ref _Co_Pctg, value, "Co_Pctg"); } }
		private decimal? _Eq_Pctg; public decimal? Eq_Pctg { get { return _Eq_Pctg; } set { Set(ref _Eq_Pctg, value, "Eq_Pctg"); } }
		private decimal? _Fa_Pctg; public decimal? Fa_Pctg { get { return _Fa_Pctg; } set { Set(ref _Fa_Pctg, value, "Fa_Pctg"); } }
		private decimal? _En_Pctg; public decimal? En_Pctg { get { return _En_Pctg; } set { Set(ref _En_Pctg, value, "En_Pctg"); } }
		private decimal? _Ca_Pctg; public decimal? Ca_Pctg { get { return _Ca_Pctg; } set { Set(ref _Ca_Pctg, value, "Ca_Pctg"); } }
		private decimal? _Pl_Pctg; public decimal? Pl_Pctg { get { return _Pl_Pctg; } set { Set(ref _Pl_Pctg, value, "Pl_Pctg"); } }
		private decimal? _Co_Min; public decimal? Co_Min { get { return _Co_Min; } set { Set(ref _Co_Min, value, "Co_Min"); } }
		private decimal? _Eq_Min; public decimal? Eq_Min { get { return _Eq_Min; } set { Set(ref _Eq_Min, value, "Eq_Min"); } }
		private decimal? _Fa_Min; public decimal? Fa_Min { get { return _Fa_Min; } set { Set(ref _Fa_Min, value, "Fa_Min"); } }
		private decimal? _En_Min; public decimal? En_Min { get { return _En_Min; } set { Set(ref _En_Min, value, "En_Min"); } }
		private decimal? _Ca_Min; public decimal? Ca_Min { get { return _Ca_Min; } set { Set(ref _Ca_Min, value, "Ca_Min"); } }
		private decimal? _Pl_Min; public decimal? Pl_Min { get { return _Pl_Min; } set { Set(ref _Pl_Min, value, "Pl_Min"); } }
		private decimal? _Add_Pctg; public decimal? Add_Pctg { get { return _Add_Pctg; } set { Set(ref _Add_Pctg, value, "Add_Pctg"); } }
		private bool? _Use_Po; public bool? Use_Po { get { return _Use_Po; } set { Set(ref _Use_Po, value, "Use_Po"); } }
		private bool? _Use_Longd; public bool? Use_Longd { get { return _Use_Longd; } set { Set(ref _Use_Longd, value, "Use_Longd"); } }
		private bool? _Valid_Accnt; public bool? Valid_Accnt { get { return _Valid_Accnt; } set { Set(ref _Valid_Accnt, value, "Valid_Accnt"); } }
		private byte? _Office_No; public byte? Office_No { get { return _Office_No; } set { Set(ref _Office_No, value, "Office_No"); } }
		private bool? _Invxml; public bool? Invxml { get { return _Invxml; } set { Set(ref _Invxml, value, "Invxml"); } }
		private string _Invxmldir; public string Invxmldir { get { return _Invxmldir; } set { Set(ref _Invxmldir, value, "Invxmldir"); } }
		private string _Com_Ach_Msg; public string Com_Ach_Msg { get { return _Com_Ach_Msg; } set { Set(ref _Com_Ach_Msg, value, "Com_Ach_Msg"); } }
		private int? _Nogl_Tvh_Ach; public int? Nogl_Tvh_Ach { get { return _Nogl_Tvh_Ach; } set { Set(ref _Nogl_Tvh_Ach, value, "Nogl_Tvh_Ach"); } }
		private string _Notvh; public string Notvh { get { return _Notvh; } set { Set(ref _Notvh, value, "Notvh"); } }
		private DateTime? _Da_Per1d; public DateTime? Da_Per1d { get { return _Da_Per1d; } set { Set(ref _Da_Per1d, value, "Da_Per1d"); } }
		private DateTime? _Da_Per1f; public DateTime? Da_Per1f { get { return _Da_Per1f; } set { Set(ref _Da_Per1f, value, "Da_Per1f"); } }
		private DateTime? _Da_Per2d; public DateTime? Da_Per2d { get { return _Da_Per2d; } set { Set(ref _Da_Per2d, value, "Da_Per2d"); } }
		private DateTime? _Da_Per2f; public DateTime? Da_Per2f { get { return _Da_Per2f; } set { Set(ref _Da_Per2f, value, "Da_Per2f"); } }
		private DateTime? _Da_Per3d; public DateTime? Da_Per3d { get { return _Da_Per3d; } set { Set(ref _Da_Per3d, value, "Da_Per3d"); } }
		private DateTime? _Da_Per3f; public DateTime? Da_Per3f { get { return _Da_Per3f; } set { Set(ref _Da_Per3f, value, "Da_Per3f"); } }
		private DateTime? _Da_Per4d; public DateTime? Da_Per4d { get { return _Da_Per4d; } set { Set(ref _Da_Per4d, value, "Da_Per4d"); } }
		private DateTime? _Da_Per4f; public DateTime? Da_Per4f { get { return _Da_Per4f; } set { Set(ref _Da_Per4f, value, "Da_Per4f"); } }
		private DateTime? _Da_Per5d; public DateTime? Da_Per5d { get { return _Da_Per5d; } set { Set(ref _Da_Per5d, value, "Da_Per5d"); } }
		private DateTime? _Da_Per5f; public DateTime? Da_Per5f { get { return _Da_Per5f; } set { Set(ref _Da_Per5f, value, "Da_Per5f"); } }
		private DateTime? _Da_Per6d; public DateTime? Da_Per6d { get { return _Da_Per6d; } set { Set(ref _Da_Per6d, value, "Da_Per6d"); } }
		private DateTime? _Da_Per6f; public DateTime? Da_Per6f { get { return _Da_Per6f; } set { Set(ref _Da_Per6f, value, "Da_Per6f"); } }
		private DateTime? _Da_Per7d; public DateTime? Da_Per7d { get { return _Da_Per7d; } set { Set(ref _Da_Per7d, value, "Da_Per7d"); } }
		private DateTime? _Da_Per7f; public DateTime? Da_Per7f { get { return _Da_Per7f; } set { Set(ref _Da_Per7f, value, "Da_Per7f"); } }
		private DateTime? _Da_Per8d; public DateTime? Da_Per8d { get { return _Da_Per8d; } set { Set(ref _Da_Per8d, value, "Da_Per8d"); } }
		private DateTime? _Da_Per8f; public DateTime? Da_Per8f { get { return _Da_Per8f; } set { Set(ref _Da_Per8f, value, "Da_Per8f"); } }
		private DateTime? _Da_Per9d; public DateTime? Da_Per9d { get { return _Da_Per9d; } set { Set(ref _Da_Per9d, value, "Da_Per9d"); } }
		private DateTime? _Da_Per9f; public DateTime? Da_Per9f { get { return _Da_Per9f; } set { Set(ref _Da_Per9f, value, "Da_Per9f"); } }
		private DateTime? _Da_Per10d; public DateTime? Da_Per10d { get { return _Da_Per10d; } set { Set(ref _Da_Per10d, value, "Da_Per10d"); } }
		private DateTime? _Da_Per10f; public DateTime? Da_Per10f { get { return _Da_Per10f; } set { Set(ref _Da_Per10f, value, "Da_Per10f"); } }
		private DateTime? _Da_Per11d; public DateTime? Da_Per11d { get { return _Da_Per11d; } set { Set(ref _Da_Per11d, value, "Da_Per11d"); } }
		private DateTime? _Da_Per11f; public DateTime? Da_Per11f { get { return _Da_Per11f; } set { Set(ref _Da_Per11f, value, "Da_Per11f"); } }
		private DateTime? _Da_Per12d; public DateTime? Da_Per12d { get { return _Da_Per12d; } set { Set(ref _Da_Per12d, value, "Da_Per12d"); } }
		private DateTime? _Da_Per12f; public DateTime? Da_Per12f { get { return _Da_Per12f; } set { Set(ref _Da_Per12f, value, "Da_Per12f"); } }
		private decimal? _Prix_Est_Do; public decimal? Prix_Est_Do { get { return _Prix_Est_Do; } set { Set(ref _Prix_Est_Do, value, "Prix_Est_Do"); } }
		private decimal? _Marge_Est_Glo; public decimal? Marge_Est_Glo { get { return _Marge_Est_Glo; } set { Set(ref _Marge_Est_Glo, value, "Marge_Est_Glo"); } }
		private decimal? _Cout_Vente; public decimal? Cout_Vente { get { return _Cout_Vente; } set { Set(ref _Cout_Vente, value, "Cout_Vente"); } }
		private decimal? _Cout_Fixe; public decimal? Cout_Fixe { get { return _Cout_Fixe; } set { Set(ref _Cout_Fixe, value, "Cout_Fixe"); } }
		private decimal? _Cout_Int; public decimal? Cout_Int { get { return _Cout_Int; } set { Set(ref _Cout_Int, value, "Cout_Int"); } }
		private decimal? _Cout_S_Rack; public decimal? Cout_S_Rack { get { return _Cout_S_Rack; } set { Set(ref _Cout_S_Rack, value, "Cout_S_Rack"); } }
		private decimal? _Cout_A_Rack; public decimal? Cout_A_Rack { get { return _Cout_A_Rack; } set { Set(ref _Cout_A_Rack, value, "Cout_A_Rack"); } }

	}
}