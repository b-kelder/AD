using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Searching
{
    public class SequentialSearch
    {
        /// <summary>
        /// Sequential Search for an item in a array and return its index.
        /// </summary>
        /// <param name="array">The array to search through.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>The index where the item can be found.</returns>
        public static int search<T>(T[] array, T item) where T : IComparable
        {
            //Store the length of the list to optimize speed.
            int length = array.Length;
            //Loop through the array
            for (int i = 0; i < length; i++)
            {
                //Check to see if the item is the one we are looking for
                if (item.CompareTo(array[i]) == 0)
                {
                    //If so, return the index of the item
                    return i;
                }
            }
            //If the item could not be found, return 0
            return -1;
        }
    }
}
