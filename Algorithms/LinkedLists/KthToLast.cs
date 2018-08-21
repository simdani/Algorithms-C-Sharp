// question: implement an algorithm to find the kth to last element of singly linked list

using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LinkedLists
{
    public static class KthToLast
    {
        // solution #1 recursive
        public static int PrintKthToLastRecursive(LinkedListNode.LinkedListNode head, int k)
        {
            if (head == null)
            {
                return 0;
            }

            int index = PrintKthToLastRecursive(head.next, k + 1);
            if (index == k)
            {
                Console.WriteLine(k + "th to last node is " + head.data);
            }

            return index;
        }

        // solution #2 iterative
        public static LinkedListNode.LinkedListNode NthToLastIterative(LinkedListNode.LinkedListNode head, int k)
        {
            LinkedListNode.LinkedListNode p1 = head;
            LinkedListNode.LinkedListNode p2 = head;

            // move p1 k nodes into the list
            for (int i = 0; i < k; i++)
            {
                if (p1 == null) return null; // out of bounds
                p1 = p1.next;
            }

            // move the at the same pace. when p1 hits the end, p2 will be at the right element
            while (p1 != null)
            {
                p1 = p1.next;
                p2 = p2.next;
            }

            return p2;
        }
    }
}
