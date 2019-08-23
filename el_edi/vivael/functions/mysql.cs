using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using static EDI_DB.Data.Base;
using System.IO;
using System.Globalization;

namespace vivael
{
    public partial class Globals
    {
        private static Connection _m_cnxConnect_db = null; public static Connection m_cnxConnect_db { get { return _m_cnxConnect_db; } set { _m_cnxConnect_db = value; } }
        private static int _gNumConnexion; public static int gNumConnexion { get { return _gNumConnexion; } set { _gNumConnexion = value; } }
        private static bool _gStayAlive; public static bool gStayAlive { get { return _gStayAlive; } set { _gStayAlive = value; } }

        public static int DataOverride = (int)EData.hybrid;
        public enum EData : int {hybrid, mysql, dbf };
        public static string NL = "\r\n";

        private static TextInfo ti = new CultureInfo("en-US", false).TextInfo;

        //public static EDI_DB.Data.DB_254 DB_254 = new EDI_DB.Data.DB_254("Test");
        //public static EDI_DB.Data.DB_253 DB_253 = new EDI_DB.Data.DB_253("Test");

        public class Connection
        {
            private static string _Provider; public string Provider { get { return _Provider; } set { _Provider = value; } }
            private static string _User; public string User { get { return _User; } set { _User = value; } }
            private static string _Password; public string Password { get { return _Password; } set { _Password = value; } }
            private static string _Server; public string Server { get { return _Server; } set { _Server = value; } }
            private static string _Database; public string Database { get { return _Database; } set { _Database = value; } }
        }

        public static bool HOpenConnection(Connection conn)
        {
            //WIP
            return true;
        }

        public static void HCloseConnection(Connection conn)
        {
            //WIP
        }

        public static bool HReadFirst(DataSource sdPCursor, string sOrderBy = "")
        {
            // WIP
            if (sdPCursor.noCurrent >= 0)
            {
                gQuery(sdPCursor.MyQuery, sdPCursor, 0, 1, sdPCursor.isFoxpro);
                sdPCursor.noCurrent = 0;
            }
            else
            {
                return false;
            }

            return true;
        }

        public static bool HOut(DataSource sdPCursor)
        {
            // WIP
            if (sdPCursor.result.Count < 1)
            {
                gFirst(sdPCursor);
                return true;
            }
            return false;
        }

        //public static bool HExecuteSQLQuery(DataSource sdPCursor, string slpMySQLQuery)
        //{
        //    MySqlCommand cmd = DB_254.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = slpMySQLQuery;

        //    sdPCursor.result = null;

        //    try
        //    {
        //        DB_254.Open();
        //        MySqlDataReader rd = cmd.ExecuteReader(CommandBehavior.KeyInfo);
        //        sdPCursor.result = rd.Cast<IDataRecord>().ToList();
        //        rd.Close();
        //    }
        //    catch
        //    {
        //        DB_254.Close();
        //        return false;
        //    }
        //    finally
        //    {
        //        DB_254.Close();
        //    }

        //    // WIP
        //    return true;
        //}

        //public static List<IDataRecord> HExecuteSQLQuery(string slpMySQLQuery, Dictionary<string, string> pParams = null)
        //{
        //    MySqlCommand cmd = DB_254.CreateCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = slpMySQLQuery;

        //    string Parameters = "";

        //    List<IDataRecord> sdPCursor = null;

        //    try
        //    {
        //        if (pParams != null)
        //        {
        //            foreach (KeyValuePair<string, string> pParam in pParams)
        //            {
        //                cmd.Parameters.AddWithValue(pParam.Key, pParam.Value);
        //                Parameters += "Key: " + pParam.Key + " Value: " + pParam.Value + NL;
        //            }
        //        }

        //        DB_254.Open();
        //        MySqlDataReader rd = cmd.ExecuteReader();
        //        sdPCursor = rd.Cast<IDataRecord>().ToList();
        //        rd.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        DB_254.Close();
        //        sdPCursor = null;
        //    }
        //    finally
        //    {
        //        DB_254.Close();
        //    }

        //    return sdPCursor;
        //}

        public static void HReset(DataSource sdPCursor)
        {
            // WIP
        }

        public static bool HAdd(DataSource sdPCursor)
        {
            // WIP
            return true;
        }

        public static bool HFound(DataSource sdPCursor)
        {
            // WIP
            return true;
        }

        public static bool HReadSeek(DataSource sdPCursor, int? primary_key_value)
        {
            // WIP
            return true;
        }

        public static bool HReadSeek(DataSource sdPCursor, string unique_key, int? unique_key_value)
        {
            // WIP
            return true;
        }

        public static bool HReadSeek(DataSource sdPCursor, string unique_key, string primary_key_value)
        {
            // WIP
            return true;
        }

        public static bool HModify(DataSource sdPCursor)
        {
            // WIP            
            return true;
        }

        public static bool HDelete(DataSource sdPCursor)
        {
            // WIP
            return true;
        }

        public static bool HReadNext(DataSource sdPCursor)
        {
            // WIP
            if (sdPCursor.noCurrent < sdPCursor.RECCOUNT()-1)
            {
                sdPCursor.noCurrent += 1;
                gQuery(sdPCursor.MyQuery, sdPCursor, sdPCursor.noCurrent, 1, sdPCursor.isFoxpro);
            }
            else
            {
                return false;
            }

            return true;
        }

