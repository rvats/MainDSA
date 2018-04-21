using MainDSA.DataStructures.Graphs;
using System;

namespace GraphDemo
{
    internal class Program
    {
        // 1, 2, 3
        // 4, 5, 6
        // 7, 8, 9
        public static void Main(string[] args)
        {
            int[] vertices;
            Tuple<int, int>[] edges;
            var graph = new Graph<int>();

            Console.WriteLine("Test Case 1");
            CreateDataSet1(out vertices, out edges);
            graph = new Graph<int>(vertices, edges); 
            Console.WriteLine(string.Join(", ", graph.DepthFirstSearch(1)));
            Console.WriteLine(string.Join(", ", graph.BreadthFirstSearch(1)));
            Console.WriteLine(graph.Search(1, 9));
            Console.WriteLine("====================================================================================");

            Console.WriteLine("Test Case 2");
            CreateDataSet2(out vertices, out edges);
            graph = new Graph<int>(vertices, edges);
            Console.WriteLine(string.Join(", ", graph.DepthFirstSearch(1)));
            Console.WriteLine(string.Join(", ", graph.BreadthFirstSearch(1)));
            Console.WriteLine(graph.Search(1, 9));
            Console.WriteLine("====================================================================================");

            Console.WriteLine("Test Case 3");
            CreateDataSet3(out vertices, out edges);
            graph = new Graph<int>(vertices, edges);
            Console.WriteLine(string.Join(", ", graph.DepthFirstSearch(1)));
            Console.WriteLine(string.Join(", ", graph.BreadthFirstSearch(1)));
            Console.WriteLine(graph.Search(1, 9));
            Console.WriteLine("====================================================================================");

            Console.ReadKey();
        }

        private static void CreateDataSet1(out int[] vertices, out Tuple<int, int>[] edges)
        {
            vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            edges = new[]{Tuple.Create(1,2), Tuple.Create(1,4),
                Tuple.Create(2,3), Tuple.Create(2,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,6), Tuple.Create(5,8),
                Tuple.Create(6,9), Tuple.Create(7,8), Tuple.Create(8,9)};
        }

        private static void CreateDataSet2(out int[] vertices, out Tuple<int, int>[] edges)
        {
            vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};
        }

        private static void CreateDataSet3(out int[] vertices, out Tuple<int, int>[] edges)
        {
            vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            edges = new[] {
                Tuple.Create(1,2), Tuple.Create(2,3), Tuple.Create(3,4), Tuple.Create(4,5), 
                Tuple.Create(6,7), Tuple.Create(7,8), Tuple.Create(8,9), Tuple.Create(9,10)
            };
        }
    }
}
