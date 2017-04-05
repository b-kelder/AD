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
    public class CircularList<T> : SinglyLinkedList<T> where T: new()
    {
        public CircularList()
        {
            head = new Node<T>(new T());
            head.next = head;
        }

        /// <summary>
        /// Method to add data to the list
        /// </summary>
        /// <param name="data">The data to add</param>
        public override void add(T data)
        {
            //Create a node to store the data in
            Node<T> toAdd = new Node<T>(data);

            //Create node to keep track of where we are
            Node<T> current = head;
            //Loop until we are at the end
            while(current.next != head)
            {
                current = current.next;
            }
            //Add node
            current.next = toAdd;
            toAdd.next = head;

            //Increase node count
            nodeCount++;
        }

        /// <summary>
        /// Method to get an item from the list at a specific index
        /// </summary>
        /// <param name="index">The index of the item</param>
        /// <returns></returns>
        public override T get(int index)
        {
            //Check if the index is in range
            if(index >= nodeCount && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            //Create node to keep track of where we are
            Node<T> nodeToGet = head.next;
            //Loop until we are at the index
            for(int i = 0; i < index; i++)
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
        public override void remove(T data)
        {
            //Get the index of the data to remove
            int index = indexOf(data);
            //If index is valid
            if(index >= 0)
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
        public override T removeAt(int index)
        {
            //Check if the index is in range
            if(index >= nodeCount && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            //Create nodes to store where we are and the node before it
            Node<T> nodeToRemove = head.next;
            Node<T> previous = head;
            //Loop until we are at the index
            for(int i = 0; i < index; i++)
            {
                //If its the node before the index
                if(i == (index - 1))
                {
                    //Store it
                    previous = nodeToRemove;
                }
                nodeToRemove = nodeToRemove.next;
            }

            //If previous node exists
            if(previous != null)
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
        public override void clear()
        {
            //Remove any link to existing nodes
            head.next = head;
            nodeCount = 0;
        }

        /// <summary>
        /// Method to check if the list contains an item
        /// </summary>
        /// <param name="item">The item to check for</param>
        /// <returns>True if found, false if not</returns>
        public override bool contains(T item)
        {
            //Create node to keep track of where we are
            Node<T> current = head.next;
            //Loop until we are at the end
            while(current != head)
            {
                //If data equals the item
                if(current.data.Equals(item))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        /// <summary>
        /// Method to get the index of an item
        /// </summary>
        /// <param name="item">The item to get the index of</param>
        /// <returns>The index of the item, -1 if not found</returns>
        public override int indexOf(T item)
        {
            //Create node to keep track of where we are
            Node<T> current = head.next;
            int index = 0;
            //Loop until we are at the end
            while(current != head)
            {
                //If the data equals the item
                if(current.data.Equals(item))
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
        /// Method to get the total items in list
        /// </summary>
        /// <returns>The total items in the list</returns>
        public override int count()
        {
            return nodeCount;
        }
    }
}
