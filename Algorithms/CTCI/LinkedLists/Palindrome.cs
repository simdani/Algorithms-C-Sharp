// question: check if a linked list is a palindrome (same backwards and forward)

using System.Collections.Generic;
using Algorithms.CTCI.Helpers;

namespace Algorithms.CTCI.LinkedLists
{
    public static class Palindrome
    {
        // solution #1 reverse original list and compare them both
        public static bool IsPalindrome(LinkedListNode head)
        {
            LinkedListNode reversed = ReverseAndClone(head);
            return IsEqual(head, reversed);
        }

        private static LinkedListNode ReverseAndClone(LinkedListNode node)
        {
            LinkedListNode head = null;
            while (node != null)
            {
                LinkedListNode n = new LinkedListNode(node.data); // clone
                n.next = head;
                head = n;
                node = node.next;
            }

            return head;
        }

        private static bool IsEqual(LinkedListNode one, LinkedListNode two)
        {
            while (one != null && two != null)
            {
                if (one.data != two.data)
                {
                    return false;
                }

                one = one.next;
                two = two.next;
            }

            return one == null && two == null;
        }

        // solution #2: iterative approach
        public static bool IsPalindromeIterative(LinkedListNode head)
        {
            LinkedListNode fast = head;
            LinkedListNode slow = head;

            Stack<int> stack = new Stack<int>();

            // push elements from first half of linked list onto stack.
            // when fast runner reaches end, then we are in the middle
            while (fast != null && fast.next != null)
            {
                stack.Push(slow.data);
                slow = slow.next;
                fast = fast.next.next;
            }

            // has odd number of elements, so skip the middle one
            if (fast != null)
            {
                slow = slow.next;
            }

            while (slow != null)
            {
                int top = stack.Pop();

                // if values are differen, then it is not a palindrome.
                if (top != slow.data)
                {
                    return false;
                }

                slow = slow.next;
            }

            return true;
        }

        // solution #3: recursive approaach
        private class Result
        {
            public LinkedListNode node;
            public bool result;

            public Result(LinkedListNode node, bool result)
            {
                this.node = node;
                this.result = result;
            }
        }

        public static bool IsPalindromeRecursive(LinkedListNode head)
        {
            int length = LengthOfList(head);
            Result p = IsPalindromeRecurse(head, length);
            return p.result;
        }

        private static Result IsPalindromeRecurse(LinkedListNode head, int length)
        {
            if (head == null || length <= 0) // even number of nodes
            {
                return new Result(head, true);
            }
            else if (length == 1) // odd number of nodes
            {
                return new Result(head.next, true);
            }

            // recurse on sublist
            Result res = IsPalindromeRecurse(head.next, length - 2);

            // if child calls are not a palindrome pass back up a failure
            if (!res.result || res.node == null)
            {
                return res;
            }

            // check if matches corresponding node on other side.
            res.result = (head.data == res.node.data);

            // return corresponding node
            res.node = res.node.next;

            return res;
        }

        private static int LengthOfList(LinkedListNode n)
        {
            int size = 0;
            while (n != null)
            {
                size++;
                n = n.next;
            }

            return size;
        }
    }
}
