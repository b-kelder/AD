using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    public static class HeapSort
    {
        /// <summary>
        /// Quickly sorts an array using heap sort.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        public static void sort<T>(T[] array) where T : IComparable
        {
            heapify(array);                     // Organize the array into a heap

            int end = array.Length - 1;
            while(end > 0)                      // Move from the back of the array forward
            {
                T tmp = array[0];               // Put the the lowest value (which is at the end because this is a max heap) in the first position
                array[0] = array[end];
                array[end] = tmp;

                end--;

                sortDown(array, 0, end);        // The heap has been damaged by our blasphemous swapping, restore it
            }
        }

        /// <summary>
        /// Orders an array into a max heap.
        /// </summary>
        /// <param name="array">The array to heapify.</param>
        private static void heapify<T>(T[] array) where T : IComparable
        {
            int length = array.Length;
            int start = (length - 2) / 2;           // The parent of the last item in the array ((length - 1) - 1) / 2

            while(start >= 0)
            {
                // Sort down the node at 'start' so all nodes below it are in the correct order.
                sortDown(array, start, length - 1);
                // Go to next parent node
                start--;
            }
        }

        /// <summary>
        /// Sorts an item down the heap.
        /// </summary>
        /// <param name="array">The array containing the heap.</param>
        /// <param name="itemIndex">The index of the item to sort.</param>
        /// <param name="lastIndex">The last index in the array we may swap with.</param>
        private static void sortDown<T>(T[] array, int itemIndex, int lastIndex) where T : IComparable
        {
            while(true)
            {
                int childLeftIndex = itemIndex * 2 + 1;
                int childRightIndex = itemIndex * 2 + 2;
                int largestValueIndex = itemIndex;              // The index of the item (out of parent, child R and child L) that has the highest value

                // Do some bounds checking and find the highest value of the three
                if(childLeftIndex <= lastIndex && array[childLeftIndex].CompareTo(array[largestValueIndex]) > 0)
                {
                    // The left child has the highest value
                    largestValueIndex = childLeftIndex;
                }
                if(childRightIndex <= lastIndex && array[childRightIndex].CompareTo(array[largestValueIndex]) > 0)
                {
                    // The right child has the highest value
                    largestValueIndex = childRightIndex;
                }

                if(largestValueIndex != itemIndex)
                {
                    // swap largest and itemIndex
                    T tmp = array[largestValueIndex];
                    array[largestValueIndex] = array[itemIndex];
                    array[itemIndex] = tmp;

                    itemIndex = largestValueIndex;
                }
                else
                {
                    // We are done
                    return;
                }
            }
        }
    }
}
