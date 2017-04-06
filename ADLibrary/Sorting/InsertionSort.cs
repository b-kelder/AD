using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting 
{
    public static class InsertionSort
    {
        /// <summary>
        /// Method that sorts and IComparable array using the insertion sort algorithm.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void sort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;      //Store the lenght of the array
            T temp;                         //Create a temp var to store items
            int j;

            for (int i = 0; i < length; i++) //Loop through the array
            {
                temp = array[i];    //store the item in temp
                j = i - 1;          //get the previous index

                while (j >= 0 && array[j].CompareTo(temp) > 0)  //Keep moving item back to the start until a larger item is found
                {
                    array[j + 1] = array[j];    
                    j--;
                }
                array[j + 1] = temp; //insert temp back into the array
            }
        }
    }
}
