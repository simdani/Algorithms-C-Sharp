using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Leetcode.Problems200_299;
using Xunit;

namespace UnitTests.LeetcodeTests.Problems200_299
{
    public class ReverseLinkedListTest
    {
        [Fact]
        public void TestReverseLinkedList()
        {
            ListNode first = new ListNode(1);
            ListNode second = new ListNode(2);
            ListNode third = new ListNode(3);

            first.next = second;
            first.next.next = third;

            ReverseLinkedListProblem reverse = new ReverseLinkedListProblem();
            reverse.ReverseList(first);
        }
    }
}
