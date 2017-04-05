using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public interface ISinglyNode<T>
    {
        Node<T> next { get; set; }
        T data { get; set; }
    }
}
