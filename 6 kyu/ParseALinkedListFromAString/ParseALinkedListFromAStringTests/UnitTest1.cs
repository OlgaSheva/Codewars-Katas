using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseALinkedListFromAString;

namespace ParseALinkedListFromAStringTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SampleTest()
        {
            Assert.AreEqual(new Node(1, new Node(2, new Node(3))), Kata.Parse("1 -> 2 -> 3 -> null"));
            Assert.AreEqual(new Node(0, new Node(1, new Node(4, new Node(9, new Node(16))))), Kata.Parse("0 -> 1 -> 4 -> 9 -> 16 -> null"));
            Assert.AreEqual(null, Kata.Parse("null"));
        }
    }
}
