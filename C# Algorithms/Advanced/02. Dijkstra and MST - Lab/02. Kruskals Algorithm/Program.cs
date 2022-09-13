namespace _02._Kruskals_Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }
    internal class Program
    {
        static List<Edge> graph;
        static int[] parents;
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            //Kruskal’s Algorithm O(E.logV) -> for smaller graphs
            CreateEdgesGraphFromConsole(number);
            MSTKruskal();
        }

        private static void CreateEdgesGraphFromConsole(int edges)
        {
            graph = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();
                graph.Add(new Edge
                {
                    First = edgeData[0],
                    Second = edgeData[1],
                    Weight = edgeData[2],
                });
            }
        }

        private static void MSTKruskal()                                    //Minimum Spanning Tree - Kruskal’s algorithm 
        {
            List<Edge> forest = new List<Edge>();

            List<int> nodes = graph                                         //get Graph's nodes from edge's structure
                            .Select(e => e.First)
                            .Union(graph.Select(e => e.Second))
                            .Distinct()
                            .ToList();

            parents = new int[nodes.Max() + 1];
            nodes.ForEach(node => parents[node] = node);                    //initialize forest as self parent graphs

            List<Edge> sortedEdges = graph.OrderBy(e => e.Weight).ToList();
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

            forest.ForEach(edge => Console.WriteLine($"{edge.First} - {edge.Second}"));
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
