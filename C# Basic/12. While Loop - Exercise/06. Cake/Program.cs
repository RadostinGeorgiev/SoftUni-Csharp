using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int pieceCakeArea = 1 * 1;
            int widthCake = int.Parse(Console.ReadLine());
            int lengthCake = int.Parse(Console.ReadLine());

            int restCakeArea = widthCake * lengthCake;

            string command;
            while ((command = Console.ReadLine()) != "STOP" && restCakeArea > 0)
            {
                int currentPiecesArea = int.Parse(command) * pieceCakeArea;
                restCakeArea -= currentPiecesArea;
            }

            Console.WriteLine(command == "STOP"
                ? $"{restCakeArea / pieceCakeArea} pieces are left."
                : $"No more cake left! You need {Math.Abs(restCakeArea)} pieces more.");
        }
    }
}