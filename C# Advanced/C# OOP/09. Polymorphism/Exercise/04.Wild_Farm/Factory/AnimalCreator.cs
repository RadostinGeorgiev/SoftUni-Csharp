using System;
using WildFarm.Models.Animals;
using WildFarm.Models.Animals.Interfaces;

namespace WildFarm.Factory
{
    public class AnimalCreator : ACreateor
    {
        private const string MissingAnimalMessage = "Missing animal";
        public override IAnimal AnimalFactory(string[] animalArgs)
        {
            IAnimal animal;
            string type = animalArgs[0];
            string name = animalArgs[1];
            double weight = double.Parse(animalArgs[2]);

            double wingSize = type switch
            {
                "Owl" => double.Parse(animalArgs[3]),
                "Hen" => double.Parse(animalArgs[3]),
                _ => 0
            };
            string livingRegion = type switch
            {
                "Dog" => animalArgs[3],
                "Mouse" => animalArgs[3],
                "Cat" => animalArgs[3],
                "Tiger" => animalArgs[3],
                _ => null
            };
            string breed = type switch
            {
                "Cat" => animalArgs[4],
                "Tiger" => animalArgs[4],
                _ => null
            };

            return animal = type switch
            {
                "Owl" => new Owl(name, weight, wingSize),
                "Hen" => new Hen(name, weight, wingSize),
                "Dog" => new Dog(name, weight, livingRegion),
                "Mouse" => new Mouse(name, weight, livingRegion),
                "Cat" => new Cat(name, weight, livingRegion, breed),
                "Tiger" => new Tiger(name, weight, livingRegion, breed),
                _ => throw new ArgumentException(MissingAnimalMessage)
            };
        }
    }
}