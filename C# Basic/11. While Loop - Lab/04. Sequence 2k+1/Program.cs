using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sequence = 1;

            while (sequence <= number)
            {
                Console.WriteLine(sequence);
                sequence = sequence * 2 + 1;
            }
        }
    }
}