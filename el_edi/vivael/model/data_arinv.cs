using System;

namespace vivael
{
	public class data_arinv : DataSource
	{
		public data_arinv() { Table_name = i.name = "arinv"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Type; public string Type { get { return _Type; } set { Set(ref _Type, value, "Type"); } }
		private string _Invnocode; public string Invnocode { get { return _Invnocode; } set { Set(ref _Invnocode, value, "Invnocode"); } }
		private int? _Invno; public int? Invno { get { return _Invno; } set { Set(ref _Invno, value, "Invno"); } }
		private DateTime? _Invdte; public DateTime? Invdte { get { return _Invdte; } set { Set(ref _Invdte, value, "Invdte"); } }
		private DateTime? _Duedte; public DateTime? Duedte { get { return _Duedte; } set { Set(ref _Duedte, value, "Duedte"); } }
		private short? _Acc_Year; public short? Acc_Year { get { return _Acc_Year; } set { Set(ref _Acc_Year, value, "Acc_Year"); } }
		private byte? _Acc_Period; public byte? Acc_Period { get { return _Acc_Period; } set { Set(ref _Acc_Period, value, "Acc_Period"); } }
		private int? _Consolid; public int? Consolid { get { return _Consolid; } set { Set(ref _Consolid, value, "Consolid"); } }
		private string _Activity; public string Activity { get { return _Activity; } set { Set(ref _Activity, value, "Activity"); } }
		private int? _Consolno; public int? Consolno { get { return _Consolno; } set { Set(ref _Consolno, value, "Consolno"); } }
		private int? _Fileid; public int? Fileid { get { return _Fileid; } set { Set(ref _Fileid, value, "Fileid"); } }
		private string _Dept; public string Dept { get { return _Dept; } set { Set(ref _Dept, value, "Dept"); } }
		private string _Status; public string Status { get { return _Status; } set { Set(ref _Status, value, "Status"); } }
		private int? _Custid; public int? Custid { get { return _Custid; } set { Set(ref _Custid, value, "Custid"); } }
		private string _Descr; public string Descr { get { return _Descr; } set { Set(ref _Descr, value, "Descr"); } }
		private decimal? _Inv_Mnt; public decimal? Inv_Mnt { get { return _Inv_Mnt; } set { Set(ref _Inv_Mnt, value, "Inv_Mnt"); } }
		private decimal? _Inv_Tx_Gst; public decimal? Inv_Tx_Gst { get { return _Inv_Tx_Gst; } set { Set(ref _Inv_Tx_Gst, value, "Inv_Tx_Gst"); } }
		private decimal? _Inv_Tx_Pst; public decimal? Inv_Tx_Pst { get { return _Inv_Tx_Pst; } set { Set(ref _Inv_Tx_Pst, value, "Inv_Tx_Pst"); } }
		private decimal? _Mnt_Paid; public decimal? Mnt_Paid { get { return _Mnt_Paid; } set { Set(ref _Mnt_Paid, value, "Mnt_Paid"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private decimal? _Cur_Rate; public decimal? Cur_Rate { get { return _Cur_Rate; } set { Set(ref _Cur_Rate, value, "Cur_Rate"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Cr_Datetime; public DateTime? Cr_Datetime { get { return _Cr_Datetime; } set { Set(ref _Cr_Datetime, value, "Cr_Datetime"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Datetime; public DateTime? Mod_Datetime { get { return _Mod_Datetime; } set { Set(ref _Mod_Datetime, value, "Mod_Datetime"); } }
		private string _Details; public string Details { get { return _Details; } set { Set(ref _Details, value, "Details"); } }
		private int? _Quoteid; public int? Quoteid { get { return _Quoteid; } set { Set(ref _Quoteid, value, "Quoteid"); } }
		private bool? _Posted; public bool? Posted { get { return _Posted; } set { Set(ref _Posted, value, "Posted"); } }
		private int? _Post_Id; public int? Post_Id { get { return _Post_Id; } set { Set(ref _Post_Id, value, "Post_Id"); } }
		private bool? _Printed; public bool? Printed { get { return _Printed; } set { Set(ref _Printed, value, "Printed"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private bool? _Voided; public bool? Voided { get { return _Voided; } set { Set(ref _Voided, value, "Voided"); } }
		private DateTime? _Voided_Dte; public DateTime? Voided_Dte { get { return _Voided_Dte; } set { Set(ref _Voided_Dte, value, "Voided_Dte"); } }
		private decimal? _Inv_Duty; public decimal? Inv_Duty { get { return _Inv_Duty; } set { Set(ref _Inv_Duty, value, "Inv_Duty"); } }
		private int? _Idgroup; public int? Idgroup { get { return _Idgroup; } set { Set(ref _Idgroup, value, "Idgroup"); } }
		private int? _Zebrainvid; public int? Zebrainvid { get { return _Zebrainvid; } set { Set(ref _Zebrainvid, value, "Zebrainvid"); } }
		private bool? _Claim; public bool? Claim { get { return _Claim; } set { Set(ref _Claim, value, "Claim"); } }
		private string _Claim_Det; public string Claim_Det { get { return _Claim_Det; } set { Set(ref _Claim_Det, value, "Claim_Det"); } }
		private bool? _Claim_Ok; public bool? Claim_Ok { get { return _Claim_Ok; } set { Set(ref _Claim_Ok, value, "Claim_Ok"); } }
		private string _Claim_Ok_Det; public string Claim_Ok_Det { get { return _Claim_Ok_Det; } set { Set(ref _Claim_Ok_Det, value, "Claim_Ok_Det"); } }
		private int? _Idinvcust; public int? Idinvcust { get { return _Idinvcust; } set { Set(ref _Idinvcust, value, "Idinvcust"); } }
		private string _Lvs_Invno; public string Lvs_Invno { get { return _Lvs_Invno; } set { Set(ref _Lvs_Invno, value, "Lvs_Invno"); } }
		private int? _Quoteno; public int? Quoteno { get { return _Quoteno; } set { Set(ref _Quoteno, value, "Quoteno"); } }
		private string _Rate_Code; public string Rate_Code { get { return _Rate_Code; } set { Set(ref _Rate_Code, value, "Rate_Code"); } }
		private string _Custlvspo; public string Custlvspo { get { return _Custlvspo; } set { Set(ref _Custlvspo, value, "Custlvspo"); } }
		private string _Itm_Descr; public string Itm_Descr { get { return _Itm_Descr; } set { Set(ref _Itm_Descr, value, "Itm_Descr"); } }
		private string _Po; public string Po { get { return _Po; } set { Set(ref _Po, value, "Po"); } }
		private string _Ref; public string Ref { get { return _Ref; } set { Set(ref _Ref, value, "Ref"); } }
		private int? _Idwarh; public int? Idwarh { get { return _Idwarh; } set { Set(ref _Idwarh, value, "Idwarh"); } }
		private int? _Idbil; public int? Idbil { get { return _Idbil; } set { Set(ref _Idbil, value, "Idbil"); } }
		private bool? _Cod; public bool? Cod { get { return _Cod; } set { Set(ref _Cod, value, "Cod"); } }
		private bool? _Accpac_Posted; public bool? Accpac_Posted { get { return _Accpac_Posted; } set { Set(ref _Accpac_Posted, value, "Accpac_Posted"); } }
		private bool? _Accpac_Ok; public bool? Accpac_Ok { get { return _Accpac_Ok; } set { Set(ref _Accpac_Ok, value, "Accpac_Ok"); } }
		private decimal? _Inv_Tx_Tvh; public decimal? Inv_Tx_Tvh { get { return _Inv_Tx_Tvh; } set { Set(ref _Inv_Tx_Tvh, value, "Inv_Tx_Tvh"); } }
		private bool? _Adj_Inv; public bool? Adj_Inv { get { return _Adj_Inv; } set { Set(ref _Adj_Inv, value, "Adj_Inv"); } }
		private short? _Wait_Time; public short? Wait_Time { get { return _Wait_Time; } set { Set(ref _Wait_Time, value, "Wait_Time"); } }
		private int? _Idtax; public int? Idtax { get { return _Idtax; } set { Set(ref _Idtax, value, "Idtax"); } }
		private decimal? _Gst_Rate; public decimal? Gst_Rate { get { return _Gst_Rate; } set { Set(ref _Gst_Rate, value, "Gst_Rate"); } }
		private decimal? _Pst_Rate; public decimal? Pst_Rate { get { return _Pst_Rate; } set { Set(ref _Pst_Rate, value, "Pst_Rate"); } }
		private decimal? _Hst_Rate; public decimal? Hst_Rate { get { return _Hst_Rate; } set { Set(ref _Hst_Rate, value, "Hst_Rate"); } }
		private string _Hst_No; public string Hst_No { get { return _Hst_No; } set { Set(ref _Hst_No, value, "Hst_No"); } }
		private bool? _Lpstongst; public bool? Lpstongst { get { return _Lpstongst; } set { Set(ref _Lpstongst, value, "Lpstongst"); } }
		private string _Vlivrea; public string Vlivrea { get { return _Vlivrea; } set { Set(ref _Vlivrea, value, "Vlivrea"); } }
		private decimal? _Tpstaux; public decimal? Tpstaux { get { return _Tpstaux; } set { Set(ref _Tpstaux, value, "Tpstaux"); } }
		private decimal? _Tvqtaux; public decimal? Tvqtaux { get { return _Tvqtaux; } set { Set(ref _Tvqtaux, value, "Tvqtaux"); } }
		private decimal? _Tvhtaux; public decimal? Tvhtaux { get { return _Tvhtaux; } set { Set(ref _Tvhtaux, value, "Tvhtaux"); } }

	}
}