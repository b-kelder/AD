using ADLibrary.Collections;
using System;
using System.Collections.Generic;

namespace ADLibrary.Hashing
{
    /// <summary>
    /// Bucket hash hashtable.
    /// </summary>
    /// <typeparam name="TKey">The type of the key</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public class BucketHash<TKey, TValue> : IHashtable<TKey, TValue>
    {
        Arraylist<KeyValuePair<TKey, TValue>>[] buckets;
        int itemCount;

        /// <summary>
        /// Creates a new BucketHash with the given max item count.
        /// </summary>
        /// <param name="size">Maximum amount of items (table size)</param>
        public BucketHash(int size)
        {
            // Create buckets
            buckets = new Arraylist<KeyValuePair<TKey, TValue>>[size];
            for(int i = 0; i < size; i++)
            {
                buckets[i] = new Arraylist<KeyValuePair<TKey, TValue>>(1, 2);        // The buckets are lists of size 1 that double in size when full
            }
            itemCount = 0;
        }

        /// <summary>
        /// The amount of items in the collection.
        /// </summary>
        /// <returns>Amount of items in the table.</returns>
        public int count()
        {
            return itemCount;
        }

        /// <summary>
        /// Hashes a key and returns a valid array index.
        /// </summary>
        /// <param name="key">The key to hash</param>
        /// <returns>Index for key</returns>
        private int hash(TKey key)
        {
            var i = key.GetHashCode();
            i = i % buckets.Length;
            if(i < 0)
            {
                i += buckets.Length;                        // Ensure the result is positive
            }
            return i;
        }

        /// <summary>
        /// Sets an item in the collection.
        /// </summary>
        /// <param name="key">The key to insert.</param>
        /// <param name="value">The value for the key.</param>
        /// /// <exception cref="ArgumentException">Thrown when key equals default(TKey)</exception>
        public void set(TKey key, TValue value)
        {
            if(key == null || key.Equals(default(TKey)))
            {
                throw new ArgumentException("key can not be default(TKey) or NULL");
            }

            var hashValue = hash(key);
            var kvPair = new KeyValuePair<TKey, TValue>(key, value);
            if(!buckets[hashValue].contains(kvPair))                    // Only add it if it's not already stored in there
            {
                var bucket = buckets[hashValue];
                var bucketSize = bucket.count();
                for(int i = 0; i < bucketSize; i++)                     // See if the key is already stored
                {
                    if(bucket[i].Key == null                            // null and default(TKey) are considered empty
                        || bucket[i].Key.Equals(default(TKey))          
                        || bucket[i].Key.Equals(key))
                    {
                        bucket[i] = kvPair;                             // Overwrite its value if that's the case
                        return;
                    }
                }

                bucket.add(kvPair);                                     // If the key's not in the bucket yet we add a new KV pair
                itemCount++;
            }
        }

        /// <summary>
        /// Returns an item based on it's key.
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The value associated with the key.</returns>
        public TValue get(TKey key)
        {
            if(key == null || key.Equals(default(TKey)))
            {
                throw new ArgumentException("key can not be default(TKey) or NULL");
            }

            var hashValue = hash(key);                                      // Get hash
            var bucket = buckets[hashValue];                                // Get bucket item should be in
            var bucketSize = bucket.count();                                // Store amount of buckets
            for(int i = 0; i < bucketSize; i++)                             // Check every bucket
            {
                if(bucket[i].Key.Equals(key))
                {
                    return bucket[i].Value;                                 // Found the key, return value
                }
            }
            return default(TValue);
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <returns>The value of the removed key.</returns>
        public TValue remove(TKey key)
        {
            if(key == null || key.Equals(default(TKey)))
            {
                throw new ArgumentException("key can not be default(TKey) or NULL");
            }

            var hashValue = hash(key);                              // Get hash
            var bucket = buckets[hashValue];                        // Get bucket item should be in
            var bucketSize = bucket.count();                        // Store amount of buckets
            for(int i = 0; i < bucketSize; i++)                     // Check every bucket
            {
                if(bucket[i].Key.Equals(key))                       // Found the item, key matches
                {
                    itemCount--;                                    // Update item count
                    return bucket.removeAt(i).Value;                // Remove item from bucket and return it
                }
            }
            return default(TValue);
        }
    }
}
