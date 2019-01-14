using EDI_850.Properties;
using EDI_850.Schema;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using static EDI_DB.Data.Base;

namespace EDI_850.Helpers
{
    public class EmailBuilder
    {
        private Schema.root Root { get; set; }
        private StringBuilder HtmlHeader { get; set; }
        private StringBuilder HtmlFooter { get; set; }
        private StringBuilder OrderHeader { get; set; }
        public StringBuilder CustomerEmail { get; set; }
        public StringBuilder InternalEmail { get; set; }
        public StringBuilder OrderTable { get; set; }

        public string InternalEmailBody { get; set; }

        public EmailBuilder(Schema.root r)
        {
            Root = r;
            HtmlHeader = new StringBuilder();
            HtmlFooter = new StringBuilder();
            OrderHeader = new StringBuilder();
            CustomerEmail = new StringBuilder();
            InternalEmail = new StringBuilder();
            OrderTable = new StringBuilder();
        }

        public void Build()
        {
            Resources.Culture = System.Globalization.CultureInfo.GetCultureInfo("fr");

            BuildHtmlHeader();

            BuildHtmlFooter();

            BuildOrderHeader();

            BuildOrderTable();

            BuildMessages();

        }

        private void BuildHtmlFooter()
        {
            HtmlFooter.AppendLine("</BODY>");
            HtmlFooter.AppendLine("</HTML>");
        }

        private void BuildHtmlHeader()
        {
            HtmlHeader.AppendLine("<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>");
            HtmlHeader.AppendLine("<HTML xmlns='http://www.w3.org/1999/xhtml'>");
            HtmlHeader.AppendLine("<HEAD>");
            HtmlHeader.AppendLine("<META http-equiv='Content-Type' content='text/html; charset=UTF-8' />");
            HtmlHeader.AppendLine("<title>Validation email</title>");
            HtmlHeader.AppendLine("<META name='viewport' content='width=device-width, initial-scale=1.0'/>");
            HtmlHeader.AppendLine("</HEAD>");
            HtmlHeader.AppendLine("<BODY>");
        }

        private void BuildOrderHeader()
        {
            OrderHeader.AppendLine($"<H1 style='font-size:large'>{Resources.EmailHeader} {Root.Order.Number}</H1><BR>");
            OrderHeader.AppendLine($"<H1 style='font-size:large'>{Resources.ReqShipDate}: {Root.Order.ActualShipDate.ToString("dd MMM yyyy", new CultureInfo("fr-CA"))}</H1><BR>");

            if(Root.Order.sMSG != "")
            {
                OrderHeader.AppendLine($"<p><strong>Message: </strong>{Root.Order.sMSG}</p><br />");
            }

            if (!Root.Customer.STInvalid)
            {
                OrderHeader.AppendLine($"<H1 style='font-size:large'>{Resources.ShipTo}:</H1>");
                OrderHeader.AppendLine($"{Root.Customer.STName}<BR>");
                OrderHeader.AppendLine($"{Root.Customer.STAddress1}<BR>");
                OrderHeader.AppendLine($"{Root.Customer.STCity} ");
                if(Root.Customer.STState != "") OrderHeader.AppendLine($"({Root.Customer.STState})");
                OrderHeader.AppendLine($"<br />");
                OrderHeader.AppendLine($"{Root.Customer.STPostalCode}<BR>");
                OrderHeader.AppendLine("<BR>");
            }
        }

