using System;
using System.Collections.Generic;
using WildFarm.Factory;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AnimalCreator animalCreator = new AnimalCreator();
            FoodCreator foodCreator = new FoodCreator();
            ICollection<IAnimal> animals = new List<IAnimal>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] animalArgs = input
                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    IAnimal animal = animalCreator.AnimalFactory(animalArgs);
                    Console.WriteLine(animal.ProduceSound());

                    string[] foodArgs = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    IFood food = foodCreator.FoodFactory(foodArgs);

                    animal.Feed(food);
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}