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
using System.IO;

namespace TestApp
{
    public partial class UI : Form
    {
        enum DataGenerationMode
        {
            Random,
            Ascending,
            Descending
        }

        enum SearchingLocation
        {
            Start,
            Middle,
            End,
            Random
        }


        SortingTestManager sortingTestManager;
        SearchingTestManager searchingTestManager;
        CollectionTestManager collectionTestManager;
        PerformanceTester pt;
        Random random;

        /// <summary>
        /// The amount of times each test action should be run.
        /// </summary>
        int testTargetIterations;
        /// <summary>
        /// The data array used for testing search and sorting algorithms.
        /// Gets restored from testDataBackup between actions.
        /// </summary>
        Fisherman[] testData;
        /// <summary>
        /// A copy of the original test data.
        /// </summary>
        Fisherman[] testDataBackup;
        /// <summary>
        /// A sorted copy of the original test data.
        /// </summary>
        Fisherman[] testDataSortedCopy;
        /// <summary>
        /// The actions that are being tested.
        /// </summary>
        List<TestAction> testActions;
        /// <summary>
        /// The value the search algorithms should find.
        /// </summary>
        Fisherman testValueToFind;
        /// <summary>
        /// Stores the result of the last search test.
        /// </summary>
        SearchingTestManager.SearchResult<Fisherman> testSearchResult;
        /// <summary>
        /// Indicates if the regular test data array is sorted (generated ascendingly)
        /// </summary>
        bool testDataIsAscending;

