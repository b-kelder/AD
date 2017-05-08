using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Tests
{
    /// <summary>
    /// Interface for tests.
    /// </summary>
    interface ITestable
    {
        string name { get; }
        void runTest();
    }
}
