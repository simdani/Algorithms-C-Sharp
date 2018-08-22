using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.LinkedLists
{
    public static class Partition
    {
        // solution #1 pass in the head of th elinked list and the value to partition around
        public static LinkedListNode PartitionSolution(LinkedListNode node, int x)
        {
            LinkedListNode beforeStart = null;
            LinkedListNode beforeEnd = null;
            LinkedListNode afterStart = null;
            LinkedListNode afterEnd = null;

            // partition list
            while (node != null)
            {
                LinkedListNode next = node.next;
                node.next = null;
                if (node.data < x)
                {
                    if (beforeStart == null)
                    {
                        // insert node into end of before list
                        beforeStart = node;
                        beforeEnd = beforeStart;
                    }
                    else
                    {
                        beforeEnd.next = node;
                        beforeEnd = node;
                    }
                }
                else
                {
                    // insert node into end of after list
                    if (afterStart == null)
                    {
                        afterStart = node;
                        afterEnd = afterStart;
                    }
                    else
                    {
                        afterEnd.next = node;
                        afterEnd = node;
                    }
                }

                node = next;
            }

            if (beforeStart == null)
            {
                return afterStart;
            }

            // merge before list and after list
            beforeEnd.next = afterStart;
            return beforeStart;
        }

        public static LinkedListNode PartitionOptimized(LinkedListNode node, int x)
        {
            LinkedListNode head = node;
            LinkedListNode tail = node;

            while (node != null)
            {
                LinkedListNode next = node.next;
                if (node.data < x)
                {
                    // insert node at head
                    node.next = head;
                    head = node;
                }
                else
                {
                    // insert node at tail
                    tail.next = node;
                    tail = node;
                }

                node = next;
            }

            tail.next = null;
            // the head has changed so we need to rerturn it to the user
            return head;
        }
    }
}
