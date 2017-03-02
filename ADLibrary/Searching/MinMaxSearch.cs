using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Searching
{
    /// <summary>
    /// Contains methods for finding the minimum and maximum values in an array.
    /// </summary>
    public class MinMaxSearch
    {
        /// <summary>
        /// Finds and returns the minimum value in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to search.</param>
        /// <returns>The minimum value in the array.</returns>
        public static T findMin<T>(T[] array) where T : IComparable
        {
            T min = array[0];
            int length = array.Length;
            for(int i = 1; i < length; i++)
            {
                if(array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }
            return min;
        }

        /// <summary>
        /// Finds and returns the maximum value in an array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to search.</param>
        /// <returns>The maximum value in the array.</returns>
        public static T findMax<T>(T[] array) where T : IComparable
        {
            T max = array[0];
            int length = array.Length;
            for(int i = 1; i < length; i++)
            {
                if(array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }
}
