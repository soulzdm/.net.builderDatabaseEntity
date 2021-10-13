using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BuilderParameter
    {
        //数据库Ip
        public string Ip { get; set; }
        /// <summary>
        /// 数据库登录名
        /// </summary>
        public string DBUser { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string DBName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string DBPassword { get; set; }
        /// <summary>
        /// 生成类的命名空间
        /// </summary>
        public string NameSapce { get; set; }//命名空间
        /// <summary>
        /// 生成类存放位置
        /// </summary>
        public string BuilderPath { get; set; }
        public DBType DbType { get; set; }
    }
    public enum DBType { SqlServer=0,Mysql=1}
}
