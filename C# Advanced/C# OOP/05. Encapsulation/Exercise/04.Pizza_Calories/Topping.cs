using System;
using System.Collections.Generic;

namespace _04.Pizza_Calories
{
    public class Topping
    {
        private static string InvalidTypeMessage = "Cannot place {0} on top of your pizza.";
        private static string InvalidWeightMessage = "{0} weight should be in the range [1..50].";
        
        private const int CaloriesBase = 2;
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;

        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private HashSet<string> ToppingType = new HashSet<string>()
        {
            "meat",
            "veggies",
            "cheese",
            "sauce"
        };

        private string typeOfTopping;
        private int weight;

        public Topping(string typeOfTopping, int weight)
        {
            TypeOfTopping = typeOfTopping;
            Weight = weight;
        }

        public string TypeOfTopping
        {
            get => typeOfTopping;

            set
            {
                if (!ToppingType.Contains(value.ToLower()))
                {
                    throw new ArgumentException(String.Format(InvalidTypeMessage, value.ToString()));
                }

                typeOfTopping = value;
            }
        }

        public int Weight
        {
            get => weight;

            set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException(String.Format(InvalidWeightMessage, this.TypeOfTopping));
                }

                weight = value;
            }
        }

        public double Calories => this.GetCalories();

        private double GetCalories()
        {
            double calories = CaloriesBase;

            switch (this.typeOfTopping.ToLower())
            {
                case "meat":
                    calories *= MeatModifier;
                    break;
                case "veggies":
                    calories *= VeggiesModifier;
                    break;
                case "cheese":
                    calories *= CheeseModifier;
                    break;
                case "sauce":
                    calories *= SauceModifier;
                    break;
            }

            return calories * this.weight;
        }

    }
}