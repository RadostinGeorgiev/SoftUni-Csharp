using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> peopels = new List<Person>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split().ToArray();
                Person person = new Person(info[0], info[1], int.Parse(info[2]));
                peopels.Add(person);

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine,peopels.OrderBy(x=>x.Age)));
        }
    }

    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public Person(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }
        
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
