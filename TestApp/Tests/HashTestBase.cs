﻿using ADLibrary.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Tests
{
    public abstract class HashTestBase<TKey, TValue> : ITestable
    {
        protected KeyValuePair<TKey, TValue>[] testData;

        public abstract string name { get; }

        public virtual void setTestData(KeyValuePair<TKey, TValue>[] testData)
        {
            this.testData = testData;
        }

        public abstract void runTest();
    }
}
