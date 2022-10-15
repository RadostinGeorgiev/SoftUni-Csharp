namespace _02._Maximum_Tasks_Assignment
{
    using System;
    using System.Collections.Generic;

    class Graph
    {
        public int VerticesCount;
        public int[,] nodes;
        public Graph(int verticesCount)
        {
            this.VerticesCount = verticesCount;
            this.nodes = new int[verticesCount, verticesCount];
        }
    }

    internal class Program
    {
        private static int people;
        private static int nodes;
        private static Graph graph;
        private static int[] parents;
        static void Main(string[] args)
        {
            people = int.Parse(Console.ReadLine());
            int tasks = int.Parse(Console.ReadLine());

            graph = CreateGraphFromConsole(people, tasks);
            PrintGraph(graph);
            parents = new int[nodes];
            Array.Fill(parents, -1);

            int source = 0;
            int destination = nodes - 1;

            ReconstructPath(source, destination);

            GetMaximumAssignment(people, tasks);
            //GetMaximumAssignmentBfs(source, destination);
            //Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void GetMaximumAssignment(int people, int tasks)
        {
            SortedSet<string> result = new SortedSet<string>();

            for (int task = people + 1; task <= people + tasks; task++)
            {
                for (int index = 0; index < graph.nodes.GetLength(1); index++)
                {
                    if (graph.nodes[task, index] > 0)
                    {
                        result.Add($"{(char)(index - 1 + 'A')}-{task - people}");
                    }
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, result));
        }
        private static void GetMaximumAssignmentBfs(int source, int destination)
        {
            SortedSet<string> result = new SortedSet<string>();
            bool[] visited = new bool[nodes];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(destination);
            visited[destination] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int child = 0; child < graph.nodes.GetLength(1); child++)
                {
                    if (!visited[child] && graph.nodes[node, child] == 1)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;

                        if (node != source && node != destination &&
                            child != source && child != destination)
                        {
                            result.Add($"{(char)(child - 1 + 'A')}-{node - people}");
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static Graph CreateGraphFromConsole(int people, int tasks)
        {
            nodes = people + tasks + 2;
            Graph graph = new Graph(nodes);
            //Graph => Source, People1, People2, .. PeopleN, Task1, Task2, ... TaskN, Destination
            //Graph => Source, Peoples, Tasks, Destination
            //Graph.nodes => Peoples + Tasks + 2

            for (int person = 1; person <= people; person++)
            {
                graph.nodes[0, person] = 1;
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                graph.nodes[task, nodes - 1] = 1;
            }

            for (int person = 1; person <= people; person++)
            {
                string peronTasks = Console.ReadLine();

                for (int task = 0; task < peronTasks.Length; task++)
                {
                    graph.nodes[person, people + task + 1] = peronTasks[task] == 'Y' ? 1 : 0;
                }
            }

            return graph;
        }
        private static bool Bfs(int source, int destination)
        {
            bool[] visited = new bool[nodes];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int child = 0; child < graph.nodes.GetLength(1); child++)
                {
                    if (!visited[child] && graph.nodes[node, child] == 1)
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parents[child] = node;
                    }
                }
            }

            return visited[destination];
        }
        private static void UpdateFlow(int source, int destination, int flow)
        {
            int node = destination;

            while (node != source)
            {
                int parent = parents[node];
                graph.nodes[parent, node] -= flow;
                graph.nodes[node, parent] += flow;
                node = parent;
            }
        }

        private static void ReconstructPath(int source, int destination)
        {
            int maxFlow = 0;

            while (Bfs(source, destination))
            {
                UpdateFlow(source, destination, 1);
                maxFlow += 1;
            }
        }

        public static void PrintGraph(Graph graph)
        {
            for (int row = 0; row < graph.nodes.GetLength(0); row++)
            {
                for (int col = 0; col < graph.nodes.GetLength(1); col++)
                {
                    var result = graph.nodes[row, col] == 1 ? 'Y' : 'N';
                    Console.Write($"{result} ");
                }
                Console.WriteLine();
            }
        }
    }
}
