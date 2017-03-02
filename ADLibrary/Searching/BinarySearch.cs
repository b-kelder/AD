using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Searching
{
    public class BinarySearch
    {
        /// <summary>
        /// Binary Search for an item in a sorted array and return its index. -1 is returned when the item can not be found.
        /// </summary>
        /// <param name="array">The array to search through.</param>
        /// <param name="item">The item to search for.</param>
        /// <returns>The index where the item can be found.</returns>
        public static int search<T>(T[] array, T item) where T : IComparable
        {
            int low = 0;
            int high = array.Length - 1;
            int midpoint;

            while (low <= high)
            {
                midpoint = (high + low) / 2;                        // Midpoint is halfway between high and low and should be floored.

                if (item.CompareTo(array[midpoint]) == 0)
                    return midpoint;
                else if (item.CompareTo(array[midpoint]) < 0)
                    high = midpoint - 1;                            // The item is before the midpoint
                else
                    low = midpoint + 1;                             // The item is after the midpoint
            }

            return -1;
        }
    }
}
