namespace _03._Emergency_Plan
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public double Time { get; set; }                               //in seconds
        public override string ToString()
        {
            return string.Format($"({this.First}-{this.Second}) -> {this.Time}");
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
            int rooms = int.Parse(Console.ReadLine());                       //nodes
            int[] exits = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int connections = int.Parse(Console.ReadLine());

            Graph graph = new Graph(rooms);
            graph = ReadEdgesGraphFromConsole(graph);

            string input = Console.ReadLine();
            double maxTime = TimeSpan.ParseExact(input, @"mm\:ss", CultureInfo.InvariantCulture).TotalSeconds;
            double[] bestEvacuationTimes = new double[rooms];
            Array.Fill(bestEvacuationTimes, double.PositiveInfinity);

            for (int i = 0; i < exits.Length; i++)
            {
                int startRoom = exits[i];                    //startNode
                var time = Dijkstra(graph, startRoom);

                for (int j = 0; j < rooms; j++)
                {
                    if (time[j] < bestEvacuationTimes[j])
                    {
                        bestEvacuationTimes[j] = time[j];
                    }
                }
            }

            for (int room = 0; room < rooms; room++)
            {
                if (exits.Contains(room))
                {
                    continue;
                }

                if (double.IsPositiveInfinity(bestEvacuationTimes[room]))
                {
                    Console.WriteLine($"Unreachable {room} (N/A)");
                    continue;
                }

                Console.WriteLine(bestEvacuationTimes[room] <= maxTime
                    ? $"Safe {room} ({TimeSpan.FromSeconds(bestEvacuationTimes[room])})"
                    : $"Unsafe {room} ({TimeSpan.FromSeconds(bestEvacuationTimes[room])})");
            }
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split();

                int start = int.Parse(edgeData[0]);
                int end = int.Parse(edgeData[1]);

                var edge = new Edge
                {
                    First = start,
                    Second = end,
                    Time = TimeSpan.ParseExact(edgeData[2], @"mm\:ss", CultureInfo.InvariantCulture).TotalSeconds
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
        private static double[] Dijkstra(Graph graph, int startNode)
        {
            double[] time = new double[graph.EdgesCount];
            Array.Fill(time, double.PositiveInfinity);                        //init all distances with positive infinity

            time[startNode] = new double();

            parents = new int[graph.EdgesCount];
            Array.Fill(parents, -1);

            //priority queue holding nodes ordered by distance d[]
            var priorityQueue = new SortedSet<int>(
                Comparer<int>.Create((f, s) => time[f].CompareTo(time[s])));
            priorityQueue.Add(startNode);                                   //add start node to queue

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.First();                            //dequeue the smallest node from Q
                priorityQueue.Remove(minNode);

                if (double.IsPositiveInfinity(time[minNode]))                           //we have a node without available path
                {
                    break;
                }

                foreach (var edge in graph.Edges[minNode])
                {
                    int otherNode = edge.First == minNode                       //get the child of current node - node from edge, not included in visited part of graph
                        ? edge.Second
                        : edge.First;

                    if (double.IsPositiveInfinity(time[otherNode]))                     //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newTime = time[minNode] + edge.Time;             //calculate new distance to current node

                    if (newTime < time[otherNode])
                    {
                        time[otherNode] = newTime;                          //update distance with shortest value
                        parents[otherNode] = minNode;                           //set parent of the node with best distance

                        priorityQueue = new SortedSet<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => time[f].CompareTo(time[s]))); //reorder queue
                    }
                }
            }

            return time;
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
