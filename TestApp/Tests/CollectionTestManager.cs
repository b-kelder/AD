using System;
using ADLibrary.Collections;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Tests
{
    /// <summary>
    /// Handles test runs for collections.
    /// </summary>
    public class CollectionTestManager
    {
        private static Random random;
        System.Collections.Generic.List<ITestable> collectionTests;
        StringBuilder stringBuilder;

        public CollectionTestManager()
        {
            random = new Random();
            stringBuilder = new StringBuilder();
            collectionTests = new System.Collections.Generic.List<ITestable>();
        }

        /// <summary>
        /// Generates many fishermen.
        /// </summary>
        /// <param name="amount">The amount of fishermen to generate.</param>
        /// <returns>Array of fishermen</returns>
        private Fisherman[] getFishermen(int amount)
        {
            var data = new Fisherman[amount];
            var fmg = new FishermanGenerator();

            for(int i = 0; i < amount; i++)
            {
                data[i] = fmg.generateRandomFisherman();
            }

            return data;
        }

        /// <summary>
        /// Creates integer test data.
        /// </summary>
        /// <param name="amount">The amount of entries.</param>
        /// <returns>Array of test data.</returns>
        private int[] getIntData(int amount)
        {
            int[] data = new int[amount];
            for(int i = 0; i < amount; i++)
            {
                data[i] = random.Next();
            }
            return data;
        }

        /// <summary>
        /// Creates test data for priority queues
        /// </summary>
        /// <param name="amount">The amount of entries.</param>
        /// <param name="first">The item with the highest priority.</param>
        /// <returns>Array of test data.</returns>
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

        /// <summary>
        /// Creates test data for hash tables.
        /// </summary>
        /// <param name="amount">The amount of entries.</param>
        /// <returns>Array of test data.</returns>
        private KeyValuePair<string, int>[] getHashTableData(int amount)
        {
            var data = new KeyValuePair<string, int>[amount];

            for(int i = 0; i < amount; i++)
            {
                data[i] = new KeyValuePair<string, int>("Entry nr. " + i, random.Next());
            }

            return data;
        }

        /// <summary>
        /// Creates tests and adds them to the list.
        /// </summary>
        private void createTests()
        {
            collectionTests.Clear();

            // Shared test data
            var intData = getIntData(10000);
            PriorityItem pQueueHighestItem;
            var pQueueData = getPQueueData(10000, out pQueueHighestItem);
            var hashTableData = getHashTableData(2500);
            var fishData = getFishermen(100000);

            // Tests
            // Stack
            var stackTest = new StackTest<int>();
            stackTest.setTestData(intData);
            collectionTests.Add(stackTest);

            // Queue
            var queueTest = new QueueTest<Fisherman>();
            queueTest.setTestData(fishData);
            collectionTests.Add(queueTest);

            // PriorityQueue
            var pQueueTest = new PriorityQueueTest<PriorityItem>();
            pQueueTest.setTestData(pQueueData, pQueueHighestItem);
            collectionTests.Add(pQueueTest);

            // Bucket Hash
            var bucketHashTest = new BucketHashTest<string, int>();
            bucketHashTest.setTestData(hashTableData);
            collectionTests.Add(bucketHashTest);

            // Linear Hash
            var linearHashTest = new LinearHashTest<string, int>();
            linearHashTest.setTestData(hashTableData);
            collectionTests.Add(linearHashTest);

            // Quadratic Hash
            var quadraticHashTest = new QuadraticHashTest<string, int>();
            quadraticHashTest.setTestData(hashTableData);
            collectionTests.Add(quadraticHashTest);

            // Arraylist
            var arraylistTest = new ArraylistTest<int>();
            arraylistTest.setTestData(intData);
            collectionTests.Add(arraylistTest);

            // Linked List

            // Doubly Linked List

            // Circular List

            // BST?????

            // Iterator???
        }

        /// <summary>
        /// Creates and runs all tests.
        /// </summary>
        /// <param name="times">The amount of times the tests should be run.</param>
        public void run(int times = 3)
        {
            createTests();

            int failed = 0;
            int cleared = 0;
            int exceptions = 0;

            outputLine("Starting test run");

            for(int i = 0; i < times; i++)
            {
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
                        outputLine("Exception thrown when testing " + test.name + "\r\n\t" + e.Message + "\r\n\t" + e.StackTrace);
                        exceptions++;
                    }
                }

                if(i < times - 1)
                {
                    outputLine("Done iteration with iteration " + (i + 1));
                }
            }

            outputLine("Finished test run with the following results:");
            outputLine("Iterations: " + times);
            outputLine("Cleared:    " + cleared);
            outputLine("Failed:     " + failed);
            outputLine("Exceptions: " + exceptions);
        }

        private void outputLine(string text)
        {
            stringBuilder.AppendLine(text);
            Console.WriteLine(text);
        }

        /// <summary>
        /// Returns the output as a string.
        /// </summary>
        public override string ToString()
        {
            return stringBuilder.ToString();
        }
    }
}
