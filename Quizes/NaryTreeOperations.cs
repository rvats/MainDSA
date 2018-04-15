using MainDSA.DataStructures.Trees;
using System.Collections.Generic;
using System.Linq;

namespace MainDSA.Quizes
{
    public class NaryTreeOperations
    {
        List<int> preOrderTraversalList = new List<int>();
        List<int> postOrderTraversalList = new List<int>();
        IList<IList<int>> levelOrderTraversalListOfLevelLists = new List<IList<int>>();
        List<int> levelOrderTraversalList = new List<int>();

        public IList<int> PreOrder(NaryTreeNode root)
        {
            //NaryTreeNode pointer = root;
            if (root == null)
                return preOrderTraversalList;
            preOrderTraversalList.Add(root.val);
            if(root.children != null)
            {
                foreach (var child in root.children)
                {
                    PreOrder(child);
                }
            }
            return preOrderTraversalList;
        }

        public IList<int> PostOrder(NaryTreeNode root)
        {
            //NaryTreeNode pointer = root;
            if (root == null)
                return postOrderTraversalList;
            postOrderTraversalList.Add(root.val);
            if (root.children != null)
            {
                foreach (var child in root.children)
                {
                    PostOrder(child);
                }
            }
            return postOrderTraversalList;
        }

        public IList<IList<int>> LevelOrder(NaryTreeNode root)
        {
            LevelOrderHelper(root, 0);
            return levelOrderTraversalListOfLevelLists;
        }

        private void LevelOrderHelper(NaryTreeNode root, int height)
        {
            if (root == null) return;
            if (height == levelOrderTraversalListOfLevelLists.Count)
            {
                levelOrderTraversalListOfLevelLists.Add(new List<int>());
            }

            levelOrderTraversalListOfLevelLists[height].Add(root.val);
            foreach (var child in root.children)
            {
                LevelOrderHelper(child, height + 1);
            }
        }
    }
}
