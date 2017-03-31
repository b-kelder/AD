using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADLibrary.Collections;
using ADLibrary.Performance;
using ADLibrary.Sorting;
using System.Reflection;
using ADLibrary.Searching;
using TestApp.Tests;

namespace TestApp
{
    /// <summary>
    /// Main form used to test performance of collections and sorting algorithms in ADLibrary.
    /// </summary>
    public partial class MainForm : Form
    {
        enum DataGenerationMode
        {
            Random,
            Ascending,
            Descending
        }

        /// <summary>
        /// Used to store info about an action that should be tested.
        /// </summary>
        struct TestAction
        {
            public string name;
            public Action action;
        }

        /// <summary>
        /// Used to store sorting algorithms in a list box
        /// </summary>
        class SortingListItem
        {
            string name;
            MethodInfo sortingMethod;

            // Delegate that matches the sorting algorithms' sort method
            public delegate void sort<T>(T[] array) where T : IComparable;

            public SortingListItem(Type sortingType)
            {
                name = sortingType.Name;
                // All sort classes must have a static method called sort
                sortingMethod = sortingType.GetMethod("sort", BindingFlags.Static | BindingFlags.Public);
            }

            public override string ToString()
            {
                return name;
            }

            /// <summary>
            /// Returns a delegate for the sort method of the bound sorting algorithm.
            /// </summary>
            /// <typeparam name="T">The type for which to generate the sort delegate</typeparam>
            /// <returns>Delegate for sorting T</returns>
            public sort<T> GetDelegate<T>() where T : IComparable
            {
                var method = sortingMethod.MakeGenericMethod(typeof(T));
                return Delegate.CreateDelegate(typeof(sort<T>), method, true) as sort<T>;
            }
        }

        Type[] collectionTypes;
        Type[] sortingTypes;

        PerformanceTester pt;
        Random random;

        public MainForm()
        {
            random = new Random();
            InitializeComponent();

            populateCollectionsTab();
            populateSortingTab();
            populateSearchingTab();
        }

        #region output
        /// <summary>
        /// Writes text to the log box and ends with a newline.
        /// Can be called from other threads.
        /// </summary>
        /// <param name="text">The text to log</param>
        private void log(string text)
        {
            if(logBox.InvokeRequired)
            {
                logBox.Invoke(new Action(() =>
                {
                    log(text);
                }));
                return;
            }
            logBox.AppendText(text + "\r\n");
        }

        private void error(string text)
        {
            log("ERROR: " + text);
        }

        private void warning(string text)
        {
            log("WARNING: " + text);
        }
        #endregion

