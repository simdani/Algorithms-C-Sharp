using System;

namespace Algorithms.CTCI.Helpers
{
    public class Graph
    {
        public static int MAX_VERTICES = 6;
        private Node[] vertices;
        public int count;

        public Graph()
        {
            vertices = new Node[MAX_VERTICES];
            count = 0;
        }

        public void AddNode(Node v)
        {
            if (count < vertices.Length)
            {
                vertices[count] = v;
                count++;
            }
            else
            {
                throw new Exception("graph is full");
            }
        }

        public Node[] GetNodes()
        {
            return vertices;
        }
    }
}
