using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    static class Util
    {
        public static Type[] getTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal) && t.IsInterface == false).ToArray();
        }

        public static string arrayToString<T>(T[] array)
        {
            if(array == null)
                return "";

            var sb = new StringBuilder();
            sb.Append("(");
            int length = array.Length;
            for(int i = 0; i < length; i++)
            {
                sb.Append(array[i]);
                if(i < length - 1)
                {
                    sb.Append(") - \r\n(");
                }
                else
                {
                    sb.Append(")");
                }
            }
            
            return sb.ToString();
        }
    }
}
