using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Leetcode.Problems200_299
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }
    public class DeleteNodeProblem
    {
        public void DeleteNode(ListNode node)
        {
            if (node.next != null)
            {
                node.val = node.next.val;
                node.next = node.next.next;
            }
            
        }
    }
}