        public static bool HReadLast(DataSource sdPCursor)
        {
            // WIP
            int lastrecord = sdPCursor.RECCOUNT() - 1;

            if (sdPCursor.noCurrent < lastrecord)
            {
                gQuery(sdPCursor.MyQuery, sdPCursor, lastrecord, 1, sdPCursor.isFoxpro);
                sdPCursor.noCurrent = lastrecord;
                return true;
            }

            return false;
        }

        public static bool HReadPrevious(DataSource sdPCursor)
        {
            if (sdPCursor.noCurrent > 0)
            {
                gQuery(sdPCursor.MyQuery, sdPCursor, --sdPCursor.noCurrent, 1, sdPCursor.isFoxpro);
            }
            else
            {
                sdPCursor.result = new List<IDataRecord>();
                return false;
            }

            return true;
        }

        public static bool HReadSeekFirst(DataSource sdPCursor, string sPFieldName, string sPSearchValue)
        {
            // WIP
            return true;
        }

        public static bool HForward(DataSource sdPCursor, string sPFieldName, int iPJumpValue)
        {
            // WIP
            gQuery(sdPCursor.MyQuery, sdPCursor, iPJumpValue, 1, sdPCursor.isFoxpro);
            sdPCursor.noCurrent = iPJumpValue;
            return true;
        }

        public static bool HFileExist(string sdPCursor)
        {
            // WIP
            return true;
        }

        public static int HSavePosition(DataSource sdPCursor)
        {
            // WIP
            //return sdPCursor.bs.Position;
            return sdPCursor.noCurrent;
        }

        public static void HRestorePosition(DataSource sdPCursor, int nPos)
        {
            // WIP
            //sdPCursor.bs.Position = nPos;
            gQuery(sdPCursor.MyQuery, sdPCursor, nPos, 1, sdPCursor.isFoxpro);
            sdPCursor.noCurrent = nPos;
        }

        public static DataSource GetDataSource(string sdPCursor)
        {
            // WIP
            return new DataSource();
        }

        public static string Error(string err, string errinfo)
        {
            //WIP
            return err;
        }

        public static string ErrorInfo()
        {
            //WIP
            return "";
        }

        public static string YesNo(string info)
        {
            //WIP
            return info;
        }

        public static string YesNo(string info, string param2)
        {
            //WIP
            return info;
        }

        public static string ToClipboard(string text)
        {
            //WIP
            return text;
        }

        public static void WAIT(int milli_seconds)
        {
            //WIP
        }

        public static bool Contains(string text, string contains)
        {
            if(text == contains)
            {
                return true;
            }
            return false;
        }

        public static string Charact(int asc)
        {
            if(asc == 13)
            {
                return "\r";
            }else if(asc == 10)
            {
                return "\n";
            }
            else
            {
                return "";
            }
        }

        public static decimal Val(string text)
        {
            return System.Convert.ToDecimal(text);
        }

        public static string sVal(string text)
        {
            return System.Convert.ToDecimal(text).ToString();
        }

        public static string Replace(string text, string find, string replace)
        {
            return text.Replace(find, replace);
        }

        public static string Lower(string text)
        {
            return text.ToLower();
        }

        public static string Upper(string text)
        {
            return text.ToUpper();
        }
        
        public static void gDisconnect()
        {
            return; //WIP not needed for now
        }

        public static string gQ1(string sPText)
        {
            return "'" + Replace(sPText, "'", "''") + "'";
        }

        public static string gQNum(string pNumber)
        {
            return gQ1(sVal(pNumber));
        }

        public static void glog_error(string sPString)
        {
            sPString = sPString + "";
            YesNo(sPString);

            ToClipboard(sPString);
        }

        /// <summary>
        ///  Execute a Sql Select query for mysql or foxpro
        /// </summary>
        public static DataSet gQuery(string sPQuery, DataSource sdPCursor, int noRec = 0, int count = 0, bool bFoxpro = false)
        {
            string slpMySQLQuery;

            if (DataOverride == (int)EData.mysql)
            {
                bFoxpro = false;
            }

            slpMySQLQuery = sPQuery;

            if (!bFoxpro)
            {
                slpMySQLQuery = Replace(slpMySQLQuery, "~", "");
                slpMySQLQuery = Replace(slpMySQLQuery, "$", "LIKE");
                if (count != 0)
                {
                    slpMySQLQuery = slpMySQLQuery + " limit " + noRec + ", " + count;
                }
                if ((sdPCursor.ds = DB_VIVA.HExecuteSQLQueryDataSet(slpMySQLQuery)) == null)
                {
                    glog_error("ERROR SQL" + "SQL Error" + slpMySQLQuery + "data_syorg.constructor");
                }
                else
                {
                    sdPCursor.result = sdPCursor.ds.Tables[0].CreateDataReader().Cast<IDataRecord>().ToList();
                }
            }
            else
            {
                if ((sdPCursor.ds = gFoxproSQL(Replace(sPQuery, "~=", "=="), sdPCursor, noRec, count)) == null)
                {
                    glog_error("ERROR DBF" + "DBF Error" + slpMySQLQuery + "data_syorg.constructor");

                }

                //mysql_foxpro.mysql_status = "xWAITING";

                //if (!HAdd(mysql_foxpro))
                //{
                //    glog_error("ERROR SQL" + "SQL Error " + mysql_foxpro.mysql_foxpro + " data_syorg.constructor");

                //    return false;
                //}

                if (!gStayAlive)
                {
                    gDisconnect();
                }
            }

            return sdPCursor.ds;
        }

