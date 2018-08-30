// question: implement a function to check if a binary tree is balanced

using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.Trees_and_Graphs
{
    public static class CheckBalanced
    {
        // solution #1
        private static int GetHeight(TreeNode root)
        {
            if (root == null) return -1; //base case
            return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
        }

        public static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true; // base case

            int heightDiff = GetHeight(root.left) - GetHeight(root.right);
            if (Math.Abs(heightDiff) > 1)
            {
                return false;
            }
            else
            {
                // recuresively check
                return IsBalanced(root.left) && IsBalanced(root.right);
            }
        }

        // solution #2
        private static int CheckheightOptimized(TreeNode root)
        {
            if (root == null) return -1;

            int leftHeight = CheckheightOptimized(root.left);
            if (leftHeight == int.MinValue) return int.MinValue; // pass error up

            int rightHeight = CheckheightOptimized(root.right);
            if (rightHeight == int.MinValue) return int.MinValue; // pass errour up

            int heightDiff = leftHeight - rightHeight;
            if (Math.Abs(heightDiff) > 1)
            {
                return int.MinValue; // foudn error
            }
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public static bool IsBalancedOptimized(TreeNode root)
        {
            return CheckheightOptimized(root) != int.MinValue;
        }
    }
}
