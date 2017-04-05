using System;
using ADLibrary.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.Tests
{
    public class DoublyLinkedListTest<K> : CollectionTestBase<DoublyLinkedList<K>, K>
    {
        public override string name
        {
            get
            {
                return "Doubly Linked List";
            }
        }

        public override void runTest()
        {
            var list = new DoublyLinkedList<K>();
           
            // Test add
            foreach(var item in testData)
            {
                list.add(item);
            }

            // Check length
            Assert.AreEqual(testData.Length, list.count());

            // Check removeAt
            int halfPoint = testData.Length / 2;
            K removedItem = list.removeAt(halfPoint);
            Assert.AreEqual(testData[halfPoint], removedItem);
            Assert.AreEqual(testData.Length - 1, list.count());

            // Check insert
            list.insert(removedItem, halfPoint);

            // Check length
            Assert.AreEqual(testData.Length, list.count());

            // Validate contents
            for(int i = 0; i < testData.Length; i++)
            {
                Assert.AreEqual(testData[i], list.get(i));
            }

            // Verify that the head exists
            /*if(list.getFirstNode() == null)
            {
                return false;
            }*/

            // Empty the list
            for(int i = 0; i < testData.Length; i++)
            {
                list.removeAt(0);
            }

            Assert.AreEqual(0, list.count());

            // Verify that the head is gone
            /*if(list.getFirstNode() != null)
            {
                return false;
            }*/
        }
    }
}
