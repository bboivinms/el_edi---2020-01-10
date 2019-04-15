using MySql.Data.MySqlClient;
using EDI_850.Helpers;
using System;
using System.Data;
using System.Linq;
using EDICommons.Tools;
using EDI_DB.Data;
using static EDI_DB.Data.Base;
using System.Xml;

namespace EDI_RSS
{
    public partial class XMLProcessor_810
    {
        private XmlNamespaceManager nsmgr;

        public XMLProcessor_810(XmlNamespaceManager nsmgr)
        {
            this.nsmgr = nsmgr;
        }


        public void ProcessOrder(XmlNode XMLNode, string filepath)
        {
            string program810Id = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();

            XmlNode N1Loop1ST = Get_Node(XMLNode, "//N1Loop1[N1/N101 = 'ST']");
            XmlNode N1Loop1VN = Get_Node(XMLNode, "//N1Loop1[N1/N101 = 'VN']");

            try
            {
                MySqlCommand cmd = DB_VIVA.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO edi_810v (Filename, arinv_invdte, arinv_invno, arinv_po, arinv_idbil," +
                    "STname, STiddel_addr, STaddr1, STaddr2, STcity, STstate, STzip, VNname, VNiddel_addr, VNaddr1, VNaddr2, VNcity, VNstate, VNzip, arinv_inv_mnt)" +
                    " VALUE(?Filename, ?arinv_invdte, ?arinv_invno, ?arinv_po, ?arinv_idbil, ?STname, ?STiddel_addr, ?STaddr1, ?STaddr2, ?STcity, ?STstate," +
                    " ?STzip, ?VNname, ?VNiddel_addr, ?VNaddr1, ?VNaddr2, ?VNcity, ?VNstate, ?VNzip, ?arinv_inv_mnt)";

                cmd.Parameters.AddWithValue("?Filename", filepath);
                cmd.Parameters.AddWithValue("?arinv_invdte", IIF_NULL(XMLNode, "//BIG//BIG01"));
                cmd.Parameters.AddWithValue("?arinv_invno", IIF_NULL(XMLNode, "//BIG//BIG02"));
                cmd.Parameters.AddWithValue("?arinv_po", IIF_NULL(XMLNode, "//BIG//BIG04"));
                cmd.Parameters.AddWithValue("?arinv_idbil", IIF_NULL(XMLNode, "//TX-00403-810//REF//REF02"));
                cmd.Parameters.AddWithValue("?STname", IIF_NULL(N1Loop1ST, ".//N102"));
                cmd.Parameters.AddWithValue("?STiddel_addr", IIF_NULL(N1Loop1ST, ".//N104"));
                cmd.Parameters.AddWithValue("?STaddr1", IIF_NULL(N1Loop1ST, ".//N301"));
                cmd.Parameters.AddWithValue("?STaddr2", IIF_NULL(N1Loop1ST, ".//N302"));
                cmd.Parameters.AddWithValue("?STcity", IIF_NULL(N1Loop1ST, ".//N401"));
                cmd.Parameters.AddWithValue("?STstate", IIF_NULL(N1Loop1ST, ".//N402"));
                cmd.Parameters.AddWithValue("?STzip", IIF_NULL(N1Loop1ST, ".//N403"));
                cmd.Parameters.AddWithValue("?VNname", IIF_NULL(N1Loop1VN, ".//N102"));
                cmd.Parameters.AddWithValue("?VNiddel_addr", IIF_NULL(N1Loop1VN, ".//N104"));
                cmd.Parameters.AddWithValue("?VNaddr1", IIF_NULL(N1Loop1VN, ".//N301"));
                cmd.Parameters.AddWithValue("?VNaddr2", IIF_NULL(N1Loop1VN, ".//N302"));
                cmd.Parameters.AddWithValue("?VNcity", IIF_NULL(N1Loop1VN, ".//N401"));
                cmd.Parameters.AddWithValue("?VNstate", IIF_NULL(N1Loop1VN, ".//N402"));
                cmd.Parameters.AddWithValue("?VNzip", IIF_NULL(N1Loop1VN, ".//N403"));
                cmd.Parameters.AddWithValue("?arinv_inv_mnt", IIF_NULL(XMLNode, "//TDS//TDS01"));

                cmd.ExecuteNonQuery();

                //loop items
                int nb = 1;
                XmlNode IT1Loop1;
                while ((IT1Loop1 = Get_Node(XMLNode, "//IT1Loop1[" + nb + "]", false)) != null)
                {
                    cmd.CommandText = "INSERT INTO edi_810vd (arinvd_invline, arinvd_qty, UnitMeasurementCode, arinvd_inv_mnt_unit," +
                    " UnitPriceCode, ivprixdcli_codecli, ivprod_code, ivprod_desc, arinvd_idbil, cocom_clientpo, cocom_ident, programId)" +
                    " VALUE(?arinvd_invline, ?arinvd_qty, ?UnitMeasurementCode, ?arinvd_inv_mnt_unit, ?UnitPriceCode, ?ivprixdcli_codecli," +
                    " ?ivprod_code, ?ivprod_desc, ?arinvd_idbil, ?cocom_clientpo, ?cocom_ident, ?programId)";

                    cmd.Parameters.AddWithValue("?arinvd_invline", IIF_NULL(IT1Loop1, ".//IT1//IT101"));
                    cmd.Parameters.AddWithValue("?arinvd_qty", IIF_NULL(IT1Loop1, ".//IT1//IT102"));
                    cmd.Parameters.AddWithValue("?UnitMeasurementCode", IIF_NULL(IT1Loop1, ".//IT1//IT103"));
                    cmd.Parameters.AddWithValue("?arinvd_inv_mnt_unit", IIF_NULL(IT1Loop1, ".//IT1//IT104"));
                    cmd.Parameters.AddWithValue("?UnitPriceCode", IIF_NULL(IT1Loop1, ".//IT1//IT105"));
                    cmd.Parameters.AddWithValue("?ivprixdcli_codecli", IIF_NULL(IT1Loop1, ".//IT1//IT107"));
                    cmd.Parameters.AddWithValue("?ivprod_code", IIF_NULL(IT1Loop1, ".//IT1//IT109"));
                    cmd.Parameters.AddWithValue("?ivprod_desc", IIF_NULL(IT1Loop1, ".//PIDLoop1//PID//PID05"));

                    cmd.Parameters.AddWithValue("?arinvd_idbil", IIF_NULL(IT1Loop1, ".//PIDLoop1//REF[1]//REF02", false));
                    cmd.Parameters.AddWithValue("?cocom_clientpo", IIF_NULL(IT1Loop1, ".//PIDLoop1//REF[2]//REF02", false));
                    cmd.Parameters.AddWithValue("?cocom_ident", IIF_NULL(IT1Loop1, ".//PIDLoop1//REF[3]//REF02", false));
                    cmd.Parameters.AddWithValue("?programId", program810Id);
                    nb++;

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                string xx = ex.ToString();
                Status += xx;
            }
        }

        /**
         * return a xml node with the namespace in the xpath
         */
        public XmlNode Get_Node(XmlNode node, string xpath, bool isBrackets = true)
        {
            xpath = xpath.Replace("/", "/ic:");
            xpath = xpath.Replace("/ic:/ic:", "//ic:");
            if (isBrackets)
                xpath = xpath.Replace("[", "[ic:");

            if (node == null) { return null; }

            return node.SelectSingleNode(xpath, nsmgr);
        }

        /**
         * return the value of a xml node if is not null
         */
        public string IIF_NULL(XmlNode node, string xpath, bool isBrackets = true, string nullValue = "")
        {
            if (Get_Node(node, xpath, isBrackets) == null)
            {
                return nullValue;
            }

            return Get_Node(node, xpath, isBrackets).InnerText;
        }
    }

}
