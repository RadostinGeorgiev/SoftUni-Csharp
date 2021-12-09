namespace Bakery.Models.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BakedFoods.Contracts;
    using Contracts;
    using Drinks.Contracts;
    using static Utilities.Messages.ExceptionMessages;

    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            IsReserved = false;

            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price => 
            PricePerPerson * NumberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill() => 
            this.foodOrders.Sum(food => food.Price) + 
            this.drinkOrders.Sum(drink => drink.Price)  + 
            Price;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.numberOfPeople = 0;
            IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}")
              .AppendLine($"Type: {this.GetType().Name}")
              .AppendLine($"Capacity: {Capacity}")
              .AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }
    }
}