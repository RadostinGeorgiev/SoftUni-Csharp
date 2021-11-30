namespace AquaShop.Models.Fish
{
    using System;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Fish : IFish
    {
        private string _name;
        private string _species;
        private decimal _price;

        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }

        public string Name
        {
            get => this._name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidFishName);
                }
                
                this._name = value;
            }
        }

        public string Species
        {
            get => this._species;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidFishSpecies);
                }

                this._species = value;
            }
        }

        public int Size { get; protected set; }

        public decimal Price
        {
            get => this._price;

            private set
            {
                if (value < 0 )
                {
                    throw new ArgumentException(InvalidFishPrice);
                }
                
                this._price = value;
            }
        }

        public abstract void Eat();
    }
}