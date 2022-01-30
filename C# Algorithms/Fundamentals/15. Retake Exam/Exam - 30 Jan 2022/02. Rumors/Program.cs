namespace _02._Rumors
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parents;

        static void Main(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine());
            int connections = int.Parse(Console.ReadLine());

            graph = new List<int>[peoples + 1];
            ReadGraph(peoples, connections);

            int startPerson = int.Parse(Console.ReadLine());

            for (int person = 1; person <= peoples; person++)
            {
                if (person == startPerson) continue;

                int endPerson = person;

                visited = new bool[peoples + 1];
                parents = new int[peoples + 1];
                Array.Fill(parents, -1);

                BFS(startPerson, endPerson);
            }
        }

        private static void BFS(int start, int destination)
        {
            var queue = new Queue<int>();

            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    var path = GetPath(destination);
                    Console.WriteLine($"{start} -> {destination} ({path.Count - 1})");
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parents[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int destination)
        {
            Stack<int> result = new Stack<int>();

            var node = destination;

            while (node != -1)
            {
                result.Push(node);
                node = parents[node];
            }

            return result;
        }

        private static void ReadGraph(int nodes, int edges)
        {
            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int edge = 1; edge <= edges; edge++)
            {
                string[] currentEdge = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int destination = int.Parse(currentEdge[0]);
                int source = int.Parse(currentEdge[1]);

                if (!graph[source].Contains(destination))
                {
                    graph[source].Add(destination);
                }

                if (!graph[destination].Contains(source))
                {
                    graph[destination].Add(source);
                }
            }
        }
    }
}