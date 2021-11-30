using System;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private const int OxygenDecreasement = 10;

        private string name;
        private double oxygen;

        private Astronaut()
        {
            Bag = new Backpack();
        }

        protected Astronaut(string name, double oxygen)
        : this()
        {
            Name = name;
            Oxygen = oxygen;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        (ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        (ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => Oxygen > 0;
        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            Oxygen -= OxygenDecreasement;

            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");

            sb.AppendLine(this.Bag.Items.Count == 0
                ? "Bag items: none"
                : $"Bag items: {string.Join(", ", this.Bag.Items)}");

            return sb.ToString().Trim();
        }
    }
}