using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        private const double WeightIncreasing = 0.40;

        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightIncreasingCoeff => WeightIncreasing;
        public override ICollection<Type> EatenFoods => new List<Type> { typeof(Meat) };

        public override string ProduceSound() => "Woof!";
    }
}