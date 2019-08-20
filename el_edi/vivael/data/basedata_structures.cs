using static EDI_DB.Data.Base;

namespace vivael
{
    public partial class Globals
    {
        //public class data_a_foxpro_tables : DataSource
        //{
        //    public data_a_foxpro_tables() { Table_name = "a_foxpro_tables"; }
        //    public string ident { get; set; }
        //    public string tablename { get; set; }
        //    public int tablecount1 { get; set; }
        //    public int tablecount2 { get; set; }
        //    public int tablecount3 { get; set; }
        //    public int tablecount4 { get; set; }
        //    public string columns1 { get; set; }
        //    public string columns2 { get; set; }
        //    public string status_insert { get; set; }
        //    public string status_update { get; set; }
        //    public DateTime timestamp2 { get; set; }
        //}

        //public class data_a_mysql_proc : DataSource
        //{
        //    public string ident { get; set; }
        //    public string tablename { get; set; }
        //    public int domysql_sync { get; set; }
        //    public int domysql_nooverride { get; set; }
        //    public string resync { get; set; }
        //    public string resync_field { get; set; }
        //    public string resync_time { get; set; }
        //    public string primary_1 { get; set; }
        //    public string primary_2 { get; set; }
        //    public string primary_3 { get; set; }
        //    public string my_hash { get; set; }
        //    public string my_insert_fields { get; set; }
        //    public string my_insert_values { get; set; }
        //    public string my_update { get; set; }
        //    public int tablecount3 { get; set; }
        //    public int tablecount4 { get; set; }
        //}

        //public class data_mysql_foxpro : DataSource
        //{
        //    public int ident_ai { get; set; }
        //    public string mysql_foxpro { get; set; }
        //    public string mysql_table { get; set; }
        //    public string mysql_treated { get; set; }
        //    public string mysql_status { get; set; }
        //    public string mysql_hash_values { get; set; }
        //    public string foxpro_error { get; set; }
        //    public string foxpro_ai_field { get; set; }
        //    public int foxpro_ai_value { get; set; }
        //    public int ident_fox { get; set; }
        //    public string idhash { get; set; }
        //}

        //public class data_mysql_proc : DataSource
        //{
        //    public data_mysql_proc() { Table_name = "mysql_proc"; }
        //    public int ident { get; set; }
        //    public string tablename { get; set; }
        //    public int domysql_sync { get; set; }
        //    public int domysql_nooverride { get; set; }
        //    public string primary_1 { get; set; }
        //    public string primary_2 { get; set; }
        //    public string primary_3 { get; set; }
        //    public string my_hash { get; set; }
        //    public string my_insert_fields { get; set; }
        //    public string my_insert_values { get; set; }
        //    public string my_update { get; set; }
        //    public string resync { get; set; }
        //    public string resync_field { get; set; }
        //    public string resync_time { get; set; }
        //}

        public class data_fields_table : DataSource
        {   
            public void setup()
            {
                gQuery(@"SELECT 
                        TABLE_NAME, 
                        `COLUMN_NAME`, 
                        `DATA_TYPE`, 
                        `COLUMN_COMMENT`, 
                        `COLUMN_KEY`, 
                        primary_1, 
                        primary_2, 
                        primary_3 
                    FROM `INFORMATION_SCHEMA`.`COLUMNS` 
                    LEFT JOIN a_mysql_proc ON a_mysql_proc.tablename = `TABLE_NAME` 
                    WHERE 
                        `TABLE_SCHEMA` = '" + DB_VIVA.GetDatabase() + @"' 
                    ORDER BY TABLE_NAME, COLUMN_NAME ", this);
            } 

            public string Table_Name { get; set; }
            public string Column_Name { get; set; }
            public string Data_Type { get; set; }
            public string Column_Comment { get; set; }
            public string Column_Key { get; set; }
            public string Is_Nullable { get; set; }
            public string Primary_1 { get; set; }
            public string Primary_2 { get; set; }
            public string Primary_3 { get; set; }
        }

        //public class data_wsseq : DataSource
        //{
        //    public data_wsseq() { Tablename = "wsseq"; }
        //    public int IDENT { get; set; }
        //    public string TABLEID { get; set; }
        //    public int NEXT_ID { get; set; }
        //    public int TMP_ID { get; set; }
        //    public DateTime DATELAST { get; set; }
        //}

    }
}