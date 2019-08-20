using System;

namespace vivael
{
	public class data_arclient : DataSource
	{
		public data_arclient() { Table_name = i.name = "arclient"; i.primary_1 = "ident"; i.primary_2 = null; i.primary_3 = null; isFoxpro = true; }

		private int _Ident; public int Ident { get { return _Ident; } set { Set(ref _Ident, value, "Ident"); } }
		private string _Code; public string Code { get { return _Code; } set { Set(ref _Code, value, "Code"); } }
		private string _Clitype; public string Clitype { get { return _Clitype; } set { Set(ref _Clitype, value, "Clitype"); } }
		private string _Name; public string Name { get { return _Name; } set { Set(ref _Name, value, "Name"); } }
		private string _Offname; public string Offname { get { return _Offname; } set { Set(ref _Offname, value, "Offname"); } }
		private string _Status; public string Status { get { return _Status; } set { Set(ref _Status, value, "Status"); } }
		private string _Language; public string Language { get { return _Language; } set { Set(ref _Language, value, "Language"); } }
		private string _Addr1; public string Addr1 { get { return _Addr1; } set { Set(ref _Addr1, value, "Addr1"); } }
		private string _Addr2; public string Addr2 { get { return _Addr2; } set { Set(ref _Addr2, value, "Addr2"); } }
		private string _City; public string City { get { return _City; } set { Set(ref _City, value, "City"); } }
		private string _State; public string State { get { return _State; } set { Set(ref _State, value, "State"); } }
		private string _Zip; public string Zip { get { return _Zip; } set { Set(ref _Zip, value, "Zip"); } }
		private string _Country; public string Country { get { return _Country; } set { Set(ref _Country, value, "Country"); } }
		private string _Deladdr1; public string Deladdr1 { get { return _Deladdr1; } set { Set(ref _Deladdr1, value, "Deladdr1"); } }
		private string _Deladdr2; public string Deladdr2 { get { return _Deladdr2; } set { Set(ref _Deladdr2, value, "Deladdr2"); } }
		private string _Delcity; public string Delcity { get { return _Delcity; } set { Set(ref _Delcity, value, "Delcity"); } }
		private string _Delstate; public string Delstate { get { return _Delstate; } set { Set(ref _Delstate, value, "Delstate"); } }
		private string _Delzip; public string Delzip { get { return _Delzip; } set { Set(ref _Delzip, value, "Delzip"); } }
		private string _Delcountry; public string Delcountry { get { return _Delcountry; } set { Set(ref _Delcountry, value, "Delcountry"); } }
		private string _Tel1; public string Tel1 { get { return _Tel1; } set { Set(ref _Tel1, value, "Tel1"); } }
		private string _Tel2; public string Tel2 { get { return _Tel2; } set { Set(ref _Tel2, value, "Tel2"); } }
		private string _Fax; public string Fax { get { return _Fax; } set { Set(ref _Fax, value, "Fax"); } }
		private string _Email; public string Email { get { return _Email; } set { Set(ref _Email, value, "Email"); } }
		private string _Web; public string Web { get { return _Web; } set { Set(ref _Web, value, "Web"); } }
		private string _Deltel1; public string Deltel1 { get { return _Deltel1; } set { Set(ref _Deltel1, value, "Deltel1"); } }
		private string _Delfax; public string Delfax { get { return _Delfax; } set { Set(ref _Delfax, value, "Delfax"); } }
		private string _C1_Cell; public string C1_Cell { get { return _C1_Cell; } set { Set(ref _C1_Cell, value, "C1_Cell"); } }
		private string _C2_Cell; public string C2_Cell { get { return _C2_Cell; } set { Set(ref _C2_Cell, value, "C2_Cell"); } }
		private string _C3_Cell; public string C3_Cell { get { return _C3_Cell; } set { Set(ref _C3_Cell, value, "C3_Cell"); } }
		private string _Notes; public string Notes { get { return _Notes; } set { Set(ref _Notes, value, "Notes"); } }
		private string _Agreement; public string Agreement { get { return _Agreement; } set { Set(ref _Agreement, value, "Agreement"); } }
		private string _Territory; public string Territory { get { return _Territory; } set { Set(ref _Territory, value, "Territory"); } }
		private string _Category; public string Category { get { return _Category; } set { Set(ref _Category, value, "Category"); } }
		private int? _Brokerid; public int? Brokerid { get { return _Brokerid; } set { Set(ref _Brokerid, value, "Brokerid"); } }
		private string _Repcode; public string Repcode { get { return _Repcode; } set { Set(ref _Repcode, value, "Repcode"); } }
		private int? _Idbillto; public int? Idbillto { get { return _Idbillto; } set { Set(ref _Idbillto, value, "Idbillto"); } }
		private bool? _Gst_Exem; public bool? Gst_Exem { get { return _Gst_Exem; } set { Set(ref _Gst_Exem, value, "Gst_Exem"); } }
		private bool? _Pst_Exem; public bool? Pst_Exem { get { return _Pst_Exem; } set { Set(ref _Pst_Exem, value, "Pst_Exem"); } }
		private bool? _Tvh_Ch; public bool? Tvh_Ch { get { return _Tvh_Ch; } set { Set(ref _Tvh_Ch, value, "Tvh_Ch"); } }
		private string _Gst_No; public string Gst_No { get { return _Gst_No; } set { Set(ref _Gst_No, value, "Gst_No"); } }
		private string _Pst_No; public string Pst_No { get { return _Pst_No; } set { Set(ref _Pst_No, value, "Pst_No"); } }
		private bool? _Do_Export; public bool? Do_Export { get { return _Do_Export; } set { Set(ref _Do_Export, value, "Do_Export"); } }
		private bool? _Do_Import; public bool? Do_Import { get { return _Do_Import; } set { Set(ref _Do_Import, value, "Do_Import"); } }
		private string _No_Import; public string No_Import { get { return _No_Import; } set { Set(ref _No_Import, value, "No_Import"); } }
		private string _Iata_Code; public string Iata_Code { get { return _Iata_Code; } set { Set(ref _Iata_Code, value, "Iata_Code"); } }
		private string _Accnt_Note; public string Accnt_Note { get { return _Accnt_Note; } set { Set(ref _Accnt_Note, value, "Accnt_Note"); } }
		private string _Curr; public string Curr { get { return _Curr; } set { Set(ref _Curr, value, "Curr"); } }
		private string _Terms; public string Terms { get { return _Terms; } set { Set(ref _Terms, value, "Terms"); } }
		private short? _Terms_Days; public short? Terms_Days { get { return _Terms_Days; } set { Set(ref _Terms_Days, value, "Terms_Days"); } }
		private decimal? _Int_Rate; public decimal? Int_Rate { get { return _Int_Rate; } set { Set(ref _Int_Rate, value, "Int_Rate"); } }
		private DateTime? _Cr_Date; public DateTime? Cr_Date { get { return _Cr_Date; } set { Set(ref _Cr_Date, value, "Cr_Date"); } }
		private string _Cr_By; public string Cr_By { get { return _Cr_By; } set { Set(ref _Cr_By, value, "Cr_By"); } }
		private DateTime? _Since; public DateTime? Since { get { return _Since; } set { Set(ref _Since, value, "Since"); } }
		private long? _Crlimit; public long? Crlimit { get { return _Crlimit; } set { Set(ref _Crlimit, value, "Crlimit"); } }
		private string _Df_Imp_Goods; public string Df_Imp_Goods { get { return _Df_Imp_Goods; } set { Set(ref _Df_Imp_Goods, value, "Df_Imp_Goods"); } }
		private string _Df_Imp_Reship; public string Df_Imp_Reship { get { return _Df_Imp_Reship; } set { Set(ref _Df_Imp_Reship, value, "Df_Imp_Reship"); } }
		private string _Df_Exp_Goods; public string Df_Exp_Goods { get { return _Df_Exp_Goods; } set { Set(ref _Df_Exp_Goods, value, "Df_Exp_Goods"); } }
		private bool? _Df_Exp_Insur; public bool? Df_Exp_Insur { get { return _Df_Exp_Insur; } set { Set(ref _Df_Exp_Insur, value, "Df_Exp_Insur"); } }
		private string _Rates; public string Rates { get { return _Rates; } set { Set(ref _Rates, value, "Rates"); } }
		private string _Logo; public string Logo { get { return _Logo; } set { Set(ref _Logo, value, "Logo"); } }
		private bool? _Eco_Notif_Now; public bool? Eco_Notif_Now { get { return _Eco_Notif_Now; } set { Set(ref _Eco_Notif_Now, value, "Eco_Notif_Now"); } }
		private bool? _Eco_Send_Summ; public bool? Eco_Send_Summ { get { return _Eco_Send_Summ; } set { Set(ref _Eco_Send_Summ, value, "Eco_Send_Summ"); } }
		private string _Eco_Email; public string Eco_Email { get { return _Eco_Email; } set { Set(ref _Eco_Email, value, "Eco_Email"); } }
		private bool? _Eco_Track; public bool? Eco_Track { get { return _Eco_Track; } set { Set(ref _Eco_Track, value, "Eco_Track"); } }
		private string _Eco_Track_Cod; public string Eco_Track_Cod { get { return _Eco_Track_Cod; } set { Set(ref _Eco_Track_Cod, value, "Eco_Track_Cod"); } }
		private string _Eco_Track_Pas; public string Eco_Track_Pas { get { return _Eco_Track_Pas; } set { Set(ref _Eco_Track_Pas, value, "Eco_Track_Pas"); } }
		private string _Bk_Name; public string Bk_Name { get { return _Bk_Name; } set { Set(ref _Bk_Name, value, "Bk_Name"); } }
		private string _Bk_Addr1; public string Bk_Addr1 { get { return _Bk_Addr1; } set { Set(ref _Bk_Addr1, value, "Bk_Addr1"); } }
		private string _Bk_Addr2; public string Bk_Addr2 { get { return _Bk_Addr2; } set { Set(ref _Bk_Addr2, value, "Bk_Addr2"); } }
		private string _Bk_Addr3; public string Bk_Addr3 { get { return _Bk_Addr3; } set { Set(ref _Bk_Addr3, value, "Bk_Addr3"); } }
		private string _Bk_Tel; public string Bk_Tel { get { return _Bk_Tel; } set { Set(ref _Bk_Tel, value, "Bk_Tel"); } }
		private string _Bk_Fax; public string Bk_Fax { get { return _Bk_Fax; } set { Set(ref _Bk_Fax, value, "Bk_Fax"); } }
		private string _Bk_Contact; public string Bk_Contact { get { return _Bk_Contact; } set { Set(ref _Bk_Contact, value, "Bk_Contact"); } }
		private string _Bk_Accnt; public string Bk_Accnt { get { return _Bk_Accnt; } set { Set(ref _Bk_Accnt, value, "Bk_Accnt"); } }
		private DateTime? _Bk_Since; public DateTime? Bk_Since { get { return _Bk_Since; } set { Set(ref _Bk_Since, value, "Bk_Since"); } }
		private decimal? _Bk_Cred_Req; public decimal? Bk_Cred_Req { get { return _Bk_Cred_Req; } set { Set(ref _Bk_Cred_Req, value, "Bk_Cred_Req"); } }
		private string _Bk_Note; public string Bk_Note { get { return _Bk_Note; } set { Set(ref _Bk_Note, value, "Bk_Note"); } }
		private string _Sec_Accnt; public string Sec_Accnt { get { return _Sec_Accnt; } set { Set(ref _Sec_Accnt, value, "Sec_Accnt"); } }
		private bool? _Eco_Inventory; public bool? Eco_Inventory { get { return _Eco_Inventory; } set { Set(ref _Eco_Inventory, value, "Eco_Inventory"); } }
		private string _Hrsouv; public string Hrsouv { get { return _Hrsouv; } set { Set(ref _Hrsouv, value, "Hrsouv"); } }
		private DateTime? _Crlimit_Dte; public DateTime? Crlimit_Dte { get { return _Crlimit_Dte; } set { Set(ref _Crlimit_Dte, value, "Crlimit_Dte"); } }
		private bool? _Tel1_Free; public bool? Tel1_Free { get { return _Tel1_Free; } set { Set(ref _Tel1_Free, value, "Tel1_Free"); } }
		private bool? _Tel2_Free; public bool? Tel2_Free { get { return _Tel2_Free; } set { Set(ref _Tel2_Free, value, "Tel2_Free"); } }
		private bool? _Fax_Free; public bool? Fax_Free { get { return _Fax_Free; } set { Set(ref _Fax_Free, value, "Fax_Free"); } }
		private bool? _Deltel_Free; public bool? Deltel_Free { get { return _Deltel_Free; } set { Set(ref _Deltel_Free, value, "Deltel_Free"); } }
		private bool? _Delfax_Free; public bool? Delfax_Free { get { return _Delfax_Free; } set { Set(ref _Delfax_Free, value, "Delfax_Free"); } }
		private int? _Repid; public int? Repid { get { return _Repid; } set { Set(ref _Repid, value, "Repid"); } }
		private string _Rate2; public string Rate2 { get { return _Rate2; } set { Set(ref _Rate2, value, "Rate2"); } }
		private string _Rate3; public string Rate3 { get { return _Rate3; } set { Set(ref _Rate3, value, "Rate3"); } }
		private string _Rate_Descr; public string Rate_Descr { get { return _Rate_Descr; } set { Set(ref _Rate_Descr, value, "Rate_Descr"); } }
		private string _Rate2_Descr; public string Rate2_Descr { get { return _Rate2_Descr; } set { Set(ref _Rate2_Descr, value, "Rate2_Descr"); } }
		private string _Rate3_Descr; public string Rate3_Descr { get { return _Rate3_Descr; } set { Set(ref _Rate3_Descr, value, "Rate3_Descr"); } }
		private bool? _Rate_Defaut; public bool? Rate_Defaut { get { return _Rate_Defaut; } set { Set(ref _Rate_Defaut, value, "Rate_Defaut"); } }
		private bool? _Rate2_Defaut; public bool? Rate2_Defaut { get { return _Rate2_Defaut; } set { Set(ref _Rate2_Defaut, value, "Rate2_Defaut"); } }
		private bool? _Rate3_Defaut; public bool? Rate3_Defaut { get { return _Rate3_Defaut; } set { Set(ref _Rate3_Defaut, value, "Rate3_Defaut"); } }
		private decimal? _Esconinv; public decimal? Esconinv { get { return _Esconinv; } set { Set(ref _Esconinv, value, "Esconinv"); } }
		private bool? _Eco_Custom_Day_Report; public bool? Eco_Custom_Day_Report { get { return _Eco_Custom_Day_Report; } set { Set(ref _Eco_Custom_Day_Report, value, "Eco_Custom_Day_Report"); } }
		private string _Eco_Track_Name; public string Eco_Track_Name { get { return _Eco_Track_Name; } set { Set(ref _Eco_Track_Name, value, "Eco_Track_Name"); } }
		private string _Eco_Logo; public string Eco_Logo { get { return _Eco_Logo; } set { Set(ref _Eco_Logo, value, "Eco_Logo"); } }
		private int? _Idprice; public int? Idprice { get { return _Idprice; } set { Set(ref _Idprice, value, "Idprice"); } }
		private decimal? _Balance; public decimal? Balance { get { return _Balance; } set { Set(ref _Balance, value, "Balance"); } }
		private string _Cond_Entr; public string Cond_Entr { get { return _Cond_Entr; } set { Set(ref _Cond_Entr, value, "Cond_Entr"); } }
		private string _Statement_Send_By; public string Statement_Send_By { get { return _Statement_Send_By; } set { Set(ref _Statement_Send_By, value, "Statement_Send_By"); } }
		private string _Statement_Dest; public string Statement_Dest { get { return _Statement_Dest; } set { Set(ref _Statement_Dest, value, "Statement_Dest"); } }
		private string _Code_Accpac; public string Code_Accpac { get { return _Code_Accpac; } set { Set(ref _Code_Accpac, value, "Code_Accpac"); } }
		private string _Service_Client; public string Service_Client { get { return _Service_Client; } set { Set(ref _Service_Client, value, "Service_Client"); } }
		private string _Msg_Cocom; public string Msg_Cocom { get { return _Msg_Cocom; } set { Set(ref _Msg_Cocom, value, "Msg_Cocom"); } }
		private string _Msg_Cobil; public string Msg_Cobil { get { return _Msg_Cobil; } set { Set(ref _Msg_Cobil, value, "Msg_Cobil"); } }
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
		private string _Cart_Ond_Palettes; public string Cart_Ond_Palettes { get { return _Cart_Ond_Palettes; } set { Set(ref _Cart_Ond_Palettes, value, "Cart_Ond_Palettes"); } }
		private int? _Ballots_Long; public int? Ballots_Long { get { return _Ballots_Long; } set { Set(ref _Ballots_Long, value, "Ballots_Long"); } }
		private int? _Ballots_Larg; public int? Ballots_Larg { get { return _Ballots_Larg; } set { Set(ref _Ballots_Larg, value, "Ballots_Larg"); } }
		private int? _Ballots_Haut; public int? Ballots_Haut { get { return _Ballots_Haut; } set { Set(ref _Ballots_Haut, value, "Ballots_Haut"); } }
		private string _Palet_Notes; public string Palet_Notes { get { return _Palet_Notes; } set { Set(ref _Palet_Notes, value, "Palet_Notes"); } }
		private string _Mode_Empilage; public string Mode_Empilage { get { return _Mode_Empilage; } set { Set(ref _Mode_Empilage, value, "Mode_Empilage"); } }
		private string _Paquet_Attache; public string Paquet_Attache { get { return _Paquet_Attache; } set { Set(ref _Paquet_Attache, value, "Paquet_Attache"); } }
		private string _Type_Decharge; public string Type_Decharge { get { return _Type_Decharge; } set { Set(ref _Type_Decharge, value, "Type_Decharge"); } }
		private string _Groupe; public string Groupe { get { return _Groupe; } set { Set(ref _Groupe, value, "Groupe"); } }
		private string _Clipros; public string Clipros { get { return _Clipros; } set { Set(ref _Clipros, value, "Clipros"); } }
		private short? _Discount_Days; public short? Discount_Days { get { return _Discount_Days; } set { Set(ref _Discount_Days, value, "Discount_Days"); } }
		private decimal? _Discount_Rate; public decimal? Discount_Rate { get { return _Discount_Rate; } set { Set(ref _Discount_Rate, value, "Discount_Rate"); } }
		private string _Comptetiteur_Carton; public string Comptetiteur_Carton { get { return _Comptetiteur_Carton; } set { Set(ref _Comptetiteur_Carton, value, "Comptetiteur_Carton"); } }
		private string _Comptetiteur_Etiquette; public string Comptetiteur_Etiquette { get { return _Comptetiteur_Etiquette; } set { Set(ref _Comptetiteur_Etiquette, value, "Comptetiteur_Etiquette"); } }
		private string _Comptetiteur_Imprimerie; public string Comptetiteur_Imprimerie { get { return _Comptetiteur_Imprimerie; } set { Set(ref _Comptetiteur_Imprimerie, value, "Comptetiteur_Imprimerie"); } }
		private string _Comptetiteur_Emballage; public string Comptetiteur_Emballage { get { return _Comptetiteur_Emballage; } set { Set(ref _Comptetiteur_Emballage, value, "Comptetiteur_Emballage"); } }
		private decimal? _Potentiel_Carton; public decimal? Potentiel_Carton { get { return _Potentiel_Carton; } set { Set(ref _Potentiel_Carton, value, "Potentiel_Carton"); } }
		private decimal? _Potentiel_Etiquette; public decimal? Potentiel_Etiquette { get { return _Potentiel_Etiquette; } set { Set(ref _Potentiel_Etiquette, value, "Potentiel_Etiquette"); } }
		private decimal? _Potentiel_Imprimerie; public decimal? Potentiel_Imprimerie { get { return _Potentiel_Imprimerie; } set { Set(ref _Potentiel_Imprimerie, value, "Potentiel_Imprimerie"); } }
		private decimal? _Potentiel_Emballage; public decimal? Potentiel_Emballage { get { return _Potentiel_Emballage; } set { Set(ref _Potentiel_Emballage, value, "Potentiel_Emballage"); } }
		private decimal? _Projete_Carton; public decimal? Projete_Carton { get { return _Projete_Carton; } set { Set(ref _Projete_Carton, value, "Projete_Carton"); } }
		private decimal? _Projete_Etiquette; public decimal? Projete_Etiquette { get { return _Projete_Etiquette; } set { Set(ref _Projete_Etiquette, value, "Projete_Etiquette"); } }
		private decimal? _Projete_Imprimerie; public decimal? Projete_Imprimerie { get { return _Projete_Imprimerie; } set { Set(ref _Projete_Imprimerie, value, "Projete_Imprimerie"); } }
		private decimal? _Projete_Emballage; public decimal? Projete_Emballage { get { return _Projete_Emballage; } set { Set(ref _Projete_Emballage, value, "Projete_Emballage"); } }
		private string _Invoices_Dest; public string Invoices_Dest { get { return _Invoices_Dest; } set { Set(ref _Invoices_Dest, value, "Invoices_Dest"); } }
		private string _Invoices_Sent_By; public string Invoices_Sent_By { get { return _Invoices_Sent_By; } set { Set(ref _Invoices_Sent_By, value, "Invoices_Sent_By"); } }
		private string _Classification; public string Classification { get { return _Classification; } set { Set(ref _Classification, value, "Classification"); } }
		private bool? _Boite_Usage; public bool? Boite_Usage { get { return _Boite_Usage; } set { Set(ref _Boite_Usage, value, "Boite_Usage"); } }
		private int? _Idtax; public int? Idtax { get { return _Idtax; } set { Set(ref _Idtax, value, "Idtax"); } }
		private bool? _Tvh_Exem; public bool? Tvh_Exem { get { return _Tvh_Exem; } set { Set(ref _Tvh_Exem, value, "Tvh_Exem"); } }
		private string _Hst_No; public string Hst_No { get { return _Hst_No; } set { Set(ref _Hst_No, value, "Hst_No"); } }
		private string _Mod_By; public string Mod_By { get { return _Mod_By; } set { Set(ref _Mod_By, value, "Mod_By"); } }
		private DateTime? _Mod_Date; public DateTime? Mod_Date { get { return _Mod_Date; } set { Set(ref _Mod_Date, value, "Mod_Date"); } }
		private int? _Idzone; public int? Idzone { get { return _Idzone; } set { Set(ref _Idzone, value, "Idzone"); } }
		private decimal? _Fuel; public decimal? Fuel { get { return _Fuel; } set { Set(ref _Fuel, value, "Fuel"); } }
		private short? _Jrshold; public short? Jrshold { get { return _Jrshold; } set { Set(ref _Jrshold, value, "Jrshold"); } }
		private string _Transp_Notes; public string Transp_Notes { get { return _Transp_Notes; } set { Set(ref _Transp_Notes, value, "Transp_Notes"); } }
		private bool? _Ct_Appoint; public bool? Ct_Appoint { get { return _Ct_Appoint; } set { Set(ref _Ct_Appoint, value, "Ct_Appoint"); } }
		private string _Ct_Contact; public string Ct_Contact { get { return _Ct_Contact; } set { Set(ref _Ct_Contact, value, "Ct_Contact"); } }
		private string _Ct_Tel; public string Ct_Tel { get { return _Ct_Tel; } set { Set(ref _Ct_Tel, value, "Ct_Tel"); } }
		private bool? _Ct_Certifica; public bool? Ct_Certifica { get { return _Ct_Certifica; } set { Set(ref _Ct_Certifica, value, "Ct_Certifica"); } }
		private int? _Ct_Def_Tr; public int? Ct_Def_Tr { get { return _Ct_Def_Tr; } set { Set(ref _Ct_Def_Tr, value, "Ct_Def_Tr"); } }
		private int? _Ct_Snow_Tr; public int? Ct_Snow_Tr { get { return _Ct_Snow_Tr; } set { Set(ref _Ct_Snow_Tr, value, "Ct_Snow_Tr"); } }
		private string _Ct_Note_Tr; public string Ct_Note_Tr { get { return _Ct_Note_Tr; } set { Set(ref _Ct_Note_Tr, value, "Ct_Note_Tr"); } }
		private bool? _Ct_Lun; public bool? Ct_Lun { get { return _Ct_Lun; } set { Set(ref _Ct_Lun, value, "Ct_Lun"); } }
		private bool? _Ct_Mar; public bool? Ct_Mar { get { return _Ct_Mar; } set { Set(ref _Ct_Mar, value, "Ct_Mar"); } }
		private bool? _Ct_Mer; public bool? Ct_Mer { get { return _Ct_Mer; } set { Set(ref _Ct_Mer, value, "Ct_Mer"); } }
		private bool? _Ct_Jeu; public bool? Ct_Jeu { get { return _Ct_Jeu; } set { Set(ref _Ct_Jeu, value, "Ct_Jeu"); } }
		private bool? _Ct_Ven; public bool? Ct_Ven { get { return _Ct_Ven; } set { Set(ref _Ct_Ven, value, "Ct_Ven"); } }
		private bool? _Ct_Sam; public bool? Ct_Sam { get { return _Ct_Sam; } set { Set(ref _Ct_Sam, value, "Ct_Sam"); } }
		private decimal? _Ct_D1_Lun; public decimal? Ct_D1_Lun { get { return _Ct_D1_Lun; } set { Set(ref _Ct_D1_Lun, value, "Ct_D1_Lun"); } }
		private decimal? _Ct_F1_Lun; public decimal? Ct_F1_Lun { get { return _Ct_F1_Lun; } set { Set(ref _Ct_F1_Lun, value, "Ct_F1_Lun"); } }
		private decimal? _Ct_D1_Mar; public decimal? Ct_D1_Mar { get { return _Ct_D1_Mar; } set { Set(ref _Ct_D1_Mar, value, "Ct_D1_Mar"); } }
		private decimal? _Ct_F1_Mar; public decimal? Ct_F1_Mar { get { return _Ct_F1_Mar; } set { Set(ref _Ct_F1_Mar, value, "Ct_F1_Mar"); } }
		private decimal? _Ct_D1_Mer; public decimal? Ct_D1_Mer { get { return _Ct_D1_Mer; } set { Set(ref _Ct_D1_Mer, value, "Ct_D1_Mer"); } }
		private decimal? _Ct_F1_Mer; public decimal? Ct_F1_Mer { get { return _Ct_F1_Mer; } set { Set(ref _Ct_F1_Mer, value, "Ct_F1_Mer"); } }
		private decimal? _Ct_D1_Jeu; public decimal? Ct_D1_Jeu { get { return _Ct_D1_Jeu; } set { Set(ref _Ct_D1_Jeu, value, "Ct_D1_Jeu"); } }
		private decimal? _Ct_F1_Jeu; public decimal? Ct_F1_Jeu { get { return _Ct_F1_Jeu; } set { Set(ref _Ct_F1_Jeu, value, "Ct_F1_Jeu"); } }
		private decimal? _Ct_D1_Ven; public decimal? Ct_D1_Ven { get { return _Ct_D1_Ven; } set { Set(ref _Ct_D1_Ven, value, "Ct_D1_Ven"); } }
		private decimal? _Ct_F1_Ven; public decimal? Ct_F1_Ven { get { return _Ct_F1_Ven; } set { Set(ref _Ct_F1_Ven, value, "Ct_F1_Ven"); } }
		private decimal? _Ct_D1_Sam; public decimal? Ct_D1_Sam { get { return _Ct_D1_Sam; } set { Set(ref _Ct_D1_Sam, value, "Ct_D1_Sam"); } }
		private decimal? _Ct_F1_Sam; public decimal? Ct_F1_Sam { get { return _Ct_F1_Sam; } set { Set(ref _Ct_F1_Sam, value, "Ct_F1_Sam"); } }
		private decimal? _Ct_D2_Lun; public decimal? Ct_D2_Lun { get { return _Ct_D2_Lun; } set { Set(ref _Ct_D2_Lun, value, "Ct_D2_Lun"); } }
		private decimal? _Ct_F2_Lun; public decimal? Ct_F2_Lun { get { return _Ct_F2_Lun; } set { Set(ref _Ct_F2_Lun, value, "Ct_F2_Lun"); } }
		private decimal? _Ct_D2_Mar; public decimal? Ct_D2_Mar { get { return _Ct_D2_Mar; } set { Set(ref _Ct_D2_Mar, value, "Ct_D2_Mar"); } }
		private decimal? _Ct_F2_Mar; public decimal? Ct_F2_Mar { get { return _Ct_F2_Mar; } set { Set(ref _Ct_F2_Mar, value, "Ct_F2_Mar"); } }
		private decimal? _Ct_D2_Mer; public decimal? Ct_D2_Mer { get { return _Ct_D2_Mer; } set { Set(ref _Ct_D2_Mer, value, "Ct_D2_Mer"); } }
		private decimal? _Ct_F2_Mer; public decimal? Ct_F2_Mer { get { return _Ct_F2_Mer; } set { Set(ref _Ct_F2_Mer, value, "Ct_F2_Mer"); } }
		private decimal? _Ct_D2_Jeu; public decimal? Ct_D2_Jeu { get { return _Ct_D2_Jeu; } set { Set(ref _Ct_D2_Jeu, value, "Ct_D2_Jeu"); } }
		private decimal? _Ct_F2_Jeu; public decimal? Ct_F2_Jeu { get { return _Ct_F2_Jeu; } set { Set(ref _Ct_F2_Jeu, value, "Ct_F2_Jeu"); } }
		private decimal? _Ct_D2_Ven; public decimal? Ct_D2_Ven { get { return _Ct_D2_Ven; } set { Set(ref _Ct_D2_Ven, value, "Ct_D2_Ven"); } }
		private decimal? _Ct_F2_Ven; public decimal? Ct_F2_Ven { get { return _Ct_F2_Ven; } set { Set(ref _Ct_F2_Ven, value, "Ct_F2_Ven"); } }
		private decimal? _Ct_D2_Sam; public decimal? Ct_D2_Sam { get { return _Ct_D2_Sam; } set { Set(ref _Ct_D2_Sam, value, "Ct_D2_Sam"); } }
		private decimal? _Ct_F2_Sam; public decimal? Ct_F2_Sam { get { return _Ct_F2_Sam; } set { Set(ref _Ct_F2_Sam, value, "Ct_F2_Sam"); } }
		private decimal? _Prixin; public decimal? Prixin { get { return _Prixin; } set { Set(ref _Prixin, value, "Prixin"); } }
		private decimal? _Prixout; public decimal? Prixout { get { return _Prixout; } set { Set(ref _Prixout, value, "Prixout"); } }
		private bool? _Entreposage; public bool? Entreposage { get { return _Entreposage; } set { Set(ref _Entreposage, value, "Entreposage"); } }
		private decimal? _Sprpalcl; public decimal? Sprpalcl { get { return _Sprpalcl; } set { Set(ref _Sprpalcl, value, "Sprpalcl"); } }
		private decimal? _Dprpalcl; public decimal? Dprpalcl { get { return _Dprpalcl; } set { Set(ref _Dprpalcl, value, "Dprpalcl"); } }
		private decimal? _Tprpalcl; public decimal? Tprpalcl { get { return _Tprpalcl; } set { Set(ref _Tprpalcl, value, "Tprpalcl"); } }
		private decimal? _Sprpalms; public decimal? Sprpalms { get { return _Sprpalms; } set { Set(ref _Sprpalms, value, "Sprpalms"); } }
		private decimal? _Dprpalms; public decimal? Dprpalms { get { return _Dprpalms; } set { Set(ref _Dprpalms, value, "Dprpalms"); } }
		private decimal? _Tprpalms; public decimal? Tprpalms { get { return _Tprpalms; } set { Set(ref _Tprpalms, value, "Tprpalms"); } }
		private bool? _Nolot; public bool? Nolot { get { return _Nolot; } set { Set(ref _Nolot, value, "Nolot"); } }
		private bool? _Nopalet; public bool? Nopalet { get { return _Nopalet; } set { Set(ref _Nopalet, value, "Nopalet"); } }
		private bool? _Trpbpc; public bool? Trpbpc { get { return _Trpbpc; } set { Set(ref _Trpbpc, value, "Trpbpc"); } }
		private bool? _Trpbpch; public bool? Trpbpch { get { return _Trpbpch; } set { Set(ref _Trpbpch, value, "Trpbpch"); } }
		private bool? _Trpmc; public bool? Trpmc { get { return _Trpmc; } set { Set(ref _Trpmc, value, "Trpmc"); } }
		private bool? _Trptp; public bool? Trptp { get { return _Trptp; } set { Set(ref _Trptp, value, "Trptp"); } }
		private bool? _Pasechues; public bool? Pasechues { get { return _Pasechues; } set { Set(ref _Pasechues, value, "Pasechues"); } }
		private string _Tel1poste; public string Tel1poste { get { return _Tel1poste; } set { Set(ref _Tel1poste, value, "Tel1poste"); } }
		private string _Tel2poste; public string Tel2poste { get { return _Tel2poste; } set { Set(ref _Tel2poste, value, "Tel2poste"); } }
		private decimal? _Tvhtaux; public decimal? Tvhtaux { get { return _Tvhtaux; } set { Set(ref _Tvhtaux, value, "Tvhtaux"); } }
		private short? _Esclp; public short? Esclp { get { return _Esclp; } set { Set(ref _Esclp, value, "Esclp"); } }
		private bool? _Logonon; public bool? Logonon { get { return _Logonon; } set { Set(ref _Logonon, value, "Logonon"); } }
		private bool? _Logoadd; public bool? Logoadd { get { return _Logoadd; } set { Set(ref _Logoadd, value, "Logoadd"); } }
		private bool? _Trfcli; public bool? Trfcli { get { return _Trfcli; } set { Set(ref _Trfcli, value, "Trfcli"); } }
		private bool? _Intercie; public bool? Intercie { get { return _Intercie; } set { Set(ref _Intercie, value, "Intercie"); } }
		private bool? _Exlot; public bool? Exlot { get { return _Exlot; } set { Set(ref _Exlot, value, "Exlot"); } }
		private char? _Grlot; public char? Grlot { get { return _Grlot; } set { Set(ref _Grlot, value, "Grlot"); } }
		private bool? _Unpofact; public bool? Unpofact { get { return _Unpofact; } set { Set(ref _Unpofact, value, "Unpofact"); } }
		private bool? _Overprod; public bool? Overprod { get { return _Overprod; } set { Set(ref _Overprod, value, "Overprod"); } }

	}
}