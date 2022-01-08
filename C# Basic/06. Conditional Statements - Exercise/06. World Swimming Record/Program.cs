using System;

namespace World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double record = double.Parse(Console.ReadLine());
            double meterDistance = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double swimmingTime = meterDistance * secondsPerMeter;
            double waterResistanceDelay = Math.Floor(meterDistance / 15) * 12.5;

            swimmingTime += waterResistanceDelay;

            Console.WriteLine(record <= swimmingTime
                ? $"No, he failed! He was {(swimmingTime - record):F2} seconds slower."
                : $"Yes, he succeeded! The new world record is {swimmingTime:F2} seconds.");
        }
    }
}