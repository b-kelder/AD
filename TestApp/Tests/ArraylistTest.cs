using System;
using ADLibrary.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestApp.Tests
{
    public class ArraylistTest<K> : CollectionTestBase<Arraylist<K>, K>
    {
        public override string name
        {
            get
            {
                return "Arraylist";
            }
        }

        public override bool runTest()
        {
            var list = new Arraylist<K>();

            // Test add
            foreach(var item in testData)
            {
                list.add(item);
            }

            // Check length
            if(list.count() != testData.Length)
            {
                return false;
            }

            // Check removeAt
            int halfPoint = testData.Length / 2;
            K removedItem = list.removeAt(halfPoint);
            if(!removedItem.Equals(testData[halfPoint]) || list.count() != testData.Length - 1)
            {
                return false;
            }

            // Check insert
            list.insert(removedItem, halfPoint);
            
            // Validate contents
            for(int i = 0; i < testData.Length; i++)
            {
                if(!testData[i].Equals(list[i]) || !testData[i].Equals(list.get(i)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
