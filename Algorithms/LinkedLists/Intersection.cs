// question: given two linked lists determine if the two list intersect.
// return intersecting node

using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.LinkedLists
{
    public static class Intersection
    {
        private class Result
        {
            public LinkedListNode tail;
            public int size;

            public Result(LinkedListNode tail, int size)
            {
                this.tail = tail;
                this.size = size;
            }
        }

        public static LinkedListNode FindIntersection(LinkedListNode list1, LinkedListNode list2)
        {
            if (list1 == null || list2 == null) return null;

            // get tail and sizes
            Result result1 = GetTailAndSize(list1);
            Result result2 = GetTailAndSize(list2);

            // if different tail nodes, then theres no intersection
            if (result1.tail != result2.tail)
            {
                return null;
            }

            // set pointers to the start of each linked lists.
            LinkedListNode shorter = result1.size < result2.size ? list1 : list2;
            LinkedListNode longer = result1.size < result2.size ? list2 : list1;

            // advance the pointer for the longer linked list by difference in length
            longer = GetKthNode(longer, Math.Abs(result1.size - result2.size));

            // move both pointers until you have a collision
            while (shorter != longer)
            {
                shorter = shorter.next;
                longer = longer.next;
            }

            // return either one
            return shorter;
        }

        private static Result GetTailAndSize(LinkedListNode list)
        {
            if (list == null) return null;

            int size = 1;
            LinkedListNode current = list;
            while (current.next != null)
            {
                size++;
                current = current.next;
            }
            return new Result(current, size);
        }

        private static LinkedListNode GetKthNode(LinkedListNode head, int k)
        {
            LinkedListNode current = head;
            while (k > 0 && current != null)
            {
                current = current.next;
                k--;
            }

            return current;
        }
    }
}
