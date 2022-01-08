using System;

namespace _05._Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int menQuantity = int.Parse(Console.ReadLine());
            int womenQuantity = int.Parse(Console.ReadLine());
            int maxTables = int.Parse(Console.ReadLine());
            int appointment = 0;

            for (int man = 1; man <= menQuantity; man++)
            {
                for (int woman = 1; woman <= womenQuantity; woman++)
                {
                    appointment++;
                    Console.Write($"({man} <-> {woman}) ");

                    if (appointment == maxTables) return;
                }
            }
        }
    }
}