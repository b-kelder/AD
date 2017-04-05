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
        /// <summary>
        /// Generates actions for searching algorithms. WARNING: BinarySearch DOES NOT work on unsorted data sets.
        /// </summary>
        /// <typeparam name="T">The type of data.</typeparam>
        /// <param name="testData">The test data array.</param>
        /// <param name="algortihmNames">Names of the algorithms to test, matching those returned by populateSearchingTab</param>
        /// <param name="valueToFind">The value to find in the array.</param>
        /// <returns></returns>
        public List<TestAction> generateSearchingActions<T>(T[] testData, IEnumerable<string> algortihmNames, T valueToFind) where T : IComparable
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
                        action = () =>
                        {
                            BinarySearch.search(testData, valueToFind);
                        }
                    });
                }
                else if(checkedItem.Equals("SequentialSearch"))
                {
                    actions.Add(new TestAction()
                    {
                        name = "SequentialSearch",
                        action = () =>
                        {
                            SequentialSearch.search(testData, valueToFind);
                        }
                    });
                }
                else if(checkedItem.Equals("MinSearch"))
                {
                    actions.Add(new TestAction()
                    {
                        name = "MinSearch",
                        action = () =>
                        {
                            MinMaxSearch.findMin(testData);
                        }
                    });
                }
                else if(checkedItem.Equals("MaxSearch"))
                {
                    actions.Add(new TestAction()
                    {
                        name = "MaxSearch",
                        action = () =>
                        {
                            MinMaxSearch.findMax(testData);
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
