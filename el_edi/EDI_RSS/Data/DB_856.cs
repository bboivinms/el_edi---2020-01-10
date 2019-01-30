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
    public class Program_856 : EDI_RSS.Program_Base
    {
        public Program_856()
        {
            TransactionCode = "856";

            LogEventSource = "EDI 856 Processor";

            Xml856Writer xml = null;

            List<IDataRecord> RawDataDetails;
            string arinv_ident;
            string edi_ident;

            Status += "Program_856" + NL + "UseSystem: " + UseSystem + NL + "TheFilename: " + Filename + NL;

            try
            {
                CreateNew();
                
                List<IDataRecord> RawData = GetData();

                foreach (IDataRecord Data in RawData)
                {
                    arinv_ident = Data["arinv_ident"].ToString();
                    edi_ident = Data["edi_810_ident"].ToString();

                    SetupClient(Convert.ToInt32(Data["arinv_custid"]));

                    Status += "GetDataDetails: " + arinv_ident + NL;

                    RawDataDetails = GetDataDetails(arinv_ident);

                    xml = new Xml856Writer(Data, RawDataDetails);

                    xml.Write(this);

                    UpdateFilename("edi_856", xml.OutputFileName, edi_ident);
                } 

            }
            catch (System.Exception e)
            {
                Error += "Error caught: " + e.Message;
                LogWriter.WriteMessage(LogEventSource, $"Error caught: {e.Message}");
            }
            finally
            {
            }
        }

        public void CreateNew()
        {
            DB_VIVA.HExecuteSQLNonQuery(@" 
                INSERT INTO edi_810 (arinv_ident) 
                SELECT ident 
                FROM arinv
                    WHERE   status = 'P' AND custid = 30037 AND 
                            ident > 14350 AND 
                            NOT EXISTS(SELECT 1 FROM edi_810 AS edi_810e WHERE edi_810e.arinv_ident = arinv.ident); 
                ALTER TABLE edi_810 AUTO_INCREMENT = 1;");
        }

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT  
                        arinv.ident AS arinv_ident, arinv.invno AS arinv_invno, arinv.invdte AS arinv_invdte, arinv.custid AS arinv_custid,
                        arinv.po AS arinv_po, arinv.idbil AS arinv_idbil, arinv.inv_mnt AS arinv_inv_mnt, arinv.INV_TX_GST AS arinv_inv_tx_gst,
                        arinv.INV_TX_PST AS arinv_inv_tx_pst, arinv.TPSTAUX AS arinv_tpstaux, arinv.TVQTAUX AS arinv_tvqtaux,
                        arinv.TVHTAUX AS arinv_tvhtaux, arinv.INV_TX_TVH AS arinv_inv_tx_tvh,
                        edi_810.ident AS edi_810_ident, edi_810.filename AS edi_810_filename
                FROM arinv 
                INNER JOIN edi_810 ON edi_810.arinv_ident = arinv.ident
                WHERE edi_810.Sent = false 
                      AND
                      arinv_ident = 14353
                ");
        }

        public List<IDataRecord> GetDataDetails(string arinv_ident)
        {
            Params.Clear();
            Params.Add("?arinv_ident", arinv_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  
                        arinvd.invline AS arinvd_invline, arinvd.qty AS arinvd_qty, arinvd.inv_mnt_unit AS arinvd_inv_mnt_unit,
                        arinvd.unite AS arinvd_unite, arinvd.descr AS arinvd_descr, arinvd.idbil AS arinvd_idbil,
                        ivprod.code AS ivprod_code, ivprod.DESC AS ivprod_desc,
                        edi_810.ident AS edi_810_ident,
                        ivprixdcli.codecli AS ivprixdcli_codecli,
                        cobili.PO_NO AS cobili_po_no,
                        cocom.CLIENTPO AS cocom_clientpo, cocom.ident AS cocom_ident  
                FROM arinv 
                INNER JOIN arinvd ON arinv.ident = arinvd.ident
                INNER JOIN ivprod ON ivprod.ident = arinvd.idprod
                INNER JOIN edi_810 ON edi_810.arinv_ident = arinv.ident
                LEFT JOIN ivprixdcli ON (ivprixdcli.idclient = arinv.custid AND ivprixdcli.idprod = arinvd.idprod AND IFNULL(ivprixdcli.codecli, '') <> '')
                INNER JOIN cobili ON cobili.IDCOBIL= arinv.IDBIL AND cobili.LINE = arinvd.BIL_LINE
                INNER JOIN cocom ON cocom.ident = cobili.IDCOM
                WHERE   edi_810.Sent = false 
                        AND
                        arinv.ident = ?arinv_ident
                ORDER BY arinvd.ident, arinvd.invline
                ", Params);
        }
    }
}
