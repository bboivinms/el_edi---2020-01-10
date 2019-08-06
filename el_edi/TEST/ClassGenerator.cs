using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace TEST
{
    public static class ClassGenerator
    {
        public static void GenerateAll()
        {
            Globals.Init_globals_basedata_tables();

            string previous = "";

            foreach (var item in Globals.fields_table.result)
            {
                if (previous != item[0].ToString() && !item[0].ToString().Contains("~"))
                {
                    Generate(item[0].ToString());
                }

                previous = item[0].ToString();
            }
            Console.ReadKey();
        }

        public static void Generate(string tablename)
        {
            DataSource sdPTable = new DataSource();
            sdPTable.i.name = tablename;

            List<data_fields_table> data_Fields = Globals.GetFields(sdPTable, Globals.fields_table);

            try
            {
                string template = File.ReadAllText(@"W:\~Programmeurs\~GIT\repos\Rémi\repos\el_edi\el_edi\vivael\bin\Debug\templateClass.cs");

                template = template.Replace("~#table_name#~", data_Fields[0]["table_name"].ToString());

                if (data_Fields[0]["isfoxpro"].ToString() == "1")
                    template = template.Replace("~#isFoxpro#~", "true");
                else
                    template = template.Replace("~#isFoxpro#~", "false");

                StringBuilder properties = new StringBuilder();
                string type, column_name = "";
                int keyCounter = 1;

                for (int i = 0; i < data_Fields.Count; i++)
                {
                    if (data_Fields[i]["column_key"].ToString() == "PRI")
                    {
                        template = template.Replace("~#key"+keyCounter+"#~", data_Fields[i]["column_name"].ToString().ToLower());
                        keyCounter++;
                    }

                    type = ConvertSqlType(data_Fields[i]["data_type"].ToString(), data_Fields[i]["is_nullable"].ToString());
                    column_name = Globals.ToTitleCase(data_Fields[i]["column_name"].ToString().ToLower());

                    if (data_Fields[i]["column_comment"].ToString().Contains("fox_ai"))
                        template = template.Replace("~#fox_ai#~", column_name);

                    if (column_name != "Timestamp" && column_name != "Idhash")
                    {
                        properties.AppendLine("\t\tprivate " + type + " _" + column_name + "; public " + type + " " + column_name + " { get { return _" + column_name + "; } set { Set(ref _" + column_name + ", value, " + Globals.Q2(column_name) + "); } }");
                    }
                }

                template = template.Replace("\"~#key1#~\"", "null");
                template = template.Replace("\"~#key2#~\"", "null");
                template = template.Replace("\"~#key3#~\"", "null");
                template = template.Replace("~#fox_ai#~", "");

                template = template.Replace("~#properties#~", properties.ToString());

                File.WriteAllText(@"W:\~Programmeurs\~GIT\repos\Rémi\repos\el_edi\el_edi\vivael\model\data_" + sdPTable.i.name + ".cs", template);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                Console.ReadKey();
            }
            finally
            {
                Console.WriteLine("Class data_" + sdPTable.i.name + " generated." );
            }

            //Process.Start("notepad++.exe", @"W:\~Programmeurs\~GIT\repos\Rémi\repos\el_edi\el_edi\vivael\model\data_" + sdPTable.i.name + ".cs");
        }

        private static string ConvertSqlType(string sqlType, string is_nullable)
        {
            string csType = "";

            switch (sqlType)
            {
                case "varchar":
                case "longtext":
                case "mediumtext":
                case "text":
                case "longblob":
                case "mediumblob":
                case "blob":
                case "tinyblob":
                    csType = "string";
                    break;
                case "tinyint":
                    csType = "byte";
                    break;
                case "bit":
                    csType = "bool";
                    break;
                case "bigint":
                    csType = "long";
                    break;
                case "date":
                case "datetime":
                    csType = "DateTime";
                    break;
                case "smallint":
                    csType = "short";
                    break;
                default:
                    csType = sqlType;
                    break;
            }
            
            if (csType != "string" && is_nullable == "YES")
            {
                csType += "?";
            }

            return csType;
        }
    }
}
