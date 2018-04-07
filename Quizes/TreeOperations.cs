using MainDSA.DataStructures.Trees;
using System.Collections.Generic;
using System.Text;

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

        public bool IsValidBinarySearchTree(TreeNode root)
        {
            return IsValidBinarySearchTree(root, double.MinValue, double.MaxValue);
        }

        public bool IsValidBinarySearchTree(TreeNode p, double min, double max)
        {
            if (p == null)
                return true;

            if (p.Value <= min || p.Value >= max)
                return false;

            return IsValidBinarySearchTree(p.Left, min, p.Value) && IsValidBinarySearchTree(p.Right, p.Value, max);
        }

        public List<string> BinaryTreePaths(TreeNode root)
        {
            List<string> finalResult = new List<string>();

            if (root == null)
                return finalResult;

            List<string> current = new List<string>();
            List<List<string>> results = new List<List<string>>();

            DepthFirstTraversal(root, results, current);

            foreach(var result in results)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(result[0]);
                for (int i = 1; i < result.Count; i++)
                {
                    stringBuilder.Append("->" + result[i]);
                }

                finalResult.Add(stringBuilder.ToString());
            }

            return finalResult;
        }

        public void DepthFirstTraversal(TreeNode root, List<List<string>> listOfNodes, List<string> currentNode)
        {
            currentNode.Add(root.Value.ToString());

            if (root.Left == null && root.Right == null)
            {
                listOfNodes.Add(currentNode);
                return;
            }

            if (root.Left != null)
            {
                List<string> temp = new List<string>(currentNode);
                DepthFirstTraversal(root.Left, listOfNodes, temp);
            }

            if (root.Right != null)
            {
                List<string> temp = new List<string>(currentNode);
                DepthFirstTraversal(root.Right, listOfNodes, temp);
            }
        }
    }
}
