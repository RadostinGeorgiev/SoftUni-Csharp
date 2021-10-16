using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> peoples = new HashSet<Person>();
            SortedSet<Person> sortedPeoples = new SortedSet<Person>();

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);

                Person person = new Person(name, age);
                peoples.Add(person);
                sortedPeoples.Add(person);
            }

            Console.WriteLine(peoples.Count);
            Console.WriteLine(sortedPeoples.Count);
        }
    }
}