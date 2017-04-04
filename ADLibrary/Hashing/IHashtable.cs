using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Hashing
{
    /// <summary>
    /// Interface for hashtables.
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TValue">The value type</typeparam>
    public interface IHashtable<TKey, TValue>
    {
        /// <summary>
        /// Amount of items in table.
        /// </summary>
        /// <returns>Amount of items in table.</returns>
        int count();
        /// <summary>
        /// Sets a key-value pair in the table.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        void set(TKey key, TValue value);
        /// <summary>
        /// Retrieves a value based on a key. default(TValue) is returned upon fail.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Value or default()</returns>
        TValue get(TKey key);
        /// <summary>
        /// Removes a key-value pair based on the key.
        /// </summary>
        /// <param name="key">The key of the pair to remove.</param>
        /// <returns>The value that was removed or default()</returns>
        TValue remove(TKey key);
    }
}
