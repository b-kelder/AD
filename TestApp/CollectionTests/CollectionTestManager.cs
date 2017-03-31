using System;
using ADLibrary.Collections;

namespace TestApp.Tests
{
    /// <summary>
    /// Handles test runs for collections.
    /// </summary>
    public class CollectionTestManager
    {
        private static Random random;
        System.Collections.Generic.List<ITestable> collectionTests;

        public CollectionTestManager()
        {
            random = new Random();
            collectionTests = new System.Collections.Generic.List<ITestable>();
        }

        private int[] getIntData(int amount)
        {
            int[] data = new int[amount];
            for(int i = 0; i < amount; i++)
            {
                data[i] = random.Next();
            }
            return data;
        }

        private PriorityItem[] getPQueueData(int amount, out PriorityItem first)
        {
            PriorityItem[] data = new PriorityItem[amount];
            first = null;
            for(int i = 0; i < amount; i++)
            {
                var pitem = new PriorityItem("Number " + i, random.Next());
                if(first == null || pitem.getPriority() > first.getPriority())
                {
                    first = pitem;
                }
                data[i] = pitem;
            }
            return data;
        }

        private void createTests()
        {
            collectionTests.Clear();

            // Shared test data
            var intData = getIntData(10000);
            PriorityItem pQueueHighestItem;
            var pQueueData = getPQueueData(10000, out pQueueHighestItem);

            // Tests
            // Stack
            var stackTest = new StackTest<int>();
            stackTest.setTestData(intData);
            collectionTests.Add(stackTest);

            // Queue
            var queueTest = new QueueTest<int>();
            queueTest.setTestData(intData);
            collectionTests.Add(queueTest);

            // PriorityQueue
            var pQueueTest = new PriorityQueueTest<PriorityItem>();
            pQueueTest.setTestData(pQueueData, pQueueHighestItem);
            collectionTests.Add(pQueueTest);
        }

        public void run()
        {
            createTests();

            int failed = 0;
            int cleared = 0;
            int exceptions = 0;

            outputLine("Starting test run");

            foreach(var test in collectionTests)
            {
                try
                {
                    if(test.runTest())
                    {
                        outputLine(test.name + " cleared!");
                        cleared++;
                    }
                    else
                    {
                        outputLine(test.name + " failed!");
                        failed++;
                    }
                }
                catch(Exception e)
                {
                    outputLine("Exception thrown when testing " + test.name + "\n" + e.Message + "\n" + e.StackTrace);
                    exceptions++;
                }
            }

            outputLine("Finished test run with the following results:");
            outputLine("Cleared:    " + cleared);
            outputLine("Failed:     " + failed);
            outputLine("Exceptions: " + exceptions);
        }

        private void outputLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
