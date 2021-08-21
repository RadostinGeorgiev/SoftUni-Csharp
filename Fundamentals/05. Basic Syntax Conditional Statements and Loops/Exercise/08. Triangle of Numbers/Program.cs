using System;

namespace _08._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int rows = 1; rows <= number; rows++)
            {
                for (int columns = 1; columns <= rows; columns++)
                {
                    Console.Write(rows + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
