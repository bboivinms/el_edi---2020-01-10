using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static vivael.Globals;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Reflection;

namespace vivael
{

    //public interface data
    //{
    //    DataRow datarow { get; set; }
    //}

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
        public string Table_name { get; set; }
        public List<IDataRecord> result { get; set; }
        public List<IDataRecord> fields_result { get; set; } = null;
        public DataSourceInfo i = new DataSourceInfo();
        public bool isFoxpro;
        public string Fox_ai { get; set; } = "";
        public string MyQuery { get; set; } = "";
        public int noCurrent { get; set; }

        public object GetPrimary_1() { return this[ToTitleCase(i.primary_1)]; }
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
            try   {
                object test = GetType().GetProperty(PropertyName);

                Type type = GetType().GetProperty(PropertyName).PropertyType;

                if (type == typeof(int) || type == typeof(int?))
                {
                    if (PropertyValue == DBNull.Value) PropertyValue = 0;
                    PropertyValue = int.Parse(PropertyValue.ToString());
                }
                else if (type == typeof(decimal) || type == typeof(decimal?))
                {
                    if (PropertyValue == DBNull.Value) PropertyValue = 0;
                    PropertyValue = decimal.Parse(PropertyValue.ToString());
                }
                else if (type == typeof(byte) || type == typeof(byte?))
                {
                    PropertyValue = byte.Parse(PropertyValue.ToString());
                }
                else if (type == typeof(bool) || type == typeof(bool?))
                {
                    if (PropertyValue == DBNull.Value) PropertyValue = false;
                    PropertyValue = Convert.ToBoolean(PropertyValue);
                }
                else if (type == typeof(string))
                {
                    if(PropertyValue == DBNull.Value) PropertyValue = "";
                }

                GetType().GetProperty(PropertyName).SetValue(this, PropertyValue);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                return false;

            }
            return true;
        }

        public void Set<T>(ref T field, T value, string propertyName)
        {
            field = value;
            OnPropertyChanged(propertyName.ToUpper());
        }

        private void SetFieldsResults()
        {
            if (fields_result != null) return;
            fields_result = fields_table.result.Where(i => i["TABLE_NAME"].ToString() == Table_name).ToList();
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
                    name = ToTitleCase(this.result[0].GetName(i).ToLower());
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
                    name = ToTitleCase(DataRecord.GetName(i).ToLower());
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

        public int RECCOUNT()
        {
            if(MyQuery != "")
            {
                DataSource temp = new DataSource();
                gQuery(MyQuery, temp, 0, 0, isFoxpro);
                return temp.result.Count();
            }
            else if(result != null)
            {
                return result.Count();
            }
            else
            {
                return 0;
            }
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

        public string SaveRow(string sPAction)
        {
            string sLOperationSQL = "";

            if (sPAction == "insert")
            {
                sLOperationSQL = gCreateInsert(this);
            }
            else if(sPAction == "update")
            {
                sLOperationSQL = gCreateUpdate(this);
            }
            else if(sPAction == "delete")
            {
                sLOperationSQL = gCreateDelete(this);
            }

            if (sLOperationSQL != "")
                gQuery(sLOperationSQL, isFoxpro);

            return sLOperationSQL;
        }

        public void ResetProperties()
        {
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length-9; ++i)
            {
                if (properties[i].PropertyType == typeof(bool?) || properties[i].PropertyType == typeof(bool))
                {
                    properties[i].SetValue(this, false);
                }
                else if (properties[i].PropertyType == typeof(byte) || properties[i].PropertyType == typeof(byte?))
                {
                    properties[i].SetValue(this, Convert.ToByte(0));
                }
                else if (properties[i].PropertyType == typeof(int) || properties[i].PropertyType == typeof(int?))
                {
                    properties[i].SetValue(this, 0);
                }
                else if (properties[i].PropertyType == typeof(decimal) || properties[i].PropertyType == typeof(decimal?))
                {
                    properties[i].SetValue(this, Convert.ToDecimal(0));
                }
                else
                {
                    properties[i].SetValue(this, null);
                }
            }
        }
                

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
