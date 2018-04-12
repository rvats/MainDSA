using System.Collections.Generic;

namespace MainDSA.DataStructures.Graphs
{
    public class UndirectedGraphNode
    {
        public int label;
        public IList<UndirectedGraphNode> neighbors;
        public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
    }
}
