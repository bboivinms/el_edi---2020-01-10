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
    public partial class XMLProcessor_855
    {
        private XmlNamespaceManager nsmgr;
        private XmlDocument doc;
        private int IDvendor;

        private Dictionary<string, string> Params = new Dictionary<string, string>();
        private string error = "";

        public XMLProcessor_855(XmlNamespaceManager nsmgr, XmlDocument doc, int idvendor)
        {
            this.nsmgr = nsmgr;
            this.doc = doc;
            IDvendor = idvendor;
        }


        public void ProcessOrder(XmlNode XMLNode, string filepath)
        {
            string program855Id = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();

            try
            {
                MySqlCommand cmd = DB_VIVA.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO edi_855v (idvendor, popo_ident, filename, popo_pono, po_dte, popo_del_name, iddel_addr, Xml855Raw, error, programId)" +
                                  " VALUES(?idvendor, ?popo_ident, ?Filename, ?popo_pono, ?po_dte, ?popo_del_name, ?iddel_addr, ?Xml855Raw, ?error, ?programId);";

                string poNumber = IIF_NULL(XMLNode, "//BAK03"); //popo_pono
                XmlNode N1Loop1 = Get_Node(XMLNode, "//N1Loop1[N1/N101 = 'ST']");

                //select ident of popo with the pono
                Params.Clear();
                Params.Add("?poNumber", poNumber);
                List<IDataRecord> result = DB_VIVA.HExecuteSQLQuery("SELECT ident, DEL_NAME FROM popo where popo.PONO = ?poNumber", Params);

                cmd.Parameters.AddWithValue("?idvendor", IDvendor);

                //if their purchase order is found in our popo table
                if (result.Count != 0)
                {
                    cmd.Parameters.AddWithValue("?popo_ident", Convert.ToInt32(result[0]["ident"].ToString())); //popo_ident

                    //if is our order we have pickup
                    if(result[0]["DEL_NAME"].ToString() == "PICK UP")
                    {
                        //if their response have pickup
                        if(IIF_NULL(N1Loop1, ".//N102").Contains("CPU"))
                        {
                            cmd.Parameters.AddWithValue("?popo_del_name", "PICK UP");  //popo_del_name / good
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("?popo_del_name", IIF_NULL(N1Loop1, ".//N102"));  //popo_del_name / error supposed to be pickup
                            error += "Error : supposed to have CPU. del_name : " + IIF_NULL(N1Loop1, ".//N102") + "\n";
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("?popo_del_name", IIF_NULL(N1Loop1, ".//N102"));  //popo_del_name / ship to address
                    }    
                }
                else
                {
                    cmd.Parameters.AddWithValue("?popo_ident", null);
                    error += "Error : The Purchase number "+ poNumber + "is not found in popo table\n";
                }

                cmd.Parameters.AddWithValue("?Filename",     filepath);
                cmd.Parameters.AddWithValue("?popo_pono",    poNumber);                             //popo_pono
                cmd.Parameters.AddWithValue("?po_dte", StringToDate(IIF_NULL(XMLNode, "//BAK04"))); //po_dte
                cmd.Parameters.AddWithValue("?iddel_addr",     IIF_NULL(N1Loop1, ".//N104"));       //iddel_addr
                cmd.Parameters.AddWithValue("?Xml855Raw", XMLNode.InnerXml);                        //Xml855Raw
                cmd.Parameters.AddWithValue("?error", error);                                       //error dans xml
                cmd.Parameters.AddWithValue("?programId", program855Id);                            //programId

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                error = "";

                //Purchased order loop 
                XmlNodeList PO1Loop1 = Get_NodeList(XMLNode, "//PO1Loop1");
                for (int i = 0; i < PO1Loop1.Count; i++)
                {
                    //items 
                    XmlNodeList xmlItems = Get_NodeList(PO1Loop1.Item(i), "//ACKLoop1");
                    for (int j = 0; j < xmlItems.Count; j++)
                    {
                        Params.Clear();
                        Params.Add("?ident", result[0]["ident"].ToString());
                        List<IDataRecord> popoiData = DB_VIVA.HExecuteSQLQuery(@"SELECT ivprix.REF_FOURN, popoi.COST, popoi.QTY_ORD, ivprod.CODE, ivprod.desc AS ivprod_desc, popo.EXPE_DTE FROM popoi
                                                                                inner join popo on popo.ident = popoi.IDPO
                                                                                inner join ivprix on ivprix.IDVENDOR = popo.IDVENDOR and ivprix.IDPRODUIT = popoi.IDPROD 
                                                                                inner join ivprod on popoi.IDPROD = ivprod.ident 
                                                                                Where popoi.idpo = ?ident order by ivprix.ident desc limit 1", Params);

                        string ivprod_desc = popoiData[0]["ivprod_desc"].ToString();
                        string qty_ord = IIF_NULL(PO1Loop1.Item(i), ".//PO102"); //quantity ordered / popoi_qty_ord

                        //verify if we have the same qty_ord
                        if (popoiData[0]["QTY_ORD"].ToString() != qty_ord)
                        {
                            error += "Error : The qty " + qty_ord + " do not correspond with our popoi.QTY_ORD " + popoiData[0]["QTY_ORD"].ToString() + "\n";
                        }

                        string cost = IIF_NULL(PO1Loop1.Item(i), ".//PO104"); //unit price / popoi_cost

                        //verify if unite price is not mille
                        if (IIF_NULL(PO1Loop1.Item(i), ".//PO105") != "TP")
                        {
                            cost = (decimal.Parse(IIF_NULL(PO1Loop1.Item(i), ".//PO104"), CultureInfo.InvariantCulture) * 1000).ToString("N4");
                        }

                        //verify if we have the same cost
                        if (popoiData[0]["cost"].ToString() != cost)
                        {
                            error += "Error : The cost per thousand : " + cost + " do not correspond with us popo.cost : " + popoiData[0]["cost"].ToString() + "\n";
                        }

                        //verify if we have the same ref_fourn
                        if (popoiData[0]["REF_FOURN"].ToString() != IIF_NULL(PO1Loop1.Item(i), ".//PO107"))
                        {
                            error += "Error : The ref_fourn provide : " + IIF_NULL(PO1Loop1.Item(i), ".//PO107") + " do not correspond with us ref_fourn : " + popoiData[0]["REF_FOURN"].ToString() + "\n";
                        }

                        //verify if we have the same code
                        if (popoiData[0]["CODE"].ToString() != IIF_NULL(PO1Loop1.Item(i), ".//PO109"))
                        {
                            error += "Error : The code of product provide : " + IIF_NULL(PO1Loop1.Item(i), ".//PO109") + " do not correspond with us code product : " + popoiData[0]["CODE"].ToString() + "\n";
                        }

                        //verify if we have the same EXPE_DTE
                        if (popoiData[0]["EXPE_DTE"].ToString().Substring(0, 10) != StringToDate(IIF_NULL(xmlItems.Item(j), ".//ACK05")))
                        {
                            error += "Error : The Estimated Delivery date : " + StringToDate(IIF_NULL(xmlItems.Item(j), ".//ACK05")) + " do not correspond with us EXPE_DTE : " + popoiData[0]["EXPE_DTE"].ToString().Substring(0, 10) + "\n";
                        }
                        
                        cmd.CommandText = "INSERT INTO edi_855vd (popoi_line, popoi_qty_tot, popoi_unit, popoi_cost, popoi_unite, " +
                                          "ivprix_ref_fourn, ivprod_code, ivprod_desc, popo_pono, popoi_idpo, statusCode, popoi_qty_ord, popoi_item_unit, popo_expe_dte, programId, error, Xml855ItemRaw) " +
                                          "VALUES(?popoi_line, ?popoi_qty_ord, ?popoi_unit, ?popoi_cost, ?popoi_unite, ?ivprix_ref_fourn, ?ivprod_code, ?ivprod_desc, " +
                                          "?popo_pono, ?popoi_idpo, ?statusCode, ?popoi_qty_ord, ?popoi_item_unit, ?popo_expe_dte, ?programId, ?error, ?Xml855ItemRaw);";

                        cmd.Parameters.AddWithValue("?popoi_line", IIF_NULL(PO1Loop1.Item(i), ".//PO101"));                     //AssignedIdentification / popoi_line
                        cmd.Parameters.AddWithValue("?popoi_qty_tot", IIF_NULL(PO1Loop1.Item(i), ".//PO102"));                  //QuantityOrdered / popoi_qty_tot
                        cmd.Parameters.AddWithValue("?popoi_unit", "TP");                                                       //UnitCode / popoi_unit fixed : TP
                        cmd.Parameters.AddWithValue("?popoi_cost", cost);                                                       //UnitPrice / decimal / popoi_cost
                        cmd.Parameters.AddWithValue("?popoi_unite", IIF_NULL(PO1Loop1.Item(i), ".//PO105"));                    //(unite): each / popoi_unite 
                        cmd.Parameters.AddWithValue("?ivprix_ref_fourn", IIF_NULL(PO1Loop1.Item(i), ".//PO107"));               //VendorPartNumber / ivprix_ref_fourn
                        cmd.Parameters.AddWithValue("?ivprod_code", IIF_NULL(PO1Loop1.Item(i), ".//PO109"));                    //BuyerPartNumber / ivprod_code
                        cmd.Parameters.AddWithValue("?ivprod_desc", ivprod_desc);                                               //BuyerPartNumber / ivprod_code
                        cmd.Parameters.AddWithValue("?popo_pono",   IIF_NULL(PO1Loop1.Item(i), ".//REF[REF01 = 'PO']//REF02")); // Purchase Order Number / popo_pono

                        if (result[0]["ident"].ToString() != "")
                            cmd.Parameters.AddWithValue("?popoi_idpo",  Convert.ToInt32(result[0]["ident"].ToString()));        // Vendor Order Number / popoi_idpo = popo_ident
                        else
                            cmd.Parameters.AddWithValue("?popoi_idpo",  null);

                        //ACK loop
                        cmd.Parameters.AddWithValue("?statusCode",      IIF_NULL(xmlItems.Item(j), ".//ACK01"));               //Status code / Item Accepted
                        cmd.Parameters.AddWithValue("?popoi_qty_ord",   IIF_NULL(xmlItems.Item(j), ".//ACK02"));               //Quantity / popoi_qty_ord
                        cmd.Parameters.AddWithValue("?popoi_item_unit", IIF_NULL(xmlItems.Item(j), ".//ACK03"));               //UnitCode / popoi_item_unit

                        cmd.Parameters.AddWithValue("?popo_expe_dte",   StringToDate(IIF_NULL(xmlItems.Item(j), ".//ACK05"))); //EstimatedDelivery / popo_expe_dte 

                        cmd.Parameters.AddWithValue("?programId",       program855Id);                                         //programId
                        cmd.Parameters.AddWithValue("?error",           error);
                        cmd.Parameters.AddWithValue("?Xml855ItemRaw",   PO1Loop1.Item(i).InnerXml);                             //les noeud xml pour un item

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }

                Email855Writer email855 = new Email855Writer(program855Id);
                email855.Build();
                email855.Send();
            }
            catch (Exception ex)
            {
                string xx = ex.ToString();
                Status += xx;
            }
        }

       
        /**
         * return a xml list node with the namespace in the xpath
         */
        public XmlNodeList Get_NodeList(XmlNode node, string xpath, bool isBrackets = true)
        {
            xpath = xpath.Replace("/", "/ic:");
            xpath = xpath.Replace("/ic:/ic:", "//ic:");

            if (isBrackets)
                xpath = xpath.Replace("[", "[ic:");

            if (node == null) { return null; }

            return node.SelectNodes(xpath, nsmgr);
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

        /**
        * return a string date in the format : yyyy-MM-dd or with time : yyyy-MM-dd hh:mm:ss
        */
        public static string StringToDate(string date, string time = null)
        {
            if (date == "")
            {
                return "No date to convert";
            }

            string year = date.Substring(0, 4);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);

            string outputDate = year + "-" + month + "-" + day;

            if (time != null)
            {
                string hour = time.Substring(0, 2);
                string min = time.Substring(2, 2);
                string sec = time.Substring(4, 2);

                string outputTime = hour + ":" + min + ":" + sec;

                return outputDate + " " + outputTime;
            }

            return outputDate;
        }
    }

}
