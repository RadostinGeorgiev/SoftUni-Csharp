using System;

namespace Pipes_In_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volumePool = int.Parse(Console.ReadLine());
            int flowRatePipe1 = int.Parse(Console.ReadLine());
            int flowRatePipe2 = int.Parse(Console.ReadLine());
            double workingHours = double.Parse(Console.ReadLine());

            double filledVolumeFromPipe1 = workingHours * flowRatePipe1;
            double filledVolumeFromPipe2 = workingHours * flowRatePipe2;
            double filledVolumeTotal = filledVolumeFromPipe1 + filledVolumeFromPipe2;

            Console.WriteLine(filledVolumeTotal <= volumePool
                ? $"The pool is {filledVolumeTotal / volumePool * 100:f2}% full. Pipe 1: {filledVolumeFromPipe1 / filledVolumeTotal * 100:f2}%. Pipe 2: {filledVolumeFromPipe2 / filledVolumeTotal * 100:f2}%."
                : $"For {workingHours:f2} hours the pool overflows with {filledVolumeTotal - volumePool:f2} liters.");
        }
    }
}