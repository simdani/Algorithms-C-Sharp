using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Leetcode.Problems200_299
{
    public class PalindromeLinkedList
    {
        public Boolean IsPalindrome(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            if (fast != null)
            {
                slow = slow.next;
            }

            slow = Reverse(slow);
            fast = head;

            while (slow != null)
            {
                if (fast.val != slow.val)
                {
                    return false;
                }

                fast = fast.next;
                slow = slow.next;
            }

            return true;
        }

        private ListNode Reverse(ListNode head)
        {
            ListNode prev = null;
            while (head != null)
            {
                ListNode next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }

            return prev;
        }
    }
}
