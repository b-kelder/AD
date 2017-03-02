using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Searching
{
    class SequentialSearch
    {
        /// <summary>
        /// Sequential Search for an item in a array and return its index.
        /// </summary>
        /// <param name="array">The array to search through.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>The index where the item can be found.</returns>
        public static int search<T>(T[] array, T item) where T : IComparable
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                if (item.CompareTo(array[i]) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
