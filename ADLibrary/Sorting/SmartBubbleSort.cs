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
                int newLength = 0;                                  // Will contain the index of the last swap
                for(int i = 1; i < length; i++)                     // Loop up to the index of the last swap, everything after that is already sorted
                {
                    if(array[i - 1].CompareTo(array[i]) > 0)        // If the previous item is larger we swap
                    {
                        newLength = i;                              // Store the index of this swap
                        T temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                    }
                }
                length = newLength;
            } while(length > 0);                                    // Keep going until everything is sorted (no swap in the previous run)
        }
    }
}
