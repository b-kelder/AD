using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Searching
{
    class BinarySearch
    {
        public static void search<T>(T[] array, T item) where T : IComparable
        {
            int low = 0;
            int high = array.Length - 1;
            int midpoint;

            while (low <= high)
            {
                midpoint = low + (high - low) / 2;

                if (item.CompareTo(array[midpoint]) == 0)
                    //TODO: ITEM FOUND
                    throw new NotImplementedException();
                else if (item.CompareTo(array[midpoint]) < 0)
                    high = midpoint - 1;
                else
                    low = midpoint + 1;
            }

            //TODO: NOT FOUND
            throw new NotImplementedException();
        }
    }
}
