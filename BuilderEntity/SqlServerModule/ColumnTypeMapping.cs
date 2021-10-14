using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerModule
{
    public class ColumnTypeMapping
    {
        public string Mapping(string colType,string colName)
        {
            string mappingType = string.Empty;
            switch (colType)
            {
                case "int":
                    mappingType =BuilderTemplate.GetPropInt32(colName);
                    break;
                case "varchar":
                case "nvarchar":
                    mappingType = BuilderTemplate.GetPropString(colName);
                    break;
                case "datetime":
                case "date":
                    mappingType = BuilderTemplate.GetPropDateTime(colName);
                    break;
                case "bool":
                    mappingType = BuilderTemplate.GetPropBool(colName);
                    break;
                case "decimal":
                    mappingType = BuilderTemplate.GetPropDouble(colName);
                    break;
                default:
                    break;
            }
            return mappingType;
        }
    }
}
