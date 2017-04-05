using System;

namespace ADLibrary.Collections
{
    /// <summary>
    /// An iterator for a singly linked list ONLY
    /// </summary>
    /// <typeparam name="T">The type that is stored in the list</typeparam>
    public class LinkedListIterator<T> where T : new()
    {
        ISinglyNode<T> current;
        ISinglyNode<T> previous;
        SinglyLinkedList<T> list;

        /// <summary>
        /// Creates an iterator for the given list.
        /// </summary>
        /// <param name="linkedList">The list to iterate.</param>
        public LinkedListIterator(SinglyLinkedList<T> linkedList)
        {
            list = linkedList;
            current = list.getHeadNode();
            previous = null;
        }

        /// <summary>
        /// Inserts an item before the current node.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        /// <exception cref="InsertBeforeHeaderException"></exception>
        public void insertBeforeCurrent(T item)
        {
            if(current == list.getHeadNode())
            {
                throw new InsertBeforeHeaderException();
            }
            else
            {
                var node = new Node<T>(item);
                node.next = (Node<T>)current;
                previous.next = node;
            }
        }

        /// <summary>
        /// Inserts an item after the current node.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        public void insertAfterCurrent(T item)
        {
            var node = new Node<T>(item);
            node.next = current.next;
            current.next = node;
        }

        /// <summary>
        /// Removes the current node from the list and moves up.
        /// </summary>
        public void remove()
        {
            previous.next = current.next;
            current = current.next;
        }

        /// <summary>
        /// Returns the current node.
        /// </summary>
        /// <returns>Current node</returns>
        public Node<T> getCurrent()
        {
            return (Node<T>)current;
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
            current = list.getHeadNode();
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
