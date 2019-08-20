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
    public class Email810Writer : EDI_RSS.Program_Base
    {
        private StringBuilder HtmlHeader { get; set; }
        private StringBuilder HtmlFooter { get; set; }
        private string Htmldoc { get; set; }
        private string program810Id { get; set; }
        private string purchaseOrder { get; set; }

        public Email810Writer(string Id)
        {
            HtmlHeader = new StringBuilder();
            HtmlFooter = new StringBuilder();
            Htmldoc = EDI_RSS.Resource_EDI_RSS.template810Email;
            program810Id = Id;
        }

        public void Build()
        {
            List<IDataRecord> RawDataDetails;

            try
            {
                List<IDataRecord> RawData = GetData(program810Id);

                foreach (IDataRecord Data in RawData)
                {
                    Status += "GetDataDetails: " + program810Id + NL;
                    RawDataDetails = GetDataDetails(program810Id);

                    purchaseOrder = Data["arinv_po"].ToString();
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
                SELECT * FROM edi_810v WHERE programId = ?programId
                ", Params);
        }

        public List<IDataRecord> GetDataDetails(string programId)
        {
            Params.Clear();
            Params.Add("?programId", programId);

            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT * FROM edi_810vd WHERE programId = ?programId
                ", Params);
        }

        public void BuildHtml(IDataRecord Data, List<IDataRecord> RawDataDetails)
        {
            Params.Clear();
            Params.Add("?idvendor", Data["idvendor"].ToString());

            List<IDataRecord> result = DB_VIVA.HExecuteSQLQuery(@"
                        SELECT apsupp.NAME AS apsupp_name, apsupp.ADDR1 AS apsupp_addr1, apsupp.CITY AS apsupp_city, apsupp.STATE AS apsupp_state, apsupp.ZIP AS apsupp_zip
                        FROM apsupp
                        WHERE ident = ?idvendor
                        ", Params);

            if (result.Count > 0)
            {
                Htmldoc = Htmldoc.Replace("~#vendorAddress#~", $"<b>{result[0]["apsupp_name"].ToString()}</b><br>" +
                    $"{result[0]["apsupp_addr1"].ToString()}<br>" +
                    $"{result[0]["apsupp_city"].ToString()},  {result[0]["apsupp_state"].ToString()}<br>" +
                    $"{result[0]["apsupp_zip"].ToString()}");
            }

            Htmldoc = Htmldoc.Replace("~#po#~", Data["arinv_po"].ToString());

            Htmldoc = Htmldoc.Replace("~#invoiceNo#~", Data["arinv_invno"].ToString());

            Htmldoc = Htmldoc.Replace("~#invoiceDate#~",  Convert.ToDateTime(Data["arinv_invdte"].ToString()).ToString("yyyy-MM-dd"));

            Htmldoc = Htmldoc.Replace("~#ShipToAddress#~", $"{Data["STname"].ToString()}<br>" +
                $"{Data["STaddr1"].ToString()}<br>" +
                $"{Data["STcity"].ToString()}, {Data["STstate"].ToString()}<br>" +
                $"{Data["STzip"].ToString()}");

            StringBuilder items = new StringBuilder();
            int qty;
            decimal cost;
            decimal amount;
            decimal totalAmount = 0;
            foreach (var DataDetail in RawDataDetails)
            {

                items.AppendLine("<tr>");
                    items.AppendLine($"<td>{DataDetail["ivprod_code"]}</td>");
                    items.AppendLine($"<td>{DataDetail["popoi_qty_ord"]}</td>");
                    items.AppendLine($"<td>{DataDetail["UnitMeasurementCode"]}</td>");
                    items.AppendLine($"<td>{DataDetail["ivprod_desc"]}</td>");
                    items.AppendLine($"<td style='text-align: right;'>{DataDetail["popoi_cost"]}</td>");

                    qty =  Convert.ToInt32(DataDetail["popoi_qty_ord"]);
                    cost = Convert.ToDecimal(DataDetail["popoi_cost"], CultureInfo.InvariantCulture);
                    amount = qty * cost;

                    items.AppendLine($"<td style='text-align: right;'>{Math.Round(amount, 2)}</td>");     
                items.AppendLine("</tr>");

                totalAmount += amount;
            }

            Htmldoc = Htmldoc.Replace("~#details#~", items.ToString());

            Htmldoc = Htmldoc.Replace("~#timestamp#~", DateTime.Now.ToString());

            Htmldoc = Htmldoc.Replace("~#before_tax#~", Math.Round(totalAmount, 2).ToString());

            decimal gst = Math.Round((totalAmount * (decimal)0.05), 2);
            Htmldoc = Htmldoc.Replace("~#GST#~", gst.ToString());

            decimal pst = Math.Round(totalAmount * (decimal)0.09975, 2);
            Htmldoc = Htmldoc.Replace("~#PST#~", pst.ToString());

            Htmldoc = Htmldoc.Replace("~#HST#~", "");
            Htmldoc = Htmldoc.Replace("~#amountpaid#~", "");
            Htmldoc = Htmldoc.Replace("~#total#~", (Convert.ToDecimal(Data["arinv_inv_mnt"].ToString()) / 100).ToString());
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
                msg.To.Add(new MailAddress("payable@multi-services.org")); 
            }

            msg.Body = Htmldoc.ToString();
            msg.Subject = $"Invoice #{purchaseOrder} (PO)";

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
