using System;
using ADLibrary.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override bool runTest()
        {
            var queue = new Queue<K>();

            // Test enqueue
            for(int i = 0; i < this.testData.Length; i++)
            {
                queue.enqueue(testData[i]);
            }

            // Test peek result
            if(!queue.peek().Equals(testData[0]))
            {
                return false;
            }

            // Test dequeue results
            for(int i = 0; i < this.testData.Length; i++)
            {
                if(!queue.dequeue().Equals(testData[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
