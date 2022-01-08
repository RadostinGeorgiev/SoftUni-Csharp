namespace _03._Shortest_Path
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parents;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            
            graph = new List<int>[nodes + 1];
            ReadGraph(nodes, edges);

            int startNode = int.Parse(Console.ReadLine());
            int endNode = int.Parse(Console.ReadLine());

            visited = new bool[nodes + 1];
            parents = new int[nodes + 1];
            Array.Fill(parents, -1);

            BFS(startNode, endNode);
        }

        private static void BFS(int start, int destination)
        {
            var queue = new Queue<int>();

            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = GetPath(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(' ', path));
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parents[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int destination)
        {
            Stack<int> result = new Stack<int>();

            var node = destination;

            while (node != -1)
            {
                result.Push(node);
                node = parents[node];
            }

            return result;
        }

        private static void ReadGraph(int nodes, int edges)
        {
            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int edge = 1; edge <= edges; edge++)
            {
                string[] currentEdge = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int destination = int.Parse(currentEdge[0]);
                int source = int.Parse(currentEdge[1]);

                graph[source].Add(destination);
                graph[destination].Add(source);
            }
        }
    }
}