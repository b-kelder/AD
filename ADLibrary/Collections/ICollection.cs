using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    /// <summary>
    /// Interface for all our collections. 
    /// Based on .NET's ICollection but with the correct coding conventions.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICollection<T>
    {
        void add(T item);
        bool contains(T item);
        void remove(T item);
        void clear();
        int count();
        T[] toArray();
    }
}
