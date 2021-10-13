using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Pithy
{
    public abstract class AbsAttribute:Attribute
    {
        private string _name { get; set; }
        public AbsAttribute(string name)
        {
            this._name = name;
        }
        public string GetName()
        {
            return _name;
        }
    }
}
