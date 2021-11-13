using System;
using System.Collections.Generic;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string MissingFoodMessage = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract double WeightIncreasingCoeff { get; }
        public abstract ICollection<Type> EatenFoods { get; }

        public abstract string ProduceSound();

        public void Feed(IFood food)
        {
            if (!EatenFoods.Contains(food.GetType()))
            {
                throw new ArgumentException(String.Format(MissingFoodMessage, GetType().Name, food.GetType().Name));
            }

            FoodEaten += food.Quantity;
            Weight += WeightIncreasingCoeff * food.Quantity;
        }
    }
}