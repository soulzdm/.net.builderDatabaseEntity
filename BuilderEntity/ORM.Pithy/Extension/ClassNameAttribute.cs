using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Pithy
{
   public class ClassNameAttribute:AbsAttribute
    {
        public ClassNameAttribute(string name):base(name)
        {

        }
    }
}
