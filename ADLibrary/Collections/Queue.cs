using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    /// <summary>
    /// A FIFO queue.
    /// </summary>
    /// <typeparam name="T">The type to store.</typeparam>
    public class Queue<T> : IList<T>
    {
        Arraylist<T> list;

        public Queue()
        {
            list = new Arraylist<T>();
        }

        /// <summary>
        /// Adds an item to the queue.
        /// </summary>
        /// <param name="item">Item to add.</param>
        public virtual void enqueue(T item)
        {
            list.add(item);
        }

        /// <summary>
        /// Removes the oldest item from the queue and returns it.
        /// </summary>
        /// <returns>The oldest item in the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public virtual T dequeue()
        {
            if(list.count() > 0)
            {
                return list.removeAt(0);
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        /// <summary>
        /// Returns the oldest item in the queue.
        /// </summary>
        /// <returns>The oldest item in the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the queue is empty.</exception>
        public virtual T peek()
        {
            if(list.count() > 0)
            {
                return list.get(0);
            }
            else
            {
                throw new InvalidOperationException("Queue is empty");
            }
        }

        /// <summary>
        /// Clears the queue.
        /// </summary>
        public virtual void clear()
        {
            list.clear();
        }

        /// <summary>
        /// Checks if the item is in the queue.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>True if item is in the queue.</returns>
        public virtual bool contains(T item)
        {
            return list.contains(item);
        }

        /// <summary>
        /// Returns the amount of items in the queue.
        /// </summary>
        /// <returns>Amount of items in the queue.</returns>
        public virtual int count()
        {
            return list.count();
        }

        /// <summary>
        /// Returns an array containing all items in the queue. The oldest item is at index 0.
        /// </summary>
        /// <returns>Array containing items in the queue.</returns>
        public virtual T[] toArray()
        {
            return list.toArray();
        }
    }
}
