using Common;
using ManagerBuilderEntity;
using MySqlConnector;
using SqlServerModule;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("\t你好，\nsadsadf");
            // string dic =Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Test");
            //if (Directory.Exists(dic) == false)
            //{
            //    Directory.CreateDirectory(dic);
            //}
            //string filepath = Path.Combine(dic, "test.cs");
            //FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);

            //StringBuilder sb = new StringBuilder();
            //sb.Append("using ORM.Pithy;\n");
            //sb.Append("using System;\n");
            //sb.Append("using System.Threading.Tasks;\n");
            //sb.Append("using System.Text;\n");
            //sb.Append("using System.Linq\n");
            //sb.Append("\n");
            //sb.Append("namespace SqlServerModule.DataEntity \n");
            //sb.Append("{\n");
            //sb.Append("public class ClassEntity\n");
            //sb.Append("\t{\n");
            //sb.Append("\t\tpublic string TableName { get; set; }\n");
            //sb.Append("\t}\n");
            //sb.Append("}\n");
            //byte [] bys=Encoding.UTF8.GetBytes(sb.ToString());
            //fs.Write(bys,0,bys.Length);
            //fs.Flush();
            //fs.Close();

            //BuilderSqlServer builderSqlServer = new BuilderSqlServer(
            //new BuilderParameter() { 
            //NameSapce= "ConsoleApp",
            //BuilderPath=Path.Combine(@"F:\MyProject\C#\WndowsFrom\BuilderEntity\ConsoleApp\Entity"),
            //DBName="test",
            //Ip=".",
            //DBPassword="123456",
            //DbType=DBType.Mysql,
            //DBUser="sa"
            //});
            string StrCon = "server=127.0.0.1;user=root;pwd=123456";
            MySqlConnection connection = new MySqlConnection(StrCon);
            connection.Open();
            MySqlCommand com = new MySqlCommand("show databases;",connection);
            MySqlDataReader ReadData = com.ExecuteReader();
            while (ReadData.Read())
            {
                Console.WriteLine(ReadData["DataBase"].ToString());
            }
            ReadData.Close();
            ReadData.Dispose();
            com.Dispose();
            connection.Close();
            //await builderSqlServer.BuilderEntityByDBTable();
        }
    }
}
