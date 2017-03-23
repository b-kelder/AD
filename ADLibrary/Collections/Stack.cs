using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    /// <summary>
    /// A LIFO collection of type T.
    /// </summary>
    /// <typeparam name="T">The type to store in the stack.</typeparam>
    public class Stack<T> : ICollection<T>
    {
        /// <summary>
        /// The next free index on the stack. Also the amount of items on the stack.
        /// </summary>
        private int stackPointer;
        /// <summary>
        /// List for storage.
        /// </summary>
        private Arraylist<T> stackList;

        public Stack()
        {
            stackPointer = 0;
            stackList = new Arraylist<T>();
        }

        /// <summary>
        /// Pushes an item on the stack.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void push(T item)
        {
            stackPointer++;
            stackList.add(item);
        }

        /// <summary>
        /// Removes the most recent item from the stack and returns it.
        /// </summary>
        /// <returns>The most recent item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when stack is empty.</exception>
        public T pop()
        {
            if(stackList.count() > 0)
            {
                stackPointer--;                                     // Decrement it so it points at the last item
                return stackList.removeAt(stackPointer);
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        /// <summary>
        /// Returns the item that was last pushed on the stack.
        /// </summary>
        /// <returns>The most recent item on the stack.</returns>
        /// <exception cref="InvalidOperationException">Thrown when stack is empty.</exception>
        public T peek()
        {
            if(stackList.count() > 0)
            {
                return stackList.get(stackPointer - 1);             // stackPointer points 1 past the last item
            }
            else
            {
                throw new InvalidOperationException("Stack is empty");
            }
        }

        /// <summary>
        /// Clears the stack.
        /// </summary>
        public void clear()
        {
            stackList.clear();
            stackPointer = 0;
        }

        /// <summary>
        /// Checks if the item is on the stack.
        /// </summary>
        /// <param name="item">Item to find</param>
        /// <returns>True if the item is in the stack.</returns>
        public bool contains(T item)
        {
            return stackList.contains(item);
        }

        /// <summary>
        /// The amount of items on the stack.
        /// </summary>
        /// <returns>The amount of items on the stack.</returns>
        public int count()
        {
            return stackPointer;
        }

        /// <summary>
        /// Returns an array containing all items on the stack in FIFO order.
        /// The oldest item is in index 0.
        /// </summary>
        /// <returns>Array containing items on the stack.</returns>
        public T[] toArray()
        {
            return stackList.toArray();
        }
    }
}
