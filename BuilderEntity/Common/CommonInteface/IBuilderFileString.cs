using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CommonInteface
{
    public interface IBuilderFileString
    {
        public  Task<Dictionary<string,string>> GetFileString(BuilderParameter Para);
    }
}
