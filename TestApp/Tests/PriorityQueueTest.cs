using System;
using ADLibrary.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Tests
{
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

        public override bool runTest()
        {
            var queue = new PriorityQueue<T>(testData.Length);

            // Test enqueue
            for(int i = 0; i < this.testData.Length; i++)
            {
                queue.enqueue(testData[i]);
            }

            // Test peek result
            if(!queue.peek().Equals(expectedFirst))
            {
                return false;
            }

            // Test count results on dequeue
            int dataSize = this.testData.Length;
            for(int i = 0; i < this.testData.Length; i++)
            {
                queue.dequeue();
                if(queue.count() != dataSize - i - 1)           // Compare size with expected size
                {
                    return false;
                }
            }

            return true;
        }
    }
}
