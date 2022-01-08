using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSteps = 0;

            string input;
            while ((input = Console.ReadLine()) != "Going home" && totalSteps < 10000)
            {
                int steps = int.Parse(input);
                totalSteps += steps;
            }

            if (input == "Going home")
            {
                totalSteps += int.Parse(Console.ReadLine());
            }

            if (totalSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{totalSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - totalSteps} more steps to reach goal.");
            }
        }
    }
}