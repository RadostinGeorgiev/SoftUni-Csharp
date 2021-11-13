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

            double wingSize;
            string livingRegion;
            string breed;

            switch (type)
            {
                case "Owl":
                    wingSize = double.Parse(animalArgs[3]);
                    animal = new Owl(name, weight, wingSize);
                    break;

                case "Hen":
                    wingSize = double.Parse(animalArgs[3]);
                    animal = new Hen(name, weight, wingSize);
                    break;

                case "Dog":
                    livingRegion = animalArgs[3];
                    animal = new Dog(name, weight, livingRegion);
                    break;

                case "Mouse":
                    livingRegion = animalArgs[3];
                    animal = new Mouse(name, weight, livingRegion);
                    break;

                case "Cat":
                    livingRegion = animalArgs[3];
                    breed = animalArgs[4];
                    animal = new Cat(name, weight, livingRegion, breed);
                    break;

                case "Tiger":
                    livingRegion = animalArgs[3];
                    breed = animalArgs[4];
                    animal = new Tiger(name, weight, livingRegion, breed);
                    break;

                default:
                    throw new ArgumentException(MissingAnimalMessage); 
            }

            return animal;
        }
    }
}