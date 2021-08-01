using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] info = input.Split(':');
                string contest = info[0];
                string password = info[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }

                input = Console.ReadLine();
            }

            SortedDictionary<string, Dictionary<string, int>> submissions = new SortedDictionary<string, Dictionary<string, int>>();

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] info = input.Split("=>");
                string contest = info[0];
                string password = info[1];
                string username = info[2];
                int points = int.Parse(info[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (submissions.ContainsKey(username))
                    {
                        if (submissions[username].ContainsKey(contest))
                        {
                            if (submissions[username][contest] < points)
                            {
                                submissions[username][contest] = points;
                            }
                        }
                        else
                        {
                            submissions[username].Add(contest, points);
                        }
                    }
                    else
                    {
                        submissions.Add(username, new Dictionary<string, int>());
                        submissions[username].Add(contest, points);
                    }
                }

                input = Console.ReadLine();
            }

            string bestUser = string.Empty;
            int bestPoints = 0;

            foreach (var keyValuePair in submissions)
            {
                if (keyValuePair.Value.Values.Sum() > bestPoints)
                {
                    bestPoints = keyValuePair.Value.Values.Sum();
                    bestUser = keyValuePair.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestUser} with total {bestPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var keyValuePair in submissions)
            {
                Console.WriteLine(keyValuePair.Key);
                foreach (var valuePair in keyValuePair.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {valuePair.Key} -> {valuePair.Value}");
                }
            }
        }
    }
}
