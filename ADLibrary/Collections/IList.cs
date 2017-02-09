using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public interface IList<T>
    {
        void add(T item);
        T get(int index);
        int indexOf(T item);
        void remove(int index);
        int count();
    }
}
