using System;

namespace _09._Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string weather = Console.ReadLine();

            Console.WriteLine(weather == "sunny" ? "It's warm outside!" : "It's cold outside!");
        }
    }
}