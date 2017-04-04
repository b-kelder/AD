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


        SortingTestManager sortingTestManager;
        SearchingTestManager searchingTestManager;
        PerformanceTester pt;
        Random random;

        public MainForm()
        {
            random = new Random();
            sortingTestManager = new SortingTestManager();
            searchingTestManager = new SearchingTestManager();
            InitializeComponent();

            sortingTestManager.populateSortingTab(sortingListBox);
            searchingTestManager.populateSearchingTab(searchingListBox);

            searchingDataMethod.SelectedIndex = 0;
            searchingLocation.SelectedIndex = 2;
            sortingComboBox.SelectedIndex = 1;
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

        private string arrayToString<T>(T[] array)
        {
            var sb = new StringBuilder();
            sb.Append("(");
            foreach(var element in array)
            {
                sb.Append(element + ") - \r\n(");
            }
            sb.Append("FINISHED)");
            return sb.ToString();
        }
        #endregion

        private void buttonRun_Click(object sender, EventArgs e)
        {
            List<TestAction> actionsToTime = new List<TestAction>();
            Fisherman[] testData = null;
            Fisherman[] originalTestData = null;
            int targetIterations = 1;

            if(tabControl.SelectedTab == tabSorting)
            {
                if(sortingListBox.CheckedItems.Count > 0)
                {
                    // Generate some test data
                    testData = generateTestData(Convert.ToInt32(sortingUpDown.Value), getSelectedDataGenerationMode());
                    originalTestData = new Fisherman[testData.Length];
                    testData.CopyTo(originalTestData, 0);

                    // Generate test actions
                    actionsToTime = sortingTestManager.generateSortingActions(testData, sortingListBox.CheckedItems.Cast<SortingTestManager.SortingListItem>());

                    targetIterations = Convert.ToInt32(sortingIterations.Value);

                    // Log some info about the test data
                    log("Test data size: " + testData.Length);
                    log("Test data method: " + sortingComboBox.Text);
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
                    originalTestData = new Fisherman[testData.Length];
                    testData.CopyTo(originalTestData, 0);

                    Fisherman valueToFind = testData[testData.Length / 2];

                    actionsToTime = searchingTestManager.generateSearchingActions(testData, searchingListBox.CheckedItems.Cast<string>(), valueToFind);

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
            }

            // Run timed tests
            if(actionsToTime.Count > 0)
            {
                int testIndex = 0;
                int iterationCounter = 0;
                long totalTime = 0;                     // Used to store total time for all iterations of an action

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
                            // Log average time
                            log("Average time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime / targetIterations));
                            log("Total time for " + actionsToTime[testIndex].name + ": " + createMsString(totalTime) + " over " + targetIterations + " iterations");

                            log("Tests completed!");
                            log("");                        // Blank line

                            log(arrayToString(testData));

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
        private Fisherman[] generateTestData(int amount, DataGenerationMode method)
        {
            Fisherman[] arr = new Fisherman[amount];
            FishermanGenerator fmg = new FishermanGenerator();

            if(method == DataGenerationMode.Random)
            { 
                log("Generating random test data");
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = fmg.generateCompletelyRandomFisherman();
                }
            }
            else if(method == DataGenerationMode.Ascending)
            {
                log("Generating ascending test data");
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = fmg.generateRandomFisherman(i * 3);
                }
            }
            else if(method == DataGenerationMode.Descending)
            {
                log("Generating descending test data");
                for(int i = 0; i < arr.Length; i++)
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
