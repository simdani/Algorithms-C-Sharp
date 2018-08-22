using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;
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

        [Fact]
        public void TestSumLists()
        {
            int[] l1 = new int[] {7,1,6};
            int[] l2 = new int[] {5,9,2};
            int[] expected = new int[] {2,1,9};

            LinkedListNode l1List = LinkedListNode.BuildList(l1);
            LinkedListNode l2List = LinkedListNode.BuildList(l2);
            LinkedListNode expectedList = LinkedListNode.BuildList(expected);

            LinkedListNode result = SumLists.AddLists(l1List, l2List, 0);

            while (result != null && expectedList != null)
            {
                Assert.Equal(expectedList.data, result.data);
                result = result.next;
                expectedList = expectedList.next;
            }
        }

        [Fact]
        public void TestSumListsOptimized()
        {
            int[] l1 = new int[] { 6, 1, 7 };
            int[] l2 = new int[] { 2, 9, 5};
            int[] expected = new int[] { 9, 1, 2 };

            LinkedListNode l1List = LinkedListNode.BuildList(l1);
            LinkedListNode l2List = LinkedListNode.BuildList(l2);
            LinkedListNode expectedList = LinkedListNode.BuildList(expected);

            LinkedListNode result = SumLists.AddListsOptimize(l1List, l2List);

            while (result != null && expectedList != null)
            {
                Assert.Equal(expectedList.data, result.data);
                result = result.next;
                expectedList = expectedList.next;
            }
        }
    }
}
