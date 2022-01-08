using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDays = int.Parse(Console.ReadLine());
            int weightFood = int.Parse(Console.ReadLine());
            double weightFoodDog = double.Parse(Console.ReadLine());
            double weightFoodCat = double.Parse(Console.ReadLine());
            double weightFoodTurtle = double.Parse(Console.ReadLine()) / 1000;

            double totalFood = numDays * (weightFoodDog + weightFoodCat + weightFoodTurtle);
            double restFood = weightFood - totalFood;

            Console.WriteLine(restFood >= 0
                ? $"{Math.Floor(restFood)} kilos of food left."
                : $"{Math.Ceiling(Math.Abs(restFood))} more kilos of food are needed.");
        }
    }
}