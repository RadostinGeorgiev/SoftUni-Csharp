using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> peoples = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split();
                string name = info[0];
                int age = int.Parse(info[1]);
                string town = info[2];
                Person person = new Person(name, age, town);
                peoples.Add(person);
            }

            int indexPerson = int.Parse(Console.ReadLine()) - 1;
            var currentPerson = peoples[indexPerson];

            int matchesCounter = peoples.Count(person => currentPerson.CompareTo(person) == 0);

            int totalPeoples = peoples.Count;
            Console.WriteLine(matchesCounter > 1
                ? $"{matchesCounter} {totalPeoples - matchesCounter} {totalPeoples}"
                : "No matches");
        }
    }
}