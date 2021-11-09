using System;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }
        string IPerson.GetName() => Name;

        public string Country { get; }
        string IResident.GetName() => "Mr/Ms/Mrs " + Name;

        public override string ToString()
            => $"{(this as IPerson).GetName()}{Environment.NewLine}" +
               $"{(this as IResident).GetName()}";
    }
}