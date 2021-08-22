using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days =
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int dayOfWeek = int.Parse(Console.ReadLine());

            Console.WriteLine((dayOfWeek > 0) && (dayOfWeek <= days.Length) ? days[dayOfWeek-1] : "Invalid day!");
        }
    }
}
