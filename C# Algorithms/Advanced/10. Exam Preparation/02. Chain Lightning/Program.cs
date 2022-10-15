namespace _02._Chain_Lightning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge : IComparable<Edge>
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }

        public Edge()
        {
            First = Second = Weight = 0;
        }
        public int CompareTo(Edge other)
        {
            int result = this.Weight.CompareTo(other.Weight);
            return result;
        }
        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Weight}");
        }
    }
    class Graph
    {
        public int VerticesCount;
        public int EdgesCount;
        public Dictionary<int, List<Edge>> Edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            Edges = new Dictionary<int, List<Edge>>();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int neighborhoods = int.Parse(Console.ReadLine());          //nodes
            int distances = int.Parse(Console.ReadLine());              //edges
            int lightnings = int.Parse(Console.ReadLine());

            Graph graph = new Graph(neighborhoods, distances);
            graph = ReadNodesGraphFromConsole(graph);

            int[] totalDamages = new int[graph.VerticesCount];
            for (int light = 0; light < lightnings; light++)
            {
                int[] strike = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int forcedNeighborhood = strike[0];
                int strikePower = strike[1];

                if (!graph.Edges.ContainsKey(forcedNeighborhood))
                {
                    graph.Edges.Add(forcedNeighborhood, new List<Edge>());
                }

                int[] damages = Prim(graph, forcedNeighborhood, strikePower);

                for (int n = 0; n < totalDamages.Length; n++)
                {
                    totalDamages[n] += damages[n];
                }
            }

            int maxDamage = totalDamages.Max();
            Console.WriteLine(maxDamage);
            //int maxIndex = Array.IndexOf(totalDamages, maxDamage);
            //Console.WriteLine($"{maxIndex} => {maxDamage}");
            //Console.WriteLine($"{string.Join(" - ", totalDamages)}");
        }

        private static Graph ReadNodesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                int firstNode = edgeData[0];
                int secondNode = edgeData[1];

                if (!graph.Edges.ContainsKey(firstNode))
                {
                    graph.Edges.Add(firstNode, new List<Edge>());
                }
                if (!graph.Edges.ContainsKey(secondNode))
                {
                    graph.Edges.Add(secondNode, new List<Edge>());
                }
                
                var edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeData[2],
                };

                graph.Edges[firstNode].Add(edge);
                graph.Edges[secondNode].Add(edge);

            }

            return graph;
        }
        private static int[] Prim(Graph graph, int startNode, int strikePower)
        {
            HashSet<int> treeNodes = new HashSet<int>();
            int[] damages = new int[graph.VerticesCount];

            var priorityQueue = new List<Edge>();
            treeNodes.Add(startNode);                                   //add startNode in spanningTree
            damages[startNode] = strikePower;
            //Console.WriteLine($"{startNode} -> {damages[startNode]}");

            foreach (var node in treeNodes)
            {
                priorityQueue.AddRange(graph.Edges[node]);
            }

            priorityQueue.Sort();

            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.First();                    //get edge with min weight from queue
                priorityQueue.Remove(minEdge);

                int nonTreeNode = -1;                                   //check if nodes of this edge are part of the tree
                if (treeNodes.Contains(minEdge.First) &&
                    !treeNodes.Contains(minEdge.Second))
                {
                    nonTreeNode = minEdge.Second;
                    damages[minEdge.Second] = damages[minEdge.First] / 2;
                    //Console.WriteLine($"{minEdge.Second} -> {damages[minEdge.Second]}");
                }
                if (treeNodes.Contains(minEdge.Second) &&
                    !treeNodes.Contains(minEdge.First))
                {
                    nonTreeNode = minEdge.First;
                    damages[minEdge.First] = damages[minEdge.Second] / 2;
                    //Console.WriteLine($"{minEdge.First} -> {damages[minEdge.First]}");
                }

                if (nonTreeNode == -1)                                  //if we have only one node as part of the tree:
                {
                    continue;
                }

                treeNodes.Add(nonTreeNode);                             //add this edge to the tree
                priorityQueue.AddRange(graph.Edges[nonTreeNode]);       //add edges of the nonTree node to the queue
                priorityQueue.Sort();

                //Console.WriteLine($"{minEdge} => {damages[minEdge.First]}-{damages[minEdge.Second]}");                             //print edge
            }

            return damages;
        }
    }
}
