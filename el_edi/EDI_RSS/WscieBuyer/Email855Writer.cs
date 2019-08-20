using EDI_DB.Data;
using EDICommons.Tools;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using static EDI_DB.Data.Base;

namespace EDI_RSS
{
    public class Email855Writer : EDI_RSS.Program_Base
    {
        private StringBuilder HtmlHeader { get; set; }
        private StringBuilder HtmlFooter { get; set; }
        private string Htmldoc { get; set; }
        private string program855Id { get; set; }
        private string purchaseOrder { get; set; }

        public Email855Writer(string Id)
        {
            HtmlHeader = new StringBuilder();
            HtmlFooter = new StringBuilder();
            Htmldoc = EDI_RSS.Resource_EDI_RSS.template855Email;
            program855Id = Id;
        }

        public void Build()
        {
            List<IDataRecord> RawDataDetails;

            try
            {
                List<IDataRecord> RawData = GetData(program855Id);

                foreach (IDataRecord Data in RawData)
                {
                    Status += "GetDataDetails: " + program855Id + NL;
                    RawDataDetails = GetDataDetails(program855Id);

                    purchaseOrder = Data["popo_pono"].ToString();
                    BuildHtml(Data, RawDataDetails);

                    //SaveToFile(@"C:\TMP\testEmail.html");
                }

            }
            catch (System.Exception e)
            {
                Error += "Error caught: " + e.ToString();
                LogWriter.WriteMessage(LogEventSource, $"Error caught: {e.Message}");
            }

        }

        public List<IDataRecord> GetData(string programId)
        {
            Params.Clear();
            Params.Add("?programId", programId);

            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT * FROM edi_855v WHERE programId = ?programId
                ", Params);
        }

        public List<IDataRecord> GetDataDetails(string programId)
        {
            Params.Clear();
            Params.Add("?programId", programId);

            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT * FROM edi_855vd where programId = ?programId
                ", Params);
        }

        public void BuildHtml(IDataRecord Data, List<IDataRecord> RawDataDetails)
        {
            Params.Clear();
            Params.Add("?popo_ident", Data["popo_ident"].ToString());

            List<IDataRecord> result = DB_VIVA.HExecuteSQLQuery(@"
                         SELECT popo.po_dte AS popo_po_dte, popo.REQU_DTE AS popo_requ_dte, popo.expe_dte AS popo_expe_dte,
                         apsupp.NAME AS apsupp_name, apsupp.ADDR1 AS apsupp_addr1, apsupp.ADDR2 AS apsupp_addr2,
                         apsupp.CITY AS apsupp_city, apsupp.STATE AS apsupp_state, apsupp.ZIP AS apsupp_zip 
                         FROM popo 
                         INNER JOIN apsupp ON apsupp.ident = popo.IDVENDOR
                         WHERE popo.ident = ?popo_ident
                        ", Params);

            Htmldoc = Htmldoc.Replace("~#popo_pono#~", Data["popo_pono"].ToString());
            Htmldoc = Htmldoc.Replace("~#popo_clientpo#~", Data["popo_clientpo"].ToString());

            if (result.Count > 0)
            {
                Htmldoc = Htmldoc.Replace("~#vendorAddress#~", $"<b>{result[0]["apsupp_name"].ToString()}</b><br>" +
                    $"{result[0]["apsupp_addr1"].ToString()}<br>" +
                    $"{result[0]["apsupp_city"].ToString()},  {result[0]["apsupp_state"].ToString()}<br>" +
                    $"{result[0]["apsupp_zip"].ToString()}");

                Htmldoc = Htmldoc.Replace("~#orderDate#~", Convert.ToDateTime(result[0]["popo_po_dte"].ToString()).ToString("yyyy-MM-dd"));

                Htmldoc = Htmldoc.Replace("~#requiredDate#~", Convert.ToDateTime(result[0]["popo_requ_dte"].ToString()).ToString("yyyy-MM-dd"));
                Htmldoc = Htmldoc.Replace("~#expe_dte#~", Convert.ToDateTime(result[0]["popo_expe_dte"].ToString()).ToString("yyyy-MM-dd"));
            }

            Htmldoc = Htmldoc.Replace("~#ShipToAddress#~", Data["popo_del_name"].ToString());

            StringBuilder items = new StringBuilder();
            int qty;
            decimal cost;
            decimal amount;
            decimal totalAmount = 0;
            foreach (var DataDetail in RawDataDetails)
            {

                items.AppendLine("<tr>");
                    items.AppendLine($"<td>{DataDetail["ivprod_code"]}</td>");
                    items.AppendLine($"<td>{DataDetail["ivprod_desc"]}</td>");
                    items.AppendLine($"<td>{DataDetail["popoi_qty_ord"]}</td>");
                    items.AppendLine($"<td style='text-align: center;'>{Convert.ToDateTime(DataDetail["popo_expe_dte"].ToString()).ToString("yyyy-MM-dd")}</td>");

                    qty =  Convert.ToInt32(DataDetail["popoi_qty_ord"]);
                    cost = Convert.ToDecimal(DataDetail["popoi_cost"]);
                    qty /= 1000;
                    amount = qty * cost;

                    items.AppendLine($"<td style='text-align: right;'>{Math.Round(amount, 2)}</td>");     
                items.AppendLine("</tr>");

                totalAmount += amount;
            }

            Htmldoc = Htmldoc.Replace("~#details#~", items.ToString());

            Htmldoc = Htmldoc.Replace("~#timestamp#~", DateTime.Now.ToString());
        }

        public void Send()
        {
            SendInternalEmail();
        }

        private void SendInternalEmail()
        {
            
            GMail msg = new GMail("EDI");

            if (UseSystem == "live" && IDE_status == "send")
            {
                msg.To.Add(new MailAddress("emilie@multi-services.org"));
            }

            msg.Body = Htmldoc.ToString();
            msg.Subject = $"Confirmation commande #{purchaseOrder} (PO)";

            msg.Send();
            
            // KJ: 2018-11-05: Add a 1 second delay after sending an email, 
            //                 in order to prevent the email from being considered spam
            System.Threading.Thread.Sleep(1000);
            
        }

        public void SaveToFile(string path)
        {
            File.WriteAllText(path, Htmldoc.ToString());
        }
    }
}
