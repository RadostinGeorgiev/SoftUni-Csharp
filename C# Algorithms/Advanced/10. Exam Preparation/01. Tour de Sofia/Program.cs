namespace _01._Tour_de_Sofia
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Edge
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return string.Format($"({this.From} -> {this.To}) - {this.Weight}");
        }
    }

    class Graph
    {
        public int VerticesCount { get; set; }
        public int EdgesCount { get; set; }
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
        static int[] parents;

        static void Main(string[] args)
        {
            int junctions = int.Parse(Console.ReadLine());
            int streets = int.Parse(Console.ReadLine());
            int startNode = int.Parse(Console.ReadLine());

            Graph graph = new Graph(junctions, streets);
            graph = ReadEdgesGraphFromConsole(graph);

            double[] distances = Dijkstra(graph, startNode, startNode);

            if (double.IsPositiveInfinity(distances[startNode]))
            {
                List<int> visitedNodes = new List<int> { startNode };

                distances
                   .Select((x, i) => !double.IsInfinity(x) ? i : -1)
                   .Where(i => i != -1)
                   .ToList()
                   .ForEach(i => visitedNodes.Add(i));
                Console.WriteLine(visitedNodes.Count);

                //Console.Write("There is no route for Pierre. Junctions that can be reached: ");
                //Console.WriteLine(string.Join(", ", visitedNodes));
            }
            else
            {
                Console.WriteLine(distances[startNode]);

                //Console.Write($"The shortest route starting at 0 is: {startNode} -> ");
                //Console.WriteLine(string.Join(" -> ", GetPath(startNode)));
            }
        }

        private static Graph ReadEdgesGraphFromConsole(Graph graph)
        {
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                int[] edgeData = Console.ReadLine()
                                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(int.Parse)
                                        .ToArray();

                int firstNode = edgeData[0];
                int secondNode = edgeData[1];

                Edge edge = new Edge
                {
                    From = firstNode,
                    To = secondNode,
                    Weight = edgeData[2],
                };

                if (!graph.Edges.ContainsKey(firstNode))
                {
                    graph.Edges.Add(firstNode, new List<Edge>());
                }

                if (!graph.Edges.ContainsKey(secondNode))
                {
                    graph.Edges.Add(secondNode, new List<Edge>());
                }

                graph.Edges[firstNode].Add(edge);
            }

            return graph;
        }

        private static double[] Dijkstra(Graph graph, int startNode, int endNode)
        {
            double[] distance = new double[graph.Edges.Keys.Max() + 1];
            Array.Fill(distance, double.PositiveInfinity);               //init all distances with positive infinity

            parents = new int[graph.Edges.Keys.Max() + 1];
            Array.Fill(parents, -1);

            //priority queue holding nodes ordered by distance d[]
            SortedSet<int> priorityQueue = new SortedSet<int>(
                Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));

            foreach (Edge child in graph.Edges[startNode])
            {
                distance[child.To] = child.Weight;
                priorityQueue.Add(child.To);                                   //add start node to queue   
            }

            int minNode = -1;

            while (priorityQueue.Count != 0)
            {
                minNode = priorityQueue.First();                                    //dequeue the smallest node from Q
                priorityQueue.Remove(minNode);

                if (double.IsPositiveInfinity(distance[minNode]))                 //we have a node without available path
                {
                    break;
                }

                if (minNode == endNode)                                             //if we have known end node
                {
                    break;
                }

                foreach (Edge edge in graph.Edges[minNode])
                {
                    int otherNode = edge.From == minNode                            //get the child of current node - node from edge, not included in visited part of graph
                            ? edge.To
                            : edge.From;

                    if (double.IsPositiveInfinity(distance[otherNode]))           //if new node is not visited 
                    {
                        priorityQueue.Add(otherNode);
                    }

                    double newDistance = distance[minNode] + edge.Weight;           //calculate new distance to current node

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;                          //update distance with shortest value
                        parents[otherNode] = minNode;                               //set parent of the node with best distance

                        priorityQueue = new SortedSet<int>(priorityQueue,
                            Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s]))); //reorder queue
                    }
                }
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