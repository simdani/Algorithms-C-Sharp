// question: implement queue using two stacks

using System.Collections.Generic;

namespace Algorithms.CTCI.Stacks_and_Queues
{
    public class QueueViaStacks<T>
    {
        private Stack<T> stackNewest;
        private Stack<T> stackOldest;

        public QueueViaStacks()
        {
            stackNewest = new Stack<T>();
            stackOldest = new Stack<T>();
        }

        public int Size()
        {
            return stackNewest.Count + stackOldest.Count;
        }

        public void Add(T value)
        {
            // push onto stack newest, which always has the newest elements on top
            stackNewest.Push(value);
        }


        // move elements from stacknewest into stackoldest
        private void ShiftStacks()
        {
            if (stackOldest.Count == 0)
            {
                while (stackNewest.Count != 0)
                {
                    stackOldest.Push(stackNewest.Pop());
                }
            }
        }

        public T Peek()
        {
            ShiftStacks(); // ensure stack oldest has the current elements
            return stackOldest.Peek();
        }

        public T Remove()
        {
            ShiftStacks(); // ensure that stackoldest has the current elements
            return stackOldest.Pop();
        }
    }
}
