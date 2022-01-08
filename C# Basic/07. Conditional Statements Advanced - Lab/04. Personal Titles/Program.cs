using System;

namespace _04._Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            string gender = Console.ReadLine();

            switch (gender)
            {
                case "m":
                    Console.WriteLine(age >= 16 ? "Mr." : "Master");
                    break;
                case "f":
                    Console.WriteLine(age >= 16 ? "Ms." : "Miss");
                    break;
            }
        }
    }
}