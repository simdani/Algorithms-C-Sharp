using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.CTCI.Stacks_and_Queues
{
    public class Node
    {
        public Node above;
        public Node below;
        public int value;

        public Node(int value)
        {
            this.value = value;
        }
    }

    public class Stack
    {
        private int capacity;
        public Node top, bottom;
        public int size = 0;

        public Stack(int capacity)
        {
            this.capacity = capacity;
        }

        public bool IsFull()
        {
            return capacity == size;
        }

        public void Join(Node above, Node below)
        {
            if (below != null)
            {
                below.above = above;
            }

            if (above != null)
            {
                above.below = below;
            }
        }

        public bool Push(int v)
        {
            if (size >= capacity) return false;
            size++;
            Node n = new Node(v);
            if (size == 1) bottom = n;
            Join(n, top);
            top = n;
            return true;
        }

        public int Pop()
        {
            Node t = top;
            top = top.below;
            size--;
            return t.value;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int RemoveBottom()
        {
            Node b = bottom;
            bottom = bottom.above;
            if (bottom != null)
            {
                bottom.below = null;
            }

            size--;
            return b.value;
        }
    }

    public class SetOfStacks
    {
        List<Stack> stacks = new List<Stack>();

        public int capacity;

        public SetOfStacks(int capacity)
        {
            this.capacity = capacity;
        }

        public Stack GetLastStack()
        {
            if (stacks.Count == 0) return null;
            return stacks.ElementAt(stacks.Count - 1);
        }

        public void Push(int v)
        {
            Stack last = GetLastStack();
            if (last != null && !last.IsFull())
            {
                last.Push(v);
            }
            else // create new stack
            {
                Stack stack = new Stack(capacity);
                stack.Push(v);
                stacks.Add(stack);
            }
        }

        public int Pop()
        {
            Stack last = GetLastStack();
            if (last == null) throw new Exception();
            int v = last.Pop();
            if (last.size == 0)
            {
                stacks.RemoveAt(stacks.Count - 1);
            }

            return v;
        }

        public bool IsEmpty()
        {
            Stack last = GetLastStack();
            return last == null || last.IsEmpty();
        }

        public int PopAt(int index)
        {
            return LeftShift(index, true);
        }

        public int LeftShift(int index, bool removeTop)
        {
            Stack stack = stacks.ElementAt(index);
            int removed_item;
            if (removeTop)
            {
                removed_item = stack.Pop();
            }
            else
            {
                removed_item = stack.RemoveBottom();
            }

            if (stack.IsEmpty())
            {
                stacks.RemoveAt(index);
            } else if (stacks.Count > index + 1)
            {
                int v = LeftShift(index + 1, false);
                stack.Push(v);
            }

            return removed_item;
        }
    }
}
