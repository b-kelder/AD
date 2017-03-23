using System;
using System.Text;

namespace ADLibrary.Collections
{
    /// <summary>
    /// A generic array list.
    /// </summary>
    /// <typeparam name="T">The type to store in this array list.</typeparam>
    public class Arraylist<T> : IList<T>
    {
        /// <summary>
        /// Internal storage array.
        /// </summary>
        private T[] array;
        /// <summary>
        /// The next index of the array that may be used to store an item. Also the amount of items in our list.
        /// </summary>
        private int itemCount;

        /// <summary>
        /// The amount the internal array is scaled by when it is full.
        /// </summary>
        public int ScaleFactor
        {
            get { return scaleFactor; }
            set
            {
                if(value > 1)
                {
                    scaleFactor = value;
                }
            }
        }
        private int scaleFactor;

        /// <summary>
        /// Creates an Arraylist with an initial size of 15 and a scale factor of 3.
        /// </summary>
        public Arraylist() : this(15, 3)
        {
        }

		/// <summary>
        /// Creates an Arraylist with the specified start size and scale factor.
        /// </summary>
        public Arraylist(int startSize, int scaleFactor)
        {
            if(startSize < 1)
            {
                throw new ArgumentOutOfRangeException("startSize", "Start size cannot be 0 or negative");
            }

            ScaleFactor = scaleFactor;
            array = new T[startSize];
            itemCount = 0;
        }

        /// <summary>
        /// Expands our internal array based on the scale factor.
        /// </summary>
        private void expand()
        {
            var tmp = new T[array.Length * scaleFactor];
            array.CopyTo(tmp, 0);
            array = tmp;
        }

        /// <summary>
        /// Adds a new item to the end of the list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void add(T item)
        {
            if(itemCount >= array.Length)
            {
                expand();
            }
            array[itemCount] = item;
            itemCount++;
        }

        /// <summary>
        /// Clears the array list.
        /// </summary>
        public void clear()
        {
            array = new T[array.Length];
            itemCount = 0;
        }

        /// <summary>
        /// Returns the item on index.
        /// </summary>
        /// <param name="index">The index of the item to return.</param>
        /// <returns>The item at index.</returns>
        public T get(int index)
        {
            if(index >= 0 && index < itemCount)
            {
                return array[index];
            }
            throw new ArgumentOutOfRangeException("index", "Index out of bounds");
        }

        /// <summary>
        /// Returns the index of the first occurence of item.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>The index of the item or -1 if it can't be found.</returns>
        public int indexOf(T item)
        {
            for(int i = 0; i < itemCount; i++)
            {
                if(array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Removes the item at index and returns it.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        /// <returns>The item that was removed</returns>
        public T removeAt(int index)
        {
            if(index >= 0 && index < itemCount)
            {
                T removedItem = array[index];
                if(index < itemCount - 1)               // It is not the last item
                {
                    // Copy every item after index to 1 position earlier to make the array continuous again
                    Array.Copy(array, index + 1, array, index, itemCount - (index + 1));
                }

                itemCount--;
                return removedItem;
            }
            else
            {
                throw new ArgumentOutOfRangeException("index", "Index out of bounds");
            }
        }

        /// <summary>
        /// Checks if item is in this array list.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>true if item is in the list</returns>
        public bool contains(T item)
        {
            return indexOf(item) >= 0;
        }

        /// <summary>
        /// Inserts the item at the position specified by index in the list.
        /// If index is larger than the amount of items in the list the item will be added to the list instead.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="index">Index of the item.</param>
        public void insert(T item, int index)
        {
            if(index >= itemCount)
            {
                // Just add it to the end.
                add(item);
            }
            else if(index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                // See if we have to expand the array
                if(itemCount >= array.Length)
                {
                    expand();
                }
                // Move everything, starting at index (it is included), 1 position back to make room for our new item
                Array.Copy(array, index, array, index + 1, itemCount - index);
                array[index] = item;
                // Account for the item being inserted
                itemCount++;
            }
        }

        /// <summary>
        /// The amount of items in the list.
        /// </summary>
        /// <returns>Amount of items in the list.</returns>
        public int count()
        {
            return itemCount;
        }

        /// <summary>
        /// Returns an array containing all items in this list.
        /// </summary>
        /// <returns>Array containing all items in the list.</returns>
        public T[] toArray()
        {
            T[] result = new T[count()];
            Array.Copy(array, result, result.Length);
            return result;
        }

        /// <summary>
        /// Removes the first occurence of item in this list.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        public void remove(T item)
        {
            int index = indexOf(item);
            if(index >= 0)
            {
                removeAt(index);
            }
        }

        // Overloading [] for convenience
        public T this[int key]
        {
            get
            {
                // the same as get()
                if(key >= 0 && key < itemCount)
                {
                    return array[key];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("key", "Key is out of range");
                }
            }
            set
            {
                // Overwrite item at position
                if(key >= 0 && key < itemCount)
                {
                    array[key] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("key", "Key is out of range");
                }
            }
        }
    }
}
