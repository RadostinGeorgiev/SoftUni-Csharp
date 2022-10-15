namespace _04._Good_Omens
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int SecurityExpenses { get; set; }
        public override string ToString()
        {
            return string.Format($"[{this.First} <=> {this.Second}]");
        }
    }
    class Graph
    {
        private int verticesCount;
        public readonly int EdgesCount;
        public readonly List<Edge> Edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.verticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            Edges = new List<Edge>();
        }
    }
    internal class Program
    {
        static int[] parents;
        static void Main(string[] args)
        {
            int stores = int.Parse(Console.ReadLine());
            int paths = int.Parse(Console.ReadLine());
            Graph graph = new Graph(stores, paths);
            graph = ReadEdgesGraphFromConsole(graph);

            //Kruskal’s Algorithm O(|E| * log* |E|) -> for smaller graphs
            var MST = MSTKruskal(graph);
            Console.WriteLine($"{string.Join(" ", MST)}");
            Console.WriteLine($"{MST.Sum(x=>x.SecurityExpenses)}");
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(" ")
                                        .Select(int.Parse)
                                        .ToArray();
                graph.Edges.Add(new Edge
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    SecurityExpenses = edgeData[2],
                });
            }

            return graph;
        }

        private static List<Edge> MSTKruskal(Graph graph)                                    //Minimum Spanning Tree - Kruskal’s algorithm 
        {
            List<Edge> forest = new List<Edge>();

            List<int> nodes = graph.Edges                                         //get Graph's nodes from edge's structure
                            .Select(e => e.First)
                            .Union(graph.Edges.Select(e => e.Second))
                            .Distinct()
                            .ToList();

            parents = new int[nodes.Max() + 1];
            nodes.ForEach(node => parents[node] = node);                    //initialize forest as self parent graphs

            List<Edge> sortedEdges = graph.Edges.OrderBy(e => e.SecurityExpenses).ToList();
            sortedEdges.ForEach(edge =>
            {
                var firstRoot = FindRoot(edge.First);
                var secondRoot = FindRoot(edge.Second);

                if (firstRoot != secondRoot)
                {
                    parents[secondRoot] = firstRoot;
                    forest.Add(edge);
                }
            });

            return forest;
        }

        static int FindRoot(int node)
        {
            while (parents[node] != node)
            {
                node = parents[node];
            }

            return node;
        }
    }
}
