using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{

    public class SinglyNode<T>
    {
        public SinglyNode<T> next { get; set; }
        public T data { get; set; }

        public SinglyNode(T element)
        {
            this.data = element;
        }
    }
}
