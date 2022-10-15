namespace _01._Most_Reliable_Path
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }

        public Edge()
        {
            First = Second = Weight = 0;
        }
    }
    class Graph
    {
        public int VerticesCount;
        public int EdgesCount;
        public Dictionary<int, List<Edge>> nodes;

        public Graph(int verticesCount, int edgesCount)
        {
            this.VerticesCount = verticesCount;
            this.EdgesCount = edgesCount;

            nodes = new Dictionary<int, List<Edge>>(verticesCount);
        }
    }
    internal class Program
    {
        static int[] parents;
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());
            Graph graph = new Graph(nodes, edges);

            graph = FillInEdgesGraphFromConsole(graph);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            Dijkstra(graph, source, destination);             //Used modified Dijkstra's Algorithm
        }

        private static Graph FillInEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                int first = edgeData[0];
                int second = edgeData[1];

                if (!graph.nodes.ContainsKey(first))
                {
                    graph.nodes.Add(first, new List<Edge>());
                }

                if (!graph.nodes.ContainsKey(second))
                {
                    graph.nodes.Add(second, new List<Edge>());
                }

                graph.nodes[first].Add(new Edge
                {
                    First = first,
                    Second = second,
                    Weight = edgeData[2],
                });

                graph.nodes[second].Add(new Edge
                {
                    First = first,
                    Second = second,
                    Weight = edgeData[2],
                });
            }

            return graph;
        }
        private static void Dijkstra(Graph graph, int source, int destination)
        {
            double[] reliability = new double[graph.nodes.Keys.Max() + 1];
            Array.Fill(reliability, double.NegativeInfinity);                 //init all reliabilities with negative infinity - we search max value

            reliability[source] = 100;

            parents = new int[graph.nodes.Keys.Max() + 1];
            Array.Fill(parents, -1);

            //priority queue holding nodes ordered by reliability r[]
            var priorityQueue = new SortedSet<int>(
                Comparer<int>.Create((f, s) => reliability[s].CompareTo(reliability[f])));
            priorityQueue.Add(source);                                      //add start node to queue

            while (priorityQueue.Count != 0)
            {
                var maxNode = priorityQueue.First();                            //dequeue the largest node from Q
                priorityQueue.Remove(maxNode);

                if (double.IsNegativeInfinity(reliability[maxNode]))        //we have a node without available path
                {
                    break;
                }

                if (maxNode == destination)                                 //if we have known end node
                {
                    break;
                }

                foreach (var edge in graph.nodes[maxNode])
                {
                    int otherNode = edge.First == maxNode                   //get the child of current node - node from edge, not included in visited part of graph
                        ? edge.Second
                        : edge.First;

                    if (double.IsNegativeInfinity(reliability[otherNode]))  //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newReliability = reliability[maxNode] * edge.Weight / 100;   //calculate new reliability to current node

                    if (newReliability > reliability[otherNode])
                    {
                        reliability[otherNode] = newReliability;            //update reliability with better value
                        parents[otherNode] = maxNode;                       //set parrent of the node with best reliability

                        priorityQueue = new SortedSet<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => reliability[s].CompareTo(reliability[f]))); //reorder queue
                    }
                }
            }

            if (double.IsNegativeInfinity(reliability[destination]))
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                Console.WriteLine($"Most reliable path reliability: {reliability[destination]:F2}%");
                GetPath(destination, " -> ");
            }
        }
        private static void GetPath(int node, string separator)
        {
            Stack<int> path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = parents[node];
            }

            Console.WriteLine(string.Join(separator, path));
        }

    }
}
