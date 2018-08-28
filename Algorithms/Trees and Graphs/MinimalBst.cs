using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.Trees_and_Graphs
{
    public static class MinimalBst
    {
        public static TreeNode CreateMinimalBST(int[] array)
        {
            return CreateMinimalBST(array, 0, array.Length - 1);
        }

        public static TreeNode CreateMinimalBST(int[] arr, int start, int end)
        {
            if (end < start)
            {
                return null;
            }

            int mid = (start + end) / 2;
            TreeNode n = new TreeNode(arr[mid]);
            n.left = CreateMinimalBST(arr, start, mid - 1);
            n.right = CreateMinimalBST(arr, mid + 1, end);
            return n;
        }
    }
}
