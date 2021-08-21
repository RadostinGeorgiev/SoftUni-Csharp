using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double availableMoney = double.Parse(Console.ReadLine());
            int numberStudents = int.Parse(Console.ReadLine());
            double priceLightsabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double numberLightsabers = Math.Ceiling(numberStudents * 1.1);
            double freeBelts = numberStudents / 6;

            double totalPrice = numberLightsabers * priceLightsabers + numberStudents * priceRobes +
                                (numberStudents - freeBelts) * priceBelts;

            Console.WriteLine(availableMoney >= totalPrice ? $"The money is enough - it would cost {totalPrice:f2}lv." : $"John will need {totalPrice - availableMoney:f2}lv more.");
        }
    }
}
