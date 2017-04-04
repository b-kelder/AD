using ADLibrary.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApp
{

    public class SortingTestManager
    {
        #region Helper Classes
        /// <summary>
        /// Used to store sorting algorithms in a list box
        /// </summary>
        public class SortingListItem
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
        #endregion

        /// <summary>
        /// Used to store all Types that we test.
        /// </summary>
        Type[] sortingTypes;

        /// <summary>
        /// Creates and initializes a new SortingTestManager.
        /// </summary>
        public SortingTestManager()
        {
            sortingTypes = getSortingTypes();
        }

        /// <summary>
        /// Generates actions used for performance testing of sorting algorithms.
        /// </summary>
        /// <typeparam name="T">The type the sorting data</typeparam>
        /// <param name="testData">The data to sort</param>
        /// <param name="listItems">A list of SortingListItems to generate actions for.</param>
        /// <returns></returns>
        public List<TestAction> generateSortingActions<T>(T[] testData, IEnumerable<SortingListItem> listItems) where T : IComparable
        {
            var actions = new List<TestAction>();

            // Get checked items
            foreach(var sli in listItems)
            {
                // Get the correct delegate
                var sortingDelegate = sli.GetDelegate<T>();
                // Create and add the action to the list
                Action action = () =>
                {
                    sortingDelegate(testData);
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
        /// Sets up the tab for sorting testing.
        /// </summary>
        /// <param name="listBox">The checkedlistbox to populate</param>
        public void populateSortingTab(CheckedListBox listBox)
        {
            listBox.ClearSelected();
            listBox.Items.Clear();
            foreach(var type in sortingTypes)
            {
                listBox.Items.Add(new SortingListItem(type), false);
            }
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
    }
}
