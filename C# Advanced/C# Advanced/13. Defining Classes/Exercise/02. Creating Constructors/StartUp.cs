using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();

            Person secondPerson = new Person(18);

            Person thirdPerson = new Person("Sam", 43);
        }
    }
}
