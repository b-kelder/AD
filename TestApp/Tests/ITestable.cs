using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Tests
{
    interface ITestable
    {
        string name { get; }
        bool runTest();
    }
}
