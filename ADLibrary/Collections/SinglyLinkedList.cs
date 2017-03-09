using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        private Node<T> next;
        private Node<T> head;

        public SinglyLinkedList()
        {

        }

        public void add(T element)
        {
            Node<T> toAdd = new Node<T>();
            toAdd.element = element;
            Node<T> current = head;
            while (current != null)
            {
                current = current.next;
            }
            current.next = toAdd;
        }

        public void clear()
        {
            head = null;
        }

        public bool contains(T item)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.element.Equals(item))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public int count()
        {
            int count = 0;
            Node<T> current = head;
            while (current != null)
            {
                current = current.next;
                count++;
            }
            return count;
        }

        public T[] toArray()
        {
            throw new NotImplementedException();
        }
    }

    internal class Node<T>
    {
        public Node<T> next { get; set; }
        public T element { get; set; }

        public Node()
        {

        }
    }
}
