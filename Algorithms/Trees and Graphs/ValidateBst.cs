// question: implement a function to check if a binary tree is a binary search tree

using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.Trees_and_Graphs
{
    public static class ValidateBst
    {
        // solution #1 copy and check if values are sorted
        public static int index = 0;
        private static void CopyBst(TreeNode root, int[] array)
        {
            if (root == null) return;
            CopyBst(root.left, array);
            array[index] = root.data;
            index++;
            CopyBst(root.right, array);
        }

        public static bool CheckBstArray(TreeNode root)
        {
            int[] array = new int[root.Size()];
            CopyBst(root, array);
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] <= array[i - 1]) return false;
            }

            return true;
        }

        private static int? last_printed = null;
        public static bool CheckBst(TreeNode n)
        {
            if (n == null) return true;

            // check / recurse left
            if (!CheckBst(n.left)) return false;

            // check current
            if (last_printed != null && n.data <= last_printed)
            {
                return false;
            }

            last_printed = n.data;

            // check / recurse right
            if (!CheckBst(n.right)) return false;

            return true;
        }

        // solution #2 optimized
        public static bool CheckBstOptimized(TreeNode n)
        {
            return CheckBstOptimized(n, null, null);
        }

        private static bool CheckBstOptimized(TreeNode n, int? min, int? max)
        {
            if (n == null)
            {
                return true;
            }

            if ((min != null && n.data <= min) || (max != null && n.data > max))
            {
                return false;
            }

            if (!CheckBstOptimized(n.left, min, n.data) || !CheckBstOptimized(n.right, n.data, max))
            {
                return false;
            }

            return true;
        }
    }
}