        /// <summary>
        ///  Execute a Sql query (insert, update delete) for mysql or foxpro
        /// </summary>
        public static bool gQuery(string sPQuery, bool bFoxpro = false)
        {
            string slpMySQLQuery;
            long LastInsertedId = 0;

            if (DataOverride == (int)EData.mysql)
            {
                bFoxpro = false;
            }

            slpMySQLQuery = sPQuery;
            

            if (!bFoxpro)
            {
                slpMySQLQuery = Replace(slpMySQLQuery, "~", "");
                if ((LastInsertedId = DB_VIVA.HExecuteSQLNonQuery(slpMySQLQuery)) == 0)
                {
                    glog_error("ERROR SQL" + "SQL Error" + slpMySQLQuery + "data_syorg.constructor");

                    return false;
                }
            }
            else
            {
                if (!gFoxproNonSQL(Replace(sPQuery, "~=", "==")))
                {
                    glog_error("ERROR DBF" + "DBF Error" + slpMySQLQuery + "data_syorg.constructor");

                    return false;
                }

                if (!gStayAlive)
                {
                    gDisconnect();
                }
            }

            return true;
        }

        public static bool gFirst(DataSource sdPCursor, string sOrderBy = "")
        {
            return HReadFirst(sdPCursor, sOrderBy);  //!HOut(sdPCursor);
        }

        public static void gMsgBox(string sPText1, string sPText2 = "")
        {
            if (sPText2 == "WINDOW NOWAIT")
            {
                gMessageBox gMessage = new gMessageBox("", sPText1, 500);
            }
            else if(Contains(sPText2, "TIME"))
            {
                int second = Convert.ToInt32(sPText2.Split(' ')[1].ToString()) * 1000;
                gMessageBox gMessage = new gMessageBox("", sPText1, second);
            }
            else
            {
                MESSAGEBOX(sPText1, 0, "");
            }
            //YesNo(sPText1, sPText2);
        }

        public static string IIF(bool bTrue, string pValueTrue, string pValueFalse)
        {
            return IIF(bTrue, pValueTrue as object, pValueFalse as object).ToString();
        }

        public static object IIF(bool bTrue, object pValueTrue, object pValueFalse)
        {
            if (bTrue)
            {
                return pValueTrue;
            }

            return pValueFalse;
        }

