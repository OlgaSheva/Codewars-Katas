using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrandChildGetTheHabitFromUncle;

namespace GrandChildGetTheHabitFromUncleTests
{
    [TestClass]
    public class SonTests
    {
        Son son = new Son();
        Uncle uncle = new Uncle();
        Mom mom = new Mom();

        [TestMethod]
        public void FoodTest()
        {
            Assert.AreEqual(son.LikeFood(), mom.LikeFood());
        }

        [TestMethod]
        public void GarbageTest()
        {
            Assert.AreEqual(son.TakeTheGarbageOut(), uncle.TakeTheGarbageOut());
        }
    }
}
