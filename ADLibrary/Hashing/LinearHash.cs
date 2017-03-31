using System;
using System.Collections.Generic;

namespace ADLibrary.Hashing
{
    /// <summary>
    /// Demo class for Linear Hash implementation.
    /// </summary>

    public class LinearHash<TKey, TValue> : IHashtable<TKey, TValue>
    {
        KeyValuePair<TKey, TValue>[] table;

        private int itemCount;

        public LinearHash(int size)
        {
            table = new KeyValuePair<TKey, TValue>[size];
            itemCount = 0;
        }

        /// <summary>
        /// Returns the amount of items in the table.
        /// </summary>
        public int count()
        {
            return itemCount;
        }

        /// <summary>
        /// Returns an index for the table based on an item's hash value.
        /// </summary>
        /// <param name="key">The item.</param>
        /// <returns>Index based on item hash.</returns>
        private int hash(TKey key)
        {
            var hashValue = key.GetHashCode();
            hashValue = hashValue % table.Length;

            if(hashValue < 0)
            {
                hashValue += table.Length;
            }
            return hashValue;
        }

        /// <summary>
        /// Inserts an item into the table.
        /// </summary>
        /// <param name="item">The item to insert.</param>
        /// <exception cref="ArgumentException">Thrown when key equals default(TKey)</exception>
        public void set(TKey key, TValue item)
        {
            if(key == null || key.Equals(default(TKey)))
            {
                throw new ArgumentException("key can not be default(TKey) or NULL");
            }

            int index = hash(key);
            int offset = 0;
            while(offset < table.Length)                                    // Loop as long as we have space in the table
            {
                int iterationIndex = (index + offset) % table.Length;       // This ensures we check all spots in the table even if we start at the back
                if(table[iterationIndex].Key == null                        // Key of null or default(TKey) is considered empty
                    || table[iterationIndex].Key.Equals(default(TKey)))
                {
                    table[iterationIndex] = new KeyValuePair<TKey, TValue>(key, item);
                    itemCount++;                                            // Track item count
                    return;
                }
                else if(key.Equals(table[iterationIndex].Key))              // Overwrite an existing value
                {
                    table[iterationIndex] = new KeyValuePair<TKey, TValue>(key, item);
                    return;
                }

                offset++;                                   // Try the next spot
            }
            throw new HashTableFullException();             // The entire table has been checked, it must be full if we hit this point
        }

        /// <summary>
        /// Removes an item from the table.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        public TValue remove(TKey key)
        {
            if(key == null || key.Equals(default(TKey)))
            {
                throw new ArgumentException("key can not be default(TKey) or NULL");
            }

            int index = hash(key);
            int offset = 0;
            while(offset < table.Length)                    // Loop as long as we have space in the table
            {
                int iterationIndex = (index + offset) % table.Length;       // This ensures we check all spots in the table even if we start at the back
                if(table[iterationIndex].Key != null && table[iterationIndex].Key.Equals(key))
                {
                    TValue value = table[iterationIndex].Value;
                    table[iterationIndex] = new KeyValuePair<TKey, TValue>(default(TKey), default(TValue));
                    itemCount--;
                    return value;
                }

                offset++;                                   // Try the next spot
            }
            return default(TValue);
        }

        /// <summary>
        /// Returns the value associated with a key. default(TValue) on failure.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The value or default(TValue)</returns>
        public TValue get(TKey key)
        {
            if(key == null || key.Equals(default(TKey)))
            {
                throw new ArgumentException("key can not be default(TKey) or NULL");
            }

            int index = hash(key);
            int offset = 0;
            while(offset < table.Length)                    // Loop as long as we have space in the table
            {
                int iterationIndex = (index + offset) % table.Length;       // This ensures we check all spots in the table even if we start at the back
                if(table[iterationIndex].Key != null && table[iterationIndex].Key.Equals(key))
                {
                    return table[iterationIndex].Value;     // We found it so we return
                }

                offset++;                                   // Try the next spot
            }
            return default(TValue);
        }
    }
}
