using MainDSA.DataStructures.Graphs;
using System.Collections.Generic;

namespace MainDSA.Quizes
{
    public class GraphOperations
    {
        public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
        {
            if (node == null)
                return null;

            Queue<UndirectedGraphNode> queue = new Queue<UndirectedGraphNode>();
            Dictionary<UndirectedGraphNode, UndirectedGraphNode> map =
                                       new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();

            UndirectedGraphNode newHead = new UndirectedGraphNode(node.label);

            queue.Enqueue(node);
            map.Add(node, newHead);

            while (queue.Count!=0)
            {
                UndirectedGraphNode current = queue.Dequeue();
                List<UndirectedGraphNode> currentNeighbors = (List<UndirectedGraphNode>)current.neighbors;

                foreach (UndirectedGraphNode aNeighbor in currentNeighbors)
                {
                    if (!map.ContainsKey(aNeighbor))
                    {
                        UndirectedGraphNode copy = new UndirectedGraphNode(aNeighbor.label);
                        map.Add(aNeighbor, copy);
                        map[current].neighbors.Add(copy);
                        queue.Enqueue(aNeighbor);
                    }
                    else
                    {
                        map[current].neighbors.Add(map[aNeighbor]);
                    }
                }

            }
            return newHead;
        }
    }
}
