// question: detect if a linked list has a loop

using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.LinkedLists
{
    public static class LoopDetection
    {
        public static LinkedListNode FindBegging(LinkedListNode head)
        {
            LinkedListNode slow = head;
            LinkedListNode fast = head;

            // find meeting point, this will be loop_size - k steps into the linked list
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    // collsion
                    break;
                }
            }

            // error check, if there is no meeting point and therefore there is no loop
            if (fast == null || fast.next == null)
            {
                return null;
            }

            // move slow to head, if they move at the same pace, they must meet at loop start
            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }

            // both now point at the start of the loop
            return slow;
        }
    }
}
