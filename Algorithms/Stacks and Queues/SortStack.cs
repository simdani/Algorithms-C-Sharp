// question: sort stack so that smallest elements are at the top

using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Stacks_and_Queues
{
    public static class SortStack
    {
        public static void Sort(Stack<int> s)
        {
            Stack<int> r = new Stack<int>();
            while (s.Count != 0)
            {
                // insert each element in s in sorted order into r
                int tmp = s.Pop();
                while (r.Count != 0 && r.Peek() > tmp)
                {
                    s.Push(r.Pop());
                }
                r.Push(tmp);
            }

            // copy the elements from r back into s
            while (r.Count != 0)
            {
                s.Push(r.Pop());
            }
        }
    }
}
