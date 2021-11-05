using System;

namespace _05.Football_Team_Generator.Models
{
    public class Player
    {
        private string name;
        public Player(string name, Stats stats)
        {
            Name = name;
            Stats = stats;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameMessage);
                }

                name = value;
            }
        }

        public Stats Stats { get; set; }

        public double SkillLevel => this.Stats.AverageStats;
    }
}