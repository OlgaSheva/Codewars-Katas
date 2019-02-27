using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunWithTreesArrayToTree;

namespace FunWithTreesArrayToTreeTests
{
    [TestClass]
    public class ArrayToTreeTests
    {
        [TestMethod]
        public void EmptyArray()
        {
            TreeNode expected = null;
            Assert.AreEqual(expected, Solution.ArrayToTree(new int[] { }));
        }

        [TestMethod]
        public void ArrayWithMultipleElements()
        {
            TreeNode expected = new TreeNode(17, new TreeNode(0, new TreeNode(3), new TreeNode(15)), new TreeNode(-4));
            Assert.AreEqual(expected, Solution.ArrayToTree(new int[] { 17, 0, -4, 3, 15 }));
        }
    }
}
