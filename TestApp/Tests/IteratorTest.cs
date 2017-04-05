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

            var iterator = new LinkedListIterator<T>(list);

            Assert.AreEqual(false, iterator.hasNext());
            iterator.insertAfterCurrent(new T());
            iterator.insertAfterCurrent(new T());
            iterator.insertAfterCurrent(new T());
            Assert.AreEqual(true, iterator.hasNext());

            iterator.advance();
            iterator.insertBeforeCurrent(new T());
            iterator.reset();
            iterator.advance();

            iterator.remove();
            iterator.remove();
            iterator.remove();
            iterator.remove();

            // Test on circular list
            var it = new LinkedListIterator<T>(new CircularList<T>());
            // Add two nodes after header
            it.insertAfterCurrent(new T());
            it.insertAfterCurrent(new T());
            it.advance();
            // Remove both nodes
            it.remove();
            it.remove();

            // Circular loop test
            int loops = 0;
            int targetLoops = 10;
            while(it.hasNext() && loops < targetLoops)
            {
                it.advance();
                loops++;
            }

            // Ensure we have looped as many times as we wanted
            // Otherwise we stopped due to it.hasNext() returning false and the list is not circular
            Assert.AreEqual(targetLoops, loops);
        }
    }
}
