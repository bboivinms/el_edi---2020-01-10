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
            string cobil_ident;
            string edi_ident;

            Status += "Program_856" + NL + "UseSystem: " + UseSystem + NL + "TheFilename: " + Filename + NL;

            try
            {
                CreateNew();
                
                List<IDataRecord> RawData = GetData();

                foreach (IDataRecord Data in RawData)
                {
                    cobil_ident = Data["cobil_ident"].ToString();
                    edi_ident = Data["edi_856_ident"].ToString();

                    SetupClient(Convert.ToInt32(Data["cobil_clientid"]));

                    Status += "GetDataDetails: " + cobil_ident + NL;

                    RawDataDetails = GetDataDetails(cobil_ident);

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
                INSERT INTO edi_856 (cobil_ident) 
                SELECT cobil.ident 
                FROM cobil
                    WHERE   cobil.clientid = 30037 AND 
                            cobil.ident > 14350 AND 
                            NOT EXISTS(SELECT 1 FROM edi_856 AS edi_856e WHERE edi_856e.cobil_ident = cobil.ident); 
                ALTER TABLE edi_856 AUTO_INCREMENT = 1;");
        }

        public List<IDataRecord> GetData()
        {
            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT  
                        cobil.ident AS cobil_ident, cobil.clientid AS cobil_clientid, cobil.clientpo AS cobil_clientpo, cobil.BIL_DTE AS cobil_bil_dte,
                        edi_856.ident AS edi_856_ident, edi_856.filename AS edi_856_filename, edi_856.Ship_date AS edi_856_ship_date
                FROM cobil 
                INNER JOIN edi_856 ON edi_856.cobil_ident = cobil.ident
                WHERE edi_856.Sent = false 
                      AND
                      cobil.ident = 14506
                ");
        }

        public List<IDataRecord> GetDataDetails(string cobil_ident)
        {
            Params.Clear();
            Params.Add("?cobil_ident", cobil_ident);

            return DB_VIVA.HExecuteSQLQuery(
                @"SELECT  
                        ivprod.code AS ivprod_code, ivprod.DESC AS ivprod_desc,
                        edi_856.ident AS edi_856_ident,
                        ivprixdcli.codecli AS ivprixdcli_codecli,
                        cobili.PO_NO AS cobili_po_no,
                        cocom.CLIENTPO AS cocom_clientpo, cocom.ident AS cocom_ident  
                FROM cobil 
                INNER JOIN cobili ON cobil.ident = cobili.idcobil
                INNER JOIN ivprod ON ivprod.ident = cobili.idprod
                INNER JOIN edi_856 ON edi_856.cobil_ident = cobil.ident
                LEFT JOIN ivprixdcli ON (ivprixdcli.idclient = cobil.clientid AND ivprixdcli.idprod = cobili.idprod AND IFNULL(ivprixdcli.codecli, '') <> '')
                INNER JOIN cocom ON cocom.ident = cobili.IDCOM
                WHERE   edi_856.Sent = false 
                        AND
                        cobil.ident = ?cobil_ident
                ORDER BY cobili.ident, cobili.line
                ", Params);
        }
    }
}
