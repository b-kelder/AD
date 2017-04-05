using System;
using ADLibrary.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.Tests
{
    public class QueueTest<K> : CollectionTestBase<Queue<K>, K>
    {
        public override string name
        {
            get
            {
                return "Queue";
            }
        }

        public override void runTest()
        {
            var queue = new Queue<K>();

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
            Assert.AreEqual(testData[0], queue.peek());

            // Test dequeue results
            for(int i = 0; i < this.testData.Length; i++)
            {
                Assert.AreEqual(testData[i], queue.dequeue());
            }

            // Count
            Assert.AreEqual(0, queue.count());
        }
    }
}
