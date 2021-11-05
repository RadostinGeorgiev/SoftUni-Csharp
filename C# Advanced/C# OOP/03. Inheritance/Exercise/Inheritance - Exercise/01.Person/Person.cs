using System;
using System.Text;

namespace _01.Person
{
    public class Person
    {
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        private string name;
        private int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public override string ToString() => $"Name: {this.Name}, Age: {this.Age}";
    }
}