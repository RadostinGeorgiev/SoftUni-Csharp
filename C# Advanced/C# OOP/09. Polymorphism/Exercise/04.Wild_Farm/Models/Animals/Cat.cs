using System;
using System.Collections.Generic;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        private const double WeightIncreasing = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightIncreasingCoeff => WeightIncreasing;
        public override ICollection<Type> EatenFoods => new List<Type> { typeof(Meat), typeof(Vegetable) };

        public override string ProduceSound() => "Meow";
    }
}