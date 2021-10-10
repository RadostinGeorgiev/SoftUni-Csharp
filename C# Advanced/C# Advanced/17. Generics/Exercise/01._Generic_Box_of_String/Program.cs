using System;

namespace GenericBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var data = new Box<string>(Console.ReadLine());
                Console.WriteLine(data);
            }
        }
    }
}