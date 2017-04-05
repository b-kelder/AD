using System;
using ADLibrary.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.Tests
{
    class BSTTest<T> : CollectionTestBase<BinarySearchTree<T>, T> where T : IComparable
    {
        public override string name
        {
            get
            {
                return "Binary Search Tree";
            }
        }

        public override void runTest()
        {
            var bst = new BinarySearchTree<T>();

            var min = testData[0];
            var max = testData[0];

            foreach(var val in testData)
            {
                if(val.CompareTo(min) < 0)
                {
                    min = val;
                }
                if(val.CompareTo(max) > 0)
                {
                    max = val;
                }
                bst.add(val);
            }

            Assert.AreEqual(testData.Length, bst.count());

            // Check item count on remove
            var data = testData[testData.Length / 2];
            bst.remove(data);
            Assert.AreEqual(testData.Length - 1, bst.count());

            // Add it again and check contains()
            bst.add(data);
            Assert.AreEqual(true, bst.contains(data));

            // Check min and max
            Assert.AreEqual(min, bst.findMin());
            Assert.AreEqual(max, bst.findMax());

            // Check min removal and re-insert
            while(bst.contains(min))
            {
                bst.remove(min);
            }
            bst.add(min);
            Assert.AreEqual(min, bst.findMin());
        }
    }
}
