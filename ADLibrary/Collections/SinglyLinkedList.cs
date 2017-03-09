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
        private int nodeCount;

        public SinglyLinkedList() { }

        public void add(T data)
        {
            Node<T> toAdd = new Node<T>(data);
            Node<T> current = head;
            while (current != null)
            {
                current = current.next;
            }
            current.next = toAdd;
            nodeCount++;
        }

        public void clear()
        {
            head = null;
            nodeCount = 0;
        }

        public bool contains(T item)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(item))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public int count()
        {
            return nodeCount;
        }

        public T[] toArray()
        {
            throw new NotImplementedException();
        }
    }

    internal class Node<T>
    {
        public Node<T> next { get; set; }
        public T data { get; set; }

        public Node(T element)
        {
            this.data = element;
        }
    }
}
