using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Pithy
{

    [AttributeUsage(AttributeTargets.Property)]
    public class ParaVerifyAttribute:Attribute
    {
        private bool _IsEmpty { get; set; }
        private int _Max { get; set; }
        private int _Min { get; set; }
        private int _Length { get; set; }
        private string _Desc { get; set; }
        public ParaVerifyAttribute(string Desc,bool IsEmpty=true,int Max=10,int Min=-1,int Length=4)
        {
            this._IsEmpty = IsEmpty;
            this._Max = Max;
            this._Min = Min;
            this._Length = Length;
            this._Desc = Desc;
        }
        public bool GetIsEmpty()
        {
            return _IsEmpty;
        }
        public int GetMax()
        {
            return this._Max;
        }
        public int GetMin()
        {
            return this._Min;
        }
        public int GetLength()
        {
            return _Length;
        }
        public string GetDesc()
        {
            return this._Desc;
        }
    }
}
