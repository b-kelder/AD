namespace ADLibrary.Collections
{
    /// <summary>
    /// Bucket hash demo class.
    /// </summary>
    /// <typeparam name="T">The type to store</typeparam>
    public class BucketHash<T>
    {
        const int SIZE = 101;
        Arraylist<T>[] buckets;

        public BucketHash()
        {
            buckets = new Arraylist<T>[SIZE];
            for(int i = 0; i < SIZE; i++)
            {
                buckets[i] = new Arraylist<T>(1, 2);        // The buckets are lists of size 1 that double in size when full
            }
        }

        /// <summary>
        /// Hashes a key and returns a valid array index.
        /// </summary>
        /// <param name="key">The key to hash</param>
        /// <returns>Index for key</returns>
        private int hash(T key)
        {
            var i = key.GetHashCode();
            i = i % buckets.Length;
            if(i < 0)
            {
                i += buckets.Length;                                // Ensure the result is positive
            }
            return i;
        }

        /// <summary>
        /// Inserts an item in the collection.
        /// </summary>
        /// <param name="item">The item to insert</param>
        public void insert(T item)
        {
            var hashValue = hash(item);
            if(!buckets[hashValue].contains(item))                  // Only add it if it's not already stored in there
            {
                buckets[hashValue].add(item);
            }
        }

        /// <summary>
        /// Removes an item from the collection.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        public void remove(T item)
        {
            var hashValue = hash(item);
            buckets[hashValue].remove(item);
        }
    }
}
