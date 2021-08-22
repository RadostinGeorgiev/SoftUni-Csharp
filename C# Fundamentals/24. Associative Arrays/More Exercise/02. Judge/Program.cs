using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contests = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();

            while (input != "no more time")
            {
                string[] info = input.Split(" -> ");
                string username = info[0];
                string contest = info[1];
                int points = int.Parse(info[2]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest].ContainsKey(username))
                    {
                        if (contests[contest][username] < points)
                        {
                            contests[contest][username] = points;
                        }
                    }
                    else
                    {
                        contests[contest].Add(username, points);
                    }

                }
                else
                {
                    contests.Add(contest, new Dictionary<string, int>());
                    contests[contest].Add(username, points);
                }

                input = Console.ReadLine();
            }

            foreach (var keyValuePair in contests)
            {
                Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value.Count} participants");
                int number = 1;
                foreach (var u in keyValuePair.Value
                    .OrderByDescending(x=>x.Value)
                    .ThenBy(x=>x.Key))
                {
                    Console.WriteLine($"{number}. {u.Key} <::> {u.Value}");
                    number++;
                }
            }

            Console.WriteLine("Individual standings:");
            Dictionary<string, int> users = new Dictionary<string, int>();

            foreach (var keyValuePair in contests)
            {
                foreach (var valuePair in keyValuePair.Value)
                {
                    if (users.ContainsKey(valuePair.Key))
                    {
                        users[valuePair.Key] += valuePair.Value;
                    }
                    else
                    {
                        users.Add(valuePair.Key, valuePair.Value);
                    }
                }
            }

            int counter = 1;
            foreach (var keyValuePair in users
                .OrderByDescending(x=>x.Value)
                .ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{counter}. {keyValuePair.Key} -> {keyValuePair.Value}");
                counter++;
            }
        }
    }
}
