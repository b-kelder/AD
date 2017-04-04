using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    /// <summary>
    /// Used to store info about an action that should be tested.
    /// </summary>
    public struct TestAction
    {
        public string name;
        public Action action;
    }
}
