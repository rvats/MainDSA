using System.Collections.Generic;

namespace MainDSA.DataStructures.Trees
{
    public class NaryTreeNode
    {
        public int val;
        public IList<NaryTreeNode> children;

        public NaryTreeNode() { }
        public NaryTreeNode(int _val, IList<NaryTreeNode> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
