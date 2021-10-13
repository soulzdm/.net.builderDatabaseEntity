using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class BuilderTemplate
    {
        public static string GetDefaultUsing()
        {
            return "using System;\n" +
                   "using System.Threading.Tasks;\n" +
                    "using System.Text;\n" +
                    "using System.Linq;\n";
        }
        public static string GetNameSapce(string NameSpace)
        {
            return $"\n namespace {NameSpace} \n";
        }
        public static string GetBalanceRight(int blank=0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <blank; i++)
            {
                sb.Append('\t');
            }
            sb.Append(" }\n");
            return sb.ToString();
        }
        public static string GetBalanceLeft(int blank = 0)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < blank; i++)
            {
                sb.Append('\t');
            }
            sb.Append(" {\n");
            return sb.ToString();
        }

        public static string GetClassName(string ClassName)
        {
            return $"\t public class {ClassName}\n";
        }

        public static string GetPropString(string ColName)
        {
            StringBuilder sb = new StringBuilder("\t \t public string ");
            sb.Append(ColName);
            sb.Append("{ get; set; } \n");
            return sb.ToString();
        }
        public static string GetPropInt32(string ColName)
        {
            StringBuilder sb = new StringBuilder("\t \t public int ");
            sb.Append(ColName);
            sb.Append("{ get; set; } \n");
            return sb.ToString();
        }
        public static string GetPropBool(string ColName)
        {
            StringBuilder sb = new StringBuilder("\t \t public bool ");
            sb.Append(ColName);
            sb.Append("{ get; set; } \n");
            return sb.ToString();
        }

        public static string GetPropDateTime(string ColName)
        {
            StringBuilder sb = new StringBuilder("\t \t public DateTime ");
            sb.Append(ColName);
            sb.Append("{ get; set; } \n");
            return sb.ToString();
        }
        public static string GetPropDouble(string ColName)
        {
            StringBuilder sb = new StringBuilder("\t \t public double ");
            sb.Append(ColName);
            sb.Append("{ get; set; } \n");
            return sb.ToString();
        }
    }
}
