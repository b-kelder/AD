using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Searching
{
    public class RandomSearch
    {
        public static int search<T>(T[] array, T item) where T : IComparable
        {
            int length = array.Length;
            Random rand = new Random();
            while (true)
            {
                int index = rand.Next(0, length);
                if (array[index].CompareTo(item) == 0)
                {
                    return index;
                }
            }
        }
    }
}
