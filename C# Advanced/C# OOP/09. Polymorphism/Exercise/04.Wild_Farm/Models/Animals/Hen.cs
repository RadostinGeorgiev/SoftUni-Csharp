using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double WeightIncreasing = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightIncreasingCoeff => WeightIncreasing;
        public override ICollection<Type> EatenFoods => new List<Type> { typeof(Meat), typeof(Vegetable), typeof(Fruit), typeof(Seeds)};

        public override string ProduceSound() => "Cluck";
    }
}