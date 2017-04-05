using System;
using ADLibrary.Sorting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Tests
{
    public class SortingTest<T> : ITestable where T:IComparable
    {
        private T[] testData;

        public string name
        {
            get
            {
                return "Sorting?";
            }
        }

        public void setTestData(T[] testData)
        {
            this.testData = testData;
        }

        public void runTest()
        {
            HeapSort.sort(testData);
        }
    }
}
