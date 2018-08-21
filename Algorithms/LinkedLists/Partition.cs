using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LinkedLists
{
    public static class Partition
    {
        // solution #1 pass in the head of th elinked list and the value to partition around
        public static LinkedListNode.LinkedListNode PartitionSolution(LinkedListNode.LinkedListNode node, int x)
        {
            LinkedListNode.LinkedListNode beforeStart = null;
            LinkedListNode.LinkedListNode beforeEnd = null;
            LinkedListNode.LinkedListNode afterStart = null;
            LinkedListNode.LinkedListNode afterEnd = null;

            // partition list
            while (node != null)
            {
                LinkedListNode.LinkedListNode next = node.next;
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

        public static LinkedListNode.LinkedListNode PartitionOptimized(LinkedListNode.LinkedListNode node, int x)
        {
            LinkedListNode.LinkedListNode head = node;
            LinkedListNode.LinkedListNode tail = node;

            while (node != null)
            {
                LinkedListNode.LinkedListNode next = node.next;
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
