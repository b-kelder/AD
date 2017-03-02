using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    public static class SmartBubbleSort
    {
        /// <summary>
        /// Method that sorts and IComparable array using a smart bubble sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void sort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;
            do
            {
                int newLength = 0;
                for(int i = 1; i < length; i++)
                {
                    if(array[i - 1].CompareTo(array[i]) > 0)
                    {
                        newLength = i;
                        T temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                }
                length = newLength;
            } while(length > 0);
        }
    }
}
