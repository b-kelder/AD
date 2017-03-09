﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        private SinglyNode<T> head;
        private int nodeCount;

        public SinglyLinkedList() { }

        public void add(T data)
        {
            SinglyNode<T> toAdd = new SinglyNode<T>(data);
            SinglyNode<T> current = head;
            while (current != null)
            {
                current = current.next;
            }
            current.next = toAdd;
            nodeCount++;
        }

        public void remove(T data)
        {
            SinglyNode<T> current = head;
            SinglyNode<T> previous = null;
            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    if (current == head)
                    {
                        head = current.next;
                    }
                    previous.next = current.next;
                    return;
                }
                previous = current;
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
            throw new NotImplementedException();
        }
    }

    internal class SinglyNode<T>
    {
        public SinglyNode<T> next { get; set; }
        //public Node<T> previous { get; set; }
        public T data { get; set; }

        public SinglyNode(T element)
        {
            this.data = element;
        }
    }
}
