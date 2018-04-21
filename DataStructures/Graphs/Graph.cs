using System;
using System.Collections.Generic;

namespace MainDSA.DataStructures.Graphs
{
    /// <summary>
    /// My Generic Graph Data Structure for Further Work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Graph<T>
    {
        /// <summary>
        /// CTCI: Chapter 4: Trees and Graphs
        /// </summary>
        enum State { Unvisited, Visited, Visiting }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Graph() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="edges"></param>
        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T>> edges)
        {
            foreach (var vertex in vertices)
                AddVertex(vertex);

            foreach (var edge in edges)
                AddEdge(edge);
        }

        /// <summary>
        /// Keeping Track Of Edges
        /// </summary>
        public Dictionary<T, HashSet<T>> AdjacencyList { get; } = new Dictionary<T, HashSet<T>>();

        public void AddVertex(T vertex)
        {
            AdjacencyList[vertex] = new HashSet<T>();
        }

        /// <summary>
        /// Create An Edge
        /// </summary>
        /// <param name="edge"></param>
        public void AddEdge(Tuple<T, T> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        /// <summary>
        /// Depth First Traversal
        /// To Do: Modify The Code below to check for all nodes in the graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public HashSet<T> DepthFirstSearch(T start)
        {
            var visited = new HashSet<T>();

            if (!AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        stack.Push(neighbor);
            }

            return visited;
        }

        /// <summary>
        /// Breadth First Search
        /// To Do: Modify The Code below to check for all nodes in the graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public HashSet<T> BreadthFirstSearch(T start)
        {
            var visited = new HashSet<T>();

            if (!AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
                    
            }

            return visited;
        }

        /// <summary>
        /// Generate Neighbouring Path Strings
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public HashSet<T> GenerateNeighbouringPathStrings(T start)
        {
            var visited = new HashSet<T>();

            if (!AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);

                foreach (var neighbor in AdjacencyList[vertex])
                    if (!visited.Contains(neighbor))
                        queue.Enqueue(neighbor);
            }

            return visited;
        }

        /// <summary>
        /// Cracking The Coding Interview: 4.1 Route Between Nodes
        /// Approach: Do either DFS or BFS
        /// The code below implements an iterative approach using Breadth First Search
        /// </summary>
        /// <param name="startStation"></param>
        /// <param name="endStation"></param>
        /// <returns type="bool">Whether a path exist in given map from start to end</returns>
        public bool Search(T startStation, T endStation)
        {
            // If starting Node is the same as the ending Node
            if (startStation.Equals(endStation)) { return true; }
            // Operate As Queue using Breadth First Philosophy
            Queue<T> queue = new Queue<T>();
            var visited = new HashSet<T>();
            queue.Enqueue(startStation);
            while (queue.Count > 0)
            {
                var station = queue.Dequeue();
                visited.Add(station);
                foreach (var connectingStation in AdjacencyList[station])
                {
                    if (connectingStation.Equals(endStation)) { return true; }
                    if (!visited.Contains(connectingStation)) { queue.Enqueue(connectingStation); }
                }
            }
            return false;
        }
    }
}
