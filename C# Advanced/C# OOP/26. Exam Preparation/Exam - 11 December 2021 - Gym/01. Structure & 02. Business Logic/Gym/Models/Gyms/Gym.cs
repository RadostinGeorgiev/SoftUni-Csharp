namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Athletes.Contracts;
    using Contracts;
    using Equipment.Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Gym : IGym
    {
        private string name;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Equipment = new List<IEquipment>();
            Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(InvalidGymName);
                }

                this.name = value;
            }
        }

        public int Capacity { get; }

        public double EquipmentWeight =>
            Equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes { get; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count == Capacity)
            {
                throw new InvalidOperationException(NotEnoughSize);
            }

            Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete) =>
            Athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            if (Athletes.Count <= 0) return;

            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {this.GetType().Name}:")
              .AppendLine(Athletes.Count == 0 ? "Athletes: No athletes" : $"Athletes: {string.Join(", ", Athletes)}")
              .AppendLine($"Equipment total count: {Equipment.Count}")
              .AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return sb.ToString().TrimEnd();
        }
    }
}