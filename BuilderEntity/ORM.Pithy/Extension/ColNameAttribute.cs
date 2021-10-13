using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Pithy
{
   public class ColNameAttribute:AbsAttribute
    {
        public ColNameAttribute(string name) : base(name)
        {

        }
    }
}
