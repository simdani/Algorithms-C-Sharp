using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems200_299;

namespace Algorithms.Leetcode.Problems1_99
{
    public class RemoveNthNodeFromList
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null)
            {
                fast = fast.next;
                if (n-- < 0)
                {
                    slow = slow.next;
                }
            }

            if (n == 0)
            {
                head = head.next;
            } else if (n < 0)
            {
                slow.next = slow.next.next;
            }
            else
            {
                return null;
            }

            return head;
        }
    }
}
