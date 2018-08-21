using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.LinkedLists.LinkedListNode
{
    public class LinkedListNode
    {
        public LinkedListNode next, prev, last;
        public int data;

        public LinkedListNode(int d, LinkedListNode n, LinkedListNode p)
        {
            data = d;
            SetNext(n);
            SetPrevious(p);
        }

        public LinkedListNode(int d)
        {
            data = d;
        }

        public LinkedListNode() { }

        public void SetNext(LinkedListNode n)
        {
            next = n;
            if (this == last)
            {
                last = n;
            }

            if (n != null && n.prev != this)
            {
                n.SetPrevious(this);
            }
        }

        public void SetPrevious(LinkedListNode p)
        {
            prev = p;
            if (p != null && p.next != this)
            {
                p.SetNext(this);
            }
        }

        public LinkedListNode Clone()
        {
            LinkedListNode next2 = null;
            if (next != null)
            {
                next2 = next.Clone();
            }

            LinkedListNode head2 = new LinkedListNode(data, next2, null);
            return head2;
        }
    }
}
