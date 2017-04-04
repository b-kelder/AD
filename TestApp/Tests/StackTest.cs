using System;
using ADLibrary.Collections;

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

        public override bool runTest()
        {
            var stack = new Stack<K>();

            // Test push
            for(int i = 0; i < this.testData.Length; i++)
            {
                stack.push(testData[i]);
            }

            // Test peek result
            if(!stack.peek().Equals(testData[testData.Length - 1]))
            {
                return false;
            }

            // Test pop results
            for(int i = this.testData.Length - 1; i >= 0; i--)
            {
                if(!stack.pop().Equals(testData[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
