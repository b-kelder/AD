using System;

namespace ADLibrary.Collections
{
    /// <summary>
    /// An iterator for a singly linked list.
    /// </summary>
    /// <typeparam name="T">The type that is stored in the list</typeparam>
    public class LinkedListIterator<T>
    {
        SinglyNode<T> current;
        SinglyNode<T> previous;
        SinglyLinkedList<T> list;

        /// <summary>
        /// Creates an iterator for the given list.
        /// </summary>
        /// <param name="linkedList">The list to iterate.</param>
        public LinkedListIterator(SinglyLinkedList<T> linkedList)
        {
            list = linkedList;
            current = list.getFirstNode();
            previous = null;
        }

        /// <summary>
        /// Inserts an item before the current node and sets the current node to the inserted node.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        /// <exception cref="InsertBeforeHeaderException"></exception>
        public void insertBeforeCurrent(T item)
        {
            if(current == list.getFirstNode())
            {
                throw new InsertBeforeHeaderException();
            }
            else
            {
                var node = new SinglyNode<T>(item);
                node.next = current;
                previous.next = node;
                current = node;
            }
        }

        /// <summary>
        /// Inserts an item after the current node and sets the current node to the inserted node.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        public void insertAfterCurrent(T item)
        {
            var node = new SinglyNode<T>(item);
            current.next = node;
            advance();
        }

        /// <summary>
        /// Removes the current node from the list.
        /// </summary>
        public void remove()
        {
            previous.next = current.next;
        }

        /// <summary>
        /// Returns the current node.
        /// </summary>
        /// <returns>Current node</returns>
        public SinglyNode<T> getCurrent()
        {
            return current;
        }

        /// <summary>
        /// Returns if there is a node after the current node.
        /// </summary>
        /// <returns>True if there is another node</returns>
        public bool hasNext()
        {
            return current.next != null;
        }

        /// <summary>
        /// Moves up one node in the linked list.
        /// </summary>
        public void advance()
        {
            previous = current;
            current = current.next;
        }

        /// <summary>
        /// Resets the iterator to the start of the list.
        /// </summary>
        public void reset()
        {
            current = list.getFirstNode();
            previous = null;
        }
    }

    public class InsertBeforeHeaderException : Exception
    {
        public InsertBeforeHeaderException() : base("Can not insert node before header!")
        {
        }
    }

}
