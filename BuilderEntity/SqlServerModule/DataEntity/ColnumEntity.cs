using ORM.Pithy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerModule
{
    [ColName("ColnumTable")]
    public class ColnumEntity
    {
        public string TableName { get; set; }
        public bool ColIdentity { get; set; }
        public int ID { get; set; }
        public string ColName { get; set; }
        public bool ColKey { get; set; }
        public string ColType { get; set; }
        public int ColSize { get; set; }//占用字节数
        public int ColLength { get; set; }//长度
        public int DigPlace { get; set; }//小数位数
        public bool IsEmpty { get; set; }//是否可空
        public string DefaultValue { get; set; }
        public string ColDesc { get; set; }
    }
}
