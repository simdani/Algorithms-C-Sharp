// question add to lists with their numbers

using Algorithms.CTCI.Helpers;

namespace Algorithms.CTCI.LinkedLists
{
    public static class SumLists
    {
        // solution #1
        public static LinkedListNode AddLists(LinkedListNode l1, LinkedListNode l2,
            int carry)
        {
            if (l1 == null && l2 == null && carry == 0)
            {
                return null;
            }

            LinkedListNode result = new LinkedListNode();
            int value = carry;
            if (l1 != null)
            {
                value += l1.data;
            }

            if (l2 != null)
            {
                value += l2.data;
            }

            result.data = value % 10; // second digit of number

            // recurse
            if (l1 != null || l2 != null)
            {
                LinkedListNode more = AddLists(l1 == null ? null : l1.next,
                    l2 == null ? null : l2.next,
                    value >= 10 ? 1 : 0);
                result.SetNext(more);
            }

            return result;
        }

        // solution #2 (allow to add shorter lists)
        private class PartialSum
        {
            public LinkedListNode sum = null;
            public int carry = 0;
        }

        public static LinkedListNode AddListsOptimize(LinkedListNode l1,
            LinkedListNode l2)
        {
            int len1 = LinkedListNode.Length(l1);
            int len2 = LinkedListNode.Length(l2);

            // pad the shorter list with zeros 
            if (len1 < len2)
            {
                l1 = PadList(l1, len2 - len1);
            }
            else
            {
                l2 = PadList(l2, len1 - len2);
            }
            // add lists
            PartialSum sum = AddListsHelper(l1, l2);

            // if there was a carry value left over, insert this at the front of the list
            if (sum.carry == 0)
            {
                return sum.sum;
            }
            else
            {
                LinkedListNode result = InsertBefore(sum.sum, sum.carry);
                return result;
            }
        }

        private static PartialSum AddListsHelper(LinkedListNode l1, LinkedListNode l2)
        {
            PartialSum sum;
            if (l1 == null && l2 == null)
            {
                sum = new PartialSum();
                return sum;
            }

            // add smaller digits recursive;
            sum = AddListsHelper(l1.next, l2.next);

            // add carry to current data
            int val = sum.carry + l1.data + l2.data;

            // insert sum of current digits
            LinkedListNode full_result = InsertBefore(sum.sum, val % 10);

            // return sum so far, and thhe carry value
            sum.sum = full_result;
            sum.carry = val / 10;
            return sum;
        }

        // pad the list with zeros
        private static LinkedListNode PadList(LinkedListNode l, int padding)
        {
            LinkedListNode head = l;
            for (int i = 0; i < padding; i++)
            {
                head = InsertBefore(head, 0);
            }

            return head;
        }

        // helper function to insert node in the front of a linked list
        private static LinkedListNode InsertBefore(LinkedListNode list, int data)
        {
            LinkedListNode node = new LinkedListNode(data);
            if (list != null)
            {
                node.next = list;
            }

            return node;
        }
    }
}
