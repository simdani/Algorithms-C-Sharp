namespace Algorithms.CTCI.Helpers
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

        public static LinkedListNode BuildList(int[] data)
        {
            if (data == null || data.Length == 0) return null;
            LinkedListNode n = new LinkedListNode(data[0]);
            LinkedListNode head = n;
            for (int i = 1; i < data.Length; i++)
            {
                n.next = new LinkedListNode(data[i]);
                n = n.next;
            }

            return head;
        }

        public static int Length(LinkedListNode head)
        {
            int len = 0;
            while (head != null)
            {
                len++;
                head = head.next;
            }

            return len;
        }

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
