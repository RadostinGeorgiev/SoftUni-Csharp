using System;

namespace _07.Working_Hours
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = int.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();

            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":
                    if ((time >= 10) && (time <= 18))
                        Console.WriteLine("open");
                    else
                        Console.WriteLine("closed");
                    break;
                default:
                    Console.WriteLine("closed");
                    break;
            }
        }
    }
}