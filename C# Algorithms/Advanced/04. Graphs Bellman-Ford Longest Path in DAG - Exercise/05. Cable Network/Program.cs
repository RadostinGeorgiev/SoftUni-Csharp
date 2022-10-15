namespace _05._Cable_Network
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
        public List<Edge>[] edges;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;
            this.edges = new List<Edge>[VerticesCount];

            for (int node = 0; node < this.edges.Length; node++)
            {
                this.edges[node] = new List<Edge>();
            }
        }
    }
    internal class Program
    {
        static HashSet<int> spanningTreeNodes;
        static int budget;

        static void Main(string[] args)
        {
            spanningTreeNodes = new HashSet<int>();

            budget = int.Parse(Console.ReadLine());

            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            Graph graph = new Graph(nodes, edges);

            graph = FillInNodesGraphFromConsole(graph);

            Prim(graph);                                                //It is not possible to test this problem in Judge with PowerCollections
        }

        private static Graph FillInNodesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

                var edge = new Edge
                {
                    First = int.Parse(edgeData[0]),
                    Second = int.Parse(edgeData[1]),
                    Weight = int.Parse(edgeData[2]),
                };

                graph.edges[edge.First].Add(edge);
                graph.edges[edge.Second].Add(edge);

                if (edgeData.Length == 4)
                {
                    spanningTreeNodes.Add(edge.First);
                    spanningTreeNodes.Add(edge.Second);
                }
            }

            return graph;
        }
        private static void Prim(Graph graph)
        {
            var priorityQueue = new List<Edge>();
            int usedBudget = 0;

            foreach (var node in spanningTreeNodes)
            {
                priorityQueue.AddRange(graph.edges[node]);
            };

            priorityQueue.Sort();

            while (priorityQueue.Count != 0)
            {
                var minEdge = priorityQueue.First();                    //get edge with min weight from queue
                priorityQueue.Remove(minEdge);

                int nonTreeNode = -1;                                   //check if nodes of this edge are part of the tree
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

                if (nonTreeNode == -1)                                  //if we have only one node as part of the tree:
                {
                    continue;
                }

                if (usedBudget + minEdge.Weight > budget)
                {
                    break;
                }

                usedBudget += minEdge.Weight;
                spanningTreeNodes.Add(nonTreeNode);                     //add this edge to the tree
                priorityQueue.AddRange(graph.edges[nonTreeNode]);       //add edges of the nonTree node to the queue
                priorityQueue.Sort();
                //Console.WriteLine(minEdge);                             //print edge
            }

            Console.WriteLine($"Budget used: {usedBudget}");
        }
    }
}
