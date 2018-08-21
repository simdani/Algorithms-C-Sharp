using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.LinkedLists.LinkedListNode;
using Algorithms.LinkedLists;
using Xunit;

namespace UnitTests
{
    public class LinkedListsTests
    {
        [Fact]
        public void TestRemoveDups()
        {
            LinkedListNode node = new LinkedListNode(2);
            node.SetNext(new LinkedListNode(3));
            node.next.SetNext(new LinkedListNode(4));
            node.next.next.SetNext(new LinkedListNode(5));
            node.next.next.next.SetNext(new LinkedListNode(3));

            int shouldBeSum = 14;

            int sum = 0;

            RemoveDups.DeleteDups(node);

            while (node != null)
            {
                sum += node.data;
                node = node.next;
            }

            Assert.Equal(shouldBeSum, sum);
        }
    }
}
