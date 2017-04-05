using System;
using ADLibrary.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.Tests
{
    public class StackTest<K> : CollectionTestBase<Stack<K>, K>
    {
        public override string name
        {
            get
            {
                return "Stack";
            }
        }

        public override void runTest()
        {
            var stack = new Stack<K>();

            // Test push
            for(int i = 0; i < this.testData.Length; i++)
            {
                stack.push(testData[i]);
            }

            // Count
            Assert.AreEqual(testData.Length, stack.count());

            // Test peek
            Assert.AreEqual(testData[testData.Length - 1], stack.peek());
            Assert.AreEqual(testData.Length, stack.count());

            // Test pop results
            for(int i = this.testData.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(testData[i], stack.pop());
            }

            // Count
            Assert.AreEqual(0, stack.count());
        }
    }
}
