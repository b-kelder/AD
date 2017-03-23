using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Collections
{
    /// <summary>
    /// Quadratic Hash demo.
    /// </summary>
    public class QuadraticHash
    {
        const int SIZE = 101;               // Size of the hashtable

        string[] hashtable;

        public QuadraticHash()
        {
            hashtable = new string[SIZE];
        }

        /// <summary>
        /// Takes a hash and ensures it's a valid array index
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private int normalizeHash(int hash)
        {
            hash = hash % SIZE;
            if(hash < 0)
            {
                hash += SIZE;
            }
            return hash;
        }

        /// <summary>
        /// Removes the key from the collection.
        /// </summary>
        /// <param name="key">The key to remove</param>
        public void remove(string key)
        {
            var index = indexOf(key);
            if(index > 0)
            {
                hashtable[index] = default(string);
            }
        }

        /// <summary>
        /// Returns the index of key in hashtable.
        /// -1 is returned when key can not be found.
        /// </summary>
        /// <param name="key">The key to find</param>
        /// <returns>Index of key in hashtable</returns>
        private int indexOf(string key)
        {
            var colCount = 0;                                           // Stores the amount of collisions we had
            var normalizedHash = normalizeHash(key.GetHashCode());
            while(colCount < SIZE)
            {
                if(hashtable[normalizedHash] != null &&
                    hashtable[normalizedHash].Equals(key))              // Check if spot is not empty and the key is stored here
                {
                    return normalizedHash;                              // Key was found, return index
                }
                else
                {
                    colCount++;
                    normalizedHash = normalizeHash(key.GetHashCode() + colCount * colCount);    // Get next index by applying quadratic hash function
                }
            }
            return -1;                                                  // Key not found
        }

        /// <summary>
        /// Inserts an item into the table.
        /// </summary>
        /// <param name="key">The item to add.</param>
        public void insert(string key)
        {
            var colCount = 0;                                           // Stores the amount of collisions we had
            var normalizedHash = normalizeHash(key.GetHashCode());
            while(colCount < SIZE)
            {
                if(hashtable[normalizedHash] == null)                   // Check if spot is empty
                {
                    hashtable[normalizedHash] = key;                    // Add an return
                    return;
                }
                else
                {
                    colCount++;
                    normalizedHash = normalizeHash(key.GetHashCode() + colCount * colCount);    // Get next index by applying quadratic hash function
                }
            }
            throw new HashTableFullException();                         // Hash table is full if j >= SIZE
        }
    }
}
