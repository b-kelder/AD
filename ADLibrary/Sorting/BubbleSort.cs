using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    public class BubbleSort : ISorter
    {
        public void sort(IComparable[] array)
        {
            IComparable temp;

            for (int i = array.Length - 1; i >= 1; i--)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}