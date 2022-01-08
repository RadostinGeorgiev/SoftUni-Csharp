namespace _07._Moving
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int spaceWidth = int.Parse(Console.ReadLine());
            int spaceLength = int.Parse(Console.ReadLine());
            int spaceHeight = int.Parse(Console.ReadLine());

            int freeSpace = spaceWidth * spaceLength * spaceHeight;

            string boxes = "";
            while (freeSpace > 0 && (boxes = Console.ReadLine()) != "Done")
            {
                freeSpace -= int.Parse(boxes);
            }

            Console.WriteLine(boxes == "Done"
                ? $"{freeSpace} Cubic meters left."
                : $"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
        }
    }
}