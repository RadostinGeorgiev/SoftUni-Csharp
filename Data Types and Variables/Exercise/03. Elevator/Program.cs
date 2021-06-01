using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int personNumber = int.Parse(Console.ReadLine());
            int elevatorCapacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)personNumber / elevatorCapacity);
            Console.WriteLine(courses);
        }
    }
}
