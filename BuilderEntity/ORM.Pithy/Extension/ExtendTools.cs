using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Pithy
{
    public static class ExtendTools
    {
        /// <summary>
        /// 校准接口参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>

        public static string GetClassName(this Type type)
        {
            if (type.IsDefined(typeof(ClassNameAttribute), false))
            {
                ClassNameAttribute classNameAttribute = (ClassNameAttribute)type.GetCustomAttributes(typeof(ClassNameAttribute),false)[0];
                return classNameAttribute.GetName();
            }
            else
            {
                return type.Name;
            }
        }

        public static string GetColName(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(ColNameAttribute), false))
            {
                ColNameAttribute classNameAttribute = (ColNameAttribute)prop.GetCustomAttributes(typeof(ColNameAttribute),false)[0];
                return classNameAttribute.GetName();
            }
            else
            {
                return prop.Name;
            }
        }

     

        public static IEnumerable<PropertyInfo> GetNoIgnore(this Type type)
        {
            IEnumerable<PropertyInfo> props=type.GetProperties().
                Where(t=>t.IsDefined(typeof(IgnoreAttribute),false)==false);
            if (props==null )
            {
                return null;
            }
            return props;
        }
        /// <summary>
        /// func---适用于其他特性的的属性的筛选
        /// </summary>
        /// <param name="type"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetNoIgnore(this Type type,Func<PropertyInfo,bool> func)
        {
            IEnumerable<PropertyInfo> props = type.GetProperties().
                Where(t=>func.Invoke(t));
            if (props == null)
            {
                return null;
            }
            return props;
        }

        public static T DicMapEntity<T>(this Dictionary<string,int> dic)
        {
            Type type = typeof(T);
            object obj = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties())
            {
                if (dic.ContainsKey(prop.GetColName()))
                {
                    prop.SetValue(obj,dic[prop.GetColName()]);
                }
            }

            return (T)obj;
        }
    }
}
