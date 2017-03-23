using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class DoublyLinkedList<T> : IList<T>
    {
        private DoublyNode<T> head;
        private int nodeCount;

        public DoublyLinkedList() { }

        public void add(T data)
        {
            DoublyNode<T> toAdd = new DoublyNode<T>(data);
            if (head == null)
            {
                head = toAdd;
            }
            else
            {
                DoublyNode<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                toAdd.previous = current;
                current.next = toAdd;
            }
            nodeCount++;
        }

        public T get(int index)
        {
            if (index >= nodeCount)
                throw new IndexOutOfRangeException();

            DoublyNode<T> nodeToGet = head;
            for (int i = 0; i < index; i++)
            {
                nodeToGet = nodeToGet.next;
            }

            return nodeToGet.data;
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
                    if(current.previous != null)
                    {
                        current.previous.next = current.next;
                    }
                    if (current.next != null)
                    {
                        current.next.previous = current.previous;
                    }
                    nodeCount--;
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
            T[] array = new T[nodeCount];

            DoublyNode<T> current = head;
            for (int i = 0; i < nodeCount; i++)
            {
                array[i] = current.data;
                current = current.next;
            }

            return array;
        }

        public int indexOf(T item)
        {
            DoublyNode<T> current = head;
            int index = 0;
            while (current != null)
            {
                if (current.data.Equals(item))
                {
                    return index;
                }
                index++;
                current = current.next;
            }
            return -1;
        }

        public T removeAt(int index)
        {
            if (index >= nodeCount && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            DoublyNode<T> nodeToRemove = head;
            for (int i = 0; i < index; i++)
            {
                nodeToRemove = nodeToRemove.next;
            }

            if (nodeToRemove == head)
            {
                head = nodeToRemove.next;
            }
            if (nodeToRemove.previous != null)
            {
                nodeToRemove.previous.next = nodeToRemove.next;
            }
            if (nodeToRemove.next != null)
            {
                nodeToRemove.next.previous = nodeToRemove.previous;
            }
            nodeCount--;
            return nodeToRemove.data;
        }

        public void insert(T item, int index)
        {
            if (index > nodeCount)
            {
                add(item);
            }

            DoublyNode<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }

            DoublyNode<T> toAdd = new DoublyNode<T>(item);
            toAdd.next = current.next;
            current.next = toAdd;
        }
    }
}
