namespace _02._Topological_Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependancies;
        private static List<string> sorted;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            ReadGraph(nodes);
            GetDependancies(graph);
            sorted = new List<string>();

            while (dependancies.Count > 0)
            {
                var nodeToRemove = dependancies.FirstOrDefault(x => x.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                sorted.Add(nodeToRemove);
                dependancies.Remove(nodeToRemove);

                foreach (var child in graph[nodeToRemove])
                {
                    dependancies[child]--;
                }
            }

            Console.WriteLine(dependancies.Count == 0 ?
                $"Topological sorting: {string.Join(", ", sorted)}" :
                "Invalid topological sorting");
        }

        private static void GetDependancies(Dictionary<string, List<string>> myGraph)
        {
            dependancies = new Dictionary<string, int>();

            foreach (var kVP in myGraph)
            {
                var node = kVP.Key;
                var children = kVP.Value;

                if (!dependancies.ContainsKey(node))
                {
                    dependancies.Add(node, 0);
                }

                foreach (var child in children)
                {
                    if (!dependancies.ContainsKey(child))
                    {
                        dependancies.Add(child, 1);
                    }
                    else
                    {
                        dependancies[child]++;
                    }
                }
            }
        }

        private static void ReadGraph(int nodes)
        {
            graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < nodes; i++)
            {
                string[] nodesInfo = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToArray();

                string node = nodesInfo[0];

                if (nodesInfo.Length == 1)
                {
                    graph[node] = new List<string>();
                }
                else
                {
                    List<string> child = nodesInfo[1]
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList();

                    graph[node] = child;
                }
            }
        }
    }
}