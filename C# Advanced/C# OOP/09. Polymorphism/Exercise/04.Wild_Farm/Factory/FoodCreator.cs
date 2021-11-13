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
            string foodType = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);

            IFood food = foodType switch
            {
                "Fruit" => new Fruit(quantity),
                "Meat" => new Meat(quantity),
                "Seed" => new Seeds(quantity),
                "Vegetable" => new Vegetable(quantity),
                _ => throw new ArgumentException(MissingFoodMessage)
            };

            return food;
        }
    }
}