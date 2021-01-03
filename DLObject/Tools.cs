using System;
using System.Reflection;
using DalApi;
//using DO;

namespace DL
{
    public static class Tools
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static T GetPropertiesFrom<T, S>(this S from) where T : new()
        {
            T to = new T();
            foreach (PropertyInfo propTo in to.GetType().GetProperties())
            {
                PropertyInfo propFrom = from.GetType().GetProperty(propTo.Name);
                if (propFrom == null)
                    continue;
                var value = propFrom.GetValue(from, null);
                if (value is ValueType || value is string)
                    propTo.SetValue(to, value);
            }
            return to;
        }
    }
}