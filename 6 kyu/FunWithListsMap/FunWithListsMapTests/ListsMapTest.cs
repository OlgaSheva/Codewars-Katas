using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunWithListsMap;
using System.Collections.Generic;

namespace FunWithListsMapTests
{
    [TestClass]
    public class ListsMapTest
    {
        [TestMethod]
        public void BasicTests()
        {
            Assert.AreEqual(null, Kata.Map<string, string>(null, x => x));

            TestMap(Kata.Map<int, int>(new Node<int>(1, new Node<int>(2, new Node<int>(3))), n => n),
                new Node<int>(1, new Node<int>(2, new Node<int>(3))));
        }
        
        private static void TestMap<T>(Node<T> result, Node<T>expected)
        {
            CollectionAssert.AreEqual(ToList(expected), ToList(result));
        }
    
        private static List<Node<T>> ToList<T>(Node<T> head)
        {
            List<Node<T>> list = new List<Node<T>>();
            Node<T> next = head;
            while (next != null)
            {
                list.Add(next);
                next = next.next;
            }
            return list;
        }
    }
}
