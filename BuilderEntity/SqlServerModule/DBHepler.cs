using ORM.Pithy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerModule
{
    public class DBHepler
    {
        private readonly SqlConnection Connection;
        public DBHepler(string IP,string DBName,string UserName,string Password)
        {
            string StrCon = $"Server={IP} ;User Id={UserName};Pwd= {Password};DataBase={DBName}";
            Connection = new SqlConnection(StrCon);
        }

        public async Task<List<T>> Read<T>(string sql)
        {
            OpenConnection();
            Type t = typeof(T);
            SqlCommand com = new SqlCommand(sql,Connection);
            SqlDataReader dataRead = com.ExecuteReader();
            List<T> Data = new List<T>();
            while (dataRead.Read())
            {
             object obj=Activator.CreateInstance(t);
                foreach (var item in t.GetProperties())
                {
                    if (item.PropertyType==typeof(int))
                    {
                        int res;
                        int.TryParse(dataRead[item.GetColName()].ToString(),out res);
                        item.SetValue(obj, res);
                    }
                    else if (item.PropertyType==typeof(string))
                    {
                        item.SetValue(obj,dataRead[item.GetColName()].ToString());
                    }
                    else if (item.PropertyType == typeof(bool))
                    {
                        bool res;
                        bool.TryParse(dataRead[item.GetColName()].ToString(),out res);
                        item.SetValue(obj, res);
                    }
                    else if (item.PropertyType == typeof(DateTime))
                    {
                        DateTime res;
                        DateTime.TryParse(dataRead[item.GetColName()].ToString(), out res);
                        item.SetValue(obj, res);
                    }
                    else if (item.PropertyType == typeof(Double))
                    {
                        double res;
                        double.TryParse(dataRead[item.GetColName()].ToString(), out res);
                        item.SetValue(obj, res);
                    }

                    else if (item.PropertyType == typeof(decimal))
                    {
                        decimal res;
                        decimal.TryParse(dataRead[item.GetColName()].ToString(), out res);
                        item.SetValue(obj, res);
                    }
                }
             Data.Add((T)obj);
            }
            com.Dispose();
            await dataRead.DisposeAsync();
            CloseConnection();
            return Data;
        }

        public void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
            if (System.Data.ConnectionState.Broken==Connection.State)
            {
                Connection.Close();
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
                Connection.Close();
        }
    }
}
