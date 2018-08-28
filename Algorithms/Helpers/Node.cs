using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Stacks_and_Queues;
using Algorithms.Trees_and_Graphs;

namespace Algorithms.Helpers
{
    public class Node
    {
        private Node[] adjacent;
        public int adjacentCount;
        private string vertex;
        public RouteBetweenNodes.State state;

        public Node(string vertex, int adjacentLength)
        {
            this.vertex = vertex;
            adjacentCount = 0;
            adjacent = new Node[adjacentLength];
        }

        public void AddAdjacent(Node v)
        {
            if (adjacentCount < adjacent.Length)
            {
                this.adjacent[adjacentCount] = v;
                adjacentCount++;
            }
            else
            {
                throw new Exception("No more adjacent can be added");
            }
        }

        public Node[] GetAdjacent()
        {
            return adjacent;
        }

        public string GetVertex()
        {
            return vertex;
        }
    }
}
