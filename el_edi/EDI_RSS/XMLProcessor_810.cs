using MySql.Data.MySqlClient;
using EDI_850.Helpers;
using System;
using System.Data;
using System.Linq;
using EDICommons.Tools;
using EDI_DB.Data;
using static EDI_DB.Data.Base;
using System.Xml;
using System.Collections.Generic;
using System.Globalization;

namespace EDI_RSS
{
    public partial class XMLProcessor_810
    {
        private XmlNamespaceManager nsmgr;
        private Dictionary<string, string> Params = new Dictionary<string, string>();
        private long lastInsertedId;
        private int IDvendor;
        private string error = "";

        public XMLProcessor_810(XmlNamespaceManager nsmgr, int idvendor)
        {
            this.nsmgr = nsmgr;
            IDvendor = idvendor;
        }

        public void ProcessOrder(XmlNode XMLNode, string filepath)
        {
            string program810Id = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            
            XmlNode N1Loop1ST = Get_Node(XMLNode, "//N1Loop1[N1/N101 = 'ST']");
            XmlNode N1Loop1VN = Get_Node(XMLNode, "//N1Loop1[N1/N101 = 'VN']");

            int arinv_inv_mnt = Convert.ToInt32(IIF_NULL(XMLNode, "//TDS//TDS01"));
            decimal totalCost = 0;
            decimal TotalAllCost = 0;
            int amountWithTax;

            try
            {
                Params.Clear();
                Params.Add("?idvendor", IDvendor.ToString());
                Params.Add("?filename", filepath);
                Params.Add("?arinv_invdte", IIF_NULL(XMLNode, "//BIG//BIG01"));
                Params.Add("?arinv_invno", IIF_NULL(XMLNode, "//BIG//BIG02"));
                Params.Add("?arinv_po", IIF_NULL(XMLNode, "//BIG//BIG04"));
                Params.Add("?arinv_idbil", IIF_NULL(XMLNode, "//TX-00403-810//REF//REF02"));
                Params.Add("?STname", IIF_NULL(N1Loop1ST, ".//N102"));
                Params.Add("?STiddel_addr", IIF_NULL(N1Loop1ST, ".//N104"));
                Params.Add("?STaddr1", IIF_NULL(N1Loop1ST, ".//N301"));
                Params.Add("?STaddr2", IIF_NULL(N1Loop1ST, ".//N302"));
                Params.Add("?STcity", IIF_NULL(N1Loop1ST, ".//N401"));
                Params.Add("?STstate", IIF_NULL(N1Loop1ST, ".//N402"));
                Params.Add("?STzip", IIF_NULL(N1Loop1ST, ".//N403"));

                Params.Add("?arinv_inv_mnt", arinv_inv_mnt.ToString());
                Params.Add("?programId", program810Id);
                Params.Add("?Xml810Raw", XMLNode.InnerXml);      //Xml810Raw original

                lastInsertedId = DB_VIVA.HExecuteSQLNonQuery(@"
                    INSERT INTO edi_810v (idvendor, filename, arinv_invdte, arinv_invno, arinv_po, arinv_idbil, STname, STiddel_addr, STaddr1, STaddr2, STcity, STstate, STzip, arinv_inv_mnt, programId, Xml810Raw)
                    VALUE(?idvendor, ?filename, ?arinv_invdte, ?arinv_invno, ?arinv_po, ?arinv_idbil, ?STname, ?STiddel_addr, ?STaddr1, ?STaddr2, ?STcity, ?STstate, ?STzip, ?arinv_inv_mnt, ?programId, ?Xml810Raw)
                    ", Params);

                //loop items
                int nb = 1;
                XmlNode IT1Loop1;
                while ((IT1Loop1 = Get_Node(XMLNode, "//IT1Loop1[" + nb + "]", false)) != null)
                {
                    Params.Clear();
                    Params.Add("?edi_810v_ident", lastInsertedId.ToString());          //edi_810v_ident
                    Params.Add("?popoi_line", IIF_NULL(IT1Loop1, ".//IT1//IT101"));    //popoi_line
                    Params.Add("?popoi_qty_ord", IIF_NULL(IT1Loop1, ".//IT1//IT102")); //popoi_qty_ord
                    Params.Add("?UnitMeasurementCode", IIF_NULL(IT1Loop1, ".//IT1//IT103"));
                    Params.Add("?popoi_cost", IIF_NULL(IT1Loop1, ".//IT1//IT104"));   //cost 
                    Params.Add("?UnitPriceCode", IIF_NULL(IT1Loop1, ".//IT1//IT105"));
                    Params.Add("?ivprixdcli_codecli", IIF_NULL(IT1Loop1, ".//IT1//IT107"));
                    Params.Add("?ivprod_code", IIF_NULL(IT1Loop1, ".//IT1//IT109"));
                    Params.Add("?ivprod_desc", IIF_NULL(IT1Loop1, ".//PIDLoop1//PID//PID05"));
                    Params.Add("?arinvd_idbil", IIF_NULL(IT1Loop1, ".//PIDLoop1//REF[1]//REF02", false));
                    Params.Add("?cocom_clientpo", IIF_NULL(IT1Loop1, ".//PIDLoop1//REF[2]//REF02", false));
                    Params.Add("?cocom_ident", IIF_NULL(IT1Loop1, ".//PIDLoop1//REF[3]//REF02", false));
                    Params.Add("?programId", program810Id);
                    Params.Add("?Xml810ItemRaw", IT1Loop1.InnerXml);      //Xml810ItemRaw

                    string strQty, strCost;
                    if ((strQty = IIF_NULL(IT1Loop1, ".//IT1//IT102")) != "" && (strCost = IIF_NULL(IT1Loop1, ".//IT1//IT104")) != "")
                    {
                        totalCost = Convert.ToInt32(strQty) * Convert.ToDecimal(strCost, CultureInfo.InvariantCulture);
                    }
                    TotalAllCost += totalCost;

                    DB_VIVA.HExecuteSQLNonQuery(@"
                     INSERT INTO edi_810vd (edi_810v_ident, popoi_line, popoi_qty_ord, UnitMeasurementCode, popoi_cost, UnitPriceCode, ivprixdcli_codecli,
                                            ivprod_code, ivprod_desc, arinvd_idbil, cocom_clientpo, cocom_ident, programId, Xml810ItemRaw)
                        VALUE(?edi_810v_ident, ?popoi_line, ?popoi_qty_ord, ?UnitMeasurementCode, ?popoi_cost, ?UnitPriceCode, ?ivprixdcli_codecli,
                              ?ivprod_code, ?ivprod_desc, ?arinvd_idbil, ?cocom_clientpo, ?cocom_ident, ?programId, ?Xml810ItemRaw)
                     ", Params);

                    nb++;
                }

                decimal GstAmount = 0;
                string strGst;
                if ((strGst = IIF_NULL(XMLNode, "//TXI[TXI01 = 'GS']//TXI02")) != "")
                {
                    GstAmount = decimal.Parse(strGst, CultureInfo.InvariantCulture);
                }
                else
                {
                    GstAmount = Math.Round(TotalAllCost * (decimal)0.05, 2);
                    error += "erreur no gst tax found in xml 810 doc" + NL;
                }

                decimal QstAmount = 0;
                string strQst;
                if ((strQst = IIF_NULL(XMLNode, "//TXI[TXI01 = 'SP']//TXI02")) != "")
                {
                    QstAmount = decimal.Parse(strQst, CultureInfo.InvariantCulture);
                }
                else
                {
                    QstAmount = Math.Round(TotalAllCost * (decimal)0.09975, 2);
                    error += "erreur no qst tax found in xml 810 doc" + NL;
                }
                amountWithTax = (int)(Math.Round(TotalAllCost + GstAmount + QstAmount, 2) * 100);

                if (amountWithTax != arinv_inv_mnt)
                {
                    error += "error montant total facture : amountWithTax=" + amountWithTax + "!= arinv_inv_mnt=" + arinv_inv_mnt + NL;
                }

                Params.Clear();
                Params.Add("?arinv_inv_mnt", amountWithTax.ToString());
                Params.Add("?error", error);
                Params.Add("?programId", program810Id);

                DB_VIVA.HExecuteSQLNonQuery(@"
                    UPDATE edi_810v SET arinv_inv_mnt = ?arinv_inv_mnt, error = ?error WHERE programId = ?programId;
                    ", Params);

                Email810Writer email810 = new Email810Writer(program810Id);
                email810.Build();
                email810.Send();
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
