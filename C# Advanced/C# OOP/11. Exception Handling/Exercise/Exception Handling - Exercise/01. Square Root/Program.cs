using System;
using static SquareRoot.SquareRootCalculator;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            try
            {
                Console.WriteLine(SquareRootCalc(number));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye");
            }
        }
    }
}