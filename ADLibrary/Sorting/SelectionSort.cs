using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    class SelectionSort : ISorter
    {
        public void sort(IComparable[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int indexSmallest = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[indexSmallest]) < 0)
                    {
                        indexSmallest = j;
                    }
                }

                IComparable temp = array[i];
                array[i] = array[indexSmallest];
                array[indexSmallest] = temp;
            }
        }
    }
}
