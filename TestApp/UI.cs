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
    public partial class UI : Form
    {
        enum DataGenerationMode
        {
            Random,
            Ascending,
            Descending
        }


        SortingTestManager sortingTestManager;
        SearchingTestManager searchingTestManager;
        CollectionTestManager collectionTestManager;
        PerformanceTester pt;
        Random random;

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

        private void buttonStartDefaultTest_Click(object sender, EventArgs e)
        {
            //TODO: RUN EVERYTHING
        }

        private void buttonStartCustomTest_Click(object sender, EventArgs e)
        {
            // Things we need
            List<TestAction> actionsToTime = new List<TestAction>();        // TestActions that will be run
            Fisherman[] testData = new Fisherman[0];                        // Data array that gets passed to actions
            Fisherman[] originalTestData = new Fisherman[0];                // Copy of generated data
            int targetIterations = 1;                                       // Amount of runs we do per action

            // Generate some test data
            var dgm = getSelectedDataGenerationMode();
            testData = generateTestData(Convert.ToInt32(searchingUpDown.Value), dgm);
            originalTestData = new Fisherman[testData.Length];
            testData.CopyTo(originalTestData, 0);

            Fisherman valueToFind = testData[testData.Length / 2];

            targetIterations = Convert.ToInt32(searchingIterations.Value);

            // Log some info about the test data
            log("Test data size: " + testData.Length);
            log("Test data method: " + dataMethod.Text);

            // Sorting algorithms
            if (sortingListBox.CheckedItems.Count > 0)
            {
                // Generate test actions
                actionsToTime.AddRange(sortingTestManager.generateSortingActions(testData, sortingListBox.CheckedItems.Cast<SortingTestManager.SortingListItem>()));
            }
            // Searching algorithms
            else if (searchingListBox.CheckedItems.Count > 0)
            { 
                // Get the test actions
                actionsToTime.AddRange(searchingTestManager.generateSearchingActions(testData, searchingListBox.CheckedItems.Cast<string>(), valueToFind));
            }
            else
            {
                warning("No algorithms selected!");
            }

            // Collection tests
            // These are a bit different, they all run in one go for all of them instead of seperate
            actionsToTime.Add(new TestAction
            {
                action = () => { collectionTestManager.run(1, true); log(collectionTestManager.ToString()); },
                name = "Collection tests",
            });
            // Put something in the output log to ensure the user that things are happening
            log("Testing Collections...");


            // Run the added tests
            if (actionsToTime.Count > 0)
            {
                int testIndex = 0;                      // The index in actionsToTime of the currently running test
                int iterationCounter = 0;               // The amount of times we have run the currently running test
                long totalTime = 0;                     // Used to store total time for all iterations of an action

                int progressBarDelta = 100 / (actionsToTime.Count * targetIterations);
                if (progressBarDelta < 1)                // Progress bar won't work correctly for 100+ iterations but that's fine
                    progressBarDelta = 1;

                Action<int> runAction = null;           // Declare here because callback refers to it
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

                        if (iterationCounter < targetIterations)
                        {
                            // We need more iterations, run the same test again
                            runAction.Invoke(testIndex);
                        }
                        else if (testIndex + 1 < actionsToTime.Count)
                        {
                            // Done with all iterations for this action
                            // Log average time
                            log("Average time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime / targetIterations));
                            log("Total time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime) + " over " + targetIterations + " iterations");
                            // Print blank line for formatting
                            log("");

                            // Reset iteration specific things
                            iterationCounter = 0;
                            totalTime = 0;
                            // Run the next action in the list
                            runAction.Invoke(testIndex + 1);
                        }
                        else
                        {
                            // Done with all of the tests
                            // Log average time
                            log("Average time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime / targetIterations));
                            log("Total time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime) + " over " + targetIterations + " iterations");

                            log("Tests completed!");
                            log("");                        // Blank line

                            onTestsFinished();
                        }
                    }));
                };

                // Runs the TestAction located at index in the list
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
                    arr[i] = fmg.generateRandomFisherman(i * 3);
                }
            }
            else if (method == DataGenerationMode.Descending)
            {
                log("Generating descending test data");
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = fmg.generateRandomFisherman((arr.Length - i) * 3);
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
        /// </summary>
        private void onTestsFinished()
        {
            buttonStartCustomTest.Enabled = true;
            buttonStartDefaultTest.Enabled = true;
            buttonAbort.Enabled = false;
            testProgressBar.Value = 100;
        }

        /// <summary>
        /// Called when tests are started.
        /// </summary>
        private void onTestsStarted()
        {
            buttonStartCustomTest.Enabled = false;
            buttonStartDefaultTest.Enabled = false;
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
    }
}
