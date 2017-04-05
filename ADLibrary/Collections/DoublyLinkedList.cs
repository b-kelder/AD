using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class DoublyLinkedList<T> : SinglyLinkedList<T> where T: new()
    {
        public DoublyLinkedList()
        {
            head = new Node<T>(new T());
            nodeCount = 0;
            head.next = null;
            head.previous = null;
        }

        /// <summary>
        /// Method to add data to the list
        /// </summary>
        /// <param name="data">The data to add</param>
        public override void add(T data)
        {
            //Create a node to store the data in
            var toAdd = new Node<T>(data);

            //Create node to keep track of where we are
            IDoublyNode<T> current = head;
            //Loop until we are at the end
            while(current.next != null)
            {
                current = current.next;
            }
            //Add node
            current.next = toAdd;
            toAdd.previous = (Node<T>)current;

            //Increase node count
            nodeCount++;
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
            IDoublyNode<T> nodeToRemove = head.next;
            IDoublyNode<T> previous = null;
            IDoublyNode<T> next = null;

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
            next = nodeToRemove.next;

            if(next != null)
            {
                // Fix next node's previous link
                next.previous = (Node<T>)previous;
            }
            if(previous != null)
            {
                // Fix previous node's next link
                previous.next = (Node<T>)next;
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
            //Remove any linkt to existing nodes
            head.next = null;
            head.previous = null;
            nodeCount = 0;
        }

        /// <summary>
        /// Method to insert an item into the list
        /// </summary>
        /// <param name="item">The item to insert</param>
        /// <param name="index">The index to store the item at</param>
        public override void insert(T item, int index)
        {
            //Check to see if index is inrange
            if(index > nodeCount || index < 0)
            {
                add(item);
            }
            else
            {
                //Create node to keep track of where we are
                IDoublyNode<T> current = head.next;
                //loop until we are at the index
                for(int i = 0; i < index; i++)
                {
                    current = current.next;
                }
                // current now contains the node at index

                //Create node to store the data
                var toAdd = new Node<T>(item);
                
                toAdd.next = (Node<T>)current;
                toAdd.previous = current.previous;
                current.previous.next = toAdd;
                current.previous = toAdd;
                //Increase node count
                nodeCount++;
            }
        }
    }
}
