using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class SinglyLinkedList<T> : IList<T>
    {
        private SinglyNode<T> head;
        private int nodeCount;

        public SinglyLinkedList() { }

        public void add(T data)
        {
            SinglyNode<T> toAdd = new SinglyNode<T>(data);            
            if (head == null)
            {
                head = toAdd;
            }
            else
            {
                SinglyNode<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = toAdd;
            }
            nodeCount++;
        }

        public T get(int index)
        {
            if (index >= nodeCount)
                throw new IndexOutOfRangeException();

            SinglyNode<T> nodeToGet = head;
            for (int i = 0; i < index; i++)
            {
                nodeToGet = nodeToGet.next;
            }

            return nodeToGet.data;
        }

        public void remove(T data)
        {
            int index = indexOf(data);
            if (index >= 0)
            {
                removeAt(index);
            }
        }

        public T removeAt(int index)
        {
            if (index >= nodeCount && index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            SinglyNode<T> nodeToRemove = head;
            SinglyNode<T> previous = null;
            for (int i = 0; i < index; i++)
            {
                if (i == (index - 1))
                {
                    previous = nodeToRemove;
                }
                nodeToRemove = nodeToRemove.next;
            }

            if (nodeToRemove == head)
            {
                head = nodeToRemove.next;
            }
            if (previous != null)
            {
                previous.next = nodeToRemove.next;
            }
            nodeCount--;
            return nodeToRemove.data;
        }

        public void clear()
        {
            head = null;
            nodeCount = 0;
        }

        public bool contains(T item)
        {
            SinglyNode<T> current = head;
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

            SinglyNode<T> current = head;
            for (int i = 0; i < nodeCount; i++)
            {
                array[i] = current.data;
                current = current.next;
            }

            return array;
        }

        public int indexOf(T item)
        {
            SinglyNode<T> current = head;
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

        public void insert(T item, int index)
        {
            if (index > nodeCount)
            {
                add(item);
            }

            SinglyNode<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
            }

            SinglyNode<T> toAdd = new SinglyNode<T>(item);
            toAdd.next = current.next;
            current.next = toAdd;
        }

        public SinglyNode<T> getFirstNode()
        {
            return head;
        }
    }
}
