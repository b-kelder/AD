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
    public partial class MainForm : Form
    {
        class SortingListItem
        {
            string name;
            MethodInfo sortingMethod;

            public delegate void sort<T>(T[] array) where T : IComparable;

            public SortingListItem(Type sortingType)
            {
                name = sortingType.Name;
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

        /// <summary>
        /// List of actions that are currently being tested. Null if no test is running.
        /// </summary>
        List<Action> currentTestActions;
        int currentTestActionIndex;

        public MainForm()
        {
            InitializeComponent();

            pt = new PerformanceTester(() =>
            {
                var al = new Arraylist<int>();
                for(int i = 0; i < 1000000; i++)
                {
                    al.add(i);
                }
            }, genericTestCallback);

            populateCollectionsTab();
            populateSortingTab();
        }

        private void genericTestCallback(long ms)
        {
            MessageBox.Show("Result: " + ms + "ms");
            logBox.Invoke(new Action(() =>
            {
                logBox.Text += ("Test result: " + ms + "ms\r\n");
            }));
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            // Generate some test data
            var arr = generateSortingTestData<int>();

            var origArray = new int[arr.Length];
            arr.CopyTo(origArray, 0);

            // Generate test actions
            var actionsToTest = generateSortingActions<int>(arr);

            if(actionsToTest.Count > 0)
            {
                currentTestActions = actionsToTest;

                Action<int> runAction = null;
                Action<long> callback = (ms) => {
                    // Ensure that this is run from the main/UI thread
                    logBox.Invoke(new Action(() =>
                    {
                        logBox.AppendText("Test result: " + ms + "ms\r\n");

                        if(currentTestActionIndex + 1 < currentTestActions.Count)
                        {
                            // Run the next action in the list
                            runAction.Invoke(currentTestActionIndex + 1);
                        }
                        else
                        {
                            // Done testing, reset fields
                            currentTestActionIndex = 0;
                            currentTestActions = null;
                            logBox.AppendText("Test completed!\r\n");
                            onTestsFinished();
                        }
                    }));
                };

                runAction = (index) => {
                    currentTestActionIndex = index;

                    // Reset test array
                    origArray.CopyTo(arr, 0);

                    pt = new PerformanceTester(currentTestActions[index], callback);
                    pt.run();
                };

                // Start the first action
                onTestsStarted();
                runAction.Invoke(0);
            }
        }

        /// <summary>
        /// Generates an array with test data for sorting algorithms based on the form's current settings.
        /// </summary>
        private T[] generateSortingTestData<T>() where T : IComparable
        {
            T[] arr = new T[Convert.ToInt32(sortingUpDown.Value)];
            var rand = new Random();

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = default(T);// rand.Next() % 100;
            }
            return arr;
        }

        /// <summary>
        /// Generates actions used for performance testing of sorting algorithms.
        /// </summary>
        /// <typeparam name="T">The type the sorting data</typeparam>
        /// <param name="testData">The data to sort</param>
        /// <returns></returns>
        private List<Action> generateSortingActions<T>(T[] testData) where T : IComparable
        {
            var actions = new List<Action>();

            // Sorting tab
            foreach(var algorithm in sortingListBox.CheckedItems)
            {
                var sli = algorithm as SortingListItem;
                var d = sli.GetDelegate<T>();
                Action action = () =>
                {
                    d(testData);
                };
                actions.Add(action);
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

        private void onTestsFinished()
        {
            buttonRun.Enabled = true;
            testProgressBar.Value = 100;
        }

        private void onTestsStarted()
        {
            buttonRun.Enabled = false;
            testProgressBar.Value = 10;
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
    }
}
