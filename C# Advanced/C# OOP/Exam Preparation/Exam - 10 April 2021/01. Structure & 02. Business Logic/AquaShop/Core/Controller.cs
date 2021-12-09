namespace AquaShop.Core
{
    using Contracts;
    using Models.Aquariums;
    using Models.Aquariums.Contracts;
    using Models.Decorations;
    using Models.Decorations.Contracts;
    using Models.Fish;
    using Models.Fish.Contracts;
    using Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using static Utilities.Messages.ExceptionMessages;
    using static Utilities.Messages.OutputMessages;

    public class Controller : IController
    {
        private readonly DecorationRepository _decorations;
        private readonly ICollection<IAquarium> _aquariums;

        public Controller()
        {
            this._decorations = new DecorationRepository();
            this._aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = aquariumType switch
            {
                "FreshwaterAquarium" => new FreshwaterAquarium(aquariumName),
                "SaltwaterAquarium" => new SaltwaterAquarium(aquariumName),
                _ => throw new InvalidOperationException(InvalidAquariumType)
            };

            this._aquariums.Add(aquarium);

            return string.Format(SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = decorationType switch
            {
                "Ornament" => new Ornament(),
                "Plant" => new Plant(),
                _ => throw new InvalidOperationException(InvalidDecorationType)
            };

            this._decorations.Add(decoration);

            return string.Format(SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this._decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(InexistentDecoration, decorationType));
            }

            IAquarium aquarium = this._aquariums.FirstOrDefault(a => a.Name == aquariumName);

            aquarium?.AddDecoration(decoration);
            this._decorations.Remove(decoration);

            return string.Format(EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = this._aquariums.FirstOrDefault(a => a.Name == aquariumName);
            var aquariumType = aquarium?.GetType().Name;

            IFish fish;
            switch (fishType)
            {
                case nameof(FreshwaterFish):
                    if (aquariumType == nameof(FreshwaterAquarium))
                    {
                        fish = new FreshwaterFish(fishName, fishSpecies, price);
                    }
                    else
                    {
                        return UnsuitableWater;
                    }
                    break;

                case nameof(SaltwaterFish):
                    if (aquariumType == nameof(SaltwaterAquarium))
                    {
                        fish = new SaltwaterFish(fishName, fishSpecies, price);
                    }
                    else
                    {
                        return UnsuitableWater;
                    }
                    break;

                default:
                    throw new InvalidOperationException(InvalidFishType);
            }

            aquarium.AddFish(fish);

            return string.Format(EntityAddedToAquarium, fishType, aquariumName);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = this._aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Feed();

            return string.Format(FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = this._aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal value = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(AquariumValue, aquariumName, value);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in this._aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}