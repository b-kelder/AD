using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    /// <summary>
    /// Implements a priority queue using a max heap.
    /// Items are prioritized based on their CompareTo result.
    /// The item with the highest value gets dequeued first.
    /// </summary>
    /// <typeparam name="T">The type to store.</typeparam>
    public class PriorityQueue<T> : Queue<T> where T : IComparable
    {
        /// <summary>
        /// Array backing the heap.
        /// </summary>
        T[] array;
        /// <summary>
        /// The amount of items in the queue.
        /// </summary>
        int itemCount;
       
        /// <summary>
        /// Creates a PriorityQueue with the specified maximum size.
        /// </summary>
        /// <param name="maxSize">Maximum items allowed in the queue.</param>
        public PriorityQueue(int maxSize)
        {
            array = new T[maxSize];
            itemCount = 0;
        }

        /// <summary>
        /// Puts an item in the queue.
        /// </summary>
        /// <param name="item"></param>
        public override void enqueue(T item)
        {
            if(itemCount >= array.Length)
            {
                throw new InvalidOperationException("Queue is full");
            }

            array[itemCount] = item;                // Insert the item at the end of the array
            sortUp(itemCount);                      // Sort it up
            itemCount++;
        }

        /// <summary>
        /// Sorts an item up the binary tree.
        /// </summary>
        /// <param name="itemIndex">The index of the item to sort down.</param>
        private void sortUp(int itemIndex)
        {
            while(true)
            {
                int parentIndex = (itemIndex - 1) / 2;

                if(array[parentIndex].CompareTo(array[itemIndex]) < 0)
                {
                    // We use a max heap and the parent is less than the item, so swap them
                    T tmp = array[parentIndex];
                    array[parentIndex] = array[itemIndex];
                    array[itemIndex] = tmp;

                    itemIndex = parentIndex;
                }
                else
                {
                    // The item is now in the correct place
                    return;
                }
            }
        }

        /// <summary>
        /// Sorts an item down the binary tree.
        /// </summary>
        /// <param name="itemIndex">The index of the item to sort down.</param>
        private void sortDown(int itemIndex)
        {
            int arrayLength = array.Length;

            while(true)
            {
                int childLeftIndex = itemIndex * 2 + 1;
                int childRightIndex = itemIndex * 2 + 2;
                int largestValueIndex = itemIndex;              // The index of the item (out of parent, child R and child L) that has the highest value

                // Do some bounds checking and find the highest value of the three
                if(childLeftIndex < itemCount && array[childLeftIndex].CompareTo(array[largestValueIndex]) > 0)
                {
                    // The left child has the highest value
                    largestValueIndex = childLeftIndex;
                }
                if(childRightIndex < itemCount && array[childRightIndex].CompareTo(array[largestValueIndex]) > 0)
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

        /// <summary>
        /// Returns the item with the highest priority.
        /// </summary>
        /// <returns>Item with the highest priority.</returns>
        public override T dequeue()
        {
            if(itemCount > 0)
            {
                T item = array[0];                  // The highest priority item will be at the root
                itemCount--;

                array[0] = array[itemCount];        // Put the lowest value element (last in the array) at the root
                sortDown(0);                        // Sort it back in place, leading to the root being corrected

                return item;
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        /// <summary>
        /// Returns the first item in the queue.
        /// </summary>
        /// <returns>The first item in the queue.</returns>
        public override T peek()
        {
            if(itemCount > 0)
            {
                return array[0];
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        /// <summary>
        /// Clears the queue.
        /// </summary>
        public override void clear()
        {
            itemCount = 0;
        }

        /// <summary>
        /// Checks if item is in the queue.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>True if the item is in the queue.</returns>
        public override bool contains(T item)
        {
            return Searching.SequentialSearch.search<T>(array, item) >= 0;
        }

        /// <summary>
        /// The amount of items in the queue.
        /// </summary>
        /// <returns>Amount of items in the queue.</returns>
        public override int count()
        {
            return itemCount;
        }

        /// <summary>
        /// Returns an array of all items in the queue in order of importance. Highest item is first.
        /// </summary>
        /// <returns>Array containing items in the queue.</returns>
        public override T[] toArray()
        {
            T[] result = new T[itemCount];
            Array.Copy(array, result, itemCount);
            Sorting.HeapSort.sort(result);
            return result;
        }
    }

    /// <summary>
    /// Wrapper object for use with PriorityQueue.
    /// Compares based on priority value.
    /// </summary>
    public class PriorityItem : IComparable
    {
        /// <summary>
        /// The object to store
        /// </summary>
        object item;
        /// <summary>
        /// The priority
        /// </summary>
        int priority;

        public PriorityItem(object item, int priority)
        {
            this.item = item;
            this.priority = priority;
        }

        /// <summary>
        /// Retrieve the item stored.
        /// </summary>
        /// <returns>Item</returns>
        public object getItem()
        {
            return item;
        }

        /// <summary>
        /// Get the priority
        /// </summary>
        /// <returns>priority value</returns>
        public int getPriority()
        {
            return priority;
        }

        /// <summary>
        /// Compares based on priority
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>-1, 0, 1</returns>
        public int CompareTo(object obj)
        {
            var other = obj as PriorityItem;
            if(other != null)
            {
                return priority.CompareTo(other.priority);
            }
            else
            {
                throw new ArgumentException("Other is not of type PriorityItem!");
            }
        }
    }
}