        private void BuildOrderTable()
        {
            //Build an HTML table to reproduce the Order sent by the customer
            OrderTable.AppendLine("<TABLE style='border-style:solid; border-width:1px; border-color:#000000;'>");
            OrderTable.AppendLine("<TR>");
            OrderTable.AppendLine($"<TH style='width:40px;border-style:solid; border-width:1px; border-color:#000000;'>Item</TH>");
            OrderTable.AppendLine($"<TH style='width:210px;border-style:solid; border-width:1px; border-color:#000000;'>{Resources.Code}</TH>");
            OrderTable.AppendLine($"<TH style='width:210px;border-style:solid; border-width:1px; border-color:#000000;'>{Resources.CustomerItemId}</TH>");
            OrderTable.AppendLine($"<TH style='width:400px;border-style:solid; border-width:1px; border-color:#000000;'>{Resources.Desc}</TH>");
            OrderTable.AppendLine($"<TH style='width:100px;border-style:solid; border-width:1px; border-color:#000000;'>{Resources.Quant}</TH>");
            OrderTable.AppendLine($"<TH style='width:100px;border-style:solid; border-width:1px; border-color:#000000;'>{Resources.Price}</TH>");
            OrderTable.AppendLine($"<TH style='width:100px;border-style:solid; border-width:1px; border-color:#000000;'>{Resources.Status}</TH>");
            OrderTable.AppendLine($"<TH style='width:60px;border-style:solid; border-width:1px; border-color:#000000;'></TH>");
            OrderTable.AppendLine("</TR>");

            foreach (rootOrderOrderItem i in Root.Order.OrderItem)
            {
                string code = i.ItemId == i.ELProdCode ? $"{i.ItemId}" : $"{i.ItemId}<BR>{i.ELProdCode}";
                OrderTable.AppendLine("<TR>");
                OrderTable.AppendLine($"<TD style='width:40px;border-style:solid; border-width:1px; border-color:#000000;'>{i.ItemLineId}</TH>");
                OrderTable.AppendLine($"<TD style='width:210px;border-style:solid; border-width:1px; border-color:#000000;'>{code}</TH>");
                OrderTable.AppendLine($"<TD style='width:210px;border-style:solid; border-width:1px; border-color:#000000;'>{i.CustomerItemId}</TH>");
                OrderTable.AppendLine($"<TD style='width:400px;border-style:solid; border-width:1px; border-color:#000000;'>{i.ItemDescription}</TH>");
                OrderTable.AppendLine($"<TD style='width:100px;border-style:solid; border-width:1px; border-color:#000000;'>{i.ItemQuantity}</TH>");
                OrderTable.AppendLine($"<TD style='width:100px;border-style:solid; border-width:1px; border-color:#000000;'>{i.AdjustedItemPrice:C2} {i.ItemUnitOfPrice}</TH>");
                OrderTable.AppendLine($"<TD style='width:100px;border-style:solid; border-width:1px; border-color:#000000;'>{i.ItemStatus}</TH>");
                OrderTable.AppendLine($"<TD style='width:60px;border-style:solid; border-width:1px; border-color:#000000;'><sup>{i.ItemSup}</sup></TH>");
                OrderTable.AppendLine("</TR>");
            }


            OrderTable.AppendLine("</TABLE>");

        }

        public void BuildMessages()
        {

            List<Message> CustomerValidationExternalMessages = Root.Customer.Messages.Where(m => m.Scope != Scope.Internal).ToList();
            List<Message> CustomerValidationInternalMessages = Root.Customer.Messages.ToList();

            if (CustomerValidationExternalMessages.Count > 0)
            {
                CustomerEmail.AppendLine($"<H2 style='font-size:medium'>{Resources.CustVal}:</H2><BR>");
                CustomerEmail.AppendLine();

                CustomerValidationExternalMessages.ForEach(m => CustomerEmail.AppendLine("<LI>" + m.Text + "</LI>"));

                CustomerEmail.AppendLine();
            }

            if (CustomerValidationInternalMessages.Count > 0)
            {
                InternalEmail.AppendLine($"<H2 style='font-size:medium'>{Resources.CustVal}:</H2><BR>");

                InternalEmail.AppendLine("<UL>");
                CustomerValidationInternalMessages.ForEach(m => InternalEmail.AppendLine("<LI>" + m.Text + "</LI>"));
                InternalEmail.AppendLine("</UL>");

                InternalEmail.AppendLine();
            }

            List<Message> OrderValidationExternalMessages = Root.Order.Messages.Where(m => m.Scope != Scope.Internal).ToList();
            List<Message> OrderValidationInternalMessages = Root.Order.Messages.ToList();

            if (OrderValidationExternalMessages.Count > 0)
            {
                CustomerEmail.AppendLine($"<H2 style='font-size:medium'>{Resources.OrderVal}:</H2><BR>");

                CustomerEmail.AppendLine("<UL>");
                OrderValidationExternalMessages.ForEach(m => CustomerEmail.AppendLine("<LI>" + m.Text + "</LI>"));
                CustomerEmail.AppendLine("</UL>");
            }

            if (OrderValidationInternalMessages.Count > 0)
            {
                InternalEmail.AppendLine($"<H2 style='font-size:medium'>{Resources.OrderVal}:</H2><BR>");

                InternalEmail.AppendLine("<UL>");
                OrderValidationInternalMessages.ForEach(m => InternalEmail.AppendLine("<LI>" + m.Text + "</LI>"));
                InternalEmail.AppendLine("</UL>");
            }

            List<Message> OrderItemsValidationExternalMessages = Root.Order.OrderItem.SelectMany(m => m.Messages.Where(mm => mm.Scope != Scope.Internal)).ToList();
            List<Message> OrderItemsValidationInternalMessages = Root.Order.OrderItem.SelectMany(m => m.Messages).ToList();

            if (OrderItemsValidationExternalMessages.Count > 0)
            {
                CustomerEmail.AppendLine($"<H2 style='font-size:medium'>{Resources.ItemVal}:</H2><BR>");

                CustomerEmail.AppendLine("<UL>");
                OrderItemsValidationExternalMessages.ForEach(m => CustomerEmail.AppendLine("<LI>" + m.Text + "</LI>"));
                CustomerEmail.AppendLine("</UL>");

            }

            if (OrderItemsValidationInternalMessages.Count > 0)
            {
                InternalEmail.AppendLine($"<H2 style='font-size:medium'>{Resources.ItemVal}:</H2><BR>");

                InternalEmail.AppendLine("<UL>");
                OrderItemsValidationInternalMessages.ForEach(m => InternalEmail.AppendLine("<LI>" + m.Text + "</LI>"));
                InternalEmail.AppendLine("</UL>");

            }

        }

