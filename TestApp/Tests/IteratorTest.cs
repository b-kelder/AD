using ADLibrary.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestApp.Tests
{
    public class IteratorTest<T> : ITestable where T: new()
    {
        public string name
        {
            get
            {
                return "Linked List Iterator";
            }
        }

        public void runTest()
        {
            var list = new SinglyLinkedList<T>();
            list.add(new T());

            var iterator = new LinkedListIterator<T>(list);

            Assert.AreEqual(false, iterator.hasNext());
            iterator.insertAfterCurrent(new T());
            iterator.insertAfterCurrent(new T());
            iterator.insertAfterCurrent(new T());
            Assert.AreEqual(false, iterator.hasNext());

            iterator.insertBeforeCurrent(new T());
            Assert.AreEqual(true, iterator.hasNext());

            iterator.reset();
            iterator.remove();
        }
    }
}
