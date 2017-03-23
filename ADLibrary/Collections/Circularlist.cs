using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    /// <summary>
    /// A doubly linked circular list
    /// </summary>
    /// <typeparam name="T">The type to store</typeparam>
    public class CircularList<T> : IList<T>
    {
        private DoublyNode<T> head;
        private int nodeCount;

        public void add(T data)
        {
            DoublyNode<T> toAdd = new DoublyNode<T>(data);
            if(head == null)
            {
                // No nodes, this will be the head
                head = toAdd;

                // Link it to itself
                head.next = head;
                head.previous = head;
            }
            else
            {
                DoublyNode<T> current = head;
                // Find last node
                while(current.next != head)
                {
                    current = current.next;
                }
                // Connect last and new node
                toAdd.previous = current;       
                current.next = toAdd;
                // Connect to head
                toAdd.next = head;
                head.previous = toAdd;
            }
            nodeCount++;
        }

        public T get(int index)
        {
            if(index >= nodeCount)
                throw new IndexOutOfRangeException();

            DoublyNode<T> nodeToGet = head;
            for(int i = 0; i < index; i++)
            {
                nodeToGet = nodeToGet.next;
            }

            return nodeToGet.data;
        }

        public void remove(T data)
        {
            DoublyNode<T> current = head;
            do
            {
                if(current.data.Equals(data))
                {
                    removeNode(current);
                    return;
                }
                current = current.next;
            }
            while(current != head);
        }

        /// <summary>
        /// Removes the given node from the list.
        /// NOTE: The node DOES NOT have to be in this list, but nodeCount is always decremented.
        /// Make sure that the node is in the list before calling this method!
        /// </summary>
        /// <param name="current"></param>
        private void removeNode(DoublyNode<T> current)
        {
            // Fix the links on the nodes before and after us
            current.next.previous = current.previous;
            current.previous.next = current.next;

            if(current == head)
            {
                if(current.next == head)
                {
                    // This only happens if there is a single node in the list
                    head = null;
                }
                else
                {
                    // Set the head to the next node
                    head = current.next;
                }
            }
            nodeCount--;
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void clear()
        {
            head = null;
            nodeCount = 0;
        }

        /// <summary>
        /// Checks if an item is in the list.
        /// </summary>
        /// <param name="item">The item to find</param>
        /// <returns>True if the item was found</returns>
        public bool contains(T item)
        {
            DoublyNode<T> current = head;
            
            do
            {
                if(current.data.Equals(item))
                {
                    return true;
                }
                current = current.next;
            }
            while(current != head);
            return false;
        }

        public int count()
        {
            return nodeCount;
        }

        public T[] toArray()
        {
            T[] array = new T[nodeCount];

            DoublyNode<T> current = head;
            for(int i = 0; i < nodeCount; i++)
            {
                array[i] = current.data;
                current = current.next;
            }

            return array;
        }

        /// <summary>
        /// Finds the zero based index of an item. Returns -1 if item can't be found.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Index of item or -1.</returns>
        public int indexOf(T item)
        {
            DoublyNode<T> current = head;
            int index = 0;
            do
            {
                if(current.data.Equals(item))
                {
                    return index;
                }
                index++;
                current = current.next;
            }
            while(current != head);
            return -1;
        }

        /// <summary>
        /// Removes the item at position in the list.
        /// </summary>
        /// <param name="index">The index to remove.</param>
        /// <returns>The removed item.</returns>
        public T removeAt(int index)
        {
            if(index >= nodeCount && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            // Go to the correct node
            DoublyNode<T> nodeToRemove = head;
            for(int i = 0; i < index; i++)
            {
                nodeToRemove = nodeToRemove.next;
            }

            // Remove it and returns it's data
            removeNode(nodeToRemove);
            return nodeToRemove.data;
        }

        /// <summary>
        /// Inserts an item at the given index.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        /// <param name="index">The index to insert at.</param>
        public void insert(T item, int index)
        {
            if(index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            // Add it to the end if the index is too large.
            if(index > nodeCount)
            {
                add(item);
            }

            // Move to the nodem at the index BEFORE the target index
            DoublyNode<T> current = head;
            for(int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }

            // Add new node after current
            DoublyNode<T> toAdd = new DoublyNode<T>(item);

            // Fix the previous link of the node that's currently at index
            current.next.previous = toAdd;

            // Fix other links
            toAdd.next = current.next;
            toAdd.previous = current;
            current.next = toAdd;
        }
    }
}
