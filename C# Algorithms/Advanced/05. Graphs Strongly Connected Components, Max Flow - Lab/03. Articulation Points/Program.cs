namespace _03._Articulation_Points
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Graph
    {
        public int VerticesCount;
        public List<int>[] nodes;

        public Graph(int verticesCount)
        {
            this.VerticesCount = verticesCount;
            this.nodes = new List<int>[VerticesCount];

            for (int node = 0; node < this.nodes.Length; node++)
            {
                this.nodes[node] = new List<int>();
            }
        }
    }
    internal class Program
    {
        private static bool[] visited;
        private static int[] depths;
        private static int[] lowpoints;
        private static int[] parents;

        private static List<int> articulationPoints;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            Graph graph = new Graph(nodes);
            graph = ReadGraphNodesFromConsole(graph, lines);

            visited = new bool[nodes];
            depths = new int[nodes];
            lowpoints = new int[nodes];
            parents = new int[nodes];
            articulationPoints = new List<int>();

            Array.Fill(parents, -1);

            for (int node = 0; node < graph.nodes.Length; node++)
            {
                if (!visited[node])
                {
                    Dfs(graph, node, 1);
                }
            }

            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
        }

        private static Graph ReadGraphNodesFromConsole(Graph graph, int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = line[0];
                graph.nodes[node].AddRange(line.Skip(1));
            }

            return graph;
        }
        private static void Dfs(Graph graph, int node, int depth)
        {
            visited[node] = true;
            depths[node] = depth;
            lowpoints[node] = depth;

            var children = 0;
            var isArticulation = false;

            foreach (int child in graph.nodes[node])
            {
                if (!visited[child])
                {
                    parents[child] = node;
                    Dfs(graph, child, depth + 1);
                    children += 1;

                    if (lowpoints[child] >= depth)
                    {
                        isArticulation = true;
                    }

                    lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);
                }
                else if (child != parents[node])
                {
                    lowpoints[node] = Math.Min(lowpoints[node], depths[child]);
                }
            }

            if ((parents[node] == -1 && children > 1) ||
                (parents[node] != -1 && isArticulation))
            {
                articulationPoints.Add(node);
            }
        }
    }
}
