using MainDSA.DataStructures.Trees;
using System.Collections;
using System.Text;

namespace MainDSA.Quizes.Design
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

    public class Codec
    {
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var serializedString = new StringBuilder();
            var queue = new Queue();
            queue.Enqueue(root ?? null);

            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var top = (TreeNode)queue.Dequeue();
                    serializedString.Append(top == null ? '#' : (char)(top.Value + '0'));
                    if (top != null)
                    {
                        queue.Enqueue(top.Left);
                        queue.Enqueue(top.Right);
                    }
                }
            }

            return serializedString.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data)) return null;
            if (data[0] == '#') return null;
            var queue = new Queue();
            var root = new TreeNode(data[0] - '0');
            queue.Enqueue(root);
            var index = 1;
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var top = (TreeNode)queue.Dequeue();
                    top.Left = data[index] == '#' ? null : new TreeNode(data[index] - '0');
                    if (top.Left != null) queue.Enqueue(top.Left);
                    index++;
                    top.Right = data[index] == '#' ? null : new TreeNode(data[index] - '0');
                    if (top.Right != null) queue.Enqueue(top.Right);
                    index++;
                }
            }

            return root;
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
}
