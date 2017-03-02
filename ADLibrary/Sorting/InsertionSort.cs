using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting 
{
    class InsertionSort
    {
        public static void sort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;
            T temp;
            int j;

            for (int i = 0; i < length; i++)
            {
                temp = array[i];
                j = i - 1;

                while (j >= 0 && array[j].CompareTo(temp) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }
        }
    }
}