        public UI()
        {
            random = new Random();
            sortingTestManager = new SortingTestManager();
            searchingTestManager = new SearchingTestManager();
            collectionTestManager = new CollectionTestManager();

            InitializeComponent();

            sortingTestManager.populateSortingTab(sortingListBox);
            searchingTestManager.populateSearchingTab(searchingListBox);

            dataMethod.SelectedIndex = 0;
            searchingLocation.SelectedIndex = 2;

            buttonAbort.Enabled = false;

            saveFileDialog.Filter = "Text file|*.txt";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        #region output
        /// <summary>
        /// Writes text to the log box and ends with a newline.
        /// Can be called from other threads.
        /// </summary>
        /// <param name="text">The text to log</param>
        private void log(string text)
        {
            if (logBox.InvokeRequired)
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

        /// <summary>
        /// Sets up test data and list.
        /// </summary>
        /// <param name="ignoreUserSettings">When true ignores UI settings. Iterations: 10, Data amount: 10000, Item location: Middle</param>
        private void setUpTestData(bool ignoreUserSettings = false)
        {
            // Reset action list
            testActions = new List<TestAction>();
            testSearchResult = new SearchingTestManager.SearchResult<Fisherman>();

            // Set iterations
            testTargetIterations = ignoreUserSettings ? 10 : Convert.ToInt32(testIterationsUpDown.Value);                          // Amount of runs we do per action

            // Generate some test data
            var dgm = ignoreUserSettings ? DataGenerationMode.Random : getSelectedDataGenerationMode();
            testDataIsAscending = (dgm == DataGenerationMode.Ascending);
            int dataAmount = ignoreUserSettings ? 10000 : Convert.ToInt32(testDataAmountUpDown.Value);
            testData = generateTestData(dataAmount, dgm);
            testDataBackup = new Fisherman[testData.Length];
            testDataSortedCopy = new Fisherman[testData.Length];

            // Create copies
            testData.CopyTo(testDataBackup, 0);
            testData.CopyTo(testDataSortedCopy, 0);

            Array.Sort(testDataSortedCopy);

            // Get location of item to find
            var valueLocation = ignoreUserSettings ? SearchingLocation.Middle : getSelectedSearchingLocation();
            if(valueLocation == SearchingLocation.Middle)
            {
                testValueToFind = testData[testData.Length / 2];
            }
            else if(valueLocation == SearchingLocation.Start)
            {
                testValueToFind = testData[0];
            }
            else if(valueLocation == SearchingLocation.End)
            {
                testValueToFind = testData[testData.Length - 1];
            }
            else
            {
                testValueToFind = testData[random.Next(testData.Length)];
            }


            // Log some info about the test data
            log("Test data size: " + testData.Length);
            log("Test data method: " + dgm);
            log("Search item location: " + valueLocation);
            log("Test iterations: " + testTargetIterations);

            if(checkShowArray.Checked)
            {
                log("Test data array:");
                log(arrayToString(testData));
            }

            log("");            // Formatting

        }

        /// <summary>
        /// Runs the current contents of testActions.
        /// </summary>
        private void runTests()
        {
            // Run the added tests
            if(testActions.Count > 0)
            {
                int testIndex = 0;                      // The index in actionsToTime of the currently running test
                int iterationCounter = 0;               // The amount of times we have run the currently running test
                long totalTime = 0;                     // Used to store total time for all iterations of an action

                int progressBarDelta = 100 / (testActions.Count * testTargetIterations);
                if(progressBarDelta < 1)                // Progress bar won't work correctly for 100+ iterations but that's fine
                    progressBarDelta = 1;

                Action<int> runAction = null;           // Declare here because callback refers to it
                // Action run when a single test is finished
                Action<long> callback = (us) =>
                {
                    // Ensure that this is run from the main/UI thread
                    this.Invoke(new Action(() =>
                    {
                        log("Test result for " + testActions[testIndex].name + ": " + createMsString(us));
                        totalTime += us;

                        // Update progress bar
                        testProgressBar.Value = Math.Min(testProgressBar.Value + progressBarDelta, 100);

                        if(iterationCounter < testTargetIterations)
                        {
                            // We need more iterations, run the same test again
                            runAction.Invoke(testIndex);
                        }
                        else
                        {
                            // Done with all iterations for this action
                            // Log average time
                            log("Average time for " + testActions[testIndex].name + ": " + createMsString(totalTime / testTargetIterations));
                            log("Total time for " + testActions[testIndex].name + ": " + createMsString(totalTime) + " over " + testTargetIterations + " iterations");
                            // Print blank line for formatting
                            log("");

                            // Reset iteration specific things
                            iterationCounter = 0;
                            totalTime = 0;
                            
                            // Result checking
                            var type = testActions[testIndex].type;
                            if(type == TestAction.Type.Sorting)
                            {
                                // Compare array to expected result
                                bool fail = false;
                                int i = 0;
                                int l = testData.Length;
                                while(i < l && fail != true)
                                {
                                    if(testData[i].CompareTo(testDataSortedCopy[i]) != 0)
                                    {
                                        error("Sort mismatch at index " + i + " got " + testData[i] + " but expected " + testDataSortedCopy[i]);
                                        fail = true;
                                    }
                                    i++;
                                }
                                if(!fail)
                                {
                                    log("Sort result validated!");
                                }

                                // Print blank line for formatting
                                log("");
                            }
                            else if(type == TestAction.Type.Searching)
                            {
                                // Check and log search result

                                // Log search result
                                if(testSearchResult.index >= 0)
                                {
                                    if(testData[testSearchResult.index].CompareTo(testValueToFind) == 0)
                                    {
                                        log("Item found at index: " + testSearchResult.index);
                                    }
                                    else
                                    {
                                        error("Item " + testValueToFind + " found at " + testSearchResult.index + " does not match expected value! Found " + testData[testSearchResult.index] + ", expected " + testValueToFind);
                                    }
                                    
                                }
                                else if(testSearchResult.max != default(Fisherman))
                                {
                                    log("Max item found: " + testSearchResult.max);
                                }
                                else if(testSearchResult.min != default(Fisherman))
                                {
                                    log("Min item found: " + testSearchResult.min);
                                }
                                else
                                {
                                    error("Search for " + testValueToFind + " failed!");
                                }
                                // Print blank line for formatting
                                log("");
                            }

                            // Display array
                            if(checkShowArray.Checked && type != TestAction.Type.Other)
                            {
                                log("Array contents: ");
                                log(arrayToString(testData));

                                // Print blank line for formatting
                                log("");
                            }


                            if(testIndex + 1 >= testActions.Count)
                            {
                                // Done with all of the tests
                                log("Tests completed!");

                                onTestsFinished();
                            }
                            else
                            {
                                // Run the next action in the list
                                runAction.Invoke(testIndex + 1);
                            }
                        }
                    }));
                };

                // Runs the TestAction located at index in the list
                runAction = (index) =>
                {
                    testIndex = index;
                    iterationCounter++;

                    // Reset test array
                    testDataBackup.CopyTo(testData, 0);
                    testSearchResult.clear();

                    // Hardcoded warning for BinarySearch
                    if(!testDataIsAscending && testActions[index].name == "BinarySearch")
                    {
                        warning("Trying to run BinarySearch on unsorted data!");
                    }

                    // Run test
                    pt = new PerformanceTester(testActions[index].action, callback);
                    pt.run();
                };

                // Start the first action
                onTestsStarted();
                runAction.Invoke(0);
            }
        }



        /// <summary>
        /// Event handler for default/all test button.
        /// Runs all tests with default settings.
        /// </summary>
        private void buttonStartDefaultTest_Click(object sender, EventArgs e)
        {
            // Setup and run sorting and searching tests
            setUpTestData(true);

            testActions.AddRange(sortingTestManager.generateSortingActions(testData, sortingListBox.Items.Cast<SortingTestManager.SortingListItem>()));
            testActions.AddRange(searchingTestManager.generateSearchingActions(testData, searchingListBox.Items.Cast<string>(), testValueToFind, testSearchResult));

            runTests();
        }

        /// <summary>
        /// Event handler for custom test button.
        /// Only runs the tests that are selected in the settings menu.
        /// </summary>
        private void buttonStartCustomTest_Click(object sender, EventArgs e)
        {
            setUpTestData();

            // Sorting algorithms
            if (sortingListBox.CheckedItems.Count > 0)
            {
                // Generate test actions
                testActions.AddRange(sortingTestManager.generateSortingActions(testData, sortingListBox.CheckedItems.Cast<SortingTestManager.SortingListItem>()));
            }
            // Searching algorithms
            if (searchingListBox.CheckedItems.Count > 0)
            {
                // Get the test actions
                testActions.AddRange(searchingTestManager.generateSearchingActions(testData, searchingListBox.CheckedItems.Cast<string>(), testValueToFind, testSearchResult));
            }
            // Warning
            if(testActions.Count < 1)
            {
                warning("No algorithms selected!");
            }

            runTests();            
        }

        /// <summary>
        /// Event handler for custom test button.
        /// Runs all possible tests.
        /// </summary>
        private void buttonTestCollections_Click(object sender, EventArgs e)
        {
            // Setup and run collection tests
            setUpTestData();
            testTargetIterations = 1;               // Not timed so only worth doing once
            // Collection tests
            // These are a bit different, they all run in one go for all of them instead of seperate
            testActions.Add(new TestAction
            {
                action = () => {
                    log("Testing Collections...");
                    collectionTestManager.run(1, true);
                    log(collectionTestManager.ToString());
                    collectionTestManager.clearBuffer();
                },
                name = "Collection tests",
            });
            runTests();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            if (pt != null)
            {
                pt.abort();
                warning("Test aborted!");
                onTestsFinished();
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            logBox.Clear();
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
            string text = dataMethod.Text;
            if (text.Equals("Random"))
            {
                return DataGenerationMode.Random;
            }
            else if (text.Equals("Ascending"))
            {
                return DataGenerationMode.Ascending;
            }
            else if (text.Equals("Descending"))
            {
                return DataGenerationMode.Descending;
            }
            return (DataGenerationMode)(-1);
        }

        private SearchingLocation getSelectedSearchingLocation()
        {
            string text = searchingLocation.Text;
            if(text.Equals("Random"))
            {
                return SearchingLocation.Random;
            }
            else if(text.Equals("Start"))
            {
                return SearchingLocation.Start;
            }
            else if(text.Equals("Middle"))
            {
                return SearchingLocation.Middle;
            }
            else if(text.Equals("End"))
            {
                return SearchingLocation.End;
            }
            return (SearchingLocation)(-1);
        }

        /// <summary>
        /// Generates an array with test data for sorting algorithms based on the form's current settings.
        /// </summary>
        /// <param name="amount">The size of the array.</param>
        /// <param name="method">The sort of data to generate (Random, Ascending, Descending)</param>
        private Fisherman[] generateTestData(int amount, DataGenerationMode method)
        {
            Fisherman[] arr = new Fisherman[amount];
            FishermanGenerator fmg = new FishermanGenerator();

            if (method == DataGenerationMode.Random)
            {
                log("Generating random test data");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = fmg.generateCompletelyRandomFisherman();
                }
            }
            else if (method == DataGenerationMode.Ascending)
            {
                log("Generating ascending test data");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = fmg.generateFisherman(i, 21, false);
                }
            }
            else if (method == DataGenerationMode.Descending)
            {
                log("Generating descending test data");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = fmg.generateFisherman((arr.Length - i), 21, false);
                }
            }
            else
            {
                error("Invalid test data generation method selected!");
            }

            return arr;
        }

