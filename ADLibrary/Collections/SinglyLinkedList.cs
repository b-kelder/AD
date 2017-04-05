using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    /// <summary>
    /// A generic singly linked list
    /// </summary>
    /// <typeparam name="T">The type to store.</typeparam>
    public class SinglyLinkedList<T> : IList<T>
    {
        /// <summary>
        /// The first node in the list
        /// </summary>
        private SinglyNode<T> head;
        /// <summary>
        /// Tht total amount of items in the list
        /// </summary>
        private int nodeCount;

        /// <summary>
        /// The default constructor for SinglyLinkedList
        /// </summary>
        public SinglyLinkedList() { }

        /// <summary>
        /// Method to add data to the list
        /// </summary>
        /// <param name="data">The data to add</param>
        public void add(T data)
        {
            //Create a node to store the data in
            SinglyNode<T> toAdd = new SinglyNode<T>(data); 
            //If head is null, add data to the start           
            if (head == null)
            {
                head = toAdd;
            }
            else
            {
                //Create node to keep track of where we are
                SinglyNode<T> current = head;
                //Loop until we are at the end
                while (current.next != null)
                {
                    current = current.next;
                }
                //Add node
                current.next = toAdd;
            }
            //Increase node count
            nodeCount++;
        }

        /// <summary>
        /// Method to get an item from the list at a specific index
        /// </summary>
        /// <param name="index">The index of the item</param>
        /// <returns></returns>
        public T get(int index)
        {
            //Check if the index is in range
            if (index >= nodeCount && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            //Create node to keep track of where we are
            SinglyNode<T> nodeToGet = head;
            //Loop until we are at the index
            for (int i = 0; i < index; i++)
            {
                nodeToGet = nodeToGet.next;
            }

            //Return the node
            return nodeToGet.data;
        }

        /// <summary>
        /// Method to remove the first occurance of data
        /// </summary>
        /// <param name="data">The data to remove</param>
        public void remove(T data)
        {
            //Get the index of the data to remove
            int index = indexOf(data);
            //If index is valid
            if (index >= 0)
            {
                //Remove item at index
                removeAt(index);
            }
        }

        /// <summary>
        /// Method to remove data at a specific index
        /// </summary>
        /// <param name="index">The index to remove the data from</param>
        /// <returns>The data that gets removed</returns>
        public T removeAt(int index)
        {
            //Check if the index is in range
            if (index >= nodeCount && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            //Create nodes to store where we are and the node before it
            SinglyNode<T> nodeToRemove = head;
            SinglyNode<T> previous = null;
            //Loop until we are at the index
            for (int i = 0; i < index; i++)
            {
                //If its the node before the index
                if (i == (index - 1))
                {
                    //Store it
                    previous = nodeToRemove;
                }
                nodeToRemove = nodeToRemove.next;
            }

            //If the node to remove is the head
            if (nodeToRemove == head)
            {
                //The new head becomes the next of the previous node
                head = nodeToRemove.next;
            }
            //If previous node exists
            if (previous != null)
            {
                //The new next of the previous node becomes the next of the node to remove
                previous.next = nodeToRemove.next;
            }
            //Decrease the node count
            nodeCount--;
            return nodeToRemove.data;
        }

        /// <summary>
        /// Method to clear the list
        /// </summary>
        public void clear()
        {
            //Remove any linkt to existing nodes
            head = null;
            nodeCount = 0;
        }

        /// <summary>
        /// Method to check if the list contains an item
        /// </summary>
        /// <param name="item">The item to check for</param>
        /// <returns>True if found, false if not</returns>
        public bool contains(T item)
        {
            //Create node to keep track of where we are
            SinglyNode<T> current = head;
            //Loop until we are at the end
            while (current != null)
            {
                //If data equals the item
                if (current.data.Equals(item))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        /// <summary>
        /// Method to get the total items in list
        /// </summary>
        /// <returns>The total items in the list</returns>
        public int count()
        {
            return nodeCount;
        }

        /// <summary>
        /// Method to change the linked list into an array
        /// </summary>
        /// <returns>An array of items</returns>
        public T[] toArray()
        {
            //Create an array with the correct size
            T[] array = new T[nodeCount];

            //Create node to keep track of where we are
            SinglyNode<T> current = head;
            //Loop through all nodes
            for (int i = 0; i < nodeCount; i++)
            {
                //Store data in the array
                array[i] = current.data;
                current = current.next;
            }

            //return the array
            return array;
        }

        /// <summary>
        /// Method to get the index of an item
        /// </summary>
        /// <param name="item">The item to get the index of</param>
        /// <returns>The index of the item, -1 if not found</returns>
        public int indexOf(T item)
        {
            //Create node to keep track of where we are
            SinglyNode<T> current = head;
            int index = 0;
            //Loop until we are at the end
            while (current != null)
            {
                //If the data equals the item
                if (current.data.Equals(item))
                {
                    //return its index
                    return index;
                }
                index++;
                current = current.next;  
            }
            return -1;
        }

        /// <summary>
        /// Method to insert an item into the list
        /// </summary>
        /// <param name="item">The item to insert</param>
        /// <param name="index">The index to store the item at</param>
        public void insert(T item, int index)
        {
            //Check to see if index is inrange
            if (index > nodeCount || index < 0)
            {
                add(item);
            }
            else
            {
                //Create node to keep track of where we are
                SinglyNode<T> current = head;
                //loop until we are at the index
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.next;
                }
                //Create node to store the data
                SinglyNode<T> toAdd = new SinglyNode<T>(item);
                //Set its next
                toAdd.next = current.next;
                current.next = toAdd;
                //Increase node count
                nodeCount++;
            }
        }

        /// <summary>
        /// Method to get from the first node
        /// </summary>
        /// <returns>The first node</returns>
        public SinglyNode<T> getFirstNode()
        {
            return head;
        }

        /// <summary>
        /// Sets the head of this list. Used by Iterator.
        /// DOES NOT update links.
        /// </summary>
        /// <param name="node">The head</param>
        public void setFirstNode(SinglyNode<T> node)
        {
            head = node;
        }
    }
}
