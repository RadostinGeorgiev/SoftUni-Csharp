namespace _03._Water_Supply_System_Disaster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Graph
    {
        public int VerticesCount { get; set; }
        public List<int>[] Nodes;

        public Graph(int verticesCount)
        {
            this.VerticesCount = verticesCount;
            this.Nodes = new List<int>[VerticesCount + 1];

            for (int node = 0; node < this.Nodes.Length; node++)
            {
                this.Nodes[node] = new List<int>();
            }
        }
    }

    internal class Program
    {
        private static int[] depths;
        private static int[] lowpoints;
        private static bool[] visited;

        private static int[] parents;

        private static List<int> articulationPoints;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int requiredParts = int.Parse(Console.ReadLine());

            Graph graph = new Graph(nodes);
            graph = ReadGraphFromConsole(graph);

            depths = new int[nodes + 1];
            lowpoints = new int[nodes + 1];
            visited = new bool[nodes + 1];
            parents = new int[nodes + 1];
            Array.Fill(parents, -1);

            articulationPoints = new List<int>();

            for (int node = 0; node < graph.Nodes.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                FindArticulationPointsDfs(graph, node, 1);
            }

            List<int> parts = new List<int>(articulationPoints.Count + 1);

            for (int i = 0; i < articulationPoints.Count; i++)
            {
                parts.Add(CountConnectedComponents(graph, articulationPoints[i]));
            }

            //Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
            Console.WriteLine(parts.Contains(requiredParts)
                ? $"{articulationPoints[parts.IndexOf(requiredParts)]}"
                : $"{0}");
        }

        private static Graph ReadGraphFromConsole(Graph graph)
        {
            for (int node = 1; node <= graph.VerticesCount; node++)
            {
                int[] connections = Console.ReadLine()
                                           .Split()
                                           .Select(int.Parse)
                                           .ToArray();

                graph.Nodes[node].AddRange(connections);
            }

            return graph;
        }

        private static void FindArticulationPointsDfs(Graph graph, int node, int depth)
        {
            visited[node] = true;
            depths[node] = depth;
            lowpoints[node] = depth;

            int children = 0;
            bool isArticulationPoint = false;

            foreach (int child in graph.Nodes[node])
            {
                if (!visited[child])
                {
                    parents[child] = node;
                    FindArticulationPointsDfs(graph, child, depth + 1);
                    children += 1;

                    if (lowpoints[child] >= depth)
                    {
                        isArticulationPoint = true;
                    }

                    lowpoints[node] = Math.Min(lowpoints[node], lowpoints[child]);
                }
                else if (child != parents[node])
                {
                    lowpoints[node] = Math.Min(lowpoints[node], depths[child]);
                }
            }

            if ((parents[node] == -1 && children > 1) ||      //node is root of DFS tree and has two or more children.
                (parents[node] != -1 && isArticulationPoint)) //node is not root of DFS tree 
            {
                articulationPoints.Add(node);
            }
        }

        private static int CountConnectedComponents(Graph graph, int deletedNode)
        {
            visited = new bool[graph.VerticesCount + 1];
            int counter = 0;

            for (int node = 1; node < graph.Nodes.Length; node++)
            {
                if (visited[node] || node == deletedNode) continue;

                //Console.Write($"Connected component [{node}]:");
                DFS(graph, node, deletedNode);

                //Console.WriteLine();
                counter++;
            }

            return counter;
        }

        private static void DFS(Graph graph, int node, int deletedNode)
        {
            if (visited[node] || node == deletedNode)
            {
                return;
            }

            visited[node] = true;

            foreach (int child in graph.Nodes[node])
            {
                DFS(graph, child, deletedNode);
            }

            //Console.Write(" " + node);
        }
    }
}