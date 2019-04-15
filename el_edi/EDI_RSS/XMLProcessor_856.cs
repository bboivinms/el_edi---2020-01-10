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
    public partial class XMLProcessor_856
    {
        private XmlNamespaceManager nsmgr;
        private XmlDocument doc;
        private string namespaceURI;

        public XMLProcessor_856(XmlNamespaceManager nsmgr, XmlDocument doc)
        {
            this.nsmgr = nsmgr;
            this.doc = doc;
            namespaceURI = "http://www.rssbus.com";
        }


        public void ProcessOrder(XmlNode XMLNode, string filepath)
        {
            string program856Id = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            try
            {
                MySqlCommand cmd = DB_VIVA.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "INSERT INTO edi_856v (popo_ref, Filename, Ship_date, shipped_date, estimated_delivery_date, shipmentId, packagingCode, popoi_qty, ShipToAddr, programId, Xml856Raw) " +
                                  "VALUES (?popo_ref, ?Filename, ?Ship_date, ?shipped_date, ?estimated_delivery_date, ?shipmentId, ?packagingCode, ?popoi_qty, ?ShipToAddr, ?programId, ?Xml856Raw);";
                
                XmlNodeList xmlShipment = Get_NodeList(XMLNode, "//HLLoop1[HL/HL03 = 'S']");
                for (int i = 0; i < xmlShipment.Count; i++)
                {
                    cmd.Parameters.AddWithValue("?popo_ref", Convert.ToInt64(IIF_NULL(XMLNode, "//BSN02")));                             //Shipment Identification / popo_ref
                    cmd.Parameters.AddWithValue("?Filename", filepath);                                                                  //Filename
                    cmd.Parameters.AddWithValue("?Ship_date", StringToDate(IIF_NULL(XMLNode, "//BSN03"), IIF_NULL(XMLNode, "//BSN04"))); //Date / ship_date //Time / ship_date
                    cmd.Parameters.AddWithValue("?shipped_date", IIF_NULL(XMLNode, "//DTM[DTM01 = '011']//DTM02"));                      //Date shipped  / shipped_date
                    cmd.Parameters.AddWithValue("?estimated_delivery_date", IIF_NULL(XMLNode, "//DTM[DTM01 = '017']//DTM02"));           //Date estimated delivery / estimated_delivery_date

                    cmd.Parameters.AddWithValue("?shipmentId",    IIF_NULL(xmlShipment.Item(i), ".//HL01"));                    //shipmentId
                    cmd.Parameters.AddWithValue("?popoi_qty",     IIF_NULL(xmlShipment.Item(i), ".//TD102"));                   //popoi_qty
                    cmd.Parameters.AddWithValue("?packagingCode", IIF_NULL(xmlShipment.Item(i), ".//TD101"));                   //packagingCode
                    cmd.Parameters.AddWithValue("?ShipToAddr",    getXML(Get_Node(xmlShipment.Item(i), ".//N1Loop1[N1/N101 = 'ST']"))); //xml node N1Loop1 / ShipToAddr

                    cmd.Parameters.AddWithValue("?programId", program856Id);     //programId
                    cmd.Parameters.AddWithValue("?Xml856Raw", XMLNode.InnerXml); //Xml856Raw original

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                
                //items 
                XmlNode items = doc.CreateElement("items", namespaceURI); //create a node items
                XMLNode.AppendChild(items);  //ajouter items node to root xml

                //boucle pour réorganiser les nodes dans le document
                XmlNodeList xmlItems = Get_NodeList(XMLNode, "//HLLoop1[HL/HL03 = 'I']"); //list of items
                for (int i = 0; i < xmlItems.Count; i++)
                {
                    XmlNode item = doc.CreateElement("item", namespaceURI);

                    XmlNode itemNodeRenamed = doc.CreateElement(xmlItems.Item(i).Name + "_" + IIF_NULL(xmlItems.Item(i), ".//HL03").Replace("\r\n", ""), namespaceURI);
                    itemNodeRenamed.InnerXml = xmlItems.Item(i).InnerXml;

                    item.AppendChild(itemNodeRenamed);

                    HLLoop1(XMLNode, item, IIF_NULL(xmlItems.Item(i), ".//HL02"));

                    items.AppendChild(item);
                }

                //boucle pour recupere les infos
                XmlNodeList list = Get_NodeList(items, ".//item");
                for (int i = 0; i < list.Count; i++)
                {
                    cmd.CommandText = "INSERT INTO edi_856vd (shipmentId, popo_pono, popo_dte, popo_ident, popoi_line, ivprix_ref_fourn," +
                              " ivprod_code, ivprod_ident, qtyShipped, unitQtyShippedCode, MeasurementValue, MeasurementCode, SerialNumber, programId)" +
                              " VALUES(?shipmentId, ?popo_pono, ?popo_dte, ?popo_ident, ?popoi_line, ?ivprix_ref_fourn," +
                              " ?ivprod_code, ?ivprod_ident, ?qtyShipped, ?unitQtyShippedCode, ?MeasurementValue, ?MeasurementCode, ?SerialNumber, ?programId)";

                    cmd.Parameters.AddWithValue("?shipmentId", Convert.ToInt32(IIF_NULL(list.Item(i), ".//HLLoop1_S//id")));   //id of shipment / shipmentId

                    XmlNode OrderNode = Get_Node(XMLNode, "//HLLoop1[HL/HL01 = " +    IIF_NULL(list.Item(i), ".//HLLoop1_O//id", true, "0") + "]");

                    //if Purchase Order is in the item node or in the ordernode
                    if (IIF_NULL(list.Item(i), ".//PRF01") != "")
                    {
                        cmd.Parameters.AddWithValue("?popo_pono", IIF_NULL(list.Item(i), ".//PRF01")); //PO_Number / popo_pono
                        cmd.Parameters.AddWithValue("?popo_dte",  IIF_NULL(list.Item(i), ".//PRF04")); //popo_dte
                    }
                    else if (IIF_NULL(OrderNode, ".//PRF01") != "")
                    {
                        cmd.Parameters.AddWithValue("?popo_pono", IIF_NULL(OrderNode, ".//PRF01"));    //PO_Number / popo_pono
                        cmd.Parameters.AddWithValue("?popo_dte",  IIF_NULL(list.Item(i), ".//PRF04")); //popo_dte
                    }
                    else
                    {
                        Status += "Purchase Order not found";
                        cmd.Parameters.AddWithValue("?popo_pono", ""); //PO_Number / popo_pono
                        cmd.Parameters.AddWithValue("?popo_dte", "");  //popo_dte
                    }

                    if (OrderNode != null)
                        cmd.Parameters.AddWithValue("?popo_ident",  IIF_NULL(OrderNode, ".//REF02"));  //popo_ident
                    else
                        cmd.Parameters.AddWithValue("?popo_ident", "");  //popo_ident

                    cmd.Parameters.AddWithValue("?popoi_line",      Convert.ToInt32(IIF_NULL(list.Item(i), ".//LIN01")));       //ID_Item / popoi_line
                    cmd.Parameters.AddWithValue("?ivprod_code",      IIF_NULL(list.Item(i), ".//LIN03"));                        //ProductId_VP / ivprod_code

                    cmd.Parameters.AddWithValue("?ivprix_ref_fourn",   IIF_NULL(list.Item(i), ".//LIN05"));                        //ProductId_BP / ivprix_ref_fourn
                    cmd.Parameters.AddWithValue("?qtyShipped",         IIF_NULL(list.Item(i), ".//SN102"));                        //Number of Units Shipped / qtyShipped
                    cmd.Parameters.AddWithValue("?unitQtyShippedCode", IIF_NULL(list.Item(i), ".//SN103"));                        //code measurement code / unitQtyShippedCode

                    cmd.Parameters.AddWithValue("?MeasurementValue", IIF_NULL(list.Item(i), ".//HLLoop1_I//MEA03"));                       //MeasurementValue
                    cmd.Parameters.AddWithValue("?MeasurementCode",  IIF_NULL(list.Item(i), ".//HLLoop1_I//MEA0401").Replace("\r\n", "")); //MeasurementCode
                    cmd.Parameters.AddWithValue("?SerialNumber",     IIF_NULL(list.Item(i), ".//HLLoop1_I//REF02"));                       //SerialNumber

                    cmd.Parameters.AddWithValue("?programId", program856Id); //ProgramId

                    //select ident of ivprod with the code
                    MySqlCommand cmd2 = DB_VIVA.CreateCommand();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT ident FROM vivams4.ivprod WHERE Code = ?code;";
                    cmd2.Parameters.AddWithValue("?code", IIF_NULL(list.Item(i), ".//LIN03"));
                    object result = cmd2.ExecuteScalar();

                    if(result.ToString() != "")
                    {
                        cmd.Parameters.AddWithValue("?ivprod_ident", result.ToString()); //ivprod_ident
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("?ivprod_ident", null); //ivprod_ident
                    }
                    

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
         * recursive function who append parent node to child node
         */
        public void HLLoop1(XmlNode node, XmlNode itemNode, string parentId)
        {

            XmlNode parentNode = Get_Node(node, "//HLLoop1[HL/HL01 = " + parentId + "]");

            XmlNode parentNodeRenamed = doc.CreateElement(parentNode.Name + "_" + IIF_NULL(parentNode, ".//HL03").Replace("\r\n", ""), namespaceURI);
            XmlNode idNode = doc.CreateElement("id", namespaceURI);
            idNode.InnerText = IIF_NULL(parentNode, ".//HL01");
            parentNodeRenamed.AppendChild(idNode);

            if (parentNodeRenamed != null)
            {
                itemNode.AppendChild(parentNodeRenamed);

                if (IIF_NULL(parentNode, ".//HL02") != "")
                    HLLoop1(node, itemNode, IIF_NULL(parentNode, ".//HL02", true, "0"));
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

        public string getXML(XmlNode node)
        {
            if(node == null)
            {
                return "";
            }

            return node.InnerXml;
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
