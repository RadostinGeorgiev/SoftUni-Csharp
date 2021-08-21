using System;

namespace _11._Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int multiplier = int.Parse(Console.ReadLine());
            int startNumber = int.Parse(Console.ReadLine());

            if (startNumber > 10)
            {
                Console.WriteLine($"{multiplier} X {startNumber} = {multiplier * startNumber}");
            }
            else
            {
                for (int i = startNumber; i <= 10; i++)
                {
                    Console.WriteLine($"{multiplier} X {i} = {multiplier * i}");
                }
            }
        }
    }
}
