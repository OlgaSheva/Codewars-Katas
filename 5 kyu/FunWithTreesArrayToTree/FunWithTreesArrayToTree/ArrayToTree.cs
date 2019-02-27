using System;
using System.Collections.Generic;

namespace FunWithTreesArrayToTree
{
    public class TreeNode
    {

        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value, TreeNode left, TreeNode right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public TreeNode(int value)
        {
            this.value = value;
        }

        public override bool Equals(Object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != this.GetType()) return false;
            return Equals((TreeNode)other);
        }

        protected bool Equals(TreeNode other)
        {
            return Equals(left, other.left) && Equals(right, other.right) && value == other.value;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (left != null ? left.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (right != null ? right.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ value;
                return hashCode;
            }
        }
    }

    public class Solution
    {
        public static TreeNode ArrayToTree(int[] array)
        {
            if (array == null || array.Length == 0)
                return null;

            TreeNode[] treeNodes = new TreeNode[array.Length * 2 + 2];
            for (int i = array.Length - 1; i >= 0; i--)
            {
                treeNodes[i] = new TreeNode(array[i], treeNodes[i * 2 + 1], treeNodes[i * 2 + 2]);
            }

            return treeNodes[0];
        }
    }
}
