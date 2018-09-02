using Algorithms.CTCI.Helpers;
using Algorithms.CTCI.LinkedLists;
using Xunit;

namespace UnitTests.CTCITests
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
        public void TestDeleteMiddleNode()
        {
            int[] l1 = new int[] {1, 2, 3, 4, 5};

            LinkedListNode result = LinkedListNode.BuildList(l1);

            Assert.True(DeleteMiddlenode.DeleteNode(result));
        }

        [Fact]
        public void TestKthToLast()
        {
            int[] l1 = new int[] { 1, 2, 3, 4, 5 };
            int[] expected = new int[] { 3, 4, 5};

            LinkedListNode l1List = LinkedListNode.BuildList(l1);
            LinkedListNode expectedList = LinkedListNode.BuildList(expected);

            LinkedListNode result = KthToLast.NthToLastIterative(l1List, 3);

            while (result != null || expectedList != null)
            {
                Assert.Equal(expectedList.data, result.data);
                result = result.next;
                expectedList = expectedList.next;
            }
        }

        [Fact]
        public void TestPartition()
        {
            int[] l1 = new int[] { 1, 1, 1, 5, 1, 1, 1 };
            int[] expected = new int[] { 1, 1, 1, 1, 1, 1, 5};

            LinkedListNode l1List = LinkedListNode.BuildList(l1);
            LinkedListNode expectedList = LinkedListNode.BuildList(expected);

            LinkedListNode result = Partition.PartitionSolution(l1List, 5);

            while (result != null && expectedList != null)
            {
                Assert.Equal(expectedList.data, result.data);
                result = result.next;
                expectedList = expectedList.next;
            }
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

        [Fact]
        public void TestPalindrome()
        {
            int[] l1 = new int[] { 0, 1, 2, 1, 0 };
            int[] l2 = new int[] { 0, 1, 2, 0};

            // solution #1 traverse and clone
            LinkedListNode l1List = LinkedListNode.BuildList(l1);
            Assert.True(Palindrome.IsPalindrome(l1List));

            LinkedListNode l2List = LinkedListNode.BuildList(l2);
            Assert.False(Palindrome.IsPalindrome(l2List));

            // solution #2 iterative
            Assert.True(Palindrome.IsPalindromeIterative(l1List));

            // solution #3 recursive
            Assert.True(Palindrome.IsPalindromeRecursive(l1List));
        }
    }
}
