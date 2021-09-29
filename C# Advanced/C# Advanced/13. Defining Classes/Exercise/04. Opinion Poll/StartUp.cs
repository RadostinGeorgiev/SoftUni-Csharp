using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();

            for (int i = 1; i <= number; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                persons.Add(person);
            }

            persons.Where(x=>x.Age > 30).OrderBy(x=>x.Name).ToList().ForEach(Console.WriteLine);
        }
    }
}