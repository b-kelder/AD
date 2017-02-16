using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    public static class SmartBubbleSort
    {
        public static void sort<T>(T[] array) where T : IComparable
        {
            int n = array.Length;
            do
            {
                int newn = 0;
                for(int i = 1; i < n; i++)
                {
                    if(array[i - 1].CompareTo(array[i]) > 0)
                    {
                        newn = i;
                        T temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                }
                n = newn;
            } while(n > 0);
        }
    }
}
