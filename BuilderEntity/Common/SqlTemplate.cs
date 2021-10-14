using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SqlTemplate
    {
        /// <summary>
        /// 查询sqlServer中包含的数据库
        /// </summary>
        /// <returns></returns>
        public static string GetSqlServerQueryDataBases()
        {
            return "select * from sysdatabases where name<>'master' and name<>'tempdb' and name<> 'model' and name<>'msdb';";
        }

        /// <summary>
        /// 查询数据库中包含的表
        /// </summary>
        /// <returns></returns>
        public static string GetSqlServerQueryTables()
        {
            return "SELECT Name as TableName FROM SysObjects Where XType='U' ORDER BY Name";
        }
        /// <summary>
        /// 查询数据库中包含的表名称
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>

        public static string GetSqlServerQueryTableByTableName(string TableName)
        {
            return "SELECT (case when a.colorder=1 then d.name else null end) TableName," +
              " a.colorder ID, a.name ColName," +
                 " (case when COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 then 1 else 0 end) ColIdentity," +
                " (case when(SELECT count(*) FROM sysobjects" +
                " WHERE(name in (SELECT name FROM sysindexes" +
                 " WHERE(id = a.id) AND(indid in" +
                 " (SELECT indid FROM sysindexkeys" +
                  " WHERE(id = a.id) AND(colid in" +
                 " (SELECT colid FROM syscolumns WHERE(id = a.id) AND(name = a.name))))))) " +
                " AND(xtype = 'PK'))> 0 then 1 else 0 end) ColKey,b.name ColType, a.length ColSize," +
                  " COLUMNPROPERTY(a.id, a.name, 'PRECISION') as ColLength, " +
                  " isnull(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0) as DigPlace,(case when a.isnullable = 1 then 1 else 0 end) IsEmpty, " +
                   " isnull(e.text, '') DefaultValue,isnull(g.[value], ' ') AS ColDesc" +
                   " FROM syscolumns a" +
                   "  join systypes b on a.xtype = b.xusertype" +
                   " inner join sysobjects d on a.id = d.id and d.xtype = 'U' and d.name <> 'dtproperties'" +
                   " left join syscomments e on a.cdefault = e.id" +
                   " left join sys.extended_properties g on a.id = g.major_id AND a.colid = g.minor_id" +
                    " left join sys.extended_properties f on d.id = f.class and f.minor_id=0" +
                    $" WHERE d.name= '{TableName}'" +
                      " order by a.id, a.colorder";
        }

        public static string GetMysqlQueryDataBases()
        {
            return "SHOW DATABASES;";
        }
        public static string GetMysqlQueryTables()
        {
            return "SHOW Tables;";
        }

        public static string GetMysqlQueryTableInfo(string TableName)
        {
            return $"DESC {TableName};";
        }
    }
}
