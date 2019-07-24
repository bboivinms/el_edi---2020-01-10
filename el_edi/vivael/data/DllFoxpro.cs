﻿using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using static EDI_DB.Data.Base;

namespace vivael
{
    class DllFoxpro
    {
        private dynamic fox;
        public DllFoxpro()
        {
            fox = ComHelper.CreateObject("Foxpro.Main");
            Directory.SetCurrentDirectory(@"C:\vivael\data");
        }

        public void do_init()
        {
            fox.do_init();
        }

        public void ExecuteNonQuery(string lcQuery)
        {
            fox.ExecuteNonQuery(lcQuery); // "INSERT INTO wsuer (name) VALUES ('dada')";
        }

        public string HelloWorld()
        {
            return fox.HelloWorld();
        }

        public List<IDataRecord> ExecuteQuery(string query, int noRec = 0, int count = 0)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(fox.ExecuteQuery(query, noRec, count)));
            return ds.Tables[0].CreateDataReader().Cast<IDataRecord>().ToList();
        }
    }
}
