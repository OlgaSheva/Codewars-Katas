using System;
using System.Collections.Generic;
using BestTravel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BestTravelTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("****** Basic Tests");
            List<int> ts = new List<int> { 50, 55, 56, 57, 58 };
            int? n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(163, n);

            ts = new List<int> { 50 };
            n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(null, n);

            ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
            n = SumOfK.chooseBestSum(230, 3, ts);
            Assert.AreEqual(228, n);
        }
    }
}
