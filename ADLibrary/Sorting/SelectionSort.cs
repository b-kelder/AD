using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    public static class SelectionSort
    {
        /// <summary>
        /// Method that sorts and IComparable array using the selection sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void sort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;

            for (int i = 0; i < length - 1; i++)            //Loop through all items in the array.
            {
                int indexSmallest = i;                      //Save the index of the smallest item in the array.

                for (int j = i + 1; j < length; j++)        //Loop through all the unsorted items (everything up to i has been sorted).
                {
                    if (array[j].CompareTo(array[indexSmallest]) < 0)       //Check if the current item is smaller than the currently know smallest item.
                    {
                        indexSmallest = j;                                  //If so, save the item as the new smallest item.
                    }
                }

                T temp = array[i];                  //After finding the new smallest item, temporary save the next unsorted item.
                array[i] = array[indexSmallest];    //Give the smaller of the two the index of the larger one.
                array[indexSmallest] = temp;        //Give the larger item the index of the smaller one, basicly swapping them.
            }
        }
    }
}
