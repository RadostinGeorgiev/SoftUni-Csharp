namespace _03._Travel_Optimizer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Weight}");
        }
    }
    class Graph
    {
        public int EdgesCount;
        public Dictionary<int, List<Edge>> Edges;

        public Graph(int edgesCount)
        {
            this.EdgesCount = edgesCount;

            Edges = new Dictionary<int, List<Edge>>();
        }
    }
    internal class Program
    {
        static int[] parents;
        static void Main(string[] args)
        {
            int edges = int.Parse(Console.ReadLine());                       //nodes

            Graph graph = new Graph(edges);
            graph = ReadEdgesGraphFromConsole(graph);

            int startCity = int.Parse(Console.ReadLine());                    //startNode
            int destinationCity = int.Parse(Console.ReadLine());              //endNode
            int maxStops = int.Parse(Console.ReadLine());

            var distances = Dijkstra(graph, startCity, destinationCity, maxStops + 1);

            if (parents[destinationCity] == -1)
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                Console.WriteLine(string.Join(" ", GetPath(destinationCity)));
            }
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                int start = edgeData[0];
                int end = edgeData[1];

                var edge = new Edge
                {
                    First = start,
                    Second = end,
                    Weight = edgeData[2],
                };

                if (!graph.Edges.ContainsKey(start))
                {
                    graph.Edges.Add(start, new List<Edge>());
                }
                if (!graph.Edges.ContainsKey(end))
                {
                    graph.Edges.Add(end, new List<Edge>());
                }

                graph.Edges[start].Add(edge);
                graph.Edges[end].Add(edge);
            }

            return graph;
        }
        private static double[] Dijkstra(Graph graph, int startNode, int endNode, int maxStops)
        {
            int stops = 0;
            double[] distance = new double[graph.Edges.Keys.Max() + 1];
            Array.Fill(distance, double.PositiveInfinity);                 //init all distances with positive infinity

            distance[startNode] = 0;

            parents = new int[graph.Edges.Keys.Max() + 1];
            Array.Fill(parents, -1);

            //priority queue holding nodes ordered by distance d[]
            var priorityQueue = new SortedSet<int>(
                Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
            priorityQueue.Add(startNode);                                   //add start node to queue

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.First();                            //dequeue the smallest node from Q
                priorityQueue.Remove(minNode);

                if (double.IsPositiveInfinity(distance[minNode]))           //we have a node without available path
                {
                    break;
                }

                if (minNode == endNode)                                     //if we have known end node
                {
                    break;
                }
                
                if ( stops == maxStops)                                     
                {
                    break;
                }

                foreach (var edge in graph.Edges[minNode])
                {
                    int otherNode = edge.First == minNode                   //get the child of current node - node from edge, not included in visited part of graph
                        ? edge.Second
                        : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))     //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newDistance = distance[minNode] + edge.Weight;   //calculate new distance to current node

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;                  //update distance with shortest value
                        parents[otherNode] = minNode;                       //set parent of the node with best distance

                        priorityQueue = new SortedSet<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s]))); //reorder queue
                    }
                }

                stops++;
            }

            return distance;
        }
        private static Stack<int> GetPath(int node)
        {
            Stack<int> path = new Stack<int>();

            while (node != -1)
            {
                path.Push(node);
                node = parents[node];
            }

            return path;
        }
    }
}
