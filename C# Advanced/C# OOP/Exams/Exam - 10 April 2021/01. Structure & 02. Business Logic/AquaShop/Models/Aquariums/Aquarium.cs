namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Decorations.Contracts;
    using Fish.Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Aquarium : IAquarium
    {
        private string _name;

        protected Aquarium(string name, int capacity)
        {
            this._name = name;
            Capacity = capacity;

            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }

        public string Name
        {
            get => this._name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidAquariumName);
                }

                this._name = value;
            }
        }

        public int Capacity { get; }

        public int Comfort =>
            Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddFish(IFish fish)
        {
            if (Capacity == Fish.Count)
            {
                throw new InvalidOperationException(NotEnoughCapacity);
            }

            Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish) => Fish.Remove(fish);

        public void AddDecoration(IDecoration decoration) =>
            Decorations.Add(decoration);

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            sb.AppendLine($"Fish: {(Fish.Count == 0 ? "none" : string.Join(", ", Fish.Select(f => f.Name)))}");

            sb.AppendLine($"Decorations: {Decorations.Count}")
            .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().Trim();
        }
    }
}