using MainDSA.DataStructures.Lists;
using MainDSA.DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Text;

namespace MainDSA.Quizes
{
    public class TreeOperations
    {
        private int maxDiameter = 0;

        public TreeNode BinarySearchTreeTreeToDoublyCircularList(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            //Init stack
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;
            stack.Push(node);
            //Create DoublyListNode header
            TreeNode temporaryHead = new TreeNode(0);
            TreeNode pointer = temporaryHead;
            TreeNode current = null;

            while (stack.Count!=0)
            {
                while (node != null && node.Left != null)
                {
                    stack.Push(node.Left);
                    node = node.Left;
                }
                //add node
                node = stack.Pop();
                current = new TreeNode(node.Value);
                pointer.Right = current;
                current.Left = pointer;
                pointer = pointer.Right;

                //check right node and add to stack
                node = node.Right;
                if (node != null)
                {
                    stack.Push(node);
                }
            }

            //Following Two Steps should be omitted when not making the list Circular and then the temporaryHead Node can be removed
            temporaryHead.Right.Left = current;
            current.Right = temporaryHead.Right;

            return temporaryHead.Right;
        }

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

        public int GetDiameterOfBinaryTree(TreeNode root)
        {
            MaxDepth(root);
            return maxDiameter;
        }

        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            int left = MaxDepth(root.Left);
            int right = MaxDepth(root.Right);
            maxDiameter = Math.Max(maxDiameter, left + right);
            return 1 + Math.Max(left, right);
        }

        public List<List<int>> VerticalOrder(TreeNode root)
        {
            List<List<int>> result = new List<List<int>>();
            if (root == null)
                return result;

            // level and list    
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();

            List<TreeNode> queue = new List<TreeNode>();
            List<int> level = new List<int>();

            queue.Add(root);
            level.Add(0);

            int minLevel = 0;
            int maxLevel = 0;

            while (queue.Count != 0)
            {
                TreeNode p = queue[0];
                queue.RemoveAt(0);
                int levelValue = level[0];
                level.RemoveAt(0);

                //track min and max levels
                minLevel = Math.Min(minLevel, levelValue);
                maxLevel = Math.Max(maxLevel, levelValue);

                if (map.ContainsKey(levelValue))
                {
                    map[levelValue].Add(p.Value);
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(p.Value);
                    map.Add(levelValue, list);
                }

                if (p.Left != null)
                {
                    queue.Add(p.Left);
                    level.Add(levelValue - 1);
                }

                if (p.Right != null)
                {
                    queue.Add(p.Right);
                    level.Add(levelValue + 1);
                }
            }


            for (int i = minLevel; i <= maxLevel; i++)
            {
                if (map.ContainsKey(i))
                {
                    result.Add(map[i]);
                }
            }

            return result;
        }

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            int preStart = 0;
            int preEnd = preorder.Length - 1;
            int inStart = 0;
            int inEnd = inorder.Length - 1;

            return Construct(preorder, preStart, preEnd, inorder, inStart, inEnd);
        }

        public TreeNode Construct(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd || inStart > inEnd)
            {
                return null;
            }

            int value = preorder[preStart];
            TreeNode pointer = new TreeNode(value);

            //find parent element index from inorder
            int k = 0;
            for (int i = 0; i < inorder.Length; i++)
            {
                if (value == inorder[i])
                {
                    k = i;
                    break;
                }
            }

            pointer.Left = Construct(preorder, preStart + 1, preStart + (k - inStart), inorder, inStart, k - 1);
            pointer.Right = Construct(preorder, preStart + (k - inStart) + 1, preEnd, inorder, k + 1, inEnd);

            return pointer;
        }
    }
}
