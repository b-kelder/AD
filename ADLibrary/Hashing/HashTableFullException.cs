using System;

namespace ADLibrary.Hashing
{
    /// <summary>
    /// Exception to throw when hash table is full.
    /// Used so the problem is immediately obvious from the name.
    /// </summary>
    public class HashTableFullException : Exception
    {
    }
}
