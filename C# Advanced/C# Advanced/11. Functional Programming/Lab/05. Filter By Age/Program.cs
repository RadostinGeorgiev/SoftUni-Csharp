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
            Func<(string name, int age), int, bool> younger = (person, age) => person.age < age;
            Func<(string name, int age), int, bool> older = (person, age) => person.age >= age;

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
            string[] format = Console.ReadLine().Split();

            switch (condition)
            {
                case "younger":
                    peoples = peoples
                        .Where(x => younger(x, age))
                        .ToList();
                    break;
                case "older":
                    peoples = peoples
                        .Where(x => older(x, age))
                        .ToList();
                    break;
            }

            if (format.Length > 1)
            {
                peoples.ForEach(x=>Console.WriteLine($"{x.name} - {x.age}"));
            }
            else
            {
                peoples.ForEach(x => Console.WriteLine(format[0] == "name" ? $"{x.name}" : $"{x.age}"));

            }
        } 
    }
}
