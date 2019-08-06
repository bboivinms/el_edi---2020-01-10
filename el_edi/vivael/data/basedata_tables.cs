using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace vivael
{
    public partial class Globals
    {
        public void Init_globals_basedata_tables()
        {
            fields_table.setup();
        }

        public static data_a_foxpro_tables a_foxpro_tables = new data_a_foxpro_tables();

        public static data_a_mysql_proc a_mysql_proc = new data_a_mysql_proc();

        public static data_mysql_foxpro mysql_foxpro = new data_mysql_foxpro();

        public static data_mysql_proc mysql_proc = new data_mysql_proc();

        public static data_fields_table fields_table = new data_fields_table(); 

        public static data_wsseq wsseq = new data_wsseq();

        public static data_wsuser wsuser = new data_wsuser();
    }
}
