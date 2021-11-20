using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                Animal animal = null;
                string[] animalArguments = Console.ReadLine().Split();

                try
                {
                    animal = GetAnimal(animalType, animalArguments);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                animals.Add(animal);
            }

            PrintOutput(animals);
        }

        private static void PrintOutput(List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public static Animal GetAnimal(string animalType, IReadOnlyList<string> animalArguments)
        {
            Animal animal;
            string name = animalArguments[0];
            int age = int.Parse(animalArguments[1]);
            string gender = string.Empty;
            if (animalArguments.Count > 2)
            {
                gender = animalArguments[2];
            }

            switch (animalType)
            {
                case "Dog":
                    animal = new Dog(name, age, gender);
                    break;

                case "Frog":
                    animal = new Frog(name, age, gender);
                    break;

                case "Cat":
                    animal = new Cat(name, age, gender);
                    break;

                case "Kitten":
                    animal = new Kitten(name, age);
                    break;

                case "Tomcat":
                    animal = new Tomcat(name, age);
                    break;

                default:
                    throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}