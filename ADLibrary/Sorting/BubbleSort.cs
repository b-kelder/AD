using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    public static class BubbleSort
    {
        /// <summary>
        /// Method that sorts and IComparable array using the bubble sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void sort<T>(T[] array) where T : IComparable
        {
            T temp;                                   //Create a variable to temporary save an item.

            for (int i = 0; i < array.Length; i++)         //loop door iets? !@##$!$%@%^$
            {
                for (int j = 1; j < array.Length - i; j++)          //loop door iets? !@##$!$%@%^$
                {
                    if (array[j - 1].CompareTo(array[j]) > 0)   //Check if the current item is larger than next item in the array.
                    {
                        temp = array[j];                        //If so, temporary save the current item.
                        array[j] = array[j - 1];                //Give the smaller of the two the index of the larger one.
                        array[j - 1] = temp;                    //Give the larger item the index of the smaller one, basicly swapping them.
                    }
                }
            }
        }
    }
}