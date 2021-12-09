using System;
using System.Collections.Generic;
using SpaceStation.Models.Planets.Contracts;
using static SpaceStation.Utilities.Messages.ExceptionMessages;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        public Planet(string name)
        {
            Name = name;
            Items = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(InvalidPlanetName);
                }

                this.name = value;
            }
        }

         public ICollection<string> Items { get; }
   }
}