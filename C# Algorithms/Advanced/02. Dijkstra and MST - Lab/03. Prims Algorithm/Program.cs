namespace _03._Prims_Algorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }
    internal class Program
    {
        static Dictionary<int, List<Edge>> graph;
        static List<int> spanningTreeNodes;
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            //Prim's Algorithm  O(E + V.logV) -> for larger graphs; necessary specified start node
            CreateNodeEdgesGraphFromConsole(number);
            MSTPrim();
        }

        private static void CreateNodeEdgesGraphFromConsole(int edges)
        {
            graph = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                int firstNode = edgeData[0];
                int secondNode = edgeData[1];

                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeData[2],
                };

                if (!graph.ContainsKey(firstNode))
                {
                    graph.Add(firstNode, new List<Edge>());
                }
                if (!graph.ContainsKey(secondNode))
                {
                    graph.Add(secondNode, new List<Edge>());
                }

                graph[firstNode].Add(edge);
                graph[secondNode].Add(edge);
            }
        }

        private static void MSTPrim()
        {
            spanningTreeNodes = new List<int>();

            foreach (var node in graph.Keys)
            {
                if (!spanningTreeNodes.Contains(node))
                {
                    Prim(node);
                }
            };
        }
        private static void Prim(int startNode)
        {
            var priorityQueue = new OrderedBag<Edge>(
                Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            spanningTreeNodes.Add(startNode);                       //add startNode in spanningTree
            priorityQueue.AddMany(graph[startNode]);                //add startNode edge in queue

            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.RemoveFirst();          //get edge with min weight from queue

                int nonTreeNode = -1;                               //check if nodes of this edge are part of the tree
                if (spanningTreeNodes.Contains(minEdge.First) &&
                    !spanningTreeNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                }
                if (spanningTreeNodes.Contains(minEdge.Second) &&
                    !spanningTreeNodes.Contains(minEdge.First))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode != -1)                              //if we have only one node as part of the tree:
                {
                    Console.WriteLine($"{minEdge.First} - {minEdge.Second}");   //print edge

                    spanningTreeNodes.Add(nonTreeNode);             //add this edge to the tree
                    priorityQueue.AddMany(graph[nonTreeNode]);      //add edges of the nonTree node to the queue 
                }
            }
        }
    }
}
