using System;

namespace _05._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int tabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 0; i < tabs; i++)
            {
                string text = Console.ReadLine();

                if (text == "Facebook")
                    salary -= 150;
                else if (text == "Instagram")
                    salary -= 100;
                else if (text == "Reddit")
                    salary -= 50;

                if (salary == 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }

            if (salary != 0)
                Console.WriteLine($"{salary:F0}");
        }
    }
}