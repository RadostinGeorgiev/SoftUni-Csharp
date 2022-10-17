namespace _03._Emergency_Plan
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public TimeSpan Time { get; set; }                                          //in seconds

        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Time}");
        }
    }

    internal class Program
    {
        static int[] parents;

        static void Main(string[] args)
        {
            int rooms = int.Parse(Console.ReadLine());                            //nodes

            var exits = Console.ReadLine()
                               .Split()
                               .Select(int.Parse)
                               .ToArray();
            int edges = int.Parse(Console.ReadLine());

            var graph = ReadEdgesGraphFromConsole(rooms, edges);

            var maxTime = TimeSpan.ParseExact(Console.ReadLine(), "mm\\:ss", CultureInfo.InvariantCulture).TotalSeconds;

            for (int room = 0; room < rooms; room++)
            {
                if (exits.Contains(room))
                {
                    continue;
                }

                var bestEvacuationTime = Dijkstra(graph, room, exits);

                if (double.IsPositiveInfinity(bestEvacuationTime))
                {
                    Console.WriteLine($"Unreachable {room} (N/A)");
                    continue;
                }

                Console.WriteLine(bestEvacuationTime <= maxTime
                    ? $"Safe {room} ({TimeSpan.FromSeconds(bestEvacuationTime):hh\\:mm\\:ss})"
                    : $"Unsafe {room} ({TimeSpan.FromSeconds(bestEvacuationTime):hh\\:mm\\:ss})");
            }
        }

        private static List<Edge>[] ReadEdgesGraphFromConsole(int nodes, int edges)
        {
            var graph = new List<Edge>[nodes];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                string[] edgeData = Console.ReadLine().Split();

                int start = int.Parse(edgeData[0]);
                int end = int.Parse(edgeData[1]);

                Edge edge = new Edge
                {
                    First = start,
                    Second = end,
                    Time = TimeSpan.ParseExact(edgeData[2], "mm\\:ss", CultureInfo.InvariantCulture),
                };

                graph[start].Add(edge);
                graph[end].Add(edge);
            }

            return graph;
        }

        private static double Dijkstra(List<Edge>[] graph, int startNode, int[] exits)
        {
            double[] distance = new double[graph.Length];
            parents = new int[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                distance[i] = double.PositiveInfinity;
                parents[i] = -1;
            }

            distance[startNode] = 0;

            //priority queue holding nodes ordered by distance d[]
            OrderedBag<int> priorityQueue = new OrderedBag<int>(Comparer<int>
               .Create((f, s) => distance[f].CompareTo(distance[s])));
            priorityQueue.Add(startNode);                                      //add start node to queue

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.RemoveFirst();                          //dequeue the smallest node from Q

                if (double.IsPositiveInfinity(distance[minNode]))                 //we have a node without available path
                {
                    break;
                }

                foreach (Edge edge in graph[minNode])
                {
                    int otherNode = edge.First == minNode                           //get the child of current node - node from edge, not included in visited part of graph
                            ? edge.Second
                            : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))           //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    var newTime = distance[minNode] + edge.Time.TotalSeconds; //calculate new distance to current node

                    if (newTime < distance[otherNode])
                    {
                        distance[otherNode] = newTime;                              //update distance with shortest value
                        parents[otherNode] = minNode;                               //set parent of the node with best distance

                        priorityQueue = new OrderedBag<int>(priorityQueue, Comparer<int>
                           .Create((f, s) => distance[f].CompareTo(distance[s]))); //reorder queue
                    }
                }
            }

            var bestEvacuationTimes = double.PositiveInfinity;

            foreach (int exit in exits)
            {
                if (distance[exit] < bestEvacuationTimes)
                {
                    bestEvacuationTimes = distance[exit];
                }
            }

            return bestEvacuationTimes;
        }
    }
}