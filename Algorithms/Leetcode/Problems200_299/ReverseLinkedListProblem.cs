using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Leetcode.Problems200_299
{
    public class ReverseLinkedListProblem
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            ListNode next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            head = prev;
            return head;
        }
    }
}