        public void Send()
        {
            // SendCustomerEmail(); // Ariva : do not send email to customer
            SendInternalEmail();
        }

        private void SendCustomerEmail()
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Credentials = new NetworkCredential("noreply@multi-services.org", "Cuz813911");
            client.EnableSsl = true;

            MailAddress from = new MailAddress("web2@envl.ca", "EDI System (Enveloppes Laurentide)", System.Text.Encoding.UTF8);
            MailAddress to = null;

            if (UseSystem == "live")
            {
                to = new MailAddress("po@envl.ca");
            }
            else
            {
                to = new MailAddress("kjohnston@multi-services.org");
            }

            MailMessage msg = new MailMessage(from, to);
            msg.Body = HtmlHeader.ToString() + OrderHeader.ToString() + CustomerEmail.ToString() + OrderTable.ToString() + HtmlFooter.ToString();
            msg.Subject = Resources.ExternalEmailSubject;
            msg.IsBodyHtml = true;
            
            if (UseSystem == "live")
            {
                msg.CC.Add(new MailAddress("kjohnston@multi-services.org"));
            }
            else
            {
                
            }

            client.Send(msg);

            // KJ: 2018-11-05: Add a 1 second delay after sending an email, 
            //                 in order to prevent the email from being considered spam
            System.Threading.Thread.Sleep(1000);
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
                to = new MailAddress("po@envl.ca");
            }
            else
            {
                to = new MailAddress("kjohnston@multi-services.org");
                // to = new MailAddress("info@clientweb.ca");
                // return; // to temporarily disable emails for test environment for now
            }

            MailMessage msg = new MailMessage(from, to);
            msg.Body = HtmlHeader.ToString() + OrderHeader.ToString() + InternalEmail.ToString() + OrderTable.ToString() + HtmlFooter.ToString();
            msg.Subject = Resources.InternalEmailSubject + $" #{Root.Order.Number} (PO)";
            msg.IsBodyHtml = true;
            msg.Headers.Add("Message-Id",
                         String.Format("<{0}@{1}>",
                         Guid.NewGuid().ToString(),
                        "envl.ca"));

            InternalEmailBody = msg.Body;

            if (UseSystem == "live")
            {
                msg.CC.Add(new MailAddress("kjohnston@multi-services.org"));
            }
            else
            {
                msg.Subject = "Test server: " + msg.Subject;
            }

            client.Send(msg);

            // KJ: 2018-11-05: Add a 1 second delay after sending an email, 
            //                 in order to prevent the email from being considered spam
            System.Threading.Thread.Sleep(1000);
        }

        public void SaveToFile(string path)
        {

        }
    }
}
