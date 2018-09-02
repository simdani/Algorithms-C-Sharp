// question: write an algorithm to find next node of a given node in a
// binary search tree.

using Algorithms.CTCI.Helpers;

namespace Algorithms.CTCI.Trees_and_Graphs
{
    public static class Successor
    {
        public static TreeNode InOrderSucc(TreeNode n)
        {
            if (n == null) return null;

            // found right children -> return leftmost node of right subtree
            if (n.right != null)
            {
                return LeftMostChild(n.right);
            }
            else
            {
                TreeNode q = n;
                TreeNode x = q.parent;
                // go up until we're on left instead of right
                while (x != null && x.left != q)
                {
                    q = x;
                    x = x.parent;
                }

                return x;
            }
        }

        private static TreeNode LeftMostChild(TreeNode n)
        {
            if (n == null)
            {
                return null;
            }

            while (n.left != null)
            {
                n = n.left;
            }

            return n;
        }
    }
}
