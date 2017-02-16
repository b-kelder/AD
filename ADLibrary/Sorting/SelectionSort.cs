using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    class SelectionSort : ISorter
    {
        /// <summary>
        /// Method that sorts and IComparable array using the selection sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public void sort(IComparable[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)                      //Loop through all items in the array.
            {
                int indexSmallest = i;                                      //Save the index of the smallest item in the array.

                for (int j = i + 1; j < array.Length; j++)                  //Loop through all the unsorted items (everything up to i has been sorted).
                {
                    if (array[j].CompareTo(array[indexSmallest]) < 0)       //Check if the current item is smaller than the currently know smallest item.
                    {
                        indexSmallest = j;                                  //If so, save the item as the new smallest item.
                    }
                }

                IComparable temp = array[i];                                //After finding the new smallest item, temporary save the next unsorted item.
                array[i] = array[indexSmallest];                            //Put the smallest item on its new index.
                array[indexSmallest] = temp;                                //Put the temporary saved item back in the array, basicly swapping them.
            }
        }
    }
}
