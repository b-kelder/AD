using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADLibrary.Sorting
{
    /// <summary>
    /// Interface for all sorting classes
    /// </summary>
    public interface ISorter
    {
        void sort(IComparable[] array);
    }
}
