using System;

namespace _05.Football_Team_Generator.Models
{
    public class Stats
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                CheckStatValue(value, nameof(this.Endurance));

                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            private set
            {
                CheckStatValue(value, nameof(this.Sprint));

                sprint = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                CheckStatValue(value, nameof(this.Dribble));

                dribble = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                CheckStatValue(value, nameof(this.Passing));

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting;
            private set
            {
                CheckStatValue(value, nameof(this.Shooting));

                shooting = value;
            }
        }
        public double AverageStats => (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;

        private static void CheckStatValue(int value, string stat)
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidStatMessage, stat, MinValue, MaxValue));
            }
        }

    }
}