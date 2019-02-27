using FunWithTreesIsPerfect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunWithTreesIsPerfectTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NullTreeShouldBePerfect()
        {
            TreeNode root = null;
            Assert.AreEqual(true, TreeNode.IsPerfect(root), "null tree should be perfect");
        }

        /**
         *   0
         *  / \
         * 0   0
         */
        [TestMethod]
        public void FullOneLevelTreeShouldBePerfect()
        {
            TreeNode root = TreeNode.Leaf().WithLeaves();
            Assert.AreEqual(true, TreeNode.IsPerfect(root), "root with two leaves should be perfect");
        }

        /**
         *   0
         *  /
         * 0
         */
        [TestMethod]
        public void OneChildTreeShouldNotBePerfect()
        {
            TreeNode root = TreeNode.Leaf().WithLeftLeaf();
            Assert.AreEqual(false, TreeNode.IsPerfect(root), "root with single leaf should not be perfect");
        }
    }
}
