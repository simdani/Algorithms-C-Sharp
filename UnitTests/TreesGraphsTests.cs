﻿using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;
using Algorithms.Trees_and_Graphs;
using Xunit;

namespace UnitTests
{
    public class TreesGraphsTests
    {
        [Fact]
        public void TestRouteBetweenNodes()
        {
            Graph g = CreateNewGraph();
            Node[] n = g.GetNodes();
            Node start = n[3];
            Node end = n[5];
            Assert.True(RouteBetweenNodes.Search(g, start, end));
        }

        private static Graph CreateNewGraph()
        {
            Graph g = new Graph();
            Node[] temp = new Node[6];

            temp[0] = new Node("a", 3);
            temp[1] = new Node("b", 0);
            temp[2] = new Node("c", 0);
            temp[3] = new Node("d", 1);
            temp[4] = new Node("e", 1);
            temp[5] = new Node("f", 0);

            temp[0].AddAdjacent(temp[1]);
            temp[0].AddAdjacent(temp[2]);
            temp[0].AddAdjacent(temp[3]);
            temp[3].AddAdjacent(temp[4]);
            temp[4].AddAdjacent(temp[5]);
            for (int i = 0; i < 6; i++)
            {
                g.AddNode(temp[i]);
            }
            return g;
        }
    }
}
