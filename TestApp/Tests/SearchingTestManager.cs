using ADLibrary.Searching;
using ADLibrary.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp.Tests
{

    public class SearchingTestManager
    {
        #region Helper classes
        /// <summary>
        /// Used to access result of search tests.
        /// </summary>
        public class SearchResult<T> where T : IComparable
        {
            public int index { get; set; }
            public T min { get; set; }
            public T max { get; set; }

            public void clear()
            {
                index = -1;
                min = default(T);
                max = default(T);
            }
        }
        #endregion

        /// <summary>
        /// Generates actions for searching algorithms.
        /// </summary>
        /// <typeparam name="T">The type of data.</typeparam>
        /// <param name="testData">The test data array.</param>
        /// <param name="sortedTestData">A sorted copy of the test data array. Used for BinarySearch.</param>
        /// <param name="algortihmNames">Names of the algorithms to test, matching those returned by populateSearchingTab</param>
        /// <param name="valueToFind">The value to find in the array.</param>
        /// <param name="result">Result object which will be updated to contain the result of the last run action.</param>
        /// <returns></returns>
        public List<TestAction> generateSearchingActions<T>(T[] testData, T[] sortedTestData, IEnumerable<string> algortihmNames, T valueToFind, SearchResult<T> result) where T : IComparable
        {
            var actions = new List<TestAction>();

            // Create test actions
            foreach(var checkedItem in algortihmNames)
            {
                if(checkedItem.Equals("BinarySearch"))
                {
                    actions.Add(new TestAction()
                    {
                        name = "BinarySearch",
                        type = TestAction.Type.Searching,
                        action = () =>
                        {
                            result.index = BinarySearch.search(sortedTestData, valueToFind);
                        }
                    });
                }
                else if(checkedItem.Equals("SequentialSearch"))
                {
                    actions.Add(new TestAction()
                    {
                        name = "SequentialSearch",
                        type = TestAction.Type.Searching,
                        action = () =>
                        {
                            result.index = SequentialSearch.search(testData, valueToFind);
                        }
                    });
                }
                else if(checkedItem.Equals("MinSearch"))
                {
                    actions.Add(new TestAction()
                    {
                        name = "MinSearch",
                        type = TestAction.Type.Searching,
                        action = () =>
                        {
                            result.min = MinMaxSearch.findMin(testData);
                        }
                    });
                }
                else if(checkedItem.Equals("MaxSearch"))
                {
                    actions.Add(new TestAction()
                    {
                        name = "MaxSearch",
                        type = TestAction.Type.Searching,
                        action = () =>
                        {
                            result.max = MinMaxSearch.findMax(testData);
                        }
                    });
                }
            }

            return actions;
        }


        /// <summary>
        /// Sets up the tab for sorting testing.
        /// </summary>
        /// <param name="listBox">The checkedlistbox to populate</param>
        public void populateSearchingTab(CheckedListBox listBox)
        {
            listBox.ClearSelected();
            listBox.Items.Clear();
            // Get the types of sorting algorithms that we have
            listBox.Items.Add("BinarySearch");
            listBox.Items.Add("SequentialSearch");
            listBox.Items.Add("MinSearch");
            listBox.Items.Add("MaxSearch");
        }
    }
}
