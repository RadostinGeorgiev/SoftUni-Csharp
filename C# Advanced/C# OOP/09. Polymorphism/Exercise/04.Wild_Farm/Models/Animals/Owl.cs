using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private const double WeightIncreasing = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightIncreasingCoeff => WeightIncreasing;
        public override ICollection<Type> EatenFoods => new List<Type> { typeof(Meat) };

        public override string ProduceSound() => "Hoot Hoot";
    }
}