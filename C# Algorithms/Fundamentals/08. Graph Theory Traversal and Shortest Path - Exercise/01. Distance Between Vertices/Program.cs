namespace _01._Distance_Between_Vertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static Dictionary<int, int> parents;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();
            ReadGraph(nodes);

            for (int i = 0; i < pairs; i++)
            {
                int[] pairArgs = Console.ReadLine()
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray();

                int startNode = pairArgs[0];
                int endNode = pairArgs[1];

                Console.WriteLine($"{{{startNode}, {endNode}}} -> {BFS(startNode, endNode)}");
            }
        }

        private static int BFS(int start, int destination)
        {
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            var isFound = false;

            queue.Enqueue(start);
            visited.Add(start);
            parents = new Dictionary<int, int>() { { start, -1 } };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return GetPathSteps(destination);
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child)) continue;

                    parents[child] = node;
                    queue.Enqueue(child);
                    visited.Add(child);
                }
            }

            return -1;
        }

        private static int GetPathSteps(int destination)
        {
            var result = 0;

            var node = destination;

            while (node != -1)
            {
                node = parents[node];
                result++;
            }

            return result - 1;
        }

        private static void ReadGraph(int nodes)
        {
            for (int i = 0; i < nodes; i++)
            {
                string[] edgeArgs = Console.ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                var node = int.Parse(edgeArgs[0]);


                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<int>());
                }

                if (edgeArgs.Length == 1) continue;

                var children = edgeArgs[1].Split().Select(int.Parse).ToList();
                graph[node] = children;
            }
        }
    }
}