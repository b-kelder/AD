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

namespace TestApp
{
    /// <summary>
    /// Main form used to test performance of collections and sorting algorithms in ADLibrary.
    /// </summary>
    public partial class MainForm : Form
    {
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
                Console.WriteLine(sortingMethod.Name);
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

        public MainForm()
        {
            InitializeComponent();

            populateCollectionsTab();
            populateSortingTab();

            var list = new Arraylist<string>();
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
            if(tabControl.SelectedTab == tabSorting)
            {
                if(sortingListBox.CheckedItems.Count > 0)
                {
                    // Generate some test data
                    var arr = generateSortingTestData();

                    var origArray = new int[arr.Length];
                    arr.CopyTo(origArray, 0);

                    // Generate test actions
                    var actionsToTest = generateSortingActions<int>(arr);

                    if(actionsToTest.Count > 0)
                    {
                        int testIndex = 0;
                        int iterationCounter = 0;
                        int targetIterations = Convert.ToInt32(sortingIterations.Value);
                        long totalTime = 0;                     // Used to store total time for all iterations of an action

                        int progressBarDelta = 100 / (actionsToTest.Count * targetIterations);
                        if(progressBarDelta < 1)                // Progress bar won't work correctly for 100+ iterations but that's fine
                            progressBarDelta = 1;

                        Action<int> runAction = null;
                        // Action run when a single test is finished
                        Action<long> callback = (ms) => 
                        {
                            // Ensure that this is run from the main/UI thread
                            this.Invoke(new Action(() =>
                            {
                                log("Test result for " + actionsToTest[testIndex].name + ": " + ms + "ms");
                                totalTime += ms;

                                // Update progress bar
                                testProgressBar.Value += progressBarDelta;

                                if(iterationCounter < targetIterations)
                                {
                                    // We need more iterations, run the same test again
                                    runAction.Invoke(testIndex);
                                }
                                else if(testIndex + 1 < actionsToTest.Count)
                                {
                                    // Log average time
                                    log("Average time for " + actionsToTest[testIndex].name + ": " + totalTime / targetIterations);

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
                                    // Log average time
                                    log("Average time for " + actionsToTest[testIndex].name + ": " + totalTime / targetIterations + "ms");
                                    log("Tests completed!");
                                    log("");                        // Blank line
                                    onTestsFinished();
                                }
                            }));
                        };

                        // Runs a test
                        runAction = (index) =>
                        {
                            testIndex = index;
                            iterationCounter++;

                            // Reset test array
                            origArray.CopyTo(arr, 0);

                            // Run test
                            pt = new PerformanceTester(actionsToTest[index].action, callback);
                            pt.run();
                        };

                        // Log some info about the test data
                        log("Test data size: " + arr.Length);
                        log("Test data method: " + sortingComboBox.Text);

                        // Start the first action
                        onTestsStarted();
                        runAction.Invoke(0);
                    }
                }
                else
                {
                    warning("No algorithms selected!");
                }
            }
            else
            {
                warning("Collection testing is not yet supported!");
            }
        }

        /// <summary>
        /// Generates an array with test data for sorting algorithms based on the form's current settings.
        /// </summary>
        private int[] generateSortingTestData()
        {
            int[] arr = new int[Convert.ToInt32(sortingUpDown.Value)];
            if(sortingComboBox.Text.Equals("Random"))
            {
                var rand = new Random();

                log("Generating random test data");
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next() % 1000;
                }
            }
            else if(sortingComboBox.Text.Equals("Ascending"))
            {
                log("Generating ascending test data");
                for(int i = 0; i < arr.Length; i++)
                {
                    arr[i] = i;
                }
            }
            else if(sortingComboBox.Text.Equals("Descending"))
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
            sortingComboBox.SelectedIndex = 0;                              // "Random"
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
            // Make sure they have a static sort method.
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
                            x.GetGenericTypeDefinition() == typeof(ADLibrary.Collections.ICollection<>))).ToArray();
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
    }
}
