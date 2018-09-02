// question implment an algorithm to deleate a node in the middle

using Algorithms.CTCI.Helpers;

namespace Algorithms.CTCI.LinkedLists
{
    public static class DeleteMiddlenode
    {
        // solution #1 we are given that middle element
        public static bool DeleteNode(LinkedListNode n)
        {
            if (n == null || n.next == null)
            {
                return false;
            }

            LinkedListNode next = n.next;
            n.data = next.data;
            n.next = next.next;
            return true;
        }
    }
}
