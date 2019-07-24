using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Globalization;
using static EDI_DB.Data.Base;

namespace TEST
{

    public static class Globals
    {
        private static TextInfo ti = new CultureInfo("en-US", false).TextInfo;
        public static string gsDatabase = "vivadata4";

        public static void Init_globals_basedata_tables()
        {
            fields_table.setup();
        }

        public static data_fields_table fields_table = new data_fields_table();

        public static string ToTitleCase(string str)
        {
            return ti.ToTitleCase(str);
        }

        public static bool gQuery(string sPQuery, DataSource sdPCursor)
        {
            string slpMySQLQuery;


            slpMySQLQuery = sPQuery;

          
            if ((sdPCursor.result = DB_VIVA.HExecuteSQLQuery(slpMySQLQuery)) == null)
            {
                return false;
            }

            return true;
        }

        public static List<data_fields_table> GetFields(DataSource sdPTable, data_fields_table sdPFieldsTable)
        {
            string sLSQL = "SELECT `TABLE_NAME`, `COLUMN_NAME`, `DATA_TYPE`, `COLUMN_COMMENT`, `COLUMN_KEY`, IS_NULLABLE, primary_1, primary_2, primary_3, isfoxpro FROM `INFORMATION_SCHEMA`.`COLUMNS` LEFT JOIN mysql_proc ON mysql_proc.tablename = " + gQ1(sdPTable.i.name) + " WHERE `TABLE_SCHEMA`=" + gQ1(gsDatabase) + " AND `TABLE_NAME`=" + gQ1(sdPTable.i.name); //+ " ORDER BY COLUMN_NAME ";

            gQuery(sLSQL, sdPFieldsTable);

            List<data_fields_table> data_Fields = new List<data_fields_table>();

            for (int i = 0; i < fields_table.result.Count; i++)
            {
                data_Fields.Add(new data_fields_table());

                data_Fields[i].LoadRow(sdPFieldsTable.result[i]);
            }

            return data_Fields;
        }

        public static string gQ1(string sPText)
        {
            return "'" + Replace(sPText, "'", "''") + "'";
        }

        public static string Replace(string text, string find, string replace)
        {
            return text.Replace(find, replace);
        }

        public static string Q2(string pText)
        {
            string sPDQuote = "\"" + pText + "\"";

            return sPDQuote;
        }

        public static bool ISNULL(object vValue)
        {
            return vValue == null;
        }
    }

    public class data_fields_table : DataSource
    {
        public void setup()
        {
            Globals.gQuery(@"SELECT 
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

        public string table_name { get; set; }
        public string column_name { get; set; }
        public string data_type { get; set; }
        public string column_comment { get; set; }
        public string column_key { get; set; }
        public string is_nullable { get; set; }
        public string primary_1 { get; set; }
        public string primary_2 { get; set; }
        public string primary_3 { get; set; }
        public int isfoxpro { get; set; }
    }

    public class DataSourceInfo
    {
        public string primary_1;
        public string primary_2;
        public string primary_3;

        public int ident_ai { get; set; }
        public string name { get; set; } 
    }

    public class DataSource : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DataRow datarow { get; set; }
        public DataSet ds { get; set; }
        public string Tablename { get; set; }
        public List<IDataRecord> result { get; set; }
        public List<IDataRecord> fields_result { get; set; } = null;
        public DataSourceInfo i = new DataSourceInfo();
        public string MyQuery { get; set; } = "";
        public int noCurrent { get; set; }

        public object GetPrimary_1() { return this[i.primary_1]; }
        public object GetPrimary_2()
        {
            if (i.primary_2 != "")
                return this[i.primary_2];
            else
                return "";
        }
        public object GetPrimary_3()
        {
            if (i.primary_3 != "")
                return this[i.primary_3];
            else
                return "";
        }

        public object this[string propertyName]
        {
            get { return GetProperty(propertyName); }
            set { SetProperty(propertyName, value); } 
        }

        public object GetProperty(string PropertyName, object PNullValue = null)
        {
            object returnObject = null;
            try   { returnObject = GetType().GetProperty(PropertyName).GetValue(this); }
            catch { return PNullValue;  } return returnObject;
        }

        public bool SetProperty(string PropertyName, object PropertyValue)
        {
            try   { GetType().GetProperty(PropertyName).SetValue(this, PropertyValue); }
            catch { return false; } return true;
        }

        public void Set<T>(ref T field, T value, string propertyName)
        {
            field = value;
            OnPropertyChanged(propertyName.ToUpper());
        }

        private void SetFieldsResults()
        {
            if (fields_result != null) return;
            fields_result = Globals.fields_table.result.Where(i => i["TABLE_NAME"].ToString() == Tablename).ToList();
        }

        public void LoadRow()
        {
            string testx = "";
            try
            {
                int count = this.result[0].FieldCount;
                string name = "";

                for (int i = 0; i < count; i++)
                {
                    name = this.result[0].GetName(i).ToLower();
                    this[name] = this.result[0][name];
                }
            }
            catch (Exception ex)
            {
                testx = ex.ToString();
            }
        }

        public void LoadRow(IDataRecord DataRecord)
        {
            string testx = "";
            try
            {
                int count = DataRecord.FieldCount;
                string name = "";

                for (int i = 0; i < count; i++)
                {
                    name = DataRecord.GetName(i).ToLower();
                    this[name] = DataRecord[name];
                }
            }
            catch (Exception ex)
            {
                testx = ex.ToString();
            }

            //string testx = "";
            //try
            //{
            //    SetFieldsResults();

            //    foreach (IDataRecord IDfields_table in fields_result)
            //    {
            //        string COLUMN_NAME = "";
            //        COLUMN_NAME = IDfields_table["COLUMN_NAME"].ToString();
            //        SetProperty(COLUMN_NAME, DataRecord[COLUMN_NAME]);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    testx = ex.ToString();
            //}
        }

        public bool Found()
        {
            //WIP//
            return false;
        }

        public object GetColumn(string sPColumnName, object PNullValue)
        {
            object vLReturn;

            vLReturn = GetProperty(sPColumnName, PNullValue); // WIP

            if (vLReturn == null)
            {
                return PNullValue;
            }

            if (sPColumnName == null) 
            {
                return PNullValue;
            }

            return vLReturn;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
