using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems1_99;
using Algorithms.Leetcode.Problems200_299;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems1_99
{
    public class RemoveNthFromEndTest
    {
        [Fact]
        public void TestRemoveNthFromEnd()
        { 
            RemoveNthNodeFromList remove = new RemoveNthNodeFromList();

            ListNode firstNode = new ListNode(1);
            ListNode secondNode = new ListNode(2);
            ListNode thirdNode = new ListNode(3);
            ListNode fourthNode = new ListNode(4);
            ListNode fifthNode = new ListNode(5);

            firstNode.next = secondNode;
            firstNode.next.next = thirdNode;
            firstNode.next.next.next = fourthNode;
            firstNode.next.next.next.next = fifthNode;

            remove.RemoveNthFromEnd(firstNode, 2);

            Assert.Equal(1, firstNode.val);
            Assert.Equal(2, firstNode.next.val);
            Assert.Equal(3, firstNode.next.next.val);
            Assert.Equal(5, firstNode.next.next.next.val);
        }
    }
}
