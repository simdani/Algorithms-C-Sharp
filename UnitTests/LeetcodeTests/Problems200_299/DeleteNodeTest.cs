using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems200_299;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems200_299
{
    public class DeleteNodeTest
    {
        [Fact]
        public void TestDeleteNode()
        {
            ListNode four = new ListNode(4);
            ListNode five = new ListNode(5);
            ListNode one = new ListNode(1);
            ListNode nine = new ListNode(9);

            four.next = five;
            five.next = one;
            one.next = nine;
            
            DeleteNodeProblem deleteNode = new DeleteNodeProblem();
            deleteNode.DeleteNode(five);

            Assert.Equal(4, four.val);
            Assert.Equal(1, four.next.val);
            Assert.Equal(9, four.next.next.val);
        }
    }
}
