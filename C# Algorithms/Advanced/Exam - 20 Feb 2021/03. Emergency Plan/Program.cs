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
        static void Main(string[] args)
        {
            int rooms = int.Parse(Console.ReadLine());                            //nodes

            int[] exits = Console.ReadLine()
                                 .Split()
                                 .Select(int.Parse)
                                 .ToArray();
            int edges = int.Parse(Console.ReadLine());

            List<Edge>[] graph = ReadEdgesGraphFromConsole(rooms, edges);

            TimeSpan maxTime = TimeSpan.ParseExact(Console.ReadLine(), "mm\\:ss", CultureInfo.InvariantCulture);

            for (int room = 0; room < rooms; room++)
            {
                if (exits.Contains(room))
                {
                    continue;
                }

                TimeSpan bestEvacuationTime = Dijkstra(graph, room, exits);

                if (bestEvacuationTime == TimeSpan.MaxValue)
                {
                    Console.WriteLine($"Unreachable {room} (N/A)");
                    continue;
                }

                Console.WriteLine(bestEvacuationTime <= maxTime
                    ? $"Safe {room} ({bestEvacuationTime:hh\\:mm\\:ss})"
                    : $"Unsafe {room} ({bestEvacuationTime:hh\\:mm\\:ss})");
            }
        }

        private static List<Edge>[] ReadEdgesGraphFromConsole(int nodes, int edges)
        {
            List<Edge>[] graph = new List<Edge>[nodes];

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

        private static TimeSpan Dijkstra(List<Edge>[] graph, int startNode, int[] exits)
        {
            TimeSpan[] times = new TimeSpan[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                times[i] = TimeSpan.MaxValue;
            }

            times[startNode] = new TimeSpan(0);

            //priority queue holding nodes ordered by time t[]
            OrderedBag<int> priorityQueue = new OrderedBag<int>(Comparer<int>
               .Create((f, s) => times[f].CompareTo(times[s])));
            priorityQueue.Add(startNode);                                      //add start node to queue

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.RemoveFirst();                          //dequeue the smallest node from Q

                if (times[minNode] == TimeSpan.MaxValue)                            //we have a node without available path
                {
                    break;
                }

                foreach (Edge edge in graph[minNode])
                {
                    int otherNode = edge.First == minNode                           //get the child of current node - node from edge, not included in visited part of graph
                            ? edge.Second
                            : edge.First;

                    if (times[otherNode] == TimeSpan.MaxValue)                      //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    TimeSpan newTime = times[minNode] + edge.Time;                       //calculate new distance to current node

                    if (newTime < times[otherNode])
                    {
                        times[otherNode] = newTime;                                 //update distance with shortest value

                        priorityQueue = new OrderedBag<int>(priorityQueue, Comparer<int>
                           .Create((f, s) => times[f].CompareTo(times[s]))); //reorder queue
                    }
                }
            }

            TimeSpan bestEvacuationTimes = TimeSpan.MaxValue;

            foreach (int exit in exits)
            {
                if (times[exit] < bestEvacuationTimes)
                {
                    bestEvacuationTimes = times[exit];
                }
            }

            return bestEvacuationTimes;
        }
    }
}