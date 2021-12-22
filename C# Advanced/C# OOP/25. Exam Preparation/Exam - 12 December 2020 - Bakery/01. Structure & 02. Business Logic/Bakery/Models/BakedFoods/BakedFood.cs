namespace Bakery.Models.BakedFoods
{
    using System;
    using Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;

        protected BakedFood(string name, int portion, decimal price)
        {
            Name = name;
            Portion = portion;
            Price = price;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidName);
                }

                this.name = value;
            }
        }

        public int Portion
        {
            get => this.portion;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidPortion);
                }
                
                this.portion = value;
            }
        }

        public decimal Price
        {
            get => this.price;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidPrice);
                }
                
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{Name}: {Portion}g - {Price:f2}";
        }
    }
}