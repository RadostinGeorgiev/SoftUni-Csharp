using System;
using System.Collections.Generic;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Interfaces
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight { get; }
        public int FoodEaten { get; }
        public double WeightIncreasingCoeff { get; }
        public ICollection<Type> EatenFoods { get; }

        string ProduceSound();
        public void Feed(IFood food);
    }
}