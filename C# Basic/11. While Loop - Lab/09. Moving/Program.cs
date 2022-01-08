using System;

namespace _09._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            const int boxVolume = 1 * 1 * 1;
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int freeVolume = width * length * height;

            string boxes; ;
            while ((boxes = Console.ReadLine()) != "Done")
            {
                int currentBoxVolume = int.Parse(boxes) * boxVolume;
                freeVolume -= currentBoxVolume;

                if (freeVolume <= 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeVolume)} Cubic meters more.");
                    break;
                }
            }`

            if (boxes == "Done")
                Console.WriteLine($"{freeVolume} Cubic meters left.");
        }
    }
}