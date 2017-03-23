using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class DoublyNode<T>
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
