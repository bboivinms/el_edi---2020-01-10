using EDICommons.Tools;
using EDI_RSS.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public partial class Program_855 : EDI_RSS.Program_Base
    {
        public Program_855()
        {
            TransactionCode = "855";
            LogEventSource = "EDI 855 Processor";

            Xml855Writer xml = null;

            List<IDataRecord> RawDataDetails;
            string cocom_ident;
            string edi_ident;

            Status += "Program_855" + NL + "UseSystem: " + UseSystem + NL + "TheFilename: " + Filename + NL;
            Status += "RSS_send_path: " + RSS_send_path + NL;
            Status += "DB_VIVA: " + DB_VIVA.conn.ConnectionString + NL;
            Status += "PortID: " + PortId + NL;

            try
            {
                //Create/Update edi_855 table to "catch" differences since last time we ran this interface
                Status += "CreateNew" + NL;
                CreateNew();
                Status += "UpdateExisting" + NL;
                UpdateExisting();

                //After create/update of 855 data, edi_855 rows marked as "New" and "Not Sent" are used to generate the actual X12 855 document(s)
                Status += "GetData" + NL;
                List<IDataRecord> RawData = GetData();

                if (RawData == null)
                {
                    Status += "No XML Records to process" + NL;
                }
                else
                {
                    //There might be multiple 855, each group represents a single one
                    foreach (IDataRecord Data in RawData)
                    {
                        cocom_ident = Data["cocom_ident"].ToString();
                        edi_ident = Data["edi_855_ident"].ToString();

                        SetupClient(Convert.ToInt32(Data["cocom_clientid"]));

                        Status += "GetDataLines: " + cocom_ident + NL;

                        RawDataDetails = GetDataDetails(cocom_ident);

                        xml = new Xml855Writer(Data, RawDataDetails);

                        xml.Write(this);

                        UpdateFilename("edi_855", xml.OutputFileName, edi_ident);

                    }
                }

            }
            catch (System.Exception e)
            {
                Error += "Error caught: " + e.Message;
                // Something unexpected went wrong.
                LogWriter.WriteMessage(LogEventSource, $"Error caught: {e.Message}");
            }
        }

        public void CreateNew()
        {
            DB_VIVA.HExecuteSQLNonQuery(@"start transaction;
                                insert into edi_855(IdCocom, Status, Validator)
                                select Id, Stat, NewValidator from
                                (select cocom.ident as Id, 'N' as Stat,
                                        GROUP_CONCAT(cocomi.line, '|', cocomi.idprod, '|', cocomi.QTY_ORD, '|', ifnull(cobili.QTY, ''), '|', ifnull(cocom.req_dte, ''), '|', ifnull(cobil.REQ_DTE, '')
                                        ORDER BY cocomi.line SEPARATOR '\r') AS NewValidator, edi_855.Validator
                                from cocom
                                inner join cocomi on cocom.ident = cocomi.idco
                                left
                                join cobili on cocom.ident = cobili.idcom and cocomi.idprod = cobili.idprod
                                left join cobil on cobil.ident = cobili.idcobil
                                left join edi_855 on cocom.ident = edi_855.IdCocom
                                WHERE LEFT(cocom.CR_BY, 4) = 'XEDI'
                                GROUP BY cocom.ident
                                having isnull(edi_855.Validator)) as TempQuery;
                                commit; ", Params);
        }

        public void UpdateExisting()
        {
              DB_VIVA.HExecuteSQLNonQuery(
                  @"START TRANSACTION;

                    SET @Ids := 
                    (SELECT GROUP_CONCAT(Id) FROM
                    (SELECT edi_855.Ident as Id,
		                    GROUP_CONCAT(cocomi.line,'|',cocomi.idprod, '|', cocomi.QTY_ORD, '|', ifnull(cobili.QTY, ''), '|',ifnull(cocom.req_dte, ''), '|', ifnull(cobil.REQ_DTE, '') 
                            ORDER BY cocomi.line SEPARATOR '\r') AS NewValidator, edi_855.Validator, edi_855.Status
                    FROM cocom
                    INNER JOIN cocomi ON cocom.ident = cocomi.idco
                    LEFT JOIN cobili ON cocom.ident = cobili.idcom AND cocomi.idprod = cobili.idprod
                    LEFT JOIN cobil ON cobil.ident = cobili.idcobil
                    LEFT JOIN edi_855 ON cocom.ident = edi_855.IdCocom
                    WHERE LEFT(cocom.CR_BY, 4) = 'XEDI' AND edi_855.Status = 'N'
                    AND (cobil.statut = 'W' OR cobil.statut = 'C' OR cobil.statut IS NULL)
                    AND (SELECT IFNULL(SUM(cocomi.qty_ord), 0) FROM cocomi WHERE cocomi.idco = cocom.ident) <>
					    (SELECT IFNULL(SUM(arinvd.qty), 0) FROM arinvd INNER JOIN arinv ON arinvd.ident = arinv.ident WHERE arinvd.idcom = cocom.ident AND arinv.status = 'P') 
                    GROUP BY cocom.ident
                    HAVING (NewValidator <> edi_855.Validator)) AS TmpQuery);

                    INSERT INTO edi_855 (IdCocom, Status, Validator)
                    SELECT Id, Stat, NewValidator FROM
                    (SELECT cocom.ident AS Id, 'N' AS Stat,
		                    GROUP_CONCAT(cocomi.line,'|',cocomi.idprod, '|', cocomi.QTY_ORD, '|', ifnull(cobili.QTY, ''), '|',ifnull(cocom.req_dte, ''), '|', ifnull(cobil.REQ_DTE, '') 
                            ORDER BY cocomi.line SEPARATOR '\r') AS NewValidator, edi_855.Validator, edi_855.Status
                    FROM cocom
                    INNER JOIN cocomi ON cocom.ident = cocomi.idco
                    LEFT JOIN cobili ON cocom.ident = cobili.idcom AND cocomi.idprod = cobili.idprod
                    LEFT JOIN cobil ON cobil.ident = cobili.idcobil
                    LEFT JOIN edi_855 on cocom.ident = edi_855.IdCocom
                    WHERE LEFT(cocom.CR_BY, 4) = 'XEDI' AND edi_855.Status = 'N'
                    AND (cobil.statut = 'W' OR cobil.statut = 'C' OR cobil.statut IS NULL)
                    AND (SELECT IFNULL(SUM(cocomi.qty_ord), 0) FROM cocomi WHERE cocomi.idco = cocom.ident) <>
					    (SELECT IFNULL(SUM(arinvd.qty), 0) FROM arinvd INNER JOIN arinv ON arinvd.ident = arinv.ident WHERE arinvd.idcom = cocom.ident AND arinv.status = 'P') 
                    GROUP BY cocom.ident
                    HAVING (NewValidator <> edi_855.Validator)) AS TempQuery;

                    UPDATE edi_855
                    SET Status = 'O'
                    WHERE FIND_IN_SET(Ident, @Ids) AND ident <> 0;

                    COMMIT;");

        }

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  cocom.ident AS cocom_ident, cocom.clientpo AS cocom_clientpo, cocom.clientid AS cocom_clientid, cocom.co_dte AS cocom_co_dte, 
                        cocom.del_name as cocom_del_name, cocom.daddr1 AS cocom_daddr1, cocom.daddr2 AS cocom_daddr2, 
                        cocom.dcity as cocom_dcity, cocom.dstate as cocom_dstate, cocom.dzip as cocom_dzip,
                        edi_855.ident AS edi_855_ident, edi_855.filename AS edi_855_filename
                FROM cocom 
                INNER JOIN edi_855 ON edi_855.idcocom = cocom.ident
                LEFT JOIN cocomi ON cocomi.idco = cocom.ident
                WHERE 
                        LEFT(cocom.CR_BY, 4) = 'XEDI' 
                        AND edi_855.Status = 'N' 
                        AND edi_855.Sent = false
                        AND (SELECT IFNULL(SUM(cocomi.qty_ord), 0) FROM cocomi WHERE cocomi.idco = cocom.ident) <>
					        (SELECT IFNULL(SUM(arinvd.qty), 0) FROM arinvd INNER JOIN arinv ON arinvd.ident = arinv.ident WHERE arinvd.idcom = cocom.ident AND arinv.status = 'P') 
                GROUP BY cocom.ident
                ");

            // AND cocom.clientpo = '4500000387'
            // AND(cocom.clientpo = '4501000399' or cocom.clientpo = '4501000375' or cocom.clientpo = '4501000291' or cocom.clientpo = '4501000073')
            //or cocom.clientpo = '4501000375' or cocom.clientpo = '4501000291' or cocom.clientpo = '4501000073')

        }

        public List<IDataRecord> GetDataDetails(string cocom_ident)
        {
            Params.Clear();
            Params.Add("?cocom_ident", cocom_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  cocom.ident AS cocom_ident, cocom.clientpo AS cocom_clientpo, cocom.clientid AS cocom_clientid, cocom.co_dte AS cocom_co_dte, 
                                        cocom.del_name as cocom_del_name, cocom.daddr1 AS cocom_daddr1, cocom.daddr2 AS cocom_daddr1, 
                        cocom.dcity as cocom_dcity, cocom.dstate as cocom_dstate, cocom.dzip as cocom_dzip, 
                        cocomi.line AS cocomi_line, cocomi.idprod, cocomi.desc, cocomi.qty_ord AS cocomi_qty_ord, 
                        cocomi.req_date AS cocomi_req_date, cocomi.unite AS cocomi_unite, cocomi.price AS cocomi_price, 
                        ivprod.code AS ivprod_code, ivprod.ident AS ivprod_ident,
                        ivprixdcli.codecli AS ivprixdcli_codecli,
                        edi_855.ident AS edi_855_ident
                FROM cocom 
                INNER JOIN cocomi ON cocom.ident = cocomi.idco
                INNER JOIN ivprod ON ivprod.ident = cocomi.idprod
                INNER JOIN edi_855 ON edi_855.idcocom = cocom.ident
                LEFT JOIN ivprixdcli ON (ivprixdcli.idclient = cocom.clientid AND ivprixdcli.idprod = cocomi.idprod AND IFNULL(ivprixdcli.codecli, '') <> '')
                WHERE LEFT(cocom.cr_by, 4) = 'XEDI' AND edi_855.Status = 'N' AND edi_855.Sent = false
                AND cocom.ident = ?cocom_ident
                ORDER BY cocom.ident, cocomi.line
                ", Params);

        }

        public List<IDataRecord> GetDataLines(string cocom_ident, string cocomi_line)
        {
            Params.Clear();
            Params.Add("?cocom_ident", cocom_ident);
            Params.Add("?cocomi_line", cocomi_line);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  cocom.ident AS cocom_ident, cocom.clientpo AS cocom_clientpo, cocom.clientid, cocom.co_dte AS cocom_co_dte, 
                        cocomi.line, cocomi.idprod, cocomi.desc, cocomi.qty_ord AS cocomi_qty_ord, cocomi.req_date AS cocomi_req_date, cocomi.unite AS cocomi_unite, cocomi.price AS cocomi_price, 
                        ivprod.code AS ivprod_code,
                        cobil.req_dte AS cobil_req_date, cobil.ident AS cobil_ident, 
                        cobili.qty AS cobili_qty, 
                        ivprixdcli.codecli AS ivprixdcli_codecli
                FROM cocom 
                INNER JOIN cocomi ON cocom.ident = cocomi.idco
                INNER JOIN ivprod ON ivprod.ident = cocomi.idprod
                INNER JOIN edi_855 ON edi_855.IdCocom = cocom.ident       
                LEFT JOIN cobili ON cobili.idcom = cocom.ident AND cobili.idprod = cocomi.IDPROD
                LEFT JOIN cobil ON cobil.ident = cobili.IDCOBIL
                LEFT JOIN ivprixdcli ON (ivprixdcli.idclient = cocom.clientid AND ivprixdcli.idprod = cocomi.idprod AND IFNULL(ivprixdcli.codecli, '') <> '')
                WHERE 
                        LEFT(cocom.CR_BY, 4) = 'XEDI' 
                    AND edi_855.Status = 'N' 
                    AND edi_855.Sent = false
                    AND (cobil.statut = 'W' OR cobil.statut = 'C')
                    AND cocom.ident = ?cocom_ident 
                    AND cocomi.line = ?cocomi_line
                ", Params);
        }
    }
}
