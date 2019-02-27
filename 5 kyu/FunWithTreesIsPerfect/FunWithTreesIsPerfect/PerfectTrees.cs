using System;
using System.Collections.Generic;

namespace FunWithTreesIsPerfect
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;

        public static bool IsPerfect(TreeNode root)
        {
            if (root == null)
                return true;

            if (root != null)
            {
                if (root.right == null && root.left == null)
                    return true;
                if (CountChildren(root.left) != CountChildren(root.right))
                {
                    return false;
                }
            }            

            return IsPerfect(root.right) && IsPerfect(root.left);
        }

        public static int CountChildren(TreeNode root)
        {
            if (root == null) return 0;
            return 1 + TreeNode.CountChildren(root.left) + TreeNode.CountChildren(root.right);
        }

        public static TreeNode Leaf()
        {
            return new TreeNode();
        }

        public static TreeNode Join(TreeNode left, TreeNode right)
        {
            return new TreeNode().WithChildren(left, right);
        }

        public TreeNode WithLeft(TreeNode left)
        {
            this.left = left;
            return this;
        }

        public TreeNode WithRight(TreeNode right)
        {
            this.right = right;
            return this;
        }

        public TreeNode WithChildren(TreeNode left, TreeNode right)
        {
            this.left = left;
            this.right = right;
            return this;
        }

        public TreeNode WithLeftLeaf()
        {
            return WithLeft(Leaf());
        }

        public TreeNode WithRightLeaf()
        {
            return WithRight(Leaf());
        }

        public TreeNode WithLeaves()
        {
            return WithChildren(Leaf(), Leaf());
        }

    }
}
