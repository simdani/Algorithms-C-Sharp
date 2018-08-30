// question: given a binary tree, design an algorithm which creates a linked list of the nodes
// of each depth (if you have a tree with depth D, you'll  have D linked lists)

using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Helpers;

namespace Algorithms.Trees_and_Graphs
{
    public static class ListOfDepths
    {
        // solution #1
        public static void CreateLevellinkedList(TreeNode root, List<LinkedList<TreeNode>> lists,
            int level)
        {
            if (root == null) return; // base case

            LinkedList<TreeNode> list = null;
            if (list.Count == level)
            {
                list = new LinkedList<TreeNode>();
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }

            list.AddLast(root);
            CreateLevellinkedList(root.left, lists, level + 1);
            CreateLevellinkedList(root.right, lists, level + 1);
        }

        public static List<LinkedList<TreeNode>> CreateLevelLinkedList(TreeNode root)
        {
            List<LinkedList<TreeNode>> lists = new List<LinkedList<TreeNode>>();
            CreateLevellinkedList(root, lists, 0);
            return lists;
        }

        // solution #2: BFS modification
        public static List<LinkedList<TreeNode>> CreateLevelLinkedListBFS(TreeNode root)
        {
            List<LinkedList<TreeNode>> result = new List<LinkedList<TreeNode>>();
            // visit the root
            LinkedList<TreeNode> current = new LinkedList<TreeNode>();
            if (root != null)
            {
                current.AddLast(root);
            }

            while (current.Count > 0)
            {
                result.Add(current); // add previous level
                LinkedList<TreeNode> parents = current; // go to next level
                current = new LinkedList<TreeNode>();
                foreach (TreeNode parent in parents)
                {
                    // visit children
                    if (parent.left != null)
                    {
                        current.AddLast(parent.left);
                    }

                    if (parent.right != null)
                    {
                        current.AddLast(parent.right);
                    }
                }
            }

            return result;
        }
    }
}
