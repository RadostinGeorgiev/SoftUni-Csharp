using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var peoples = new List<(string name, int age)>();

            int number = int.Parse(Console.ReadLine());
            int age;
            for (int i = 0; i < number; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                age = int.Parse(info[1]);

                peoples.Add((name, age));
            }

            string condition = Console.ReadLine();
            age = int.Parse(Console.ReadLine());
            Func<(string name, int age), bool> filter = tuple => true;

            switch (condition)
            {
                case "younger":
                    filter = (person) => person.age < age;
                    break;
                case "older":
                    filter = (person) => person.age >= age;
                    break;
            }

            string format = Console.ReadLine();
            Func<(string name, int age), string> output = null;

            switch (format)
            {
                case "name":
                    output = x => $"{x.name}";
                    break;
                case "age":
                    output = x => $"{x.age}";
                    break;
                case "name age":
                    output = x => $"{x.name} - {x.age}";
                    break;
            }

            peoples.Where(filter).Select(output).ToList().ForEach(Console.WriteLine);
        }
    }
}
