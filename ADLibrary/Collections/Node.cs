using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{

    public class Node<T> : ISinglyNode<T>, IDoublyNode<T>
    {
        public Node<T> next { get; set; }
        public Node<T> previous { get; set; }
        public T data { get; set; }

        public Node(T element)
        {
            this.data = element;
        }
    }
}
