using System;
using System.Collections.Generic;

namespace ADLibrary.Hashing
{
    /// <summary>
    /// Demo class for Quadratic Hash implementation.
    /// </summary>
    public class QuadraticHash<TKey, TValue> : IHashtable<TKey, TValue>
    {
        KeyValuePair<TKey, TValue>[] table;

        private int itemCount;

        public QuadraticHash(int size)
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
        /// Takes a hash and ensures it's a valid array index
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private int normalizeHash(int hash)
        {
            hash = hash % table.Length;
            if(hash < 0)
            {
                hash += table.Length;
            }
            return hash;
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

            int normalizedHash = normalizeHash(key.GetHashCode());
            int colCount = 0;
            while(colCount < table.Length)                                    // Loop as long as we have space in the table
            {
                if(table[normalizedHash].Key == null                        // Key of null or default(TKey) is considered empty
                    || table[normalizedHash].Key.Equals(default(TKey)))
                {
                    table[normalizedHash] = new KeyValuePair<TKey, TValue>(key, item);
                    itemCount++;                                            // Track item count
                    return;
                }
                else if(key.Equals(table[normalizedHash].Key))              // Overwrite an existing value
                {
                    table[normalizedHash] = new KeyValuePair<TKey, TValue>(key, item);
                    return;
                }

                normalizedHash = normalizeHash(key.GetHashCode() + colCount * colCount);    // Get next index by applying quadratic hash function
                colCount++;
            }
            throw new HashTableFullException();             // The entire table has been checked, it must be full if we hit this point
        }

        public static string arrayToString<T>(T[] array)
        {
            if(array == null)
                return "";

            var sb = new System.Text.StringBuilder();
            sb.Append("(");
            foreach(var element in array)
            {
                sb.Append(element + ") - \r\n(");
            }
            sb.Append("FINISHED)");
            return sb.ToString();
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

            int normalizedHash = normalizeHash(key.GetHashCode());
            int colCount = 0;
            while(colCount < table.Length)                    // Loop as long as we have space in the table
            {
                if(table[normalizedHash].Key != null && table[normalizedHash].Key.Equals(key))
                {
                    TValue value = table[normalizedHash].Value;
                    table[normalizedHash] = new KeyValuePair<TKey, TValue>(default(TKey), default(TValue));
                    itemCount--;
                    return value;
                }

                normalizedHash = normalizeHash(key.GetHashCode() + colCount * colCount);    // Get next index by applying quadratic hash function
                colCount++; 
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

            int normalizedHash = normalizeHash(key.GetHashCode());
            int colCount = 0;
            while(colCount < table.Length)                    // Loop as long as we have space in the table
            {
                if(table[normalizedHash].Key != null && table[normalizedHash].Key.Equals(key))
                {
                    return table[normalizedHash].Value;
                }

                normalizedHash = normalizeHash(key.GetHashCode() + colCount * colCount);    // Get next index by applying quadratic hash function
                colCount++;
            }
            return default(TValue);
        }
    }
}
