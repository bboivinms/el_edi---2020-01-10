using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_Dll
{

    public class Edi855v
    {
        public string Ident { get; set; }
        public string Popo_ident { get; set; }
        public string Status { get; set; }
        public string Validator { get; set; }
        public string Sent { get; set; }
        public string Filename { get; set; }
        public string Popo_pono { get; set; }
        public string Po_dte { get; set; }
        public string Popo_del_name { get; set; }
        public string Iddel_addr { get; set; }
        public string Xml855Raw { get; set; }
        public string error { get; set; }
        public string Timestamp { get; set; }

        public Edi855v(IDataRecord records)
        {
            Ident = records["Ident"].ToString();
            Popo_ident = records["popo_ident"].ToString(); 
            Status = records["Status"].ToString();
            Validator = records["Validator"].ToString(); 
            Sent = records["Sent"].ToString(); 
            Filename = records["Filename"].ToString();
            Popo_pono = records["popo_pono"].ToString();
            Po_dte = records["po_dte"].ToString();
            Popo_del_name = records["popo_del_name"].ToString();
            Iddel_addr = records["iddel_addr"].ToString();
            Xml855Raw = records["Xml855Raw"].ToString();
            error = records["error"].ToString();
            Timestamp = records["Timestamp"].ToString();
        }

        public Edi855v()
        {
            Ident = "";
            Popo_ident = "";
            Status = "";
            Validator = "";
            Sent = "";
            Filename = "";
            Popo_pono = "";
            Po_dte = "";
            Popo_del_name = "";
            Iddel_addr = "";
            Xml855Raw = "";
            error = "";
            Timestamp = "";
        }

    }
}
