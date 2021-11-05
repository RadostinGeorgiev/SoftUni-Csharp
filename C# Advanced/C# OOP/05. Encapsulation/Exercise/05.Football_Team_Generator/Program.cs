using System;
using System.Collections.Generic;
using System.Linq;

using _05.Football_Team_Generator.Models;

namespace _05.Football_Team_Generator
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Team> teams = new HashSet<Team>();
            Team team = null;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandArgs = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0];
                string teamName = commandArgs[1];

                try
                {
                    string playerName;
                    switch (command)
                    {
                        case "Team":
                            team = new Team(teamName);
                            teams.Add(team);
                            break;

                        case "Add":
                            team = ValidateTeam(teams, teamName);

                            playerName = commandArgs[2];
                            int endurance = int.Parse(commandArgs[3]);
                            int sprint = int.Parse(commandArgs[4]);
                            int dribble = int.Parse(commandArgs[5]);
                            int passing = int.Parse(commandArgs[6]);
                            int shooting = int.Parse(commandArgs[7]);

                            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
                            Player player = new Player(playerName, stats);
                            team.AddPlayer(player);
                            break;

                        case "Remove":
                            playerName = commandArgs[2];

                            team = ValidateTeam(teams, teamName);
                            team.RemovePlayer(playerName);
                            break;

                        case "Rating":
                            team = ValidateTeam(teams, teamName);
                            Console.WriteLine(team.ToString());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Team ValidateTeam(HashSet<Team> teams, string teamName)
        {
            Team team = teams.FirstOrDefault(x => x.Name == teamName);
            return team == null
                ? throw new InvalidOperationException(string.Format(ExceptionMessages.MissingTeamMessage, teamName))
                : team;
        }
    }
}