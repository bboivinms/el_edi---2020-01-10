using MySql.Data.MySqlClient;
using EDI_850.Helpers;
using System;
using System.Data;
using System.Linq;
using EDICommons.Tools;
using EDI_DB.Data;
using static EDI_DB.Data.Base;

namespace EDI_850
{
    public partial class XMLProcessor_850
    {
        private string XMLFilePath;

        public XMLProcessor_850()
        {
            XMLFilePath = Program_850.XmlFilePath;
        }


        public void ProcessOrder()
        {
            Schema.root r = null;

            try
            {
                r = Schema.root.LoadFromFile(XMLFilePath);
            }
            catch (Exception e)
            {

                //Write to application log
                LogWriter.WriteMessage(Program_850.LogEventSource, $"Error reading XML file: {XMLFilePath}\r\n\r\n{e.Message}");

                string tt = e.Message;
                Environment.Exit(-1);
            }

            //Open DB connections
            DB_VIVA.conn.Open();
            DB_WEB.conn.Open();

            try
            {
                //Create timestamp used as PK on some tables
                TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
                long TimeStamp = Convert.ToInt64(t.TotalMilliseconds);

                //Fire up the validation process on the XML data.
                //
                //The validation process requires the MySql connection object, already opened.
                r.Validate();

                EmailBuilder eb = new EmailBuilder(r);
                eb.Build();

                eb.Send();

                //Check if customer information is valid. If not, stop processing
                if (!r.Customer.IsValid)
                {
                    DB_VIVA.conn.Close();
                    DB_WEB.conn.Close();
                    return;
                }

                //Check if Order information is valid. If not, stop processing
                if (!r.Order.IsValid)
                {
                    DB_VIVA.conn.Close();
                    DB_WEB.conn.Close();
                    return;
                }

                //Check if Order information is valid. If not, stop processing
                //KJ: 2018-11-08: continue processing but with empty record
                if (r.Order.OrderItem.All(i => !i.IsValid))
                {
                    LogWriter.WriteMessage(Program_850.LogEventSource, "No valid item in order, stop processing.");
                }

                //Create new order in s_cocom & s_cocomi on "web" DB

                try
                {
                    using (MySqlTransaction tr = DB_WEB.conn.BeginTransaction(IsolationLevel.ReadUncommitted))
                    {
                        MySqlCommand cmd = DB_WEB.conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO s_cocom(ident, clientid, co_dte, clientpo, client_name, client_addr, del_name, iddel_addr, del_add, cr_by, cr_dtet, req_dte, notes, statut, ucode, " +
                            " contact, contactfax, contactemail, edi_del_addr, edi_messages, edi_email_internal) " +
                            " VALUE(?ident, ?clientid, ?co_dte, ?clientpo, ?client_name, ?client_addr, ?del_name, ?iddel_addr, ?del_add, ?cr_by, ?cr_dtet, ?req_dte, ?notes, ?statut, ?ucode, " +
                            " ?contact, ?contactfax, ?contactemail, ?edi_del_addr, ?edi_messages, ?edi_email_internal)";

                        cmd.Parameters.AddWithValue("?ident", TimeStamp);
                        cmd.Parameters.AddWithValue("?clientid", r.Customer.Id);
                        cmd.Parameters.AddWithValue("?co_dte", r.Order.Date);
                        cmd.Parameters.AddWithValue("?clientpo", r.Order.Number);
                        cmd.Parameters.AddWithValue("?client_name", r.Customer.BTName);
                        cmd.Parameters.AddWithValue("?client_addr", r.Customer.BTAddress);
                        cmd.Parameters.AddWithValue("?del_name", r.Customer.STName);
                        cmd.Parameters.AddWithValue("?iddel_addr", r.Customer.ST_IDDEL_ADDR);
                        cmd.Parameters.AddWithValue("?del_add", r.Customer.STAddress);
                        cmd.Parameters.AddWithValue("?cr_by", r.Order.CreatedBy);
                        cmd.Parameters.AddWithValue("?cr_dtet", r.Order.Date);
                        cmd.Parameters.AddWithValue("?req_dte", r.Order.ActualShipDate);
                        cmd.Parameters.AddWithValue("?notes", r.Order.sMSG);
                        cmd.Parameters.AddWithValue("?statut", r.Order.Status);
                        cmd.Parameters.AddWithValue("?ucode", r.Order.UserCode);

                        cmd.Parameters.AddWithValue("?contact", r.Customer.BYName);
                        cmd.Parameters.AddWithValue("?contactfax", r.Customer.BYFax);
                        cmd.Parameters.AddWithValue("?contactemail", r.Customer.BYEmail);

                        cmd.Parameters.AddWithValue("?edi_del_addr", r.Customer.STAddress);
                        cmd.Parameters.AddWithValue("?edi_messages", eb.CustomerEmail.ToString() + "\r\n\r\n" + eb.InternalEmail.ToString());

                        cmd.Parameters.AddWithValue("?edi_email_internal", eb.InternalEmailBody);

                        if (cmd.ExecuteNonQuery() != 1)
                        {
                            tr.Rollback();
                            DB_VIVA.conn.Close();
                            DB_WEB.conn.Close();
                            LogWriter.WriteMessage(Program_850.LogEventSource, $"Was unable to create s_cocom in MySql for order {r.Order.Number}");
                            return;
                        }

                        foreach (Schema.rootOrderOrderItem l in r.Order.OrderItem.Where(i => i.IsValid))
                        {
                            using (MySqlCommand cmdi = DB_WEB.conn.CreateCommand())
                            {
                                cmdi.CommandType = CommandType.Text;
                                cmdi.CommandText = "INSERT INTO s_cocomi(idco, line, idprod, idquote, descr, qty_ord, price, unite, conv, qty_del_on, statut, edi_prod, edi_price, edi_total, measure, CustItemNo, req_date, clientpo)" +
                                    "VALUE(?idco, ?line, ?idprod, ?idquote, ?descr, ?qty_ord, ?price, ?unite, ?conv, ?qty_del_on, ?statut, ?edi_prod, ?edi_price, ?edi_total, ?measure, ?CustItemNo, ?req_date, ?clientpo)";
                                cmdi.Parameters.AddWithValue("?idco", TimeStamp);
                                cmdi.Parameters.AddWithValue("?line", l.ItemLineId / 10); //Divide Line number by 10 //TODO: might have to be adapted on a per customer basis
                                cmdi.Parameters.AddWithValue("?idprod", l.IdProd);
                                cmdi.Parameters.AddWithValue("?idquote", 0);
                                cmdi.Parameters.AddWithValue("?descr", l.ItemDescription);
                                cmdi.Parameters.AddWithValue("?qty_ord", l.AdjustedQty);
                                cmdi.Parameters.AddWithValue("?price", l.AdjustedItemPrice);
                                cmdi.Parameters.AddWithValue("?unite", l.ItemUnitOfPrice);
                                cmdi.Parameters.AddWithValue("?conv", l.ItemUnitConversion);
                                cmdi.Parameters.AddWithValue("?qty_del_on", null);
                                cmdi.Parameters.AddWithValue("?statut", l.Status);
                                cmdi.Parameters.AddWithValue("?edi_prod", l.ItemDescription);
                                cmdi.Parameters.AddWithValue("?edi_price", l.ItemRate);
                                cmdi.Parameters.AddWithValue("?edi_total", l.AdjustedItemTotal);
                                cmdi.Parameters.AddWithValue("?measure", l.ItemUnitOfMeasure);
                                cmdi.Parameters.AddWithValue("?CustItemNo", l.CustomerItemId);
                                cmdi.Parameters.AddWithValue("?req_date", r.Order.RequestedShipDate);
                                cmdi.Parameters.AddWithValue("?clientpo", r.Order.Number);

                                if (cmdi.ExecuteNonQuery() != 1)
                                {
                                    tr.Rollback();
                                    DB_VIVA.conn.Close();
                                    DB_WEB.conn.Close();
                                    LogWriter.WriteMessage(Program_850.LogEventSource, $"Was unable to create s_cocomi in MySql for order {r.Order.Number}");
                                    return;
                                }
                            }
                        }

                        tr.Commit();


                    }
                }
                catch (Exception ex)
                {
                    string xx = ex.Message;
                }
                //TODO: create COBIL et COBILI for items that are valid. Must only create for items which
                //have enough stock available to ship entirely.

                var ItemsToShip = r.Order.OrderItem.Where(i => i.IsValid && i.AdjustedQty <= i.QtyInStock).Select((item, index) => new { Item = item, Index = index + 1 }).ToList();

                //If no items have stock, stop processing
                if (ItemsToShip.Count == 0)
                    return;

                using (MySqlTransaction tr = DB_WEB.conn.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    if (r.Order.HasActualShipDate1) InsertCobil(r.Order.ActualShipDate1, 1);
                    if (r.Order.HasActualShipDate2) InsertCobil(r.Order.ActualShipDate2, 2);

                    void InsertCobil(DateTime cobil_req_dte, int TimeMod)
                    {
                        long ident = (TimeStamp * 10) + TimeMod;

                        MySqlCommand cmd = DB_WEB.conn.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO cobil(ident, del_name, iddel_addr, del_add, bil_dte, cr_by, cr_dtet, ref, statut, req_dte, clientid, client_name, client_addr, date_entered, ucode, type_liv)" +
                            "VALUES(?ident, ?del_name, ?iddel_addr, ?del_add, ?bil_dte, ?cr_by, ?cr_dtet, ?ref, ?statut, ?req_dte, ?clientid, ?client_name, ?client_addr, ?date_entered, ?ucode, ?type_liv)";
                        cmd.Parameters.AddWithValue("?ident", ident);
                        cmd.Parameters.AddWithValue("?del_name", r.Customer.STName);
                        cmd.Parameters.AddWithValue("?iddel_addr", r.Customer.ST_IDDEL_ADDR);
                        cmd.Parameters.AddWithValue("?del_add", r.Customer.STAddress);
                        cmd.Parameters.AddWithValue("?bil_dte", DateTime.Today);
                        cmd.Parameters.AddWithValue("?cr_by", "EDI");
                        cmd.Parameters.AddWithValue("?cr_dtet", r.Order.Date);
                        cmd.Parameters.AddWithValue("?ref", r.Order.Number);
                        cmd.Parameters.AddWithValue("?statut", "E");
                        cmd.Parameters.AddWithValue("?req_dte", cobil_req_dte);
                        cmd.Parameters.AddWithValue("?clientid", arclient_ident);
                        cmd.Parameters.AddWithValue("?client_name", r.Customer.BTName);
                        cmd.Parameters.AddWithValue("?client_addr", r.Customer.BTAddress);
                        cmd.Parameters.AddWithValue("?date_entered", DateTime.Today);
                        cmd.Parameters.AddWithValue("?ucode", "XEDI");
                        cmd.Parameters.AddWithValue("?type_liv", 0);
                    
                        if (cmd.ExecuteNonQuery() != 1)
                        {
                            tr.Rollback();
                            DB_VIVA.conn.Close();
                            DB_WEB.conn.Close();
                            LogWriter.WriteMessage(Program_850.LogEventSource, $"Was unable to create cobil in MySql for order {r.Order.Number}");
                            return;
                        }
                    }

                    foreach (var item in ItemsToShip)
                    {
                        using (MySqlCommand cmdi = DB_WEB.conn.CreateCommand())
                        {
                            long idcobil = (TimeStamp * 10) + item.Item.ActualShipDateNumber;

                            cmdi.CommandType = CommandType.Text;
                            cmdi.CommandText = "INSERT INTO cobili(idcobil, line, statut, idprod, descr, qty, price, unite, conv, po_no, nopalet, nolot, idcom, qty_bo)" +
                                "VALUE(?idcobil, ?line, ?statut, ?idprod, ?descr, ?qty, ?price, ?unite, ?conv, ?po_no, ?nopalet, ?nolot, ?idcom, ?qty_bo)";
                            cmdi.Parameters.AddWithValue("?idcobil", idcobil);
                            cmdi.Parameters.AddWithValue("?line", item.Index);
                            cmdi.Parameters.AddWithValue("?statut", "E");
                            cmdi.Parameters.AddWithValue("?idprod", item.Item.IdProd);
                            cmdi.Parameters.AddWithValue("?descr", item.Item.ItemDescription);
                            cmdi.Parameters.AddWithValue("?qty", item.Item.AdjustedQty);
                            cmdi.Parameters.AddWithValue("?price", item.Item.AdjustedItemPrice);
                            cmdi.Parameters.AddWithValue("?unite", item.Item.ItemUnitOfPrice);
                            cmdi.Parameters.AddWithValue("?conv", item.Item.ItemUnitConversion);
                            cmdi.Parameters.AddWithValue("?po_no", r.Order.Number);
                            cmdi.Parameters.AddWithValue("?nopalet", 0);
                            cmdi.Parameters.AddWithValue("?nolot", string.Empty);
                            cmdi.Parameters.AddWithValue("?idcom", 0);
                            cmdi.Parameters.AddWithValue("?qty_bo", 0);

                            if (item.Item.IdProd != null && item.Item.IdProd != 0)
                            {
                                if (cmdi.ExecuteNonQuery() != 1)
                                {
                                    tr.Rollback();
                                    DB_VIVA.conn.Close();
                                    DB_WEB.conn.Close();
                                    LogWriter.WriteMessage(Program_850.LogEventSource, $"Was unable to create cobili in MySql for order {r.Order.Number}");
                                    return;
                                }
                            }

                        }
                    }

                    tr.Commit();

                }


            }
            finally
            {
                DB_VIVA.conn.Close();
                DB_WEB.conn.Close();
            }

        }

    }
}
