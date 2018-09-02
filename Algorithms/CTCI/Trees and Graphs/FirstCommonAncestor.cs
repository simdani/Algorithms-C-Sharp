// question: fin the first common ancestor of two nodes in a binary tree

using System;
using Algorithms.CTCI.Helpers;

namespace Algorithms.CTCI.Trees_and_Graphs
{
    public static class FirstCommonAncestor
    {
        // solution #1 with links to parents
        public static TreeNode CommonAncestorWithLinks(TreeNode p, TreeNode q)
        {
            int delta = DepthWithLinks(p) - DepthWithLinks(q); // get depth difference
            TreeNode first = delta > 0 ? q : p;
            TreeNode second = delta > 0 ? p : q;
            second = GoUpByWithLinks(second, Math.Abs(delta));

            // find where paths intersect
            while (first != second && first != null && second != null)
            {
                first = first.parent;
                second = second.parent;
            }

            return first == null || second == null ? null : first;
        }

        private static TreeNode GoUpByWithLinks(TreeNode node, int delta)
        {
            while (delta > 0 && node != null)
            {
                node = node.parent;
                delta--;
            }

            return node;
        }

        private static int DepthWithLinks(TreeNode node)
        {
            int depth = 0;
            while (node != null)
            {
                node = node.parent;
                depth++;
            }

            return depth;
        }

        // solution #2 better worst-case scenario
        public static TreeNode CommonAncestorBetterWorst(TreeNode root, TreeNode p, TreeNode q)
        {
            // check if either node is not in the tree, or if one covers the other.
            if (!CoversBetterWorst(root, p) || !CoversBetterWorst(root, q))
            {
                return null;
            }
            else if (CoversBetterWorst(p, q))
            {
                return p;
            }
            else if (CoversBetterWorst(q, p))
            {
                return q;
            }

            // traverse upwards until you find a node that cover q.
            TreeNode sibling = GetSiblingBetterWorst(p);
            TreeNode parent = p.parent;
            while (!CoversBetterWorst(sibling, q))
            {
                sibling = GetSiblingBetterWorst(parent);
                parent = parent.parent;
            }

            return parent;
        }

        private static bool CoversBetterWorst(TreeNode root, TreeNode n)
        {
            if (root == null) return false;
            if (root == n) return true;
            return CoversBetterWorst(root.left, n) || CoversBetterWorst(root.right, n);
        }

        private static TreeNode GetSiblingBetterWorst(TreeNode node)
        {
            if (node == null || node.parent == null)
            {
                return null;
            }

            TreeNode parent = node.parent;
            return parent.left == node ? parent.right : parent.left;
        }
    }
}
