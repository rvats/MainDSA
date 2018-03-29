using GenerateStrings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDemo
{
    class Program
    {
        // 1, 2, 3
        // 4, 5, 6
        // 7, 8, 9
        public static void Main(string[] args)
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,4),
                Tuple.Create(2,3), Tuple.Create(2,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,6), Tuple.Create(5,8),
                Tuple.Create(6,9), Tuple.Create(7,8), Tuple.Create(8,9)};

            var graph = new Graph<int>(vertices, edges);

            Console.WriteLine(string.Join(", ", graph.DFS(graph, 1)));
            Console.WriteLine(string.Join(", ", graph.BFS(graph, 1)));
        }
    }
}
