namespace _02._Max_Flow_algorithm___Edmonds_Karp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Graph
    {
        public int VerticesCount { get; set; }
        public int[][] Nodes;

        public Graph(int verticesCount)
        {
            this.VerticesCount = verticesCount;
            this.Nodes = new int[VerticesCount][];
        }
    }

    internal class Program
    {
        private static Graph graph;
        private static int[] parents;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            graph = new Graph(nodes);
            graph = ReadGraphNodesFromConsole(graph);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            parents = new int[nodes];
            Array.Fill(parents, -1);

            ReconstructPath(source, destination);
        }

        private static Graph ReadGraphNodesFromConsole(Graph graph)
        {
            for (int node = 0; node < graph.VerticesCount; node++)
            {
                int[] children = Console.ReadLine()
                                        .Split(",")
                                        .Select(int.Parse)
                                        .ToArray();

                graph.Nodes[node] = children;
            }

            return graph;
        }

        private static bool Bfs(int source, int destination)
        {
            bool[] visited = new bool[graph.VerticesCount];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int child = 0; child < graph.Nodes[node].Length; child++)
                {
                    if (!visited[child] && graph.Nodes[node][child] > 0)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parents[child] = node;
                    }
                }
            }

            return visited[destination];
        }

        private static int GetMinFlow(int source, int destination)
        {
            int minFlow = int.MaxValue;

            int node = destination;

            while (node != source)
            {
                int parent = parents[node];
                minFlow = Math.Min(minFlow, graph.Nodes[parent][node]);
                node = parent;
            }

            return minFlow;
        }

        private static void UpdateFlow(int source, int destination, int flow)
        {
            int node = destination;

            while (node != source)
            {
                int parent = parents[node];
                graph.Nodes[parent][node] -= flow;
                graph.Nodes[node][parent] += flow;
                node = parent;
            }
        }

        private static void ReconstructPath(int source, int destination)
        {
            int maxFlow = 0;

            while (Bfs(source, destination))
            {
                int minFlow = GetMinFlow(source, destination);

                UpdateFlow(source, destination, minFlow);
                maxFlow += minFlow;
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }
    }
}