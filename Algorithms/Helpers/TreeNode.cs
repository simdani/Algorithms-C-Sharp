using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Helpers
{
    public class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;
        public TreeNode parent;
        private int size = 0;

        public TreeNode(int data)
        {
            this.data = data;
            size = 1;
        }

        private void SetLeftChild(TreeNode left)
        {
            this.left = left;
            if (left != null)
            {
                left.parent = this;
            }
        }

        private void SetRightChild(TreeNode right)
        {
            this.right = right;
            if (right != null)
            {
                right.parent = this;
            }
        }

        public void InsertInOrder(int d)
        {
            if (d <= data)
            {
                if (left == null)
                {
                    SetLeftChild(new TreeNode(d));
                }
                else
                {
                    left.InsertInOrder(d);
                }
            }
            else
            {
                if (right == null)
                {
                    SetRightChild(new TreeNode(d));
                }
                else
                {
                    right.InsertInOrder(d);
                }
            }

            size++;
        }

        public int Size()
        {
            return size;
        }

        public bool IsBST()
        {
            if (left != null)
            {
                if (data < left.data || !left.IsBST())
                {
                    return false;
                }
            }

            if (right != null)
            {
                if (data >= right.data || !right.IsBST())
                {
                    return false;
                }
            }

            return true;
        }

        public int Height()
        {
            int leftHeight = left != null ? left.Height() : 0;
            int rightHeight = right != null ? right.Height() : 0;
            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public TreeNode Find(int d)
        {
            if (d == data)
            {
                return this;
            } else if (d <= data)
            {
                return left != null ? left.Find(d) : null;
            }
            else if (d > data)
            {
                return right != null ? right.Find(d) : null;
            }

            return null;
        }
    }
}
