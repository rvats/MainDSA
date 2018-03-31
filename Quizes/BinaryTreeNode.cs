using System;

namespace MainDSA.Quizes
{
    public class BinaryTreeNode
    {
        public int Value { get; }

        public BinaryTreeNode Left { get; private set; }

        public BinaryTreeNode Right { get; private set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }

        public BinaryTreeNode InsertLeft(int leftValue)
        {
            Left = new BinaryTreeNode(leftValue);
            return Left;
        }

        public BinaryTreeNode InsertRight(int rightValue)
        {
            Right = new BinaryTreeNode(rightValue);
            return Right;
        }

        public int FindLargest(BinaryTreeNode rootNode)
        {
            var current = rootNode;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Value;
        }

        public int FindSecondLargest(BinaryTreeNode rootNode)
        {
            if (rootNode == null
                || (rootNode.Left == null && rootNode.Right == null))
            {
                throw new ArgumentException("Tree must have at least 2 nodes",
                    nameof(rootNode));
            }

            var current = rootNode;

            while (true)
            {
                // Case: current is largest and has a left subtree
                // 2nd largest is the largest in that subtree
                if (current.Left != null && current.Right == null)
                {
                    return FindLargest(current.Left);
                }

                // Case: current is parent of largest, and largest has no children,
                // so current is 2nd largest
                if (current.Right != null
                    && current.Right.Left == null
                    && current.Right.Right == null)
                {
                    return current.Value;
                }

                current = current.Right;
            }
        }

        public int FindSmallest(BinaryTreeNode rootNode)
        {
            var current = rootNode;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Value;
        }

        public int FindSecondSmallest(BinaryTreeNode rootNode)
        {
            if (rootNode == null
                || (rootNode.Left == null && rootNode.Right == null))
            {
                throw new ArgumentException("Tree must have at least 2 nodes",
                    nameof(rootNode));
            }

            var current = rootNode;

            while (true)
            {
                // Case: current is largest and has a left subtree
                // 2nd largest is the largest in that subtree
                if (current.Right != null && current.Left == null)
                {
                    return FindSmallest(current.Right);
                }

                // Case: current is parent of largest, and largest has no children,
                // so current is 2nd largest
                if (current.Left != null
                    && current.Left.Left == null
                    && current.Left.Right == null)
                {
                    return current.Value;
                }

                current = current.Left;
            }
        }
    }
}
