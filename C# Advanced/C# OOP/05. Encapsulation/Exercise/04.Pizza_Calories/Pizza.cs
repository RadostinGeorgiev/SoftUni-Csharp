using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Pizza_Calories
{
    public class Pizza
    {
        private const string InvalidNameMessage = "Pizza name should be between 1 and 15 symbols.";
        private const string InvalidToppingsNumberMessage = "Number of toppings should be in range [0..10].";

        private const int MinNameLength = 1;
        private const int MaxNameLength = 15;
        private const int MaxToppingNumber = 10;

        private string name;
        private Dough doughs;
        private List<Topping> toppings;

        public Pizza()
        {
            toppings = new List<Topping>();
        }
        public Pizza(string name) 
            : this()
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentException(InvalidNameMessage);
                }
                this.name = value;
            }
        }


        public Dough Doughs
        {
            get => doughs;
            set => this.doughs = value;
        }


        public int NumberOfToppings => toppings.Count;
        public double TotalCalories
        {
            get { return Doughs.Calories + toppings.Sum(x => x.Calories); }
        }

        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings == MaxToppingNumber)
            {
                throw new InvalidOperationException(InvalidToppingsNumberMessage);
            }

            toppings.Add(topping);
        }

        public override string ToString()
        {
            return $"{Name} - {TotalCalories:F2} Calories.";
        }
    }
}