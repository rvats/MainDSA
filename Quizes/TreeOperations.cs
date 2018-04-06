using MainDSA.DataStructures.Trees;
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
    }
}
