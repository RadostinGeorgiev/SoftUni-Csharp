namespace _01._Food_Programme
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Time { get; set; }
        public override string ToString()                                          //Weight
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
            int zones = int.Parse(Console.ReadLine());                      //nodes
            int roads = int.Parse(Console.ReadLine());                      //edges
            int[] path = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int start = path[0];                                             //startNode
            int destination = path[1];                                       //endNode

            Graph graph = new Graph(roads);
            graph = ReadEdgesGraphFromConsole(graph);

            var times = Dijkstra(graph, start, destination);

            Console.WriteLine(string.Join(" ", GetPath(destination)));
            Console.WriteLine(times[destination]);
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                var edgeData = Console.ReadLine()
                                        .Split()
                                        .Select(int.Parse)
                                        .ToArray();

                int start = edgeData[0];
                int end = edgeData[1];

                var edge = new Edge
                {
                    First = start,
                    Second = end,
                    Time = edgeData[2],
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
        private static double[] Dijkstra(Graph graph, int startNode, int endNode)
        {
            double[] time = new double[graph.Edges.Keys.Max() + 1];
            Array.Fill(time, double.PositiveInfinity);              //init all distances with positive infinity

            time[startNode] = 0;

            parents = new int[graph.Edges.Keys.Max() + 1];
            Array.Fill(parents, -1);

            //priority queue holding nodes ordered by distance d[]
            var priorityQueue = new SortedSet<int>(
                Comparer<int>.Create((f, s) => time[f].CompareTo(time[s])));
            priorityQueue.Add(startNode);                                 //add start node to queue

            while (priorityQueue.Count > 0)
            {
                int minNode = priorityQueue.First();                           //dequeue the smallest node from Q
                priorityQueue.Remove(minNode);

                if (double.IsPositiveInfinity(time[minNode]))                //we have a node without available path
                {
                    break;
                }

                if (minNode == endNode)                                        //if we have known end node
                {
                    break;
                }

                foreach (var edge in graph.Edges[minNode])
                {
                    int otherNode = edge.First == minNode                       //get the child of current node - node from edge, not included in visited part of graph
                        ? edge.Second
                        : edge.First;

                    if (double.IsPositiveInfinity(time[otherNode]))      //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newDistance = time[minNode] + edge.Time;    //calculate new distance to current node

                    if (newDistance < time[otherNode])
                    {
                        time[otherNode] = newDistance;                     //update distance with shortest value
                        parents[otherNode] = minNode;                          //set parent of the node with best distance

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
