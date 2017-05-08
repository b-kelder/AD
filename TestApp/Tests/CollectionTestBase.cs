using ADLibrary.Collections;
using System;
using System.Diagnostics;

namespace TestApp.Tests
{
    /// <summary>
    /// Base class for collection tests
    /// </summary>
    /// <typeparam name="T">The collection to test</typeparam>
    /// <typeparam name="K">The type to store in the collection</typeparam>
    public abstract class CollectionTestBase<T, K> : ITestable where T : ICollection<K>
    {
        public abstract string name { get; }
        protected K[] testData;

        public void setTestData(K[] testData)
        {
            this.testData = (K[])testData.Clone();
        }

        public abstract void runTest();
    }
}
