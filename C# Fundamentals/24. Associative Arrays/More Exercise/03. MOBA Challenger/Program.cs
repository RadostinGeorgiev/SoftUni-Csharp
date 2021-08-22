using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "Season end")
            {
                if (input.Contains("->"))
                {
                    string[] info = input.Split(" -> ");
                    string player = info[0];
                    string position = info[1];
                    int skill = int.Parse(info[2]);

                    if (players.ContainsKey(player))
                    {
                        if (players[player].ContainsKey(position))
                        {
                            if (players[player][position] < skill)
                            {
                                players[player][position] = skill;
                            }
                        }
                        else
                        {
                            players[player].Add(position, skill);
                        }
                    }
                    else
                    {
                        players.Add(player, new Dictionary<string, int>());
                        players[player].Add(position, skill);
                    }
                }
                else
                {
                    string[] info = input.Split(" vs ");
                    string playerFirst = info[0];
                    string playerSecond = info[1];

                    if (players.ContainsKey(playerFirst) && players.ContainsKey(playerSecond))
                    {
                        foreach (var keyValuePair in players[playerFirst])
                        {
                            string position = keyValuePair.Key;
                            int skills = keyValuePair.Value;

                            if (players[playerSecond].ContainsKey(position))
                            {
                                if (players[playerFirst][position] > players[playerSecond][position])
                                {
                                    players[playerSecond].Remove(position);
                                }
                                else if (players[playerFirst][position] < players[playerSecond][position])
                                {
                                    players[playerFirst].Remove(position);
                                }
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Dictionary<string, int> totalPoints = new Dictionary<string, int>();
            foreach (var keyValuePair in players)
            {
                totalPoints[keyValuePair.Key] = players[keyValuePair.Key].Values.Sum();
            }

            foreach (var keyValuePair in totalPoints
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                if (keyValuePair.Value > 0)
                {
                    Console.WriteLine($"{keyValuePair.Key}: {keyValuePair.Value} skill");
                    foreach (var valuePair in players[keyValuePair.Key]
                        .OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key))
                    {
                        Console.WriteLine($"- {valuePair.Key} <::> {valuePair.Value}");
                    }
                }
            }
        }
    }
}
