using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int numberPeoples = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberPeoples; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Person person = new Person(info[0], int.Parse(info[1]));
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }

        private List<Person> Members;

        public void AddMember(Person member)
        {
            Members.Add(member);
        }

        public Person GetOldestMember()
        {
            int maxAge = Members.Max(x => x.Age);
            return Members.First(x => x.Age == maxAge);
        }
    }
}
