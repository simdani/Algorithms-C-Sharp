// question: write code to removve duplicated from an usroted linked list
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LinkedLists
{
    public static class RemoveDups
    {
        // solution #1
        public static void DeleteDups(LinkedListNode.LinkedListNode n)
        {
            HashSet<int> set = new HashSet<int>();
            LinkedListNode.LinkedListNode previous = null;
            while (n != null)
            {
                if (set.Contains(n.data))
                {
                    previous.next = n.next;
                }
                else
                {
                    set.Add(n.data);
                    previous = n;
                }

                n = n.next;
            }
        }

        // solution #2 no buffer allowed
        public static void DeleteDupsNoBuffer(LinkedListNode.LinkedListNode head)
        {
            LinkedListNode.LinkedListNode current = head;
            while (current != null)
            {
                // remove all future nodes that have the same value
                LinkedListNode.LinkedListNode runner = current;
                while (runner.next != null)
                {
                    if (runner.next.data == current.data)
                    {
                        runner.next = runner.next.next;
                    }
                    else
                    {
                        runner = runner.next;
                    }
                }

                current = current.next;
            }
        }
    }
}
