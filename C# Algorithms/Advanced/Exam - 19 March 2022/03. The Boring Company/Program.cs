namespace _03._The_Boring_Company
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Costs { get; set; }                                              //Weight

        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Costs}");
        }
    }

    class Graph
    {
        public int VerticesCount { get; set; }
        public int EdgesCount { get; set; }
        public List<Edge> Edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            this.Edges = new List<Edge>();
        }
    }

    internal class Program
    {
        static int[] parents;
        private static int minBudget;

        static void Main(string[] args)
        {
            minBudget = 0;

            int districts = int.Parse(Console.ReadLine());
            int connections = int.Parse(Console.ReadLine());
            int connectedDistricts = int.Parse(Console.ReadLine());

            Graph graph = new Graph(districts, connections);
            ReadGraphFromConsole(graph);

            //Kruskal’s Algorithm for smaller graphs
            List<Edge> MST = MSTKruskal(graph, connectedDistricts);

            Console.WriteLine($"Minimum budget: {minBudget}");
            MST.ForEach(edge => Console.WriteLine($"{edge}"));
        }

        private static void ReadGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                int[] edgeData = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                graph.Edges.Add(new Edge
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    Costs = edgeData[2],
                });
            }
        }

        private static List<Edge>
            MSTKruskal(Graph graph, int availableConnections) //Minimum Spanning Tree - Kruskal’s algorithm 
        {
            List<Edge> forest = new List<Edge>();

            List<int> nodes = graph.Edges //get Graph's nodes from edge's structure
                                   .Select(e => e.First)
                                   .Union(graph.Edges.Select(e => e.Second))
                                   .Distinct()
                                   .ToList();

            parents = new int[nodes.Max() + 1];
            nodes.ForEach(node => parents[node] = node); //initialize forest as self parent graphs

            List<Edge> sortedEdges = graph.Edges.OrderBy(e => e.Costs).ToList();

            //modification of Kruskal’s algorithm - adding previously known links
            for (int p = 0; p < availableConnections; p++)
            {
                int[] connection = Console.ReadLine()
                                          .Split()
                                          .Select(int.Parse)
                                          .ToArray();

                int firstDistrict = connection[0];
                int secondDistrict = connection[1];

                Edge edge = graph.Edges
                                 .Find(x => x.First == firstDistrict &&
                                      x.Second == secondDistrict);

                parents[secondDistrict] = firstDistrict;
                forest.Add(edge);
                sortedEdges.Remove(edge);
            }

            sortedEdges.ForEach(edge =>
            {
                int firstRoot = FindRoot(edge.First);
                int secondRoot = FindRoot(edge.Second);

                if (firstRoot != secondRoot)
                {
                    parents[secondRoot] = firstRoot;
                    forest.Add(edge);

                    minBudget += edge.Costs;
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