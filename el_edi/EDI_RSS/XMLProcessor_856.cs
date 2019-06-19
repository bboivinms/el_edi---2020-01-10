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

namespace EDI_RSS
{
    public partial class XMLProcessor_856
    {
        private XmlNamespaceManager nsmgr;
        private Dictionary<string, string> Params = new Dictionary<string, string>();
        private XmlDocument doc;
        private string namespaceURI;
        private int IDvendor;

        public XMLProcessor_856(XmlNamespaceManager nsmgr, XmlDocument doc, int idvendor)
        {
            this.nsmgr = nsmgr;
            this.doc = doc;
            namespaceURI = "http://www.rssbus.com";
            IDvendor = idvendor;
        }


        public void ProcessOrder(XmlNode XMLNode, string filepath)
        {
            string program856Id = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            try
            {
                XmlNode N1Loop1ST = null;
                XmlNodeList xmlShipment = Get_NodeList(XMLNode, "//HLLoop1[HL/HL03 = 'S']");
                for (int i = 0; i < xmlShipment.Count; i++)
                {
                    N1Loop1ST = Get_Node(xmlShipment.Item(i), ".//N1Loop1[N1/N101 = 'ST']"); //node address ship to xml

                    Params.Clear();
                    Params.Add("?idvendor", IDvendor.ToString());
                    Params.Add("?popo_ref", Convert.ToInt64(IIF_NULL(XMLNode, "//BSN02")).ToString());                  //Shipment Identification / popo_ref
                    Params.Add("?Filename", filepath);                                                                  //Filename
                    Params.Add("?Ship_date", StringToDate(IIF_NULL(XMLNode, "//BSN03"), IIF_NULL(XMLNode, "//BSN04"))); //Date / ship_date //Time / ship_date

                    string shipped_date;
                    if (IIF_NULL(XMLNode, "//DTM[DTM01 = '007']//DTM02") != "")
                    {
                        shipped_date = IIF_NULL(XMLNode, "//DTM[DTM01 = '007']//DTM02");
                    }
                    else if(IIF_NULL(XMLNode, "//DTM[DTM01 = '011']//DTM02") != "")
                    {
                        shipped_date = IIF_NULL(XMLNode, "//DTM[DTM01 = '011']//DTM02");
                    }
                    else
                    {
                        shipped_date = null;
                    }

                    Params.Add("?shipped_date", shipped_date);     //Date shipped  / Effective or Shipped
                    Params.Add("?estimated_delivery_date", IIF_NULL(XMLNode, "//DTM[DTM01 = '017']//DTM02"));           //Date estimated delivery / estimated_delivery_date
                    Params.Add("?shipmentId",    IIF_NULL(xmlShipment.Item(i), ".//HL01"));                             //shipmentId
                    Params.Add("?popoi_qty",     IIF_NULL(xmlShipment.Item(i), ".//TD102"));                            //popoi_qty
                    Params.Add("?packagingCode", IIF_NULL(xmlShipment.Item(i), ".//TD101"));                            //packagingCode

                    Params.Add("?STname", IIF_NULL(N1Loop1ST, ".//N102"));          //addr name
                    Params.Add("?STaddr1", IIF_NULL(N1Loop1ST, ".//N301"));         //address 1
                    Params.Add("?STaddr2", IIF_NULL(N1Loop1ST, ".//N302"));         //address 2
                    Params.Add("?STcity", IIF_NULL(N1Loop1ST, ".//N401"));          //addr city
                    Params.Add("?STstate", IIF_NULL(N1Loop1ST, ".//N402"));         //addr state
                    Params.Add("?STzip", IIF_NULL(N1Loop1ST, ".//N403"));           //addr zip code

                    Params.Add("?ShipToAddr",    getXML(N1Loop1ST));                //xml node N1Loop1 / ShipToAddr
                    Params.Add("?programId", program856Id);                         //programId
                    Params.Add("?Xml856Raw", XMLNode.InnerXml);                     //Xml856Raw original

                    DB_VIVA.HExecuteSQLNonQuery("INSERT INTO edi_856v (idvendor, popo_ref, Filename, Ship_date, shipped_date, estimated_delivery_date, shipmentId, packagingCode, popoi_qty," +
                                                      " STname, STaddr1, STaddr2, STcity, STstate, STzip, ShipToAddr, programId, Xml856Raw) " +
                                                      "VALUES (?idvendor, ?popo_ref, ?Filename, ?Ship_date, ?shipped_date, ?estimated_delivery_date, ?shipmentId, ?packagingCode, ?popoi_qty," +
                                                      " ?STname, ?STaddr1, ?STaddr2, ?STcity, ?STstate, ?STzip, ?ShipToAddr, ?programId, ?Xml856Raw);", Params);
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
                    Params.Clear();
                    Params.Add("?shipmentId", Convert.ToInt32(IIF_NULL(list.Item(i), ".//HLLoop1_S//id")).ToString());   //id of shipment / shipmentId

                    XmlNode OrderNode = Get_Node(XMLNode, "//HLLoop1[HL/HL01 = " +    IIF_NULL(list.Item(i), ".//HLLoop1_O//id", true, "0") + "]");

                    //if Purchase Order is in the item node or in the ordernode
                    if (IIF_NULL(list.Item(i), ".//PRF01") != "")
                    {
                        Params.Add("?popo_pono", IIF_NULL(list.Item(i), ".//PRF01")); //PO_Number / popo_pono
                        Params.Add("?popo_dte",  IIF_NULL(list.Item(i), ".//PRF04")); //popo_dte
                    }
                    else if (IIF_NULL(OrderNode, ".//PRF01") != "")
                    {
                        Params.Add("?popo_pono", IIF_NULL(OrderNode, ".//PRF01"));    //PO_Number / popo_pono
                        Params.Add("?popo_dte",  IIF_NULL(list.Item(i), ".//PRF04")); //popo_dte
                    }
                    else
                    {
                        Status += "Purchase Order not found";
                        Params.Add("?popo_pono", ""); //PO_Number / popo_pono
                        Params.Add("?popo_dte", "");  //popo_dte
                    }

                    if (OrderNode != null)
                        Params.Add("?popo_ident",  IIF_NULL(OrderNode, ".//REF02"));  //popo_ident
                    else
                        Params.Add("?popo_ident", "");  //popo_ident

                    Params.Add("?popoi_line",         Convert.ToInt32(IIF_NULL(list.Item(i), ".//LIN01")).ToString());      //ID_Item / popoi_line
                    Params.Add("?ivprix_ref_fourn",   IIF_NULL(list.Item(i), ".//LIN05"));                                  //ProductId_BP / ivprix_ref_fourn
                    Params.Add("?ivprod_code", IIF_NULL(list.Item(i), ".//LIN03"));                                         //ProductId_VP / ivprod_code

                    //select ident and desc of ivprod with the code
                    Params.Add("?code", IIF_NULL(list.Item(i), ".//LIN03"));
                    List<IDataRecord> result = DB_VIVA.HExecuteSQLQuery("SELECT ivprod.ident AS ivprod_ident, ivprod.DESC AS ivprod_desc FROM ivprod WHERE Code = ?code;", Params);
                   
                    if(result.Count > 0)
                    {
                        Params.Add("?ivprod_desc", result[0]["ivprod_desc"].ToString());    //ivprod_desc
                        Params.Add("?ivprod_ident", result[0]["ivprod_ident"].ToString());  //ivprod_ident
                    }
                    else
                    {
                        Params.Add("?ivprod_desc", null);  //ivprod_desc
                        Params.Add("?ivprod_ident", null); //ivprod_ident
                    }

                    Params.Add("?qtyShipped", IIF_NULL(list.Item(i), ".//SN102"));                                          //Number of Units Shipped / qtyShipped
                    Params.Add("?unitQtyShippedCode", IIF_NULL(list.Item(i), ".//SN103"));                                  //code measurement code / unitQtyShippedCode
                    Params.Add("?MeasurementValue", IIF_NULL(list.Item(i), ".//HLLoop1_I//MEA03"));                         //MeasurementValue
                    Params.Add("?MeasurementCode", IIF_NULL(list.Item(i), ".//HLLoop1_I//MEA0401").Replace("\r\n", ""));    //MeasurementCode
                    Params.Add("?SerialNumber", IIF_NULL(list.Item(i), ".//HLLoop1_I//REF02"));                             //SerialNumber
                    Params.Add("?programId", program856Id);                                                                 //ProgramId
                    Params.Add("?Xml856ItemRaw", list.Item(i).InnerXml);                                                    //Xml856ItemRaw 

                    DB_VIVA.HExecuteSQLNonQuery("INSERT INTO edi_856vd (shipmentId, popo_pono, popo_dte, popo_ident, popoi_line, ivprix_ref_fourn," +
                                                  " ivprod_code, ivprod_desc, ivprod_ident, qtyShipped, unitQtyShippedCode, MeasurementValue, MeasurementCode, SerialNumber, programId, Xml856ItemRaw)" +
                                                  " VALUES(?shipmentId, ?popo_pono, ?popo_dte, ?popo_ident, ?popoi_line, ?ivprix_ref_fourn," +
                                                  " ?ivprod_code, ?ivprod_desc, ?ivprod_ident, ?qtyShipped, ?unitQtyShippedCode, ?MeasurementValue, ?MeasurementCode, ?SerialNumber, ?programId, ?Xml856ItemRaw)", Params);
                }

                //Email856Writer email856 = new Email856Writer(program856Id);
                //email856.Build();
                //email856.Send();
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

            if(parentNode != null)
            {
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
            else
            {
                Status += "ParentId is not found. line 169";
                //erreur avec la hierarchie shipment -> order -> item
                //un item possède un parent id inconnue (non utiliseé par un order ou shipment)
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
         * return a string date in the format : yyyy-MM-dd or with time : yyyy-MM-dd hh:mm:ss or hh:mm
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
                string outputTime = "";

                string hour = time.Substring(0, 2);
                string min = time.Substring(2, 2);

                if(time.Length == 6) // si il y a des secondes
                {
                    string sec = time.Substring(4, 2);

                    outputTime = hour + ":" + min + ":" + sec;
                }
                else
                {
                    outputTime = hour + ":" + min;
                }

                return outputDate + " " + outputTime;
            }

            return outputDate;
        }
    }

}
