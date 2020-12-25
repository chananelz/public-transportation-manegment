using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DalObject
{
    public partial class DalObject
    {
        internal static T Clone<T>(this T original)
        {
            T copyToObject = (T)Activator.CreateInstance(original.GetType());
            //...

            foreach (PropertyInfo sourcePropertyInfo in original.GetType().GetProperties())
            {
                PropertyInfo destPropertyInfo = original.GetType().GetProperty(sourcePropertyInfo.Name);

                destPropertyInfo.SetValue(copyToObject, sourcePropertyInfo.GetValue(original, null), null);
            }

            return copyToObject;
        }
    }
}
