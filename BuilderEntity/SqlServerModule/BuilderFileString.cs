using Common;
using Common.CommonInteface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerModule
{
    public class BuilderFileString:IBuilderFileString
    {
        private readonly ColumnTypeMapping _map;
        public BuilderFileString()
        {
            _map = new ColumnTypeMapping();
        }
        public async Task<Dictionary<string,string>> GetFileString(BuilderParameter Para)
        {
            DBHepler _SqlServerDB=new DBHepler(Para.Ip, Para.DBName, Para.DBUser, Para.DBPassword);
            string StrSqlQueryTable = SqlTemplate.GetSqlServerQueryTables();
            List<ClassEntity> tables = await _SqlServerDB.Read<ClassEntity>(StrSqlQueryTable);
            Dictionary<string,string> sbs = new Dictionary<string, string>();
            foreach (var table in tables)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(BuilderTemplate.GetDefaultUsing());
                sb.Append(BuilderTemplate.GetNameSapce(Para.NameSapce));
                sb.Append(BuilderTemplate.GetBalanceLeft());
                sb.Append(BuilderTemplate.GetClassName(table.TableName));
                sb.Append(BuilderTemplate.GetBalanceLeft(1));
                string StrSqlQueryTableInfo = SqlTemplate.GetSqlServerQueryTableByTableName(table.TableName);
                List<ColnumEntity> tb_colnums = await _SqlServerDB.Read<ColnumEntity>(StrSqlQueryTableInfo);
                foreach (var colnum in tb_colnums)
                {
                    sb.Append(_map.Mapping(colnum.ColType,colnum.ColName));
                }
                sb.Append(BuilderTemplate.GetBalanceRight(1));
                sb.Append(BuilderTemplate.GetBalanceRight());
                sbs.Add(table.TableName,sb.ToString());
            }
            return sbs;
        }
    }
}
