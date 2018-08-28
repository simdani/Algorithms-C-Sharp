// question: given a direct graph, design an algorithm to find out whether there is 
// a route between two nodes

using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.Trees_and_Graphs
{
    public static class RouteBetweenNodes
    {
        public enum State
        {
            Unvisited, 
            Visited,
            Visiting
        }

        // solution (using BFS - bread first search)
        public static bool Search(Graph g, Node start, Node end)
        {
            if (start == end) return true;

            // operates as queue
            LinkedList<Node> q = new LinkedList<Node>();

            foreach (var u in g.GetNodes())
            {
                u.state = State.Unvisited;
            }

            start.state = State.Visiting;
            q.AddLast(start);
            Node x;
            while (q.Count != 0)
            {             
                x = q.First.Value;
                q.RemoveFirst();

                if (x != null)
                {
                    foreach (Node v in x.GetAdjacent())
                    {
                        if (v.state == State.Unvisited)
                        {
                            if (v == end)
                            {
                                return true;
                            }
                            else
                            {
                                v.state = State.Visiting;
                                q.AddLast(v);
                            }
                        }
                    }

                    x.state = State.Visited;
                }
            }

            return false;
        }
    }
}
