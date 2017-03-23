namespace ADLibrary.Hashing
{
    /// <summary>
    /// Demo class for Linear Hash implementation.
    /// </summary>
    public class LinearHash
    {
        const int TABLE_SIZE = 101;
        string[] table;

        public LinearHash()
        {
            table = new string[TABLE_SIZE];
        }

        /// <summary>
        /// Returns an index for the table based on an item's hash value.
        /// </summary>
        /// <param name="key">The item.</param>
        /// <returns>Index based on item hash.</returns>
        private int hash(string key)
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
        public void insert(string item)
        {
            int index = hash(item);
            int offset = 0;
            while(offset < table.Length)                    // Loop as long as we have space in the table
            {
                int iterationIndex = (index + offset) % table.Length;       // This ensures we check all spots in the table even if we start at the back
                if(table[iterationIndex] == null)
                {
                    table[iterationIndex] = item;           // Store and return if spot is empty
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
        public void remove(string item)
        {
            int index = hash(item);
            int offset = 0;
            while(offset < table.Length)                    // Loop as long as we have space in the table
            {
                int iterationIndex = (index + offset) % table.Length;       // This ensures we check all spots in the table even if we start at the back
                if(table[iterationIndex] == item)
                {
                    table[iterationIndex] = null;           // Set spot to null if we find the item
                    return;
                }

                offset++;                                   // Try the next spot
            }
        }
    }
}
