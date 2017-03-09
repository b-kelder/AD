using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        private DoublyNode<T> head;
        private int nodeCount;

        public DoublyLinkedList() { }

        public void add(T data)
        {
            DoublyNode<T> toAdd = new DoublyNode<T>(data);
            DoublyNode<T> current = head;
            while (current != null)
            {
                current = current.next;
            }
            current.next = toAdd;
            toAdd.previous = current;
            nodeCount++;
        }

        public void remove(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    if (current == head)
                    {
                        head = current.next;
                    }
                    current.previous.next = current.next;
                    current.next.previous = current.previous;
                    return;
                }
                current = current.next;
            }
        }

        public void clear()
        {
            head = null;
            nodeCount = 0;
        }

        public bool contains(T item)
        {
            DoublyNode<T> current = head;
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

    internal class DoublyNode<T>
    {
        public DoublyNode<T> next { get; set; }
        public DoublyNode<T> previous { get; set; }
        public T data { get; set; }

        public DoublyNode(T element)
        {
            this.data = element;
        }
    }
}
