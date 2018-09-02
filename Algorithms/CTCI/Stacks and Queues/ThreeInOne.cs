// question: describe how you could use a single array to implement three stacks

using System;

namespace Algorithms.CTCI.Stacks_and_Queues
{
    public class ThreeInOne
    {
        // solution #1 fixed division
        private class FixedMultiStack
        {
            private int numberOfStacks = 3;
            private int stackCapacity;
            private int[] values;
            private int[] sizes;

            public FixedMultiStack(int stackSize)
            {
                stackCapacity = stackSize;
                values = new int[stackSize * numberOfStacks];
                sizes = new int[numberOfStacks];
            }

            // push values onto stack
            public void Push(int stackNum, int value)
            {
                if (IsFull(stackNum))
                {
                    throw new SystemException("Stack is full");
                }

                // increment stack pointer and then update top value
                sizes[stackNum]++;
                values[IndexOfTop(stackNum)] = value;
            }

            // pop item from stack
            public int pop(int stackNum)
            {
                if (IsEmpty(stackNum))
                {
                    throw SystemException("stack is empty");
                }

                int topIndex = IndexOfTop(stackNum);
                int value = values[topIndex];
                values[topIndex] = 0; // clear
                sizes[stackNum]--; //shrink
                return value;
            }

            // return top element
            public int Peek(int stackNum)
            {
                if (IsEmpty(stackNum))
                {
                    throw SystemException("stack is empty");
                }

                return values[IndexOfTop(stackNum)];
            }

            private Exception SystemException(string v)
            {
                throw new Exception(v);
            }

            // return if stack is empty
            public bool IsEmpty(int stackNum)
            {
                return sizes[stackNum] == 0;
            }

            // return if stack is full
            public bool IsFull(int stackNum)
            {
                return sizes[stackNum] == stackCapacity;
            }

            // returns index of the top of the stack
            private int IndexOfTop(int stackNum)
            {
                int offset = stackNum * stackCapacity;
                int size = sizes[stackNum];
                return offset + size - 1;
            }
        }
    }
}
