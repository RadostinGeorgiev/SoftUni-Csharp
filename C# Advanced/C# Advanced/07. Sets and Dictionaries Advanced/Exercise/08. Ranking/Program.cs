using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] info = input.Split(':');
                string contest = info[0];
                string password = info[1];

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, password);
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] info = input.Split("=>");
                string contest = info[0];
                string password = info[1];
                string username = info[2];
                int points = int.Parse(info[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if (users[username].ContainsKey(contest))
                    {
                        if (points > users[username][contest])
                        {
                            users[username][contest] = points;
                        }
                    }
                    else
                    {
                        users[username].Add(contest, points);
                    }
                }
            }

            var bestUser = users
                .OrderByDescending(x => x.Value.Values.Sum())
                .First(); 
            Console.WriteLine($"Best candidate is {bestUser.Key} with total {bestUser.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users.OrderBy(x=>x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}