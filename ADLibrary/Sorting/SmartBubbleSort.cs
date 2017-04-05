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
            int nlength = 0;

            //Loop until no item is being swapped
            while (length > 0)
            {
                //Reset the swapped var
                //swapped = false;
                nlength = 0;
                //Loop throught all the items
                for (int i = 1; i < length; i++)
                {
                    //If item is largen than item after it
                    if (array[i - 1].CompareTo(array[i]) > 0)
                    {
                        //Swap the items
                        T temp = array[i];
                        array[i] = array[i - 1];
                        array[i - 1] = temp;
                        //Set the swapped var to true
                        nlength = i;
                    }
                }
                length = nlength;
                //
            }
        }
    }
}
