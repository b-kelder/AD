using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public interface ICollection<T>
    {
        void add(T item);
        T get(int index);
        int indexOf(T item);
        bool contains(T item);
        void insert(T item, int index);
        void remove(int index);
        int count();
    }
}
