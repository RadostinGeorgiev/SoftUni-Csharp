using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Football_Team_Generator.Models
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;

        public Team()
        {
            players = new List<Player>();
        }

        public Team(string name) 
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameMessage);
                }

                name = value;
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.players.Any(x=>x.Name == playerName))
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidPlayerMessage, playerName, this.Name));
            }

            players.RemoveAll(x=>x.Name == playerName);
        }
        public int Rating => players.Count > 0 ? (int)Math.Round(players.Average(x => x.SkillLevel)) : 0;

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}