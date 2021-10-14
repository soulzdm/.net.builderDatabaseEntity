using Common;
using Common.CommonInteface;
using SqlServerModule;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBuilderEntity
{
   
    public class BuilderSqlServer
    {
        private readonly DBHepler _SqlServerDB;
        private readonly BuilderParameter _para;
        public  BuilderSqlServer(BuilderParameter para)
        {
            _SqlServerDB = new DBHepler(para.Ip,para.DBName,para.DBUser,para.DBPassword);
            _para = para;
        }

        public async Task BuilderEntityByDBTable()
        {
            try
            {
                Dictionary<string,string> fileContentStrings;
                IBuilderFileString Builder;
                switch (_para.DbType)
                {
                    case DBType.SqlServer:
                        Builder = new BuilderFileString();
                        fileContentStrings = await Builder.GetFileString(_para);
                        break;
                    case DBType.Mysql:
                        fileContentStrings = new Dictionary<string,string>();
                        break;
                    default:
                        fileContentStrings = new Dictionary<string,string>();
                        break;
                }

                foreach (var item in fileContentStrings)
                {
                   

                    if (Directory.Exists(_para.BuilderPath)==false)
                    {
                        Directory.CreateDirectory(_para.BuilderPath);
                    }
                    string filePath = Path.Combine(_para.BuilderPath,item.Key+".cs");
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    using (FileStream fs=new FileStream(filePath,FileMode.Create,FileAccess.Write))
                    {
                        byte[] bys = Encoding.UTF8.GetBytes(item.Value.ToString());
                        await fs.WriteAsync(bys);
                        fs.Flush();
                        fs.Close();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
