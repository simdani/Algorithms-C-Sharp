using Algorithms.CTCI.Stacks_and_Queues;
using Xunit;

namespace UnitTests.CTCITests
{
    public class StackQueuesTests
    {
        [Fact]
        public void TestStackMin()
        {
            StackMin minStack = new StackMin();
            minStack.Push(2);
            minStack.Push(6);
            minStack.Push(7);
            minStack.Push(3);

            Assert.Equal(2, minStack.Min());
        }
    }
}
