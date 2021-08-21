using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>(teamsCount);
            string user = "";
            string teamName = "";

            for (int i = 1; i <= teamsCount; i++)
            {
                var command = Console.ReadLine()
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                user = command[0];
                teamName = command[1];

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(x => x.Creator == user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                else
                {
                    Team team = new Team(teamName, user);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {user}!");
                }
            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                var command = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                user = command[0];
                teamName = command[1];

                if (!teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(x => x.Members.Contains(user) || x.Creator == user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    teams.First(x => x.TeamName == teamName).Members.Add(user);
                }

                input = Console.ReadLine();
            }

            var finalTeam = teams
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .ToList();

            StringBuilder output = new StringBuilder();

            foreach (var team in finalTeam)
            {
                output.AppendLine(team.TeamName);
                output.AppendLine("- " + team.Creator);
                foreach (var item in team.Members.OrderBy(x => x))
                {
                    output.AppendLine("-- " + item);
                }
                Console.WriteLine(output.ToString().TrimEnd());
                output.Clear();
            }

            var disbandedTeams = teams
                .Where(x => x.Members.Count == 0)
                .OrderBy(x => x.TeamName)
                .ToList();

            Console.WriteLine($"Teams to disband:");
            foreach (var team in disbandedTeams)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }

    class Team
    {
        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members;

        public Team(string teamName, string creator)
        {
            TeamName = teamName;
            Creator = creator;
            Members = new List<string>();
        }
    }
}
