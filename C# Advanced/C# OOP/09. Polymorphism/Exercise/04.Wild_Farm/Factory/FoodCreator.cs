using System;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Factory
{
    public class FoodCreator : FCreator
    {
        private const string MissingFoodMessage = "Missing food";
        public override IFood FoodFactory(string[] foodArgs)
        {
            IFood food;
            string type = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            return food = type switch
            {
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seeds" => new Seeds(quantity),
                "Vegetable" => new Vegetable(quantity),
                _ => throw new ArgumentException(MissingFoodMessage)
            };
        }
    }
}