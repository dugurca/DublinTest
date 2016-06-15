using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DublinTest.NestedList.Test
{
    [TestFixture]
    class NestedListFlatterTest
    {
        [Test]
        public void BasicTests()
        {
            NestedListFlatter flatter = new NestedListFlatter();

            var nested1 = new List<object> {1};
            var flat1 = new List<int> {1};

            Assert.IsTrue( ListsEqual(flat1, flatter.FlattenRecursive(nested1)) );

            //[[1,2,[3]],4] → [1,2,3,4]
            var nested1234 = new List<object>
            {
                new List<object>
                {
                    1, 2, new List<object> { 3 }
                },
                4
            };

            Console.WriteLine(flatter.NestedListToString(nested1234));
            var flat1234 = new List<int> {1, 2, 3, 4};
            bool test1Res = ListsEqual(flat1234, flatter.FlattenRecursive(nested1234));
            Assert.IsTrue(test1Res);
        }

        [Test]
        public void StressTest()
        {
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int len = 5 + rand.Next()%1000;
                NestedListRandomTest(len);
            }
        }
        
        public void NestedListRandomTest(int n)
        {
            NestedListFlatter flatter = new NestedListFlatter();
            List<int> flatList = new List<int>();
            for (int i = 0; i < n; i++) flatList.Add(i);
            List<object> nestedList = RandomNestedList(n);
            List<int> flatNestedList = flatter.FlattenIterative(nestedList);
            
            Assert.AreEqual(true, ListsEqual(flatList, flatNestedList));
        }

        public List<object> RandomNestedList(int n)
        {
            Random rand = new Random();
            int index = 0;
            List<object> nestedList = new List<object>();
            List<object> inner = nestedList;

            while (index < n)
            {
                if (rand.NextDouble() > 0.5)
                    inner.Add(index++);
                else
                {
                    var newInnerList = new List<object>();
                    inner.Add(newInnerList);
                    inner = newInnerList;
                }
            }
            return nestedList;
        }

        public bool ListsEqual(List<int> list1, List<int> list2)
        {
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i]) return false;
            }
            return true;
        }
    }
}
