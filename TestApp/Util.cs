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
            foreach(var element in array)
            {
                sb.Append(element + ") - \r\n(");
            }
            sb.Append("FINISHED)");
            return sb.ToString();
        }
    }
}
