using System;

namespace GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            var data = new Box<double>();
            for (int i = 0; i < lines; i++)
            {
                data.Add(double.Parse(Console.ReadLine()));
            }

            var comparedItem = double.Parse(Console.ReadLine());
            Console.WriteLine(data.Compare(comparedItem));
        }
    }
}