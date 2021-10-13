using Common;
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
                string StrSqlQueryTable = SqlTemplate.GetSqlServerQueryTables();
                List<ClassEntity> tables = await _SqlServerDB.Read<ClassEntity>(StrSqlQueryTable);
                foreach (var table in tables)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(BuilderTemplate.GetDefaultUsing());
                    sb.Append(BuilderTemplate.GetNameSapce(_para.NameSapce));
                    sb.Append(BuilderTemplate.GetBalanceLeft());
                    sb.Append(BuilderTemplate.GetClassName(table.TableName));
                    sb.Append(BuilderTemplate.GetBalanceLeft(1));
                    string StrSqlQueryTableInfo = SqlTemplate.GetSqlServerQueryTableByTableName(table.TableName);
                    List<ColnumEntity> tb_colnums=await _SqlServerDB.Read<ColnumEntity>(StrSqlQueryTableInfo);
                    foreach (var colnum in tb_colnums)
                    {
                        if (colnum.ColType=="int")
                        {
                            sb.Append(BuilderTemplate.GetPropInt32(colnum.ColName));
                        }

                        if (colnum.ColType == "varchar" ||colnum.ColType=="nvarchar")
                        {
                            sb.Append(BuilderTemplate.GetPropString(colnum.ColName));
                        }
                        if (colnum.ColType == "datetime" || colnum.ColType == "date")
                        {
                            sb.Append(BuilderTemplate.GetPropDateTime(colnum.ColName));
                        }
                        if (colnum.ColType == "bool")
                        {
                            sb.Append(BuilderTemplate.GetPropBool(colnum.ColName));
                        }

                        if (colnum.ColType == "decimal")
                        {
                            sb.Append(BuilderTemplate.GetPropDouble(colnum.ColName));
                        }
                    }
                    sb.Append(BuilderTemplate.GetBalanceRight(1));
                    sb.Append(BuilderTemplate.GetBalanceRight());

                    if (Directory.Exists(_para.BuilderPath)==false)
                    {
                        Directory.CreateDirectory(_para.BuilderPath);
                    }
                    string filePath = Path.Combine(_para.BuilderPath,table.TableName+".cs");
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    using (FileStream fs=new FileStream(filePath,FileMode.Create,FileAccess.Write))
                    {
                        byte[] bys = Encoding.UTF8.GetBytes(sb.ToString());
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
