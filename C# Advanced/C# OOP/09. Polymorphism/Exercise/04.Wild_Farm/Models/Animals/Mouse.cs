using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double WeightIncreasing = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncreasingCoeff => WeightIncreasing;
        public override ICollection<Type> EatenFoods => new List<Type> {typeof(Vegetable),  typeof(Fruit)};

        public override string ProduceSound() => "Squeak";
    }
}