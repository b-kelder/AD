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
            //Store the first entry in the array as the minimum.
            T min = array[0];
            //Store the length of the list to optimize speed.
            int length = array.Length;
            //Loop through the array, starting at the second item.
            for(int i = 1; i < length; i++)
            {
                //Check to see if the current item is smaller than the saved minimum item.
                if (array[i].CompareTo(min) < 0)
                {
                    //If smaller, store as new minimum.
                    min = array[i];
                }
            }
            //When finished, return the minimum value.
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
            //Store the first entry in the array as the maximum.
            T max = array[0];
            //Store the length of the list to optimize speed.
            int length = array.Length;
            //Loop through the array, starting at the second item.
            for (int i = 1; i < length; i++)
            {
                //Check to see if the current item is larger than the saved maximum item.
                if (array[i].CompareTo(max) > 0)
                {
                    //If smaller, store as new maximum.
                    max = array[i];
                }
            }
            //When finished, return the maximum value.
            return max;
        }
    }
}
