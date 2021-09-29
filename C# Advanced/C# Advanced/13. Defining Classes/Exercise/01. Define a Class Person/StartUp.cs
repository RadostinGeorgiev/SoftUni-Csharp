using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person()
            {
                Name = "Peter",
                Age = 20
            };

            Person secondPerson = new Person()
            {
                Name = "George",
                Age = 18
            };

            Person thirdPerson = new Person()
            {
                Name = "Sam",
                Age = 43
            };
        }
    }
}