﻿using MainDSA.DataStructures.Trees;
using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public class TreeOperations
    {
        public void Flatten(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode pointer = root;

            while (pointer != null || stack.Count != 0)
            {

                if (pointer.Right != null)
                {
                    stack.Push(pointer.Right);
                }

                if (pointer.Left != null)
                {
                    pointer.Right = pointer.Left;
                    pointer.Left = null;
                }
                else if (stack.Count != 0)
                {
                    TreeNode temp = stack.Pop();
                    pointer.Right = temp;
                }

                pointer = pointer.Right;
            }
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            else if (p == null || q == null)
            {
                return false;
            }

            if (p.Value == q.Value)
            {
                return IsSameTree(p.Left, q.Left) && IsSameTree(p.Right, q.Right);
            }
            else
            {
                return false;
            }
        }

        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, double.MinValue, double.MaxValue);
        }

        public bool IsValidBST(TreeNode p, double min, double max)
        {
            if (p == null)
                return true;

            if (p.Value <= min || p.Value >= max)
                return false;

            return IsValidBST(p.Left, min, p.Value) && IsValidBST(p.Right, p.Value, max);
        }
    }
}
