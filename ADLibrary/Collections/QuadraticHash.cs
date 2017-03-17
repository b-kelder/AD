using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    public class QuadraticHash<T>
    {
        const int SIZE = 101;               // Should be prime?

        T[] hashtable;

        public QuadraticHash()
        {
            hashtable = new T[SIZE];
        }

        /// <summary>
        /// Returns GetHashCode of key modulo SIZE.
        /// </summary>
        /// <param name="key">The key to hash</param>
        /// <returns>Positive array index</returns>
        public int hash(T key)
        {
            var i = key.GetHashCode();
            i = i % SIZE;
            if(i < 0)
            {
                i += SIZE;
            }
            return i;
        }

        public void insert(T key)
        {
            var j = 0;
            var normalizedHash = hash(key);
            if(hashtable[normalizedHash] == null)                   // Check if spot is empty
            {

            }
        }
    }
}
