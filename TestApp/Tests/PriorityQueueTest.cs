using System;
using ADLibrary.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.Tests
{
    /// <summary>
    /// Tests for PriorityQueue collection.
    /// </summary>
    /// <typeparam name="T">Type to store</typeparam>
    public class PriorityQueueTest<T> : CollectionTestBase<PriorityQueue<T>, T> where T : IComparable
    {
        private T expectedFirst;

        public override string name
        {
            get
            {
                return "Priority Queue";
            }
        }

        /// <summary>
        /// Sets test data for testing.
        /// </summary>
        /// <param name="array">Array of test data</param>
        /// <param name="firstValue">The item with the highest priority</param>
        public void setTestData(T[] array, T firstValue)
        {
            this.testData = array;
            this.expectedFirst = firstValue;
        }

        public override void runTest()
        {
            var queue = new PriorityQueue<T>(testData.Length);

            // Test enqueue
            for(int i = 0; i < this.testData.Length; i++)
            {
                queue.enqueue(testData[i]);
            }

            // Count
            Assert.AreEqual(testData.Length, queue.count());

            // Contains
            Assert.AreEqual(true, queue.contains(testData[0]));

            // Test peek result
            Assert.AreEqual(this.expectedFirst, queue.peek());

            // Test count results on dequeue
            int dataSize = this.testData.Length;
            for(int i = 0; i < this.testData.Length; i++)
            {
                queue.dequeue();
                Assert.AreEqual(dataSize - i - 1, queue.count());           // Compare size with expected size
            }
        }
    }
}
