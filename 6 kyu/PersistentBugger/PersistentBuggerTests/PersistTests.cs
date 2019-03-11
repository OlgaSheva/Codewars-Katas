using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersistentBugger;

namespace PersistTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            Assert.AreEqual(3, Persist.Persistence(39));
            Assert.AreEqual(0, Persist.Persistence(4));
            Assert.AreEqual(2, Persist.Persistence(25));
            Assert.AreEqual(4, Persist.Persistence(999));
        }
    }
}
