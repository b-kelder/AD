using System;
using System.Text;

namespace ADLibrary.Collections
{
    public class Arraylist<T> : ICollection<T>
    {
        private T[] array;
        private int nextFreeIndex;

        public Arraylist() : this(10)
        {
        }

        public Arraylist(int startSize)
        {
            if(startSize < 1)
            {
                throw new ArgumentOutOfRangeException("startSize", "Start size cannot be 0 or negative");
            }

            array = new T[startSize];
            nextFreeIndex = 0;
        }

        /// <summary>
        /// Expands our internal array to 3 times it's current size.
        /// </summary>
        private void expand()
        {
            var tmp = new T[array.Length * 3];
            array.CopyTo(tmp, 0);
            array = tmp;
        }

        public void add(T item)
        {
            if(nextFreeIndex == array.Length)
            {
                expand();
            }
            array[nextFreeIndex] = item;
            nextFreeIndex++;
        }

        public void clear()
        {
            array = new T[array.Length];
            nextFreeIndex = 0;
        }

        public T get(int index)
        {
            if(index >= 0 && index < nextFreeIndex)
            {
                return array[index];
            }
            throw new ArgumentOutOfRangeException("index", "Index out of bounds");
        }

        public int indexOf(T item)
        {
            for(int i = 0; i < nextFreeIndex; i++)
            {
                if(array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void remove(int index)
        {
            if(index >= 0 && index < nextFreeIndex)
            {
                // Copy the contents of array after the item to one position earlier.
                Array.Copy(array, index + 1, array, index, nextFreeIndex - index - 1);
                nextFreeIndex--;
            }
            else
            {
                throw new ArgumentOutOfRangeException("index", "Index out of bounds");
            }
        }

        public bool contains(T item)
        {
            return indexOf(item) >= 0;
        }

        public void insert(T item, int index)
        {
            if(index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Index cannot be negative");
            }

            if(index >= nextFreeIndex)
            {
                add(item);
            }
            else
            {
                // See if we have space left in our array
                if(nextFreeIndex == array.Length)
                {
                    // No? Make it bigger
                    expand();
                }
                // Move everything starting at index 1 position back
                Array.Copy(array, index, array, index + 1, nextFreeIndex - index);
            }
        }

        public int count()
        {
            return nextFreeIndex;
        }

        public T[] toArray()
        {
            T[] result = new T[count()];
            array.CopyTo(result, 0);
            return result;
        }
    }
}
