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
    public class Email856Writer : EDI_RSS.Program_Base
    {
        private StringBuilder HtmlHeader { get; set; }
        private StringBuilder HtmlFooter { get; set; }
        private string Htmldoc { get; set; }
        private string program856Id { get; set; }
        private string ShipmentRef { get; set; }

        public Email856Writer(string Id)
        {
            HtmlHeader = new StringBuilder();
            HtmlFooter = new StringBuilder();
            Htmldoc = File.ReadAllText(@"template856Email.html");
            program856Id = Id;
        }

        public void Build()
        {
            List<IDataRecord> RawDataDetails;

            try
            {
                List<IDataRecord> RawData = GetData(program856Id);

                foreach (IDataRecord Data in RawData)
                {
                    Status += "GetDataDetails: shipmentId: " + Data["shipmentId"].ToString() + " program856Id: " + program856Id + NL;

                    RawDataDetails = GetDataDetails(Data["shipmentId"].ToString(), program856Id);

                    ShipmentRef = Data["popo_ref"].ToString();
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
                SELECT * FROM edi_856v WHERE programId = ?programId
                ", Params);
        }

        public List<IDataRecord> GetDataDetails(string shipmentId, string programId)
        {
            Params.Clear();
            Params.Add("?shipmentId", shipmentId);
            Params.Add("?programId", programId);

            return DB_VIVA.HExecuteSQLQuery(@"
                SELECT COUNT(qtyShipped) AS nb_item_per_qty, edi_856vd.* FROM edi_856vd where shipmentId = ?shipmentId AND programId = ?programId GROUP BY qtyShipped
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

            Htmldoc = Htmldoc.Replace("~#shipmentId#~", Data["popo_ref"].ToString());
            Htmldoc = Htmldoc.Replace("~#shipDate#~", Data["Ship_date"].ToString());
            Htmldoc = Htmldoc.Replace("~#shippedDate#~", Convert.ToDateTime(Data["shipped_date"].ToString()).ToString("yyyy-MM-dd"));

            Htmldoc = Htmldoc.Replace("~#ShipToAddress#~", $"{Data["STname"].ToString()}<br>" +
                $"{Data["STaddr1"].ToString()}<br>" +
                $"{Data["STcity"].ToString()}, {Data["STstate"].ToString()}<br>" +
                $"{Data["STzip"].ToString()}");

            Htmldoc = Htmldoc.Replace("~#extimated_dte#~", Convert.ToDateTime(Data["estimated_delivery_date"].ToString()).ToString("yyyy-MM-dd"));

            StringBuilder items = new StringBuilder();
            foreach (var DataDetail in RawDataDetails)
            {

                items.AppendLine("<tr>");
                    items.AppendLine($"<td>{DataDetail["ivprod_code"]}</td>");
                    items.AppendLine($"<td>{DataDetail["ivprod_desc"]}</td>");
                    items.AppendLine($"<td>{DataDetail["qtyShipped"]}</td>");
                    items.AppendLine($"<td>{DataDetail["nb_item_per_qty"]}X{DataDetail["qtyShipped"]}</td>");
                    items.AppendLine($"<td>{DataDetail["popo_pono"]}</td>");
                items.AppendLine("</tr>");

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
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Credentials = new NetworkCredential("noreply@multi-services.org", "Cuz813911");
            client.EnableSsl = true;

            MailAddress from = new MailAddress("web2@envl.ca", "Ariva EDI (Enveloppes Laurentide)", System.Text.Encoding.UTF8);
            MailAddress to = null;

            if (UseSystem == "live")
            {
                if (IDE_status == "send")
                {
                    to = new MailAddress("emilie@multi-services.org");
                }
            }
            else
            {
                to = new MailAddress("buickremi.cool@hotmail.com");
            }

            MailMessage msg = new MailMessage(from, to);
            msg.Body = Htmldoc.ToString();
            msg.Subject = $"Bon de livraison #{ShipmentRef} (Shipment Id)";
            msg.IsBodyHtml = true;
            msg.Headers.Add("Message-Id",
                         String.Format("<{0}@{1}>",
                         Guid.NewGuid().ToString(),
                        "envl.ca"));

            if (UseSystem != "live")
            {
                msg.Subject = "Test server: " + msg.Subject;
            }

            msg.CC.Add(new MailAddress("kjohnston@multi-services.org"));

            client.Send(msg);

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