        /// <summary>
        /// Called when tests are finished.
        /// Sets UI to the correct state.
        /// Also prints seperator in the log.
        /// </summary>
        private void onTestsFinished()
        {
            buttonStartCustomTest.Enabled = true;
            buttonStartAllTest.Enabled = true;
            buttonTestCollections.Enabled = true;
            buttonAbort.Enabled = false;
            testProgressBar.Value = 100;

            log("");
            log("------------------------------------------------------------");
            log("");
        }

        /// <summary>
        /// Called when tests are started.
        /// </summary>
        private void onTestsStarted()
        {
            buttonStartCustomTest.Enabled = false;
            buttonStartAllTest.Enabled = false;
            buttonTestCollections.Enabled = false;
            buttonAbort.Enabled = true;
            testProgressBar.Value = 0;
        }

        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure the test thread is aborted before we close the window.
            // This prevents issues with a callback being invoked after the window is already closed.
            if (pt != null)
            {
                pt.abort();
            }
        }

        /// <summary>
        /// Button handler for log saving
        /// </summary>
        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using(var file = File.Open(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                {
                    using(var sw = new StreamWriter(file))
                    {
                        sw.Write(logBox.Text);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Takes an array and returns a string of it's contents.
        /// </summary>
        /// <typeparam name="T">The type in the array.</typeparam>
        /// <param name="array">The array.</param>
        /// <returns>Formatted string containing all elements of the array.</returns>
        private string arrayToString<T>(T[] array)
        {
            if (array == null)
                return "";

            var sb = new StringBuilder();
            sb.Append("(");
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                sb.Append(array[i]);
                if (i < length - 1)
                {
                    sb.Append(") - \r\n(");
                }
                else
                {
                    sb.Append(")");
                }
            }

            return sb.ToString();
        }
    }
}
