namespace _01._Electrical_Substation_Network
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

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            Graph graph = new Graph(nodes);
            graph = ReadGraphNodesFromConsole(graph, lines);

            visited = new bool[nodes];
            List<Stack<int>> components = FindStronglyConnectedComponents(graph);

            components.ForEach(c => Console.WriteLine($"{String.Join(", ", c)}"));
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
        private static Graph BuildReverseGraph(Graph graph)
        {
            Graph reversedGraph = new Graph(graph.VerticesCount);
            for (int node = 0; node < graph.VerticesCount; node++)
            {
                reversedGraph.nodes[node] = new List<int>();
            }

            for (int node = 0; node < graph.VerticesCount; node++)
            {
                foreach (int child in graph.nodes[node])
                {
                    reversedGraph.nodes[child].Add(node);
                }
            }

            return reversedGraph;
        }
        private static Stack<int> TopologicalSorting(Graph graph)
        {
            Stack<int> sorted = new Stack<int>();

            for (int node = 0; node < graph.VerticesCount; node++)              //DFS for all nodes in graph
            {
                if (visited[node])
                {
                    continue;
                }

                Dfs(node, graph, sorted);
            }

            return sorted;
        }
        private static void Dfs(int node, Graph graph, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (int child in graph.nodes[node])
            {
                Dfs(child, graph, result);
            }

            result.Push(node);
        }
        public static List<Stack<int>> FindStronglyConnectedComponents(Graph originalGraph)
        {
            var stronglyConnectedComponents = new List<Stack<int>>();

            Stack<int> sorted = TopologicalSorting(originalGraph);
            Graph reversedGraph = BuildReverseGraph(originalGraph);

            visited = new bool[originalGraph.VerticesCount];

            while (sorted.Count != 0)                                           //DFS for all nodes in topological sorted elements
            {
                int node = sorted.Pop();

                if (visited[node])
                {
                    continue;
                }

                Stack<int> elements = new Stack<int>();
                Dfs(node, reversedGraph, elements);

                stronglyConnectedComponents.Add(elements);
            }

            return stronglyConnectedComponents;
        }
    }
}