        /// <summary>
        ///  Execute a Foxpro Sql Select query
        /// </summary>
        public static DataSet gFoxproSQL(string sPQuery, DataSource sdPCursor, int noRec = 0, int count = 0)
        {
            DllFoxpro foxpro = new DllFoxpro();
            sdPCursor.result = null;
            try
            {
                sdPCursor.ds = new DataSet();
                sdPCursor.ds = foxpro.ExecuteQuery(sPQuery, noRec, count);
                foreach (DataTable table in sdPCursor.ds.Tables)
                {
                    sdPCursor.result = table.CreateDataReader().Cast<IDataRecord>().ToList();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            
            return sdPCursor.ds;
        }

        /// <summary>
        ///  Execute a Foxpro Sql query (insert, update delete)
        /// </summary>
        public static bool gFoxproNonSQL(string sPQuery)
        {
            DllFoxpro foxpro = new DllFoxpro();
            try
            {
                foxpro.ExecuteNonQuery(sPQuery);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static string gQ2(string pText)
        {
            string sPDQuote = "\"\"";

            return sPDQuote + Replace(pText, sPDQuote, sPDQuote + sPDQuote) + sPDQuote;
        }

        public static string Q2(string pText)
        {
            string sPDQuote = "\""+ pText + "\"";

            return sPDQuote;
        }

        public static string gSaveRow(DataSource sdPTable, string sPAction = "SMART_SAVE", int iPType = -1)
        {
            sPAction = Lower(sPAction);
            
            string sLOperationSQL = "";

            if (iPType == -1)
            {
                iPType = gIPType;
            }

            if (Upper(sPAction) == "SMART_SAVE")
            {
                sPAction = "update";
            }

            if (iPType == 1 || iPType == 2)
            {
                string sLHashValues = gCreateHashValues(sdPTable);

                if (sPAction == "insert")
                {
                    sLOperationSQL = gCreateInsertFoxpro(sdPTable);
                }
                else
                {
                    if (sPAction == "update")
                    {
                        sLOperationSQL = gCreateUpdateFoxpro(sdPTable);
                    }
                    else if (sPAction == "delete")
                    {
                        sLOperationSQL = gCreateDeleteFoxpro(sdPTable);
                    }

                    HReset(mysql_foxpro);

                    mysql_foxpro.Mysql_Foxpro = sLOperationSQL;
                    mysql_foxpro.Mysql_Table = sdPTable.i.name;
                    mysql_foxpro.Mysql_Status = "WAITING";
                    mysql_foxpro.Mysql_Hash_Values = sLHashValues;
                    mysql_foxpro.Foxpro_Ai_Field = gGetFoxAI(sdPTable);

                    if (!HAdd(mysql_foxpro))
                    {
                        return "ERROR_1";
                    }

                    // SECTION: Reload the row, once it has been updated || inserted

                    WAIT(25);

                    // NOTE: Reload foxpro record to get updated foxpro information
                    HReadSeek(mysql_foxpro, mysql_foxpro.Ident_Ai);

                    if (!HFound(mysql_foxpro))
                    {
                        return "ERROR_2";

                    }
                    else
                    {

                        // NOTE: if foxpro has not processed the record yet, change status to windev-abandon
                        if (mysql_foxpro.Mysql_Status != "DONE")
                        {
                            mysql_foxpro.Mysql_Status = "WINDEV-ABANDON";

                            HModify(mysql_foxpro);
                            return "ERROR_3";

                        }

                        // NOTE:  if foxpro has an auto increase value, { find the corresponding record (if being deleted)
                        if (mysql_foxpro.Foxpro_Ai_Value > 0)
                        {
                            HReadSeek(sdPTable, mysql_foxpro.Foxpro_Ai_Field + "", mysql_foxpro.Foxpro_Ai_Value + 0);

                            if (HFound(sdPTable))
                            {
                                if (sPAction == "delete")
                                {
                                    return "ERROR_MYSQL_ROW_FOUND_AFTER_DELETE";
                                }
                            }
                            else if (sPAction != "delete")
                            {
                                return "ERROR_MYSQL_ROW_NOT_FOUND";
                            }
                        }
                        else
                        {
                            // NOTE: Refresh the table using the primary keys that were originally used
                            if (!gGetRowRefresh(sdPTable))
                            {
                                return "ERROR_MYSQL_ROW_NOT_FOUND";
                            }
                        }
                    }

                    // NOTE: Process the regular inserts if the DBF does not need to be udpated
                    if (iPType == 0 || iPType == 1)
                    {
                        if (sPAction == "insert")
                        {
                            if (!HAdd(sdPTable))
                            {
                                return "ERROR_4";
                            }
                        }
                        else if (sPAction == "update")
                        {

                            if (!HModify(sdPTable))
                            {
                                return "ERROR_5";
                            }
                        }
                        else if (sPAction == "delete")
                        {
                            if (!HDelete(sdPTable))
                            {
                                return "ERROR_6";
                            }
                        }
                    }
                }
            }
            return "";
        }

        public static string gCreateHashValues(DataSource sdPTable)
        {
            string sLHashValues = "";

            if (gGetFields(sdPTable, ref fields_table))
            {
                sLHashValues = "TABLE: " + sdPTable.i.name + "|";

                do
                {
                    if (Lower(fields_table.Column_Name) != "idhash" &&
                        Lower(fields_table.Column_Name) != "timestamp")
                    {
                        sLHashValues = sLHashValues + gCR();

                        sLHashValues = sLHashValues + Lower(fields_table.Column_Name) + ": ";

                        sLHashValues = sLHashValues + gFoxproValue(sdPTable.GetColumn(fields_table.Column_Name, "").ToString(), fields_table.Data_Type, sdPTable.i.name + "." + fields_table.Column_Name) + "|";
                    }

                } while (gNext(fields_table));
            }

            return sLHashValues;

        }

        public static bool gGetFields(DataSource sdPTable, ref data_fields_table sdPFieldsTable)
        {
            string sLSQL = "SELECT `TABLE_NAME`, `COLUMN_NAME`, `DATA_TYPE`, `COLUMN_COMMENT`, `COLUMN_KEY`, primary_1, primary_2, primary_3 FROM `INFORMATION_SCHEMA`.`COLUMNS` JOIN mysql_proc ON mysql_proc.tablename = " + gQ1(sdPTable.i.name) + " WHERE `TABLE_SCHEMA`=" + gQ1(gsDatabase) + " AND `TABLE_NAME`=" + gQ1(sdPTable.i.name); //+ " ORDER BY COLUMN_NAME ";

            gQuery(sLSQL, sdPFieldsTable);

            //if (gFirst(sdPFieldsTable))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        public static List<data_fields_table> GetFields(string sdPTable)
        {
            string sLSQL = "SELECT `TABLE_NAME`, `COLUMN_NAME`, `DATA_TYPE`, `COLUMN_COMMENT`, `COLUMN_KEY`, IS_NULLABLE, primary_1, primary_2, primary_3 FROM `INFORMATION_SCHEMA`.`COLUMNS` LEFT JOIN mysql_proc ON mysql_proc.tablename = " + gQ1(sdPTable) + " WHERE `TABLE_SCHEMA`=" + gQ1(gsDatabase) + " AND `TABLE_NAME`=" + gQ1(sdPTable); //+ " ORDER BY COLUMN_NAME ";

            data_fields_table sdPFieldsTable = new data_fields_table();
            gQuery(sLSQL, sdPFieldsTable);

            List<data_fields_table> data_Fields = new List<data_fields_table>();

            for (int i = 0; i < sdPFieldsTable.result.Count; i++)
            {
                data_Fields.Add(new data_fields_table());

                data_Fields[i].LoadRow(sdPFieldsTable.result[i]);
            }

            return data_Fields;
        }

        public static bool gNext(DataSource sdPCursor)
        {
            return HReadNext(sdPCursor); 
        }

        public static bool IsLast(DataSource sdPCursor)
        {
            if (sdPCursor.noCurrent >= sdPCursor.RECCOUNT() - 1)
            {
                return true;
            }

            return false;
        }

        public static string gFoxproValue(object PFieldValue, string sPFieldType, string sPFieldName)
        {
            sPFieldType = Lower(sPFieldType);

            if (sPFieldType == "date" || sPFieldType == "datetime")
            {
                if (PFieldValue.ToString() == "" || PFieldValue == null)
                {
                    return "{}";
                }

                if (sPFieldType == "datetime")
                {
                    DateTime dtDateTime = (DateTime)PFieldValue;

                    return "DATETIME(" + String.Format("{0:yyyy, MM, dd, HH, mm, ss}", PFieldValue) + ")";
                }
                else
                {
                    return "DATE(" + String.Format("{0:yyyy, MM, dd}", PFieldValue) + ")";
                }
            }
            else
            {
                if (sPFieldType == "bit")
                {

                    if (PFieldValue == null)
                    {
                        return ".F."; // return ".NULL." // FOXPRO PROGRAM RARELY USES  NULLS
                    }

                    if (PFieldValue.ToString() == "")
                    {
                        return ".F.";

                    }

                    if ((bool)PFieldValue == false)
                    {
                        return ".F.";
                    }
                    else
                    {
                        return ".T.";
                    }

                }
                else
                {
                    if (Contains(sPFieldType, "tinyint"))
                    {

                        if (PFieldValue == null)
                        {
                            return "0"; // return ".NULL." // FOXPRO PROGRAM RARELY USES  NULLS

                        }

                        // is numeric
                        //return "ifBool(" + gQ2(sPFieldName) + ", " + PFieldValue + ")";
                        return PFieldValue.ToString();

                    }
                    else
                    {
                        if (Contains(sPFieldType, "int") || sPFieldType == "decimal" || sPFieldType == "bigint")
                        {
                            if (PFieldValue == null)
                            {
                                return "0"; // return ".NULL." // FOXPRO PROGRAM RARELY USES  NULLS
                            }

                            // is numeric
                            return PFieldValue.ToString();
                        }
                        else
                        {

                            // Only character fields should be left
                            if (PFieldValue == null)
                            {
                                return ""; // return ".NULL." // FOXPRO PROGRAM RARELY USES  NULLS

                            }

                            PFieldValue = gQ1(PFieldValue + "");

                            PFieldValue = Replace(PFieldValue.ToString(), Charact(13), "");

                            PFieldValue = Replace(PFieldValue.ToString(), Charact(10), "' + CHR(13) + CHR(10) + '");  // "' + CHR(13) + CHR(10) + " + gCR() + "'"

                            return PFieldValue.ToString();
                        }
                    }
                }
            }
        }

        public static void gCallDLL32(string sParam1, string sParam2, string sParam3)
        {
            //WIP// CallDLL32(UnicodeToAnsi(sParam1), UnicodeToAnsi(sParam2), UnicodeToAnsi(sParam3));
        }

        public static string gCreateInsertFoxpro(DataSource sdPTable)
        {
            if (gGetFields(sdPTable, ref fields_table))
            {
                string sLSQL = "INSERT INTO " + sdPTable.i.name + " " + gCR();

                string sLColumnNames = "";

                string sLColumnValues = "";

                do
                {
                    // do not insert idhash, timestamp and skip_insert fields (foxpro auto keys)
                    if (Lower(fields_table.Column_Name) != "idhash" &&
                        Lower(fields_table.Column_Name) != "timestamp" &&
                        Lower(fields_table.Column_Name) != "ident_fox" &&
                        Lower(fields_table.Column_Name) != "ident_ai" &&
                        !Contains(Lower(fields_table.Column_Comment), "fox_ai") &&
                        !Contains(Lower(fields_table.Column_Comment), "skip_insert"))
                    {

                        if (sLColumnNames != "")
                        {
                            sLColumnNames = sLColumnNames + ",  " + gCR();

                            sLColumnValues = sLColumnValues + ",  " + gCR();
                        }

                        sLColumnNames = sLColumnNames + Lower(fields_table.Column_Name);

                        sLColumnValues = sLColumnValues + gFoxproValue(sdPTable.GetColumn(fields_table.Column_Name, ""), fields_table.Data_Type, sdPTable.i.name + "." + fields_table.Column_Name);
                    }

                } while (gNext(fields_table));

                return Replace(sLSQL + "(" + sLColumnNames + ") VALUES (" + sLColumnValues + ")", gCR(), ";" + gCR());

            }

            return "";
        }

        public static string gCreateUpdateFoxpro(DataSource sdPTable)
        {
            if (gGetFields(sdPTable, ref fields_table))
            {
                string sLSQL = "UPDATE " + sdPTable.i.name + " SET  " + gCR();

                string sLUpdate = "";

                string sLWhere = gGetWhere(sdPTable, fields_table);

                foreach (IDataRecord Data in fields_table.result)
                {
                    fields_table.SetProperty("COLUMN_NAME", Data["COLUMN_NAME"]);
                    fields_table.SetProperty("DATA_TYPE", Data["DATA_TYPE"]);
                    fields_table.SetProperty("COLUMN_COMMENT", Data["COLUMN_COMMENT"]);

                    // do not update idhash, timestamp and primary keys
                    if (Lower(fields_table.Column_Name) != "idhash" &&
                            Lower(fields_table.Column_Name) != "timestamp" &&
                            Lower(fields_table.Column_Name) != "ident_fox" &&
                            !Contains(Lower(fields_table.Column_Comment), "fox_ai") &&
                            !Contains(Lower(fields_table.Column_Comment), "skip_update") &&
                            !Contains(Lower(fields_table.Column_Key), "pri"))
                    {

                        if (sLUpdate != "")
                        {
                            sLUpdate = sLUpdate + ",  " + gCR();
                        }

                        sLUpdate = sLUpdate + sdPTable.i.name + "." + Lower(fields_table.Column_Name) + " = ";

                        sLUpdate = sLUpdate + gFoxproValue(sdPTable.GetColumn(fields_table.Column_Name, ""), fields_table.Data_Type, sdPTable.i.name + "." + fields_table.Column_Name);
                    }
                }

                // return sLSQL + sLUpdate + sLWhere
                return Replace(sLSQL + sLUpdate + sLWhere, gCR(), ";" + gCR());
            }

            return "";
        }

        public static string gCreateInsert(DataSource sdPTable)
        {
            string tablename = sdPTable.i.name;
            bool isFoxpro = sdPTable.isFoxpro;

            List<data_fields_table> data_Fields = GetFields(tablename);

            string sLSQL = "INSERT INTO " + tablename + " ";  // + gCR();

            string sLColumnNames = "";

            string sLColumnValues = "";

            foreach (data_fields_table fields_table in data_Fields)
            {
                string fieldname = Lower(fields_table.Column_Name);
                string comment = Lower(fields_table.Column_Comment);
                // do not insert idhash, timestamp and fox_ai
                if (fieldname != "idhash" &&
                        fieldname != "timestamp" &&
                        fieldname != "ident_fox" &&
                        !Contains(Lower(comment), "fox_ai"))
                {
                    if(!Contains(Lower(comment), "fox_ai"))
                    {
                        DataSource NextId = new DataSource();
                        gQuery("SELECT MAX("+sdPTable.i.primary_1+")+1 AS next_id FROM "+sdPTable.i.name, NextId, 0, 0, sdPTable.isFoxpro);
                        lastInsertId = NextId.result[0]["next_id"];
                        sdPTable.SetProperty(ToTitleCase(sdPTable.i.primary_1), lastInsertId);
                    }

                    if (sLColumnNames != "")
                    {
                        sLColumnNames += ",  "; // + gCR();
                        sLColumnValues += ",  "; // + gCR();
                    }

                    
                    //à mettre dans fonction séparer
                    if (isFoxpro)
                    {
                        sLColumnNames += Lower(fieldname);
                        sLColumnValues += gFoxproValue(sdPTable.GetColumn(ToTitleCase(fieldname), ""), fields_table.Data_Type, tablename + "." + fieldname);
                    }
                    else
                    {
                        sLColumnNames += sdPTable.i.name + "." + Lower(fieldname);

                        if (sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(int) ||
                            sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(bool) ||
                            sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(byte) ||
                            sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(decimal)||
                            sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(long))
                        {
                            sLColumnValues += sdPTable.GetColumn(ToTitleCase(fieldname), "");
                        }
                        else
                        {
                            sLColumnValues += gQ1(sdPTable.GetColumn(ToTitleCase(fieldname), "").ToString());
                        }
                    }
                    //*****************************//
                }

            }

            return sLSQL + "(" + sLColumnNames + ") VALUES (" + sLColumnValues + ")";

        }

        public static string gCreateUpdate(DataSource sdPTable)
        {
            List<data_fields_table> data_Fields = GetFields(sdPTable.i.name);

            string sLSQL = "UPDATE " + sdPTable.i.name + " SET  ";// + gCR();

            string sLUpdate = "";

            string sLWhere = gGetWhere(sdPTable);
            IDataRecord data = sdPTable.result[0];

            foreach (data_fields_table Data in data_Fields)
            {
                string fieldname = Lower(Data.Column_Name);

                // do not update idhash, timestamp and primary keys
                if (fieldname != "idhash" &&
                        fieldname != "timestamp" &&
                        fieldname != "ident_fox" &&
                        fieldname != sdPTable.i.primary_1)
                {

                    if (sLUpdate != "")
                    {
                        sLUpdate = sLUpdate + ",  ";// + gCR();
                    }

                    sLUpdate += sdPTable.i.name + "." + fieldname + " = ";

                    //à mettre dans fonction séparer
                    if (sdPTable.isFoxpro)
                    {
                        sLUpdate += gFoxproValue(sdPTable.GetColumn(ToTitleCase(fieldname), ""), Data.Data_Type, sdPTable.i.name + "." + fieldname);
                    }
                    else
                    { 
                        if (sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(int) ||
                            sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(bool) ||
                            sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(byte) ||
                            sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(decimal)||
                             sdPTable.GetColumn(ToTitleCase(fieldname), "").GetType() == typeof(long))
                        {
                            sLUpdate += sdPTable.GetColumn(ToTitleCase(fieldname), "");
                        }
                        else
                        {
                            sLUpdate += gQ1(sdPTable.GetColumn(ToTitleCase(fieldname), "").ToString());
                        }
                    }
                    //************************//
                }
            }

            
            return sLSQL + sLUpdate + sLWhere;

        }

        public static string gCreateDelete(DataSource sdPTable)
        {
            return "DELETE FROM " + sdPTable.i.name + gGetWhere(sdPTable);
        }

        public static string gGetWhere(DataSource sdPTable, data_fields_table sdLFieldsTable)
        {
            string sLPrimary_1 = sdLFieldsTable.Primary_1;
            string sLPrimary_2 = sdLFieldsTable.Primary_2;
            string sLPrimary_3 = sdLFieldsTable.Primary_3;
            string sLWhere = " WHERE ";

            if (sLPrimary_1 == "")
            {
                sLPrimary_1 = "ident";
            }

            sLWhere = sLWhere + sLPrimary_1 + " = " + sdPTable.GetPrimary_1();

            if (sdLFieldsTable.Primary_2 != "")
            {
                sLWhere = sLWhere + " AND " + sdLFieldsTable.Primary_2 + " = " + sdPTable.GetPrimary_2();
            }

            if (sdLFieldsTable.Primary_3 != "")
            {
                sLWhere = sLWhere + " AND " + sdLFieldsTable.Primary_3 + " = " + sdPTable.GetPrimary_3();
            }

            return sLWhere;

        }

        public static string gGetWhere(DataSource sdPTable)
        {
            string sLPrimary_1 = sdPTable.i.primary_1;
            string sLPrimary_2 = sdPTable.i.primary_2;
            string sLPrimary_3 = sdPTable.i.primary_3;
            string sLWhere = " WHERE ";

            if (sLPrimary_1 == "")
            {
                sLPrimary_1 = "ident";
            }

            sLWhere = sLWhere + sLPrimary_1 + " = " + sdPTable.GetPrimary_1();

            if (sLPrimary_2 != null)
            {
                sLWhere = sLWhere + " AND " + sdPTable.i.primary_2 + " = " + sdPTable.GetPrimary_2();
            }

            if (sLPrimary_3 != null)
            {
                sLWhere = sLWhere + " AND " + sdPTable.i.primary_3 + " = " + sdPTable.GetPrimary_3();
            }

            return sLWhere;

        }

        public static string gQ1s(string sPText)
        {
            return "'" + Replace(sPText, "'", "\'") + "'";
        }

        public static string gCR()
        {
            return CR;
        }

        public static int? gGet_next_id(string pTableID)
        {
            int? lnext_value;

            HReadSeek(wsseq, "tableid", pTableID);

            if (HFound(wsseq))
            {
                wsseq.Next_Id = wsseq.Next_Id + 1;

                lnext_value = wsseq.Next_Id;

                gSaveRow(wsseq, "update");

            }
            else
            {
                lnext_value = 1;

                wsseq.Tableid = pTableID;
                wsseq.Next_Id = lnext_value;
                gSaveRow(wsseq, "insert");
            }

            return lnext_value;
        }

        public static string MD5(string sPString)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(sPString);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static string gGetFoxAI(DataSource sdPTable)
        {
            if (gGetFields(sdPTable, ref fields_table))
            {
                do
                {
                    if (Contains(Lower(fields_table.Column_Comment), "fox_ai") || Lower(fields_table.Column_Name) == "ident_ai")
                    {
                        return fields_table.Column_Name;
                    }

                } while (gNext(fields_table));

                return "";
            }
            return "";
        }

        public static string gCreateDeleteFoxpro(DataSource sdPTable)
        {
            if (gGetFields(sdPTable, ref fields_table))
            {
                return "DELETE FROM " + sdPTable.i.name + gGetWhere(sdPTable, fields_table);
            }

            return "";
        }

        public static bool gGetRow(DataSource sdPTable, object vPrimary1, object vPrimary2 = null, object vPrimary3 = null)
        {
            //WIP//
            if (gGetFields(sdPTable, ref fields_table))
            {
                string sLPrimary_1 = fields_table.Primary_1;

                if (sLPrimary_1 == "")
                {
                    sLPrimary_1 = "ident";
                }

                if (vPrimary3 != null)
                {
                    // HReadSeekFirst(sdPTable, PRIMARY, ValCompKey);
                    return HFound(sdPTable);
                }
                else if (vPrimary2 != null)
                {
                    // HReadSeekFirst(sdPTable, PRIMARY, ValCompKey);
                    return HFound(sdPTable);
                }
                else
                {
                    // HReadSeekFirst(sdPTable, sLPrimary_1, vPrimary1);
                    return HFound(sdPTable);
                }
            }
            return false;
        }


        public static bool gGetRowRefresh(DataSource sdPTable)
        {

            if (gGetFields(sdPTable, ref fields_table))
            {
                string sLPrimary_1 = fields_table.Primary_1;
                string sLPrimary_2 = fields_table.Primary_2;
                string sLPrimary_3 = fields_table.Primary_3;

                if (sLPrimary_1 == "")
                {
                    sLPrimary_1 = "ident";
                }

                if (fields_table.Primary_3 != "")
                {
                    return gGetRow(sdPTable, sdPTable.GetPrimary_1(), sdPTable.GetPrimary_2(), sdPTable.GetPrimary_3());
                }
                else if (fields_table.Primary_2 != "")
                {
                    return gGetRow(sdPTable, sdPTable.GetPrimary_1(), sdPTable.GetPrimary_2());
                }
                else
                {
                    return gGetRow(sdPTable, sdPTable.GetPrimary_1());
                }
            }

            return false;
        }

        public static void gTesting()
        {


        }

        public static string gCreateFoxMysql_proc()
        {

            string vLMyTable = "";
            string lReturn = "";

            data_mysql_proc mysql_proc = new data_mysql_proc();

            gQuery("SELECT * FROM mysql_proc WHERE tablename = 'ivenformat' ", mysql_proc);
     
            // mysql_proc.Tablename = "mysql_proc";

            foreach (IDataRecord Data in mysql_proc.result)
            {
                mysql_proc.LoadRow(Data);

                vLMyTable = mysql_proc.Tablename;
                mysql_proc.i.name = "mysql_proc";

                if (gGetRow(mysql_proc, vLMyTable))
                {
                    Console.WriteLine("vLMyTable : " + vLMyTable + " Test.i.name : " + mysql_proc.i.name);
                    DataSource sdPTable;
                    sdPTable = GetDataSource(vLMyTable);
  
                    sdPTable.i.name = vLMyTable;
                    sdPTable.Table_name = vLMyTable;


                    mysql_proc.My_Hash = gCreateFoxProcess(sdPTable, "ifNULL(?WebDate(~#FIELD#~), '')", "?WebNum(~#FIELD#~)", "?WebText(~#FIELD#~)");
                    mysql_proc.My_Insert_Fields = gCreateFoxProcess(sdPTable, "`~#FIELD#~`", "`~#FIELD#~`", "`~#FIELD#~`");
                    mysql_proc.My_Insert_Values = gCreateFoxProcess(sdPTable, "?WebDate(~#FIELD#~)", "?WebNum(~#FIELD#~)", "TRIM(?~#FIELD#~)");
                    mysql_proc.My_Update = gCreateFoxProcess(sdPTable, "`~#FIELD#~`=?WebDate(~#FIELD#~)", "`~#FIELD#~`=?WebNum(~#FIELD#~)", "`~#FIELD#~`=TRIM(?~#FIELD#~)");

                    lReturn = mysql_proc.My_Hash;
                    gQuery("UPDATE mysql_proc SET my_hash='"+ mysql_proc.My_Hash + "' WHERE tablename='" + vLMyTable + "'");
                    gQuery("UPDATE mysql_proc SET my_insert_fields='" + mysql_proc.My_Insert_Fields + "' WHERE tablename='" + vLMyTable + "'");
                    gQuery("UPDATE mysql_proc SET my_insert_values='" + mysql_proc.My_Insert_Values + "' WHERE tablename='" + vLMyTable + "'");
                    gQuery("UPDATE mysql_proc SET my_update='" + mysql_proc.My_Update + "' WHERE tablename='" + vLMyTable + "'");

                }
            }

            Console.ReadKey();

            return lReturn;
        }

        public static bool gErr(string sPString)
        {
            return sPString.StartsWith("ERROR_");
        }

        public static string gCreateFoxProcess(DataSource sdPTable, string sPDate, string sPNumber, string sPString)
        {
            string sLValues = "";

            // fields_table.setup();

            if (gGetFields(sdPTable, ref fields_table))
            {
                string COLUMN_NAME = "column_name";
                string DATA_TYPE = "data_type";
                string COLUMN_COMMENT = "column_comment";

                foreach (IDataRecord Data in fields_table.result)
                {
                    fields_table.LoadRow(Data);

                    //fields_table.SetProperty(COLUMN_NAME, Data[COLUMN_NAME]);
                    //fields_table.SetProperty(DATA_TYPE, Data[DATA_TYPE]);
                    //fields_table.SetProperty(COLUMN_COMMENT, Data[COLUMN_COMMENT]);
                
                //do
                //{
                    string sPFieldType = Lower(fields_table.Data_Type);   //Lower(fields_table.result[0][1].ToString())
                    string sPFieldName = Lower(fields_table.Column_Name); // Lower(fields_table.result[0][0].ToString())

                    if (sPFieldName != "idhash" &&
                        sPFieldName != "timestamp" &&
                        !Contains(Lower(fields_table.Column_Comment), "data_too_big")) //Lower(fields_table.result[0][2].ToString())
                        
                    {
                        if (sLValues != "") { sLValues = sLValues + ", "; }

                        sLValues = sLValues + gCR();

                        if (sPFieldType == "date" || sPFieldType == "datetime")
                        {
                            sLValues = sLValues + Replace(sPDate, "~#FIELD#~", sPFieldName);
                        }
                        else if (Contains(sPFieldType, "int") || sPFieldType == "decimal")
                        {
                            sLValues = sLValues + Replace(sPNumber, "~#FIELD#~", sPFieldName);
                        }
                        else if (sPFieldType == "bit")
                        {
                            sLValues = sLValues + Replace(Replace(sPNumber, "~#FIELD#~", sPFieldName), "WebNum", "WebNum");
                        }
                        else if (Contains(sPFieldType, "blob"))
                        {
                            sLValues = sLValues + Replace(Replace(Replace(Replace(sPNumber, "~#FIELD#~", sPFieldName), "WebNum", ""), "(", ""), ")", "");
                        }
                        else
                        {
                            sLValues = sLValues + Replace(sPString, "~#FIELD#~", sPFieldName);
                        }
                    }
                    //} while (gNext(fields_table));
                }
            }
            else
            {
                return "ERROR_PROCESS";
            }
            return sLValues;
        }

        public static bool gLast(DataSource sdPCursor)
        {
            return HReadLast(sdPCursor);//HOut(sdPCursor);
        }

        public static bool gPrevious(DataSource sdPCursor)
        {
            HReadPrevious(sdPCursor); 
            return !HOut(sdPCursor);
        }

        public static bool IsFirst(DataSource sdPCursor)
        {
            if (sdPCursor.noCurrent <= 0)
            {
                return true;
            }

            return false;
        }

        public static bool gGo(DataSource sdPCursor, int lRecordId)
        {
            if (lRecordId <= RECCOUNT(sdPCursor))
            {
                if (lRecordId == 0)
                {
                    return gFirst(sdPCursor);
                }
                else
                {
                    gFirst(sdPCursor);
                }
                return HForward(sdPCursor, "", lRecordId);
            }
            else
            {
                return false;
            }
        }

        public static bool gSearch(DataSource sdPCursor, string sPFieldName, string sPSearchValue)
        {
            HReadSeekFirst(sdPCursor, sPFieldName, sPSearchValue);

            if (sdPCursor.Found() == true)
            {
                //WIP//FileToScreen();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static object GetObject(string sObjectName, string TheNameSpace = "vivael.")
        {
            return Activator.CreateInstance(Type.GetType(TheNameSpace + sObjectName));
        }

        public static string ToTitleCase(string str)
        {
            return ti.ToTitleCase(str);
        }
    }
}