        private void buttonRun_Click(object sender, EventArgs e)
        {
            List<TestAction> actionsToTime = new List<TestAction>();
            AdvancedLog advancedLog = new AdvancedLog();
            int[] testData = null;
            int[] originalTestData = null;
            int targetIterations = 1;

            if(tabControl.SelectedTab == tabSorting)
            {
                if(sortingListBox.CheckedItems.Count > 0)
                {
                    // Generate some test data
                    testData = generateTestData(Convert.ToInt32(sortingUpDown.Value), getSelectedDataGenerationMode());
                    originalTestData = new int[testData.Length];
                    testData.CopyTo(originalTestData, 0);

                    // Generate test actions
                    actionsToTime = generateSortingActions<int>(testData);

                    targetIterations = Convert.ToInt32(sortingIterations.Value);

                    // Log some info about the test data
                    log("Test data size: " + testData.Length);
                    log("Test data method: " + sortingComboBox.Text);

                    // Show the advanced log
                    if (checkBoxShowArray.Checked)
                    {
                        advancedLog.printUnsorted(testData);
                        advancedLog.Show();
                    }
                }
                else
                {
                    warning("No algorithms selected!");
                }
            }
            else if(tabControl.SelectedTab == tabSearching)
            {
                if(searchingListBox.CheckedItems.Count > 0)
                {
                    // Generate some test data
                    var dgm = getSelectedDataGenerationMode();
                    testData = generateTestData(Convert.ToInt32(searchingUpDown.Value), dgm);
                    originalTestData = new int[testData.Length];
                    testData.CopyTo(originalTestData, 0);

                    int valueToFind = testData[testData.Length / 2];

                    // Create test actions
                    foreach(var checkedItem in searchingListBox.CheckedItems)
                    {
                        if(checkedItem.Equals("BinarySearch"))
                        {
                            if(dgm == DataGenerationMode.Ascending)
                            {
                                actionsToTime.Add(new TestAction()
                                {
                                    name = "BinarySearch",
                                    action = () =>
                                    {
                                        BinarySearch.search(testData, valueToFind);
                                    }
                                });
                            }
                            else
                            {
                                warning("BinarySearch only works on sorted data sets, not running test!");
                            }
                        }
                        else if(checkedItem.Equals("SequentialSearch"))
                        {
                            actionsToTime.Add(new TestAction()
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
                            actionsToTime.Add(new TestAction()
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
                            actionsToTime.Add(new TestAction()
                            {
                                name = "MaxSearch",
                                action = () =>
                                {
                                    MinMaxSearch.findMax(testData);
                                }
                            });
                        }
                        else if (checkedItem.Equals("RandomSearch"))
                        {
                            actionsToTime.Add(new TestAction()
                            {
                                name = "RandomSearch",
                                action = () =>
                                {
                                    RandomSearch.search(testData, valueToFind);
                                }
                            });
                        }
                    }

                    targetIterations = Convert.ToInt32(searchingIterations.Value);
                }
                else
                {
                    warning("No algorithms selected!");
                }
            }
            else
            {
                //                warning("Collection testing is not yet supported!");
                onTestsStarted();

                CollectionTestManager ctm = new CollectionTestManager();
                ctm.run();
                log(ctm.ToString());

                onTestsFinished();
                return;
            }

            // Run the tests
            if(actionsToTime.Count > 0)
            {
                int testIndex = 0;
                int iterationCounter = 0;
                long totalTime = 0;                     // Used to store total time for all iterations of an action

                // TODO: Fix progress bar
                int progressBarDelta = 100 / (actionsToTime.Count * targetIterations);
                if(progressBarDelta < 1)                // Progress bar won't work correctly for 100+ iterations but that's fine
                    progressBarDelta = 1;

                Action<int> runAction = null;
                // Action run when a single test is finished
                Action<long> callback = (us) =>
                {
                    // Ensure that this is run from the main/UI thread
                    this.Invoke(new Action(() =>
                    {
                        log("Test result for " + actionsToTime[testIndex].name + ": " + createMsString(us));
                        totalTime += us;

                        // Update progress bar
                        testProgressBar.Value = Math.Min(testProgressBar.Value + progressBarDelta, 100);

                        if(iterationCounter < targetIterations)
                        {
                            // We need more iterations, run the same test again
                            runAction.Invoke(testIndex);
                        }
                        else if(testIndex + 1 < actionsToTime.Count)
                        {
                            // Log average time
                            log("Average time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime / targetIterations));
                            log("Total time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime) + " over " + targetIterations + " iterations");

                            // Reset iteration specific things
                            log("");                        // Blank line
                            iterationCounter = 0;
                            totalTime = 0;
                            // Run the next action in the list
                            runAction.Invoke(testIndex + 1);
                        }
                        else
                        {
                            // Done testing
                            advancedLog.printSorted(testData);
                            // Log average time
                            log("Average time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime / targetIterations));
                            log("Total time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime) + " over " + targetIterations + " iterations");

                            log("Tests completed!");
                            log("");                        // Blank line
                            onTestsFinished();
                        }
                    }));
                };

                // Runs the test action at index in the list
                runAction = (index) =>
                {
                    testIndex = index;
                    iterationCounter++;

                    // Reset test array
                    originalTestData.CopyTo(testData, 0);

                    // Run test
                    pt = new PerformanceTester(actionsToTime[index].action, callback);
                    pt.run();
                };

                // Start the first action
                onTestsStarted();
                runAction.Invoke(0);
            }
        }

        /// <summary>
        /// Creates a string with the format 0.00 ms
        /// </summary>
        /// <param name="microseconds">The value to convert in microseconds</param>
        /// <returns>String in ms</returns>
        private string createMsString(long microseconds)
        {
            return Math.Round(((double)microseconds) / 1000, 2) + " ms";
        }

        private DataGenerationMode getSelectedDataGenerationMode()
        {
            string text;
            if(tabControl.SelectedTab == tabSorting)
            {
                text = sortingComboBox.Text;
            }
            else
            {
                text = searchingDataMethod.Text;
            }
            if(text.Equals("Random"))
            {
                return DataGenerationMode.Random;
            }
            else if(text.Equals("Ascending"))
            {
                return DataGenerationMode.Ascending;
            }
            else if(text.Equals("Descending"))
            {
                return DataGenerationMode.Descending;
            }
            return (DataGenerationMode)(-1);
        }

        /// <summary>
        /// Generates an array with test data for sorting algorithms based on the form's current settings.
        /// </summary>
        /// <param name="amount">The size of the array.</param>
        /// <param name="method">The sort of data to generate (Random, Ascending, Descending)</param>
        private int[] generateTestData(int amount, DataGenerationMode method)
        {
            int[] arr = new int[amount];
            if(method == DataGenerationMode.Random)
            { 
                log("Generating random test data");
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = random.Next();
                }
            }
            else if(method == DataGenerationMode.Ascending)
            {
                log("Generating ascending test data");
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = i;
                }
            }
            else if(method == DataGenerationMode.Descending)
            {
                log("Generating descending test data");
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = arr.Length - i;
                }
            }
            else
            {
                error("Invalid test data generation method selected!");
            }

            return arr;
        }

        /// <summary>
        /// Generates actions used for performance testing of sorting algorithms.
        /// </summary>
        /// <typeparam name="T">The type the sorting data</typeparam>
        /// <param name="testData">The data to sort</param>
        /// <returns></returns>
        private List<TestAction> generateSortingActions<T>(T[] testData) where T : IComparable
        {
            var actions = new List<TestAction>();

            // Get checked items
            foreach(var algorithm in sortingListBox.CheckedItems)
            {
                var sli = algorithm as SortingListItem;
                // Get the correct delegate
                var d = sli.GetDelegate<T>();
                // Create and add the action to the list
                Action action = () =>
                {
                    d(testData);
                };
                actions.Add(new TestAction()
                {
                    action = action,
                    name = sli.ToString()
                });
            }

            return actions;
        }

        /// <summary>
        /// Called when tests are finished.
        /// </summary>
        private void onTestsFinished()
        {
            buttonRun.Enabled = true;
            testProgressBar.Value = 100;
        }

        /// <summary>
        /// Called when tests are started.
        /// </summary>
        private void onTestsStarted()
        {
            buttonRun.Enabled = false;
            testProgressBar.Value = 0;
        }

        /// <summary>
        /// Sets up the tab for collection testing.
        /// </summary>
        private void populateCollectionsTab()
        {
            collectionTypes = getCollectionTypes();
            foreach(var type in collectionTypes)
            {
                // Generic types have `1 behind their name so we remove that bit
                collectionsListBox.Items.Add(type.Name.Remove(type.Name.IndexOf('`')), false);
            }
        }

        /// <summary>
        /// Sets up the tab for sorting testing.
        /// </summary>
        private void populateSortingTab()
        {
            // Get the types of sorting algorithms that we have
            sortingTypes = getSortingTypes();
            foreach(var type in sortingTypes)
            {
                sortingListBox.Items.Add(new SortingListItem(type), false);
            }

            // Test data settings
            sortingComboBox.SelectedIndex = 0;                              // "Random" data generation
        }

        /// <summary>
        /// Sets up the tab for search testing.
        /// </summary>
        private void populateSearchingTab()
        {
            // Get the types of sorting algorithms that we have
            searchingListBox.Items.Add("BinarySearch");
            searchingListBox.Items.Add("SequentialSearch");
            searchingListBox.Items.Add("MinSearch");
            searchingListBox.Items.Add("MaxSearch");
            searchingListBox.Items.Add("RandomSearch");
            searchingListBox.Items.Add("THIS IS BROKEN PLS HALP");

            // Test data settings
            searchingDataMethod.SelectedIndex = 1;                          // "Ascending" data generation
            searchingLocation.SelectedIndex = 1;                            // Item is in the middle (start, middle, end, random)
        }

        /// <summary>
        /// Finds and returns all valid sorting types in the library.
        /// </summary>
        /// <returns>List of valid sorting types</returns>
        private Type[] getSortingTypes()
        {
            // Get all types in the sorting namespace
            var typelist = Util.getTypesInNamespace(Assembly.GetAssembly(typeof(BubbleSort)), "ADLibrary.Sorting");
            // Debug output
            for(int i = 0; i < typelist.Length; i++)
            {
                Console.WriteLine(typelist[i].Name);
            }
            // Make sure they have a static sort method
            return typelist.Where(t => null != t.GetMethod("sort", BindingFlags.Static | BindingFlags.Public)).ToArray();
        }

        /// <summary>
        /// Finds and returns all valid collection types in the library.
        /// </summary>
        /// <returns>Array of valid collection types</returns>
        private Type[] getCollectionTypes()
        {
            // Get all types in the collections namespace
            var typelist = Util.getTypesInNamespace(Assembly.GetAssembly(typeof(Arraylist<int>)), "ADLibrary.Collections");
            // Output to console for debugging
            for(int i = 0; i < typelist.Length; i++)
            {
                Console.WriteLine(typelist[i].Name);
            }
            // Make sure thay they implement our ICollection interface.
            return typelist.Where(t => t.GetInterfaces().Any(x =>
                            x.IsGenericType &&
                            x.GetGenericTypeDefinition() == typeof(ADLibrary.Collections.IList<>))).ToArray();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure the test thread is aborted before we close the window.
            // This prevents issues with a callback being invoked after the window is already closed.
            if(pt != null)
            {
                pt.abort();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            logBox.Clear();
        }

        private void sortingUpDown_ValueChanged(object sender, EventArgs e)
        {
            checkForAdvancedLog();
        }

        private void checkBoxShowArray_CheckedChanged(object sender, EventArgs e)
        {
            checkForAdvancedLog();
        }

        private void checkForAdvancedLog()
        {
            int limit = 100000;
            if (sortingUpDown.Value > limit)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Advanced log with more than " + limit);
                sb.AppendLine("items is not supported in the");
                sb.AppendLine("unregistered version.");
                labelWaring.Text = sb.ToString();
                checkBoxShowArray.Checked = false;
                checkBoxShowArray.Enabled = false;
            }
            else
            {
                checkBoxShowArray.Enabled = true;
                labelWaring.Text = "";
            }
        }
    }
}
