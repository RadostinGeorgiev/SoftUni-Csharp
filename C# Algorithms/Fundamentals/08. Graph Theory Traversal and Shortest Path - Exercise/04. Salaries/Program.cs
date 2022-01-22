namespace _04._Salaries
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static List<int>[] graph;
        private static Dictionary<int, int> visited;

        static void Main(string[] args)
        {
            int employees = int.Parse(Console.ReadLine());

            graph = new List<int>[employees];
            visited = new Dictionary<int, int>();

            ReadEmployees(employees);

            var totalSalaries = 0;

            for (var node = 0; node < graph.Length; node++)
            {
                totalSalaries += DFS(node);
            }

            Console.WriteLine(totalSalaries);
        }

        private static int DFS(int node)
        {
            if (visited.ContainsKey(node))
            {
                return visited[node];
            }

            var salary = 0;

            if (graph[node].Count == 0)
            {
                salary = 1;
            }
            else
            {
                foreach (var child in graph[node])
                {
                    salary += DFS(child);
                }
            }

            visited[node] = salary;
            return salary;
        }

        private static void ReadEmployees(int employees)
        {
            for (int i = 0; i < employees; i++)
            {
                var currentEmployee = Console.ReadLine().ToCharArray();
                graph[i] = new List<int>();

                for (int j = 0; j < employees; j++)
                {
                    if (currentEmployee[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }
        }
    }
}