using System;

namespace GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var data = new Box<int>(int.Parse(Console.ReadLine()));
                Console.WriteLine(data);
            }
        }
    }
}
